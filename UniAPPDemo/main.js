import {
	createSSRApp
} from "vue";
import App from "./App.vue";
import uviewPlus, {
	route,
	http,
	throttle,
	debounce
} from "uview-plus";
import * as Pinia from "pinia";
import piniaPersist from "pinia-plugin-persist-uni";

import {
	setRequestConfig
} from '@/http/request.js';

// 引入组件

export function createApp() {
	const app = createSSRApp(App);
	// 引入组件

	app.use(uviewPlus);
	// 1.创建pinia的实例
	const pinia = Pinia.createPinia();
	pinia.use(piniaPersist);
	app.use(pinia);
	setRequestConfig(app);
	return {
		app,
		Pinia, // 2.必须导出Pinia
	};
}

uni.$showMsg = function(title = '获取数据失败！', duration = 1500, type = 'success') {
	uni.$u.toast(title)
};
uni.$loading = function(title = '加载中...') {
	uni.showLoading({
		title,
		mask: true,
	})
}
uni.$route = route;
uni.$http = http;
uni.$throttle = throttle;
uni.$debounce = debounce;