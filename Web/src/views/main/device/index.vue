<template>
	<div class="device-container">
		<el-card shadow="hover" :body-style="{ paddingBottom: '0' }">
			<el-form :model="queryParams" ref="queryForm" :inline="true">
				<el-form-item label="类型" prop="type">
					<el-select v-model="queryParams.type" placeholder="请选择" clearable>
						<el-option label="算法" :value="0" />
						<el-option label="相机" :value="1" />
					</el-select>
				</el-form-item>
				<el-form-item label="名称">
					<el-input v-model="queryParams.name" clearable="" placeholder="请输入名称" />
				</el-form-item>
				<el-form-item label="IP&端口">
					<el-input v-model="queryParams.ipPort" clearable="" placeholder="请输入IP&端口" />
				</el-form-item>
				<el-form-item label="账号">
					<el-input v-model="queryParams.account" clearable="" placeholder="请输入账号" />
				</el-form-item>
				<el-form-item>
					<el-button-group>
						<el-button icon="ele-Refresh" @click="handleReset"> 重置 </el-button>
						<el-button type="primary" icon="ele-Search" @click="handleQuery" v-auth="'device:page'"> 查询
						</el-button>
					</el-button-group>
				</el-form-item>
				<el-form-item>
					<el-button type="primary" icon="ele-Plus" @click="openAddDevice" v-auth="'device:add'"> 新增 </el-button>
				</el-form-item>
			</el-form>
		</el-card>
		<el-card class="full-table" shadow="hover" style="margin-top: 8px">
			<el-table :data="tableData" style="width: 100%" v-loading="loading" tooltip-effect="light" row-key="id"
				border="">
				<el-table-column type="index" label="序号" width="55" align="center" fixed="" />
				<el-table-column prop="name" label="名称" fixed="" show-overflow-tooltip="" />
				<el-table-column prop="type" label="类型" fixed="" show-overflow-tooltip="">
					<template #default="scope">
						<span>{{ scope.row.type == 0 ? '算法' : '相机' }}</span>
					</template>
				</el-table-column>
				<el-table-column prop="ipPort" label="IP&端口" fixed="" show-overflow-tooltip="" />
				<el-table-column prop="account" label="账号" fixed="" show-overflow-tooltip="" />
				<el-table-column prop="remark" label="备注" fixed="" show-overflow-tooltip="" />
				<el-table-column label="操作" width="140" align="center" fixed="right" show-overflow-tooltip=""
					v-if="auth('device:edit') || auth('device:delete')">
					<template #default="scope">
						<el-button icon="ele-Edit" size="small" text="" type="primary" @click="openEditDevice(scope.row)"
							v-auth="'device:edit'"> 编辑 </el-button>
						<el-button icon="ele-Delete" size="small" text="" type="primary" @click="delDevice(scope.row)"
							v-auth="'device:delete'"> 删除 </el-button>
					</template>
				</el-table-column>
			</el-table>
			<el-pagination v-model:currentPage="tableParams.page" v-model:page-size="tableParams.pageSize"
				:total="tableParams.total" :page-sizes="[10, 20, 50, 100]" small="" background=""
				@size-change="handleSizeChange" @current-change="handleCurrentChange"
				layout="total, sizes, prev, pager, next, jumper" />
			<editDialog ref="editDialogRef" :title="editDialogTitle" @reloadTable="handleQuery" />
		</el-card>
	</div>
</template>
<script lang="ts" setup="" name="device">
import { ref } from 'vue';
import { ElMessageBox, ElMessage } from 'element-plus';
import { auth } from '/@/utils/authFunction';
import { pageDevice, deleteDevice } from '/@/api/main/device';
import editDialog from '/@/views/main/device/component/editDialog.vue';

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

// 查询数据
const handleQuery = async () => {
	loading.value = true;
	var res = await pageDevice(Object.assign(queryParams.value, tableParams.value));
	tableData.value = res.data.result?.items ?? [];
	tableParams.value.total = res.data.result?.total;
	loading.value = false;
};
const handleReset = () => {
	queryParams.value = {};
	handleQuery();
};

// 每页大小
const handleSizeChange = (val: number) => {
	tableParams.value.pageSize = val;
	handleQuery();
};

// 当前页数
const handleCurrentChange = (val: number) => {
	tableParams.value.page = val;
	handleQuery();
};

// 新增页面
const openAddDevice = () => {
	editDialogTitle.value = '添加设备';
	editDialogRef.value.openDialog({});
};

// 编辑页面
const openEditDevice = (row: any) => {
	editDialogTitle.value = '编辑设备';
	editDialogRef.value.openDialog(row);
};

// 删除数据
const delDevice = (row: any) => {
	ElMessageBox.confirm(`确定要删除吗?`, '提示', {
		confirmButtonText: '确定',
		cancelButtonText: '取消',
		type: 'warning',
	})
		.then(async () => {
			await deleteDevice(row);
			handleQuery();
			ElMessage.success('删除成功');
		})
		.catch(() => { });
};

handleQuery();
</script>
