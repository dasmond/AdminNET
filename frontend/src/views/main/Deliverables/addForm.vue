<template>
  <a-modal
    title="新增交付物管理"
    :width="900"
    :visible="visible"
    :confirmLoading="confirmLoading"
    @ok="handleSubmit"
    @cancel="handleCancel">
    <a-spin :spinning="confirmLoading">
      <a-form :form="form">
        <a-form-item label="当前月份" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-date-picker style="width: 100%" placeholder="请选择当前月份" v-decorator="['issue',{rules: [{ required: true, message: '请选择当前月份！' }]}]" @change="onChangeissue"/>
        </a-form-item>
        <a-form-item label="所属企业" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入所属企业" v-decorator="['enterprise', {rules: [{required: true, message: '请输入所属企业！'}]}]" />
        </a-form-item>
        <a-form-item label="上传验收单" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入上传验收单" v-decorator="['acceptance']" />
        </a-form-item>
        <a-form-item label="任务" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入任务" v-decorator="['job', {rules: [{required: true, message: '请输入任务！'}]}]" />
        </a-form-item>
        <a-form-item label="状态" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入状态" v-decorator="['state']" />
        </a-form-item>
        <a-form-item label="上传交付物" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入上传交付物" v-decorator="['deliver']" />
        </a-form-item>
        <a-form-item label="创客姓名" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入创客姓名" v-decorator="['fullName', {rules: [{required: true, message: '请输入创客姓名！'}]}]" />
        </a-form-item>
        <a-form-item label="身份证号" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入身份证号" v-decorator="['idCard', {rules: [{required: true, message: '请输入身份证号！'}]}]" />
        </a-form-item>
      </a-form>
    </a-spin>
  </a-modal>
</template>

<script>
  import {
    DeliverablesAdd
  } from '@/api/modular/main/DeliverablesManage'

  export default {
    data () {
      return {
        labelCol: {
          xs: { span: 24 },
          sm: { span: 5 }
        },
        wrapperCol: {
          xs: { span: 24 },
          sm: { span: 15 }
        },
        issueDateString: '',
        visible: false,
        confirmLoading: false,
        form: this.$form.createForm(this)
      }
    },
    methods: {
      // 初始化方法
      add (record) {
        this.visible = true
      },
      /**
       * 提交表单
       */
      handleSubmit () {
        const { form: { validateFields } } = this
        this.confirmLoading = true
        validateFields((errors, values) => {
          if (!errors) {
            for (const key in values) {
              if (typeof (values[key]) === 'object') {
                values[key] = JSON.stringify(values[key])
              }
            }
            values.issue = this.issueDateString
            DeliverablesAdd(values).then((res) => {
              if (res.success) {
                this.$message.success('新增成功')
                this.confirmLoading = false
                this.$emit('ok', values)
                this.handleCancel()
              } else {
                this.$message.error('新增失败：' + JSON.stringify(res.message))
              }
            }).finally((res) => {
              this.confirmLoading = false
            })
          } else {
            this.confirmLoading = false
          }
        })
      },
      onChangeissue(date, dateString) {
        this.issueDateString = dateString
      },
      handleCancel () {
        this.form.resetFields()
        this.visible = false
      }
    }
  }
</script>
