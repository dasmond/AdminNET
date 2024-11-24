<template>
	<div class="sys-app-container">
		<el-card shadow="hover" :body-style="{ paddingBottom: '0' }">
			<el-form :model="state.queryParams" ref="queryForm" :inline="true">
				<el-form-item label="关键字">
					<el-input v-model="state.queryParams.keyword" placeholder="关键字" clearable />
				</el-form-item>
				<el-form-item>
					<el-button-group>
						<el-button type="primary" icon="ele-Search" @click="handleQuery" v-auth="'sysApp:page'"> 查询 </el-button>
						<el-button icon="ele-Refresh" @click="resetQuery"> 重置 </el-button>
					</el-button-group>
				</el-form-item>
				<el-form-item>
					<el-button type="primary" icon="ele-Plus" @click="openAddApp" v-auth="'sysApp:add'"> 新增 </el-button>
				</el-form-item>
			</el-form>
		</el-card>

		<el-card class="full-table" shadow="hover" style="margin-top: 5px">
			<el-table :data="state.appData" style="width: 100%" v-loading="state.loading" border>
				<el-table-column type="index" label="序号" width="55" align="center" fixed />
        <el-table-column prop="logo" label="图标" width="55" align="center" show-overflow-tooltip>
          <template #default="scope">
            <el-avatar shape="square" :src="scope.row.logo" size="small" />
          </template>
        </el-table-column>
				<el-table-column prop="name" label="名称" width="180" align="center" show-overflow-tooltip />
				<el-table-column prop="title" label="标题" width="180" align="center" show-overflow-tooltip />
				<el-table-column prop="viceTitle" label="副标题" width="180" align="center" show-overflow-tooltip />
				<el-table-column prop="viceDesc" label="描述" width="300" align="center" show-overflow-tooltip />
				<el-table-column prop="watermark" label="水印" width="130" align="center" show-overflow-tooltip />
				<el-table-column prop="copyright" label="版权信息" width="350" align="center" show-overflow-tooltip />
				<el-table-column prop="icp" label="备案号" width="130" align="center" show-overflow-tooltip />
				<el-table-column prop="orderNo" label="排序" width="70" align="center" show-overflow-tooltip />
				<el-table-column label="修改记录" width="100" align="center" show-overflow-tooltip>
					<template #default="scope">
						<ModifyRecord :data="scope.row" />
					</template>
				</el-table-column>
				<el-table-column label="操作" width="130" fixed="right" align="center" show-overflow-tooltip>
					<template #default="scope">
						<el-button icon="ele-Edit" size="small" text type="primary" @click="openEditApp(scope.row)" v-auth="'sysApp:update'"> 编辑 </el-button>
						<el-button icon="ele-Delete" size="small" text type="danger" @click="delApp(scope.row)" v-auth="'sysApp:delete'"> 删除 </el-button>
					</template>
				</el-table-column>
			</el-table>
			<el-pagination
				v-model:currentPage="state.tableParams.page"
				v-model:page-size="state.tableParams.pageSize"
				:total="state.tableParams.total"
				:page-sizes="[10, 20, 50, 100]"
				size="small"
				background
				@size-change="handleSizeChange"
				@current-change="handleCurrentChange"
				layout="total, sizes, prev, pager, next, jumper"
			/>
		</el-card>

		<EditApp ref="editAppRef" :title="state.editAppTitle" @handleQuery="handleQuery" />
	</div>
</template>

<script lang="ts" setup name="sysApp">
import { onMounted, reactive, ref } from 'vue';
import { ElMessageBox, ElMessage } from 'element-plus';
import EditApp from '/@/views/system/app/component/editApp.vue';
import ModifyRecord from '/@/components/table/modifyRecord.vue';

import { getAPI } from '/@/utils/axios-utils';
import { SysAppApi } from '/@/api-services/api';

const editAppRef = ref<InstanceType<typeof EditApp>>();
const state = reactive({
	loading: false,
	appData: [] as any[],
	queryParams: {
		keyword: undefined,
	},
	tableParams: {
		page: 1,
		pageSize: 50,
		total: 0 as any,
	},
	editAppTitle: '',
});

onMounted(async () => {
	await handleQuery();
});

// 查询操作
const handleQuery = async () => {
	state.loading = true;
	let params = Object.assign(state.queryParams, state.tableParams);
	let res = await getAPI(SysAppApi).apiSysAppPagePost(params);
	state.appData = res.data.result?.items ?? [];
	state.tableParams.total = res.data.result?.total;
	state.loading = false;
};

// 重置操作
const resetQuery = async () => {
	state.queryParams.keyword = undefined;
	await handleQuery();
};

// 打开新增页面
const openAddApp = () => {
	state.editAppTitle = '添加应用';
	editAppRef.value?.openDialog({ id: undefined, status: 1, orderNo: 100 });
};

// 打开编辑页面
const openEditApp = async (row: any) => {
	state.editAppTitle = '编辑应用';
	editAppRef.value?.openDialog(row);
};

// 删除
const delApp = (row: any) => {
	ElMessageBox.confirm(`确定删除应用：【${row.name}】?`, '提示', {
		confirmButtonText: '确定',
		cancelButtonText: '取消',
		type: 'warning',
	})
		.then(async () => {
			await getAPI(SysAppApi).apiSysAppDeletePost({ id: row.id });
			await handleQuery();
			ElMessage.success('删除成功');
		})
		.catch(() => {});
};

// 改变页面容量
const handleSizeChange = async (val: number) => {
	state.tableParams.pageSize = val;
	await handleQuery();
};

// 改变页码序号
const handleCurrentChange = async (val: number) => {
	state.tableParams.page = val;
	await handleQuery();
};
</script>
