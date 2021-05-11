<template>
  <div>
    <a-divider>图表</a-divider>
    <a-card title="图表" :bordered="false">
      <a-row>
        <a-col :span="8">
          <div id="myChart_bar" :style="{width: '300px', height: '300px'}"></div>
        </a-col>
        <a-col :span="8">
          <div id="myChart_value" :style="{width: '300px', height: '300px'}"></div>
        </a-col>
        <a-col :span="8">
          <div id="myChart_pie" :style="{width: '300px', height: '300px'}"></div>
        </a-col>
      </a-row>
    </a-card>
    <a-divider>显示序号</a-divider>
    <a-card title="显示序号" :bordered="false">
      <vxe-table :data="tableData">
        <vxe-column type="seq" title="序号" width="60"></vxe-column>
        <vxe-column field="code" title="编码"></vxe-column>
        <vxe-column field="name" title="名称"></vxe-column>
      </vxe-table>
    </a-card>
    <a-divider>固定表头</a-divider>
    <a-card title="固定表头" :bordered="false">
      <vxe-table
        border
        height="400"
        :data="tableData1">
        <vxe-table-column type="seq" width="60"></vxe-table-column>
        <vxe-table-column field="name" title="Name"></vxe-table-column>
        <vxe-table-column field="sex" title="Sex"></vxe-table-column>
        <vxe-table-column field="age" title="Age"></vxe-table-column>
        <vxe-table-column field="address" title="Address" show-overflow></vxe-table-column>
      </vxe-table>
    </a-card>
    <a-divider>固定列</a-divider>
    <a-card title="固定列" :bordered="false">
      <vxe-table
        border="inner"
        show-overflow
        :data="tableData2">
        <vxe-table-column type="seq" width="60" fixed="left"></vxe-table-column>
        <vxe-table-column field="name" title="Name" width="300"></vxe-table-column>
        <vxe-table-column field="role" title="Role" width="300"></vxe-table-column>
        <vxe-table-column field="sex" title="Sex" width="300"></vxe-table-column>
        <vxe-table-column field="date" title="Date" width="300"></vxe-table-column>
        <vxe-table-column field="address" title="Address" fixed="right" width="300"></vxe-table-column>
      </vxe-table>
    </a-card>
  </div>
</template>

<script>
import {
    getBasicTableList
  } from '@/api/modular/tables/table'
export default {
  data () {
    return {
      tableData: [
      ],
      tableData1: [
        { id: 10001, name: 'Test1', role: 'Develop', sex: 'Man', age: 28, address: 'vxe-table 从入门到放弃' },
        { id: 10002, name: 'Test2', role: 'Test', sex: 'Women', age: 22, address: 'Guangzhou' },
        { id: 10003, name: 'Test3', role: 'PM', sex: 'Man', age: 32, address: 'Shanghai' },
        { id: 10004, name: 'Test4', role: 'Designer', sex: 'Women ', age: 23, address: 'vxe-table 从入门到放弃' },
        { id: 10005, name: 'Test5', role: 'Develop', sex: 'Women ', age: 30, address: 'Shanghai' },
        { id: 10006, name: 'Test6', role: 'Designer', sex: 'Women ', age: 21, address: 'vxe-table 从入门到放弃' },
        { id: 10007, name: 'Test7', role: 'Test', sex: 'Man ', age: 29, address: 'vxe-table 从入门到放弃' },
        { id: 10008, name: 'Test8', role: 'Develop', sex: 'Man ', age: 35, address: 'vxe-table 从入门到放弃' }
      ],
      tableData2: [
        { id: 10001, name: 'Test1', role: 'Develop', sex: 'Man', age: 28, address: 'vxe-table 从入门到放弃' },
        { id: 10002, name: 'Test2', role: 'Test', sex: 'Women', age: 22, address: 'Guangzhou' },
        { id: 10003, name: 'Test3', role: 'PM', sex: 'Man', age: 32, address: 'Shanghai' },
        { id: 10004, name: 'Test4', role: 'Designer', sex: 'Women ', age: 24, address: 'Shanghai' }
      ]
    }
  },
  mounted() {
    this.drawBar()
    this.drawValue()
    this.drawPie()
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
    },
    drawBar() {
      // 基于准备好的dom，初始化echarts实例
      var myChart = this.$echarts.init(document.getElementById('myChart_bar'))
      // 绘制图表
      myChart.setOption({
        title: { text: '柱状图' },
        tooltip: {},
        xAxis: {
          data: ['衬衫', '羊毛衫', '雪纺衫', '裤子', '高跟鞋', '袜子']
        },
        yAxis: {},
        series: [{
          name: '销量',
          type: 'bar',
          data: [5, 20, 36, 10, 10, 20]
        }]
      })
    },
    drawValue() {
      // 基于准备好的dom，初始化echarts实例
      var myChart = this.$echarts.init(document.getElementById('myChart_value'))
      // 绘制图表
      myChart.setOption({
        title: { text: '折线图' },
        tooltip: {},
        xAxis: {
        type: 'category',
        data: ['Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat', 'Sun']
        },
        yAxis: {
          type: 'value'
        },
        series: [{
          data: [150, 230, 224, 218, 135, 147, 260],
          type: 'line'
        }]
      })
    },
    drawPie() {
      // 基于准备好的dom，初始化echarts实例
      var myChart = this.$echarts.init(document.getElementById('myChart_pie'))
      // 绘制图表
      myChart.setOption({
        tooltip: {
        trigger: 'item',
        formatter: '{a} <br/>{b}: {c} ({d}%)'
        },
        legend: {
          data: ['直达', '营销广告', '搜索引擎', '邮件营销', '联盟广告', '视频广告', '百度', '谷歌', '必应', '其他']
        },
        series: [
        {
          name: '访问来源',
          type: 'pie',
          selectedMode: 'single',
          radius: [0, '30%'],
          label: {
            position: 'inner',
            fontSize: 14
          },
          labelLine: {
            show: false
          },
          data: [
            { value: 1548, name: '搜索引擎' },
            { value: 775, name: '直达' },
            { value: 679, name: '营销广告', selected: true }
          ]
        },
        {
          name: '访问来源',
          type: 'pie',
          radius: ['45%', '60%'],
          labelLine: {
            length: 30
          },
          label: {
            formatter: '{a|{a}}{abg|}\n{hr|}\n  {b|{b}：}{c}  {per|{d}%}',
            backgroundColor: '#F6F8FC',
            borderColor: '#8C8D8E',
            borderWidth: 1,
            borderRadius: 4,
            rich: {
                a: {
                  color: '#6E7079',
                  lineHeight: 22,
                  align: 'center'
                },
                hr: {
                  borderColor: '#8C8D8E',
                  width: '100%',
                  borderWidth: 1,
                  height: 0
                },
                b: {
                  color: '#4C5058',
                  fontSize: 14,
                  fontWeight: 'bold',
                  lineHeight: 33
                },
                per: {
                  color: '#fff',
                  backgroundColor: '#4C5058',
                  padding: [3, 4],
                  borderRadius: 4
                }
              }
            },
            data: [
              { value: 1048, name: '百度' },
              { value: 335, name: '直达' },
              { value: 310, name: '邮件营销' },
              { value: 251, name: '谷歌' },
              { value: 234, name: '联盟广告' },
              { value: 147, name: '必应' },
              { value: 135, name: '视频广告' },
              { value: 102, name: '其他' }
            ]
          }
        ]
      })
    }
  }
}
</script>
