<template>
  <div class="supplierOrder-container">
    <el-card shadow="hover" :body-style="{ paddingBottom: '0' }">
      <el-form :model="queryParams" ref="queryForm" labelWidth="90">
        <el-row>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10">
            <el-form-item label="关键字">
              <el-input v-model="queryParams.searchKey" clearable="" placeholder="请输入模糊查询关键字"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="合同id">
              <el-input v-model="queryParams.snoId" clearable="" placeholder="请输入合同id"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="合同编码">
              <el-input v-model="queryParams.sno" clearable="" placeholder="请输入合同编码"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="订单编码">
              <el-input v-model="queryParams.orderSno" clearable="" placeholder="请输入订单编码"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="物流收货单id">
              <el-input v-model="queryParams.logisticsReceiptId" clearable="" placeholder="请输入物流收货单id"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="购方合同编码">
              <el-input v-model="queryParams.purchaserSno" clearable="" placeholder="请输入购方合同编码"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="合同详情id">
              <el-input v-model="queryParams.snoDetailsId" clearable="" placeholder="请输入合同详情id"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="商品id">
              <el-input v-model="queryParams.goodsId" clearable="" placeholder="请输入商品id"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="入库数量">
              <el-input v-model="queryParams.quantity" clearable="" placeholder="请输入入库数量"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="超出数量">
              <el-input v-model="queryParams.exceedQuantity" clearable="" placeholder="请输入超出数量"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="打印次数">
              <el-input-number v-model="queryParams.count"  clearable="" placeholder="请输入打印次数"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="发货方式">
              <el-input v-model="queryParams.delivery" clearable="" placeholder="请输入发货方式"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="快递单号">
              <el-input v-model="queryParams.trackingNumber" clearable="" placeholder="请输入快递单号"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="审核信息提示">
              <el-input v-model="queryParams.status" clearable="" placeholder="请输入审核信息提示"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="审批完成状态">
              <el-input-number v-model="queryParams.completeStatus"  clearable="" placeholder="请输入审批完成状态"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="联系人名称">
              <el-input v-model="queryParams.contactsName" clearable="" placeholder="请输入联系人名称"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="客户名称">
              <el-input v-model="queryParams.customerName" clearable="" placeholder="请输入客户名称"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="收货人">
              <el-input v-model="queryParams.consigneeName" clearable="" placeholder="请输入收货人"/>
              
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
                <el-button type="primary"  icon="ele-Search" @click="handleQuery" v-auth="'supplierOrder:page'"> 查询 </el-button>
                <el-button icon="ele-Refresh" @click="() => queryParams = {}"> 重置 </el-button>
                <el-button icon="ele-ZoomIn" @click="changeAdvanceQueryUI" v-if="!showAdvanceQueryUI"> 高级 </el-button>
                <el-button icon="ele-ZoomOut" @click="changeAdvanceQueryUI" v-if="showAdvanceQueryUI"> 隐藏 </el-button>
                
              </el-button-group>
              
              <el-button-group style="margin-left:20px">
                <el-button type="primary" icon="ele-Plus" @click="openAddSupplierOrder" v-auth="'supplierOrder:add'"> 新增 </el-button>
                
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
        <el-table-column prop="snoId" label="合同id" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="sno" label="合同编码" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="orderSno" label="订单编码" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="logisticsReceiptId" label="物流收货单id" width="105"  show-overflow-tooltip="" />
        <el-table-column prop="purchaserSno" label="购方合同编码" width="90"  show-overflow-tooltip="" />
        <el-table-column prop="snoDetailsId" label="合同详情id" width="90"  show-overflow-tooltip="" />
        <el-table-column prop="goodsId" label="商品id" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="quantity" label="入库数量" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="exceedQuantity" label="超出数量" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="count" label="打印次数" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="delivery" label="发货方式" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="trackingNumber" label="快递单号" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="status" label="审核信息提示" width="90"  show-overflow-tooltip="" />
        <el-table-column prop="completeStatus" label="审批完成状态" width="90"  show-overflow-tooltip="" />
        <el-table-column prop="contactsName" label="联系人名称" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="customerName" label="客户名称" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="consigneeName" label="收货人" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="reVision" label="乐观锁" width="140"  show-overflow-tooltip="" />
        <el-table-column label="操作" width="140" align="center" fixed="right" show-overflow-tooltip="" v-if="auth('supplierOrder:edit') || auth('supplierOrder:delete')">
          <template #default="scope">
            <el-button icon="ele-Edit" size="small" text="" type="primary" @click="openEditSupplierOrder(scope.row)" v-auth="'supplierOrder:edit'"> 编辑 </el-button>
            <el-button icon="ele-Delete" size="small" text="" type="primary" @click="delSupplierOrder(scope.row)" v-auth="'supplierOrder:delete'"> 删除 </el-button>
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
        :title="printSupplierOrderTitle"
        @reloadTable="handleQuery" />
      <editDialog
        ref="editDialogRef"
        :title="editSupplierOrderTitle"
        @reloadTable="handleQuery"
      />
    </el-card>
  </div>
</template>

<script lang="ts" setup="" name="supplierOrder">
  import { ref } from "vue";
  import { ElMessageBox, ElMessage } from "element-plus";
  import { auth } from '/@/utils/authFunction';
  import { getDictDataItem as di, getDictDataList as dl } from '/@/utils/dict-utils';
  import { formatDate } from '/@/utils/formatTime';


  import printDialog from '/@/views/system/print/component/hiprint/preview.vue'
  import editDialog from '/@/views/main/supplierOrder/component/editDialog.vue'
  import { pageSupplierOrder, deleteSupplierOrder } from '/@/api/main/supplierOrder';


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

  const printSupplierOrderTitle = ref("");
  const editSupplierOrderTitle = ref("");

  // 改变高级查询的控件显示状态
  const changeAdvanceQueryUI = () => {
    showAdvanceQueryUI.value = !showAdvanceQueryUI.value;
  }
  

  // 查询操作
  const handleQuery = async () => {
    loading.value = true;
    var res = await pageSupplierOrder(Object.assign(queryParams.value, tableParams.value));
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
  const openAddSupplierOrder = () => {
    editSupplierOrderTitle.value = '添加供应商订单';
    editDialogRef.value.openDialog({});
  };

  // 打开打印页面
  const openPrintSupplierOrder = async (row: any) => {
    printSupplierOrderTitle.value = '打印供应商订单';
  }
  
  // 打开编辑页面
  const openEditSupplierOrder = (row: any) => {
    editSupplierOrderTitle.value = '编辑供应商订单';
    editDialogRef.value.openDialog(row);
  };

  // 删除
  const delSupplierOrder = (row: any) => {
    ElMessageBox.confirm(`确定要删除吗?`, "提示", {
    confirmButtonText: "确定",
    cancelButtonText: "取消",
    type: "warning",
  })
  .then(async () => {
    await deleteSupplierOrder(row);
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

