<template>
  <div>
    <div ref="chartRef" style="width: 600px; height: 400px;"></div>
  </div>
</template>

<script setup lang="ts">
import { ref, onMounted } from 'vue';
import * as echarts from 'echarts';

interface ChartData {
  xAxis: string[];
  series: number[];
}

const chartRef = ref<HTMLElement | null>(null);

const chartData: ChartData = {
  xAxis: ['周一', '周二', '周三', '周四', '周五', '周六', '周日'],
  series: [22, 24, 20, 25, 27, 23, 26]
};

const initChart = () => {
  if (!chartRef.value) return;
  
  const myChart = echarts.init(chartRef.value);
  const option = {
    title: {
      text: '最近7天上海的温度变化'
    },
    tooltip: {
      trigger: 'axis'
    },
    xAxis: {
      type: 'category',
      data: chartData.xAxis
    },
    yAxis: {
      type: 'value'
    },
    series: [
      {
        name: '温度',
        type: 'line',
        data: chartData.series
      }
    ]
  };
  myChart.setOption(option);
};

onMounted(() => {
  initChart();
});
</script>

<style scoped>
#chart {
  width: 100%;
  height: 400px;
}
</style>
