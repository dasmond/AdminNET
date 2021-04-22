<template>
  <a-modal
    title="编辑代码生成业务"
    :width="900"
    :visible="visible"
    :confirmLoading="confirmLoading"
    @ok="handleSubmit"
    @cancel="handleCancel">
    <a-spin :spinning="confirmLoading">
      <a-form :form="form">
        <a-form-item label="名称" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入名称" v-decorator="['name']" />
        </a-form-item>
        <a-form-item label="昵称" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入昵称" v-decorator="['nickName']" />
        </a-form-item>
        <a-form-item label="生日" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-date-picker style="width: 100%" placeholder="请选择生日" v-decorator="['birthday']" @change="onChangebirthday"/>
        </a-form-item>
        <a-form-item label="年龄" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input-number placeholder="请输入年龄" style="width: 100%" v-decorator="['age']" />
        </a-form-item>
        <a-form-item v-show="false"><a-input v-decorator="['id']" /></a-form-item>
      </a-form>
    </a-spin>
  </a-modal>
</template>

<script>
  import moment from 'moment'
  import { CodeGenTestEdit } from '@/api/modular/main/CodeGenTestManage'
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
        birthdayDateString: '',
        visible: false,
        confirmLoading: false,
        form: this.$form.createForm(this)
      }
    },
    methods: {
      moment,
      // 初始化方法
      edit (record) {
        this.visible = true
        setTimeout(() => {
          this.form.setFieldsValue(
            {
              id: record.id,
              name: record.name,
              nickName: record.nickName,
              age: record.age
            }
          )
        }, 100)
        this.form.getFieldDecorator('birthday', { initialValue: moment(record.birthday, 'YYYY-MM-DD') })
        this.birthdayDateString = moment(record.birthday).format('YYYY-MM-DD')
      },
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
            values.birthday = this.birthdayDateString
            CodeGenTestEdit(values).then((res) => {
              if (res.success) {
                this.$message.success('编辑成功')
                this.confirmLoading = false
                this.$emit('ok', values)
                this.handleCancel()
              } else {
                this.$message.error('编辑失败')//  + res.message
              }
            }).finally((res) => {
              this.confirmLoading = false
            })
          } else {
            this.confirmLoading = false
          }
        })
      },
      onChangebirthday(date, dateString) {
        this.birthdayDateString = dateString
      },
      handleCancel () {
        this.form.resetFields()
        this.visible = false
      }
    }
  }
</script>
