<template>
  <div class="workGroup-container">
    <el-card shadow="hover" :body-style="{ paddingBottom: '0' }">
      <el-form :model="queryParams" ref="queryForm" :inline="true">
        <el-form-item label="关键字">
          <el-input v-model="queryParams.searchKey" clearable="" placeholder="请输入模糊查询关键字"/>
          
        </el-form-item>
        <el-form-item label="工作组编号">
          <el-input v-model="queryParams.workGroupCode" clearable="" placeholder="请输入工作组编号"/>
          
        </el-form-item>
        <el-form-item label="工作组名称">
          <el-input v-model="queryParams.workGroupName" clearable="" placeholder="请输入工作组名称"/>
          
        </el-form-item>
        <el-form-item label="工作组简称">
          <el-input v-model="queryParams.workGroupSimpleName" clearable="" placeholder="请输入工作组简称"/>
          
        </el-form-item>
        <el-form-item label="车间Id">
          <el-input v-model="queryParams.workShopId" clearable="" placeholder="请输入车间Id"/>
          
        </el-form-item>
        <el-form-item>
          <el-button-group>
            <el-button type="primary"  icon="ele-Search" @click="handleQuery" v-auth="'workGroup:page'"> 查询 </el-button>
            <el-button icon="ele-Refresh" @click="() => queryParams = {}"> 重置 </el-button>
            
          </el-button-group>
          
        </el-form-item>
        <el-form-item>
          <el-button type="primary" icon="ele-Plus" @click="openAddWorkGroup" v-auth="'workGroup:add'"> 新增 </el-button>
          
        </el-form-item>
        
      </el-form>
    </el-card>
    <el-card class="full-table" shadow="hover" style="margin-top: 8px">
      <el-table
				:data="tableData"
				style="width: 100%"
				v-loading="loading"
				tooltip-effect="light"
				row-key="id"
				border="">
        <el-table-column type="index" label="序号" width="55" align="center"/>
        <el-table-column prop="workGroupCode" label="工作组编号" width="140" show-overflow-tooltip="" />
        <el-table-column prop="workGroupName" label="工作组名称" width="140" show-overflow-tooltip="" />
        <el-table-column prop="workGroupSimpleName" label="工作组简称" width="140" show-overflow-tooltip="" />
        <el-table-column prop="workShopId" label="车间Id" width="140" show-overflow-tooltip="" />
        <el-table-column label="操作" width="140" align="center" fixed="right" show-overflow-tooltip="" v-if="auth('workGroup:edit') || auth('workGroup:delete')">
          <template #default="scope">
            <el-button icon="ele-Edit" size="small" text="" type="primary" @click="openEditWorkGroup(scope.row)" v-auth="'workGroup:edit'"> 编辑 </el-button>
            <el-button icon="ele-Delete" size="small" text="" type="primary" @click="delWorkGroup(scope.row)" v-auth="'workGroup:delete'"> 删除 </el-button>
          </template>
        </el-table-column>
      </el-table>
      <el-pagination
				v-model:currentPage="tableParams.page"
				v-model:page-size="tableParams.pageSize"
				:total="tableParams.total"
				:page-sizes="[10, 20, 50, 100, 200]"
				small=""
				background=""
				@size-change="handleSizeChange"
				@current-change="handleCurrentChange"
				layout="total, sizes, prev, pager, next, jumper"
	/>
      <editDialog
        ref="editDialogRef"
        :title="editWorkGroupTitle"
        @reloadTable="handleQuery"
      />
    </el-card>
  </div>
</template>

<script lang="ts" setup="" name="workGroup">
  import { ref } from "vue";
  import { ElMessageBox, ElMessage } from "element-plus";
  import { auth } from '/@/utils/authFunction';
  //import { formatDate } from '/@/utils/formatTime';

  import editDialog from '/@/views/main/workGroup/component/editDialog.vue'
  import { pageWorkGroup, deleteWorkGroup } from '/@/api/main/workGroup';


  const editDialogRef = ref();
  const loading = ref(false);
  const tableData = ref<any>([]);
  const queryParams = ref<any>({});
  const tableParams = ref({
  page: 1,
  pageSize: 10,
  total: 0,
  });
  const editWorkGroupTitle = ref("");


  // 查询操作
  const handleQuery = async () => {
    loading.value = true;
    var res = await pageWorkGroup(Object.assign(queryParams.value, tableParams.value));
    tableData.value = res.data.result?.items ?? [];
    tableParams.value.total = res.data.result?.total;
    loading.value = false;
  };

  // 打开新增页面
  const openAddWorkGroup = () => {
    editWorkGroupTitle.value = '添加工作中心';
    editDialogRef.value.openDialog({});
  };

  // 打开编辑页面
  const openEditWorkGroup = (row: any) => {
    editWorkGroupTitle.value = '编辑工作中心';
    editDialogRef.value.openDialog(row);
  };

  // 删除
  const delWorkGroup = (row: any) => {
    ElMessageBox.confirm(`确定要删除吗?`, "提示", {
    confirmButtonText: "确定",
    cancelButtonText: "取消",
    type: "warning",
  })
  .then(async () => {
    await deleteWorkGroup(row);
    handleQuery();
    ElMessage.success("删除成功");
  })
  .catch(() => {});
  };

  // 改变页面容量
  const handleSizeChange = (val: number) => {
    tableParams.value.pageSize = val;
    handleQuery();
  };

  // 改变页码序号
  const handleCurrentChange = (val: number) => {
    tableParams.value.page = val;
    handleQuery();
  };


  handleQuery();
</script>


