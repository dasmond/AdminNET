<template>
  <div id="creatflow">
    <!-- <a-steps :current="currentStepIndex" size="small">
      <a-step v-for="item in steps" :key="item.title" :title="item.title">
        <a-icon slot="icon" :type="item.icon"/></a-step>
    </a-steps> -->
    <div class="steps-content">
      <a-card>
        <div v-if="steps[currentStepIndex].content === 'First-content'" >
          <nomal ref="nomalinfo" @getflownomalinfo="getnomal" :data="flowinfodata"></nomal>
        </div>
      </a-card>
      <div v-if="steps[currentStepIndex].content === 'Last-content'">
        <builder ref="build" :localflow="localflow" :propformId="flowinfodata.formId"></builder>
      </div>
    </div>
    <div>
      <div class="steps-next">
        <a-button icon="caret-down" v-if="currentStepIndex < steps.length - 1" type="primary" @click="next" >
          下一步
        </a-button>
      </div>
      <div class="steps-send">
        <a-button icon="caret-up" v-if="currentStepIndex > 0" type="primary" style="margin-left: 8px" @click="prev">
          上一步
        </a-button>
        <a-button
          style="margin-left: 8px"
          icon="check"
          v-if="currentStepIndex == steps.length - 1 && hasPerm('workFlow:save')"
          type="primary"
          @click="saveworkflow"
        >
          提交
        </a-button>
      </div>
    </div>
  </div>
</template>
<script>
import { addWorkflowDefinition } from '@/api/modular/system/workflowManage'
import nomal from './components/nomalWorkFlow.vue'
import builder from './components/builderWorkFlow.vue'
export default {
  name: 'Creatflow',
  components: {
    nomal,
    builder
    },
  data() {
    return {
      localflow: null,
      workflow: {
       title: '',
       version: '',
       description: '',
       icon: '',
       color: '',
       group: '',
       inputs: null,
       nodes: null,
       formId: ''
     },
      // 基本信息是否达到提交条件
      savecondition: false,
      flowinfodata: {
        icon: null,
        title: null,
        group: null,
        description: null,
        formId: null
      },
      currentStepIndex: 0,
      steps: [
        {
          title: '基本信息',
          content: 'First-content',
          icon: 'credit-card'
        },
        {
          title: '流程设计',
          content: 'Last-content',
          icon: 'apartment'
        }
      ]
    }
  },
  methods: {
    getnomal(success, values) {
      this.flowinfodata = values
      if (success) {
        this.savecondition = true
      } else {
        this.savecondition = false
      }
    },
    async  next() {
      if (this.currentStepIndex === 0) {
        await this.$refs.nomalinfo.getnomalinfo()
      }
      if (this.workflow.nodes) { this.localflow = JSON.parse(this.workflow.nodes) } else { this.localflow = null }
      this.currentStepIndex++
    },
    prev() {
      this.packageflow()
      this.currentStepIndex--
    },
    packageflow() {
      // 得到node
       this.$refs.build.returnnode()
       this.workflow.title = this.flowinfodata.title
       this.workflow.version = this.$refs.build.WorkflowDefinition.version
       this.workflow.description = this.flowinfodata.description
       this.workflow.icon = this.flowinfodata.icon
       this.workflow.color = this.$refs.build.WorkflowDefinition.color
       this.workflow.group = this.flowinfodata.group
       this.workflow.inputs = null
       this.workflow.nodes = JSON.stringify(this.$refs.build.WorkflowDefinition.nodes)
       this.workflow.formId = this.flowinfodata.formId
    },
    saveworkflow() {
      if (this.savecondition) {
      this.packageflow()

      addWorkflowDefinition(Object.assign(this.workflow)).then(res => {
      if (res.success) {
        this.$message.success('提交成功')
        } else {
        this.$message.error('提交失败' + res.message)
        }
     })
     } else {
       this.$message.warning('请完善流程基本信息')
     }
    }
  }
}
</script>
<style scoped>
.steps-content {
  margin-top: 16px;
  border-radius: 6px;
  min-height: 200px;
  text-align: center;
  padding-top: 15px;
}
.steps-next {
  text-align:center;
  margin-top: 24px;
  margin-right: 24px;
}
.steps-send {
  text-align:right;
  margin-top: 24px;
  margin-right: 400px;
}
</style>
