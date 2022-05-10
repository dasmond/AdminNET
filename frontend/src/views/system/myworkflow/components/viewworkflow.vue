<template>
  <a-drawer
    title="流程审核"
    placement="right"
    width="1000px"
    :maskClosable="true"
    :destroyOnClose="true"
    :closable="true"
    :visible="visible"
    @close="onClose"
  >
    <a-skeleton :active="true" :loading="loading" :paragraph="true" :title="true" />
    <a-skeleton :active="true" :loading="loading" :paragraph="true" :title="true" />
    <k-form-build v-show="loading == false" ref="kfb" :value="jsonData" :disabled="true"/>
    <a-divider>流程路线</a-divider>
    <a-skeleton :active="true" :loading="loading" :paragraph="true" :title="true" />
    <time v-show="loading == false" v-for="item in stepAuditor" :key="item.stepName">
      <a-timeline-item style="margin-left:100px" :color="setColor(item.status)">
        <p class="title">
          <span >{{ item.stepName }}</span>
          <span style="margin-left:10px">{{ item.auditorTime }}</span>
        </p>
        <p v-if="item.auditorName !== ''">{{ item.auditorName }}</p>
        <p v-if="item.auditorName !== ''">{{ item.reMark }}</p>
      </a-timeline-item>
    </time>
  </a-drawer>
</template>

<script>
import 'k-form-design/styles/k-form-design.less'
import { formEntityView } from '@/api/modular/system/formDesignmanage'
import { inputsWorkflow } from '@/api/modular/system/workflowManage'
import { getStepAuditor } from '@/api/modular/system/auditorworkflowManage'
import { Timeline } from 'ant-design-vue'
export default {
  name: 'ViewWorkflow',
  components: {
    [Timeline.Item.name]: Timeline.Item
  },
  props: {

  },
  data () {
    return {
      visible: false,
      loading: true,
      executionPointerId: null,
      labelCol: { span: 4 },
      wrapperCol: { span: 14 },
      form: {
        reMark: '',
        resource: true
      },
      jsonData: {},
      jsonValue: {},
      stepAuditor: []
    }
  },
  methods: {
    init(id, executionPointerId, formId) {
      this.visible = true
      this.executionPointerId = executionPointerId
      formEntityView(Object.assign({ id: formId })).then(res => {
        this.jsonData = JSON.parse(res.data.formJson) // res.data.nodesList
        inputsWorkflow(Object.assign({ workflowId: id })).then(res => {
          this.loading = false
          this.$refs.kfb.setData(res.data)
        })
      })
      getStepAuditor(Object.assign({ workflowId: id })).then(res => {
        this.stepAuditor = res.data
      })
    },
    setColor(status) {
      if (status === 0) {
        return 'red'
      } else if (status === 1) {
        return 'green'
      } else if (status === 2) {
        return 'orange'
      }
    },
    onClose() {
      this.visible = false
      this.form.reMark = ''
      this.form.resource = true
      this.loading = true
    }
  }
}
</script>

<style>
.title{
  font-weight: bolder;
}
</style>
