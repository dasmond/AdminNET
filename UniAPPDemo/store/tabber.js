import { defineStore } from "pinia";

/**
 * TabberStore 小仓库
 * @description 管理选项卡的状态
 */
export const TabberStore = defineStore("Tabber", {
  state: () => ({
    activeTab: 0, // 默认选中的索引
  }),
  actions: {
    /**
     * 设置 activeTab 的值
     * @param {number} active - 选中的索引
     */
    setActive(active) {
      this.activeTab = active;
    },
  },
  getters: {
    /**
     * 获取 activeTab 的值
     * @returns {number} 当前选中的索引
     */
    getActive() {
      return this.activeTab;
    },
  },
  persist: {
    enabled: true,
    strategies: [
      {
        key: "Tabber",
        storage: localStorage,
      },
    ],
  },
});
