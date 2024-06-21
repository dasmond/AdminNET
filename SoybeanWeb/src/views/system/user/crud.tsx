
import { dict } from '@fast-crud/fast-crud';
import { shallowRef, ref } from 'vue';
import { NEllipsis, NAvatar } from 'naive-ui';
import { getSysUserPage, addSysUser, editSysUser, delSysUser, getEnumDataByTypeName } from '@/service/api/index';
const loadAccountType = async () => {
    const data = await getEnumDataByTypeName("AccountTypeEnum");
    if (data) {
        return data;
    }
    return [];
};

export default function ({ expose }) {
    const pageRequest = async (query) => {
        query.param = {
            "Field": "id",
            "Order": "id",
            "DescStr": "asc"
        }
        const result = await getSysUserPage(query);
        return result;
    };
    const editRequest = async ({ form, row }: EditReq) => {
        if (form.id == null) {
            form.id = row.id;
        }
        return await editSysUser(form);
    };
    const delRequest = async ({ row }: DelReq) => {
        return await delSysUser(row);
    };
    const addRequest = async ({ form }: AddReq) => {
        return await addSysUser(form);
    };
    const selectedIds = ref([]);
    const onSelectionChange = (changed) => {
        selectedIds.value = changed;
    };
    return {
        selectedIds,
        crudOptions: {
            container: {
                is: 'fs-layout-card'
            },
            form: {
                wrapper: {
                    width: '800px',
                    draggable: false,
                    closeOnEsc: false,
                    maskClosable: false,
                }
            },
            search: {
                show: true,
            },
            actionbar: {
                show: true,
            },
            toolbar: {
                show: true,
                buttons: {
                    search: { show: false },
                    refresh: { show: true },
                    compact: { show: true },
                    export: { show: true },
                    columns: { show: true },
                },
            },
            table: {
                scrollX: 1015,
                bordered: false,
                rowKey: (row) => row.id,
                checkedRowKeys: selectedIds,
                'onUpdate:checkedRowKeys': onSelectionChange,
            },
            pagination: {
                show: true
            },
            request: {
                pageRequest,
                delRequest,
                addRequest,
                editRequest,
                transformQuery: ({ page, form, sort }) => {
                    const order = sort == null ? {} : { orderProp: sort.prop, orderAsc: sort.asc }
                    return { page: page.currentPage, pageSize: page.pageSize, ...form, ...order };
                },
                transformRes: ({ res }) => {
                    const records = res.items;
                    const total = res.total;
                    const currentPage = res.totalPages;
                    const pageSize = res.pageSize;
                    return {
                        currentPage: currentPage, pageSize: pageSize, total: total, records
                    };
                },
            },
            rowHandle: {
                fixed: "right",
                align: "center",
                width: 150,
                buttons: {
                    view: { show: true },
                    edit: { show: true },
                    remove: { show: true },
                }
            },
            columns: {
                _checked: {
                    title: '选择',
                    form: { show: false },
                    column: {
                        type: 'selection',
                        align: 'center',
                        width: '55px',
                        columnSetDisabled: true
                    },
                },
                avatar: {
                    title: '头像',
                    type: 'text',
                    search: { show: false, col: { span: 'auto' } },
                    column: {
                        align: "center",
                        width: '120px',
                        cellRender(scope: ScopeContext) {
                            if (scope.row.avatar !== "") {
                                return <NAvatar round size="large" src={scope.row.avatar}></NAvatar>
                            }
                            else {
                                return <NAvatar round size="large">{scope.row.nickName?.slice(0, 1) ?? scope.row.realName?.slice(0, 1)}</NAvatar>
                            }
                        }
                    },
                    form: {
                        show: false
                    }
                },
                account: {
                    title: '账号',
                    type: 'text',
                    search: { show: true, col: { span: 6 } },
                    column: {
                        align: "center",
                        width: '120px',
                    },
                    form: {
                        col: { span: 12 },
                        rule: [
                            { required: true, message: '请输入账号' }
                        ],
                    }
                },
                realName: {
                    title: '姓名',
                    type: 'text',
                    search: { show: false, col: { span: 'auto' } },
                    column: {
                        align: "center",
                        width: '120px',
                    },
                    form: {
                        col: { span: 12 },
                        rule: [
                            { required: true, message: '请输入姓名' }
                        ],
                    }
                },
                phone: {
                    title: '手机号码',
                    type: 'text',
                    search: { show: true, col: { span: 'auto' } },
                    column: {
                        align: "center",
                        width: '120px',
                    },
                    form: {
                        col: { span: 12 },
                        rule: [
                            { required: true, message: '请输入手机号码' }
                        ],
                    }
                },
                accountType: {
                    title: '账号类型',
                    type: 'dict-select',
                    dict: dict({
                        label: "describe",
                        value: "value",
                        async getData({ dict }) {
                            return await loadAccountType();
                        }
                    }),
                    search: {
                        show: true, col: { span: 4 },
                        component: {
                            clearable: true
                        },
                    },
                    column: {
                        align: "center",
                        width: "150px",
                    },
                    form: {
                        component: {
                            clearable: false,
                            multiple: false,
                        },
                        col: { span: 12 },
                        rule: [
                            { required: true, message: '请选择账号类型' }
                        ]
                    }
                },
                roleName: {
                    title: '角色集合',
                    type: 'text',
                    search: { show: false, col: { span: 'auto' } },
                    column: {
                        align: "center",
                        width: '120px',
                        cellRender(scope: ScopeContext) {
                            return <NEllipsis style="max-width:100px">{scope.value}</NEllipsis>
                        }
                    },
                    form: {
                        col: { span: 12 },
                        rule: [
                            { required: true, message: '请输入账号类型' }
                        ],
                    }
                },
                orgName: {
                    title: '所属机构',
                    type: 'text',
                    search: { show: false, col: { span: 'auto' } },
                    column: {
                        align: "center",
                        width: '120px',
                    },
                    form: {
                        col: { span: 12 },
                        rule: [
                            { required: true, message: '请输入职位名称' }
                        ],
                    }
                },
                posName: {
                    title: '职位名称',
                    type: 'text',
                    search: { show: false, col: { span: 'auto' } },
                    column: {
                        align: "center",
                        width: '120px',
                    },
                    form: {
                        col: { span: 12 },
                        rule: [
                            { required: true, message: '请输入职位名称' }
                        ],
                    }
                },
                orderNo: {
                    title: '排序',
                    type: 'text',
                    search: { show: false, col: { span: 'auto' } },
                    column: {
                        align: "center",
                        width: '120px',
                    },
                    form: {
                        col: { span: 12 },
                        rule: [
                            { required: true, message: '请输入排序' }
                        ],
                    }
                },
                status: {
                    title: '状态',
                    type: 'dict-switch',
                    search: { show: false },
                    column: {
                        align: "center",
                        show: true,
                        width: "120px",
                        component: {
                            name: 'n-switch',
                            checkedValue: 1,
                            uncheckedValue: 2,
                            vModel: 'value',
                            disabled: true
                        },
                        valueChange({ value, row }) {
                            console.log('valueChange', value, row);
                        },
                    },
                    form: {
                        show: false
                    }
                },
            },
        },
    };
}