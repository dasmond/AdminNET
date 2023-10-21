<template>
	<div class="t_WorkLine-container">
		<el-dialog v-model="isShowDialog" :title="props.title" :width="800" draggable="">
			<el-form :model="ruleForm" ref="ruleFormRef" label-width="auto" :rules="rules">
				<el-row :gutter="35">
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="生产线编号" prop="workLineCode">
							<el-input v-model="ruleForm.workLineCode" placeholder="请输入生产线编号" maxlength="128" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="生产线名称" prop="workLineName">
							<el-input v-model="ruleForm.workLineName" placeholder="请输入生产线名称" maxlength="128" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="生产线简称" prop="workLineSimpleName">
							<el-input v-model="ruleForm.workLineSimpleName" placeholder="请输入生产线简称" maxlength="128" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="允许领料" prop="ifAllowed">
							<el-select clearable v-model="ruleForm.ifAllowed" placeholder="请选择允许领料">
								<el-option v-for="(item,index) in  getEditifAllowedData"  :key="index" :value="item.code" :label="item.value"></el-option>
								
							</el-select>
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="允许计件" prop="ifPriceAllowed">
							<el-select clearable v-model="ruleForm.ifPriceAllowed" placeholder="请选择允许计件">
								<el-option v-for="(item,index) in  getEditifPriceAllowedData"  :key="index" :value="item.code" :label="item.value"></el-option>
								
							</el-select>
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="所属生产中心" prop="workGroupID">
							<el-select clearable filterable v-model="ruleForm.workGroupID" placeholder="请选择所属生产中心">
								<el-option v-for="(item,index) in t_WorkGroupWorkGroupIDDropdownList" :key="index" :value="item.value" :label="item.label" />
								
							</el-select>
							
						</el-form-item>
						
					</el-col>
					<el-form-item v-show="false">
						<el-input v-model="ruleForm.id" />
					</el-form-item>
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
	import { addT_WorkLine, updateT_WorkLine } from "/@/api/main/t_WorkLine";
	import { getT_WorkGroupWorkGroupIDDropdown } from '/@/api/main/t_WorkLine';
	import { getDictDataList } from '/@/api/system/admin';
	const getEditifAllowedData = ref<any>([]);
	const getEditifPriceAllowedData = ref<any>([]);
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
		workLineCode: [{required: true, message: '请输入生产线编号！', trigger: 'blur',},],
		workLineName: [{required: true, message: '请输入生产线名称！', trigger: 'blur',},],
		ifAllowed: [{required: true, message: '请选择允许领料！', trigger: 'change',},],
		ifPriceAllowed: [{required: true, message: '请选择允许计件！', trigger: 'change',},],
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
					await addT_WorkLine(values);
				} else {
					await updateT_WorkLine(values);
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

		const dictTypeDataList = async (val: any) => {
		let list = await getDictDataList(val);
		return list.data.result ?? [];
		};

	const t_WorkGroupWorkGroupIDDropdownList = ref<any>([]); 
	const getT_WorkGroupWorkGroupIDDropdownList = async () => {
		let list = await getT_WorkGroupWorkGroupIDDropdown();
		t_WorkGroupWorkGroupIDDropdownList.value = list.data.result ?? [];
	};
	getT_WorkGroupWorkGroupIDDropdownList();
	






	// 页面加载时
	onMounted(async () => {
		getEditifAllowedData.value= await dictTypeDataList('IfAllowed');
		getEditifPriceAllowedData.value= await dictTypeDataList('IfAllowed');
	});

	//将属性或者函数暴露给父组件
	defineExpose({ openDialog });
</script>




