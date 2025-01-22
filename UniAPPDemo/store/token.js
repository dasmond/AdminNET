import { defineStore } from "pinia";
/**
 * TokenStore 小仓库
 * @description 管理用户的 token 信息
 */
export const TokenStore = defineStore("Token", {
  state: () => ({
    token: "",
    refreshToken: "",
  }),
  actions: {
    /**
     * 保存 token 和 refreshToken
     * @param {string} token - 用户 token
     * @param {string} refreshToken - 刷新 token
     */
    setToken(token, refreshToken) {
      this.token = token;
      this.refreshToken = refreshToken;
    },
    /**
     * 清除 token 信息
     */
    clear() {
      this.token = "";
      this.refreshToken = "";
    },
  },
  getters: {
    /**
     * 获取 token
     * @returns {string} 当前的 token
     */
    getToken() {
      return this.token;
    },
    /**
     * 获取 refreshToken
     * @returns {string} 当前的 refreshToken
     */
    getRefreshToken() {
      return this.refreshToken;
    },
  },
  //持久化
  persist: {
    enabled: true,
    strategies: [
      {
        key: "Token",
        storage: sessionStorage,
      },
    ],
  },
});
