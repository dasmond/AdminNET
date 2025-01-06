<template>
  <el-menu
    :default-active="activeIndex"
    class="el-menu-vertical-demo"
    @click="handleMenuClick"
  >
    <el-menu-item
      v-for="(option, index) in options"
      :key="index"
      :index="index.toString()"
    >
      {{ option.name }}
    </el-menu-item>
  </el-menu>
</template>

<script setup lang="ts">
import { ref, defineProps } from 'vue';

const props = defineProps<{
  options: Array<{
    name: string;
    action: () => void;
  }>;
}>();

const activeIndex = ref('0');

const handleMenuClick = (index: { index: string }) => {
  const option = props.options[parseInt(index.index)];
  if (option && typeof option.action === 'function') {
    option.action();
  }
};
</script>

<style scoped>
.el-menu-vertical-demo {
  width: 200px;
}
</style>