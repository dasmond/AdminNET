// 导入需要的 Pinia store
import { TokenStore } from "@/store/token.js";
import { UserInfoStore } from "@/store/userInfo.js";
import { TabberStore } from "@/store/tabber.js";

/**
 * 清除所有 Pinia store 的数据并重定向到登录页面
 */
const clearPinia = () => {
  // 清除 token
  TokenStore().$reset();
  // 清除用户信息
  UserInfoStore().$reset();
  // 清除 tabber
  TabberStore().$reset();
  // 重定向到登录页面
  uni.$route({
    url: "/pages/login/login",
    type: "reLaunch",
  });
};

export default clearPinia;
