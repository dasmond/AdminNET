<template>
	<div class="sys-user-role-container">
		<el-dialog v-model="state.isShowDialog" draggable :close-on-click-modal="false" width="700px">
			<template #header>
				<div style="color: #fff">
					<el-icon size="16" style="margin-right: 3px; display: inline; vertical-align: middle"> <ele-Edit /> </el-icon>
					<span> {{ props.title }} </span>
				</div>
			</template>
			<el-row :gutter="10">
				<el-col :span="10">
					<div class="transfer-panel">
						<p class="transfer-panel__header">
							<el-checkbox v-model="state.leftAllChecked" :indeterminate="leftIndeterminate" :validate-event="false" @change="handleLeftAllChecked"> 未授权 </el-checkbox>
							<span>{{ state.leftChecked.length }}/{{ state.leftData.length }}</span>
						</p>
						<div class="transfer-panel__body">
							<el-input class="transfer-panel__filter" v-model="state.leftKeyword" placeholder="搜索" :prefix-icon="Search" clearable :validate-event="false" />
							<el-checkbox-group v-show="true" v-model="state.leftChecked" :validate-event="false" class="transfer-panel__list">
								<el-checkbox v-for="(i, k) in leftFilterData" :key="k" :value="i.id" :label="i.name" :disabled="i.disabled" :validate-event="false" class="transfer-panel__item"> </el-checkbox>
							</el-checkbox-group>
						</div>
					</div>
				</el-col>
				<el-col :span="4" class="transfer-buttons">
					<div class="transfer-buttons__item">
						<el-button type="primary" style="width: 100%" :icon="ArrowRight" @click="toRight">往右</el-button>
					</div>
					<div class="transfer-buttons__item">
						<el-button type="primary" style="width: 100%" :icon="ArrowLeft" @click="toLeft">往右</el-button>
					</div>
					<div class="transfer-buttons__item">
						<el-button type="primary" style="width: 100%" :icon="DArrowRight" @click="allToRight">全部往右</el-button>
					</div>
					<div class="transfer-buttons__item">
						<el-button type="primary" style="width: 100%" :icon="DArrowLeft" @click="allToLeft">全部往右</el-button>
					</div>
				</el-col>
				<el-col :span="10">
					<div class="transfer-panel">
						<p class="transfer-panel__header">
							<el-checkbox v-model="state.rightAllChecked" :indeterminate="rightIndeterminate" :validate-event="false" @change="handleRightAllChecked"> 已授权 </el-checkbox>
							<span>{{ state.rightChecked.length }}/{{ state.rightData.length }}</span>
						</p>
						<div class="transfer-panel__body">
							<el-input class="transfer-panel__filter" v-model="state.rightKeyword" placeholder="搜索" :prefix-icon="Search" clearable :validate-event="false" />
							<el-checkbox-group v-show="true" v-model="state.rightChecked" :validate-event="false" class="transfer-panel__list">
								<el-checkbox v-for="(i, k) in rightFilterData" :key="k" :value="i.id" :label="i.name" :disabled="i.disabled" :validate-event="false" class="transfer-panel__item"> </el-checkbox>
							</el-checkbox-group>
						</div>
					</div>
				</el-col>
			</el-row>

			<template #footer>
				<span class="dialog-footer">
					<el-button @click="cancel">取 消</el-button>
					<el-button type="primary" @click="submit">确 定</el-button>
				</span>
			</template>
		</el-dialog>
	</div>
</template>

<script lang="ts" setup name="sysGrantRole">
import { reactive, computed, watch } from 'vue';
import { getAPI } from '/@/utils/axios-utils';
import { SysUserApi } from '/@/api-services/api';
import { Search, ArrowRight, ArrowLeft, DArrowRight, DArrowLeft } from '@element-plus/icons-vue';

const props = defineProps({
	title: String,
});
const emits = defineEmits(['handleQuery']);
const state = reactive({
	isShowDialog: false,
	leftAllChecked: false,
	leftKeyword: '',
	leftData: [],
	leftChecked: [],
	rightAllChecked: false,
	rightKeyword: '',
	rightData: [],
	rightChecked: [],
	userId: undefined as number | undefined,
});

