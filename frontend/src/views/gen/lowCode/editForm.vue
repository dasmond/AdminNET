<template>
  <a-modal
    title="编辑代码生成配置"
    :width="1200"
    :visible="visible"
    :confirmLoading="confirmLoading"
    @ok="handleSubmit"
    @cancel="handleCancel">
    <a-spin :spinning="confirmLoading">
      <a-tabs v-model="activeKey" @change="tabsChange">
        <a-tab-pane key="1" tab="基础信息">
          <a-form :form="form">
            <a-form-item v-show="false">
              <a-input v-decorator="['id']" />
            </a-form-item>
            <a-row :gutter="24">
              <a-col :md="12" :sm="24">
                <a-form-item :labelCol="labelCol" :wrapperCol="wrapperCol" label="生成库" has-feedback>
                  <a-select
                    style="width: 100%"
                    placeholder="请选择数据库"
                    v-decorator="['databaseName', {rules: [{ required: true, message: '请选择数据库！' }]}]">
                    <a-select-option
                      v-for="(item,index) in databaseNameData"
                      :key="index"
                      :value="item.databaseName"
                      @click="databaseNameSele(item)">{{ item.databaseName }}</a-select-option>
                  </a-select>
                </a-form-item>
              </a-col>

              <a-col :md="12" :sm="24">
                <a-form-item label="业务名" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
                  <a-input
                    placeholder="请输入业务名"
                    v-decorator="['busName', {rules: [{required: true, message: '请输入业务名！'}]}]" />
                </a-form-item>
              </a-col>
              
              <a-col :md="12" :sm="24">
                <a-form-item :labelCol="labelCol" :wrapperCol="wrapperCol" label="菜单分类" has-feedback>
                  <a-select
                    style="width: 100%"
                    placeholder="请选择应用分类"
                    v-decorator="['menuApplication', {rules: [{ required: true, message: '请选择应用分类！' }]}]">
                    <a-select-option
                      v-for="(item,index) in appData"
                      :key="index"
                      :value="item.code"
                      @click="changeApplication(item.code)">{{ item.name }}</a-select-option>
                  </a-select>
                </a-form-item>
              </a-col>
              <a-col :md="12" :sm="24">
                <div>
                  <a-form-item :labelCol="labelCol" :wrapperCol="wrapperCol" label="父级菜单" has-feedback>
                    <a-tree-select
                      v-decorator="['menuPid', {rules: [{ required: true, message: '请选择父级菜单！' }]}]"
                      style="width: 100%"
                      :dropdownStyle="{ maxHeight: '300px', overflow: 'auto' }"
                      :treeData="menuTreeData"
                      placeholder="请选择父级菜单"
                      treeDefaultExpandAll>
                      <span slot="title" slot-scope="{ id }">{{ id }}
                      </span>
                    </a-tree-select>
                  </a-form-item>
                </div>
              </a-col>
            
              <a-col :md="12" :sm="24">
                <a-form-item label="命名空间" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
                  <a-input
                    placeholder="请输入命名空间"
                    v-decorator="['nameSpace', {rules: [{required: true, message: '请输入命名空间！'}]}]" />
                </a-form-item>
              </a-col>
              <a-col :md="12" :sm="24">
                <a-form-item label="作者姓名" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
                  <a-input
                    placeholder="请输入作者姓名"
                    v-decorator="['authorName', {rules: [{required: true, message: '请输入作者姓名！'}]}]" />
                </a-form-item>
              </a-col>

              <a-col :md="12" :sm="24">
                <a-form-item :labelCol="labelCol" :wrapperCol="wrapperCol" label="生成方式">
                  <a-radio-group v-decorator="['generateType',{rules: [{ required: true, message: '请选择生成方式！' }]}]">
                    <a-radio
                      v-for="(item,index) in generateTypeData"
                      :key="index"
                      :value="item.code"
                      @click="generateTypeRadio(item.code)">{{ item.name }}</a-radio>
                  </a-radio-group>
                </a-form-item>
              </a-col>
            </a-row>
          </a-form>
        </a-tab-pane>
        <a-tab-pane key="2" tab="表单配置" force-render>
          <k-form-design 
            :showHead="false" 
            ref='kfd'
            style="background-color: white;"
            @save="kFormHandleSave"
            :value="kFormDesignData"  />
        </a-tab-pane>
        <a-tab-pane key="3" tab="动态数据" force-render>
          <dictIndex></dictIndex>
        </a-tab-pane>
        <a-tab-pane key="4" tab="数据表配置">
          <a-button type="primary" @click="addTableModal">添加表</a-button>

          <span v-for="(table, index) in Tables" :key="index">
            <a-tag :closable="true" @close="tableHandleClose(table)">
              {{ table.tableDesc }}
            </a-tag>
          </span>

          <a-table 
            ref="table"
            :dataSource="databases" 
            :columns="databases_columns"
            :pagination="false"
            :alert="true"
            :rowKey="(record) => record.id">
            <span slot="dbParam" slot-scope="text, record">
              <a-input v-model="record.dbParam" />
            </span>
            <span slot="fieldName" slot-scope="text, record">
              <a-input v-model="record.fieldName" />
            </span>
            <span slot="tableName" slot-scope="text, record">
              <a-select v-model="record.tableName" @change="handleChangeTable(record)">
                <a-select-option v-for="d in Tables" :key="d.tableName">
                  {{ d.tableDesc }}
                </a-select-option>
              </a-select>
            </span>
            <span slot="isRequired" slot-scope="text, record">
              <a-checkbox v-model="record.isRequired"></a-checkbox>
            </span>
            <span slot="key" slot-scope="text, record">
              {{record.control_Key}} <br />
              {{record.control_Label}} ({{record.control_Model}})
            </span>
            <template slot="whetherTable" slot-scope="text, record">
              <a-checkbox v-model="record.whetherTable" />
            </template>
            <template slot="whetherOrderBy" slot-scope="text, record">
              <a-checkbox v-model="record.whetherOrderBy" />
            </template>
            <template slot="whetherAddUpdate" slot-scope="text, record">
              <a-checkbox v-model="record.whetherAddUpdate" />
            </template>
            <template slot="queryWhether" slot-scope="text, record">
              <a-checkbox v-model="record.queryWhether" />
            </template>
            <template slot="queryType" slot-scope="text, record">
              <a-select style="width: 100px" v-model="record.queryType" :disabled="!record.queryWhether">
                <a-select-option v-for="(item, index) in codeGenQueryTypeData" :key="index" :value="item.code">{{
                  item.name
                }}</a-select-option>
              </a-select>
            </template>
          </a-table>
        </a-tab-pane>
      </a-tabs>
      <a-modal :visible="visible" v-if="addTableShow" title="添加表" @ok="addTable_handleOk" @cancel="addTable_handleCancel">
          <a-row :gutter="24">
            <a-col :md="24" :sm="24">
              <a-form-item label="类名" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
                <a-input v-model="addTable.className" />
              </a-form-item>
            </a-col>
            <a-col :md="24" :sm="24">
              <a-form-item label="表名" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
                <a-input v-model="addTable.tableName" />
              </a-form-item>
            </a-col>
            <a-col :md="24" :sm="24">
              <a-form-item label="描述" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
                <a-input v-model="addTable.tableDesc" />
              </a-form-item>
            </a-col>
          </a-row>
      </a-modal>
    </a-spin>
  </a-modal>
