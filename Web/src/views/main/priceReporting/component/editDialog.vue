<template>
	<div class="priceReporting-container">
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
						<el-form-item label="备注" prop="meMo">
							<el-input v-model="ruleForm.meMo" placeholder="请输入备注" maxlength="255" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="编码" prop="sno">
							<el-input v-model="ruleForm.sno" placeholder="请输入编码" maxlength="255" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="客户id" prop="customerId">
							<el-input v-model="ruleForm.customerId" placeholder="请输入客户id" maxlength="19" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="联系人id" prop="linkmanId">
							<el-input v-model="ruleForm.linkmanId" placeholder="请输入联系人id" maxlength="19" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="审批提示信息状态" prop="status">
							<el-input v-model="ruleForm.status" placeholder="请输入审批提示信息状态" maxlength="255" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="审批完成状态" prop="completeStatus">
							<el-input-number v-model="ruleForm.completeStatus" placeholder="请输入审批完成状态" clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="生效日期" prop="expireDate">
							<el-date-picker v-model="ruleForm.expireDate" type="date" placeholder="生效日期" />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="交货周期" prop="expireCycle">
							<el-input-number v-model="ruleForm.expireCycle" placeholder="请输入交货周期" clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="失效日期" prop="loseEfficacyDate">
							<el-date-picker v-model="ruleForm.loseEfficacyDate" type="date" placeholder="失效日期" />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="交货时间" prop="leadTime">
							<el-date-picker v-model="ruleForm.leadTime" type="date" placeholder="交货时间" />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="结算方式" prop="settlement">
							<el-input v-model="ruleForm.settlement" placeholder="请输入结算方式" maxlength="255" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="商品id" prop="goodsId">
							<el-input v-model="ruleForm.goodsId" placeholder="请输入商品id" maxlength="19" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="含税单价" prop="price">
							<el-input v-model="ruleForm.price" placeholder="请输入含税单价" maxlength="18" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="税点" prop="tax">
							<el-input v-model="ruleForm.tax" placeholder="请输入税点" maxlength="18" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="未税单价" prop="noPrice">
							<el-input v-model="ruleForm.noPrice" placeholder="请输入未税单价" maxlength="18" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="客户商品编号" prop="customGoodsId">
							<el-input v-model="ruleForm.customGoodsId" placeholder="请输入客户商品编号" maxlength="255" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="默认值" prop="defaultValue">
							<el-switch v-model="ruleForm.defaultValue" active-text="是" inactive-text="否" />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="客户商品名" prop="customGoodsName">
							<el-input v-model="ruleForm.customGoodsName" placeholder="请输入客户商品名" maxlength="255" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="商品标签模板" prop="labelTemplate">
							<el-input v-model="ruleForm.labelTemplate" placeholder="请输入商品标签模板" maxlength="255" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="允许导出" prop="allowExport">
							<el-switch v-model="ruleForm.allowExport" active-text="是" inactive-text="否" />
							
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
	import { addPriceReporting, updatePriceReporting, detailPriceReporting } from "/@/api/main/priceReporting";

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
		meMo: [{required: true, message: '请输入备注！', trigger: 'blur',},],
		sno: [{required: true, message: '请输入编码！', trigger: 'blur',},],
		customerId: [{required: true, message: '请输入客户id！', trigger: 'blur',},],
		linkmanId: [{required: true, message: '请输入联系人id！', trigger: 'blur',},],
		status: [{required: true, message: '请输入审批提示信息状态！', trigger: 'blur',},],
		completeStatus: [{required: true, message: '请输入审批完成状态！', trigger: 'blur',},],
		expireDate: [{required: true, message: '请选择生效日期！', trigger: 'change',},],
		expireCycle: [{required: true, message: '请输入交货周期！', trigger: 'blur',},],
		loseEfficacyDate: [{required: true, message: '请选择失效日期！', trigger: 'change',},],
		leadTime: [{required: true, message: '请选择交货时间！', trigger: 'change',},],
		settlement: [{required: true, message: '请输入结算方式！', trigger: 'blur',},],
		goodsId: [{required: true, message: '请输入商品id！', trigger: 'blur',},],
		price: [{required: true, message: '请输入含税单价！', trigger: 'blur',},],
		tax: [{required: true, message: '请输入税点！', trigger: 'blur',},],
		noPrice: [{required: true, message: '请输入未税单价！', trigger: 'blur',},],
		customGoodsId: [{required: true, message: '请输入客户商品编号！', trigger: 'blur',},],
		customGoodsName: [{required: true, message: '请输入客户商品名！', trigger: 'blur',},],
		labelTemplate: [{required: true, message: '请输入商品标签模板！', trigger: 'blur',},],
		reVision: [{required: true, message: '请输入乐观锁！', trigger: 'blur',},],
	});

	// 打开弹窗
	const openDialog = async (row: any) => {
		// ruleForm.value = JSON.parse(JSON.stringify(row));
		// 改用detail获取最新数据来编辑
		let rowData = JSON.parse(JSON.stringify(row));
		if (rowData.id)
			ruleForm.value = (await detailPriceReporting(rowData.id)).data.result;
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
					await addPriceReporting(values);
				} else {
					await updatePriceReporting(values);
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




