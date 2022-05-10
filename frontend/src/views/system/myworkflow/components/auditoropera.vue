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
    <a-skeleton :active="true" :loading="loading" :paragraph="true" :title="true" />
    <k-form-build v-show="loading == false" ref="kfb" :value="jsonData" :disabled="true"/>
    <a-form-model v-show="loading == false" :model="form" :label-col="labelCol" :wrapper-col="wrapperCol">
      <a-form-model-item label="处理">
        <a-radio-group v-model="form.resource">
          <a-radio :value="true" :checked="true">
            同意
          </a-radio>
          <a-radio :value="false">
            不同意
          </a-radio>
        </a-radio-group>
      </a-form-model-item>
      <a-form-model-item label="备注">
        <a-textarea v-model="form.reMark" />
      </a-form-model-item>
    </a-form-model>
    <div
      :style="{
        position: 'absolute',
        right: 0,
        bottom: 0,
        width: '100%',
        borderTop: '1px solid #e9e9e9',
        padding: '10px 16px',
        background: '#fff',
        textAlign: 'right',
        zIndex: 1,
      }"
    >
      <a-button :style="{ marginRight: '8px' }" @click="onClose">
        取消
      </a-button>
      <a-button type="primary" @click="submit()">
        提交
      </a-button>
    </div>
    <time v-show="loading == false" v-for="item in stepAuditor" :key="item.auditorName">
      <a-timeline-item :color="setColor(item.status)">
        <p>{{ item.auditorTime }}</p>
        <p>{{ item.auditorName }}</p>
        <p>{{ item.reMark }}</p>
      </a-timeline-item>
    </time>
  </a-drawer>
</template>

<script>
import 'k-form-design/styles/k-form-design.less'
import { formEntityView } from '@/api/modular/system/formDesignmanage'
import { inputsWorkflow } from '@/api/modular/system/workflowManage'
import { getStepAuditor, auditorWorkflow } from '@/api/modular/system/auditorworkflowManage'
import { Timeline } from 'ant-design-vue'
export default {
  name: 'AuditorOpera',
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
    submit() {
      var data = {
        executionPointerId: this.executionPointerId,
        status: this.form.resource === true ? 1 : 0,
        Remark: this.form.reMark
      }
      auditorWorkflow(Object.assign(data)).then(res => {
        if (res.success === true) {
          this.$message.success('审核成功')
          this.onClose()
        } else {
          this.$message.success(res.message)
        }
      })
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

</style>
