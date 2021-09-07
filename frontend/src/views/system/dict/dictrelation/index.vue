<template>
  <a-modal
    :title="'类型 [' + dictType.name + '] 值 [' + dictData.value + '] 的关联管理'"
    :width="900"
    :visible="visible"
    :footer="null"
    @cancel="handleCancel"
  >
    <x-card v-if="hasPerm('sysDictData:page')">
      <div slot="content" class="table-page-search-wrapper" >
        <a-form layout="inline">
          <a-row :gutter="48">
            <a-col :md="8" :sm="24">
              <a-form-item label="数据类型" >
                <a-select v-model="queryParam.typeId" show-search>
                  <a-select-option v-for="dt in queryTypes" :key="dt.id">
                    {{ dt.name }}
                  </a-select-option>
                </a-select>
              </a-form-item>
            </a-col>
            <a-col :md="8" :sm="24">
              <a-form-item label="字典值" >
                <a-input v-model="queryParam.dataRelationVal" allow-clear placeholder="请输入字典值"/>
              </a-form-item>
            </a-col>
            <a-col :md="!advanced && 8 || 24" :sm="24">
              <span class="table-page-search-submitButtons" :style="advanced && { float: 'right', overflow: 'hidden' } || {} ">
                <a-button type="primary" @click="$refs.table.refresh(true)">查询</a-button>
                <a-button style="margin-left: 8px" @click="() => queryParam = {}">重置</a-button>
              </span>
            </a-col>
          </a-row>
        </a-form>
      </div>
    </x-card>
    <a-card :bordered="false">
      <s-table
        ref="table"
        :columns="columns"
        :data="loadData"
        :alert="false"
        :rowKey="(record) => record.code"
      >
        <template slot="operator" v-if="hasPerm('sysDictData:add')" >
          <a-form layout="inline">
            <a-form-item label="关联数据">
              <a-select v-model="addParam.typeId" show-search style="width: 150px;padding-left:8px" @change="dictTypeChange">
                <a-select-option v-for="dt in dictTypes" :key="dt.id">
                  {{ dt.name }}
                </a-select-option>
              </a-select>
            </a-form-item>
            <a-form-item>
              <a-select v-model="addParam.dataRelationIds" style="width: auto; min-width: 150px; max-width: 350px" mode="multiple" placeholder="请选择值" >
                <a-select-option v-for="dd in dictDatas" :key="dd.id">
                  {{ dd.name }}
                </a-select-option>
              </a-select>
            </a-form-item>
            <a-form-item>
              <span class="table-page-search-submitButtons">
                <a-button type="primary" @click="addRelation">添加</a-button>
              </span>
            </a-form-item>
          </a-form>
        </template>
        <span slot="action" slot-scope="text, record">
          <a-popconfirm placement="topRight" title="确认删除？" @confirm="() => sysDictRelationDelete(record)">
            <a>删除</a>
          </a-popconfirm>
        </span>
      </s-table>
      <add-form ref="addForm" @ok="handleOk" />
      <edit-form ref="editForm" @ok="handleOk" />
    </a-card>
  </a-modal>
</template>
<script>
  import { STable, XCard } from '@/components'
  import { sysDictRelationPage, sysDictRelationDelete, sysDictRelationAdd } from '@/api/modular/system/dictRelationManage'
  import { sysDictTypeTree } from '@/api/modular/system/dictManage'
  import addForm from './addForm'
  import editForm from './editForm'
  export default {
    components: {
      XCard,
      STable,
      addForm,
      editForm
    },
    data () {
      return {
        // 高级搜索 展开/关闭
        advanced: false,
        // 查询参数
        queryParam: {
          typeId: 0,
          dataRelationVal: ''
        },
        // 表头
        columns: [
          {
            title: '字典值',
            dataIndex: 'dataRelationValue'
          },
          {
            title: '字典类型',
            dataIndex: 'typeName'
          }
        ],
        visible: false,
        dictType: {},
        dictData: {},
        // 加载数据方法 必须为 Promise 对象
        loadData: parameter => {
          return sysDictRelationPage(Object.assign(parameter, this.queryParam)).then((res) => {
            console.log(this.queryParam)
            return res.data
          })
        },
        queryTypes: [], // 搜索框类型下拉
        dictTypes: [], // 添加框类型下拉
        dictDatas: [], // 添加值框字典列表
        // 添加数据的参数
        addParam: {
          dataRelationIds: [],
          typeId: 0,
          dataId: 0
        }
      }
    },
    created () {
      this.loadDictType()
      if (this.hasPerm('sysDictData:edit') || this.hasPerm('sysDictData:delete')) {
        this.columns.push({
          title: '操作',
          width: '150px',
          dataIndex: 'action',
          scopedSlots: { customRender: 'action' }
        })
      }
    },
    methods: {
      // 类型切换关联值下拉
      dictTypeChange(value) {
        for (var item of this.dictTypes) {
          if (item.id === value) {
            this.addParam.dataRelationIds = []
            this.dictDatas = item.children
            break
          }
        }
      },
      // 添加关系方法
      addRelation () {
        sysDictRelationAdd(this.addParam)
        this.$refs.table.refresh()
      },
      // 加载字典类型数据
      loadDictType() {
        sysDictTypeTree().then((res) => {
          this.dictTypes = res.data
          this.dictDatas.push(...this.dictTypes[0].children)
          this.addParam.typeId = this.dictTypes[0].id
          this.queryTypes = []
          this.queryTypes.push({ 'name': '全部类型', 'id': 0 })
          for (var item of res.data) {
            this.queryTypes.push({ 'name': item.name, 'id': item.id })
          }
          this.queryParam.typeId = this.queryTypes[0].id
        })
      },
      // 打开此页面首先加载此方法
      index (record, dtyp) {
        this.visible = true
        this.queryParam.dataId = record.id
        this.dictType = dtyp
        this.dictData = record
        this.addParam.dataId = record.id
        //
        if (this.dictTypes.length > 0) {
          this.addParam.typeId = this.dictTypes[0].id
        }
        if (this.queryTypes.length > 0) {
          this.queryParam.typeId = this.queryTypes[0].id
        }
        this.addParam.dataRelationIds = []
        try {
          this.$refs.table.refresh()
        } catch (e) {
          // 首次进入界面，因表格加载顺序，会抛异常，我们不予理会
        }
      },
      /**
       * 获取字典数据
       */
      handleCancel () {
        this.queryParam = {}
        this.visible = false
      },
      sysDictRelationDelete (record) {
        sysDictRelationDelete(record).then((res) => {
          if (res.success) {
            this.$message.success('删除成功')
            this.$refs.table.refresh()
          } else {
            this.$message.error('删除失败：' + res.message)
          }
        }).catch((err) => {
          this.$message.error('删除错误：' + err.message)
        })
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
