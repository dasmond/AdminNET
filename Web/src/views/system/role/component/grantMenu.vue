<template>
	<div class="sys-grantData-container">
		<el-dialog v-model="state.isShowDialog" draggable :close-on-click-modal="false" width="700px">
			<template #header>
				<div style="color: #fff">
					<el-icon size="16" style="margin-right: 3px; display: inline; vertical-align: middle"> <ele-Edit />
					</el-icon>
					<span>{{ state.title }} 授权菜单 </span>
				</div>
			</template>
			<el-form :model="state.ruleForm" label-position="top">
				<el-col :xs="24" :sm="24" :md="24" :lg="24" :xl="24" class="mb20">
					<el-form-item label="菜单权限" v-loading="state.loading">
						<el-tree ref="treeRef" :data="state.menuData" node-key="id" show-checkbox
							:props="{ children: 'children', label: 'title', class: treeNodeClass }" icon="ele-Menu"
							highlight-current default-expand-all />
					</el-form-item>
				</el-col>
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

<script lang="ts" setup name="sysGrantMenu">
import { onMounted, reactive, ref } from 'vue';
import type { ElTree } from 'element-plus';

import { getAPI } from '/@/utils/axios-utils';
import { SysRoleApi, SysMenuApi } from '/@/api-services/api';
import { SysMenu, RoleMenuInput } from '/@/api-services/models';

const treeRef = ref<InstanceType<typeof ElTree>>();
const state = reactive({
	loading: false,
	isShowDialog: false,
	title: '',
	ruleForm: {} as RoleMenuInput,
	menuData: [] as Array<SysMenu>, // 菜单数据
});

onMounted(async () => {
	state.loading = true;
	var res = await getAPI(SysMenuApi).apiSysMenuListGet();
	state.menuData = res.data.result ?? [];
	state.loading = false;
})

// 打开弹窗
const openDialog = async (row: any) => {
	treeRef.value?.setCheckedKeys([]); // 清空选中值
	state.title = row.name;
	state.ruleForm.id = row.id
	var res = await getAPI(SysRoleApi).apiSysRoleOwnMenuListGet(row.id);
	setTimeout(() => {
		treeRef.value?.setCheckedKeys(res.data.result ?? []);
	}, 100);
	state.isShowDialog = true;
};

// 取消
const cancel = () => {
	state.isShowDialog = false;
};

// 关闭弹窗
const closeDialog = () => {
	state.isShowDialog = false;
};

// 提交
const submit = async () => {
	state.ruleForm.menuIdList = treeRef.value?.getCheckedKeys() as Array<number>;
	await getAPI(SysRoleApi).apiSysRoleGrantMenuPost(state.ruleForm);
	closeDialog();
};

// 叶子节点同行显示样式
const treeNodeClass = (node: SysMenu) => {
	if (node.children != null) {
		let addClass = true; // 添加叶子节点同行显示样式
		for (var key in node.children) {
			// 如果存在子节点非叶子节点，不添加样式
			if (node.children[key].children?.length ?? 0 > 0) {
				addClass = false;
				break;
			}
		}
		return addClass ? 'penultimate-node' : '';
	}
	return ''
};


// 导出对象
defineExpose({ openDialog });
</script>

<style lang="scss" scoped>
:deep(.penultimate-node) {
	.el-tree-node__children {
		padding-left: 40px;
		white-space: pre-wrap;
		line-height: 100%;

		.el-tree-node {
			display: inline-block;
		}

		.el-tree-node__content {
			padding-left: 5px !important;
			padding-right: 5px;

			// .el-tree-node__expand-icon {
			// 	display: none;
			// }
		}
	}
}
</style>
