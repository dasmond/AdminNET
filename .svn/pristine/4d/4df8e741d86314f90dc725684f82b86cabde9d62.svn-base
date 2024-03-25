<template>
  <div class="processInstanceRecord-container">
    <el-card shadow="hover" :body-style="{ paddingBottom: '0' }">
      <el-form :model="queryParams" ref="queryForm" labelWidth="90">
        <el-row>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10">
            <el-form-item label="关键字">
              <el-input v-model="queryParams.searchKey" clearable="" placeholder="请输入模糊查询关键字"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="业务ID">
              <el-input v-model="queryParams.businessKey" clearable="" placeholder="请输入业务ID"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="流程实例id">
              <el-input v-model="queryParams.processInstanceId" clearable="" placeholder="请输入流程实例id"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="流程模板ID">
              <el-input v-model="queryParams.flowId" clearable="" placeholder="请输入流程模板ID"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="当前流程任务id">
              <el-input v-model="queryParams.flowTaskId" clearable="" placeholder="请输入当前流程任务id"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="当前流程任务名称">
              <el-input v-model="queryParams.flowTaskName" clearable="" placeholder="请输入当前流程任务名称"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="操作人">
              <el-input v-model="queryParams.startUserName" clearable="" placeholder="请输入操作人"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="操作人id">
              <el-input v-model="queryParams.startUserId" clearable="" placeholder="请输入操作人id"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="审批结果">
              <el-input-number v-model="queryParams.approvalResults"  clearable="" placeholder="请输入审批结果"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="审批人意见">
              <el-input v-model="queryParams.opinionOfApprover" clearable="" placeholder="请输入审批人意见"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="角色组">
              <el-input v-model="queryParams.roleGroup" clearable="" placeholder="请输入角色组"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="流程分支业务id">
              <el-input v-model="queryParams.processBranchId" clearable="" placeholder="请输入流程分支业务id"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="乐观锁">
              <el-input-number v-model="queryParams.reVision"  clearable="" placeholder="请输入乐观锁"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="6" :xl="6" class="mb10">
            <el-form-item>
              <el-button-group>
                <el-button type="primary"  icon="ele-Search" @click="handleQuery" v-auth="'processInstanceRecord:page'"> 查询 </el-button>
                <el-button icon="ele-Refresh" @click="() => queryParams = {}"> 重置 </el-button>
                <el-button icon="ele-ZoomIn" @click="changeAdvanceQueryUI" v-if="!showAdvanceQueryUI"> 高级 </el-button>
                <el-button icon="ele-ZoomOut" @click="changeAdvanceQueryUI" v-if="showAdvanceQueryUI"> 隐藏 </el-button>
                
              </el-button-group>
              
              <el-button-group style="margin-left:20px">
                <el-button type="primary" icon="ele-Plus" @click="openAddProcessInstanceRecord" v-auth="'processInstanceRecord:add'"> 新增 </el-button>
                
              </el-button-group>
              
            </el-form-item>
            
          </el-col>
        </el-row>
      </el-form>
    </el-card>
    <el-card class="full-table" shadow="hover" style="margin-top: 8px">
      <el-table
				:data="tableData"
				style="width: 100%"
				v-loading="loading"
				tooltip-effect="light"
				row-key="id"
                @sort-change="sortChange"
				border="">
        <el-table-column type="index" label="序号" width="55" align="center"/>
        <el-table-column prop="businessKey" label="业务ID" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="processInstanceId" label="流程实例id" width="90"  show-overflow-tooltip="" />
        <el-table-column prop="flowId" label="流程模板ID" width="90"  show-overflow-tooltip="" />
        <el-table-column prop="flowTaskId" label="当前流程任务id" width="120"  show-overflow-tooltip="" />
        <el-table-column prop="flowTaskName" label="当前流程任务名称" width="120"  show-overflow-tooltip="" />
        <el-table-column prop="startUserName" label="操作人" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="startUserId" label="操作人id" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="approvalResults" label="审批结果" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="opinionOfApprover" label="审批人意见" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="roleGroup" label="角色组" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="processBranchId" label="流程分支业务id" width="120"  show-overflow-tooltip="" />
        <el-table-column prop="reVision" label="乐观锁" width="140"  show-overflow-tooltip="" />
        <el-table-column label="操作" width="140" align="center" fixed="right" show-overflow-tooltip="" v-if="auth('processInstanceRecord:edit') || auth('processInstanceRecord:delete')">
          <template #default="scope">
            <el-button icon="ele-Edit" size="small" text="" type="primary" @click="openEditProcessInstanceRecord(scope.row)" v-auth="'processInstanceRecord:edit'"> 编辑 </el-button>
            <el-button icon="ele-Delete" size="small" text="" type="primary" @click="delProcessInstanceRecord(scope.row)" v-auth="'processInstanceRecord:delete'"> 删除 </el-button>
          </template>
        </el-table-column>
      </el-table>
      <el-pagination
				v-model:currentPage="tableParams.page"
				v-model:page-size="tableParams.pageSize"
				:total="tableParams.total"
				:page-sizes="[10, 20, 50, 100, 200, 500]"
				small=""
				background=""
				@size-change="handleSizeChange"
				@current-change="handleCurrentChange"
				layout="total, sizes, prev, pager, next, jumper"
	/>
      <printDialog
        ref="printDialogRef"
        :title="printProcessInstanceRecordTitle"
        @reloadTable="handleQuery" />
      <editDialog
        ref="editDialogRef"
        :title="editProcessInstanceRecordTitle"
        @reloadTable="handleQuery"
      />
    </el-card>
  </div>
