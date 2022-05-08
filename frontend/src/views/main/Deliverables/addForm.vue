<template>
  <a-modal
    title="新增交付物管理"
    :width="900"
    :visible="visible"
    :confirmLoading="confirmLoading"
    @ok="handleSubmit"
    @cancel="handleCancel">
    <a-spin :spinning="confirmLoading">
      <k-form-build ref="kfb" :value="formDesign" />
    </a-spin>
  </a-modal>
</template>

<script>
  import {
    DeliverablesAdd
  } from '@/api/modular/main/DeliverablesManage'
  import 'k-form-design/styles/k-form-design.less'
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
        formDesign: {"list":[{"type":"grid","label":"栅格布局","columns":[{"span":12,"list":[{"type":"input","label":"创客姓名","options":{"type":"text","width":"100%","defaultValue":"","placeholder":"请输入","clearable":false,"maxLength":null,"addonBefore":"","addonAfter":"","hidden":false,"disabled":false},"model":"FullName","key":"input_1651987502608","help":"","rules":[{"required":true,"message":"必填项"}]}]},{"span":12,"list":[{"type":"input","label":"身份证号","options":{"type":"text","width":"100%","defaultValue":"","placeholder":"请输入","clearable":false,"maxLength":null,"addonBefore":"","addonAfter":"","hidden":false,"disabled":false},"model":"IdCard","key":"input_1651987511375","help":"","rules":[{"required":true,"message":"必填项"}]}]}],"options":{"gutter":0},"key":"grid_1651987784432"},{"type":"grid","label":"栅格布局","columns":[{"span":12,"list":[{"type":"select","label":"所属企业","options":{"width":"100%","multiple":false,"disabled":false,"clearable":false,"hidden":false,"placeholder":"请选择","dynamicKey":"","dynamic":false,"options":[{"value":"1","label":"太阳有限公司"},{"value":"2","label":"月亮有限公司"},{"value":"3","label":"星星有限公司"}],"showSearch":true},"model":"Enterprise","key":"select_1651987524560","help":"","rules":[{"required":true,"message":"必填项"}]}]},{"span":12,"list":[{"type":"date","label":"当前月份","options":{"width":"100%","defaultValue":"","rangeDefaultValue":[],"range":false,"showTime":false,"disabled":false,"hidden":false,"clearable":false,"placeholder":"请选择","rangePlaceholder":["开始时间","结束时间"],"format":"YYYY-MM"},"model":"Issue","key":"date_1651987670207","help":"","rules":[{"required":true,"message":"必填项"}]}]}],"options":{"gutter":0},"key":"grid_1651987845406"},{"type":"select","label":"任务","options":{"width":"100%","multiple":false,"disabled":false,"clearable":false,"hidden":false,"placeholder":"请选择","dynamicKey":"","dynamic":false,"options":[{"value":"10001","label":"游戏陪玩"},{"value":"10002","label":"直播"}],"showSearch":false},"model":"Job","key":"select_1651987581814","help":"","rules":[{"required":true,"message":"必填项"}]},{"type":"grid","label":"栅格布局","columns":[{"span":12,"list":[{"type":"uploadFile","label":"上传交付物","options":{"defaultValue":"[]","multiple":false,"disabled":false,"hidden":false,"drag":false,"downloadWay":"a","dynamicFun":"","width":"100%","limit":3,"data":"{}","fileName":"file","headers":{},"action":"http://cdn.kcz66.com/uploadFile.txt","placeholder":"上传"},"model":"Deliver","key":"uploadFile_1651987756772","help":"","rules":[{"required":false,"message":"必填项"}]}]},{"span":12,"list":[{"type":"uploadFile","label":"上传验收单","options":{"defaultValue":"[]","multiple":false,"disabled":false,"hidden":false,"drag":false,"downloadWay":"a","dynamicFun":"","width":"100%","limit":3,"data":"{}","fileName":"file","headers":{},"action":"http://cdn.kcz66.com/uploadFile.txt","placeholder":"上传"},"model":"Acceptance","key":"uploadFile_1651987770805","help":"","rules":[{"required":false,"message":"必填项"}]}]}],"options":{"gutter":0},"key":"grid_1651987865700"},{"type":"radio","label":"状态","options":{"disabled":true,"hidden":true,"defaultValue":"1","dynamicKey":"","dynamic":false,"options":[{"value":"1","label":"待上传"},{"value":"2","label":"已上传"}]},"model":"State","key":"radio_1651987714390","help":"","rules":[{"required":false,"message":"必填项"}]}],"config":{"layout":"horizontal","labelCol":{"xs":4,"sm":4,"md":4,"lg":4,"xl":4,"xxl":4},"labelWidth":100,"labelLayout":"flex","wrapperCol":{"xs":18,"sm":18,"md":18,"lg":18,"xl":18,"xxl":18},"hideRequiredMark":false,"customStyle":""}}
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
        this.$refs.kfb.getData().then(values => {
          let data = { ...values };
            DeliverablesAdd(data).then((res) => {
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
        });
      },
      onChangeissue(date, dateString) {
        this.issueDateString = dateString
      },
      handleCancel () {
        this.$refs.kfb.reset()
        this.visible = false
      }
    }
  }
</script>
