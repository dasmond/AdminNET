<template>
  <div class="tn-base-page">
    <div class="tn-base-page-content">
      <el-form v-loading="loading" :model="ruleForm" ref="ruleFormRef" label-width="auto" :rules="rules">
        <el-row :gutter="35">
          <el-form-item v-show="false">
            <el-input v-model="ruleForm.id" />
          </el-form-item>
          <el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
            <el-form-item label="车间编号" prop="workShopCode">
              <el-input v-model="ruleForm.workShopCode" placeholder="请输入车间编号" maxlength="32" show-word-limit clearable />

            </el-form-item>

          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
            <el-form-item label="车间名称" prop="workShopName">
              <el-input v-model="ruleForm.workShopName" placeholder="请输入车间名称" maxlength="32" show-word-limit clearable />

            </el-form-item>

          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
            <el-form-item label="所属机构Id" prop="orgId">
              <el-select clearable filterable v-model="ruleForm.orgId" placeholder="请选择所属机构Id">
                <el-option v-for="(item,index) in sysOrgOrgIdDropdownList" :key="index" :value="item.value" :label="item.label" />
              </el-select>

            </el-form-item>

          </el-col>
        </el-row>
      </el-form>
    </div>
    <div class="tn-base-page-bottom">
      <el-button @click="cancel">取 消</el-button>
      <el-button type="primary" @click="submit">确 定</el-button>
    </div>
  </div>
</template>
<style scoped>
:deep(.el-select),
:deep(.el-input-number) {
  width: 100%;
}
</style>
<script lang="ts" setup>
import {ref, onMounted} from "vue";
import {ElMessage, ElMessageBox} from "element-plus";
import type { FormRules } from "element-plus";
import { addT_WorkShop, updateT_WorkShop } from "/@/api/main/t_WorkShop";
import { getSysOrgOrgIdDropdown } from '/@/api/main/t_WorkShop';
import { useRoute } from "vue-router";
import mittBus from "/@/utils/mitt";
const loading = ref(false)


const ruleFormRef = ref();
let ruleForm = ref<any>({});
//自行添加其他规则
const rules = ref<FormRules>({
  workShopCode: [{required: true, message: '请输入车间编号！', trigger: 'blur',},],
  workShopName: [{required: true, message: '请输入车间名称！', trigger: 'blur',},],
});


// 定义变量内容
const route = useRoute();

// 1、关闭当前 tagsView
const refreshCurrentTagsView = () => {
  mittBus.emit(
      "onCurrentContextmenuClick",
      Object.assign({}, { contextMenuClickId: 1, ...route })
  );
};

// 取消
const cancel = () => {
  ElMessageBox.confirm(`确定要退出编辑吗?`, "提示", {
    confirmButtonText: "确定",
    cancelButtonText: "取消",
    type: "warning",
  })
      .then(async () => {
        refreshCurrentTagsView()
      })
      .catch(() => {
      });
};

// 提交
const submit = async () => {
  ruleFormRef.value.validate(async (isValid: boolean, fields?: any) => {
    if (isValid) {
      loading.value = true;
      let values = ruleForm.value;
      let res
      if (ruleForm.value.id == undefined || ruleForm.value.id == null || ruleForm.value.id == "" || ruleForm.value.id == 0) {
        res = await addT_WorkShop(values);
      } else {
        res = await updateT_WorkShop(values);
      }
      if (res.data.code == 200) {
        loading.value = false;
        ElMessage.success("保存成功");
        setTimeout(() => {
          refreshCurrentTagsView();
        }, 1500)
      }
    } else {
      ElMessage({
        message: `表单有${Object.keys(fields).length}处验证失败，请修改后再提交`,
        type: "error",
      });
    }
  });
};


const sysOrgOrgIdDropdownList = ref<any>([]);
const getSysOrgOrgIdDropdownList = async () => {
  let list = await getSysOrgOrgIdDropdown();
  sysOrgOrgIdDropdownList.value = list.data.result ?? [];
};
getSysOrgOrgIdDropdownList();


// 页面加载时
onMounted(async () => {
  if (route.query.params) {
    ruleForm.value = JSON.parse(<string>route.query.params)
  }
});


</script>




