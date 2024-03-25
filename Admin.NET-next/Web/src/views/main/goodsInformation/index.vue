<template>
  <div class="goodsInformation-container">
    <el-card shadow="hover" :body-style="{ paddingBottom: '0' }">
      <el-form :model="queryParams" ref="queryForm" labelWidth="90">
        <el-row>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10">
            <el-form-item label="关键字">
              <el-input v-model="queryParams.searchKey" clearable="" placeholder="请输入模糊查询关键字"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="编码">
              <el-input v-model="queryParams.sno" clearable="" placeholder="请输入编码"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="内部编码">
              <el-input v-model="queryParams.pN" clearable="" placeholder="请输入内部编码"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="品名">
              <el-input v-model="queryParams.cnName" clearable="" placeholder="请输入品名"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="英文品名">
              <el-input v-model="queryParams.enName" clearable="" placeholder="请输入英文品名"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="规格">
              <el-input v-model="queryParams.model" clearable="" placeholder="请输入规格"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="助记码">
              <el-input v-model="queryParams.shortcutCode" clearable="" placeholder="请输入助记码"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="制造商">
              <el-input v-model="queryParams.mfr" clearable="" placeholder="请输入制造商"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="制造商型号">
              <el-input v-model="queryParams.mfrModel" clearable="" placeholder="请输入制造商型号"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="存货类别">
              <el-input v-model="queryParams.inventoryCategory" clearable="" placeholder="请输入存货类别"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="单位">
              <el-input v-model="queryParams.unit" clearable="" placeholder="请输入单位"/>
              
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
            <el-form-item label="分类父id">
              <el-input v-model="queryParams.parentCategoryId" clearable="" placeholder="请输入分类父id"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="分类子id">
              <el-input v-model="queryParams.subclassificationId" clearable="" placeholder="请输入分类子id"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="库存上限">
              <el-input-number v-model="queryParams.upperLimit"  clearable="" placeholder="请输入库存上限"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="库存下限">
              <el-input-number v-model="queryParams.lowerLimit"  clearable="" placeholder="请输入库存下限"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="条码">
              <el-input v-model="queryParams.barcode" clearable="" placeholder="请输入条码"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="限制批数">
              <el-input-number v-model="queryParams.restrictedLots"  clearable="" placeholder="请输入限制批数"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="生产状态">
              <el-input-number v-model="queryParams.statuses"  clearable="" placeholder="请输入生产状态"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="含税指导价">
              <el-input v-model="queryParams.guidePrice" clearable="" placeholder="请输入含税指导价"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="未税指导价">
              <el-input v-model="queryParams.noGuidePrice" clearable="" placeholder="请输入未税指导价"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="可销售">
              <el-input-number v-model="queryParams.marketable"  clearable="" placeholder="请输入可销售"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="可生产">
              <el-input-number v-model="queryParams.burnable"  clearable="" placeholder="请输入可生产"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="可采购">
              <el-input-number v-model="queryParams.purchasable"  clearable="" placeholder="请输入可采购"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="审核信息提示">
              <el-input v-model="queryParams.status" clearable="" placeholder="请输入审核信息提示"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="完成状态">
              <el-input-number v-model="queryParams.completeStatus"  clearable="" placeholder="请输入完成状态"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="供应商名">
              <el-input v-model="queryParams.supplierName" clearable="" placeholder="请输入供应商名"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="加工厂名">
              <el-input v-model="queryParams.processingPlantName" clearable="" placeholder="请输入加工厂名"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="交期">
              <el-date-picker placeholder="请选择交期" value-format="YYYY/MM/DD" type="daterange" v-model="queryParams.deliveryTimeRange" />
              
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
                <el-button type="primary"  icon="ele-Search" @click="handleQuery" v-auth="'goodsInformation:page'"> 查询 </el-button>
                <el-button icon="ele-Refresh" @click="() => queryParams = {}"> 重置 </el-button>
                <el-button icon="ele-ZoomIn" @click="changeAdvanceQueryUI" v-if="!showAdvanceQueryUI"> 高级 </el-button>
                <el-button icon="ele-ZoomOut" @click="changeAdvanceQueryUI" v-if="showAdvanceQueryUI"> 隐藏 </el-button>
                
              </el-button-group>
              
              <el-button-group style="margin-left:20px">
                <el-button type="primary" icon="ele-Plus" @click="openAddGoodsInformation" v-auth="'goodsInformation:add'"> 新增 </el-button>
                
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
        <el-table-column prop="sno" label="编码" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="pN" label="内部编码" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="cnName" label="品名" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="enName" label="英文品名" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="model" label="规格" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="shortcutCode" label="助记码" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="mfr" label="制造商" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="mfrModel" label="制造商型号" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="inventoryCategory" label="存货类别" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="unit" label="单位" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="mPQ" label="最小包装量" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="mOQ" label="最小订单量" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="parentCategoryId" label="分类父id" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="subclassificationId" label="分类子id" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="upperLimit" label="库存上限" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="lowerLimit" label="库存下限" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="barcode" label="条码" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="restrictedLots" label="限制批数" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="statuses" label="生产状态" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="guidePrice" label="含税指导价" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="noGuidePrice" label="未税指导价" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="marketable" label="可销售" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="burnable" label="可生产" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="purchasable" label="可采购" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="status" label="审核信息提示" width="90"  show-overflow-tooltip="" />
        <el-table-column prop="completeStatus" label="完成状态" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="supplierName" label="供应商名" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="processingPlantName" label="加工厂名" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="deliveryTime" label="交期" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="reVision" label="乐观锁" width="140"  show-overflow-tooltip="" />
        <el-table-column label="操作" width="140" align="center" fixed="right" show-overflow-tooltip="" v-if="auth('goodsInformation:edit') || auth('goodsInformation:delete')">
          <template #default="scope">
            <el-button icon="ele-Edit" size="small" text="" type="primary" @click="openEditGoodsInformation(scope.row)" v-auth="'goodsInformation:edit'"> 编辑 </el-button>
            <el-button icon="ele-Delete" size="small" text="" type="primary" @click="delGoodsInformation(scope.row)" v-auth="'goodsInformation:delete'"> 删除 </el-button>
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
        :title="printGoodsInformationTitle"
        @reloadTable="handleQuery" />
      <editDialog
        ref="editDialogRef"
        :title="editGoodsInformationTitle"
        @reloadTable="handleQuery"
      />
    </el-card>
  </div>
