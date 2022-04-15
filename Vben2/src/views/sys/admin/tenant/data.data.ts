import { h } from 'vue';
import { BasicColumn, FormSchema } from '/@/components/Table';
export const columns: BasicColumn[] = [
  {
    title: '公司名称',
    dataIndex: 'name',
  },
  {
    title: '管理员名称',
    dataIndex: 'adminName',
  },
  {
    title: '电子邮箱',
    dataIndex: 'email',
  },
  {
    title: '电话',
    dataIndex: 'phone',
  },
  {
    title: '备注',
    dataIndex: 'remark',
  },
];

export const searchFormSchema: FormSchema[] = [
  {
    field: 'name',
    label: '公司名称',
    colProps: { span: 8 },
    component: 'Input',
  },
];

export const formSchema: FormSchema[] = [
  {
    label: 'Id',
    field: 'id',
    component: 'Input',
    required: false,
    show: false,
  },
  {
    label: '公司名称',
    field: 'name',
    component: 'Input',
    required: true,
  },
  {
    label: '管理员名称',
    field: 'adminName',
    component: 'Input',
    required: true,
  },  
  {
    label: '电子邮箱',
    field: 'email',
    component: 'Input',
    required: true,
  },
  {
    label: '电话',
    field: 'phone',
    component: 'Input',
    required: false,
  },  
  {
    label: '备注',
    field: 'remark',
    component: 'Input',
    required: false,
  },
];