</template>

<script>
  import {
    getAppList
  } from '@/api/modular/system/appManage'
  import {
    getMenuTree
  } from '@/api/modular/system/menuManage'
  import { 
    codeGenerateDatabaseList 
  } from '@/api/modular/gen/codeGenerateManage'
  import { lowCodeEdit,lowCodeContrast, lowCodeInfo } from '@/api/modular/gen/lowCodeManage'
  import { CheckOutlined, EditOutlined } from '@ant-design/icons-vue';
  import 'k-form-design/styles/k-form-design.less'
import { setFormDesignConfig } from 'k-form-design'
  import { STable, Ellipsis } from '@/components'
  import dictIndex from '../../system/dict/index.vue'
  import Vue from 'vue'
  import { ACCESS_TOKEN } from '@/store/mutation-types'
import { map } from 'leaflet'

  export default{
    components: {
      STable, Ellipsis,dictIndex
    },
    data() {
      return {
        labelCol: {
          xs: {
            span: 24
          },
          sm: {
            span: 5
          }
        },
        wrapperCol: {
          xs: {
            span: 24
          },
          sm: {
            span: 15
          }
        },
        visible: false,
        addTable:{
          className: '',
          tableName: '',
          tableDesc: ''
        },
        Tables:[],
        addTableShow: false,
        databaseNameData:[],
        tableNameData: [],
        appData: [],
        menuTreeData: [],
        generateTypeData: [],
        confirmLoading: false,
        databaseNameValue:'',
        tableNameValue: '',
        activeKey: '1',
        kFormDesignData: {},
        databases: [],
        editableData: {},
        databases_columns: [{
            title: 'key',
            dataIndex: 'control_Key',
            key: 'control_Key',
            scopedSlots: { customRender: 'key' }
          },{
            title: '表单类型',
            dataIndex: 'control_Type',
            key: 'control_Type',
          },{
            title: '非空字段',
            dataIndex: 'isRequired',
            key: 'isRequired',
            width: '70px',
            scopedSlots: { customRender: 'isRequired' }
          },{
            title: '表名',
            dataIndex: 'tableName',
            key: 'tableName',
            scopedSlots: { customRender: 'tableName' }
          },{
            title: '字段名',
            dataIndex: 'fieldName',
            key: 'fieldName',
            width: '150px',
          },{
            title: '数据类型',
            dataIndex: 'dbTypeName',
            key: 'dbTypeName',
          },{
            title: '数据库类型',
            dataIndex: 'dbParam',
            key: 'dbParam',
            width: '150px',
            scopedSlots: { customRender: 'dbParam' }
          },
          {
            title: '列表显示',
            align: 'center',
            dataIndex: 'whetherTable',
            scopedSlots: {
              customRender: 'whetherTable'
            }
          },
          {
            title: '排序',
            align: 'center',
            dataIndex: 'whetherOrderBy',
            scopedSlots: {
              customRender: 'whetherOrderBy'
            }
          },
          {
            title: '增改',
            align: 'center',
            dataIndex: 'whetherAddUpdate',
            scopedSlots: {
              customRender: 'whetherAddUpdate'
            }
          },
          {
            title: '是否是查询',
            align: 'center',
            dataIndex: 'queryWhether',
            scopedSlots: {
              customRender: 'queryWhether'
            }
          },
          {
            title: '查询方式',
            dataIndex: 'queryType',
            scopedSlots: {
              customRender: 'queryType'
            }
          }],
        codeGenQueryTypeData: [],
        form: this.$form.createForm(this)
      }
    },
    methods: {
      // 初始化方法
      edit(record) {
        const dictOption = this.$options
        this.visible = true
        this.codeGenerateDatabaseList()
        this.dataTypeItem()
        this.loadData(record)
        this.databaseNameValue = record.databaseName
        this.tableNameValue = record.tableName
        this.databases = [];
        this.codeGenQueryTypeData = dictOption.filters['dictData']('code_gen_query_type')

        let formDesign = record.formDesign || '';

        if(formDesign.length > 0){
          this.kFormDesignData = JSON.parse(record.formDesign);
        }else{
          this.kFormDesignData = {
              "list": [
              ],
              "config": {
                  "layout": "horizontal",
                  "labelCol": {
                      "xs": 4,
                      "sm": 4,
                      "md": 4,
                      "lg": 4,
                      "xl": 4,
                      "xxl": 4
                  },
                  "labelWidth": 100,
                  "labelLayout": "flex",
                  "wrapperCol": {
                      "xs": 18,
                      "sm": 18,
                      "md": 18,
                      "lg": 18,
                      "xl": 18,
                      "xxl": 18
                  },
                  "hideRequiredMark": false,
                  "customStyle": ""
              }
          }
        }

        // 获取系统应用列表
        this.getSysApplist()
        this.changeApplication(record.menuApplication)

        let uploadHeaders = {};

        const token = Vue.ls.get(ACCESS_TOKEN)
        const refreshToken = Vue.ls.get('X-Access-Token')
        if (token) {
          uploadHeaders['Authorization'] = 'Bearer ' + token
        }
        if (refreshToken) {
          uploadHeaders['X-Authorization'] = 'Bearer ' + refreshToken
        }

        let kformConfig = {
          uploadFile: "/api/sysFileInfo/kformormupload", // 上传文件地址
          uploadImage: "/api/sysFileInfo/kformormupload", // 上传图片地址
          uploadFileName: "file", // 上传文件name
          uploadImageName: "file", // 上传图片name
          uploadFileData: { key: "UploadFile:Default" }, // 上传文件额外参数
          uploadImageData: { key: "UploadFile:Default" }, // 上传图片额外参数
          uploadFileHeaders: uploadHeaders, // 上传文件请求头部
          uploadImageHeaders: uploadHeaders // 上传图片请求头部
        };

        setFormDesignConfig(kformConfig);

        this.$nextTick(() => {
          this.form.setFieldsValue({
            id: record.id,
            databaseName:record.databaseName,
            tableName: record.tableName,
            // tablePrefix: record.tablePrefix,
            // tableComment: record.tableComment,
            // className: record.className,
            busName: record.busName,
            generateType: record.generateType,
            authorName: record.authorName,
            nameSpace: record.nameSpace,
            menuApplication: record.menuApplication,
            menuPid: record.menuPid
          })

          this.importKFormDesignData();
        });

      },
      /**
       * 加载数据
       */
      loadData(record){
        lowCodeInfo(record.id).then((res) => {
          if (res.success) {
            this.databases = [];
            this.Tables = [];
            (res.data.databases || []).forEach(element => {
              this.databases.push(element);
            });
            (res.data.tables || []).forEach(element => {
              this.Tables.push(element);
            });
          } else {
            this.$message.error('获取失败' + res.message)
          }
        })
      },
      /**
       * 获得菜单所属应用
       */
      getSysApplist() {
        return getAppList().then((res) => {
          if (res.success) {
            this.appData = res.data
          } else {
            this.$message.warning(res.message)
          }
        })
      },
        /**
       * 获得所有数据库
       */
      codeGenerateDatabaseList() {
        codeGenerateDatabaseList().then((res) => {
          this.databaseNameData = res.data
        })
      },
      /**
       * 获取字典数据
       */
      dataTypeItem() {
        this.tablePrefixData = this.$options.filters['dictData']('yes_or_no')
        this.generateTypeData = this.$options.filters['dictData']('code_gen_create_type')
        this.generateTypeData.splice(0, 1) // 默认去掉从压缩包下载
      },
      /**
       * 提交表单
       */
      handleSubmit() {
        const {
          form: {
            validateFields
          }
        } = this
        validateFields((errors, values) => {
          if (!errors) {
            this.confirmLoading = true
            
            this.$refs.kfd.handleSave();
            values.formDesign = this.form.formDesign;
            values.formDesignType = 1;
            values.Databases = this.databases;

            lowCodeEdit(values).then((res) => {
              if (res.success) {
                this.$message.success('编辑成功')
                this.$emit('ok', values)
                this.handleCancel()
              } else {
                this.$message.error('编辑失败' + res.message)
              }
            }).finally((res) => {
              this.confirmLoading = false
            })
          }
        })
      },
      handleCancel() {
        this.form.resetFields()
        this.visible = false
      },
        /**
       * 选择数据库
       */
      databaseNameSele(item) {
        this.databaseNameValue = item.databaseName
        // this.form.getFieldDecorator('tableComment', { initialValue: item.tableComment })
        //this.form.getFieldDecorator('busName', {
        //  initialValue: item.databaseComment
        //})
        this.form.setFieldsValue({'tableName':''}); //这个OK
        //this.settingDefaultValue()
      },
      /**
       * 选择数据库列表
       */
      tableNameSele(item) {
        this.tableNameValue = item.tableName
        this.form.setFieldsValue({
          className: item.tableComment
        })
      },
      /**
       * 菜单所属应用change事件
       */
      changeApplication(value) {
        getMenuTree({
          'application': value
        }).then((res) => {
          if (res.success) {
            this.menuTreeData = [{
              'id': '-1',
              'parentId': '0',
              'title': '顶级',
              'value': '0',
              'pid': '0',
              'children': res.data
            }]
          } else {
            this.$message.warning(res.message)
          }
        })
      },
      /**
       * 选择生成方式
       */
      generateTypeRadio(generateType) {
        // if (generateType === '1') {
        //   this.packageNameShow = true
        // } else {
        //   this.packageNameShow = false
        //   this.form.setFieldsValue({ packageName: 'com.cn.xiaonuo' })
        // }
      },
      kFormHandleSave(values) {
        this.form.formDesign = values
      },
      tabsChange(values){
        if(values == "4"){
          var Fields = this.$refs.kfd.getValue();

          lowCodeContrast({Controls: JSON.stringify(Fields) , Databases: this.databases}).then((res) => {
            if (res.success) {
              for(var i = 0;i < (res.data.del || []).length;i++){
                this.databases.forEach((item,index) => {
                  if(item.control_Key === res.data.del[i].control_Key){
                    this.databases.splice(index,1)
                  }
                })
              }
              for(var i = 0;i < (res.data.add || []).length;i++){
                this.databases.push(res.data.add[i]);
              }
            } else {
              this.$message.error('加载失败' + res.message)
            }
          }).finally((res) => {
            //this.confirmLoading = false
            //结束加载
          })
        }
      },
      addTable_handleOk(){
        var dataTable = {...this.addTable};
        this.Tables.push(dataTable);
        this.databases.forEach((item,index) => {
          this.$set(item,'className',dataTable.className);
          this.$set(item,'tableName',dataTable.tableName);
          this.$set(item,'tableDesc',dataTable.tableDesc);
        });
        this.addTableShow = false;
      },
      addTable_handleCancel(){
        this.addTableShow = false;
      },
      addTableModal(){
        this.addTableShow = true;
        this.addTable.className = '';
        this.addTable.tableName = '';
        this.addTable.tableDesc = '';
      },
      importKFormDesignData () {
        this.$refs.kfd.handleSetData(this.kFormDesignData)
      },
      tableHandleClose(item){
        this.Tables = this.Tables.filter(table => table.className !== item.className);
      },
      handleChangeTable(a){
        let selectTable = this.Tables.filter(table => table.tableName === a.tableName)

        if(selectTable.length > 0){
          let item = { ...selectTable[0] };
          a.className = item.className;
          a.tableDesc = item.tableDesc;
        }
      }
    }
  }
</script>
