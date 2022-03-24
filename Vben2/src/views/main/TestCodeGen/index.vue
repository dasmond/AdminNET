<template>
  <div>
    <BasicTable @register="registerTable">
      <template #toolbar>
        <a-button type="primary" @click="handleCreate">新增测试生成</a-button>
      </template>
      <template #action="{ record }">
        <TableAction
          :actions="[
            {
              icon: 'clarity:note-edit-line',
              tooltip: '编辑',
              onClick: handleEdit.bind(null, record),
            },
            {
              icon: 'ant-design:delete-outlined',
              color: 'error',
              tooltip: '删除',
              popConfirm: {
                title: '是否确认删除',
                confirm: handleDelete.bind(null, record),
              },
            },
          ]"
        />
      </template> 
    </BasicTable>
    <TestCodeGenModal @register="registerModal" @success="handleSuccess" />
  </div>
</template>
<script lang="ts">
  import { defineComponent } from 'vue';
  import { BasicTable, useTable, TableAction } from '/@/components/Table';
  import { useModal } from '/@/components/Modal';
  import TestCodeGenModal from './dataModal.vue';

  import { columns, searchFormSchema } from './data.data';
  import { useMessage } from '/@/hooks/web/useMessage';
  import { getTestCodeGenPageList, deleteTestCodeGen } from '/@/api/main/TestCodeGen';
  let searchvalue = undefined;
  export default defineComponent({
    components: { BasicTable, TestCodeGenModal, TableAction },
    setup() {
      const { createMessage } = useMessage();
      const [registerModal, { openModal }] = useModal();
      const [registerTable, { reload }] = useTable({
        title: '测试生成列表',
        api: getTestCodeGenPageList,
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
          width: 120,
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
        await deleteTestCodeGen(record);
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
      };
    },
  });
</script>

