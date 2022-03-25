import { h } from 'vue';
import { BasicColumn, FormSchema } from '/@/components/Table';
import { uploadFile } from '/@/api/sys/admin';
import { getCmsWebsiteDropdown } from '/@/api/main/CmsArticleCategory';
export const columns: BasicColumn[] = [
  {
    title: '名称',
    dataIndex: 'name',
  },
  {
    title: '图像',
    dataIndex: 'picture',
    slots: { customRender: 'picture' },
  },
  {
    title: '描述',
    dataIndex: 'description',
  },
  {
    title: '排序',
    dataIndex: 'orderNo',
  },
  {
    title: '所属站点',
    dataIndex: 'websiteId',
    customRender: ({ record }) => {
      return record.fkWebsiteId.name;
    },
  },
];

export const searchFormSchema: FormSchema[] = [
  {
    label: '父级',
    field: 'pid',
    component: 'Input',
    colProps: { span: 8 },
  },
  {
    label: '名称',
    field: 'name',
    component: 'Input',
    colProps: { span: 8 },
  },
  {
    field: 'websiteId',
    label: '所属站点',
    component: 'ApiSelect',
    colProps: { span: 8 },
    componentProps: {
      api: getCmsWebsiteDropdown,
      labelField: 'label',
      valueField: 'value',
    },
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
    label: '父级',
    field: 'pid',
    component: 'TreeSelect',
    required: false,
  },
  {
    label: '名称',
    field: 'name',
    component: 'Input',
    required: true,
  },
  {
    label: '图像',
    field: 'picture',
    component: 'Upload',
    required: true,
    componentProps: {
      maxNumber: 1,
      api: uploadFile,
    },
  },
  {
    label: '描述',
    field: 'description',
    component: 'Input',
    required: true,
  },
  {
    label: '排序',
    field: 'orderNo',
    component: 'InputNumber',
    required: true,
  },
  {
    label: '所属站点',
    field: 'websiteId',
    component: 'ApiSelect',
    componentProps: {
      api: getCmsWebsiteDropdown,
      labelField: 'label',
      valueField: 'value',
    },
    required: true,
  },
];
