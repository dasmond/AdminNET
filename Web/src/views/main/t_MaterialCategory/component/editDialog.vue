<template>
	<div class="t_MaterialCategory-container">
		<el-dialog v-model="isShowDialog" :title="props.title" :width="800" draggable="">
			<el-form :model="ruleForm" ref="ruleFormRef" label-width="auto" :rules="rules">
				<el-row :gutter="35">
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="车间ID" prop="orgID">
							<el-select clearable filterable v-model="ruleForm.orgID" placeholder="请选择车间ID">
								<el-option v-for="(item,index) in t_WorkShopOrgIDDropdownList" :key="index" :value="item.value" :label="item.label" />
								
							</el-select>
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="物料类别编码" prop="categoryCode">
							<el-input v-model="ruleForm.categoryCode" placeholder="请输入物料类别编码" maxlength="32" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="物料类别名称" prop="categoryName">
							<el-input v-model="ruleForm.categoryName" placeholder="请输入物料类别名称" maxlength="128" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="连接符号" prop="connectorStr">
							<el-input v-model="ruleForm.connectorStr" placeholder="请输入连接符号" maxlength="10" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="流水长度" prop="codeLength">
							<el-input-number v-model="ruleForm.codeLength" placeholder="请输入流水长度" clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="物料名称" prop="materialName">
							<el-input v-model="ruleForm.materialName" placeholder="请输入物料名称" maxlength="255" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="英文名称" prop="materialEngname">
							<el-input v-model="ruleForm.materialEngname" placeholder="请输入英文名称" maxlength="255" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="规格" prop="specification">
							<el-input v-model="ruleForm.specification" placeholder="请输入规格" maxlength="255" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="单位" prop="unit">
							<el-input v-model="ruleForm.unit" placeholder="请输入单位" maxlength="10" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="净重" prop="netWeight">
							<el-input v-model="ruleForm.netWeight" placeholder="请输入净重" maxlength="23" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="毛重" prop="grossWeight">
							<el-input v-model="ruleForm.grossWeight" placeholder="请输入毛重" maxlength="23" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="体积" prop="cubage">
							<el-input v-model="ruleForm.cubage" placeholder="请输入体积" maxlength="23" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="包装件数" prop="packqty">
							<el-input v-model="ruleForm.packqty" placeholder="请输入包装件数" maxlength="23" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="物料来源" prop="materialOrigin">
							<el-select clearable v-model="ruleForm.materialOrigin" placeholder="请选择物料来源">
								<el-option v-for="(item,index) in  getEditmaterialOriginData"  :key="index" :value="item.code" :label="item.value"></el-option>
								
							</el-select>
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="物料属性" prop="materialProp">
							<el-select clearable v-model="ruleForm.materialProp" placeholder="请选择物料属性">
								<el-option v-for="(item,index) in  getEditmaterialPropData"  :key="index" :value="item.code" :label="item.value"></el-option>
								
							</el-select>
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="产品系列" prop="productSeries">
							<el-input v-model="ruleForm.productSeries" placeholder="请输入产品系列" maxlength="255" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="材质" prop="grain">
							<el-input v-model="ruleForm.grain" placeholder="请输入材质" maxlength="255" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="颜色" prop="color">
							<el-input v-model="ruleForm.color" placeholder="请输入颜色" maxlength="255" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="图纸号" prop="picCode">
							<el-input v-model="ruleForm.picCode" placeholder="请输入图纸号" maxlength="255" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="条型码" prop="barCode">
							<el-input v-model="ruleForm.barCode" placeholder="请输入条型码" maxlength="255" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="选配1类型" prop="configFID">
							<el-select clearable v-model="ruleForm.configFID" placeholder="请选择选配1类型">
								<el-option v-for="(item,index) in  getEditconfigFIDData"  :key="index" :value="item.code" :label="item.value"></el-option>
								
							</el-select>
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="选配1项目ID" prop="configTypeFID">
							<el-input v-model="ruleForm.configTypeFID" placeholder="请输入选配1项目ID" maxlength="19" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="选配1必填" prop="configFRequired">
							<el-input v-model="ruleForm.configFRequired" placeholder="请输入选配1必填" maxlength="1" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="默认选配1内容ID" prop="dftConfigFID">
							<el-input v-model="ruleForm.dftConfigFID" placeholder="请输入默认选配1内容ID" maxlength="19" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="选配2类型" prop="configSID">
							<el-select clearable v-model="ruleForm.configSID" placeholder="请选择选配2类型">
								<el-option v-for="(item,index) in  getEditconfigSIDData"  :key="index" :value="item.code" :label="item.value"></el-option>
								
							</el-select>
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="选配2项目ID" prop="configTypeSID">
							<el-input v-model="ruleForm.configTypeSID" placeholder="请输入选配2项目ID" maxlength="19" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="选配2必填" prop="configSRequired">
							<el-input v-model="ruleForm.configSRequired" placeholder="请输入选配2必填" maxlength="1" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="默认选配2内容ID" prop="dftConfigSID">
							<el-input v-model="ruleForm.dftConfigSID" placeholder="请输入默认选配2内容ID" maxlength="19" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="选配3类型" prop="configTID">
							<el-select clearable v-model="ruleForm.configTID" placeholder="请选择选配3类型">
								<el-option v-for="(item,index) in  getEditconfigTIDData"  :key="index" :value="item.code" :label="item.value"></el-option>
								
							</el-select>
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="选配3项目ID" prop="configTypeTID">
							<el-input v-model="ruleForm.configTypeTID" placeholder="请输入选配3项目ID" maxlength="19" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="选配3必填" prop="configTRequired">
							<el-input v-model="ruleForm.configTRequired" placeholder="请输入选配3必填" maxlength="1" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="默认选配3内容ID" prop="dftConfigTID">
							<el-input v-model="ruleForm.dftConfigTID" placeholder="请输入默认选配3内容ID" maxlength="19" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="套件类型" prop="suite">
							<el-select clearable v-model="ruleForm.suite" placeholder="请选择套件类型">
								<el-option v-for="(item,index) in  getEditsuiteData"  :key="index" :value="item.code" :label="item.value"></el-option>
								
							</el-select>
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="进出类型" prop="outType">
							<el-select clearable v-model="ruleForm.outType" placeholder="请选择进出类型">
								<el-option v-for="(item,index) in  getEditoutTypeData"  :key="index" :value="item.code" :label="item.value"></el-option>
								
							</el-select>
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="辅助单位" prop="auxUnit">
							<el-input v-model="ruleForm.auxUnit" placeholder="请输入辅助单位" maxlength="32" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="转换率" prop="rate">
							<el-input v-model="ruleForm.rate" placeholder="请输入转换率" maxlength="23" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="默认仓库ID" prop="storageID">
							<el-input v-model="ruleForm.storageID" placeholder="请输入默认仓库ID" maxlength="19" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="默认仓位ID" prop="spaceID">
							<el-input v-model="ruleForm.spaceID" placeholder="请输入默认仓位ID" maxlength="19" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="使用库存分配" prop="storageLock">
							<el-switch v-model="ruleForm.storageLock" active-text="是" inactive-text="否" />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="使用批号" prop="batchCode">
							<el-switch v-model="ruleForm.batchCode" active-text="是" inactive-text="否" />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="批号规则" prop="batchRule">
							<el-input v-model="ruleForm.batchRule" placeholder="请输入批号规则" maxlength="1" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-form-item v-show="false">
						<el-input v-model="ruleForm.id" />
					</el-form-item>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="上级ID" prop="pID">
							<el-select clearable filterable v-model="ruleForm.pID" placeholder="请选择上级ID">
								<el-option v-for="(item,index) in t_MaterialCategoryPIDDropdownList" :key="index" :value="item.value" :label="item.label" />
								
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
	import { addT_MaterialCategory, updateT_MaterialCategory } from "/@/api/main/t_MaterialCategory";
	import { getT_WorkShopOrgIDDropdown } from '/@/api/main/t_MaterialCategory';
	import { getT_MaterialCategoryPIDDropdown } from '/@/api/main/t_MaterialCategory';
	import { getDictDataList } from '/@/api/system/admin';
	const getEditmaterialOriginData = ref<any>([]);
	const getEditmaterialPropData = ref<any>([]);
	const getEditconfigFIDData = ref<any>([]);
	const getEditconfigSIDData = ref<any>([]);
	const getEditconfigTIDData = ref<any>([]);
	const getEditsuiteData = ref<any>([]);
	const getEditoutTypeData = ref<any>([]);
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
		categoryCode: [{required: true, message: '请输入物料类别编码！', trigger: 'blur',},],
		categoryName: [{required: true, message: '请输入物料类别名称！', trigger: 'blur',},],
		connectorStr: [{required: true, message: '请输入连接符号！', trigger: 'blur',},],
		codeLength: [{required: true, message: '请输入流水长度！', trigger: 'blur',},],
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
					await addT_MaterialCategory(values);
				} else {
					await updateT_MaterialCategory(values);
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

	const t_WorkShopOrgIDDropdownList = ref<any>([]); 
	const getT_WorkShopOrgIDDropdownList = async () => {
		let list = await getT_WorkShopOrgIDDropdown();
		t_WorkShopOrgIDDropdownList.value = list.data.result ?? [];
	};
	getT_WorkShopOrgIDDropdownList();
	
	const t_MaterialCategoryPIDDropdownList = ref<any>([]); 
	const getT_MaterialCategoryPIDDropdownList = async () => {
		let list = await getT_MaterialCategoryPIDDropdown();
		t_MaterialCategoryPIDDropdownList.value = list.data.result ?? [];
	};
	getT_MaterialCategoryPIDDropdownList();
	






	// 页面加载时
	onMounted(async () => {
		getEditmaterialOriginData.value= await dictTypeDataList('materialorigin');
		getEditmaterialPropData.value= await dictTypeDataList('materialprop');
		getEditconfigFIDData.value= await dictTypeDataList('configtype');
		getEditconfigSIDData.value= await dictTypeDataList('configtype');
		getEditconfigTIDData.value= await dictTypeDataList('configtype');
		getEditsuiteData.value= await dictTypeDataList('suite');
		getEditoutTypeData.value= await dictTypeDataList('outtype');
	});

	//将属性或者函数暴露给父组件
	defineExpose({ openDialog });
</script>




