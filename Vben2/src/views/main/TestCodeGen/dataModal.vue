<template>
  <BasicModal v-bind="$attrs" @register="registerModal" :title="getTitle" @ok="handleSubmit">
    <BasicForm @register="registerForm" />
  </BasicModal>
</template>
<script lang="ts">
  import { defineComponent, ref, computed, unref } from 'vue';
  import { BasicModal, useModalInner } from '/@/components/Modal';
  import { BasicForm, useForm } from '/@/components/Form/index';
  import { formSchema } from './data.data';
  import { addTestCodeGen, updateTestCodeGen } from '/@/api/main/TestCodeGen';

  export default defineComponent({
    components: { BasicModal, BasicForm },
    emits: ['success', 'register'],
    setup(_, { emit }) {
      const isUpdate = ref(true);
      const [registerForm, { setFieldsValue, resetFields, validate }] = useForm({
        labelWidth: 100,
        schemas: formSchema,
        showActionButtonGroup: false,
        actionColOptions: {
          span: 23,
        },
        });
      const [registerModal, { setModalProps, closeModal }] = useModalInner(async (data) => {
        resetFields();
        setModalProps({ confirmLoading: false });
        isUpdate.value = !!data?.isUpdate;
        if (unref(isUpdate)) {
          setFieldsValue({
            ...data.record,
          });
        }
      });
      const getTitle = computed(() => (!unref(isUpdate) ? '新增测试生成' : '编辑测试生成'));
      async function handleSubmit() {
        try { 
          const values = await validate();
          setModalProps({ confirmLoading: true });
          if (!unref(isUpdate)) {
            await addTestCodeGen(values);
          } else {
            await updateTestCodeGen(values);
          }
          closeModal();
          emit('success');
          } finally {
            setModalProps({ confirmLoading: false });
          }
        }
      return { registerModal, registerForm, getTitle, handleSubmit };
      },
  });
</script>

