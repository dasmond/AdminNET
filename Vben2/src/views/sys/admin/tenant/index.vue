<template>
  <div>
    <BasicTable @register="registerTable">
      <template #toolbar>
        <a-button type="primary" @click="handleCreate" :disabled="!hasPermission('sysTenant:add')">新增租户</a-button>
      </template>
      <template #action="{ record }">
        <TableAction
          :actions="[
            {
              icon: 'clarity:note-edit-line',
              label: '编辑',
              disabled: !hasPermission('sysTenant:update'),
              onClick: handleEdit.bind(null, record),
            }]"
          :dropDownActions="[
            {
              icon: 'ant-design:menu-outlined',
              label: '授权菜单',
              disabled: !hasPermission('sysTenant:grantMenu'),
              onClick: handleGrantMenu.bind(null, record),
            },
            {
              icon: 'ant-design:database-outlined',
              label: '重置密码',
              disabled: !hasPermission('sysTenant:resetPwd'),
              popConfirm: {
                title: '是否确认重置密码？',
                confirm: handleResetPwd.bind(null, record),
              },
            },
            {
              icon: 'ant-design:delete-outlined',
              color: 'error',
              label: '删除',
              ifShow: hasPermission('sysTenant:delete'),
              popConfirm: {
                title: '是否确认删除？',
                confirm: handleDelete.bind(null, record),
              },
            },
          ]"
        />
      </template>
    </BasicTable>
    <SysTenantModal @register="registerModal" @success="handleSuccess" />
    <GrantMenuDrawer @register="registerGrantMenuDrawer" />
  </div>
</template>
<script lang="ts">
  import { defineComponent } from 'vue';
  import { BasicTable, useTable, TableAction } from '/@/components/Table';
  import { useModal } from '/@/components/Modal';
  import SysTenantModal from './dataModal.vue';
  import { useDrawer } from '/@/components/Drawer';
  import { usePermission } from '/@/hooks/web/usePermission';
  import { columns, searchFormSchema } from './data.data';
  import { useMessage } from '/@/hooks/web/useMessage';
  import { getSysTenantPageList, deleteSysTenant, resetPwd } from '/@/api/sys/tenant';

  import GrantMenuDrawer from './GrantMenuDrawer.vue';
  let searchvalue = undefined;
  export default defineComponent({
     components:{ BasicTable, SysTenantModal, TableAction, GrantMenuDrawer },
    setup() {
      const { createMessage } = useMessage();
      const [registerModal, { openModal }] = useModal();
      const [registerTable, { reload }] = useTable({
        title: '租户列表',
        api: getSysTenantPageList,
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
      const [registerGrantMenuDrawer, { openDrawer: openGrantMenuDrawer }] = useDrawer();
      const { hasPermission } = usePermission();
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
        console.log(record);
        await deleteSysTenant(record.id);
        reload();
        createMessage.success('删除成功！');
      }
      function handleSuccess() {
        reload();
      }
      function handleGrantMenu(record: Recordable) {
        openGrantMenuDrawer(true, { record });
      }
      function handleResetPwd(record: Recordable) {
        resetPwd(record);
        createMessage.success(`已成功重置密码`);
      }
      return {
        registerTable,
        registerModal,
        handleCreate,
        handleEdit,
        handleDelete,
        handleSuccess,
        registerGrantMenuDrawer,
        handleGrantMenu,
        handleResetPwd,
        hasPermission
      };
    },
  });
</script>