<template>
  <div>
    <a-card>
      <a-tabs default-active-key="1" force-render>
        <a-tab-pane key="1" tab="我发起的流程">
          <create-workflow></create-workflow>
        </a-tab-pane>
        <a-tab-pane key="2" tab="未审核流程" >
          <un-auditor-workflow></un-auditor-workflow>
        </a-tab-pane>
        <a-tab-pane key="3" tab="已审核流程">
          <auditor-workflow></auditor-workflow>
        </a-tab-pane>
      </a-tabs>
    </a-card>
  </div>
</template>

<script>
import { XCard } from '@/components'
import CreateWorkflow from './create.vue'
import UnAuditorWorkflow from './unauditor.vue'
import AuditorWorkflow from './auditor.vue'
export default {
  name: 'WorkflowList',
  components: {
    XCard,
    CreateWorkflow,
    UnAuditorWorkflow,
    AuditorWorkflow
  },
  data() {
    return {

    }
  },
  methods: {

  }
}
</script>

<style>

</style>
