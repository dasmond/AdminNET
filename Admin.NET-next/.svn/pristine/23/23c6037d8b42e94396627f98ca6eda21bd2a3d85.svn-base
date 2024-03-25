<template>
	<div class="logisticsReceipt-container">
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
						<el-form-item label="合同id" prop="contractId">
							<el-input v-model="ruleForm.contractId" placeholder="请输入合同id" maxlength="19" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="物流收货编码" prop="logisticsReceiptSno">
							<el-input v-model="ruleForm.logisticsReceiptSno" placeholder="请输入物流收货编码" maxlength="255" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="合同编码" prop="contractSno">
							<el-input v-model="ruleForm.contractSno" placeholder="请输入合同编码" maxlength="255" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="购方合同编码" prop="purchaserSno">
							<el-input v-model="ruleForm.purchaserSno" placeholder="请输入购方合同编码" maxlength="255" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="商品id" prop="goodsId">
							<el-input v-model="ruleForm.goodsId" placeholder="请输入商品id" maxlength="19" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="商品名称" prop="goodsName">
							<el-input v-model="ruleForm.goodsName" placeholder="请输入商品名称" maxlength="255" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="来货数量" prop="quantity">
							<el-input-number v-model="ruleForm.quantity" placeholder="请输入来货数量" clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="送货方式" prop="delivery">
							<el-input v-model="ruleForm.delivery" placeholder="请输入送货方式" maxlength="255" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="快递单号" prop="trackingNumber">
							<el-input v-model="ruleForm.trackingNumber" placeholder="请输入快递单号" maxlength="255" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="物流公司" prop="logisticsCompany">
							<el-input v-model="ruleForm.logisticsCompany" placeholder="请输入物流公司" maxlength="255" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="送货单号" prop="deliveryNoteNumber">
							<el-input v-model="ruleForm.deliveryNoteNumber" placeholder="请输入送货单号" maxlength="255" show-word-limit clearable />
							
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
	import { addLogisticsReceipt, updateLogisticsReceipt, detailLogisticsReceipt } from "/@/api/main/logisticsReceipt";

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
		contractId: [{required: true, message: '请输入合同id！', trigger: 'blur',},],
		logisticsReceiptSno: [{required: true, message: '请输入物流收货编码！', trigger: 'blur',},],
		contractSno: [{required: true, message: '请输入合同编码！', trigger: 'blur',},],
		purchaserSno: [{required: true, message: '请输入购方合同编码！', trigger: 'blur',},],
		goodsId: [{required: true, message: '请输入商品id！', trigger: 'blur',},],
		goodsName: [{required: true, message: '请输入商品名称！', trigger: 'blur',},],
		quantity: [{required: true, message: '请输入来货数量！', trigger: 'blur',},],
		delivery: [{required: true, message: '请输入送货方式！', trigger: 'blur',},],
		trackingNumber: [{required: true, message: '请输入快递单号！', trigger: 'blur',},],
		logisticsCompany: [{required: true, message: '请输入物流公司！', trigger: 'blur',},],
		deliveryNoteNumber: [{required: true, message: '请输入送货单号！', trigger: 'blur',},],
		typesOf: [{required: true, message: '请输入类型！', trigger: 'blur',},],
		reVision: [{required: true, message: '请输入乐观锁！', trigger: 'blur',},],
	});

	// 打开弹窗
	const openDialog = async (row: any) => {
		// ruleForm.value = JSON.parse(JSON.stringify(row));
		// 改用detail获取最新数据来编辑
		let rowData = JSON.parse(JSON.stringify(row));
		if (rowData.id)
			ruleForm.value = (await detailLogisticsReceipt(rowData.id)).data.result;
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
					await addLogisticsReceipt(values);
				} else {
					await updateLogisticsReceipt(values);
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




