<template>
  <div class="t_WorkShop-container">
    <el-card shadow="hover" :body-style="{ paddingBottom: '0' }">
      <el-form :model="queryParams" ref="queryForm" :inline="true">
        <el-form-item label="关键字">
          <el-input v-model="queryParams.searchKey" clearable="" placeholder="请输入模糊查询关键字"/>
          
        </el-form-item>
        <el-form-item label="车间编号">
          <el-input v-model="queryParams.workShopCode" clearable="" placeholder="请输入车间编号"/>
          
        </el-form-item>
        <el-form-item label="车间名称">
          <el-input v-model="queryParams.workShopName" clearable="" placeholder="请输入车间名称"/>
          
        </el-form-item>
        <el-form-item label="所属机构Id">
          <el-select clearable="" filterable="" v-model="queryParams.orgId" placeholder="请选择所属机构Id">
            <el-option v-for="(item,index) in  sysOrgOrgIdDropdownList" :key="index" :value="item.value" :label="item.label" />
            
          </el-select>
          
        </el-form-item>
        <el-form-item>
          <el-button-group>
            <el-button type="primary"  icon="ele-Search" @click="handleQuery" v-auth="'t_WorkShop:page'"> 查询 </el-button>
            <el-button icon="ele-Refresh" @click="() => queryParams = {}"> 重置 </el-button>
            
          </el-button-group>
          
        </el-form-item>
        <el-form-item>
          <el-button type="primary" icon="ele-Plus" @click="openAddT_WorkShop" v-auth="'t_WorkShop:add'"> 新增 </el-button>
          
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
        <el-table-column prop="workShopCode" label="车间编号" width="140" show-overflow-tooltip="" />
        <el-table-column prop="workShopName" label="车间名称" width="140" show-overflow-tooltip="" />
        <el-table-column prop="orgId" label="所属机构Id" width="90" show-overflow-tooltip="">
          <template #default="scope">
            <span>{{scope.row.orgIdId}}</span>

          </template>

        </el-table-column>
        <el-table-column label="操作" width="140" align="center" fixed="right" show-overflow-tooltip="" v-if="auth('t_WorkShop:edit') || auth('t_WorkShop:delete')">
          <template #default="scope">
            <el-button icon="ele-Edit" size="small" text="" type="primary" @click="openEditT_WorkShop(scope.row)" v-auth="'t_WorkShop:edit'"> 编辑 </el-button>
            <el-button icon="ele-Delete" size="small" text="" type="primary" @click="delT_WorkShop(scope.row)" v-auth="'t_WorkShop:delete'"> 删除 </el-button>
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
        :title="editT_WorkShopTitle"
        @reloadTable="handleQuery"
      />
    </el-card>
  </div>
</template>

<script lang="ts" setup="" name="t_WorkShop">
  import { ref } from "vue";
  import { ElMessageBox, ElMessage } from "element-plus";
  import { auth } from '/@/utils/authFunction';
  //import { formatDate } from '/@/utils/formatTime';

  import editDialog from '/@/views/main/t_WorkShop/component/editDialog.vue'
  import { pageT_WorkShop, deleteT_WorkShop } from '/@/api/main/t_WorkShop';
  import { getSysOrgOrgIdDropdown } from '/@/api/main/t_WorkShop';
  import router from "/@/router";


  const editDialogRef = ref();
  const loading = ref(false);
  const tableData = ref<any>([]);
  const queryParams = ref<any>({});
  const tableParams = ref({
  page: 1,
  pageSize: 10,
  total: 0,
  });
  const editT_WorkShopTitle = ref("");


  // 查询操作
  const handleQuery = async () => {
    loading.value = true;
    var res = await pageT_WorkShop(Object.assign(queryParams.value, tableParams.value));
    tableData.value = res.data.result?.items ?? [];
    tableParams.value.total = res.data.result?.total;
    loading.value = false;
  };

  // 打开新增页面
  const openAddT_WorkShop = () => {
    // editT_WorkShopTitle.value = '添加车间';
    // editDialogRef.value.openDialog({});
    router.push('/manufacturing/info/t_workshop/add')
  };

  // 打开编辑页面
  const openEditT_WorkShop = (row: any) => {
    // editT_WorkShopTitle.value = '编辑车间';
    // editDialogRef.value.openDialog(row);
    router.push({path: '/manufacturing/info/t_workshop/add', query: row})
  };

  // 删除
  const delT_WorkShop = (row: any) => {
    ElMessageBox.confirm(`确定要删除吗?`, "提示", {
    confirmButtonText: "确定",
    cancelButtonText: "取消",
    type: "warning",
  })
  .then(async () => {
    await deleteT_WorkShop(row);
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

  const sysOrgOrgIdDropdownList = ref<any>([]); 
  const getSysOrgOrgIdDropdownList = async () => {
    let list = await getSysOrgOrgIdDropdown();
    sysOrgOrgIdDropdownList.value = list.data.result ?? [];
  };
  getSysOrgOrgIdDropdownList();


  handleQuery();
</script>


