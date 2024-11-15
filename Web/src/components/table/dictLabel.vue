<template>
	<el-Tag :type="state.tagType ?? ''">{{ state.label }}</el-Tag>
</template>

<script lang="ts" setup>
import { useUserInfo } from '/@/stores/userInfo';
import { reactive, onMounted } from 'vue';

const props = defineProps({
	code: String,
	value: Object,
	propLabel: {
		type: String,
		default: 'value'
	},
	propValue: {
		type: String,
		default: 'code'
	},
	defaultValue: {
		type: String,
		default: '-'
	},
});

const state = reactive({
  label: '' as string,
  tagType: '' as string
});

onMounted(() => {
	const dict = useUserInfo().dictList[props.code]?.find(x => x[props.propValue] == props.value);
	if (dict) {
		state.label = dict[props.propLabel] || props.defaultValue;
		state.tagType = dict.tagType;
	}
})
</script>
