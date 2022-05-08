<template>
  <a-modal
    title="编辑租户表"
    :width="900"
    :visible="visible"
    :confirmLoading="confirmLoading"
    @ok="handleSubmit"
    @cancel="handleCancel">
    <a-spin :spinning="confirmLoading">
      <a-form :form="form">
        <a-form-item label="公司名称" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入公司名称" v-decorator="['name']" />
        </a-form-item>
        <a-form-item label="管理员名称" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入管理员名称" v-decorator="['adminName']" />
        </a-form-item>
        <a-form-item label="主机" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入主机" v-decorator="['host']" />
        </a-form-item>
        <a-form-item label="电子邮箱" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入电子邮箱" v-decorator="['email']" />
        </a-form-item>
        <a-form-item label="电话" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入电话" v-decorator="['phone']" />
        </a-form-item>
        <a-form-item label="数据库连接" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入数据库连接" v-decorator="['connection']" />
        </a-form-item>
        <a-form-item label="架构" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入架构" v-decorator="['schema']" />
        </a-form-item>
        <a-form-item label="备注" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入备注" v-decorator="['remark']" />
        </a-form-item>
        <a-form-item v-show="false"><a-input v-decorator="['id']" /></a-form-item>
      </a-form>
    </a-spin>
  </a-modal>
</template>

<script>
  import {
    SysTenantEdit
  } from '@/api/modular/main/SysTenantManage'
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
        record: {},
        visible: false,
        confirmLoading: false,
        form: this.$form.createForm(this)
      }
    },
    methods: {
      // 初始化方法
      edit (record) {
        this.visible = true
        this.record = record
        this.$nextTick(() => {
          this.form.setFieldsValue(
            {
              id: record.id,
              name: record.name,
              adminName: record.adminName,
              host: record.host,
              email: record.email,
              phone: record.phone,
              connection: record.connection,
              schema: record.schema,
              remark: record.remark
            }
          )
        })
      },
      handleSubmit () {
        const { form: { validateFields } } = this
        this.confirmLoading = true
        validateFields((errors, values) => {
          if (!errors) {
            for (const key in values) {
              if (values[key] == null) continue
              if (typeof (values[key]) === 'object') {
                values[key] = JSON.stringify(values[key])
                 this.record[key] = values[key]
              } else {
                 this.record[key] = values[key]
              }
            }
            SysTenantEdit(this.record).then((res) => {
              if (res.success) {
                this.$message.success('编辑成功')
                this.confirmLoading = false
                this.$emit('ok', this.record)
                this.handleCancel()
              } else {
                this.$message.error('编辑失败：' + JSON.stringify(res.message))
              }
            }).finally((res) => {
              this.confirmLoading = false
            })
          }else{
            this.confirmLoading = false
          } 
        });
      },
      handleCancel () {
        this.form.resetFields()
        this.visible = false
      }
    }
  }
</script>
