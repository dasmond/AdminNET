<template>
	<div class="t_Material-container">
		<el-dialog v-model="isShowDialog" :title="props.title" :width="800" draggable="">
			<el-form :model="ruleForm" ref="ruleFormRef" label-width="auto" :rules="rules">
				<el-row :gutter="35">
					<el-form-item v-show="false">
						<el-input v-model="ruleForm.id" />
					</el-form-item>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="车间ID" prop="orgID">
							<el-select clearable filterable v-model="ruleForm.orgID" placeholder="请选择车间ID">
								<el-option v-for="(item,index) in sysOrgOrgIDDropdownList" :key="index" :value="item.value" :label="item.label" />
								
							</el-select>
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="物料编码" prop="materialCode">
							<el-input v-model="ruleForm.materialCode" placeholder="请输入物料编码" maxlength="128" show-word-limit clearable />
							
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
							<el-input v-model="ruleForm.unit" placeholder="请输入单位" maxlength="1" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="审核人" prop="auditTime">
							<el-date-picker v-model="ruleForm.auditTime" type="date" placeholder="审核人" />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="审核者Id" prop="auditUserId">
							<el-input v-model="ruleForm.auditUserId" placeholder="请输入审核者Id" maxlength="19" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="净重" prop="netweight">
							<el-input v-model="ruleForm.netweight" placeholder="请输入净重" maxlength="23" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="毛重" prop="grossweight">
							<el-input v-model="ruleForm.grossweight" placeholder="请输入毛重" maxlength="23" show-word-limit clearable />
							
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
							<el-input v-model="ruleForm.configTID" placeholder="请输入选配3类型" maxlength="1" show-word-limit clearable />
							
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
							<el-input v-model="ruleForm.storageLock" placeholder="请输入使用库存分配" maxlength="1" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="使用批号" prop="batchcode">
							<el-switch v-model="ruleForm.batchcode" active-text="是" inactive-text="否" />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="批号规则" prop="batchrule">
							<el-input v-model="ruleForm.batchrule" placeholder="请输入批号规则" maxlength="1" show-word-limit clearable />
							
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
	import { addT_Material, updateT_Material } from "/@/api/main/t_Material";
	import { getSysOrgOrgIDDropdown } from '/@/api/main/t_Material';
	import { getDictDataList } from '/@/api/system/admin';
	const getEditstatusData = ref<any>([]);
	const getEditflagData = ref<any>([]);
	const getEditmaterialOriginData = ref<any>([]);
	const getEditmaterialPropData = ref<any>([]);
	const getEditconfigFIDData = ref<any>([]);
	const getEditconfigSIDData = ref<any>([]);
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
		materialCode: [{required: true, message: '请输入物料编码！', trigger: 'blur',},],
		materialName: [{required: true, message: '请输入物料名称！', trigger: 'blur',},],
		materialEngname: [{required: true, message: '请输入英文名称！', trigger: 'blur',},],
		specification: [{required: true, message: '请输入规格！', trigger: 'blur',},],
		unit: [{required: true, message: '请输入单位！', trigger: 'blur',},],
		status: [{required: true, message: '请选择状态！', trigger: 'change',},],
		flag: [{required: true, message: '请选择审核标记！', trigger: 'change',},],
		netweight: [{required: true, message: '请输入净重！', trigger: 'blur',},],
		grossweight: [{required: true, message: '请输入毛重！', trigger: 'blur',},],
		cubage: [{required: true, message: '请输入体积！', trigger: 'blur',},],
		packqty: [{required: true, message: '请输入包装件数！', trigger: 'blur',},],
		materialOrigin: [{required: true, message: '请选择物料来源！', trigger: 'change',},],
		materialProp: [{required: true, message: '请选择物料属性！', trigger: 'change',},],
		productSeries: [{required: true, message: '请输入产品系列！', trigger: 'blur',},],
		grain: [{required: true, message: '请输入材质！', trigger: 'blur',},],
		color: [{required: true, message: '请输入颜色！', trigger: 'blur',},],
		picCode: [{required: true, message: '请输入图纸号！', trigger: 'blur',},],
		barCode: [{required: true, message: '请输入条型码！', trigger: 'blur',},],
		configFID: [{required: true, message: '请选择选配1类型！', trigger: 'change',},],
		configTypeFID: [{required: true, message: '请输入选配1项目ID！', trigger: 'blur',},],
		configFRequired: [{required: true, message: '请输入选配1必填！', trigger: 'blur',},],
		dftConfigFID: [{required: true, message: '请输入默认选配1内容ID！', trigger: 'blur',},],
		configSID: [{required: true, message: '请选择选配2类型！', trigger: 'change',},],
		configTypeSID: [{required: true, message: '请输入选配2项目ID！', trigger: 'blur',},],
		configSRequired: [{required: true, message: '请输入选配2必填！', trigger: 'blur',},],
		dftConfigSID: [{required: true, message: '请输入默认选配2内容ID！', trigger: 'blur',},],
		configTID: [{required: true, message: '请输入选配3类型！', trigger: 'blur',},],
		configTypeTID: [{required: true, message: '请输入选配3项目ID！', trigger: 'blur',},],
		configTRequired: [{required: true, message: '请输入选配3必填！', trigger: 'blur',},],
		dftConfigTID: [{required: true, message: '请输入默认选配3内容ID！', trigger: 'blur',},],
		suite: [{required: true, message: '请选择套件类型！', trigger: 'change',},],
		outType: [{required: true, message: '请选择进出类型！', trigger: 'change',},],
		auxUnit: [{required: true, message: '请输入辅助单位！', trigger: 'blur',},],
		rate: [{required: true, message: '请输入转换率！', trigger: 'blur',},],
		inuse: [{required: true, message: '请输入已使用！', trigger: 'blur',},],
		storageID: [{required: true, message: '请输入默认仓库ID！', trigger: 'blur',},],
		spaceID: [{required: true, message: '请输入默认仓位ID！', trigger: 'blur',},],
		storageLock: [{required: true, message: '请输入使用库存分配！', trigger: 'blur',},],
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
					await addT_Material(values);
				} else {
					await updateT_Material(values);
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

	const sysOrgOrgIDDropdownList = ref<any>([]); 
	const getSysOrgOrgIDDropdownList = async () => {
		let list = await getSysOrgOrgIDDropdown();
		sysOrgOrgIDDropdownList.value = list.data.result ?? [];
	};
	getSysOrgOrgIDDropdownList();
	






	// 页面加载时
	onMounted(async () => {
		getEditstatusData.value= await dictTypeDataList('IfAllowed');
		getEditflagData.value= await dictTypeDataList('IfAllowed');
		getEditmaterialOriginData.value= await dictTypeDataList('materialorigin');
		getEditmaterialPropData.value= await dictTypeDataList('materialorigin');
		getEditconfigFIDData.value= await dictTypeDataList('configtype');
		getEditconfigSIDData.value= await dictTypeDataList('configtype');
		getEditsuiteData.value= await dictTypeDataList('suite');
		getEditoutTypeData.value= await dictTypeDataList('outtype');
	});

	//将属性或者函数暴露给父组件
	defineExpose({ openDialog });
</script>




