<template>
	<div class="sys-codeGenTree-container">
		<el-dialog v-model="state.isShowDialog" draggable :close-on-click-modal="false" width="700px">
			<template #header>
				<div style="color: #fff">
					<el-icon size="16" style="margin-right: 3px; display: inline; vertical-align: middle"> <ele-Edit /> </el-icon>
					<span> 树选择配置 </span>
				</div>
			</template>
			<el-form :model="state.ruleForm" ref="ruleFormRef" label-width="auto">
				<el-row :gutter="35">
					<el-col :xs="24" :sm="24" :md="24" :lg="24" :xl="24" class="mb20">
						<el-form-item label="库定位器" prop="configId" :rules="[{ required: true, message: '库不能为空', trigger: 'blur' }]">
							<el-select clearable v-model="state.ruleForm.configId" placeholder="库名" filterable @change="DbChanged()" class="w100">
								<el-option v-for="item in state.dbData" :key="item.configId" :label="item.configId" :value="item.configId" />
							</el-select>
						</el-form-item>
					</el-col>
					<el-col :xs="24" :sm="24" :md="24" :lg="24" :xl="24" class="mb20">
						<el-form-item label="数据库表" prop="tableName" :rules="[{ required: true, message: '数据表不能为空', trigger: 'blur' }]">
							<el-select v-model="state.ruleForm.tableName" class="w100" filterable clearable @change="TableChanged()">
								<el-option v-for="item in state.tableData" :key="item.entityName" :label="item.tableName + ' [' + item.tableComment + ']'" :value="item.tableName" />
							</el-select>
						</el-form-item>
					</el-col>
					<el-col :xs="24" :sm="24" :md="24" :lg="24" :xl="24" class="mb20">
						<el-form-item label="显示字段" prop="displayColumnList" :rules="[{ required: true, message: '显示字段不能为空', trigger: 'blur' }]">
							<el-select v-model="state.ruleForm.displayColumnList" multiple filterable class="w100">
								<el-option v-for="item in state.columnData" :key="item.columnName" :label="item.columnName + ' [' + item.columnComment + ']'" :value="item.columnName" />
							</el-select>
						</el-form-item>
					</el-col>
					<el-col :xs="24" :sm="24" :md="24" :lg="24" :xl="24" class="mb20">
						<el-form-item label="选择值字段" prop="valueColumn" :rules="[{ required: true, message: '值字段不能为空', trigger: 'blur' }]">
							<el-select v-model="state.ruleForm.valueColumn" class="w100">
								<el-option v-for="item in state.columnData" :key="item.columnName" :label="item.columnName + ' [' + item.columnComment + ']'" :value="item.columnName" />
							</el-select>
						</el-form-item>
					</el-col>
					<el-col :xs="24" :sm="24" :md="24" :lg="24" :xl="24" class="mb20">
						<el-form-item label="父级字段" prop="pidColumn" :rules="[{ required: true, message: '父级字段不能为空', trigger: 'blur' }]">
							<el-select v-model="state.ruleForm.pidColumn" class="w100">
								<el-option v-for="item in state.columnData" :key="item.columnName" :label="item.columnName + ' [' + item.columnComment + ']'" :value="item.columnName" />
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

<script lang="ts" setup name="sysCodeGenTree">
import { onMounted, reactive, ref } from 'vue';

import { getAPI } from '/@/utils/axios-utils';
import { SysCodeGenApi } from '/@/api-services/api';

let rowData = {} as any;
const emits = defineEmits(['submitRefreshFk']);
const ruleFormRef = ref();
const state = reactive({
	isShowDialog: false,
	ruleForm: {} as any,
	dbData: [] as any,
	tableData: [] as any,
	columnData: [] as any,
});

onMounted(async () => {
	await getDbList();

	// 默认使用第一个库
	//state.ruleForm.configId = state.dbData[0].configId;
	//await DbChanged();
});

const DbChanged = async () => {
	state.tableData = [];
	state.columnData = [];
	await getTableInfoList();
};

const TableChanged = async () => {
	state.columnData = [];
	await getColumnInfoList();
	state.ruleForm.displayColumnList = undefined;
	state.ruleForm.valueColumn = undefined;
	state.ruleForm.pidColumn = undefined;
};

const getDbList = async () => {
	const res = await getAPI(SysCodeGenApi).apiSysCodeGenDatabaseListGet();
	state.dbData = res.data.result;
};

const getTableInfoList = async () => {
	if (state.ruleForm.configId == '') return;
  const res = await getAPI(SysCodeGenApi).apiSysCodeGenTableListConfigIdGet(state.ruleForm.configId);
	state.tableData = res.data.result;
};

const getColumnInfoList = async () => {
	if (state.ruleForm.configId == '' || state.ruleForm.tableName == '') return;
  const res = await getAPI(SysCodeGenApi).apiSysCodeGenColumnListByTableNameTableNameConfigIdGet(state.ruleForm.tableName, state.ruleForm.configId);
	state.columnData = res.data.result;
};

// 打开弹窗
const openDialog = async (row: any) => {
	rowData = row;
	state.isShowDialog = true;
	ruleFormRef.value?.resetFields();
	if (rowData.fkConfigId) {
		await getDbList();
    state.ruleForm.configId = rowData.fkConfigId;
		state.ruleForm.tableName = rowData.fkTableName;

		await DbChanged();
		await TableChanged();

    state.ruleForm.pidColumn = rowData.pidColumn;
    state.ruleForm.valueColumn = rowData.valueColumn;
    state.ruleForm.displayColumnList = rowData.displayColumnList;
	}
};

// 关闭弹窗
const closeDialog = () => {
  rowData.fkColumnNetType = state.columnData.find(x => x.columnName == state.ruleForm.valueColumn)?.netType;
	let table = state.tableData.find(x => x.tableName == state.ruleForm.tableName);
	rowData.displayColumn = state.ruleForm.displayColumn;
	rowData.valueColumn = state.ruleForm.valueColumn;
  rowData.fkTableName = state.ruleForm.tableName;
	rowData.pidColumn = state.ruleForm.pidColumn;
	rowData.fkConfigId = state.ruleForm.configId;
  rowData.fkEntityName = table?.entityName;
	emits('submitRefreshFk', rowData);
	cancel();
};

// 取消
const cancel = () => {
	state.isShowDialog = false;
	ruleFormRef.value?.resetFields();
	state.ruleForm = {};
	state.dbData.value = [];
	state.tableData.value = [];
	state.columnData.value = [];
};

// 提交
const submit = () => {
	ruleFormRef.value.validate(async (valid: boolean) => {
		if (!valid) return;
		closeDialog();
	});
};

// 导出对象
defineExpose({ openDialog });
</script>
