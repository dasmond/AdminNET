<template>
	<el-Tag :type="state.tagType ?? ''">{{ state.label }}</el-Tag>
</template>

<script lang="ts" setup>
import { useUserInfo } from '/@/stores/userInfo';
import { reactive, onMounted } from 'vue';
import { ElTag } from 'element-plus';

const props = defineProps({
	code: String,
	value: Object,
	propLabel: {
		type: String,
		default: 'name'
	},
	propValue: {
		type: String,
		default: 'value'
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
	const dictList = useUserInfo().getDictDatasByCode(props.code);
	const dict = dictList?.find(x => x[props.propValue] == props.value + "") ?? {};
	if (dict) {
		state.label = dict[props.propLabel] || props.defaultValue;
		state.tagType = dict.tagType;
	}
})
</script>
