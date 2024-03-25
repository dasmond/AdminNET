<template>
	<div class="bomDetailsCopy-container">
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
						<el-form-item label="Bom主表id" prop="bomId">
							<el-input v-model="ruleForm.bomId" placeholder="请输入Bom主表id" maxlength="19" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="上级物料id" prop="parentPartId">
							<el-input v-model="ruleForm.parentPartId" placeholder="请输入上级物料id" maxlength="19" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="上级物料编码" prop="parentPartNo">
							<el-input v-model="ruleForm.parentPartNo" placeholder="请输入上级物料编码" maxlength="255" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="当前物料编码" prop="partNo">
							<el-input v-model="ruleForm.partNo" placeholder="请输入当前物料编码" maxlength="255" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="用量" prop="qty">
							<el-input v-model="ruleForm.qty" placeholder="请输入用量" maxlength="18" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="不良率" prop="defectRate">
							<el-input v-model="ruleForm.defectRate" placeholder="请输入不良率" maxlength="18" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="工序号" prop="locator">
							<el-input v-model="ruleForm.locator" placeholder="请输入工序号" maxlength="255" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="不发料" prop="noPur">
							<el-switch v-model="ruleForm.noPur" active-text="是" inactive-text="否" />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="位号" prop="rem">
							<el-input v-model="ruleForm.rem" placeholder="请输入位号" maxlength="255" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="版本" prop="ver">
							<el-input v-model="ruleForm.ver" placeholder="请输入版本" maxlength="255" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="层级" prop="level">
							<el-input-number v-model="ruleForm.level" placeholder="请输入层级" clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="完成状态" prop="completeStatus">
							<el-input-number v-model="ruleForm.completeStatus" placeholder="请输入完成状态" clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="变更状态" prop="changeStatus">
							<el-input-number v-model="ruleForm.changeStatus" placeholder="请输入变更状态" clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="替代料状态" prop="alternativeMaterialStatus">
							<el-input-number v-model="ruleForm.alternativeMaterialStatus" placeholder="请输入替代料状态" clearable />
							
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
	import { addBomDetailsCopy, updateBomDetailsCopy, detailBomDetailsCopy } from "/@/api/main/bomDetailsCopy";

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
		bomId: [{required: true, message: '请输入Bom主表id！', trigger: 'blur',},],
		parentPartId: [{required: true, message: '请输入上级物料id！', trigger: 'blur',},],
		parentPartNo: [{required: true, message: '请输入上级物料编码！', trigger: 'blur',},],
		partNo: [{required: true, message: '请输入当前物料编码！', trigger: 'blur',},],
		qty: [{required: true, message: '请输入用量！', trigger: 'blur',},],
		defectRate: [{required: true, message: '请输入不良率！', trigger: 'blur',},],
		locator: [{required: true, message: '请输入工序号！', trigger: 'blur',},],
		rem: [{required: true, message: '请输入位号！', trigger: 'blur',},],
		ver: [{required: true, message: '请输入版本！', trigger: 'blur',},],
		level: [{required: true, message: '请输入层级！', trigger: 'blur',},],
		completeStatus: [{required: true, message: '请输入完成状态！', trigger: 'blur',},],
		changeStatus: [{required: true, message: '请输入变更状态！', trigger: 'blur',},],
		alternativeMaterialStatus: [{required: true, message: '请输入替代料状态！', trigger: 'blur',},],
		reVision: [{required: true, message: '请输入乐观锁！', trigger: 'blur',},],
	});

	// 打开弹窗
	const openDialog = async (row: any) => {
		// ruleForm.value = JSON.parse(JSON.stringify(row));
		// 改用detail获取最新数据来编辑
		let rowData = JSON.parse(JSON.stringify(row));
		if (rowData.id)
			ruleForm.value = (await detailBomDetailsCopy(rowData.id)).data.result;
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
					await addBomDetailsCopy(values);
				} else {
					await updateBomDetailsCopy(values);
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




