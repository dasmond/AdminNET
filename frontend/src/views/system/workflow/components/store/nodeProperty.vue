<template>
  <div>
    <a-tabs default-active-key="node" @change="callback" :activeKey="activekey">
      <a-tab-pane key="line" tab="连线" force-render :disabled="!isclickLine">
        <a-form
          ref="connectionForm"
          label-position="top"
          :model="nodecondition"
          style="padding:5px;"
          layout="vertical"
        >
          <a-form-item label="连线标题 :">
            <a-input v-model="nodecondition.label" @change="revalidateConnection"></a-input>
          </a-form-item>
          <a-form-item label="连线类型 :">
            <a-select v-model="nodecondition.type" >
              <a-select-option value="条件">
                条件
              </a-select-option>
            </a-select>
          </a-form-item>
          <a-form-item label="条件 :" v-show="conditionsvisionable">
            <a-row :gutter="5" v-for="item in nodecondition.conditions.filter(item=>(item.costom === false))" :key="item.index" class="itemmarginTop">
              <a-col span="6">
                <a-select v-model="item.field">
                  <a-select-option v-for="iitem in formmodellist" :value="iitem.key" :key="iitem.key" :dropdownMatchSelectWidth="false" dropdownStyle="downstyle">{{
                    iitem.label
                  }}</a-select-option>
                </a-select>
              </a-col>
              <a-col span="4">
                <a-select v-model="item.operator">
                  <a-select-option value=">">{{ '>' }}</a-select-option>
                  <a-select-option value=">=">{{ '&ge;' }}</a-select-option>
                  <a-select-option value="<">{{ '&lt;' }}</a-select-option>
                  <a-select-option value="<=">{{ '&le;' }}</a-select-option>
                  <a-select-option value="!=">{{ '!=' }}</a-select-option>
                  <a-select-option value="==">{{ '==' }}</a-select-option>
                </a-select>
              </a-col>
              <a-col span="6">
                <a-input v-model="item.value" :minlength="1"></a-input>
              </a-col>
              <a-col span="6">
                <a-select v-model="item.type">
                  <a-select-option value="string">{{ 'string' }}</a-select-option>
                  <a-select-option value="bool">{{ 'bool' }}</a-select-option>
                  <a-select-option value="number">{{ 'number' }}</a-select-option>
                </a-select>
              </a-col>
              <a-col span="2">
                <a-button @click="removeCondition(item.index)" icon="delete"></a-button>
              </a-col>
            </a-row>
          </a-form-item>
          <a-form-item>
            <a-row :gutter="5">
              <a-col span="12">
                <a-button type="dashed" long @click="addCondition" icon="plus" v-show="conditionsvisionable">添加条件</a-button>
              </a-col>
            </a-row>
            <a-divider />
            <a-row class="margin-top-10">
              <a-col span="24">
                <a-button type="primary" @click="removeConnection" icon="delete">删除连线</a-button>
              </a-col>
            </a-row>
          </a-form-item>
        </a-form>
      </a-tab-pane>
      <a-tab-pane key="node" tab="节点" :disabled="isclickLine" style="margin-left:-15px">
        <a-form :form="flownode" :label-col="{ span: 8 }" :wrapper-col="{ span: 16 }" @submit="handleSubmitnode">
          <a-form-item label="标识">
            <a-input v-model="flownode.key" :disabled="true"></a-input>
          </a-form-item>
          <a-form-item label="标题">
            <a-input v-model="flownode.title" @change="revalidateNode" :disabled="!flownode.key"></a-input>
          </a-form-item>
          <a-form-item label="执行操作">
            <a-select v-model="flownode.stepBody.displayName" placeholder="" @change="onStepBodyChange" :disabled="!flownode.key">
              <a-select-option v-for="(item, index) in StepBodys" :value="item.name" :key="index">{{
                item.displayName
              }}</a-select-option>
            </a-select>
          </a-form-item>
          <a-form-item label="审核对象：">
            <a-select v-model="flownode.stepBody.inputs.userId.value" v-if="flownode.stepBody.name == 'FixedUserAudit'" @change="onStepBodyUserIDChange">
              <a-select-option v-for="(user, index) in userslist" :value="user.key" :key="index">{{
                user.title
              }}</a-select-option>
            </a-select>
          </a-form-item>
          <a-form-item :wrapper-col="{ span: 17, offset: 5 }">
            <a-button type="primary" @click="removenode" :disabled="!flownode.key">
              删除节点
            </a-button>
          </a-form-item>
        </a-form>
      </a-tab-pane>
    </a-tabs>
  </div>
