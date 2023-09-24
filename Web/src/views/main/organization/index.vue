<template>
  <div class="organization-container">
    <el-card shadow="hover" :body-style="{ paddingBottom: '0' }">
      <el-form :model="queryParams" ref="queryForm" :inline="true">
        <el-form-item label="关键字">
          <el-input v-model="queryParams.searchKey" clearable="" placeholder="请输入模糊查询关键字"/>
          
        </el-form-item>
        <el-form-item label="组织代号">
          <el-input v-model="queryParams.organCode" clearable="" placeholder="请输入组织代号"/>
          
        </el-form-item>
        <el-form-item label="组织名称">
          <el-input v-model="queryParams.organName" clearable="" placeholder="请输入组织名称"/>
          
        </el-form-item>
        <el-form-item>
          <el-button-group>
            <el-button type="primary"  icon="ele-Search" @click="handleQuery" v-auth="'organization:page'"> 查询 </el-button>
            <el-button icon="ele-Refresh" @click="() => queryParams = {}"> 重置 </el-button>
            
          </el-button-group>
          
        </el-form-item>
        <el-form-item>
          <el-button type="primary" icon="ele-Plus" @click="openAddOrganization" v-auth="'organization:add'"> 新增 </el-button>
          
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
        <el-table-column prop="organCode" label="组织代号" width="140" show-overflow-tooltip="" />
        <el-table-column prop="organName" label="组织名称" width="140" show-overflow-tooltip="" />
        <el-table-column label="操作" width="140" align="center" fixed="right" show-overflow-tooltip="" v-if="auth('organization:edit') || auth('organization:delete')">
          <template #default="scope">
            <el-button icon="ele-Edit" size="small" text="" type="primary" @click="openEditOrganization(scope.row)" v-auth="'organization:edit'"> 编辑 </el-button>
            <el-button icon="ele-Delete" size="small" text="" type="primary" @click="delOrganization(scope.row)" v-auth="'organization:delete'"> 删除 </el-button>
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
        :title="editOrganizationTitle"
        @reloadTable="handleQuery"
      />
    </el-card>
  </div>
</template>

<script lang="ts" setup="" name="organization">
  import { ref } from "vue";
  import { ElMessageBox, ElMessage } from "element-plus";
  import { auth } from '/@/utils/authFunction';
  //import { formatDate } from '/@/utils/formatTime';

  import editDialog from '/@/views/main/organization/component/editDialog.vue'
  import { pageOrganization, deleteOrganization } from '/@/api/main/organization';


  const editDialogRef = ref();
  const loading = ref(false);
  const tableData = ref<any>([]);
  const queryParams = ref<any>({});
  const tableParams = ref({
  page: 1,
  pageSize: 10,
  total: 0,
  });
  const editOrganizationTitle = ref("");


  // 查询操作
  const handleQuery = async () => {
    loading.value = true;
    var res = await pageOrganization(Object.assign(queryParams.value, tableParams.value));
    tableData.value = res.data.result?.items ?? [];
    tableParams.value.total = res.data.result?.total;
    loading.value = false;
  };

  // 打开新增页面
  const openAddOrganization = () => {
    editOrganizationTitle.value = '添加组织';
    editDialogRef.value.openDialog({});
  };

  // 打开编辑页面
  const openEditOrganization = (row: any) => {
    editOrganizationTitle.value = '编辑组织';
    editDialogRef.value.openDialog(row);
  };

  // 删除
  const delOrganization = (row: any) => {
    ElMessageBox.confirm(`确定要删除吗?`, "提示", {
    confirmButtonText: "确定",
    cancelButtonText: "取消",
    type: "warning",
  })
  .then(async () => {
    await deleteOrganization(row);
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


