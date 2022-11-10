<template>
	<div class="game-container">
		<el-card shadow="hover" style="margin-top: 8px;">
			<div class="column">
				<el-link :underline="false" class="game_title">喵了个喵</el-link>
				<el-link :underline="false" style="margin: 0 0px 5px 0;" type="success">被关押在喵王国的小猫咪们，打算逃离城堡，
				</el-link>
				<el-link :underline="false" style="margin: 0 0px 5px 0;" type="success">
					但是城堡周围遍布陷阱，小猫咪们只能在你的指引下躲避，快去帮助他们吧！</el-link>
				<el-link :underline="false" style="margin: 0 0px 5px 0;" type="primary">源码地址：
					<el-link type="info">https://store.cocos.com/app/detail/4222
					</el-link>
				</el-link>
			</div>
			<iframe :src="url" :width="gameWidth" :height="gameHeight" frameborder="0"></iframe>
		</el-card>
	</div>
</template>
<script lang="ts">
import { toRefs, reactive,  defineComponent } from 'vue';
import { useUserInfo } from '/@/stores/userInfo';
import { storeToRefs } from 'pinia';
export default defineComponent({
	name: 'testGame',
	components: {},
	setup() {
		const stores = useUserInfo();
		const { userInfos } = storeToRefs(stores);
		const state = reactive({
			loading: false,
			userInfo: userInfos.value,
			url: "/src/assets/game/index.html",
			gameWidth: (document.body.clientHeight - 300) * 0.562,
			gameHeight: document.body.clientHeight - 300
		});
		return {
			...toRefs(state),
		};
	},
});
</script>
<style scoped>
.game_title {
	font-size: 32px;
	font-weight: bolder;
	margin: 0 30px 10px 0;
}

.column {
	display: flex;
	flex-direction: column;
	align-items: flex-start;
}
</style>