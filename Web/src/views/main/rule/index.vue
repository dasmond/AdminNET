<template>
	<div class="rule-container">
		<el-card shadow="hover" :body-style="{ paddingBottom: '0' }">
			<el-form :model="queryParams" ref="queryForm" :inline="true">
				<el-form-item label="类型" prop="type">
					<el-select v-model="queryParams.type" placeholder="请选择" clearable>
						<el-option label="文字" :value="0" />
						<el-option label="图片" :value="1" />
						<el-option label="音频" :value="2" />
						<el-option label="视频" :value="3" />
					</el-select>
				</el-form-item>
				<el-form-item label="名称">
					<el-input v-model="queryParams.name" clearable="" placeholder="请输入名称" />
				</el-form-item>
				<el-form-item label="内容">
					<el-input v-model="queryParams.content" clearable="" placeholder="请输入内容" />
				</el-form-item>
				<el-form-item>
					<el-button-group>
						<el-button type="primary" icon="ele-Search" @click="handleQuery" v-auth="'rule:page'"> 查询 </el-button>
						<el-button icon="ele-Refresh" @click="() => (queryParams = {})"> 重置 </el-button>
					</el-button-group>
				</el-form-item>
				<el-form-item>
					<el-button type="primary" icon="ele-Plus" @click="openAddRule" v-auth="'rule:add'"> 新增 </el-button>
				</el-form-item>
			</el-form>
		</el-card>
		<el-card class="full-table" shadow="hover" style="margin-top: 8px">
			<el-table :data="tableData" style="width: 100%" v-loading="loading" tooltip-effect="light" row-key="id" border="">
				<el-table-column type="index" label="序号" width="55" align="center" fixed="" />
				<el-table-column prop="name" label="名称" fixed="" show-overflow-tooltip="">
					<template #default="scope"> {{ scope.row.name }} <el-tag v-if="scope.row.isDisable" style="margin-left: 8px">禁用</el-tag> </template>
				</el-table-column>
				<el-table-column prop="type" label="类型" fixed="" show-overflow-tooltip="">
					<template #default="scope">
						<span>{{ getTypeTitle(scope.row.type) }}</span>
					</template>
				</el-table-column>
				<el-table-column prop="start" label="起始(秒)" fixed="" show-overflow-tooltip="" />
				<el-table-column prop="range" label="持续(秒)" fixed="" show-overflow-tooltip="" />
				<el-table-column prop="content" label="内容" fixed="" show-overflow-tooltip="" />
				<el-table-column prop="sortIndex" label="排序" fixed="" show-overflow-tooltip="" />
				<el-table-column prop="remark" label="备注" fixed="" show-overflow-tooltip="" />
				<el-table-column label="操作" width="140" align="center" fixed="right" show-overflow-tooltip="" v-if="auth('rule:edit') || auth('rule:delete')">
					<template #default="scope">
						<el-button icon="ele-Edit" size="small" text="" type="primary" @click="openEditRule(scope.row)" v-auth="'rule:edit'"> 编辑 </el-button>
						<el-button icon="ele-Delete" size="small" text="" type="primary" @click="delRule(scope.row)" v-auth="'rule:delete'"> 删除 </el-button>
					</template>
				</el-table-column>
			</el-table>
			<el-pagination
				v-model:currentPage="tableParams.page"
				v-model:page-size="tableParams.pageSize"
				:total="tableParams.total"
				:page-sizes="[10, 20, 50, 100]"
				small=""
				background=""
				@size-change="handleSizeChange"
				@current-change="handlePageChange"
				layout="total, sizes, prev, pager, next, jumper"
			/>
			<editDialog ref="editDialogRef" :title="editDialogTitle" @reloadTable="handleQuery" />
		</el-card>
	</div>
</template>
<script lang="ts" setup="" name="rule">
import { ref } from 'vue';
import { ElMessageBox, ElMessage } from 'element-plus';
import { auth } from '/@/utils/authFunction';
import { pageRule, deleteRule } from '/@/api/main/rule';
import editDialog from '/@/views/main/rule/component/editDialog.vue';

const loading = ref(false);
const tableData = ref<any>([]);
const queryParams = ref<any>({});
const tableParams = ref({
	page: 1,
	pageSize: 10,
	total: 0,
});

const editDialogRef = ref();
const editDialogTitle = ref('');

const getTypeTitle = (value: number) => {
	let result = '';
	switch (value) {
		case 0:
			result = '文字';
			break;
		case 1:
			result = '图片';
			break;
		case 2:
			result = '音频';
			break;
		case 3:
			result = '视频';
			break;
	}
	return result;
};

// 查询数据
const handleQuery = async () => {
	loading.value = true;
	var res = await pageRule(Object.assign(queryParams.value, tableParams.value));
	tableData.value = res.data.result?.items ?? [];
	tableParams.value.total = res.data.result?.total;
	loading.value = false;
};

// 每页大小
const handleSizeChange = (val: number) => {
	tableParams.value.pageSize = val;
	handleQuery();
};

// 当前页数
const handlePageChange = (val: number) => {
	tableParams.value.page = val;
	handleQuery();
};

// 新增页面
const openAddRule = () => {
	editDialogTitle.value = '添加规则';
	editDialogRef.value.openDialog({});
};

// 编辑页面
const openEditRule = (row: any) => {
	editDialogTitle.value = '编辑规则';
	editDialogRef.value.openDialog(row);
};

// 删除数据
const delRule = (row: any) => {
	ElMessageBox.confirm(`确定要删除吗?`, '提示', {
		confirmButtonText: '确定',
		cancelButtonText: '取消',
		type: 'warning',
	})
		.then(async () => {
			await deleteRule(row);
			handleQuery();
			ElMessage.success('删除成功');
		})
		.catch(() => {});
};

handleQuery();
</script>
