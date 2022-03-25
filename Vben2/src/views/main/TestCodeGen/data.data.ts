import { h } from 'vue';
import { BasicColumn, FormSchema } from '/@/components/Table';
import { uploadFile } from '/@/api/sys/admin';
import { getSysUserDropdown } from '/@/api/main/TestCodeGen';
import { Switch } from 'ant-design-vue';
export const columns: BasicColumn[] = [
  {
    title: '图像',
    dataIndex: 'image',
    slots: { customRender: 'image' },
  },
  {
    title: '用户',
    dataIndex: 'user',
    customRender: ({ record }) => {
      return record.fkUser.nickName;
    },
  },
  {
    title: '状态',
    dataIndex: 'status',
    customRender: ({ record }) => {
      return h(Switch, { checked: record.status });
    },
  },
];

export const searchFormSchema: FormSchema[] = [
  {
    field: 'user',
    label: '用户',
    component: 'ApiSelect',
    colProps: { span: 8 },
    componentProps: {
      api: getSysUserDropdown,
      labelField: 'label',
      valueField: 'value',
    },
  },
  {
    label: '状态',
    field: 'status',
    component: 'Input',
    colProps: { span: 8 },
  },
];

export const formSchema: FormSchema[] = [
  {
    label: '主键Id',
    field: 'id',
    component: 'Input',
    required: false,
    show: false,
  },
  {
    label: '图像',
    field: 'image',
    component: 'Upload',
    required: true,
    componentProps: {
      maxNumber: 1,
      api: uploadFile,
    },
  },
  {
    label: '用户',
    field: 'user',
    component: 'ApiSelect',
    componentProps: {
      api: getSysUserDropdown,
      labelField: 'label',
      valueField: 'value',
    },
    required: true,
  },
  {
    label: '状态',
    field: 'status',
    component: 'Switch',
    required: true,
  },
];
