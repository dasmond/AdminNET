<template>
	<div class="sys-difflog-container">
		<el-card shadow="hover" :body-style="{ paddingBottom: '0' }">
			<el-form :model="state.queryParams" ref="queryForm" :inline="true">
				<el-form-item label="开始时间">
					<el-date-picker v-model="state.queryParams.startTime" type="datetime" placeholder="开始时间" value-format="YYYY-MM-DD HH:mm:ss" :shortcuts="shortcuts" />
				</el-form-item>
				<el-form-item label="结束时间">
					<el-date-picker v-model="state.queryParams.endTime" type="datetime" placeholder="结束时间" value-format="YYYY-MM-DD HH:mm:ss" :shortcuts="shortcuts" />
				</el-form-item>
				<el-form-item>
					<el-button-group>
						<el-button type="primary" icon="ele-Search" @click="handleQuery" v-auth="'sysDifflog:page'"> 查询 </el-button>
						<el-button icon="ele-Refresh" @click="resetQuery"> 重置 </el-button>
					</el-button-group>
				</el-form-item>
			</el-form>
		</el-card>

		<el-card class="full-table" shadow="hover" style="margin-top: 5px">
			<el-table :data="state.logData" style="width: 100%" v-loading="state.loading" border>
        <el-table-column type="expand">
          <template #default="scope">
            <el-card header="差异数据" style="width: 100%; margin: 5px">
              <el-table :data="item.columns" v-for="item in scope.row.diffData" :key="item.tableName" style="width: 100%">
                <el-table-column :label="item.tableName + '-' + item.tableDescription" align="center">
                  <el-table-column prop="columnName" label="字段描述" width="300" :formatter="(row: any) => `${row.columnName} - ${row.columnDescription}`" />
                  <el-table-column prop="beforeValue" label="修改前" />
                  <el-table-column prop="afterValue" label="修改后" />
                </el-table-column>
              </el-table>
            </el-card>
            <el-card header="SQL" style="width: 100%; margin: 5px" class="overflow-text">{{scope.row.sql}}</el-card>
            <el-card header="SQL参数" style="width: 100%; margin: 5px">
              <el-table :data="scope.row.parameters" style="width: 100%"  border>
                <el-table-column prop="parameterName" label="参数名" width="200" />
                <el-table-column prop="typeName" label="类型" width="100" />
                <el-table-column prop="value" label="值" />
              </el-table>
            </el-card>

          </template>
        </el-table-column>
				<el-table-column type="index" label="序号" width="55" align="center" />
				<el-table-column prop="diffType" label="差异操作" header-align="center" show-overflow-tooltip />
				<el-table-column prop="elapsed" label="耗时(ms)" header-align="center" show-overflow-tooltip />
				<el-table-column prop="message" label="日志消息" header-align="center" show-overflow-tooltip />
				<el-table-column prop="businessData" label="业务对象" header-align="center" show-overflow-tooltip />
				<el-table-column prop="createTime" label="操作时间" align="center" show-overflow-tooltip />
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
	</div>
</template>

<script lang="ts" setup name="sysDiffLog">
import { onMounted, reactive } from 'vue';

import { getAPI } from '/@/utils/axios-utils';
import { SysLogDiffApi } from '/@/api-services/api';
import { SysLogDiff } from '/@/api-services/models';

const state = reactive({
	loading: false,
	queryParams: {
		startTime: undefined,
		endTime: undefined,
	},
	tableParams: {
		page: 1,
		pageSize: 50,
		total: 0 as any,
	},
	logData: [] as Array<SysLogDiff>,
});

onMounted(async () => {
	handleQuery();
});

// 查询操作
const handleQuery = async () => {
	if (state.queryParams.startTime == null) state.queryParams.startTime = undefined;
	if (state.queryParams.endTime == null) state.queryParams.endTime = undefined;

	state.loading = true;
	let params = Object.assign(state.queryParams, state.tableParams);
	var res = await getAPI(SysLogDiffApi).apiSysLogDiffPagePost(params);
	state.logData = res.data.result?.items ?? [];
  state.logData.forEach(e => {
    e.diffData = JSON.parse(e.diffData ?? "[]");
    e.parameters = JSON.parse(e.parameters ?? "[]");
  });
	state.tableParams.total = res.data.result?.total;
	state.loading = false;
};

// 重置操作
const resetQuery = () => {
	state.queryParams.startTime = undefined;
	state.queryParams.endTime = undefined;
	handleQuery();
};

// 改变页面容量
const handleSizeChange = (val: number) => {
	state.tableParams.pageSize = val;
	handleQuery();
};

// 改变页码序号
const handleCurrentChange = (val: number) => {
	state.tableParams.page = val;
	handleQuery();
};

const shortcuts = [
	{
		text: '今天',
		value: new Date(),
	},
	{
		text: '昨天',
		value: () => {
			const date = new Date();
			date.setTime(date.getTime() - 3600 * 1000 * 24);
			return date;
		},
	},
	{
		text: '上周',
		value: () => {
			const date = new Date();
			date.setTime(date.getTime() - 3600 * 1000 * 24 * 7);
			return date;
		},
	},
];
</script>

<style lang="scss" scoped>
.el-popper {
	max-width: 60%;
}
:deep(.el-table__expanded-cell) {
  margin-left: 10px !important;
}
.overflow-text {
  max-width: 100%; /* 或者你希望的最大宽度 */
  word-wrap: break-word;
}
</style>
