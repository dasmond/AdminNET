import { createSSRApp } from "vue";
import App from "./App.vue";
import uviewPlus,{route,} from "uview-plus";
import * as Pinia from "pinia";
import piniaPersist from "pinia-plugin-persist-uni";

export function createApp() {
    const app = createSSRApp(App);

    app.use(uviewPlus);

    // 1.创建pinia的实例
    const pinia = Pinia.createPinia();
    pinia.use(piniaPersist);
    app.use(pinia);

    return {
        app,
        Pinia, // 2.必须导出Pinia
    };
}

uni.$showMsg = function(title = '获取数据失败！', duration = 1500, type = 'success') {
 uni.$u.toast(title)
};
uni.$route = route;