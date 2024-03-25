<template>
	<div class="assignment-container">
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
						<el-form-item label="前置任务" prop="predecessorTaskId">
							<el-input v-model="ruleForm.predecessorTaskId" placeholder="请输入前置任务" maxlength="19" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="前置任务名称" prop="predecessorTaskName">
							<el-input v-model="ruleForm.predecessorTaskName" placeholder="请输入前置任务名称" maxlength="255" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="任务名称" prop="assignmentName">
							<el-input v-model="ruleForm.assignmentName" placeholder="请输入任务名称" maxlength="255" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="所属项目id" prop="projectId">
							<el-input v-model="ruleForm.projectId" placeholder="请输入所属项目id" maxlength="19" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="编码" prop="sno">
							<el-input v-model="ruleForm.sno" placeholder="请输入编码" maxlength="255" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="任务所属人" prop="roleId">
							<el-input v-model="ruleForm.roleId" placeholder="请输入任务所属人" maxlength="19" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="紧急程度" prop="prioriry">
							<el-input-number v-model="ruleForm.prioriry" placeholder="请输入紧急程度" clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="重要程度" prop="instancy">
							<el-input-number v-model="ruleForm.instancy" placeholder="请输入重要程度" clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="任务内容" prop="conTent">
							<el-input v-model="ruleForm.conTent" placeholder="请输入任务内容" maxlength="255" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="状态" prop="status">
							<el-input-number v-model="ruleForm.status" placeholder="请输入状态" clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="开始时间" prop="startTime">
							<el-date-picker v-model="ruleForm.startTime" type="date" placeholder="开始时间" />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="预计完成天数" prop="projectedCompletionTime">
							<el-input-number v-model="ruleForm.projectedCompletionTime" placeholder="请输入预计完成天数" clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="已用天数" prop="daysUsed">
							<el-input-number v-model="ruleForm.daysUsed" placeholder="请输入已用天数" clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="实际完成时间" prop="actyalTime">
							<el-date-picker v-model="ruleForm.actyalTime" type="date" placeholder="实际完成时间" />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="任务完成评价" prop="appraise">
							<el-input v-model="ruleForm.appraise" placeholder="请输入任务完成评价" maxlength="255" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="效率评价等级" prop="efficiencyLevel">
							<el-input-number v-model="ruleForm.efficiencyLevel" placeholder="请输入效率评价等级" clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="质量评价等级" prop="qualityLevel">
							<el-input-number v-model="ruleForm.qualityLevel" placeholder="请输入质量评价等级" clearable />
							
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
	import { addAssignment, updateAssignment, detailAssignment } from "/@/api/main/assignment";

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
		predecessorTaskId: [{required: true, message: '请输入前置任务！', trigger: 'blur',},],
		predecessorTaskName: [{required: true, message: '请输入前置任务名称！', trigger: 'blur',},],
		assignmentName: [{required: true, message: '请输入任务名称！', trigger: 'blur',},],
		projectId: [{required: true, message: '请输入所属项目id！', trigger: 'blur',},],
		sno: [{required: true, message: '请输入编码！', trigger: 'blur',},],
		roleId: [{required: true, message: '请输入任务所属人！', trigger: 'blur',},],
		prioriry: [{required: true, message: '请输入紧急程度！', trigger: 'blur',},],
		instancy: [{required: true, message: '请输入重要程度！', trigger: 'blur',},],
		conTent: [{required: true, message: '请输入任务内容！', trigger: 'blur',},],
		status: [{required: true, message: '请输入状态！', trigger: 'blur',},],
		startTime: [{required: true, message: '请选择开始时间！', trigger: 'change',},],
		projectedCompletionTime: [{required: true, message: '请输入预计完成天数！', trigger: 'blur',},],
		daysUsed: [{required: true, message: '请输入已用天数！', trigger: 'blur',},],
		actyalTime: [{required: true, message: '请选择实际完成时间！', trigger: 'change',},],
		appraise: [{required: true, message: '请输入任务完成评价！', trigger: 'blur',},],
		efficiencyLevel: [{required: true, message: '请输入效率评价等级！', trigger: 'blur',},],
		qualityLevel: [{required: true, message: '请输入质量评价等级！', trigger: 'blur',},],
		reVision: [{required: true, message: '请输入乐观锁！', trigger: 'blur',},],
	});

	// 打开弹窗
	const openDialog = async (row: any) => {
		// ruleForm.value = JSON.parse(JSON.stringify(row));
		// 改用detail获取最新数据来编辑
		let rowData = JSON.parse(JSON.stringify(row));
		if (rowData.id)
			ruleForm.value = (await detailAssignment(rowData.id)).data.result;
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
					await addAssignment(values);
				} else {
					await updateAssignment(values);
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




