<template>
	<div class="sys-genTable-container">
		<el-dialog v-model="state.isShowDialog" draggable :close-on-click-modal="false" width="700px">
			<template #header>
				<div style="color: #fff">
					<el-icon size="16" style="margin-right: 3px; display: inline; vertical-align: middle"> <ele-Edit /> </el-icon>
					<span> {{ props.title }} </span>
				</div>
			</template>
			<el-form :model="state.ruleForm" ref="ruleFormRef" label-width="auto">
				<el-tabs>
					<el-tab-pane label="实体信息">
						<div v-for="(column, index) in state.ruleForm.entityColumnList">
							{{ column }}
						</div>
					</el-tab-pane>
					<el-tab-pane label="库表信息">
						<div v-for="(column, index) in state.ruleForm.columnList">
							{{ column }}
						</div>
					</el-tab-pane>
					<el-tab-pane label="配置信息">
						<div v-for="(column, index) in state.ruleForm.tableColumnList">
							{{ column }}
						</div>
					</el-tab-pane>
				</el-tabs>
			</el-form>
			<template #footer>
				<span class="dialog-footer">
					<el-button @click="cancel">取 消</el-button>
					<el-button type="primary" @click="submit">确 定</el-button>
					<el-button type="primary" @click="sync" disabled>同 步</el-button>
				</span>
			</template>
		</el-dialog>
	</div>
</template>

<script lang="ts" setup name="sysGenTable">
import { onMounted, reactive, ref } from 'vue';
import { ElMessageBox, ElMessage } from 'element-plus';

import { getAPI } from '/@/utils/axios-utils';
import { SysCodeGenApi } from '/@/api-services/api';

const props = defineProps({
	title: String,
});
const emits = defineEmits(['handleQuery']);

const ruleFormRef = ref();

const state = reactive({
	isShowDialog: false,
	ruleForm: {} as any,
});

onMounted(async () => {});

// 打开弹窗
const openDialog = async (row: any) => {
	var res = await getAPI(SysCodeGenApi).apiSysCodeGenSyncGet(row.id);
	state.ruleForm = res.data.result;
	state.isShowDialog = true;
	ruleFormRef.value?.resetFields();
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
const submit = () => {};

// 同步
const sync = async () => {
	ElMessageBox.confirm(`确定要同步吗?`, '提示', {
		confirmButtonText: '确定',
		cancelButtonText: '取消',
		type: 'warning',
	})
		.then(async () => {
			await getAPI(SysCodeGenApi).apiSysCodeGenSyncPost(state.ruleForm);
			ElMessage.success('同步成功');
		})
		.catch(() => {});
};

// 导出对象
defineExpose({ openDialog });
</script>