// 打开弹窗
const openDialog = async (row: any) => {
	state.isShowDialog = true;
	state.userId = row.id;
	const { data } = await getAPI(SysUserApi).apiSysUserAvailableRoleListUserIdGet(row.id);
	state.leftData = data.result?.available;
	state.rightData = data.result?.granted;
	state.leftAllChecked = false;
	state.rightAllChecked = false;
	state.leftChecked = [];
	state.rightChecked = [];
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
const submit = async () => {
	const roleIdList = state.rightData.map((e) => e.id);
	await getAPI(SysUserApi).apiSysUserGrantRolePost({ userId: state.userId, roleIdList: roleIdList });
	closeDialog();
};

//未授权过滤数据
const leftFilterData = computed(() => {
	let result = state.leftData.filter((e) => e.name.toLowerCase().includes(state.leftKeyword.toLowerCase()));
	if (state.leftChecked.length > 0) {
		for (let i = state.leftChecked.length - 1; i >= 0; i--) {
			const index = result.findIndex((e) => e.id == state.leftChecked[i]);
			// eslint-disable-next-line vue/no-side-effects-in-computed-properties
			if (index == -1) state.leftChecked.splice(i, 1);
		}
	}
	return result;
});

//未授权数据全选
const handleLeftAllChecked = (value: any) => {
	state.leftChecked = value ? leftFilterData.value.filter((e) => e.disabled == false).map((e) => e.id) : [];
};

//未授权数据半选状态
const leftIndeterminate = computed(() => {
	const checkedLength = state.leftChecked.length;
	const result = checkedLength > 0 && checkedLength < leftFilterData.value.filter((e) => e.disabled == false).length;
	return result;
});

watch(
	() => state.leftChecked,
	(val: any[]) => {
		state.leftAllChecked = val.length > 0 && val.length == leftFilterData.value.filter((e) => e.disabled == false).length;
	}
);

//已授权过滤数据
const rightFilterData = computed(() => {
	let result = state.rightData.filter((e) => e.name.toLowerCase().includes(state.rightKeyword.toLowerCase()));
	if (state.rightChecked.length > 0) {
		for (let i = state.rightChecked.length - 1; i >= 0; i--) {
			const index = result.findIndex((e) => e.id == state.rightChecked[i]);
			// eslint-disable-next-line vue/no-side-effects-in-computed-properties
			if (index == -1) state.rightChecked.splice(i, 1);
		}
	}
	return result;
});

//已授权数据全选
const handleRightAllChecked = (value: any) => {
	state.rightChecked = value ? rightFilterData.value.filter((e) => e.disabled == false).map((e) => e.id) : [];
};

//已授权数据半选状态
const rightIndeterminate = computed(() => {
	const checkedLength = state.rightChecked.length;
	const result = checkedLength > 0 && checkedLength < rightFilterData.value.filter((e) => e.disabled == false).length;
	return result;
});

watch(
	() => state.rightChecked,
	(val: any[]) => {
		state.rightAllChecked = val.length > 0 && val.length == rightFilterData.value.filter((e) => e.disabled == false).length;
	}
);

//未授权中选中的变已授权
const toRight = () => {
	if (state.leftChecked.length) {
		state.leftChecked.forEach((id: number) => {
			const index = state.leftData.findIndex((e) => e.id == id);
			if (index > -1) {
				const temp = state.leftData.splice(index, 1);
				state.rightData = state.rightData.concat(temp);
			}
		});
		state.leftChecked = [];
	}
};

//全部未授权的变已授权
const allToRight = () => {
	if (leftFilterData.value.length > 0) {
		const ids = leftFilterData.value.filter((e) => e.disabled == false).map((e) => e.id);
		ids.forEach((id: number) => {
			const index = state.leftData.findIndex((e) => e.id == id);
			if (index > -1) {
				const temp = state.leftData.splice(index, 1);
				state.rightData = state.rightData.concat(temp);
			}
		});
		state.leftChecked = [];
	}
};

//已授权中选中的变未授权
const toLeft = () => {
	if (state.rightChecked.length) {
		state.rightChecked.forEach((id: number) => {
			const index = state.rightData.findIndex((e) => e.id == id);
			if (index > -1) {
				const temp = state.rightData.splice(index, 1);
				state.leftData = state.leftData.concat(temp);
			}
		});
		state.rightChecked = [];
	}
};

//全部已授权的变未授权
const allToLeft = () => {
	if (rightFilterData.value.length > 0) {
		const ids = rightFilterData.value.filter((e) => e.disabled == false).map((e) => e.id);
		ids.forEach((id: number) => {
			const index = state.rightData.findIndex((e) => e.id == id);
			if (index > -1) {
				const temp = state.rightData.splice(index, 1);
				state.leftData = state.leftData.concat(temp);
			}
		});
		state.rightChecked = [];
	}
};

// 导出对象
defineExpose({ openDialog });
</script>

<style lang="scss" scoped>
.transfer-panel {
	overflow: hidden;
	display: inline-block;
	text-align: left;
	vertical-align: middle;
	width: 100%;
	max-height: 100%;
	box-sizing: border-box;
	position: relative;
	border: 1px solid #ebeef5;
	&__header {
		width: 100%;
		display: flex;
		align-items: center;
		justify-content: space-between;
		flex-wrap: nowrap;
		background: #f5f7fa;
		padding: 3px 6px;
		border-bottom: 1px solid #ebeef5;
	}
	&__body {
		height: 300px;
		.transfer-panel__filter {
			padding: 6px;
		}
		.transfer-panel__list {
			overflow: auto;
			height: calc(100% - 36px);
			.transfer-panel__item {
				display: block !important;
				padding-left: 6px;
			}
		}
	}
}
.transfer-buttons {
	display: flex;
	flex-direction: column;
	justify-content: center;
	align-items: center;
	&__item {
		padding-top: 10px;
		width: 100%;
	}
}
</style>
