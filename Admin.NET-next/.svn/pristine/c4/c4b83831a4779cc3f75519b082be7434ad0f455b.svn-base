<template>
  <div class="processingFactorySalesContractSubsidiary-container">
    <el-card shadow="hover" :body-style="{ paddingBottom: '0' }">
      <el-form :model="queryParams" ref="queryForm" labelWidth="90">
        <el-row>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10">
            <el-form-item label="关键字">
              <el-input v-model="queryParams.searchKey" clearable="" placeholder="请输入模糊查询关键字"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="主表id">
              <el-input v-model="queryParams.parentId" clearable="" placeholder="请输入主表id"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="结算方式">
              <el-input v-model="queryParams.settlement" clearable="" placeholder="请输入结算方式"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="商品id">
              <el-input v-model="queryParams.goodsId" clearable="" placeholder="请输入商品id"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="商品编码">
              <el-input v-model="queryParams.goodsSno" clearable="" placeholder="请输入商品编码"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="商品名称">
              <el-input v-model="queryParams.goodsName" clearable="" placeholder="请输入商品名称"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="税点">
              <el-input v-model="queryParams.tax" clearable="" placeholder="请输入税点"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="用量">
              <el-input v-model="queryParams.qty" clearable="" placeholder="请输入用量"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="不良率">
              <el-input v-model="queryParams.defectRate" clearable="" placeholder="请输入不良率"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="最小包装量">
              <el-input-number v-model="queryParams.mPQ"  clearable="" placeholder="请输入最小包装量"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="最小订单量">
              <el-input-number v-model="queryParams.mOQ"  clearable="" placeholder="请输入最小订单量"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="备注">
              <el-input v-model="queryParams.meMo" clearable="" placeholder="请输入备注"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="数量">
              <el-input-number v-model="queryParams.quantity"  clearable="" placeholder="请输入数量"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="含税单价">
              <el-input v-model="queryParams.price" clearable="" placeholder="请输入含税单价"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="已发数量">
              <el-input-number v-model="queryParams.lssuedQuantity"  clearable="" placeholder="请输入已发数量"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="状态">
              <el-input v-model="queryParams.status" clearable="" placeholder="请输入状态"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="单位">
              <el-input v-model="queryParams.unit" clearable="" placeholder="请输入单位"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="金额">
              <el-input v-model="queryParams.amount" clearable="" placeholder="请输入金额"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="交货日期">
              <el-input-number v-model="queryParams.deliveryDate"  clearable="" placeholder="请输入交货日期"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="排单交期">
              <el-date-picker placeholder="请选择排单交期" value-format="YYYY/MM/DD" type="daterange" v-model="queryParams.schedulingDeliveryDateRange" />
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="商品标签模板">
              <el-input v-model="queryParams.labelTemplate" clearable="" placeholder="请输入商品标签模板"/>
              
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
                <el-button type="primary"  icon="ele-Search" @click="handleQuery" v-auth="'processingFactorySalesContractSubsidiary:page'"> 查询 </el-button>
                <el-button icon="ele-Refresh" @click="() => queryParams = {}"> 重置 </el-button>
                <el-button icon="ele-ZoomIn" @click="changeAdvanceQueryUI" v-if="!showAdvanceQueryUI"> 高级 </el-button>
                <el-button icon="ele-ZoomOut" @click="changeAdvanceQueryUI" v-if="showAdvanceQueryUI"> 隐藏 </el-button>
                
              </el-button-group>
              
              <el-button-group style="margin-left:20px">
                <el-button type="primary" icon="ele-Plus" @click="openAddProcessingFactorySalesContractSubsidiary" v-auth="'processingFactorySalesContractSubsidiary:add'"> 新增 </el-button>
                
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
        <el-table-column prop="parentId" label="主表id" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="settlement" label="结算方式" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="goodsId" label="商品id" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="goodsSno" label="商品编码" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="goodsName" label="商品名称" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="tax" label="税点" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="qty" label="用量" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="defectRate" label="不良率" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="mPQ" label="最小包装量" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="mOQ" label="最小订单量" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="meMo" label="备注" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="quantity" label="数量" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="price" label="含税单价" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="lssuedQuantity" label="已发数量" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="status" label="状态" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="unit" label="单位" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="amount" label="金额" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="deliveryDate" label="交货日期" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="schedulingDeliveryDate" label="排单交期" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="labelTemplate" label="商品标签模板" width="90"  show-overflow-tooltip="" />
        <el-table-column prop="reVision" label="乐观锁" width="140"  show-overflow-tooltip="" />
        <el-table-column label="操作" width="140" align="center" fixed="right" show-overflow-tooltip="" v-if="auth('processingFactorySalesContractSubsidiary:edit') || auth('processingFactorySalesContractSubsidiary:delete')">
          <template #default="scope">
            <el-button icon="ele-Edit" size="small" text="" type="primary" @click="openEditProcessingFactorySalesContractSubsidiary(scope.row)" v-auth="'processingFactorySalesContractSubsidiary:edit'"> 编辑 </el-button>
            <el-button icon="ele-Delete" size="small" text="" type="primary" @click="delProcessingFactorySalesContractSubsidiary(scope.row)" v-auth="'processingFactorySalesContractSubsidiary:delete'"> 删除 </el-button>
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
        :title="printProcessingFactorySalesContractSubsidiaryTitle"
        @reloadTable="handleQuery" />
      <editDialog
        ref="editDialogRef"
        :title="editProcessingFactorySalesContractSubsidiaryTitle"
        @reloadTable="handleQuery"
      />
    </el-card>
  </div>
