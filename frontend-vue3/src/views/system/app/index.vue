<template>
  <div>
    <BasicTable @register="registerTable">
      <template #action="{ record }">
        <TableAction
          :actions="[
            {
              icon: 'clarity:note-edit-line',
            },
            {
              icon: 'ant-design:delete-outlined',
              color: 'error',
              popConfirm: {
                title: '是否确认删除',
              },
            },
          ]"
        /> </template
    ></BasicTable>
  </div>
</template>

<script lang="ts">
  import { defineComponent } from 'vue';

  import { BasicTable, useTable, TableAction } from '/@/components/Table';
  import { sysAppPage3Post } from '/@/api_base/api/app-api';

  import { columns, searchFormSchema } from './app.data';

  export default defineComponent({
    name: 'AppManagement', // 与路由设置中的name保持一致，页面缓存（openKeepAlive）功能才会生效
    components: { BasicTable, TableAction },
    setup() {
      const [registerTable] = useTable({
        title: '应用列表',
        api: sysAppPage3Post,
        columns,
        formConfig: {
          labelWidth: 120,
          schemas: searchFormSchema,
        },
        useSearchForm: true,
        showTableSetting: true,
        bordered: true,
        showIndexColumn: false,
        actionColumn: {
          width: 80,
          title: '操作',
          dataIndex: 'action',
          slots: { customRender: 'action' },
          fixed: undefined,
        },
      });
      return {
        registerTable,
      };
    },
  });
</script>

<style scoped></style>
