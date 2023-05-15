<template>
	<div class="rule-container">
		<el-dialog v-model="isShowDialog" :title="props.title" :width="700" draggable>
			<el-form :model="ruleForm" ref="ruleFormRef" size="default" label-width="100px" :rules="rules">
				<el-row :gutter="35">
					<el-form-item v-show="false">
						<el-input v-model="ruleForm.id" />
					</el-form-item>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="名称" prop="name">
							<el-space>
								<el-input v-model="ruleForm.name" placeholder="请输入名称" clearable />
								<el-checkbox v-model="ruleForm.isDisable" label="禁用" />
							</el-space>
						</el-form-item>
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="类型" prop="type">
							<el-select v-model="ruleForm.type" placeholder="请选择" clearable>
								<el-option label="文字" :value="0" />
								<el-option label="图片" :value="1" />
								<el-option label="音频" :value="2" />
								<el-option label="视频" :value="3" />
							</el-select>
						</el-form-item>
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="起始(秒)" prop="start">
							<el-input-number v-model="ruleForm.start" :min="0" controls-position="right" style="width: 100%" placeholder="请输入起始(秒)" clearable />
						</el-form-item>
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="持续(秒)" prop="range">
							<el-input-number v-model="ruleForm.range" :min="0" controls-position="right" style="width: 100%" placeholder="请输入持续(秒)" clearable />
						</el-form-item>
					</el-col>
					<el-col :xs="24" :sm="24" :md="24" :lg="24" :xl="24" class="mb20">
						<el-form-item label="内容" prop="content">
							<el-input v-model="ruleForm.content" placeholder="请输入内容" type="textarea" clearable />
						</el-form-item>
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="素材" prop="url">
							<el-upload ref="uploadRef" list-type="picture-card" :limit="1" :show-file-list="false" :http-request="handleUpload">
								<img v-if="ruleForm.file" :src="ruleForm.file.thumbUrl" style="width: 100%; height: 100%; object-fit: contain" />
								<el-icon v-else>
									<Plus />
								</el-icon>
							</el-upload>
						</el-form-item>
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="排序" prop="sortIndex">
							<el-input-number v-model="ruleForm.sortIndex" :min="0" controls-position="right" style="width: 100%" placeholder="请输入排序" clearable />
						</el-form-item>
					</el-col>
					<el-col :xs="24" :sm="24" :md="24" :lg="24" :xl="24" class="mb20">
						<el-form-item label="备注" prop="remark">
							<el-input v-model="ruleForm.remark" placeholder="请输入备注" type="textarea" clearable />
						</el-form-item>
					</el-col>
				</el-row>
			</el-form>
			<template #footer>
				<span class="dialog-footer">
					<el-button @click="cancel" size="default">取 消</el-button>
					<el-button type="primary" @click="submitForm(ruleFormRef)" size="default">确 定</el-button>
				</span>
			</template>
		</el-dialog>
	</div>
</template>
<script lang="ts" setup>
import { ref } from 'vue';

import { Plus } from '@element-plus/icons-vue';
import { UploadRequestOptions } from 'element-plus';
import type { FormInstance, FormRules,UploadInstance } from 'element-plus';

import { addRule, updateRule, uploadMaterial } from '/@/api/main/rule';

const isShowDialog = ref(false);
const ruleForm = ref<any>({});
const ruleFormRef = ref<FormInstance>();

// 规则
const rules = ref<FormRules>({
	name: [{ required: true, message: '请输入名称！' }],
	type: [{ required: true, message: '请选择类型！' }],
});

// 打开
const openDialog = (row: any) => {
	resetForm(ruleFormRef.value);
	ruleForm.value = JSON.parse(JSON.stringify(row));
	isShowDialog.value = true;
};

// 关闭
const closeDialog = () => {
	emit('reloadTable');
	isShowDialog.value = false;
};

// 取消
const cancel = () => {
	isShowDialog.value = false;
};

// 重置
const resetForm = (formEl: FormInstance | undefined) => {
	if (!formEl) return;
	formEl.resetFields();
};

// 提交
const submitForm = async (formEl: FormInstance | undefined) => {
	if (!formEl) return
	await formEl.validate(async (isValid) => {
		if (!isValid) return;
		let values = ruleForm.value;
		if (ruleForm.value.id && ruleForm.value.id > 0) {
			await updateRule(values);
		} else {
			await addRule(values);
		}
		closeDialog();
	});
};

// 上传
const uploadRef = ref<UploadInstance>();
const handleUpload = async (options: UploadRequestOptions) => {
	const res = await uploadMaterial(options);
	ruleForm.value.file = res.data.result;
	ruleForm.value.url = res.data.result?.url;
	uploadRef.value!.clearFiles();//清空已选列表
};

// 自定义属性，事件，方法
const props = defineProps({
	title: {
		type: String,
		default: '',
	},
});

const emit = defineEmits(['reloadTable']);

defineExpose({ openDialog });
</script>