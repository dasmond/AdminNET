<template>
  <div class="nomalstyle">
    <a-form-model
      ref="ruleForm"
      :model="infodata"
      :label-col="{ span: 5 }"
      :wrapper-col="{ span: 12 }"
      @submit="handleSubmit"
      :rules="rules">
      <a-form-model-item label="标题" prop="title">
        <a-input
          placeholder="请输入标题"
          v-model="infodata.title"
        />
      </a-form-model-item>
      <a-form-model-item label="图标">
        <a-input placeholder="请选择图标" disabled="disabled" v-model="infodata.icon">
          <a-icon slot="addonAfter" @click="openIconSele()" type="setting" />
        </a-input>
      </a-form-model-item>
      <a-form-model-item label="绑定表单">
        <a-select placeholder="请选择表单" v-model="infodata.formId">
          <a-select-option v-for="formDesign in formDataSource" :value="formDesign.id" :key="formDesign.id">
            {{ formDesign.name }}</a-select-option>
        </a-select>
      </a-form-model-item>
      <a-form-model-item label="分组">
        <a-select placeholder="请选择分组" v-model="infodata.group">
          <a-select-option v-for="(group, index) in groupDataSource" :value="group.code" :key="index">
            {{ group.value }}</a-select-option>
        </a-select>
      </a-form-model-item>
      <a-form-model-item label="描述">
        <a-textarea
          v-model="infodata.description"
          placeholder="请填写流程描述"
          :auto-size="{ minRows: 3, maxRows: 5 }"
        />
      </a-form-model-item>
    </a-form-model>
    <a-modal
      :width="850"
      :visible="visibleIcon"
      @cancel="handleCancelIcon"
      footer=""
      :mask="false"
      :closable="false"
      :destroyOnClose="true">
      <icon-selector v-model="currentSelectedIcon" @change="handleIconChange" />
    </a-modal>
  </div>
</template>

<script>
import { sysDictTypeDropDown } from '@/api/modular/system/dictManage'
import { getformList } from '@/api/modular/system/formDesignmanage'
import IconSelector from '@/components/IconSelector'
export default {
  name: 'Nomalflow',
  components: { IconSelector },
   props: {
    // 活动页
    data: {
      type: Object,
      default: null
    }
  },
  data() {
    return {
       rules: {
        title: [{ required: true, message: '请输入标题', trigger: 'change' }]
      },
      // infodata: {
      //   icon: null,
      //   title: null,
      //   group: null,
      //   description: null
      // },
      infodata: this.data,
      nomalinfo: null,
      groupDataSource: [],
      formDataSource: [],
      formLayout: 'horizontal',
      form: this.$form.createForm(this, { name: 'coordinated' }),
      currentSelectedIcon: 'pause-circle',
      visibleIcon: false
    }
  },
  created() {
    this.getSysDict()
    this.getformList()
   },
   activated() {
  },
   mounted() {
  },
  methods: {
   async datainit() {
     await this.form.setFieldsValue({
        icon: this.infodata.icon,
        title: this.infodata.title,
        group: this.infodata.group,
        description: this.infodata.description
      })
    },
    getnomalinfo() {
       this.$refs.ruleForm.validate(valid => {
        if (valid) {
          this.$emit('getflownomalinfo', true, this.infodata)
        } else {
          this.$emit('getflownomalinfo', false, this.infodata)
          return false
        }
      })
    },
    /**
    * 获取字典数据
    */
    getSysDict() {
        sysDictTypeDropDown({
          code: 'workflow_group'
        }).then((res) => {
          this.groupDataSource = res.data
      })
    },
    getformList() {
      getformList().then(res => {
        res.data.forEach(element => {
          var el = { id: element.id, name: element.title }
          this.formDataSource.push(el)
        })
      })
    },
    handleIconChange(icon) {
        this.infodata.icon = icon
        this.visibleIcon = false
      },
    handleSubmit(e) {
      e.preventDefault()
      this.form.validateFields((err, values) => {
        if (!err) {
        }
      })
    },
    handleSelectChange(value) {
      this.form.setFieldsValue({
        note: `Hi, ${value === 'male' ? 'man' : 'lady'}!`
      })
    },
    handleCancelIcon() {
        this.visibleIcon = false
      },
    openIconSele() {
        this.visibleIcon = true
      }
  }
}
</script>

<style scoped>
.nomalstyle{
  margin-top: 100px;
  margin-left: 10%;
  text-align: center;
}
</style>
