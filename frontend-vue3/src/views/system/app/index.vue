<template>
  <BasicTable
    @register="registerTable"
  >

    <template #action="{ record, column }">
      <TableAction :actions="createActions(record, column)" />
    </template>
  </BasicTable>
</template>
<script lang="ts">
  import { defineComponent, ref} from 'vue';
  import { Tag } from 'ant-design-vue';
  import { BasicForm, FormSchema } from '/@/components/Form';
  import { BasicTable,
    useTable,
    TableAction,
    BasicColumn,
    ActionItem,
    EditRecordRow} from '/@/components/Table';
  import { useMessage } from '/@/hooks/web/useMessage';
  import {getList,updateData} from './api'

  const columnsData = [
    {
      title: 'ID',
      dataIndex: 'id',
      defaultHidden:true,
      width: '10%',
    },
    {
      title: '应用名称',
      dataIndex: 'name',
      sorter: true,
      editRow: true,
      // 默认必填校验
      editRule: true,
      width: '20%',
    },
    {
      title: '应用编码',
      dataIndex: 'code',
      sorter: true,
      editRow: true,
      // 默认必填校验
      editRule: true,
      width: '20%',
    },
    {
      title: '是否为默认',
      dataIndex: 'active',
      editRow: true,
      // 默认必填校验
      editRule: true,
      editComponent: 'Select',
      editComponentProps: {
        options: [
          {
            label: '是',
            value: 'Y',
          },
          {
            label: '否',
            value: 'N',
          },
        ],
      },
      width: '10%',
    },
    {
      title: '状态',
      dataIndex: 'status',
      editRow: true,
      slots: { customRender: 'status' },
      editComponent: 'Select',
      editComponentProps: {
        options: [
          {
            label: '开启',
            value: 0,
          },
          {
            label: '关闭',
            value: 1,
          },
        ],
      },
      width: '10%',
    },
    {
      title: '排序',
      dataIndex: 'sort',
      defaultHidden:true,
      width: '10%',
    },
  ];

  const getFormSchemas: FormSchema[] = [
    {
      field: 'name',
      component: 'Input',
      label: '应用名称',
      colProps: {
        span: 8,
      },
      defaultValue: '',
      componentProps: {
        placeholder: '应用名称',
        // onChange: (e: any) => {
        //   console.log(e);
        // },
      },
    },
    {
      field: 'code',
      component: 'Input',
      label: '应用编码',
      colProps: {
        span: 8,
      },
      defaultValue: '',
      componentProps: {
        placeholder: '应用编码',
        // onChange: (e: any) => {
        //   console.log(e);
        // },
      },
    },
  ];

  export default defineComponent({
    name: "SystemApp",
    components: {
      BasicForm,
      BasicTable,
      Tag,
      TableAction,
    },
    setup() {

      const { createMessage } = useMessage();


      const currentEditKeyRef = ref('');


      function handleEdit(record: EditRecordRow) {
        currentEditKeyRef.value = record.key;
        record.onEdit?.(true);
      }

      function handleCancel(record: EditRecordRow) {
        currentEditKeyRef.value = '';
        record.onEdit?.(false, true);
      }

      async function handleSave(record: EditRecordRow) {
        //console.log(record);
        const pass = await record.onEdit?.(false, true);
        if (pass) {
          const res = await updateData(record);
          console.log(res);
          currentEditKeyRef.value = '';
        }

      }

      const [registerTable] = useTable({
        api: getList,
        columns: columnsData,
        canResize: true,
        bordered: true,
        showTableSetting:true,
        actionColumn: {
          width: 160,
          title: '操作',
          dataIndex: 'action',
          slots: { customRender: 'action' },
        },
      });

      function createActions(record: EditRecordRow, column: BasicColumn): ActionItem[] {
        if (!record.editable) {
          return [
            {
              label: '编辑',
              disabled: currentEditKeyRef.value ? currentEditKeyRef.value !== record.key : false,
              onClick: handleEdit.bind(null, record),
            },
          ];
        }
        return [
          {
            label: '保存',
            onClick: handleSave.bind(null, record, column),
          },
          {
            label: '取消',
            popConfirm: {
              title: '是否取消编辑',
              confirm: handleCancel.bind(null, record, column),
            },
          },
        ];
      }

      return {
        getFormSchemas,
        registerTable,
        handleAsDefault,
        handleDelete,
        handleSave,
        handleOpen,
        createActions,
      };

    },
  });
</script>
