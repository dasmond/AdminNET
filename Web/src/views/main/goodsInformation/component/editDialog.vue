<template>
	<div class="goodsInformation-container">
		<el-dialog v-model="isShowDialog" :width="800" draggable="">
			<template #header>
				<div style="color: #fff">
					<!--<el-icon size="16" style="margin-right: 3px; display: inline; vertical-align: middle"> <ele-Edit /> </el-icon>-->
					<span>{{ props.title }}</span>
				</div>
			</template>
			<el-form :model="ruleForm" ref="ruleFormRef" label-width="auto" :rules="rules">
				<el-row :gutter="35">
					<el-form-item v-show="false">
						<el-input v-model="ruleForm.id" />
					</el-form-item>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="编码" prop="sno">
							<el-input v-model="ruleForm.sno" placeholder="请输入编码" maxlength="255" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="内部编码" prop="pN">
							<el-input v-model="ruleForm.pN" placeholder="请输入内部编码" maxlength="255" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="品名" prop="cnName">
							<el-input v-model="ruleForm.cnName" placeholder="请输入品名" maxlength="255" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="英文品名" prop="enName">
							<el-input v-model="ruleForm.enName" placeholder="请输入英文品名" maxlength="255" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="规格" prop="model">
							<el-input v-model="ruleForm.model" placeholder="请输入规格" maxlength="255" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="助记码" prop="shortcutCode">
							<el-input v-model="ruleForm.shortcutCode" placeholder="请输入助记码" maxlength="255" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="制造商" prop="mfr">
							<el-input v-model="ruleForm.mfr" placeholder="请输入制造商" maxlength="255" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="制造商型号" prop="mfrModel">
							<el-input v-model="ruleForm.mfrModel" placeholder="请输入制造商型号" maxlength="255" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="存货类别" prop="inventoryCategory">
							<el-input v-model="ruleForm.inventoryCategory" placeholder="请输入存货类别" maxlength="255" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="单位" prop="unit">
							<el-input v-model="ruleForm.unit" placeholder="请输入单位" maxlength="255" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="最小包装量" prop="mPQ">
							<el-input-number v-model="ruleForm.mPQ" placeholder="请输入最小包装量" clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="最小订单量" prop="mOQ">
							<el-input-number v-model="ruleForm.mOQ" placeholder="请输入最小订单量" clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="分类父id" prop="parentCategoryId">
							<el-input v-model="ruleForm.parentCategoryId" placeholder="请输入分类父id" maxlength="19" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="分类子id" prop="subclassificationId">
							<el-input v-model="ruleForm.subclassificationId" placeholder="请输入分类子id" maxlength="19" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="库存上限" prop="upperLimit">
							<el-input-number v-model="ruleForm.upperLimit" placeholder="请输入库存上限" clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="库存下限" prop="lowerLimit">
							<el-input-number v-model="ruleForm.lowerLimit" placeholder="请输入库存下限" clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="条码" prop="barcode">
							<el-input v-model="ruleForm.barcode" placeholder="请输入条码" maxlength="255" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="限制批数" prop="restrictedLots">
							<el-input-number v-model="ruleForm.restrictedLots" placeholder="请输入限制批数" clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="生产状态" prop="statuses">
							<el-input-number v-model="ruleForm.statuses" placeholder="请输入生产状态" clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="含税指导价" prop="guidePrice">
							<el-input v-model="ruleForm.guidePrice" placeholder="请输入含税指导价" maxlength="18" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="未税指导价" prop="noGuidePrice">
							<el-input v-model="ruleForm.noGuidePrice" placeholder="请输入未税指导价" maxlength="18" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="可销售" prop="marketable">
							<el-input-number v-model="ruleForm.marketable" placeholder="请输入可销售" clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="可生产" prop="burnable">
							<el-input-number v-model="ruleForm.burnable" placeholder="请输入可生产" clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="可采购" prop="purchasable">
							<el-input-number v-model="ruleForm.purchasable" placeholder="请输入可采购" clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="审核信息提示" prop="status">
							<el-input v-model="ruleForm.status" placeholder="请输入审核信息提示" maxlength="255" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="完成状态" prop="completeStatus">
							<el-input-number v-model="ruleForm.completeStatus" placeholder="请输入完成状态" clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="供应商名" prop="supplierName">
							<el-input v-model="ruleForm.supplierName" placeholder="请输入供应商名" maxlength="255" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="加工厂名" prop="processingPlantName">
							<el-input v-model="ruleForm.processingPlantName" placeholder="请输入加工厂名" maxlength="255" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="交期" prop="deliveryTime">
							<el-date-picker v-model="ruleForm.deliveryTime" type="date" placeholder="交期" />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="乐观锁" prop="reVision">
							<el-input-number v-model="ruleForm.reVision" placeholder="请输入乐观锁" clearable />
							
						</el-form-item>
						
					</el-col>
				</el-row>
			</el-form>
			<template #footer>
				<span class="dialog-footer">
					<el-button @click="cancel">取 消</el-button>
					<el-button type="primary" @click="submit">确 定</el-button>
				</span>
			</template>
		</el-dialog>
	</div>
