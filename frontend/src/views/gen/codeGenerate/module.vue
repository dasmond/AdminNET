<template>
  <a-row :gutter="24">
    <a-col :md="5" :sm="24" style="padding: 0 0 0 0;">
      <a-card :bordered="true">
        <a-table
          ref="table"
          size="middle"
          :rowKey="(record) => record.code"
          :pagination="false"
          :defaultExpandAllRows="true"
          :columns="moduleColumns"
          :dataSource="moduleData"
          :loading="loading"
          showPagination="auto"
          :row-selection="{ selectedRowKeys: selectedAppKeys, onChange: onAppSelectChange,type:'radio' }"
          :customRow="click"
        >
          <!--:rowSelection="rowSelectionon"-->

          <span slot="type" slot-scope="text">
            {{ typeFilter(text) }}
          </span>

          <span slot="icon" slot-scope="text">
            <div v-if="text != null && text != ''">
              <a-icon :type="text"/>
            </div>
          </span>
        </a-table>
      </a-card>
    </a-col>
  </a-row>

</template>
<script>
import { STable, Ellipsis } from '@/components'
export default {
    components: {},
    data(){
        return {
            loading: false,
            moduleColumns: [{
                    title: '模块类型',
                    dataIndex: 'name'
            }],
            moduleData: [
                {name:'系统模块',code:'system'},
                {name:'自定义模块',code:'user'}
            ],
            selectedAppKeys: [],
        }
    },
    methods:{
        onAppSelectChange(selectedRowKeys) {
            this.selectedAppKeys = selectedRowKeys
            if (selectedRowKeys.length > 0) {
                // this.queryParam.application = selectedRowKeys[0]
                // getMenuList(this.queryParam).then((res) => {
                //     if (res.success) {
                //         this.data = res.data
                //         this.removeEmptyChildren(this.data)
                //     }
                // }).finally(() => {
                //     this.loading = false
                // })
            }
        },
        click(record, index) {
            return {
                on: {
                    click: () => {
                        const keys = []
                        keys.push(record.code)
                        this.selectedAppKeys = keys
                        this.onAppSelectChange(this.selectedAppKeys)
                    }
                }
            }
        },
        refreshSele() {
            this.onAppSelectChange(this.selectedAppKeys)
        },
        handleOk() {
            this.onAppSelectChange(this.selectedAppKeys)
        },
        typeFilter(type) {
            // eslint-disable-next-line eqeqeq
            const values = this.typeDict.filter(item => item.code == type)
            if (values.length > 0) {
                return values[0].value
            }
        }
    }
}
</script>
<style lang="less">
</style>