<template>
  <div class="workShop-container">
    <el-card shadow="hover" :body-style="{ paddingBottom: '0' }">
      <el-form :model="queryParams" ref="queryForm" :inline="true">
        <el-form-item label="关键字">
          <el-input v-model="queryParams.searchKey" clearable="" placeholder="请输入模糊查询关键字"/>
          
        </el-form-item>
        <el-form-item label="车间代号">
          <el-input v-model="queryParams.workShopCode" clearable="" placeholder="请输入车间代号"/>
          
        </el-form-item>
        <el-form-item label="车间名称">
          <el-input v-model="queryParams.workShopName" clearable="" placeholder="请输入车间名称"/>
          
        </el-form-item>
        <el-form-item label="组织">
          <el-select clearable="" filterable="" v-model="queryParams.organId" placeholder="请选择组织">
            <el-option v-for="(item,index) in  organizationOrganIdDropdownList" :key="index" :value="item.value" :label="item.label" />
            
          </el-select>
          
        </el-form-item>
        <el-form-item>
          <el-button-group>
            <el-button type="primary"  icon="ele-Search" @click="handleQuery" v-auth="'workShop:page'"> 查询 </el-button>
            <el-button icon="ele-Refresh" @click="() => queryParams = {}"> 重置 </el-button>
            
          </el-button-group>
          
        </el-form-item>
        <el-form-item>
          <el-button type="primary" icon="ele-Plus" @click="openAddWorkShop" v-auth="'workShop:add'"> 新增 </el-button>
          
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
        <el-table-column prop="workShopCode" label="车间代号" width="140" show-overflow-tooltip="" />
        <el-table-column prop="workShopName" label="车间名称" width="140" show-overflow-tooltip="" />
        <el-table-column prop="organId" label="组织" width="120" show-overflow-tooltip="">
          <template #default="scope">
            <span>{{scope.row.organIdOrganName}}</span>
            
          </template>
          
        </el-table-column>
        <el-table-column label="操作" width="140" align="center" fixed="right" show-overflow-tooltip="" v-if="auth('workShop:edit') || auth('workShop:delete')">
          <template #default="scope">
            <el-button icon="ele-Edit" size="small" text="" type="primary" @click="openEditWorkShop(scope.row)" v-auth="'workShop:edit'"> 编辑 </el-button>
            <el-button icon="ele-Delete" size="small" text="" type="primary" @click="delWorkShop(scope.row)" v-auth="'workShop:delete'"> 删除 </el-button>
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
        :title="editWorkShopTitle"
        @reloadTable="handleQuery"
      />
    </el-card>
  </div>
</template>

<script lang="ts" setup="" name="workShop">
  import { ref } from "vue";
  import { ElMessageBox, ElMessage } from "element-plus";
  import { auth } from '/@/utils/authFunction';
  //import { formatDate } from '/@/utils/formatTime';

  import editDialog from '/@/views/main/workShop/component/editDialog.vue'
  import { pageWorkShop, deleteWorkShop } from '/@/api/main/workShop';
  import { getOrganizationOrganIdDropdown } from '/@/api/main/workShop';


  const editDialogRef = ref();
  const loading = ref(false);
  const tableData = ref<any>([]);
  const queryParams = ref<any>({});
  const tableParams = ref({
  page: 1,
  pageSize: 10,
  total: 0,
  });
  const editWorkShopTitle = ref("");


  // 查询操作
  const handleQuery = async () => {
    loading.value = true;
    var res = await pageWorkShop(Object.assign(queryParams.value, tableParams.value));
    tableData.value = res.data.result?.items ?? [];
    tableParams.value.total = res.data.result?.total;
    loading.value = false;
  };

  // 打开新增页面
  const openAddWorkShop = () => {
    editWorkShopTitle.value = '添加车间';
    editDialogRef.value.openDialog({});
  };

  // 打开编辑页面
  const openEditWorkShop = (row: any) => {
    editWorkShopTitle.value = '编辑车间';
    editDialogRef.value.openDialog(row);
  };

  // 删除
  const delWorkShop = (row: any) => {
    ElMessageBox.confirm(`确定要删除吗?`, "提示", {
    confirmButtonText: "确定",
    cancelButtonText: "取消",
    type: "warning",
  })
  .then(async () => {
    await deleteWorkShop(row);
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

  const organizationOrganIdDropdownList = ref<any>([]); 
  const getOrganizationOrganIdDropdownList = async () => {
    let list = await getOrganizationOrganIdDropdown();
    organizationOrganIdDropdownList.value = list.data.result ?? [];
  };
  getOrganizationOrganIdDropdownList();


  handleQuery();
</script>


