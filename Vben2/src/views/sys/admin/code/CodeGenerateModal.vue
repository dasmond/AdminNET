<template>
  <BasicModal
    v-bind="$attrs"
    @register="registerModal"
    showFooter
    :title="getTitle"
    width="40%"
    @ok="handleSubmit"
  >
    <BasicForm @register="registerForm" />
  </BasicModal>
</template>
<script lang="ts">
  import { defineComponent, ref, computed, unref } from 'vue';
  import { BasicForm, useForm } from '/@/components/Form/index';
  import { codeFormSchema } from './codeGenerate.data';
  import { BasicModal, useModalInner } from '/@/components/Modal';

  import { addGenerate, updateGenerate } from '/@/api/sys/admin';
  import { useMessage } from '/@/hooks/web/useMessage';

  export default defineComponent({
    components: { BasicModal, BasicForm },
    emits: ['success', 'register'],
    setup(_, { emit }) {
      const isUpdate = ref(true);
      const { createMessage } = useMessage();
      const [registerForm, { resetFields, setFieldsValue, updateSchema, validate }] = useForm({
        labelWidth: 100,
        schemas: codeFormSchema,
        showActionButtonGroup: false,
        baseColProps: { lg: 12, md: 24 },
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

      const getTitle = computed(() => (!unref(isUpdate) ? '新增' : '编辑'));

      async function handleSubmit() {
        try {
          const values = await validate();
          setModalProps({ confirmLoading: true });
          let ret: any;
          if (!unref(isUpdate)) {
            ret = await addGenerate(values);
          } else {
            ret = await updateGenerate(values);
          }
          if (ret != null) {
            if (ret.code == 204) {
              closeModal();
              createMessage.success('保存成功！');
            } else {
              createMessage.warning(ret.message + ret.message[0].messages);
            }
          } else {
            createMessage.error('未知错误');
          }
          emit('success');
        } finally {
          setModalProps({ confirmLoading: false });
        }
      }

      return { registerModal, registerForm, getTitle, handleSubmit };
    },
  });
</script>
