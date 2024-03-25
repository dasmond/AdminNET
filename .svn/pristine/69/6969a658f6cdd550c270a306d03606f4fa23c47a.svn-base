<template>
	<div class="supplierRejectionOrder-container">
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
						<el-form-item label="合同id" prop="snoId">
							<el-input v-model="ruleForm.snoId" placeholder="请输入合同id" maxlength="19" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="合同编码" prop="sno">
							<el-input v-model="ruleForm.sno" placeholder="请输入合同编码" maxlength="255" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="审核信息提示" prop="status">
							<el-input v-model="ruleForm.status" placeholder="请输入审核信息提示" maxlength="255" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="订单编码" prop="orderSno">
							<el-input v-model="ruleForm.orderSno" placeholder="请输入订单编码" maxlength="255" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="物流收货单id" prop="logisticsReceiptId">
							<el-input v-model="ruleForm.logisticsReceiptId" placeholder="请输入物流收货单id" maxlength="19" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="物流收货单id" prop="logisticsReceipt">
							<el-input v-model="ruleForm.logisticsReceipt" placeholder="请输入物流收货单id" maxlength="19" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="购方合同编码" prop="purchaserSno">
							<el-input v-model="ruleForm.purchaserSno" placeholder="请输入购方合同编码" maxlength="255" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="合同详情id" prop="snoDetailsId">
							<el-input v-model="ruleForm.snoDetailsId" placeholder="请输入合同详情id" maxlength="19" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="商品id" prop="goodsId">
							<el-input v-model="ruleForm.goodsId" placeholder="请输入商品id" maxlength="19" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="审批完成状态" prop="completeStatus">
							<el-input-number v-model="ruleForm.completeStatus" placeholder="请输入审批完成状态" clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="数量" prop="quantity">
							<el-input-number v-model="ruleForm.quantity" placeholder="请输入数量" clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="打印次数" prop="count">
							<el-input-number v-model="ruleForm.count" placeholder="请输入打印次数" clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="发货方式" prop="delivery">
							<el-input v-model="ruleForm.delivery" placeholder="请输入发货方式" maxlength="255" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="快递单号" prop="trackingNumber">
							<el-input v-model="ruleForm.trackingNumber" placeholder="请输入快递单号" maxlength="255" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="联系人名称" prop="contactsName">
							<el-input v-model="ruleForm.contactsName" placeholder="请输入联系人名称" maxlength="255" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="客户名称" prop="customerName">
							<el-input v-model="ruleForm.customerName" placeholder="请输入客户名称" maxlength="255" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="客户名称" prop="consigneeName">
							<el-input v-model="ruleForm.consigneeName" placeholder="请输入客户名称" maxlength="255" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="不合格原因" prop="unqualified">
							<el-input v-model="ruleForm.unqualified" placeholder="请输入不合格原因" maxlength="255" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="备注" prop="meMo">
							<el-input v-model="ruleForm.meMo" placeholder="请输入备注" maxlength="255" show-word-limit clearable />
							
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
	import { addSupplierRejectionOrder, updateSupplierRejectionOrder, detailSupplierRejectionOrder } from "/@/api/main/supplierRejectionOrder";

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
		snoId: [{required: true, message: '请输入合同id！', trigger: 'blur',},],
		sno: [{required: true, message: '请输入合同编码！', trigger: 'blur',},],
		status: [{required: true, message: '请输入审核信息提示！', trigger: 'blur',},],
		orderSno: [{required: true, message: '请输入订单编码！', trigger: 'blur',},],
		logisticsReceiptId: [{required: true, message: '请输入物流收货单id！', trigger: 'blur',},],
		logisticsReceipt: [{required: true, message: '请输入物流收货单id！', trigger: 'blur',},],
		purchaserSno: [{required: true, message: '请输入购方合同编码！', trigger: 'blur',},],
		snoDetailsId: [{required: true, message: '请输入合同详情id！', trigger: 'blur',},],
		goodsId: [{required: true, message: '请输入商品id！', trigger: 'blur',},],
		completeStatus: [{required: true, message: '请输入审批完成状态！', trigger: 'blur',},],
		quantity: [{required: true, message: '请输入数量！', trigger: 'blur',},],
		count: [{required: true, message: '请输入打印次数！', trigger: 'blur',},],
		delivery: [{required: true, message: '请输入发货方式！', trigger: 'blur',},],
		trackingNumber: [{required: true, message: '请输入快递单号！', trigger: 'blur',},],
		contactsName: [{required: true, message: '请输入联系人名称！', trigger: 'blur',},],
		customerName: [{required: true, message: '请输入客户名称！', trigger: 'blur',},],
		consigneeName: [{required: true, message: '请输入客户名称！', trigger: 'blur',},],
		unqualified: [{required: true, message: '请输入不合格原因！', trigger: 'blur',},],
		meMo: [{required: true, message: '请输入备注！', trigger: 'blur',},],
		reVision: [{required: true, message: '请输入乐观锁！', trigger: 'blur',},],
	});

	// 打开弹窗
	const openDialog = async (row: any) => {
		// ruleForm.value = JSON.parse(JSON.stringify(row));
		// 改用detail获取最新数据来编辑
		let rowData = JSON.parse(JSON.stringify(row));
		if (rowData.id)
			ruleForm.value = (await detailSupplierRejectionOrder(rowData.id)).data.result;
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
					await addSupplierRejectionOrder(values);
				} else {
					await updateSupplierRejectionOrder(values);
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




