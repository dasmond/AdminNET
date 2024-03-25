<template>
  <div class="appendix-container">
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
            <el-form-item label="编码">
              <el-input v-model="queryParams.sno" clearable="" placeholder="请输入编码"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="所属表id">
              <el-input v-model="queryParams.dbId" clearable="" placeholder="请输入所属表id"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="模块名">
              <el-input v-model="queryParams.module" clearable="" placeholder="请输入模块名"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="文件名">
              <el-input v-model="queryParams.name" clearable="" placeholder="请输入文件名"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="文件类型">
              <el-input v-model="queryParams.type" clearable="" placeholder="请输入文件类型"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="程序类型">
              <el-input-number v-model="queryParams.programType"  clearable="" placeholder="请输入程序类型"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="状态">
              <el-input v-model="queryParams.status" clearable="" placeholder="请输入状态"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="文件路径">
              <el-input v-model="queryParams.path" clearable="" placeholder="请输入文件路径"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="文件链接">
              <el-input v-model="queryParams.url" clearable="" placeholder="请输入文件链接"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="文件md5">
              <el-input v-model="queryParams.md5" clearable="" placeholder="请输入文件md5"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="文件大小">
              <el-input v-model="queryParams.size" clearable="" placeholder="请输入文件大小"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="文件后缀">
              <el-input v-model="queryParams.suffix" clearable="" placeholder="请输入文件后缀"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="下载次数">
              <el-input-number v-model="queryParams.download"  clearable="" placeholder="请输入下载次数"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="存储到bucket的名称">
              <el-input v-model="queryParams.fileObjectName" clearable="" placeholder="请输入存储到bucket的名称"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="存储到bucket的名称">
              <el-input-number v-model="queryParams.distinguishTypes"  clearable="" placeholder="请输入存储到bucket的名称"/>
              
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
                <el-button type="primary"  icon="ele-Search" @click="handleQuery" v-auth="'appendix:page'"> 查询 </el-button>
                <el-button icon="ele-Refresh" @click="() => queryParams = {}"> 重置 </el-button>
                <el-button icon="ele-ZoomIn" @click="changeAdvanceQueryUI" v-if="!showAdvanceQueryUI"> 高级 </el-button>
                <el-button icon="ele-ZoomOut" @click="changeAdvanceQueryUI" v-if="showAdvanceQueryUI"> 隐藏 </el-button>
                
              </el-button-group>
              
              <el-button-group style="margin-left:20px">
                <el-button type="primary" icon="ele-Plus" @click="openAddAppendix" v-auth="'appendix:add'"> 新增 </el-button>
                
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
        <el-table-column prop="sno" label="编码" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="dbId" label="所属表id" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="module" label="模块名" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="name" label="文件名" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="type" label="文件类型" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="programType" label="程序类型" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="status" label="状态" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="path" label="文件路径" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="url" label="文件链接" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="md5" label="文件md5" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="size" label="文件大小" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="suffix" label="文件后缀" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="download" label="下载次数" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="fileObjectName" label="存储到bucket的名称" width="180"  show-overflow-tooltip="" />
        <el-table-column prop="distinguishTypes" label="存储到bucket的名称" width="180"  show-overflow-tooltip="" />
        <el-table-column prop="reVision" label="乐观锁" width="140"  show-overflow-tooltip="" />
        <el-table-column label="操作" width="140" align="center" fixed="right" show-overflow-tooltip="" v-if="auth('appendix:edit') || auth('appendix:delete')">
          <template #default="scope">
            <el-button icon="ele-Edit" size="small" text="" type="primary" @click="openEditAppendix(scope.row)" v-auth="'appendix:edit'"> 编辑 </el-button>
            <el-button icon="ele-Delete" size="small" text="" type="primary" @click="delAppendix(scope.row)" v-auth="'appendix:delete'"> 删除 </el-button>
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
        :title="printAppendixTitle"
        @reloadTable="handleQuery" />
      <editDialog
        ref="editDialogRef"
        :title="editAppendixTitle"
        @reloadTable="handleQuery"
      />
    </el-card>
  </div>
</template>

<script lang="ts" setup="" name="appendix">
  import { ref } from "vue";
  import { ElMessageBox, ElMessage } from "element-plus";
  import { auth } from '/@/utils/authFunction';
  import { getDictDataItem as di, getDictDataList as dl } from '/@/utils/dict-utils';
  import { formatDate } from '/@/utils/formatTime';


  import printDialog from '/@/views/system/print/component/hiprint/preview.vue'
  import editDialog from '/@/views/main/appendix/component/editDialog.vue'
  import { pageAppendix, deleteAppendix } from '/@/api/main/appendix';


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

  const printAppendixTitle = ref("");
  const editAppendixTitle = ref("");

  // 改变高级查询的控件显示状态
  const changeAdvanceQueryUI = () => {
    showAdvanceQueryUI.value = !showAdvanceQueryUI.value;
  }
  

  // 查询操作
  const handleQuery = async () => {
    loading.value = true;
    var res = await pageAppendix(Object.assign(queryParams.value, tableParams.value));
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
  const openAddAppendix = () => {
    editAppendixTitle.value = '添加附件表';
    editDialogRef.value.openDialog({});
  };

  // 打开打印页面
  const openPrintAppendix = async (row: any) => {
    printAppendixTitle.value = '打印附件表';
  }
  
  // 打开编辑页面
  const openEditAppendix = (row: any) => {
    editAppendixTitle.value = '编辑附件表';
    editDialogRef.value.openDialog(row);
  };

  // 删除
  const delAppendix = (row: any) => {
    ElMessageBox.confirm(`确定要删除吗?`, "提示", {
    confirmButtonText: "确定",
    cancelButtonText: "取消",
    type: "warning",
  })
  .then(async () => {
    await deleteAppendix(row);
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

