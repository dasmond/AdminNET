<template>
	<div class="layout-container">
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
						<el-form-item label="商品id" prop="goodsId">
							<el-input v-model="ruleForm.goodsId" placeholder="请输入商品id" maxlength="19" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="项目Id" prop="projectId">
							<el-input v-model="ruleForm.projectId" placeholder="请输入项目Id" maxlength="19" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="任务Id" prop="taskId">
							<el-input v-model="ruleForm.taskId" placeholder="请输入任务Id" maxlength="19" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="开发工具" prop="developmentTool">
							<el-input v-model="ruleForm.developmentTool" placeholder="请输入开发工具" maxlength="255" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="PCB文件" prop="pCBUrl">
							<el-input v-model="ruleForm.pCBUrl" placeholder="请输入PCB文件" maxlength="255" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="原理图" prop="schematicDiagramImageUrl">
							<el-input v-model="ruleForm.schematicDiagramImageUrl" placeholder="请输入原理图" maxlength="255" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="贴片图" prop="sMTImageUrl">
							<el-input v-model="ruleForm.sMTImageUrl" placeholder="请输入贴片图" maxlength="255" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="Gerber文件" prop="gerberUrl">
							<el-input v-model="ruleForm.gerberUrl" placeholder="请输入Gerber文件" maxlength="255" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="编码" prop="sno">
							<el-input v-model="ruleForm.sno" placeholder="请输入编码" maxlength="255" show-word-limit clearable />
							
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
	import { addLayout, updateLayout, detailLayout } from "/@/api/main/layout";

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
		goodsId: [{required: true, message: '请输入商品id！', trigger: 'blur',},],
		projectId: [{required: true, message: '请输入项目Id！', trigger: 'blur',},],
		taskId: [{required: true, message: '请输入任务Id！', trigger: 'blur',},],
		developmentTool: [{required: true, message: '请输入开发工具！', trigger: 'blur',},],
		pCBUrl: [{required: true, message: '请输入PCB文件！', trigger: 'blur',},],
		schematicDiagramImageUrl: [{required: true, message: '请输入原理图！', trigger: 'blur',},],
		sMTImageUrl: [{required: true, message: '请输入贴片图！', trigger: 'blur',},],
		gerberUrl: [{required: true, message: '请输入Gerber文件！', trigger: 'blur',},],
		sno: [{required: true, message: '请输入编码！', trigger: 'blur',},],
		reVision: [{required: true, message: '请输入乐观锁！', trigger: 'blur',},],
	});

	// 打开弹窗
	const openDialog = async (row: any) => {
		// ruleForm.value = JSON.parse(JSON.stringify(row));
		// 改用detail获取最新数据来编辑
		let rowData = JSON.parse(JSON.stringify(row));
		if (rowData.id)
			ruleForm.value = (await detailLayout(rowData.id)).data.result;
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
					await addLayout(values);
				} else {
					await updateLayout(values);
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




