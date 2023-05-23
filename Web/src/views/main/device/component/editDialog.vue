<template>
	<div class="device-container">
		<el-dialog v-model="isShowDialog" :title="props.title" :width="700" draggable>
			<el-form :model="ruleForm" ref="ruleFormRef" size="default" label-width="100px" :rules="rules">
				<el-row :gutter="35">
					<el-form-item v-show="false">
						<el-input v-model="ruleForm.id" />
					</el-form-item>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="名称" prop="name">
							<el-input v-model="ruleForm.name" placeholder="请输入名称" clearable />
						</el-form-item>
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="类型" prop="type">
							<el-select v-model="ruleForm.type" placeholder="请选择" clearable>
								<el-option label="算法" :value="0" />
								<el-option label="相机" :value="1" />
							</el-select>
						</el-form-item>
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="IP&端口" prop="ipPort">
							<el-input v-model="ruleForm.ipPort" placeholder="请输入IP:端口" clearable />
						</el-form-item>
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="账号" prop="account">
							<el-input v-model="ruleForm.account" placeholder="请输入账号" clearable />
						</el-form-item>
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="密码" prop="password">
							<el-input v-model="ruleForm.password" placeholder="请输入密码" clearable />
						</el-form-item>
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="备注" prop="remark">
							<el-input v-model="ruleForm.remark" placeholder="请输入备注" clearable />
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
import type { FormInstance, FormRules } from 'element-plus';
import { addDevice, updateDevice } from '/@/api/main/device';

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
	if (!formEl) return;
	await formEl.validate(async (isValid: boolean) => {
		if (!isValid) return;
		let values = ruleForm.value;
		if (ruleForm.value.id && ruleForm.value.id > 0) {
			await updateDevice(values);
		} else {
			await addDevice(values);
		}
		closeDialog();
	});
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
