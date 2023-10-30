<template>
	<div class="tn-base-page">
		<div class="tn-base-page-content">
			<el-form v-loading="loading" :model="ruleForm" ref="ruleFormRef" label-width="auto" :rules="rules">
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
		</div>
		<div class="tn-base-page-bottom">
			<el-button @click="cancel">取 消</el-button>
			<el-button type="primary" @click="submit">确 定</el-button>
		</div>
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
	import { ElMessage, ElMessageBox } from "element-plus";
	import type { FormRules } from "element-plus";
	import { addT_WorkGroup, updateT_WorkGroup } from "/@/api/main/t_WorkGroup";
	import { getT_WorkShopWorkShopIDDropdown } from '/@/api/main/t_WorkGroup';

	import { useRoute } from "vue-router";
	import mittBus from "/@/utils/mitt";
	const loading = ref(false)

	const ruleFormRef = ref();
	const ruleForm = ref<any>({});
	//自行添加其他规则
	const rules = ref<FormRules>({
		workGroupCode: [{required: true, message: '请输入生产中心编号！', trigger: 'blur',},],
		workGroupName: [{required: true, message: '请输入生产中心名称！', trigger: 'blur',},],
		workGroupSimpleName: [{required: true, message: '请输入生产中心简称！', trigger: 'blur',},],
	});

	// 定义变量内容
	const route = useRoute();

	// 1、关闭当前 tagsView
	const refreshCurrentTagsView = () => {
		mittBus.emit(
			"onCurrentContextmenuClick",
			Object.assign({}, { contextMenuClickId: 1, ...route })
		);
	};

	// 取消
	const cancel = () => {
		ElMessageBox.confirm(`确定要退出编辑吗?`, "提示", {
			confirmButtonText: "确定",
			cancelButtonText: "取消",
			type: "warning",
		})
		.then(async () => {
			refreshCurrentTagsView()
		})
		.catch(() => {
		});
	};

	// 提交
	const submit = async () => {
		ruleFormRef.value.validate(async (isValid: boolean, fields?: any) => {
			if (isValid) {
				loading.value = true;
				let values = ruleForm.value;
				let res
				if (ruleForm.value.id == undefined || ruleForm.value.id == null || ruleForm.value.id == "" || ruleForm.value.id == 0) {
					res = await addT_WorkGroup(values);
				} else {
					res = await updateT_WorkGroup(values);
				}
				if (res.data.code == 200) {
					loading.value = false;
					ElMessage.success("保存成功");
					setTimeout(() => {
						refreshCurrentTagsView();
					}, 1500)
				}
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
		if (route.query.params) {
			ruleForm.value = JSON.parse(<string>route.query.params)
		}
	});

	
</script>




