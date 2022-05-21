<template>
  <div>
    <a-card :bordered="false" :bodyStyle="tstyle">

      <div class="table-page-search-wrapper" v-if="hasPerm('SysTenant:page')">
        <a-form layout="inline">
          <a-row :gutter="48">
            <a-col :md="8" :sm="24">
              <a-form-item label="公司名称">
                <a-input v-model="queryParam.name" allow-clear placeholder="请输入公司名称"/>
              </a-form-item>
            </a-col>
            <a-col :md="8" :sm="24">
              <a-form-item label="管理员名称">
                <a-input v-model="queryParam.adminName" allow-clear placeholder="请输入管理员名称"/>
              </a-form-item>
            </a-col><template v-if="advanced">
              <a-col :md="8" :sm="24">
                <a-form-item label="主机">
                  <a-input v-model="queryParam.host" allow-clear placeholder="请输入主机"/>
                </a-form-item>
              </a-col>
              <a-col :md="8" :sm="24">
                <a-form-item label="电子邮箱">
                  <a-input v-model="queryParam.email" allow-clear placeholder="请输入电子邮箱"/>
                </a-form-item>
              </a-col>
              <a-col :md="8" :sm="24">
                <a-form-item label="电话">
                  <a-input v-model="queryParam.phone" allow-clear placeholder="请输入电话"/>
                </a-form-item>
              </a-col>
              <a-col :md="8" :sm="24">
                <a-form-item label="数据库连接">
                  <a-input v-model="queryParam.connection" allow-clear placeholder="请输入数据库连接"/>
                </a-form-item>
              </a-col>
              <a-col :md="8" :sm="24">
                <a-form-item label="架构">
                  <a-input v-model="queryParam.schema" allow-clear placeholder="请输入架构"/>
                </a-form-item>
              </a-col>
              <a-col :md="8" :sm="24">
                <a-form-item label="备注">
                  <a-input v-model="queryParam.remark" allow-clear placeholder="请输入备注"/>
                </a-form-item>
              </a-col>            </template>

            <a-col :md="8" :sm="24" >
              <span class="table-page-search-submitButtons">
                <a-button type="primary" @click="$refs.table.refresh(true)" >查询</a-button>
                <a-button style="margin-left: 8px" @click="() => queryParam = {}">重置</a-button>
                <a @click="toggleAdvanced" style="margin-left: 8px"> {{ advanced ? '收起' : '展开' }}
                  <a-icon :type="advanced ? 'up' : 'down'"/>
                </a>
              </span>
            </a-col>

          </a-row>
        </a-form>
      </div>
    </a-card>
    <a-card :bordered="false">
      <s-table
        ref="table"
        :columns="columns"
        :data="loadData"
        :alert="true"
        :rowKey="(record) => record.id"
        :rowSelection="{ selectedRowKeys: selectedRowKeys, onChange: onSelectChange }">
        <template class="table-operator" slot="operator" v-if="hasPerm('SysTenant:add')" >
          <a-button type="primary" v-if="hasPerm('SysTenant:add')" icon="plus" @click="$refs.addForm.add()">新增租户表</a-button>
        </template>
        <span slot="action" slot-scope="text, record">
          <a v-if="hasPerm('SysTenant:edit')" @click="$refs.editForm.edit(record)">编辑</a>
          <a-divider type="vertical" v-if="hasPerm('SysTenant:edit') & hasPerm('SysTenant:delete')"/>
          <a-popconfirm v-if="hasPerm('SysTenant:delete')" placement="topRight" title="确认删除？" @confirm="() => SysTenantDelete(record)">
            <a>删除</a>
          </a-popconfirm>
        </span>
      </s-table>
      <add-form ref="addForm" @ok="handleOk" />
      <edit-form ref="editForm" @ok="handleOk" />
    </a-card>
  </div>
</template>
<script>
  import { STable } from '@/components'
  import { SysTenantPage, SysTenantDelete } from '@/api/modular/main/SysTenantManage'
  import addForm from './addForm.vue'
  import editForm from './editForm.vue'
  export default {
    components: {
      STable,
      addForm,
      editForm
    },
    data () {
      return {
        advanced: false, // 高级搜索 展开/关闭
        queryParam: {},
        columns: [
          {
            title: '公司名称',
            align: 'center',
sorter: true,
            dataIndex: 'name'
          },
          {
            title: '管理员名称',
            align: 'center',
sorter: true,
            dataIndex: 'adminName'
          },
          {
            title: '主机',
            align: 'center',
sorter: true,
            dataIndex: 'host'
          },
          {
            title: '电子邮箱',
            align: 'center',
sorter: true,
            dataIndex: 'email'
          },
          {
            title: '电话',
            align: 'center',
sorter: true,
            dataIndex: 'phone'
          },
          {
            title: '数据库连接',
            align: 'center',
sorter: true,
            dataIndex: 'connection'
          },
          {
            title: '架构',
            align: 'center',
sorter: true,
            dataIndex: 'schema'
          },
          {
            title: '备注',
            align: 'center',
sorter: true,
            dataIndex: 'remark'
          }
        ],
        tstyle: { 'padding-bottom': '0px', 'margin-bottom': '10px' },
        // 加载数据方法 必须为 Promise 对象
        loadData: parameter => {
          return SysTenantPage(Object.assign(parameter, this.queryParam)).then((res) => {
            return res.data
          })
        },
        selectedRowKeys: [],
        selectedRows: []
      }
    },
    created () {
      if (this.hasPerm('SysTenant:edit') || this.hasPerm('SysTenant:delete')) {
        this.columns.push({
          title: '操作',
          width: '150px',
          dataIndex: 'action',
          scopedSlots: { customRender: 'action' }
        })
      }
    },
    methods: {
      /**
       * 查询参数组装
       */
      switchingDate () {
        const obj = JSON.parse(JSON.stringify(this.queryParam))
        return obj
      },
      SysTenantDelete (record) {
        SysTenantDelete(record).then((res) => {
          if (res.success) {
            this.$message.success('删除成功')
            this.$refs.table.refresh()
          } else {
            this.$message.error('删除失败') // + res.message
          }
        })
      },
      toggleAdvanced () {
        this.advanced = !this.advanced
      },
      handleOk () {
        this.$refs.table.refresh()
      },
      onSelectChange (selectedRowKeys, selectedRows) {
        this.selectedRowKeys = selectedRowKeys
        this.selectedRows = selectedRows
      }
    }
  }
</script>
<style lang="less">
  .table-operator {
    margin-bottom: 18px;
  }
  button {
    margin-right: 8px;
  }
</style>
