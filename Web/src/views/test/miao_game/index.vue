<template>
	<div class="game-container">
		<el-card shadow="hover" :body-style="{ paddingBottom: '0' }">
			<el-form ref="queryForm" :inline="true">
				<el-form-item>
					<el-button type="primary" icon="ele-Search" @click="handleQuery"> 查询 </el-button>

				</el-form-item>
			</el-form>
		</el-card>
		<el-card shadow="hover" style="margin-top: 8px">
			<iframe :src="url" frameborder="0"></iframe>
		</el-card>
	</div>
</template>
<script lang="ts">
import { toRefs, reactive, onMounted, ref, defineComponent, onUnmounted, getCurrentInstance } from 'vue';
import { ElMessageBox } from 'element-plus';
import { getAPI } from '/@/utils/axios-utils';
export default defineComponent({
	name: 'testGame',
	components: {},
	setup() {
		const { proxy } = getCurrentInstance() as any;
		const state = reactive({
			loading: false,
			url: import.meta.env.VITE_URL + import.meta.env.VITE_PORT + "/src/assets/game/index.html"
		});
		onMounted(async () => {
			handleQuery();

			proxy.mittBus.on('submitRefresh', () => {
				handleQuery();
			});
		});
		onUnmounted(() => {
			proxy.mittBus.off('submitRefresh');
		});
		// 查询操作
		const handleQuery = async () => {
			state.loading = true;

			state.loading = false;
		};
		return {
			handleQuery,
			...toRefs(state),
		};
	},
});
</script>