import { BasicColumn, FormSchema } from '/@/components/Table';
import { h } from 'vue';
import { Tag } from 'ant-design-vue';

// 列配置
export const columns: BasicColumn[] = [
  {
    title: '应用名称',
    dataIndex: 'name',
  },
  {
    title: '唯一编码',
    dataIndex: 'code',
  },
  {
    title: '是否默认',
    dataIndex: 'active',
    customRender: ({ record }) => {
      const enable = record.active === 'Y';
      const color = enable ? 'green' : 'red';
      const text = enable ? '是' : '否';
      return h(Tag, { color: color }, () => text);
    },
  },
  {
    title: '状态',
    dataIndex: 'status',
    customRender: ({ record }) => {
      const enable = record.status === 0;
      const color = enable ? 'green' : 'red';
      const text = enable ? '启用' : '停用';
      return h(Tag, { color: color }, () => text);
    },
  },
  {
    title: '排序',
    dataIndex: 'sort',
  },
];

// 搜索表单
export const searchFormSchema: FormSchema[] = [
  {
    field: 'name',
    label: '应用名称',
    component: 'Input',
    componentProps: {
      placeholder: '请输入应用名称',
    },
    colProps: { span: 8 },
  },
  {
    field: 'code',
    label: '唯一编码',
    component: 'Input',
    componentProps: {
      placeholder: '请输入唯一编码',
    },
    colProps: { span: 8 },
  },
];
