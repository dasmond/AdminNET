<template>
  <div>
    <k-form-design
      :showHead="false"
      ref="kfd"
      style="background-color: white;"
      @save="handleSave" />
    <a-modal
      title="保存表单"
      :visible="visible"
      :destroyOnClose="true"
      @ok="handleOk"
      @cancel="handleCancel"
    >
      <a-form :label-col="{ span: 5 }" :wrapper-col="{ span: 12 }">
        <a-form-item label="表单标题">
          <a-input placeholder="请输入表单标题" v-model="formtitle"/>
        </a-form-item>
        <a-form-item label="表单类型">
          <a-select :select="selectformtype" v-model="typeId">
            <a-select-option v-for="item in formtype" :value="item.id" :key="item.id">
              {{ item.value }}</a-select-option>
          </a-select>
        </a-form-item>
      </a-form>
    </a-modal>
  </div>
</template>
<script>
  import 'k-form-design/styles/k-form-design.less'
  import { formAdd } from '@/api/modular/system/formDesignmanage'
  import { sysDictTypeDropDown } from '@/api/modular/system/dictManage'

  export default {
    components: {},
    data() {
      return {
        visible: false,
        formtitle: '',
        jsonData: '',
        typeId: ''
      }
    },
    created() {
      this.getSysDict()
    },
    methods: {
      getSysDict() {
        sysDictTypeDropDown({
          code: 'form_type'
        }).then((res) => {
          this.formtype = res.data
        })
      },
      selectformtype(value) {
      },
      handleSave(values) {
        this.visible = true
        this.jsonData = values
      },
      handleOk() {
        var data = {
          title: this.formtitle,
          formJson: this.jsonData,
          typeId: this.typeId
        }
         formAdd(Object.assign(data)).then(res => {
          if (res.success === true) {
            this.$message.success(res.message)
            this.visible = false
            this.formtitle = ''
            this.$refs.formdesign.handleReset()
          } else {
            this.$message.error(res.message)
          }
        })
      },
      handleCancel() {
        this.visible = false
        this.formtitle = ''
      }
    },
    mounted () {
      // this.importData()
    }
  }
</script>

<style lang="less" scoped>
</style>