</template>

<script lang="ts" setup="" name="processInstanceRecord">
  import { ref } from "vue";
  import { ElMessageBox, ElMessage } from "element-plus";
  import { auth } from '/@/utils/authFunction';
  import { getDictDataItem as di, getDictDataList as dl } from '/@/utils/dict-utils';
  import { formatDate } from '/@/utils/formatTime';


  import printDialog from '/@/views/system/print/component/hiprint/preview.vue'
  import editDialog from '/@/views/main/processInstanceRecord/component/editDialog.vue'
  import { pageProcessInstanceRecord, deleteProcessInstanceRecord } from '/@/api/main/processInstanceRecord';


  const showAdvanceQueryUI = ref(false);
  const printDialogRef = ref();
  const editDialogRef = ref();
  const loading = ref(false);
  const tableData = ref<any>([]);
  const queryParams = ref<any>({});
  const tableParams = ref({
    page: 1,
    pageSize: 10,
    total: 0,
  });

  const printProcessInstanceRecordTitle = ref("");
  const editProcessInstanceRecordTitle = ref("");

  // 改变高级查询的控件显示状态
  const changeAdvanceQueryUI = () => {
    showAdvanceQueryUI.value = !showAdvanceQueryUI.value;
  }
  

  // 查询操作
  const handleQuery = async () => {
    loading.value = true;
    var res = await pageProcessInstanceRecord(Object.assign(queryParams.value, tableParams.value));
    tableData.value = res.data.result?.items ?? [];
    tableParams.value.total = res.data.result?.total;
    loading.value = false;
  };

  // 列排序
  const sortChange = async (column: any) => {
	queryParams.value.field = column.prop;
	queryParams.value.order = column.order;
	await handleQuery();
  };

  // 打开新增页面
  const openAddProcessInstanceRecord = () => {
    editProcessInstanceRecordTitle.value = '添加历史流程记录表';
    editDialogRef.value.openDialog({});
  };

  // 打开打印页面
  const openPrintProcessInstanceRecord = async (row: any) => {
    printProcessInstanceRecordTitle.value = '打印历史流程记录表';
  }
  
  // 打开编辑页面
  const openEditProcessInstanceRecord = (row: any) => {
    editProcessInstanceRecordTitle.value = '编辑历史流程记录表';
    editDialogRef.value.openDialog(row);
  };

  // 删除
  const delProcessInstanceRecord = (row: any) => {
    ElMessageBox.confirm(`确定要删除吗?`, "提示", {
    confirmButtonText: "确定",
    cancelButtonText: "取消",
    type: "warning",
  })
  .then(async () => {
    await deleteProcessInstanceRecord(row);
    handleQuery();
    ElMessage.success("删除成功");
  })
  .catch(() => {});
  };

  // 改变页面容量
  const handleSizeChange = (val: number) => {
    tableParams.value.pageSize = val;
    handleQuery();
  };

  // 改变页码序号
  const handleCurrentChange = (val: number) => {
    tableParams.value.page = val;
    handleQuery();
  };

  handleQuery();
</script>
<style scoped>
:deep(.el-ipnut),
:deep(.el-select),
:deep(.el-input-number) {
	width: 100%;
}
</style>

