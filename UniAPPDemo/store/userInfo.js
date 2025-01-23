import { defineStore } from "pinia";
import { getImageUrl } from "@/utils/image.js";

/**
 * UserInfoStore 小仓库
 * @description 管理用户信息
 */
export const UserInfoStore = defineStore("userInfo", {
  state: () => ({
    userInfo: null,
  }),
  getters: {
    /**
     * 获取处理后的用户信息
     * @returns {Object|null} 用户信息对象或 null
     */
    getUserInfo: (state) => {
      if (!state.userInfo) return null;

      return {
        ...state.userInfo,
        avatar: getImageUrl(state.userInfo.avatar, "/static/avatar.png"),
      };
    },
  },
  actions: {
    /**
     * 设置用户信息
     * @param {Object|null} data - 用户信息对象或 null
     */
    setUserInfo(data) {
      this.userInfo = data || null;
    },
    /**
     * 清除用户信息
     */
    clearUserInfo() {
      this.userInfo = null;
    },
  },
  persist: {
    enabled: true,
    strategies: [
      {
        key: "userInfo",
        storage: localStorage,
      },
    ],
  },
});
