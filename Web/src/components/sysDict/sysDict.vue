<script setup lang="ts">
import {reactive, watch} from "vue";
import { DictItem } from "/@/types/global";
import { useUserInfo } from "/@/stores/userInfo";

const emit = defineEmits(['update:modelValue']);
const dictList = useUserInfo().dictList;
const props = defineProps({
  modelValue: {
    type: [String, Number, Boolean, null],
    required: true
  },
  code: {
    type: String,
    required: true
  },
  propLabel: {
    type: String,
    default: 'label'
  },
  propValue: {
    type: String,
    default: 'value'
  },
  onItemFilter: {
    type: Function,
    default: (dict: any): boolean => dict
  },
  renderAs: {
    type: String,
    default: 'tag',
    validator(value: string) {
      return ['tag', 'select', 'radio'].includes(value);
    }
  }
});

const state = reactive({
  dict: {} as DictItem | undefined,
  dictData: [] as DictItem[],
  value: null as any,
});

const setDictValue = (value: any) => {
  state.value = value;
  state.dictData = dictList[props.code]?.filter(props.onItemFilter) ?? [];
  state.dict = state.dictData.find((x: any) => x[props.propValue] == state.value);
  if (state.dict && !["success", "warning", "info", "primary", "danger"].includes(state.dict.tagType ?? '')) state.dict.tagType = "primary";
}

watch(() => props.modelValue, (newValue) => setDictValue(newValue), { immediate: true });
</script>

<template>
  <!-- 渲染标签 -->
  <template v-if="props.renderAs === 'tag'">
    <el-tag v-if="state.dict" v-bind="$attrs" :type="state.dict.tagType" :style="state.dict.styleSetting" :class="state.dict.classSetting">{{ state.dict[props.propLabel] }}</el-tag>
    <span v-else>{{ state.value }}</span>
  </template>
  <!-- 渲染选择器 -->
  <template v-if="props.renderAs === 'select'">
    <el-select v-model="state.value" v-bind="$attrs" @change="(newValue: any) => emit('update:modelValue', newValue)">
      <el-option :label="item[props.propLabel]" :value="item[props.propValue]" v-for="(item, index) in state.dictData" :key="index" />
    </el-select>
  </template>
  <!-- 渲染单选框 -->
  <template v-if="props.renderAs === 'radio'">
    <el-radio-group v-model="state.value" v-bind="$attrs" @change="(newValue: any) => emit('update:modelValue', newValue)">
      <el-radio :value="item[props.propValue]" v-for="(item, index) in state.dictData" :key="index">{{item[props.propLabel]}}</el-radio>
    </el-radio-group>
  </template>
</template>

<style scoped lang="scss">
</style>