<template>
  <div>
    <x-card v-if="hasPerm('formmanager:page')">
      <div slot="content" class="table-page-search-wrapper">
        <a-form layout="inline">
          <a-row :gutter="48">
            <a-col :md="8" :sm="24">
              <a-form-item label="表单名称">
                <a-input v-model="queryParam.title" allow-clear placeholder="请输入表单名称" />
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
          <span slot="publish" slot-scope="text,record">
            <a-switch :defaultChecked="text" @change="(checked)=>{ onChange(checked,record)}"/>
          </span>
          <span slot="action" slot-scope="text,record">
            <a v-if="hasPerm('formmanager:edit')" @click="edit(record.id)">修改</a>
            <a-divider type="vertical" v-if="hasPerm('formmanager:delete') & hasPerm('formmanager:edit')" />
            <a-popconfirm v-if="hasPerm('formmanager:delete')" placement="topRight" title="确认删除？" @confirm="() => deleteform(record.id)">
              <a>删除</a>
            </a-popconfirm>
          </span>
        </s-table>
      </a-spin>
    </a-card>
  </div>
</template>

<script>
import { STable, XCard } from '@/components'
import { formList, formPublish, formDelete } from '@/api/modular/system/formDesignmanage'
export default {
  name: 'FormDesignList',
  components: {
    STable,
    XCard
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
          title: '表单类型',
          dataIndex: 'typeName'
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
          title: '是否发布',
          dataIndex: 'publish',
          scopedSlots: {
            customRender: 'publish'
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
        return formList(Object.assign(parameter, this.queryParam)).then(res => {
          this.loading = false
          return res.data
        })
      }
    }
  },
  methods: {
    // 发布表单
    onChange(checked, record) {
      var id = record.id
      formPublish(Object.assign({ Id: id, publish: checked })).then(res => {
          if (res.success === true) {
            this.$message.success(res.message)
          } else {
            this.$message.error(res.message)
          }
      })
    },
    // 修改表单
    edit(Id) {
      this.$router.push({ path: '/formDesign/edit', query: { Id: Id } })
    },
    // 删除表单
    deleteform(Id) {
      formDelete(Object.assign({ 'Id': Id })).then(res => {
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
