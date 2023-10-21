<template>
  <div class="t_WorkLine-container">
    <el-card shadow="hover" :body-style="{ paddingBottom: '0' }">
      <el-form :model="queryParams" ref="queryForm" :inline="true">
        <el-form-item label="关键字">
          <el-input v-model="queryParams.searchKey" clearable="" placeholder="请输入模糊查询关键字"/>
          
        </el-form-item>
        <el-form-item label="生产线编号">
          <el-input v-model="queryParams.workLineCode" clearable="" placeholder="请输入生产线编号"/>
          
        </el-form-item>
        <el-form-item label="生产线名称">
          <el-input v-model="queryParams.workLineName" clearable="" placeholder="请输入生产线名称"/>
          
        </el-form-item>
        <el-form-item label="生产线简称">
          <el-input v-model="queryParams.workLineSimpleName" clearable="" placeholder="请输入生产线简称"/>
          
        </el-form-item>
        <el-form-item label="允许领料">
          <el-select clearable="" v-model="queryParams.ifAllowed" placeholder="请选择允许领料">
            <el-option v-for="(item,index) in getifAllowedData" :key="index" :value="item.value" :label="item.label" />
            
          </el-select>
          
        </el-form-item>
        <el-form-item label="允许计件">
          <el-select clearable="" v-model="queryParams.ifPriceAllowed" placeholder="请选择允许计件">
            <el-option v-for="(item,index) in getifPriceAllowedData" :key="index" :value="item.value" :label="item.label" />
            
          </el-select>
          
        </el-form-item>
        <el-form-item label="所属生产中心">
          <el-select clearable="" filterable="" v-model="queryParams.workGroupID" placeholder="请选择所属生产中心">
            <el-option v-for="(item,index) in  t_WorkGroupWorkGroupIDDropdownList" :key="index" :value="item.value" :label="item.label" />
            
          </el-select>
          
        </el-form-item>
        <el-form-item>
          <el-button-group>
            <el-button type="primary"  icon="ele-Search" @click="handleQuery" v-auth="'t_WorkLine:page'"> 查询 </el-button>
            <el-button icon="ele-Refresh" @click="() => queryParams = {}"> 重置 </el-button>
            
          </el-button-group>
          
        </el-form-item>
        <el-form-item>
          <el-button type="primary" icon="ele-Plus" @click="openAddT_WorkLine" v-auth="'t_WorkLine:add'"> 新增 </el-button>
          
        </el-form-item>
        
      </el-form>
    </el-card>
    <el-card class="full-table" shadow="hover" style="margin-top: 8px">
      <el-table
				:data="tableData"
				style="width: 100%"
				v-loading="loading"
				tooltip-effect="light"
				row-key="id"
				border="">
        <el-table-column type="index" label="序号" width="55" align="center"/>
        <el-table-column prop="workLineCode" label="生产线编号" width="140" show-overflow-tooltip="" />
        <el-table-column prop="workLineName" label="生产线名称" width="140" show-overflow-tooltip="" />
        <el-table-column prop="workLineSimpleName" label="生产线简称" width="140" show-overflow-tooltip="" />
        <el-table-column prop="ifAllowed" label="允许领料" width="140" show-overflow-tooltip="" />
        <el-table-column prop="ifPriceAllowed" label="允许计件" width="140" show-overflow-tooltip="" />
        <el-table-column prop="workGroupID" label="所属生产中心" width="90" show-overflow-tooltip="">
          <template #default="scope">
            <span>{{scope.row.workGroupIDWorkGroupName}}</span>
            
          </template>
          
        </el-table-column>
        <el-table-column label="操作" width="140" align="center" fixed="right" show-overflow-tooltip="" v-if="auth('t_WorkLine:edit') || auth('t_WorkLine:delete')">
          <template #default="scope">
            <el-button icon="ele-Edit" size="small" text="" type="primary" @click="openEditT_WorkLine(scope.row)" v-auth="'t_WorkLine:edit'"> 编辑 </el-button>
            <el-button icon="ele-Delete" size="small" text="" type="primary" @click="delT_WorkLine(scope.row)" v-auth="'t_WorkLine:delete'"> 删除 </el-button>
          </template>
        </el-table-column>
      </el-table>
      <el-pagination
				v-model:currentPage="tableParams.page"
				v-model:page-size="tableParams.pageSize"
				:total="tableParams.total"
				:page-sizes="[10, 20, 50, 100, 200]"
				small=""
				background=""
				@size-change="handleSizeChange"
				@current-change="handleCurrentChange"
				layout="total, sizes, prev, pager, next, jumper"
	/>
      <editDialog
        ref="editDialogRef"
        :title="editT_WorkLineTitle"
        @reloadTable="handleQuery"
      />
    </el-card>
  </div>
</template>

<script lang="ts" setup="" name="t_WorkLine">
  import { ref } from "vue";
  import { ElMessageBox, ElMessage } from "element-plus";
  import { auth } from '/@/utils/authFunction';
  //import { formatDate } from '/@/utils/formatTime';

  import editDialog from '/@/views/main/t_WorkLine/component/editDialog.vue'
  import { pageT_WorkLine, deleteT_WorkLine } from '/@/api/main/t_WorkLine';
  import { getT_WorkGroupWorkGroupIDDropdown } from '/@/api/main/t_WorkLine';
  import { getDictDataList } from '/@/api/system/admin';

  const getifAllowedData = ref<any>([]);
  const getifPriceAllowedData = ref<any>([]);

  const editDialogRef = ref();
  const loading = ref(false);
  const tableData = ref<any>([]);
  const queryParams = ref<any>({});
  const tableParams = ref({
  page: 1,
  pageSize: 10,
  total: 0,
  });
  const editT_WorkLineTitle = ref("");


  // 查询操作
  const handleQuery = async () => {
    loading.value = true;
    var res = await pageT_WorkLine(Object.assign(queryParams.value, tableParams.value));
    tableData.value = res.data.result?.items ?? [];
    tableParams.value.total = res.data.result?.total;
    loading.value = false;
    getifAllowedData.value = await dictTypeDataList('IfAllowed');
    getifPriceAllowedData.value = await dictTypeDataList('IfAllowed');
  };

  // 打开新增页面
  const openAddT_WorkLine = () => {
    editT_WorkLineTitle.value = '添加生产线';
    editDialogRef.value.openDialog({});
  };

  // 打开编辑页面
  const openEditT_WorkLine = (row: any) => {
    editT_WorkLineTitle.value = '编辑生产线';
    editDialogRef.value.openDialog(row);
  };

  // 删除
  const delT_WorkLine = (row: any) => {
    ElMessageBox.confirm(`确定要删除吗?`, "提示", {
    confirmButtonText: "确定",
    cancelButtonText: "取消",
    type: "warning",
  })
  .then(async () => {
    await deleteT_WorkLine(row);
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

  const t_WorkGroupWorkGroupIDDropdownList = ref<any>([]); 
  const getT_WorkGroupWorkGroupIDDropdownList = async () => {
    let list = await getT_WorkGroupWorkGroupIDDropdown();
    t_WorkGroupWorkGroupIDDropdownList.value = list.data.result ?? [];
  };
  getT_WorkGroupWorkGroupIDDropdownList();


    const dictTypeDataList = async (val: any) => {
      let list = await getDictDataList(val);
      return list.data.result ?? [];
    };
  handleQuery();
</script>


