<template>
  <div>
    <BasicTable @register="registerTable">
      <template #toolbar>
        <a-button type="primary" @click="handleCreate">新增文章分类</a-button>
      </template>
      <template #picture="{ text, record }">
        <TableImg
          v-if="text"
          :size="60"
          :simpleShow="true"
          :showBadge="false"
          :imgList="[downUrl + '/' + record.pictureAttachment.id + record.pictureAttachment.suffix]"
        />
      </template>
      <template #action="{ record }">
        <TableAction
          :actions="[
            {
              icon: 'clarity:note-edit-line',
              label: '编辑',
              onClick: handleEdit.bind(null, record),
            },
            {
              icon: 'ant-design:delete-outlined',
              color: 'error',
              label: '删除',
              popConfirm: {
                title: '是否确认删除',
                confirm: handleDelete.bind(null, record),
              },
            },
          ]"
        />
      </template>
    </BasicTable>
    <CmsArticleCategoryModal @register="registerModal" @success="handleSuccess" />
  </div>
</template>
<script lang="ts">
  import { defineComponent } from 'vue';
  import { BasicTable, useTable, TableAction, TableImg } from '/@/components/Table';
  import { useModal } from '/@/components/Modal';
  import CmsArticleCategoryModal from './dataModal.vue';

  import { columns, searchFormSchema } from './data.data';
  import { useMessage } from '/@/hooks/web/useMessage';
  import { getCmsArticleCategoryPageList, deleteCmsArticleCategory } from '/@/api/main/CmsArticleCategory';
  let searchvalue = undefined;
  export default defineComponent({
    components: { BasicTable, CmsArticleCategoryModal, TableAction, TableImg },
    setup() {
      const { createMessage } = useMessage();
      const [registerModal, { openModal }] = useModal();
      const [registerTable, { reload }] = useTable({
        title: '文章分类列表',
        api: getCmsArticleCategoryPageList,
        pagination: true,
        beforeFetch(params) {
          params.searchvalue = searchvalue;
          return params;
        },
        rowKey: 'id',
        columns,
        formConfig: {
          labelWidth: 120,
          schemas: searchFormSchema,
          autoSubmitOnEnter: true,
        },
        useSearchForm: true,
        showTableSetting: true,
        bordered: true,
        canResize: true,
        actionColumn: {
          width: 150,
          title: '操作',
          dataIndex: 'action',
          slots: { customRender: 'action' },
        },
        handleSearchInfoFn(info) {
          searchvalue = info.searchvalue;
          return info;
        },
      });

      function handleCreate() {
        openModal(true, {
          isUpdate: false,
        });
      }

      function handleEdit(record: Recordable) {
        openModal(true, {
          record,
          isUpdate: true,
        });
      }

      async function handleDelete(record: Recordable) {
        await deleteCmsArticleCategory(record);
        reload();
        createMessage.success('删除成功！');
      }
      function handleSuccess() {
        reload();
      }
      return {
        registerTable,
        registerModal,
        handleCreate,
        handleEdit,
        handleDelete,
        handleSuccess,
        downUrl: import.meta.env.VITE_GLOB_DOWNLOAD_URL,
      };
    },
  });
</script>