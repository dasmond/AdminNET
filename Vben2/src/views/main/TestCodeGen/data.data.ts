import { BasicColumn, FormSchema } from '/@/components/Table';
import { uploadFile } from '/@/api/sys/admin';
export const columns: BasicColumn[] = [
  {
    title: '图像',
    dataIndex: 'image',
  },
  {
    title: '用户',
    dataIndex: 'user',
  },
];

export const searchFormSchema: FormSchema[] = [
  {
    label: '图像',
    field: 'image',
    component: 'Input',
    colProps: { span: 8 },
  },
  {
    label: '用户',
    field: 'user',
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
    component: 'fk',
    required: true,
  },
];
