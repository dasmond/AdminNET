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
  import { addCmsWebsite, updateCmsWebsite } from '/@/api/main/CmsWebsite';

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
      const getTitle = computed(() => (!unref(isUpdate) ? '新增站点' : '编辑站点'));
      function getFileId(urls) {
        debugger;
        let arr = urls[0].split('/');
        let str = arr[arr.length - 1];
        let id = str.split('.')[0];
        return id;
      }
      async function handleSubmit() {
        try {
          var values = await validate();
          if (values.logo) {
            values = { ...values, logo: getFileId(values.logo) };
          }
          setModalProps({ confirmLoading: true });
          if (!unref(isUpdate)) {
            await addCmsWebsite(values);
          } else {
            await updateCmsWebsite(values);
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
