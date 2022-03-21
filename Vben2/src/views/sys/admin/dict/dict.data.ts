import { BasicColumn } from '/@/components/Table';
import { FormSchema } from '/@/components/Table';
import { h } from 'vue';
import { Tag } from 'ant-design-vue';

export const columns: BasicColumn[] = [
  {
    title: '类型名称',
    dataIndex: 'name',
    align: 'left',
  },
  {
    title: '唯一编码',
    dataIndex: 'code',
  },
  {
    title: '排序',
    dataIndex: 'order',
  },
  {
    title: '备注',
    dataIndex: 'remark',
  },
  {
    title: '状态',
    dataIndex: 'status',
    width: 80,
    customRender: ({ record }) => {
      const status = record.status;
      const enable = status === 1;
      const color = enable ? 'green' : 'red';
      const text = enable ? '正常' : '停用';
      return h(Tag, { color: color }, () => text);
    },
  },
];
export const searchFormSchema: FormSchema[] = [
  {
    field: 'name',
    label: '类型名称',
    component: 'Input',
    colProps: { span: 8 },
  },
  {
    field: 'code',
    label: '唯一编码',
    component: 'Input',
    colProps: { span: 8 },
  },
];
export const formSchema: FormSchema[] = [
  {
    field: 'id',
    label: 'Id',
    required: false,
    component: 'Input',
    show: false,
  },
  {
    field: 'name',
    label: '类型名称',
    required: true,
    component: 'Input',
  },
  {
    field: 'code',
    label: '唯一编码',
    required: true,
    component: 'Input',
  },
  {
    field: 'order',
    label: '排序',
    required: true,
    component: 'Input',
  },
  {
    label: '备注',
    field: 'remark',
    component: 'InputTextArea',
  },
  {
    field: 'status',
    label: '状态',
    component: 'RadioButtonGroup',
    defaultValue: 0,
    componentProps: {
      options: [
        { label: '启用', value: 1 },
        { label: '停用', value: 0 },
      ],
    },
  },
];
