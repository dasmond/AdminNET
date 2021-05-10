<template>
  <div>
    <vxe-table
      stripe
      :data="tableData">
      <vxe-table-column type="seq" title="序号" width="60"></vxe-table-column>
      <vxe-table-column field="name" title="名称"></vxe-table-column>
      <vxe-table-column field="sex" title="性别"></vxe-table-column>
      <vxe-table-column field="age" title="年龄"></vxe-table-column>
      <vxe-table-column field="address" title="地址" show-overflow></vxe-table-column>
    </vxe-table>
  </div>
</template>

<script>
import {
    getStripeTableList
  } from '@/api/modular/tables/table'
export default {
  data () {
    return {
      tableData: [
      ]
    }
  },
  created() {
    this.load()
  },
  methods: {
    /**
     * 获取斑马线表格数据
     */
    load() {
      getStripeTableList().then((res) => {
        this.tableData = res.data
      }).catch((err) => {
        this.$message.error('获取数据错误：' + err.message)
      })
    }
  }
}
</script>
