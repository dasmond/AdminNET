<template>
	<view>
		<up-swiper :list="list" previousMargin="30" nextMargin="30" circular :autoplay="true" radius="5" bgColor="#ffffff"></up-swiper>
	</view>
	<tabberVue></tabberVue>
</template>
<script setup>
	import tabberVue from '@/components/tabber/tabber.vue';
	import {
		reactive
	} from 'vue';

	// 使用 reactive 创建响应式数组  
	const list = reactive([
		'https://cdn.uviewui.com/uview/swiper/swiper1.png',
		'https://cdn.uviewui.com/uview/swiper/swiper2.png',
		'https://cdn.uviewui.com/uview/swiper/swiper3.png',
	]);
</script>
<style>

</style>