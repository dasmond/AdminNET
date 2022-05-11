<template>
  <a-modal
    title="发起流程"
    :visible="visible"
    width="1000px"
    :destroyOnClose="true"
    @ok="handleOk"
    @cancel="handleCancel">
    <k-form-build ref="kfb" :value="jsonData" />
  </a-modal>
</template>

<script>
import 'k-form-design/styles/k-form-design.less'
import { formEntity } from '@/api/modular/system/formDesignmanage'
import { startWorkflow } from '@/api/modular/system/workflowManage'
export default {
  name: 'StartWorkflow',
  components: {
    porpsWorkflowDefinitionId: {
      type: Number,
      default: null
    },
    porpsVersion: {
      type: Number,
      default: null
    },
    porpsFormId: {
      type: Number,
      default: null
    }
  },
  data() {
    return {
      visible: false,
      workflowdefinitionId: null,
      version: null,
      jsonData: {}
    }
  },
  methods: {
    // 初始化
    init(workflowdefinitionid, version, formId) {
      this.visible = true
      this.workflowdefinitionId = workflowdefinitionid
      this.version = version
      formEntity(Object.assign({ id: formId })).then(res => {
        console.log(res)
        this.jsonData = JSON.parse(res.data.formJson)
      })
    },
    // 提交
    handleOk() {
      this.$refs.kfb.getData().then(values => {
        console.log('验证通过', values)
        var data = {
          id: this.workflowdefinitionId,
          version: this.version,
          inputs: values
        }
        startWorkflow(data).then(res => {
          console.log(res)
        })
      }).catch(() => {
        console.log('验证未通过，获取失败')
      })
    },
    // 取消
    handleCancel() {
      this.visible = false
    }
  }
}
</script>

<style>

</style>