</template>
<style scoped>
:deep(.el-select),
:deep(.el-input-number) {
	width: 100%;
}
</style>
<script lang="ts" setup>
	import { ref,onMounted } from "vue";
	import { getDictDataItem as di, getDictDataList as dl } from '/@/utils/dict-utils';
	import { ElMessage } from "element-plus";
	import type { FormRules } from "element-plus";
	import { addGoodsInformation, updateGoodsInformation, detailGoodsInformation } from "/@/api/main/goodsInformation";

	//父级传递来的参数
	var props = defineProps({
		title: {
		type: String,
		default: "",
	},
	});
	//父级传递来的函数，用于回调
	const emit = defineEmits(["reloadTable"]);
	const ruleFormRef = ref();
	const isShowDialog = ref(false);
	const ruleForm = ref<any>({});
	//自行添加其他规则
	const rules = ref<FormRules>({
		sno: [{required: true, message: '请输入编码！', trigger: 'blur',},],
		pN: [{required: true, message: '请输入内部编码！', trigger: 'blur',},],
		cnName: [{required: true, message: '请输入品名！', trigger: 'blur',},],
		enName: [{required: true, message: '请输入英文品名！', trigger: 'blur',},],
		model: [{required: true, message: '请输入规格！', trigger: 'blur',},],
		shortcutCode: [{required: true, message: '请输入助记码！', trigger: 'blur',},],
		mfr: [{required: true, message: '请输入制造商！', trigger: 'blur',},],
		mfrModel: [{required: true, message: '请输入制造商型号！', trigger: 'blur',},],
		inventoryCategory: [{required: true, message: '请输入存货类别！', trigger: 'blur',},],
		unit: [{required: true, message: '请输入单位！', trigger: 'blur',},],
		mPQ: [{required: true, message: '请输入最小包装量！', trigger: 'blur',},],
		mOQ: [{required: true, message: '请输入最小订单量！', trigger: 'blur',},],
		parentCategoryId: [{required: true, message: '请输入分类父id！', trigger: 'blur',},],
		subclassificationId: [{required: true, message: '请输入分类子id！', trigger: 'blur',},],
		upperLimit: [{required: true, message: '请输入库存上限！', trigger: 'blur',},],
		lowerLimit: [{required: true, message: '请输入库存下限！', trigger: 'blur',},],
		barcode: [{required: true, message: '请输入条码！', trigger: 'blur',},],
		restrictedLots: [{required: true, message: '请输入限制批数！', trigger: 'blur',},],
		statuses: [{required: true, message: '请输入生产状态！', trigger: 'blur',},],
		guidePrice: [{required: true, message: '请输入含税指导价！', trigger: 'blur',},],
		noGuidePrice: [{required: true, message: '请输入未税指导价！', trigger: 'blur',},],
		marketable: [{required: true, message: '请输入可销售！', trigger: 'blur',},],
		burnable: [{required: true, message: '请输入可生产！', trigger: 'blur',},],
		purchasable: [{required: true, message: '请输入可采购！', trigger: 'blur',},],
		status: [{required: true, message: '请输入审核信息提示！', trigger: 'blur',},],
		completeStatus: [{required: true, message: '请输入完成状态！', trigger: 'blur',},],
		supplierName: [{required: true, message: '请输入供应商名！', trigger: 'blur',},],
		processingPlantName: [{required: true, message: '请输入加工厂名！', trigger: 'blur',},],
		reVision: [{required: true, message: '请输入乐观锁！', trigger: 'blur',},],
	});

	// 打开弹窗
	const openDialog = async (row: any) => {
		// ruleForm.value = JSON.parse(JSON.stringify(row));
		// 改用detail获取最新数据来编辑
		let rowData = JSON.parse(JSON.stringify(row));
		if (rowData.id)
			ruleForm.value = (await detailGoodsInformation(rowData.id)).data.result;
		else
			ruleForm.value = rowData;
		isShowDialog.value = true;
	};

	// 关闭弹窗
	const closeDialog = () => {
		emit("reloadTable");
		isShowDialog.value = false;
	};

	// 取消
	const cancel = () => {
		isShowDialog.value = false;
	};

	// 提交
	const submit = async () => {
		ruleFormRef.value.validate(async (isValid: boolean, fields?: any) => {
			if (isValid) {
				let values = ruleForm.value;
				if (ruleForm.value.id == undefined || ruleForm.value.id == null || ruleForm.value.id == "" || ruleForm.value.id == 0) {
					await addGoodsInformation(values);
				} else {
					await updateGoodsInformation(values);
				}
				closeDialog();
			} else {
				ElMessage({
					message: `表单有${Object.keys(fields).length}处验证失败，请修改后再提交`,
					type: "error",
				});
			}
		});
	};







	// 页面加载时
	onMounted(async () => {
	});

	//将属性或者函数暴露给父组件
	defineExpose({ openDialog });
</script>




