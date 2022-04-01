<template>
  <div>
    <k-form-design 
      :showHead="false" 
      ref='kfd'
      style="background-color: white;"
      @save="handleSave"  />

    <!-- <k-form-design 
      :showHead="true" 
      title="我是修改后的标题" 
      ref='kfd'
      style="background-color: white;" /> -->

    <!-- <k-form-build :value="jsonData" /> -->
  </div>
</template>
<script>
  import 'k-form-design/styles/k-form-design.less'

  export default {
    components: {},
    data() {
      return {
        jsonData: {
          list: [
            {
              type: "select",
              label: "下拉选择器",
              options: {
                width: "100%",
                multiple: false,
                disabled: false,
                clearable: false,
                placeholder: "请选择",
                dynamicKey: "",
                dynamic: false,
                options: [
                  { value: "1", label: "下拉框1" },
                  { value: "2", label: "下拉框2" }
                ],
                filterable: false
              },
              model: "select_1585829530472",
              key: "select_1585829530472",
              rules: [{ required: false, message: "必填项" }]
            },
            {
              type: "radio",
              label: "单选框",
              icon: "icon-danxuan-cuxiantiao",
              options: {
                disabled: false,
                defaultValue: "",
                dynamicKey: "",
                dynamic: false,
                options: [
                  { value: "1", label: "选项1" },
                  { value: "2", label: "选项2" },
                  { value: "3", label: "选项3" }
                ]
              },
              model: "radio_1585829530935",
              key: "radio_1585829530935",
              rules: [{ required: false, message: "必填项" }]
            }
          ],
          config: {
            layout: "horizontal",
            labelCol: { span: 4 },
            wrapperCol: { span: 18 },
            hideRequiredMark: false,
            customStyle: ""
          }
        }
      }
    },
    methods: {
      importData () {
        this.$refs.kfd.handleSetData(this.jsonData)
      },
      handleSave(values) {
        console.log(values);
      }
    },
    mounted () {
      // this.importData()
    }
  }
</script>

<style lang="less" scoped>
</style>
