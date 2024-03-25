<template>
	<div class="customer-container">
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
						<el-form-item label="客户名称" prop="name">
							<el-input v-model="ruleForm.name" placeholder="请输入客户名称" maxlength="255" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="客户所属人id" prop="belongtoId">
							<el-input v-model="ruleForm.belongtoId" placeholder="请输入客户所属人id" maxlength="19" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="上任业务员id" prop="predecessor">
							<el-input v-model="ruleForm.predecessor" placeholder="请输入上任业务员id" maxlength="19" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="助理id" prop="assistantId">
							<el-input v-model="ruleForm.assistantId" placeholder="请输入助理id" maxlength="19" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="助理分配时间" prop="assistantAllocationTime">
							<el-date-picker v-model="ruleForm.assistantAllocationTime" type="date" placeholder="助理分配时间" />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="简称" prop="shortName">
							<el-input v-model="ruleForm.shortName" placeholder="请输入简称" maxlength="255" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="客户类型" prop="customerType">
							<el-input v-model="ruleForm.customerType" placeholder="请输入客户类型" maxlength="255" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="省" prop="province">
							<el-input v-model="ruleForm.province" placeholder="请输入省" maxlength="255" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="市" prop="city">
							<el-input v-model="ruleForm.city" placeholder="请输入市" maxlength="255" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="区" prop="area">
							<el-input v-model="ruleForm.area" placeholder="请输入区" maxlength="255" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="邮编" prop="zip">
							<el-input v-model="ruleForm.zip" placeholder="请输入邮编" maxlength="255" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="固定电话" prop="fixedPhoen">
							<el-input v-model="ruleForm.fixedPhoen" placeholder="请输入固定电话" maxlength="255" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="传真" prop="fax">
							<el-input v-model="ruleForm.fax" placeholder="请输入传真" maxlength="255" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="开户银行" prop="bank">
							<el-input v-model="ruleForm.bank" placeholder="请输入开户银行" maxlength="255" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="银行账号" prop="bankId">
							<el-input v-model="ruleForm.bankId" placeholder="请输入银行账号" maxlength="255" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="纳税号" prop="taxId">
							<el-input v-model="ruleForm.taxId" placeholder="请输入纳税号" maxlength="255" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="公司主页" prop="url">
							<el-input v-model="ruleForm.url" placeholder="请输入公司主页" maxlength="255" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="主营业务" prop="mainBusiness">
							<el-input v-model="ruleForm.mainBusiness" placeholder="请输入主营业务" maxlength="255" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="信用评级" prop="creditRating">
							<el-input v-model="ruleForm.creditRating" placeholder="请输入信用评级" maxlength="255" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="经纬度" prop="center">
							<el-input v-model="ruleForm.center" placeholder="请输入经纬度" maxlength="255" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="结算方式" prop="settlement">
							<el-input v-model="ruleForm.settlement" placeholder="请输入结算方式" maxlength="255" show-word-limit clearable />
							
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
	import { addCustomer, updateCustomer, detailCustomer } from "/@/api/main/customer";

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
		name: [{required: true, message: '请输入客户名称！', trigger: 'blur',},],
		belongtoId: [{required: true, message: '请输入客户所属人id！', trigger: 'blur',},],
		predecessor: [{required: true, message: '请输入上任业务员id！', trigger: 'blur',},],
		assistantId: [{required: true, message: '请输入助理id！', trigger: 'blur',},],
		shortName: [{required: true, message: '请输入简称！', trigger: 'blur',},],
		customerType: [{required: true, message: '请输入客户类型！', trigger: 'blur',},],
		province: [{required: true, message: '请输入省！', trigger: 'blur',},],
		city: [{required: true, message: '请输入市！', trigger: 'blur',},],
		area: [{required: true, message: '请输入区！', trigger: 'blur',},],
		zip: [{required: true, message: '请输入邮编！', trigger: 'blur',},],
		fixedPhoen: [{required: true, message: '请输入固定电话！', trigger: 'blur',},],
		fax: [{required: true, message: '请输入传真！', trigger: 'blur',},],
		bank: [{required: true, message: '请输入开户银行！', trigger: 'blur',},],
		bankId: [{required: true, message: '请输入银行账号！', trigger: 'blur',},],
		taxId: [{required: true, message: '请输入纳税号！', trigger: 'blur',},],
		url: [{required: true, message: '请输入公司主页！', trigger: 'blur',},],
		mainBusiness: [{required: true, message: '请输入主营业务！', trigger: 'blur',},],
		creditRating: [{required: true, message: '请输入信用评级！', trigger: 'blur',},],
		center: [{required: true, message: '请输入经纬度！', trigger: 'blur',},],
		settlement: [{required: true, message: '请输入结算方式！', trigger: 'blur',},],
		reVision: [{required: true, message: '请输入乐观锁！', trigger: 'blur',},],
	});

	// 打开弹窗
	const openDialog = async (row: any) => {
		// ruleForm.value = JSON.parse(JSON.stringify(row));
		// 改用detail获取最新数据来编辑
		let rowData = JSON.parse(JSON.stringify(row));
		if (rowData.id)
			ruleForm.value = (await detailCustomer(rowData.id)).data.result;
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
					await addCustomer(values);
				} else {
					await updateCustomer(values);
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




