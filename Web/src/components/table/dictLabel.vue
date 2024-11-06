<template>
	<ElTag :type="dict?.tagType ?? ''">{{ dict?.name ?? defaultValue ?? '-' }}</ElTag>
</template>

<script lang="ts" setup>
import { useUserInfo } from '/@/stores/userInfo';
import { reactive } from 'vue';
import { ElTag } from 'element-plus';

const props = defineProps<{
	code: string;
	value: any;
	defaultValue: string
}>();

const dict = reactive(useUserInfo().getDictLabelByVal(props.code, props.value + ""));
</script>
