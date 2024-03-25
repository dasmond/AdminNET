<template>
  <div class="customer-container">
    <el-card shadow="hover" :body-style="{ paddingBottom: '0' }">
      <el-form :model="queryParams" ref="queryForm" labelWidth="90">
        <el-row>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10">
            <el-form-item label="关键字">
              <el-input v-model="queryParams.searchKey" clearable="" placeholder="请输入模糊查询关键字"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="备注">
              <el-input v-model="queryParams.meMo" clearable="" placeholder="请输入备注"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="编码">
              <el-input v-model="queryParams.sno" clearable="" placeholder="请输入编码"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="客户名称">
              <el-input v-model="queryParams.name" clearable="" placeholder="请输入客户名称"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="客户所属人id">
              <el-input v-model="queryParams.belongtoId" clearable="" placeholder="请输入客户所属人id"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="上任业务员id">
              <el-input v-model="queryParams.predecessor" clearable="" placeholder="请输入上任业务员id"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="助理id">
              <el-input v-model="queryParams.assistantId" clearable="" placeholder="请输入助理id"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="助理分配时间">
              <el-date-picker placeholder="请选择助理分配时间" value-format="YYYY/MM/DD" type="daterange" v-model="queryParams.assistantAllocationTimeRange" />
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="简称">
              <el-input v-model="queryParams.shortName" clearable="" placeholder="请输入简称"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="客户类型">
              <el-input v-model="queryParams.customerType" clearable="" placeholder="请输入客户类型"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="省">
              <el-input v-model="queryParams.province" clearable="" placeholder="请输入省"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="市">
              <el-input v-model="queryParams.city" clearable="" placeholder="请输入市"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="区">
              <el-input v-model="queryParams.area" clearable="" placeholder="请输入区"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="邮编">
              <el-input v-model="queryParams.zip" clearable="" placeholder="请输入邮编"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="固定电话">
              <el-input v-model="queryParams.fixedPhoen" clearable="" placeholder="请输入固定电话"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="传真">
              <el-input v-model="queryParams.fax" clearable="" placeholder="请输入传真"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="开户银行">
              <el-input v-model="queryParams.bank" clearable="" placeholder="请输入开户银行"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="银行账号">
              <el-input v-model="queryParams.bankId" clearable="" placeholder="请输入银行账号"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="纳税号">
              <el-input v-model="queryParams.taxId" clearable="" placeholder="请输入纳税号"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="公司主页">
              <el-input v-model="queryParams.url" clearable="" placeholder="请输入公司主页"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="主营业务">
              <el-input v-model="queryParams.mainBusiness" clearable="" placeholder="请输入主营业务"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="信用评级">
              <el-input v-model="queryParams.creditRating" clearable="" placeholder="请输入信用评级"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="经纬度">
              <el-input v-model="queryParams.center" clearable="" placeholder="请输入经纬度"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="结算方式">
              <el-input v-model="queryParams.settlement" clearable="" placeholder="请输入结算方式"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="乐观锁">
              <el-input-number v-model="queryParams.reVision"  clearable="" placeholder="请输入乐观锁"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="6" :xl="6" class="mb10">
            <el-form-item>
              <el-button-group>
                <el-button type="primary"  icon="ele-Search" @click="handleQuery" v-auth="'customer:page'"> 查询 </el-button>
                <el-button icon="ele-Refresh" @click="() => queryParams = {}"> 重置 </el-button>
                <el-button icon="ele-ZoomIn" @click="changeAdvanceQueryUI" v-if="!showAdvanceQueryUI"> 高级 </el-button>
                <el-button icon="ele-ZoomOut" @click="changeAdvanceQueryUI" v-if="showAdvanceQueryUI"> 隐藏 </el-button>
                
              </el-button-group>
              
              <el-button-group style="margin-left:20px">
                <el-button type="primary" icon="ele-Plus" @click="openAddCustomer" v-auth="'customer:add'"> 新增 </el-button>
                
              </el-button-group>
              
            </el-form-item>
            
          </el-col>
        </el-row>
      </el-form>
    </el-card>
    <el-card class="full-table" shadow="hover" style="margin-top: 8px">
      <el-table
				:data="tableData"
				style="width: 100%"
				v-loading="loading"
				tooltip-effect="light"
				row-key="id"
                @sort-change="sortChange"
				border="">
        <el-table-column type="index" label="序号" width="55" align="center"/>
        <el-table-column prop="meMo" label="备注" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="sno" label="编码" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="name" label="客户名称" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="belongtoId" label="客户所属人id" width="105"  show-overflow-tooltip="" />
        <el-table-column prop="predecessor" label="上任业务员id" width="105"  show-overflow-tooltip="" />
        <el-table-column prop="assistantId" label="助理id" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="assistantAllocationTime" label="助理分配时间" width="90"  show-overflow-tooltip="" />
        <el-table-column prop="shortName" label="简称" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="customerType" label="客户类型" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="province" label="省" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="city" label="市" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="area" label="区" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="zip" label="邮编" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="fixedPhoen" label="固定电话" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="fax" label="传真" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="bank" label="开户银行" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="bankId" label="银行账号" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="taxId" label="纳税号" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="url" label="公司主页" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="mainBusiness" label="主营业务" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="creditRating" label="信用评级" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="center" label="经纬度" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="settlement" label="结算方式" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="reVision" label="乐观锁" width="140"  show-overflow-tooltip="" />
        <el-table-column label="操作" width="140" align="center" fixed="right" show-overflow-tooltip="" v-if="auth('customer:edit') || auth('customer:delete')">
          <template #default="scope">
            <el-button icon="ele-Edit" size="small" text="" type="primary" @click="openEditCustomer(scope.row)" v-auth="'customer:edit'"> 编辑 </el-button>
            <el-button icon="ele-Delete" size="small" text="" type="primary" @click="delCustomer(scope.row)" v-auth="'customer:delete'"> 删除 </el-button>
          </template>
        </el-table-column>
      </el-table>
      <el-pagination
				v-model:currentPage="tableParams.page"
				v-model:page-size="tableParams.pageSize"
				:total="tableParams.total"
				:page-sizes="[10, 20, 50, 100, 200, 500]"
				small=""
				background=""
				@size-change="handleSizeChange"
				@current-change="handleCurrentChange"
				layout="total, sizes, prev, pager, next, jumper"
	/>
      <printDialog
        ref="printDialogRef"
        :title="printCustomerTitle"
        @reloadTable="handleQuery" />
      <editDialog
        ref="editDialogRef"
        :title="editCustomerTitle"
        @reloadTable="handleQuery"
      />
    </el-card>
  </div>
