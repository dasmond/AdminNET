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
import { ref } from "vue";
import { TabberStore } from "@/store/tabber.js";
import tabBar from "@/config/tabber.config.js";
const tabberStore = TabberStore();
const list = ref(tabBar);
const activeTab = ref(tabberStore.activeTab);

const handleTabbarItemClick = (item, index) => {
  tabberStore.setActive(index);
  // activeTab.value = index
  uni.$route({
    url: item.path,
    type: "tab",
  });
};
</script>

<style></style>
