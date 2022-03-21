import { BasicColumn } from '/@/components/Table';
import { FormSchema } from '/@/components/Table';
export const columns: BasicColumn[] = [
  {
    title: '字典值',
    dataIndex: 'value',
  },
  {
    title: '唯一编码',
    dataIndex: 'code',
  },
  {
    title: '排序',
    dataIndex: 'order',
    width: 100,
  },
  {
    title: '备注',
    dataIndex: 'remark',
  },
];
export const searchFormSchema: FormSchema[] = [
  {
    field: 'code',
    label: '编码',
    component: 'Input',
    colProps: { span: 8 },
  },
  {
    field: 'value',
    label: '值',
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
    field: 'typeId',
    label: 'typeId',
    required: true,
    component: 'Input',
    show: false,
  },
  {
    field: 'value',
    label: '字典值',
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
];
