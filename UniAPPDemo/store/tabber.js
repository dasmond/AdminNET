import { defineStore } from 'pinia'
 
//创建小仓库
export const TabberStore = defineStore('Tabber', {
  state: () => {
    return {
      activeTab: 0 // 默认选中的索引
    }
  },
  actions: {
    //设置active的值
    setActive(active) {
      this.activeTab = active
    }
  },
  getters: {
    //获取active的值
    getActive() {
      return this.activeTab
    }
  },
  persist: {
    enabled: true,
	  strategies: [
      {
        key: 'Tabber',
        storage: localStorage
      }
    ]
  }
})
