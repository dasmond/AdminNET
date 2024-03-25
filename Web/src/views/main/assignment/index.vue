<template>
  <div class="assignment-container">
    <el-card shadow="hover" :body-style="{ paddingBottom: '0' }">
      <el-form :model="queryParams" ref="queryForm" labelWidth="90">
        <el-row>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10">
            <el-form-item label="关键字">
              <el-input v-model="queryParams.searchKey" clearable="" placeholder="请输入模糊查询关键字"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="备注">
              <el-input v-model="queryParams.meMo" clearable="" placeholder="请输入备注"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="前置任务">
              <el-input v-model="queryParams.predecessorTaskId" clearable="" placeholder="请输入前置任务"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="前置任务名称">
              <el-input v-model="queryParams.predecessorTaskName" clearable="" placeholder="请输入前置任务名称"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="任务名称">
              <el-input v-model="queryParams.assignmentName" clearable="" placeholder="请输入任务名称"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="所属项目id">
              <el-input v-model="queryParams.projectId" clearable="" placeholder="请输入所属项目id"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="编码">
              <el-input v-model="queryParams.sno" clearable="" placeholder="请输入编码"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="任务所属人">
              <el-input v-model="queryParams.roleId" clearable="" placeholder="请输入任务所属人"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="紧急程度">
              <el-input-number v-model="queryParams.prioriry"  clearable="" placeholder="请输入紧急程度"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="重要程度">
              <el-input-number v-model="queryParams.instancy"  clearable="" placeholder="请输入重要程度"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="任务内容">
              <el-input v-model="queryParams.conTent" clearable="" placeholder="请输入任务内容"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="状态">
              <el-input-number v-model="queryParams.status"  clearable="" placeholder="请输入状态"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="开始时间">
              <el-date-picker placeholder="请选择开始时间" value-format="YYYY/MM/DD" type="daterange" v-model="queryParams.startTimeRange" />
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="预计完成天数">
              <el-input-number v-model="queryParams.projectedCompletionTime"  clearable="" placeholder="请输入预计完成天数"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="已用天数">
              <el-input-number v-model="queryParams.daysUsed"  clearable="" placeholder="请输入已用天数"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="实际完成时间">
              <el-date-picker placeholder="请选择实际完成时间" value-format="YYYY/MM/DD" type="daterange" v-model="queryParams.actyalTimeRange" />
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="任务完成评价">
              <el-input v-model="queryParams.appraise" clearable="" placeholder="请输入任务完成评价"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="效率评价等级">
              <el-input-number v-model="queryParams.efficiencyLevel"  clearable="" placeholder="请输入效率评价等级"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="质量评价等级">
              <el-input-number v-model="queryParams.qualityLevel"  clearable="" placeholder="请输入质量评价等级"/>
              
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
                <el-button type="primary"  icon="ele-Search" @click="handleQuery" v-auth="'assignment:page'"> 查询 </el-button>
                <el-button icon="ele-Refresh" @click="() => queryParams = {}"> 重置 </el-button>
                <el-button icon="ele-ZoomIn" @click="changeAdvanceQueryUI" v-if="!showAdvanceQueryUI"> 高级 </el-button>
                <el-button icon="ele-ZoomOut" @click="changeAdvanceQueryUI" v-if="showAdvanceQueryUI"> 隐藏 </el-button>
                
              </el-button-group>
              
              <el-button-group style="margin-left:20px">
                <el-button type="primary" icon="ele-Plus" @click="openAddAssignment" v-auth="'assignment:add'"> 新增 </el-button>
                
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
        <el-table-column prop="meMo" label="备注" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="predecessorTaskId" label="前置任务" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="predecessorTaskName" label="前置任务名称" width="90"  show-overflow-tooltip="" />
        <el-table-column prop="assignmentName" label="任务名称" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="projectId" label="所属项目id" width="90"  show-overflow-tooltip="" />
        <el-table-column prop="sno" label="编码" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="roleId" label="任务所属人" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="prioriry" label="紧急程度" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="instancy" label="重要程度" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="conTent" label="任务内容" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="status" label="状态" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="startTime" label="开始时间" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="projectedCompletionTime" label="预计完成天数" width="90"  show-overflow-tooltip="" />
        <el-table-column prop="daysUsed" label="已用天数" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="actyalTime" label="实际完成时间" width="90"  show-overflow-tooltip="" />
        <el-table-column prop="appraise" label="任务完成评价" width="90"  show-overflow-tooltip="" />
        <el-table-column prop="efficiencyLevel" label="效率评价等级" width="90"  show-overflow-tooltip="" />
        <el-table-column prop="qualityLevel" label="质量评价等级" width="90"  show-overflow-tooltip="" />
        <el-table-column prop="reVision" label="乐观锁" width="140"  show-overflow-tooltip="" />
        <el-table-column label="操作" width="140" align="center" fixed="right" show-overflow-tooltip="" v-if="auth('assignment:edit') || auth('assignment:delete')">
          <template #default="scope">
            <el-button icon="ele-Edit" size="small" text="" type="primary" @click="openEditAssignment(scope.row)" v-auth="'assignment:edit'"> 编辑 </el-button>
            <el-button icon="ele-Delete" size="small" text="" type="primary" @click="delAssignment(scope.row)" v-auth="'assignment:delete'"> 删除 </el-button>
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
        :title="printAssignmentTitle"
        @reloadTable="handleQuery" />
      <editDialog
        ref="editDialogRef"
        :title="editAssignmentTitle"
        @reloadTable="handleQuery"
      />
    </el-card>
  </div>
</template>

<script lang="ts" setup="" name="assignment">
  import { ref } from "vue";
  import { ElMessageBox, ElMessage } from "element-plus";
  import { auth } from '/@/utils/authFunction';
  import { getDictDataItem as di, getDictDataList as dl } from '/@/utils/dict-utils';
  import { formatDate } from '/@/utils/formatTime';


  import printDialog from '/@/views/system/print/component/hiprint/preview.vue'
  import editDialog from '/@/views/main/assignment/component/editDialog.vue'
  import { pageAssignment, deleteAssignment } from '/@/api/main/assignment';


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

  const printAssignmentTitle = ref("");
  const editAssignmentTitle = ref("");

  // 改变高级查询的控件显示状态
  const changeAdvanceQueryUI = () => {
    showAdvanceQueryUI.value = !showAdvanceQueryUI.value;
  }
  

  // 查询操作
  const handleQuery = async () => {
    loading.value = true;
    var res = await pageAssignment(Object.assign(queryParams.value, tableParams.value));
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
  const openAddAssignment = () => {
    editAssignmentTitle.value = '添加任务表';
    editDialogRef.value.openDialog({});
  };

  // 打开打印页面
  const openPrintAssignment = async (row: any) => {
    printAssignmentTitle.value = '打印任务表';
  }
  
  // 打开编辑页面
  const openEditAssignment = (row: any) => {
    editAssignmentTitle.value = '编辑任务表';
    editDialogRef.value.openDialog(row);
  };

  // 删除
  const delAssignment = (row: any) => {
    ElMessageBox.confirm(`确定要删除吗?`, "提示", {
    confirmButtonText: "确定",
    cancelButtonText: "取消",
    type: "warning",
  })
  .then(async () => {
    await deleteAssignment(row);
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

