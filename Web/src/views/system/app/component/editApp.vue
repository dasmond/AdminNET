<template>
	<div class="sys-app-container">
		<el-dialog v-model="state.isShowDialog" draggable :close-on-click-modal="false">
			<template #header>
				<div style="color: #fff">
					<el-icon size="16" style="margin-right: 3px; display: inline; vertical-align: middle"> <ele-Edit /> </el-icon>
					<span>{{ props.title }}</span>
				</div>
			</template>
			<el-form :model="state.ruleForm" ref="ruleFormRef" label-width="auto">
				<el-row :gutter="35">
					<el-col :xs="24" :sm="10" :md="10" :lg="10" :xl="10" class="mb20">
						<el-form-item label="名称" prop="name" :rules="[{ required: true, message: '名称不能为空', trigger: 'blur' }]">
							<el-input v-model="state.ruleForm.name" maxlength="32" placeholder="应用名称" show-word-limit clearable />
						</el-form-item>
					</el-col>
          <el-col :xs="24" :sm="14" :md="14" :lg="14" :xl="14" class="mb20">
            <el-form-item label="Logo" prop="logo" :rules="[{ required: true, message: '应用Logo不能为空', trigger: 'blur' }]">
              <el-input v-model="state.ruleForm.logo" class="w80" maxlength="256" placeholder="应用Logo" show-word-limit clearable />
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="10" :md="10" :lg="10" :xl="10" class="mb20">
            <el-form-item label="标题" prop="title" :rules="[{ required: true, message: '标题不能为空', trigger: 'blur' }]">
              <el-input v-model="state.ruleForm.title" placeholder="应用标题" maxlength="32" show-word-limit clearable />
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="14" :md="14" :lg="14" :xl="14" class="mb20">
            <el-form-item label="副标题" prop="viceTitle" :rules="[{ required: true, message: '副标题不能为空', trigger: 'blur' }]">
              <el-input v-model="state.ruleForm.viceTitle" placeholder="应用副标题" maxlength="32" show-word-limit clearable />
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="24" :md="24" :lg="24" :xl="24" class="mb20">
            <el-form-item label="副标题描述" prop="viceDesc" :rules="[{ required: true, message: '副标题描述不能为空', trigger: 'blur' }]">
              <el-input v-model="state.ruleForm.viceDesc" placeholder="应用副标题描述" maxlength="64" show-word-limit clearable />
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="24" :lg="24" :xl="24" class="mb20">
            <el-form-item label="版权信息" prop="copyright" :rules="[{ required: true, message: '版权信息不能为空', trigger: 'blur' }]">
              <el-input v-model="state.ruleForm.copyright" placeholder="版权信息" maxlength="64" show-word-limit clearable />
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="9" :md="9" :lg="9" :xl="9" class="mb20">
            <el-form-item label="备案号" prop="icp" :rules="[{ required: true, message: '备案号不能为空', trigger: 'blur' }]">
              <el-input v-model="state.ruleForm.icp" placeholder="备案号" maxlength="32" show-word-limit clearable />
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="9" :md="9" :lg="9" :xl="9" class="mb20">
            <el-form-item label="水印" prop="watermark" :rules="[{ required: true, message: '水印不能为空', trigger: 'blur' }]">
              <el-input v-model="state.ruleForm.watermark" placeholder="应用水印" maxlength="32" show-word-limit clearable />
            </el-form-item>
          </el-col>
					<el-col :xs="24" :sm="6" :md="6" :lg="6" :xl="6" class="mb20">
						<el-form-item label="排序">
							<el-input-number v-model="state.ruleForm.orderNo" placeholder="排序" class="w100" />
						</el-form-item>
					</el-col>
					<el-col :xs="24" :sm="24" :md="24" :lg="24" :xl="24" class="mb20">
						<el-form-item label="备注">
							<el-input v-model="state.ruleForm.remark" placeholder="请输入备注内容" show-word-limit clearable type="textarea" />
						</el-form-item>
					</el-col>
					<el-col :xs="24" :sm="24" :md="24" :lg="24" :xl="24" class="mb20" v-auth="'sysApp:grantMenu'">
						<el-form-item label="菜单权限" v-loading="state.loading">
							<el-tree
								ref="treeRef"
								:data="state.menuData"
								node-key="id"
								show-checkbox
								:props="{ children: 'children', label: 'title', class: treeNodeClass }"
								icon="ele-Menu"
								highlight-current
								default-expand-all
								style="height: 600px;overflow-y: auto;">
                <template #default="{ node, data }">
                  <span>{{ node.label }}</span>
                  <span v-if="data.path" style="margin-left: 5px!important;">
                    <el-tag effect="plain" type="warning">{{data.path}}</el-tag>
                  </span>
                </template>
              </el-tree>
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

<script lang="ts" setup name="sysEditApp">
import { onMounted, reactive, ref } from 'vue';
import type { ElTree } from 'element-plus';

import { getAPI } from '/@/utils/axios-utils';
import { SysMenuApi, SysAppApi } from '/@/api-services/api';
import { SysMenu } from '/@/api-services/models';
import {auth} from "/@/utils/authFunction";

const props = defineProps({
	title: String,
});
const emits = defineEmits(['handleQuery']);
const ruleFormRef = ref();
const treeRef = ref<InstanceType<typeof ElTree>>();
const state = reactive({
	loading: false,
	isShowDialog: false,
	ruleForm: {} as any,
	menuData: [] as Array<SysMenu>, // 菜单数据
});

onMounted(async () => {
	state.loading = true;
  if (auth('sysApp:grantMenu')) {
    const res = await getAPI(SysMenuApi).apiSysMenuListGet(undefined, undefined, true);
    state.menuData = res.data.result ?? [];
  }
	state.loading = false;
});

// 打开弹窗
const openDialog = async (row: any) => {
	ruleFormRef.value?.resetFields();
	treeRef.value?.setCheckedKeys([]); // 清空选中值
	state.ruleForm = JSON.parse(JSON.stringify(row));
	if (row.id && auth('sysApp:grantMenu')) {
    const res = await getAPI(SysAppApi).apiSysAppGrantMenuGet(row.id);
    treeRef.value?.setCheckedKeys(res.data.result ?? []);
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
		const menuIdList = treeRef.value?.getCheckedKeys() as Array<number> ?? []; //.concat(treeRef.value?.getHalfCheckedKeys());
		if (state.ruleForm.id != undefined && state.ruleForm.id > 0) {
			await getAPI(SysAppApi).apiSysAppUpdatePost(state.ruleForm);
		} else {
      state.ruleForm.id = await getAPI(SysAppApi).apiSysAppAddPost(state.ruleForm).then(res => res.data.result);
		}
    if (state.ruleForm.id && auth('sysApp:grantMenu')) {
      await getAPI(SysAppApi).apiSysAppGrantMenuPost({ id: state.ruleForm.id, menuIdList: menuIdList });
    }
		closeDialog();
	});
};

// 叶子节点同行显示样式
const treeNodeClass = (node: SysMenu) => {
	let addClass = true; // 添加叶子节点同行显示样式
	for (const index in node.children) {
		// 如果存在子节点非叶子节点，不添加样式
		if (node.children[index].children?.length ?? 0 > 0) {
			addClass = false;
			break;
		}
	}
	return addClass ? 'penultimate-node' : '';
};

// 导出对象
defineExpose({ openDialog });
</script>

<style lang="scss" scoped>
.menu-data-tree {
	width: 100%;
	border: 1px solid var(--el-border-color);
	border-radius: var(--el-input-border-radius, var(--el-border-radius-base));
	padding: 5px;
}

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
		}
	}
}
</style>
