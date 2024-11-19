<template>
	<el-Tag :type="state.tagType ?? ''">{{ state.label }}</el-Tag>
</template>

<script lang="ts" setup>
import { useUserInfo } from '/@/stores/userInfo';
import { reactive, onMounted, watch } from 'vue';

const props = defineProps({
	code: String,
	value: Object,
	propLabel: {
		type: String,
		default: 'value',
	},
	propValue: {
		type: String,
		default: 'code',
	},
	defaultValue: {
		type: String,
		default: '-',
	},
});

const state = reactive({
	label: '' as string,
	tagType: '' as string,
});

onMounted(() => {
  setDictValue(props.value);
});

watch(
	() => props.value,
	(newValue) => setDictValue(newValue)
);

const setDictValue = (value: any) => {
  const dict = useUserInfo().dictList[props.code]?.find((x: any) => x[props.propValue] == value);
  if (dict) {
    state.label = dict[props.propLabel] || props.defaultValue;
    state.tagType = dict.tagType;
  }
}
</script>
