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
            <a-tag v-if="text === 1" color="green">
              {{ '已完成' }}
            </a-tag>
          </span>
          <span slot="action" slot-scope="text, record">
            <a v-if="hasPerm('auditorworkflow:view')" @click="viewworkflow(record.id,record.version)" >查看</a>
            <a-divider type="vertical" v-if="hasPerm('auditorworkflow:auditor') & record.status == 0 & hasPerm('auditorworkflow:view')" />
            <a v-if="hasPerm('auditorworkflow:auditor')" @click="auditorworkflow(record.workflowId,record.executionPointerId,record.formId)" >审核</a>
          </span>
        </s-table>
      </a-spin>
    </a-card>
    <auditor-opera ref="auditoropera"></auditor-opera>
  </div>
</template>

<script>
import { STable, XCard } from '@/components'
import { getMyUnAuditorWorkflow } from '@/api/modular/system/auditorworkflowManage'
import AuditorOpera from './components/auditoropera.vue'
export default {
  name: 'UnAuditorWorkflow',
  components: {
    STable,
    XCard,
    AuditorOpera
  },
  data() {
    return {
      queryParam: {},
      loading: true,
      columns: [
        {
          title: '标题',
          dataIndex: 'title'
        },

        {
          title: '任务名称',
          dataIndex: 'stepName'
        },
        {
          title: '发起人',
          dataIndex: 'createUserName'
        },
        {
          title: '创建时间',
          dataIndex: 'createTime'
        },
        {
          title: '状态',
          dataIndex: 'status',
          scopedSlots: {
            customRender: 'status'
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
        this.queryParam.status = 0
        return getMyUnAuditorWorkflow(Object.assign(parameter, this.queryParam)).then((res) => {
          this.loading = false
          return res.data
        })
      }
    }
  },
  methods: {
    // 查看流程
    viewworkflow(id, version) {

    },
    // 审核流程
    auditorworkflow(id, executionPointerId, formId) {
      this.$refs.auditoropera.init(id, executionPointerId, formId)
    }
  }
}
</script>

<style>

</style>
