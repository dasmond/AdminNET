<template>
  <div>
    <a-spin :spinning="spinning">
      <h1 class="headertitle">{{ title }}</h1>
      <k-form-design ref="kfd" :showHead="false" :title="title" @save="onSave"/>
    </a-spin>

  </div>
</template>
<script>
  import { formEntity, formEdit } from '@/api/modular/system/formDesignmanage'
  export default {
    components: {},
    data() {
      return {
        spinning: true,
        jsonData: '',
        title: ''
      }
    },
    mounted () {
      formEntity(Object.assign({ Id: this.$route.query.Id })).then(res => {
        if (res.success === true) {
          this.importData(res.data.formJson)
          this.title = res.data.title
          this.spinning = false
        } else {
          this.$message.error(res.message)
        }
      })
    },
    methods: {
      importData (json) {
        this.$refs.kfd.handleSetData(JSON.parse(json))
      },
      onSave(values) {
        var data = {
          formJson: values,
          id: this.$route.query.Id
        }
        formEdit(Object.assign(data)).then(res => {
          if (res.success === true) {
            this.$message.success(res.message)
          } else {
            this.$message.error(res.message)
          }
        })
      }
    }
  }
</script>

<style >
.headertitle{
  font-size: 30px;
  font-weight: bolder;
  text-align: center;
  background-color: white;
}
</style>
