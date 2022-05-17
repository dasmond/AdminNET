import { TreeItem } from '/@/components/Tree/index';

export const treeData: TreeItem[] = [
  {
    title: 'parent ',
    key: '0-0',
    children: [
      { title: 'leaf', key: '0-0-0' },
      {
        title: 'leaf',
        key: '0-0-1',
        children: [
          { title: 'leaf', key: '0-0-0-0', children: [{ title: 'leaf', key: '0-0-0-0-1' }] },
          { title: 'leaf', key: '0-0-0-1' },
        ],
      },
    ],
  },
  {
    title: 'parent 2',
    key: '1-1',
    children: [
      { title: 'leaf', key: '1-1-0' },
      { title: 'leaf', key: '1-1-1' },
    ],
  },
  {
    title: 'parent 3',
    key: '2-2',
    children: [
      { title: 'leaf', key: '2-2-0' },
      { title: 'leaf', key: '2-2-1' },
    ],
  },
  {
    title: 'parent 4',
    key: '4-2',
    children: [
      { title: 'leaf', key: '4-2-0' },
      { title: 'leaf', key: '4-2-1' },
    ],
  },
  {
    title: 'parent 5',
    key: '2-2',
    children: [
      { title: 'leaf', key: '5-2-0' },
      { title: 'leaf', key: '5-2-1' },
    ],
  },
  {
    title: 'parent 6',
    key: '6-2',
    children: [
      { title: 'leaf', key: '6-2-0' },
      { title: 'leaf', key: '6-2-1' },
    ],
  },
  {
    title: 'parent 7',
    key: '7-2',
    children: [
      { title: 'leaf', key: '7-2-0' },
      { title: 'leaf', key: '7-2-1' },
    ],
  },
  {
    title: 'parent 88888888888888888888888888888888888888888888888888888888888888888888888888888888888888',
    key: '8-2',
    children: [
      { title: 'leaf8888888888888888888888888888888888888888888888888888888888888888888888888888888888', key: '8-2-0' },
      { title: 'leaf888888888888888888888888888888888888888888888888888888888888888888888888888888888888', key: '8-2-1' },
    ],
  },

];

export const treeData2: any[] = [
  {
    name: 'parent ',
    id: '0-0',

    children: [
      { name: 'leaf', id: '0-0-0' },
      {
        name: 'leaf',
        id: '0-0-1',

        children: [
          {
            name: 'leaf',

            id: '0-0-0-0',
            children: [{ name: 'leaf', id: '0-0-0-0-1' }],
          },
          { name: 'leaf', id: '0-0-0-1' },
        ],
      },
    ],
  },
  {
    name: 'parent 2',
    id: '1-1',

    children: [
      { name: 'leaf', id: '1-1-0' },
      { name: 'leaf', id: '1-1-1' },
    ],
  },
  {
    name: 'parent 3',
    id: '2-2',

    children: [
      { name: 'leaf', id: '2-2-0' },
      { name: 'leaf', id: '2-2-1' },
    ],
  },
];

export const treeData3: any[] = [
  {
    name: 'parent ',
    key: '0-0',
    children: [
      { name: 'leaf', key: '0-0-0' },
      {
        name: 'leaf',
        key: '0-0-1',
        children: [
          {
            name: 'leaf',
            key: '0-0-0-0',
            children: [{ name: 'leaf', key: '0-0-0-0-1' }],
          },
          { name: 'leaf', key: '0-0-0-1' },
        ],
      },
    ],
  },
  {
    name: 'parent 2',
    key: '1-1',

    children: [
      { name: 'leaf', key: '1-1-0' },
      { name: 'leaf', key: '1-1-1' },
    ],
  },
  {
    name: 'parent 3',
    key: '2-2',

    children: [
      { name: 'leaf', key: '2-2-0' },
      { name: 'leaf', key: '2-2-1' },
    ],
  },
];