</template>

<script lang="ts" setup="" name="processingFactorySalesContractSubsidiary">
  import { ref } from "vue";
  import { ElMessageBox, ElMessage } from "element-plus";
  import { auth } from '/@/utils/authFunction';
  import { getDictDataItem as di, getDictDataList as dl } from '/@/utils/dict-utils';
  import { formatDate } from '/@/utils/formatTime';


  import printDialog from '/@/views/system/print/component/hiprint/preview.vue'
  import editDialog from '/@/views/main/processingFactorySalesContractSubsidiary/component/editDialog.vue'
  import { pageProcessingFactorySalesContractSubsidiary, deleteProcessingFactorySalesContractSubsidiary } from '/@/api/main/processingFactorySalesContractSubsidiary';


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

  const printProcessingFactorySalesContractSubsidiaryTitle = ref("");
  const editProcessingFactorySalesContractSubsidiaryTitle = ref("");

  // 改变高级查询的控件显示状态
  const changeAdvanceQueryUI = () => {
    showAdvanceQueryUI.value = !showAdvanceQueryUI.value;
  }
  

  // 查询操作
  const handleQuery = async () => {
    loading.value = true;
    var res = await pageProcessingFactorySalesContractSubsidiary(Object.assign(queryParams.value, tableParams.value));
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
  const openAddProcessingFactorySalesContractSubsidiary = () => {
    editProcessingFactorySalesContractSubsidiaryTitle.value = '添加加工厂合同从表';
    editDialogRef.value.openDialog({});
  };

  // 打开打印页面
  const openPrintProcessingFactorySalesContractSubsidiary = async (row: any) => {
    printProcessingFactorySalesContractSubsidiaryTitle.value = '打印加工厂合同从表';
  }
  
  // 打开编辑页面
  const openEditProcessingFactorySalesContractSubsidiary = (row: any) => {
    editProcessingFactorySalesContractSubsidiaryTitle.value = '编辑加工厂合同从表';
    editDialogRef.value.openDialog(row);
  };

  // 删除
  const delProcessingFactorySalesContractSubsidiary = (row: any) => {
    ElMessageBox.confirm(`确定要删除吗?`, "提示", {
    confirmButtonText: "确定",
    cancelButtonText: "取消",
    type: "warning",
  })
  .then(async () => {
    await deleteProcessingFactorySalesContractSubsidiary(row);
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

