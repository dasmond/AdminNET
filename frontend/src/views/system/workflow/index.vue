<template>
  <div>
    <x-card v-if="hasPerm('workflowdefinition:page')">
      <div slot="content" class="table-page-search-wrapper">
        <a-form layout="inline">
          <a-row :gutter="48">
            <a-col :md="8" :sm="24">
              <a-form-item label="流程名称">
                <a-input v-model="queryParam.title" allow-clear placeholder="请输入流程名称" />
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
          <template slot="operator" v-if="hasPerm('workflowdefinition:create')">
            <a-button @click="createWorkflow()" icon="plus" type="primary" v-if="hasPerm('workflowdefinition:create')">新增工作流</a-button>
          </template>
          <span slot="action" slot-scope="text, record">
            <a v-if="hasPerm('workflowmanager:start')" @click="startworkflow(record.id,record.version,record.formId)" >发起流程</a>
            <a-divider type="vertical" v-if="hasPerm('workflowmanager:start') & hasPerm('workflowdefinition:edit')" />
            <a v-if="hasPerm('workflowdefinition:edit')" @click="editworkflow(record.id,record.version)" >修改</a>
            <a-divider type="vertical" v-if="hasPerm('workflowdefinition:delete') & hasPerm('workflowdefinition:edit')" />
            <a-popconfirm v-if="hasPerm('workflowdefinition:delete')" placement="topRight" title="确认删除？" @confirm="() => deleteworkflow(record.id)">
              <a>删除</a>
            </a-popconfirm>
          </span>
        </s-table>
      </a-spin>
    </a-card>
    <start-workflow ref="startworkflow"></start-workflow>
  </div>
</template>

<script>
import { STable, XCard } from '@/components'
import { getWorkflowDefinitionList, deleteWorkflowDefinition } from '@/api/modular/system/workflowManage'
import StartWorkflow from './startworkflow.vue'
export default {
  name: 'WorkflowList',
  components: {
    STable,
    XCard,
    StartWorkflow
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
          title: '流程版本',
          dataIndex: 'version'
        },
        {
          title: '创建人',
          dataIndex: 'createdUserName'
        },
        {
          title: '创建时间',
          dataIndex: 'createdTime'
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
        return getWorkflowDefinitionList(Object.assign(parameter, this.queryParam)).then((res) => {
          this.loading = false
          return res.data
        })
      }
    }
  },
  methods: {
    // 新建工作流
    createWorkflow() {
      this.$nextTick(() => {
        this.$router.push({ path: '/workflowmanage/create' })
      })
    },
    // 发起流程
    startworkflow(id, version, formId) {
      if (formId === null) {

      } else {
        this.$refs.startworkflow.init(id, version, formId)
      }
    },
    // 修改流程
    editworkflow(id, version) {
       this.$nextTick(() => {
        this.$router.push({ name: 'sys_workflow_edit', params: { id: id, version: version } })
      })
    },
    // 删除流程
    deleteworkflow(Id) {
      deleteWorkflowDefinition(Object.assign({ Id: Id })).then(res => {
        if (res.success === true) {
          this.$refs.table.refresh(true)
          this.$message.success(res.message)
        } else {
          this.$message.error(res.message)
        }
      })
    }
  }
}
</script>

<style>

</style>
