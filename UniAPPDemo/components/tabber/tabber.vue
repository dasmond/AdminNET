<template>
	<up-tabbar
		:value="activeTab"
		:placeholder="false"
		:border="false"
		:fixed="true"
		:safeAreaInsetBottom="true"
	>
		<up-tabbar-item
		v-for="(item, index) in list"
		:key="index"
		:icon="item.icon"
		:text="item.name"
		@click="handleTabbarItemClick(item, index)"
	></up-tabbar-item>
	</up-tabbar>
</template>

<script setup>
	import { ref } from 'vue';
	import { TabberStore } from '@/store/tabber.js';
	import tabBar from '@/config/tabber.config.js'
	const tabberStore = TabberStore()
	const list = ref(tabBar);
	const activeTab = ref(tabberStore.activeTab);
	
	const handleTabbarItemClick = (item, index) => {
		tabberStore.setActive(index)
		// activeTab.value = index
		uni.$route({
			url: item.path,
			type: 'tab'
		})
	}
	
	//
	import {
		signalR
	} from '@/utils/signalr.js';
	import {
		requestLogout
	} from '@/http/api.js';
	import {
		onLoad
	} from '@dcloudio/uni-app';
	import clearPinia from '@/utils/clearPinia.js'
	onLoad(() => {
		// 强制下线
		signalR.off('ForceOffline');
		signalR.on('ForceOffline', async (data) => {
			console.log('强制下线', data);
			await signalR.stop();
			await requestLogout();
			clearPinia();
		});
	});
</script>

<style>
</style>