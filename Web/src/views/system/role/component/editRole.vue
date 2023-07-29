<template>
	<div class="sys-role-container">
		<el-dialog v-model="state.isShowDialog" draggable :close-on-click-modal="false" width="700px">
			<template #header>
				<div style="color: #fff">
					<el-icon size="16" style="margin-right: 3px; display: inline; vertical-align: middle"> <ele-Edit /> </el-icon>
					<span>{{ props.title }}</span>
				</div>
			</template>
			<el-form :model="state.ruleForm" ref="ruleFormRef" label-width="auto">
				<el-row :gutter="35">
					<el-col :xs="24" :sm="24" :md="24" :lg="24" :xl="24" class="mb20">
						<el-form-item label="角色名称" prop="name" :rules="[{ required: true, message: '角色名称不能为空', trigger: 'blur' }]">
							<el-input v-model="state.ruleForm.name" placeholder="角色名称" clearable />
						</el-form-item>
					</el-col>
					<el-col :xs="24" :sm="24" :md="24" :lg="24" :xl="24" class="mb20">
						<el-form-item label="角色编码" prop="code" :rules="[{ required: true, message: '角色编码不能为空', trigger: 'blur' }]">
							<el-input v-model="state.ruleForm.code" placeholder="角色编码" clearable :disabled="state.ruleForm.code == 'sys_admin' && state.ruleForm.id != undefined" />
						</el-form-item>
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="排序">
							<el-input-number v-model="state.ruleForm.orderNo" placeholder="排序" class="w100" />
						</el-form-item>
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="状态">
							<el-radio-group v-model="state.ruleForm.status">
								<el-radio :label="1">启用</el-radio>
								<el-radio :label="2">禁用</el-radio>
							</el-radio-group>
						</el-form-item>
					</el-col>
					<el-col :xs="24" :sm="24" :md="24" :lg="24" :xl="24" class="mb20">
						<el-form-item label="备注">
							<el-input v-model="state.ruleForm.remark" placeholder="请输入备注内容" clearable type="textarea" />
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

<script lang="ts" setup name="sysEditRole">
import { onMounted, reactive, ref } from 'vue';
import type { ElTree } from 'element-plus';

import { getAPI } from '/@/utils/axios-utils';
import { SysRoleApi } from '/@/api-services/api';
import { AddRoleInput, UpdateRoleInput } from '/@/api-services/models';

const props = defineProps({
	title: String,
});
const emits = defineEmits(['handleQuery']);
const ruleFormRef = ref();
const treeRef = ref<InstanceType<typeof ElTree>>();
const state = reactive({
	isShowDialog: false,
	ruleForm: {} as UpdateRoleInput
});

onMounted(async () => {
	
});

// 打开弹窗
const openDialog = async (row: any) => {
	treeRef.value?.setCheckedKeys([]); // 清空选中值
	state.ruleForm = JSON.parse(JSON.stringify(row));
	if (row.id != undefined) {
		var res = await getAPI(SysRoleApi).apiSysRoleOwnMenuListGet(row.id);
		setTimeout(() => {
			treeRef.value?.setCheckedKeys(res.data.result ?? []);
		}, 100);
	}
	state.isShowDialog = true;
};

// 关闭弹窗
const closeDialog = () => {
	emits('handleQuery');
	state.isShowDialog = false;
};

// 取消
const cancel = () => {
	state.isShowDialog = false;
};

// 提交
const submit = () => {
	ruleFormRef.value.validate(async (valid: boolean) => {
		if (!valid) return;
		if (state.ruleForm.id != undefined && state.ruleForm.id > 0) {
			await getAPI(SysRoleApi).apiSysRoleUpdatePost(state.ruleForm);
		} else {
			await getAPI(SysRoleApi).apiSysRoleAddPost(state.ruleForm);
		}
		closeDialog();
	});
};

// 导出对象
defineExpose({ openDialog });
</script>