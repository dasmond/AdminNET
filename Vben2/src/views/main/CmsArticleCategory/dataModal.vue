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
  import { addCmsArticleCategory, updateCmsArticleCategory } from '/@/api/main/CmsArticleCategory';

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
          if (data.record.picture) {
            setFieldsValue({
              picture: [data.record.pictureAttachment],
            });
          }
        }
      });
      const getTitle = computed(() => (!unref(isUpdate) ? '新增文章分类' : '编辑文章分类'));
      async function handleSubmit() {
        try {
          var values = await validate();
          if (values.picture) {
            values = { ...values, picture: values.picture[0].id };
          }
          setModalProps({ confirmLoading: true });
          if (!unref(isUpdate)) {
            await addCmsArticleCategory(values);
          } else {
            await updateCmsArticleCategory(values);
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
