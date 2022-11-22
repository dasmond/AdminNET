<template>
	<div class="sys-dataRes-container">
		<el-dialog v-model="isShowDialog" :title="title" draggable width="600px">
			<el-form :model="ruleForm" ref="ruleFormRef" size="default" label-width="80px">
				<el-row :gutter="35">
					<el-col :xs="24" :sm="24" :md="24" :lg="24" :xl="24" class="mb20">
						<el-form-item label="上级资源">
							<el-cascader
								:options="dataResData"
								:props="{ checkStrictly: true, emitPath: false, value: 'id', label: 'name' }"
								placeholder="请选择上级资源"
								clearable
								class="w100"
								v-model="ruleForm.pid"
							>
								<template #default="{ node, data }">
									<span>{{ data.name }}</span>
									<span v-if="!node.isLeaf"> ({{ data.children.length }}) </span>
								</template>
							</el-cascader>
						</el-form-item>
					</el-col>
					<el-col :xs="24" :sm="24" :md="24" :lg="24" :xl="24" class="mb20">
						<el-form-item label="资源名称" prop="name" :rules="[{ required: true, message: '资源名称不能为空', trigger: 'blur' }]">
							<el-input v-model="ruleForm.name" placeholder="资源名称" clearable />
						</el-form-item>
					</el-col>
					<el-col :xs="24" :sm="24" :md="24" :lg="24" :xl="24" class="mb20">
						<el-form-item label="资源值" prop="value" :rules="[{ required: true, message: '资源值不能为空', trigger: 'blur' }]">
							<el-input v-model="ruleForm.value" placeholder="资源值" clearable />
						</el-form-item>
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="排序">
							<el-input-number v-model="ruleForm.order" placeholder="排序" class="w100" />
						</el-form-item>
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="状态">
							<el-radio-group v-model="ruleForm.status">
								<el-radio :label="1">启用</el-radio>
								<el-radio :label="2">禁用</el-radio>
							</el-radio-group>
						</el-form-item>
					</el-col>
					<el-col :xs="24" :sm="24" :md="24" :lg="24" :xl="24" class="mb20">
						<el-form-item label="备注">
							<el-input v-model="ruleForm.remark" placeholder="请输入备注内容" clearable type="textarea" />
						</el-form-item>
					</el-col>
				</el-row>
			</el-form>
			<template #footer>
				<span class="dialog-footer">
					<el-button @click="cancel" size="default">取 消</el-button>
					<el-button type="primary" @click="submit" size="default">确 定</el-button>
				</span>
			</template>
		</el-dialog>
	</div>
</template>

<script lang="ts">
import { reactive, toRefs, defineComponent, ref } from 'vue';
import mittBus from '/@/utils/mitt';

import { getAPI } from '/@/utils/axios-utils';
import { SysDataResourceApi } from '/@/api-services/api';
import { SysDataResource, UpdateDataResourceInput } from '/@/api-services/models';

export default defineComponent({
	name: 'sysEditOrg',
	components: {},
	props: {
		title: {
			type: String,
			default: '',
		},
		dataResData: {
			type: Array<SysDataResource>,
			default: () => [],
		},
	},
	setup() {
		const ruleFormRef = ref();
		const state = reactive({
			isShowDialog: false,
			ruleForm: {} as UpdateDataResourceInput,
			orgLevelOptions: [] as any,
		});

		// 打开弹窗
		const openDialog = (row: any) => {
			state.ruleForm = JSON.parse(JSON.stringify(row));
			state.isShowDialog = true;
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
					await getAPI(SysDataResourceApi).sysDataResourceUpdatePost(state.ruleForm);
				} else {
					await getAPI(SysDataResourceApi).sysDataResourceAddPost(state.ruleForm);
				}
				mittBus.emit('submitRefresh');
				state.isShowDialog = false;
			});
		};
		return {
			ruleFormRef,
			openDialog,
			cancel,
			submit,
			...toRefs(state),
		};
	},
});
</script>