</template>
<script>
import { getUserList } from '@/api/modular/system/userManage'
import { getAllStepBodyList } from '@/api/modular/system/workflowManage'
import { formEntity } from '@/api/modular/system/formDesignmanage'
export default {
  components: {
  },
  props: {
    // 所有节点
    nodelist: {
      type: Array,
      default: null
    },
     // form表单中的条件value
    formlistsource: {
      type: Array,
      default: null
    },
    // 活动页
    activekey: {
      type: String,
      default: 'node'
    },
    // 是否选中了连线
    isclickLine: {
      type: Boolean,
      default: false
    },
    // 节点属性
    currentNode: {
      type: Object,
      default: null
    },
    // 连线属性
    conditionNode: {
      type: Object,
      default: null
    },
    // 表单Id
    formId: {
      type: Number,
      default: null
    }
  },
  data() {
    return {
      // 所有有用的节点
      nodesListEnable: [],
      conditionsvisionable: true,
      formmodellist: [],
      formmodecostomlist: [],
      formlistdata: [],
      formJson: {},
      UserValue: '',
      FormValue: null,
      PositionValue: '',
      // 选择执行类型
      tempName: '',
      // 用户列表
      userslist: [],
      // 表单字段引入
      nodecondition: {
        label: '',
        type: '条件',
        source: '',
        target: '',
        nodeId: '',
        conditions: []
      },
      labelCol: {
          xs: {
            span: 13
          },
          sm: {
            span: 13
          }
        },
        wrapperCol: {
          xs: {
            span: 10
          },
          sm: {
            span: 7
          }
        },
        labelCol1: {
          xs: {
            span: 10
          },
          sm: {
            span: 8
          }
        },
        wrapperCol1: {
          xs: {
            span: 10
          },
          sm: {
            span: 4
          }
        },
      flownode: {
        key: '',
        title: '',
        icon: '',
        type: '',
        group: '',
        endpointOptions: null,
        stepBody: null,
        parentNodes: null,
        nextNodes: null,
        position: null,
        nextStep: null,
        direction: false
        // backAnyStep: null
      },
      StepBodys: [],
      initStepBody: {
        displayName: '',
        inputs: {
          userId: {
            displayName: '',
            name: '',
            value: null
          }
        },
        name: '',
        stepBodyType:
          ''
      }
    }
  },
 async created() {
    // 初始化
    this.flownode.stepBody = this.initStepBody
    // 查找所有步骤
    await getAllStepBodyList().then(res => {
        if (res.success) {
          res.data.forEach(item => {
          this.StepBodys.push(item)
        })
      }
     })
    if (this.formId != null) {
      formEntity(Object.assign({ id: this.formId })).then(res => {
        this.formmodellist = res.data.nodesList.list
      })
    } else {
      this.$message.warning('流程未绑定表单，无法添加条件！')
    }
      // 查找用户列表
    getUserList().then(res => {
      if (res.success) {
        const mockData = []
        res.data.forEach(item => {
          const data = {
            key: item.id.toString(),
            title: item.name
          }
          mockData.push(data)
        })
        this.userslist = mockData
      }
    })
  },
  watch: {
    nodelist: 'getnodelist',
    formlistsource: 'getformlistsource',
    activekey: 'getactivekey',
    currentNode: 'getcurrentNode',
    conditionNode: 'getconditionNode'
  },
  methods: {
    removenode() {
      this.$emit('deleteNode')
    },
    handleChange(e) {
       this.flownode.form = e
    },
    onStepBodyProcedureIDChange(e) {
      this.flownode.stepBody.inputs.workProcedureId.value = e
    },
    onStepBodyUserIDChange(e) {
      this.flownode.stepBody.inputs.userId.value = e
    },
     onStepBodyChange(value) {
      this.flownode.stepBody = JSON.parse(JSON.stringify(this.StepBodys.filter(u => u.name === value)[0]))
    },
    gettempStepBodyName() {
      this.tempName = ''
    },
    // 删除条件
    removeCondition(index) {
      this.conditionNode.conditions = this.conditionNode.conditions.filter(item => (item.index !== index))
    },
    handleSubmitnode() {},
    getactivekey(curVal, oldVal) {
      this.activekeynow = curVal
    },
    getnodelist(curVal, oldVal) {
      this.nodesListEnable = curVal.filter(i => i.enable === true)
       },
    // getformlistsource(curVal, oldVal) {
    //   this.formmodellist = curVal
    // },
    getcurrentNode(curVal, oldVal) {
      this.flownode = curVal
      if (!this.flownode.stepBody || this.flownode.stepBody.stepBodyType === '') {
        this.initStepBody.displayName = ''
        this.flownode.stepBody = this.initStepBody
      }
    },
    getconditionNode(curVal, oldVal) {
      this.nodecondition = curVal
    },
    revalidateConnection(e) {
      this.$emit('renameConnection', this.conditionNode.label)
    },
    nodenextstep() {
      this.$emit('nextStepConnection', this.flownode.nextStep)
    },
    onChange() {
      this.$emit('directionConnection', this.flownode.direction)
    },
    nodeBackAuto() {
      if (this.flownode.backAutoStep) {
        this.$emit('changeNextNode', null)
      } else { this.$emit('changeNextNode', null) }
      this.$emit('backAutoStep', this.flownode.backAutoStep)
    },
        revalidateNode(e) {
     // this.$emit('renameNode', this.flownode.title)
    },
    savecondition() {
    },
    // 删除
    removeConnection() {
      this.$emit('deleteConnection')
    },
    // 添加条件
    addCondition() {
      var conditions = {
        index: this.conditionNode.conditions.length + 1,
        costom: false,
        field: '',
        operator: '',
        value: '',
        type: ''
      }
      this.conditionNode.conditions.push(conditions)
    },
    handleSelectChange(value) {
      this.form.setFieldsValue({
        note: `Hi, ${value === 'male' ? 'man' : 'lady'}!`
      })
    },
    callback(key) {
          }
  }
}
</script>
<style scoped>
.downstyle {
    width: 200px;
    background-color: blue;
}
.itemmarginTop{
 margin-top: 10px;
}
.itemmarginTopcostom{
   margin-top: 10px;
}
.iteminline{
  display: inline-block;
  width: 200px;
}
.iteminline1{
  display: inline-block;
  width: 140px;
}
.mark{
  width: 5px;
  height: 100%;
  background-color: red;
}
</style>