</template>

<script lang="ts" setup="" name="goodsInformation">
  import { ref } from "vue";
  import { ElMessageBox, ElMessage } from "element-plus";
  import { auth } from '/@/utils/authFunction';
  import { getDictDataItem as di, getDictDataList as dl } from '/@/utils/dict-utils';
  import { formatDate } from '/@/utils/formatTime';


  import printDialog from '/@/views/system/print/component/hiprint/preview.vue'
  import editDialog from '/@/views/main/goodsInformation/component/editDialog.vue'
  import { pageGoodsInformation, deleteGoodsInformation } from '/@/api/main/goodsInformation';


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

  const printGoodsInformationTitle = ref("");
  const editGoodsInformationTitle = ref("");

  // 改变高级查询的控件显示状态
  const changeAdvanceQueryUI = () => {
    showAdvanceQueryUI.value = !showAdvanceQueryUI.value;
  }
  

  // 查询操作
  const handleQuery = async () => {
    loading.value = true;
    var res = await pageGoodsInformation(Object.assign(queryParams.value, tableParams.value));
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
  const openAddGoodsInformation = () => {
    editGoodsInformationTitle.value = '添加商品资料表';
    editDialogRef.value.openDialog({});
  };

  // 打开打印页面
  const openPrintGoodsInformation = async (row: any) => {
    printGoodsInformationTitle.value = '打印商品资料表';
  }
  
  // 打开编辑页面
  const openEditGoodsInformation = (row: any) => {
    editGoodsInformationTitle.value = '编辑商品资料表';
    editDialogRef.value.openDialog(row);
  };

  // 删除
  const delGoodsInformation = (row: any) => {
    ElMessageBox.confirm(`确定要删除吗?`, "提示", {
    confirmButtonText: "确定",
    cancelButtonText: "取消",
    type: "warning",
  })
  .then(async () => {
    await deleteGoodsInformation(row);
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

