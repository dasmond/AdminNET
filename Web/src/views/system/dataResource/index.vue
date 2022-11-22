<template>
	<div class="sys-dataRes-container">
		<el-row :gutter="8" style="width: 100%">
			<el-col :span="5" :xs="24">
				<DataResTree ref="dataResTreeRef" @node-click="nodeClick" />
			</el-col>

			<el-col :span="19" :xs="24">
				<el-card shadow="hover" :body-style="{ paddingBottom: '0' }">
					<el-form :model="queryParams" ref="queryForm" :inline="true">
						<el-form-item label="资源名称" prop="name">
							<el-input placeholder="资源名称" clearable @keyup.enter="handleQuery" v-model="queryParams.name" />
						</el-form-item>
						<el-form-item label="资源值" prop="value">
							<el-input placeholder="资源值" clearable @keyup.enter="handleQuery" v-model="queryParams.value" />
						</el-form-item>
						<el-form-item label="资源编码" prop="code">
							<el-input placeholder="资源编码" clearable @keyup.enter="handleQuery" v-model="queryParams.code" />
						</el-form-item>
						<el-form-item>
							<el-button icon="ele-Refresh" @click="resetQuery"> 重置 </el-button>
							<el-button type="primary" icon="ele-Search" @click="handleQuery" v-auth="'sysDataResource:page'"> 查询 </el-button>
							<el-button icon="ele-Plus" @click="openAddDataRes" v-auth="'sysDataResource:add'"> 新增 </el-button>
						</el-form-item>
					</el-form>
				</el-card>

				<el-card shadow="hover" style="margin-top: 8px">
					<el-table :data="dataResData" style="width: 100%" v-loading="loading" row-key="id" default-expand-all :tree-props="{ children: 'children', hasChildren: 'hasChildren' }" border>
						<el-table-column prop="name" label="资源名称" show-overflow-tooltip />
						<el-table-column prop="value" label="资源值" show-overflow-tooltip />
						<el-table-column prop="code" label="资源编码" show-overflow-tooltip />
						<el-table-column prop="order" label="排序" width="70" align="center" show-overflow-tooltip />
						<el-table-column label="状态" width="70" align="center" show-overflow-tooltip>
							<template #default="scope">
								<el-tag type="success" v-if="scope.row.status === 1">启用</el-tag>
								<el-tag type="danger" v-else>禁用</el-tag>
							</template>
						</el-table-column>
						<el-table-column prop="createTime" label="修改时间" align="center" show-overflow-tooltip />
						<el-table-column prop="remark" label="备注" show-overflow-tooltip />
						<el-table-column label="操作" width="140" fixed="right" align="center" show-overflow-tooltip>
							<template #default="scope">
								<el-button icon="ele-Edit" size="small" text type="primary" @click="openEditDataRes(scope.row)" v-auth="'sysDataResource:update'"> 编辑 </el-button>
								<el-button icon="ele-Delete" size="small" text type="danger" @click="delDataRes(scope.row)" v-auth="'sysDataResource:delete'"> 删除 </el-button>
							</template>
						</el-table-column>
					</el-table>
				</el-card>
			</el-col>
		</el-row>
		<EditDataRes ref="editDataResRef" :title="editDataResTitle" :dataResData="dataResTreeData" />
	</div>
</template>

<script lang="ts">
import { ref, toRefs, reactive, onMounted, defineComponent, onUnmounted } from 'vue';
import mittBus from '/@/utils/mitt';
import { ElMessageBox, ElMessage } from 'element-plus';
import DataResTree from '/@/views/system/dataResource/component/dataResTree.vue';
import EditDataRes from '/@/views/system/dataResource/component/editDataRes.vue';

import { getAPI } from '/@/utils/axios-utils';
import { SysDataResourceApi } from '/@/api-services/api';
import { SysDataResource } from '/@/api-services/models';

export default defineComponent({
	name: 'sysDataResource',
	components: { DataResTree, EditDataRes },
	setup() {
		const editDataResRef = ref();
		const dataResTreeRef = ref();
		const state = reactive({
			loading: false,
			dataResData: [] as Array<SysDataResource>, // 数据资源列表数据
			dataResTreeData: [] as Array<SysDataResource>, // 数据资源树所有数据
			queryParams: {
				id: -1,
				pid: 0,
				name: undefined,
				value: undefined,
				code: undefined,
			},
			editDataResTitle: '',
		});
		onMounted(() => {
			handleQuery();

			mittBus.on('submitRefresh', async () => {
				handleQuery();

				// 编辑删除后更新资源数据
				dataResTreeRef.value.initTreeData();
			});
		});
		onUnmounted(() => {
			mittBus.off('submitRefresh');
		});
		// 查询操作
		const handleQuery = async () => {
			state.loading = true;
			var res = await getAPI(SysDataResourceApi).sysDataResourceListGet(state.queryParams.id, state.queryParams.pid, state.queryParams.name, state.queryParams.value, state.queryParams.code);
			state.dataResData = res.data.result ?? [];
			state.loading = false;

			// 若无选择节点并且查询条件为空时
			if (state.queryParams.id == -1 && state.queryParams.pid == 0 && state.queryParams.name == undefined && state.queryParams.value == undefined && state.queryParams.code == undefined)
				state.dataResTreeData = state.dataResData;
		};
		// 重置操作
		const resetQuery = () => {
			state.queryParams.id = -1;
			state.queryParams.pid = 0;
			state.queryParams.name = undefined;
			state.queryParams.code = undefined;
			handleQuery();
		};
		// 打开新增页面
		const openAddDataRes = () => {
			state.editDataResTitle = '添加数据资源';
			editDataResRef.value.openDialog({ status: 1 });
		};
		// 打开编辑页面
		const openEditDataRes = (row: any) => {
			state.editDataResTitle = '编辑数据资源';
			editDataResRef.value.openDialog(row);
		};
		// 删除
		const delDataRes = (row: any) => {
			ElMessageBox.confirm(`确定删除数据资源：【${row.name}】?`, '提示', {
				confirmButtonText: '确定',
				cancelButtonText: '取消',
				type: 'warning',
			})
				.then(async () => {
					await getAPI(SysDataResourceApi).sysDataResourceDeletePost({ id: row.id });
					ElMessage.success('删除成功');
					mittBus.emit('submitRefresh');
				})
				.catch(() => {});
		};
		// 树组件点击
		const nodeClick = async (node: any) => {
			state.queryParams.id = node.id;
			state.queryParams.pid = node.pid;
			state.queryParams.name = undefined;
			state.queryParams.code = undefined;
			handleQuery();
		};
		return {
			handleQuery,
			resetQuery,
			editDataResRef,
			dataResTreeRef,
			openAddDataRes,
			openEditDataRes,
			delDataRes,
			nodeClick,
			...toRefs(state),
		};
	},
});
</script>