</template>

<script lang="ts" setup="" name="customer">
  import { ref } from "vue";
  import { ElMessageBox, ElMessage } from "element-plus";
  import { auth } from '/@/utils/authFunction';
  import { getDictDataItem as di, getDictDataList as dl } from '/@/utils/dict-utils';
  import { formatDate } from '/@/utils/formatTime';


  import printDialog from '/@/views/system/print/component/hiprint/preview.vue'
  import editDialog from '/@/views/main/customer/component/editDialog.vue'
  import { pageCustomer, deleteCustomer } from '/@/api/main/customer';


  const showAdvanceQueryUI = ref(false);
  const printDialogRef = ref();
  const editDialogRef = ref();
  const loading = ref(false);
  const tableData = ref<any>([]);
  const queryParams = ref<any>({});
  const tableParams = ref({
    page: 1,
    pageSize: 10,
    total: 0,
  });

  const printCustomerTitle = ref("");
  const editCustomerTitle = ref("");

  // 改变高级查询的控件显示状态
  const changeAdvanceQueryUI = () => {
    showAdvanceQueryUI.value = !showAdvanceQueryUI.value;
  }
  

  // 查询操作
  const handleQuery = async () => {
    loading.value = true;
    var res = await pageCustomer(Object.assign(queryParams.value, tableParams.value));
    tableData.value = res.data.result?.items ?? [];
    tableParams.value.total = res.data.result?.total;
    loading.value = false;
  };

  // 列排序
  const sortChange = async (column: any) => {
	queryParams.value.field = column.prop;
	queryParams.value.order = column.order;
	await handleQuery();
  };

  // 打开新增页面
  const openAddCustomer = () => {
    editCustomerTitle.value = '添加客户资料';
    editDialogRef.value.openDialog({});
  };

  // 打开打印页面
  const openPrintCustomer = async (row: any) => {
    printCustomerTitle.value = '打印客户资料';
  }
  
  // 打开编辑页面
  const openEditCustomer = (row: any) => {
    editCustomerTitle.value = '编辑客户资料';
    editDialogRef.value.openDialog(row);
  };

  // 删除
  const delCustomer = (row: any) => {
    ElMessageBox.confirm(`确定要删除吗?`, "提示", {
    confirmButtonText: "确定",
    cancelButtonText: "取消",
    type: "warning",
  })
  .then(async () => {
    await deleteCustomer(row);
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
<style scoped>
:deep(.el-ipnut),
:deep(.el-select),
:deep(.el-input-number) {
	width: 100%;
}
</style>

