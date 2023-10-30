<template>
  <div class="t_WorkGroup-container">
    <el-card shadow="hover" :body-style="{ paddingBottom: '0' }">
      <el-form :model="queryParams" ref="queryForm" :inline="true">
        <el-form-item label="关键字">
          <el-input v-model="queryParams.searchKey" clearable="" placeholder="请输入模糊查询关键字"/>
          
        </el-form-item>
        <el-form-item label="生产中心编号">
          <el-input v-model="queryParams.workGroupCode" clearable="" placeholder="请输入生产中心编号"/>
          
        </el-form-item>
        <el-form-item label="生产中心名称">
          <el-input v-model="queryParams.workGroupName" clearable="" placeholder="请输入生产中心名称"/>
          
        </el-form-item>
        <el-form-item label="生产中心简称">
          <el-input v-model="queryParams.workGroupSimpleName" clearable="" placeholder="请输入生产中心简称"/>
          
        </el-form-item>
        <el-form-item label="所属车间">
          <el-select clearable="" filterable="" v-model="queryParams.workShopID" placeholder="请选择所属车间">
            <el-option v-for="(item,index) in  t_WorkShopWorkShopIDDropdownList" :key="index" :value="item.value" :label="item.label" />
            
          </el-select>
          
        </el-form-item>
        <el-form-item>
          <el-button-group>
            <el-button type="primary"  icon="ele-Search" @click="handleQuery" v-auth="'t_WorkGroup:page'"> 查询 </el-button>
            <el-button icon="ele-Refresh" @click="() => queryParams = {}"> 重置 </el-button>
            
          </el-button-group>
          
        </el-form-item>
        <el-form-item>
          <el-button type="primary" icon="ele-Plus" @click="openAddT_WorkGroup" v-auth="'t_WorkGroup:add'"> 新增 </el-button>
          
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
        <el-table-column prop="workGroupCode" label="生产中心编号" width="90" show-overflow-tooltip="" />
        <el-table-column prop="workGroupName" label="生产中心名称" width="90" show-overflow-tooltip="" />
        <el-table-column prop="workGroupSimpleName" label="生产中心简称" width="90" show-overflow-tooltip="" />
        <el-table-column prop="workShopID" label="所属车间" width="120" show-overflow-tooltip="">
          <template #default="scope">
            <span>{{scope.row.workShopIDWorkShopName}}</span>
            
          </template>
          
        </el-table-column>
        <el-table-column label="操作" width="140" align="center" fixed="right" show-overflow-tooltip="" v-if="auth('t_WorkGroup:edit') || auth('t_WorkGroup:delete')">
          <template #default="scope">
            <el-button icon="ele-Edit" size="small" text="" type="primary" @click="openEditT_WorkGroup(scope.row)" v-auth="'t_WorkGroup:edit'"> 编辑 </el-button>
            <el-button icon="ele-Delete" size="small" text="" type="primary" @click="delT_WorkGroup(scope.row)" v-auth="'t_WorkGroup:delete'"> 删除 </el-button>
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
        :title="editT_WorkGroupTitle"
        @reloadTable="handleQuery"
      />
    </el-card>
  </div>
</template>

<script lang="ts" setup="" name="t_WorkGroup">
  import { ref } from "vue";
  import { ElMessageBox, ElMessage } from "element-plus";
  import { auth } from '/@/utils/authFunction';
  //import { formatDate } from '/@/utils/formatTime';

  import editDialog from '/@/views/main/t_WorkGroup/component/editDialog.vue'
  import { pageT_WorkGroup, deleteT_WorkGroup } from '/@/api/main/t_WorkGroup';
  import { getT_WorkShopWorkShopIDDropdown } from '/@/api/main/t_WorkGroup';


  const editDialogRef = ref();
  const loading = ref(false);
  const tableData = ref<any>([]);
  const queryParams = ref<any>({});
  const tableParams = ref({
  page: 1,
  pageSize: 10,
  total: 0,
  });
  const editT_WorkGroupTitle = ref("");


  // 查询操作
  const handleQuery = async () => {
    loading.value = true;
    var res = await pageT_WorkGroup(Object.assign(queryParams.value, tableParams.value));
    tableData.value = res.data.result?.items ?? [];
    tableParams.value.total = res.data.result?.total;
    loading.value = false;
  };

  // 打开新增页面
  const openAddT_WorkGroup = () => {
    editT_WorkGroupTitle.value = '添加生产中心';
    editDialogRef.value.openDialog({});
  };

  // 打开编辑页面
  const openEditT_WorkGroup = (row: any) => {
    editT_WorkGroupTitle.value = '编辑生产中心';
    editDialogRef.value.openDialog(row);
  };

  // 删除
  const delT_WorkGroup = (row: any) => {
    ElMessageBox.confirm(`确定要删除吗?`, "提示", {
    confirmButtonText: "确定",
    cancelButtonText: "取消",
    type: "warning",
  })
  .then(async () => {
    await deleteT_WorkGroup(row);
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

  const t_WorkShopWorkShopIDDropdownList = ref<any>([]); 
  const getT_WorkShopWorkShopIDDropdownList = async () => {
    let list = await getT_WorkShopWorkShopIDDropdown();
    t_WorkShopWorkShopIDDropdownList.value = list.data.result ?? [];
  };
  getT_WorkShopWorkShopIDDropdownList();


  handleQuery();
</script>


