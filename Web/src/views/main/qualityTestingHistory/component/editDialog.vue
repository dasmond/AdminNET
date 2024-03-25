<template>
	<div class="qualityTestingHistory-container">
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
						<el-form-item label="物流收货id" prop="logisticsReceiptId">
							<el-input v-model="ruleForm.logisticsReceiptId" placeholder="请输入物流收货id" maxlength="19" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="合同id" prop="salesContractSnoId">
							<el-input v-model="ruleForm.salesContractSnoId" placeholder="请输入合同id" maxlength="19" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="合同编号" prop="salesContractSno">
							<el-input v-model="ruleForm.salesContractSno" placeholder="请输入合同编号" maxlength="255" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="客户id" prop="customerId">
							<el-input v-model="ruleForm.customerId" placeholder="请输入客户id" maxlength="19" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="客户名称" prop="customerName">
							<el-input v-model="ruleForm.customerName" placeholder="请输入客户名称" maxlength="255" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="业务员" prop="salesman">
							<el-input v-model="ruleForm.salesman" placeholder="请输入业务员" maxlength="255" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="商品id" prop="goodsId">
							<el-input v-model="ruleForm.goodsId" placeholder="请输入商品id" maxlength="19" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="商品编号" prop="goodsSno">
							<el-input v-model="ruleForm.goodsSno" placeholder="请输入商品编号" maxlength="255" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="商品型号" prop="mfrModel">
							<el-input v-model="ruleForm.mfrModel" placeholder="请输入商品型号" maxlength="255" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="商品名" prop="goodsName">
							<el-input v-model="ruleForm.goodsName" placeholder="请输入商品名" maxlength="255" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="备注" prop="meMo">
							<el-input v-model="ruleForm.meMo" placeholder="请输入备注" maxlength="255" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="商品来货数量" prop="goodsOrderQuantity">
							<el-input-number v-model="ruleForm.goodsOrderQuantity" placeholder="请输入商品来货数量" clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="单位" prop="unit">
							<el-input v-model="ruleForm.unit" placeholder="请输入单位" maxlength="255" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="验收数量" prop="checkAndAcceptQuantity">
							<el-input v-model="ruleForm.checkAndAcceptQuantity" placeholder="请输入验收数量" maxlength="18" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="验退数量" prop="rejectionQuantity">
							<el-input v-model="ruleForm.rejectionQuantity" placeholder="请输入验退数量" maxlength="18" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="不合格原因" prop="unqualified">
							<el-input v-model="ruleForm.unqualified" placeholder="请输入不合格原因" maxlength="255" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="类型" prop="typesOf">
							<el-input-number v-model="ruleForm.typesOf" placeholder="请输入类型" clearable />
							
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
	import { addQualityTestingHistory, updateQualityTestingHistory, detailQualityTestingHistory } from "/@/api/main/qualityTestingHistory";

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
		logisticsReceiptId: [{required: true, message: '请输入物流收货id！', trigger: 'blur',},],
		salesContractSnoId: [{required: true, message: '请输入合同id！', trigger: 'blur',},],
		salesContractSno: [{required: true, message: '请输入合同编号！', trigger: 'blur',},],
		customerId: [{required: true, message: '请输入客户id！', trigger: 'blur',},],
		customerName: [{required: true, message: '请输入客户名称！', trigger: 'blur',},],
		salesman: [{required: true, message: '请输入业务员！', trigger: 'blur',},],
		goodsId: [{required: true, message: '请输入商品id！', trigger: 'blur',},],
		goodsSno: [{required: true, message: '请输入商品编号！', trigger: 'blur',},],
		mfrModel: [{required: true, message: '请输入商品型号！', trigger: 'blur',},],
		goodsName: [{required: true, message: '请输入商品名！', trigger: 'blur',},],
		meMo: [{required: true, message: '请输入备注！', trigger: 'blur',},],
		goodsOrderQuantity: [{required: true, message: '请输入商品来货数量！', trigger: 'blur',},],
		unit: [{required: true, message: '请输入单位！', trigger: 'blur',},],
		checkAndAcceptQuantity: [{required: true, message: '请输入验收数量！', trigger: 'blur',},],
		rejectionQuantity: [{required: true, message: '请输入验退数量！', trigger: 'blur',},],
		unqualified: [{required: true, message: '请输入不合格原因！', trigger: 'blur',},],
		typesOf: [{required: true, message: '请输入类型！', trigger: 'blur',},],
		reVision: [{required: true, message: '请输入乐观锁！', trigger: 'blur',},],
	});

	// 打开弹窗
	const openDialog = async (row: any) => {
		// ruleForm.value = JSON.parse(JSON.stringify(row));
		// 改用detail获取最新数据来编辑
		let rowData = JSON.parse(JSON.stringify(row));
		if (rowData.id)
			ruleForm.value = (await detailQualityTestingHistory(rowData.id)).data.result;
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
					await addQualityTestingHistory(values);
				} else {
					await updateQualityTestingHistory(values);
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




