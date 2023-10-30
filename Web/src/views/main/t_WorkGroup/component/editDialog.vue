<template>
	<div class="t_WorkGroup-container">
		<el-dialog v-model="isShowDialog" :title="props.title" :width="800" draggable="">
			<el-form :model="ruleForm" ref="ruleFormRef" label-width="auto" :rules="rules">
				<el-row :gutter="35">
					<el-form-item v-show="false">
						<el-input v-model="ruleForm.id" />
					</el-form-item>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="生产中心编号" prop="workGroupCode">
							<el-input v-model="ruleForm.workGroupCode" placeholder="请输入生产中心编号" maxlength="128" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="生产中心名称" prop="workGroupName">
							<el-input v-model="ruleForm.workGroupName" placeholder="请输入生产中心名称" maxlength="128" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="生产中心简称" prop="workGroupSimpleName">
							<el-input v-model="ruleForm.workGroupSimpleName" placeholder="请输入生产中心简称" maxlength="128" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="所属车间" prop="workShopID">
							<el-select clearable filterable v-model="ruleForm.workShopID" placeholder="请选择所属车间">
								<el-option v-for="(item,index) in t_WorkShopWorkShopIDDropdownList" :key="index" :value="item.value" :label="item.label" />
								
							</el-select>
							
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
	import { ElMessage } from "element-plus";
	import type { FormRules } from "element-plus";
	import { addT_WorkGroup, updateT_WorkGroup } from "/@/api/main/t_WorkGroup";
	import { getT_WorkShopWorkShopIDDropdown } from '/@/api/main/t_WorkGroup';
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
		workGroupCode: [{required: true, message: '请输入生产中心编号！', trigger: 'blur',},],
		workGroupName: [{required: true, message: '请输入生产中心名称！', trigger: 'blur',},],
	});

	// 打开弹窗
	const openDialog = (row: any) => {
		ruleForm.value = JSON.parse(JSON.stringify(row));
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
					await addT_WorkGroup(values);
				} else {
					await updateT_WorkGroup(values);
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


	const t_WorkShopWorkShopIDDropdownList = ref<any>([]); 
	const getT_WorkShopWorkShopIDDropdownList = async () => {
		let list = await getT_WorkShopWorkShopIDDropdown();
		t_WorkShopWorkShopIDDropdownList.value = list.data.result ?? [];
	};
	getT_WorkShopWorkShopIDDropdownList();
	






	// 页面加载时
	onMounted(async () => {
	});

	//将属性或者函数暴露给父组件
	defineExpose({ openDialog });
</script>




