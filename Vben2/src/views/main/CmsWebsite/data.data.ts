import { BasicColumn, FormSchema } from '/@/components/Table';
import { uploadFile } from '/@/api/sys/admin';
export const columns: BasicColumn[] = [
  {
    title: '站点名称',
    dataIndex: 'name',
  },
  {
    title: 'Logo',
    dataIndex: 'logo',
  },
  {
    title: '域名',
    dataIndex: 'domain',
  },
];

export const searchFormSchema: FormSchema[] = [
  {
    label: '站点名称',
    field: 'name',
    component: 'Input',
    colProps: { span: 7 },
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
    label: '站点名称',
    field: 'name',
    component: 'Input',
    required: true,
  },
  {
    label: 'Logo',
    field: 'logo',
    component: 'Upload',
    required: false,
    componentProps: {
      maxNumber: 1,
      api: uploadFile,
    },
  },
  {
    label: '域名',
    field: 'domain',
    component: 'Input',
    required: true,
  },
];
