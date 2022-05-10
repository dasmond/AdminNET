<template>
  <div>
    <x-card v-if="hasPerm('myworkflow:page')">
      <div slot="content" class="table-page-search-wrapper">
        <a-form layout="inline">
          <a-row :gutter="48">
            <a-col :md="8" :sm="24">
              <a-form-item label="流程名称">
                <a-input v-model="queryParam.description" allow-clear placeholder="请输入流程名称" />
              </a-form-item>
            </a-col>
            <a-col :md="8" :sm="24">
              <span class="table-page-search-submitButtons">
                <a-button type="primary" @click="$refs.table.refresh(true)">查询</a-button>
                <a-button style="margin-left: 8px" @click="() => queryParam = {}">重置</a-button>
              </span>
            </a-col>
          </a-row>
        </a-form>
      </div>
    </x-card>
    <a-card :bordered="false">
      <a-spin :spinning="loading">
        <s-table
          ref="table"
          :columns="columns"
          :data="loadData"
          :alert="true"
          :rowKey="(record) => record.id">
          <span slot="status" slot-scope="text">
            <a-tag v-if="text === 0" color="orange">
              {{ '未完成' }}
            </a-tag>
            <a-tag v-if="text === 1" color="blue">
              {{ '暂停' }}
            </a-tag>
            <a-tag v-if="text === 2" color="green">
              {{ '已完成' }}
            </a-tag>
            <a-tag v-if="text === 3" color="red">
              {{ '结束' }}
            </a-tag>
          </span>
          <span slot="createdUserName" slot-scope="text">
            <a-tag color="">
              {{ text }}
            </a-tag>
          </span>
          <span slot="version" slot-scope="text">
            {{ 'V'+text+'.0' }}
          </span>
          <span slot="action" slot-scope="text, record">
            <a v-if="hasPerm('auditorworkflow:view')" @click="viewworkflow(record.id,record.formId)" >查看</a>
            <a-divider type="vertical" v-if="hasPerm('auditorworkflow:delete') & record.status == 0 & hasPerm('auditorworkflow:view')" />
            <a-popconfirm v-if="hasPerm('myworkflow:delete') & record.status == 0" placement="topRight" title="确认删除？" @confirm="() => deleteworkflow(record.id)">
              <a>删除</a>
            </a-popconfirm>
          </span>
        </s-table>
      </a-spin>
    </a-card>
    <view-workflow ref="viewworkflow"></view-workflow>
  </div>
</template>

<script>
import { STable, XCard } from '@/components'
import { getMystartWorkflow } from '@/api/modular/system/auditorworkflowManage'
import ViewWorkflow from './components/viewworkflow.vue'
export default {
  name: 'CreateWorkflow',
  components: {
    STable,
    XCard,
    ViewWorkflow
  },
  data() {
    return {
      queryParam: {},
      loading: true,
      columns: [
        {
          title: '标题',
          dataIndex: 'description'
        },

        {
          title: '创建人',
          dataIndex: 'createdUserName',
          scopedSlots: {
            customRender: 'createdUserName'
          }
        },
        {
          title: '创建时间',
          dataIndex: 'createdTime'
        },
        {
          title: '状态',
          dataIndex: 'status',
          scopedSlots: {
            customRender: 'status'
          }
        },
        {
          title: '完成时间',
          dataIndex: 'completeTime'
        },
        {
          title: '流程版本',
          dataIndex: 'version',
          scopedSlots: {
            customRender: 'version'
          }
        },
        {
          title: '操作',
          dataIndex: 'action',
          scopedSlots: {
            customRender: 'action'
          }
        }
      ],
      // 加载数据方法 必须为 Promise 对象
      loadData: parameter => {
        return getMystartWorkflow(Object.assign(parameter, this.queryParam)).then((res) => {
          this.loading = false
          return res.data
        })
      }
    }
  },
  methods: {
    // 查看流程
    viewworkflow(id, formId) {
      this.$refs.viewworkflow.init(id, '', formId)
    },
    // 删除流程
    deleteworkflow(id) {

    }
  }
}
</script>

<style>

</style>
