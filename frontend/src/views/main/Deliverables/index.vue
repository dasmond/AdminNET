<template>
  <div>
    <a-card :bordered="false" :bodyStyle="tstyle">

      <div class="table-page-search-wrapper" v-if="hasPerm('Deliverables:page')">
        <a-form layout="inline">
          <a-row :gutter="48"><a-col :md="8" :sm="24">
              <a-form-item label="当前月份">
                <a-date-picker style="width: 100%" placeholder="请选择当前月份" v-model="queryParam.issueDate" @change="onChangeissue"/>
              </a-form-item>
            </a-col>
            <a-col :md="8" :sm="24">
              <a-form-item label="所属企业">
                <a-input v-model="queryParam.enterprise" allow-clear placeholder="请输入所属企业"/>
              </a-form-item>
            </a-col><template v-if="advanced">
              <a-col :md="8" :sm="24">
                <a-form-item label="状态">
                  <a-input v-model="queryParam.state" allow-clear placeholder="请输入状态"/>
                </a-form-item>
              </a-col>
              <a-col :md="8" :sm="24">
                <a-form-item label="创客姓名">
                  <a-input v-model="queryParam.fullName" allow-clear placeholder="请输入创客姓名"/>
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
        <template class="table-operator" slot="operator" v-if="hasPerm('Deliverables:add')" >
          <a-button type="primary" v-if="hasPerm('Deliverables:add')" icon="plus" @click="$refs.addForm.add()">新增交付物管理</a-button>
        </template>
        <span slot="action" slot-scope="text, record">
          <a v-if="hasPerm('Deliverables:edit')" @click="$refs.editForm.edit(record)">编辑</a>
          <a-divider type="vertical" v-if="hasPerm('Deliverables:edit') & hasPerm('Deliverables:delete')"/>
          <a-popconfirm v-if="hasPerm('Deliverables:delete')" placement="topRight" title="确认删除？" @confirm="() => DeliverablesDelete(record)">
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
  import moment from 'moment'
  import { DeliverablesPage, DeliverablesDelete } from '@/api/modular/main/DeliverablesManage'
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
            title: '当前月份',
            align: 'center',
sorter: true,
            dataIndex: 'issue'
          },
          {
            title: '所属企业',
            align: 'center',
sorter: true,
            dataIndex: 'enterprise'
          },
          {
            title: '任务',
            align: 'center',
sorter: true,
            dataIndex: 'job'
          },
          {
            title: '状态',
            align: 'center',
sorter: true,
            dataIndex: 'state'
          },
          {
            title: '创客姓名',
            align: 'center',
sorter: true,
            dataIndex: 'fullName'
          },
          {
            title: '身份证号',
            align: 'center',
sorter: true,
            dataIndex: 'idCard'
          }
        ],
        tstyle: { 'padding-bottom': '0px', 'margin-bottom': '10px' },
        // 加载数据方法 必须为 Promise 对象
        loadData: parameter => {
          return DeliverablesPage(Object.assign(parameter, this.switchingDate())).then((res) => {
            return res.data
          })
        },
        selectedRowKeys: [],
        selectedRows: []
      }
    },
    created () {
      if (this.hasPerm('Deliverables:edit') || this.hasPerm('Deliverables:delete')) {
        this.columns.push({
          title: '操作',
          width: '150px',
          dataIndex: 'action',
          scopedSlots: { customRender: 'action' }
        })
      }
    },
    methods: {
      moment,
      /**
       * 查询参数组装
       */
      switchingDate () {
        const queryParamissue = this.queryParam.issueDate
        if (queryParamissue != null) {
            this.queryParam.issue = moment(queryParamissue).format('YYYY-MM-DD')
            if (queryParamissue.length < 1) {
                delete this.queryParam.issue
            }
        }else
        {
          delete this.queryParam.issue
        }
        const obj = JSON.parse(JSON.stringify(this.queryParam))
        return obj
      },
      DeliverablesDelete (record) {
        DeliverablesDelete(record).then((res) => {
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
      onChangeissue(date, dateString) {
        this.issueDateString = dateString
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
