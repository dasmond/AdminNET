<template>
  <div>
    <vxe-table :data="tableData">
      <vxe-column type="seq" title="序号" width="60"></vxe-column>
      <vxe-column field="code" title="编码"></vxe-column>
      <vxe-column field="name" title="名称"></vxe-column>
    </vxe-table>
  </div>
</template>

<script>
import {
    getBasicTableList
  } from '@/api/modular/tables/basicTable'
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
     * 获取基本表格数据
     */
    load() {
      getBasicTableList().then((res) => {
        this.tableData = res.data
      }).catch((err) => {
        this.$message.error('获取数据错误：' + err.message)
      })
    }
  }
}
</script>
