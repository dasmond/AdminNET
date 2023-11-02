<template>
  <div class="t_MaterialCategory-container">
    <el-card shadow="hover" :body-style="{ paddingBottom: '0' }">
      <el-form :model="queryParams" ref="queryForm" :inline="true">
        <el-form-item label="关键字">
          <el-input v-model="queryParams.searchKey" clearable="" placeholder="请输入模糊查询关键字"/>
          
        </el-form-item>
        <el-form-item label="物料类别编码">
          <el-input v-model="queryParams.categoryCode" clearable="" placeholder="请输入物料类别编码"/>
          
        </el-form-item>
        <el-form-item label="物料类别名称">
          <el-input v-model="queryParams.categoryName" clearable="" placeholder="请输入物料类别名称"/>
          
        </el-form-item>
        <el-form-item label="连接符号">
          <el-input v-model="queryParams.connectorStr" clearable="" placeholder="请输入连接符号"/>
          
        </el-form-item>
        <el-form-item label="流水长度">
          <el-input-number v-model="queryParams.codeLength"  clearable="" placeholder="请输入流水长度"/>
          
        </el-form-item>
        <el-form-item label="上级ID">
          <el-select clearable="" filterable="" v-model="queryParams.pID" placeholder="请选择上级ID">
            <el-option v-for="(item,index) in  t_MaterialCategoryPIDDropdownList" :key="index" :value="item.value" :label="item.label" />
            
          </el-select>
          
        </el-form-item>
        <el-form-item>
          <el-button-group>
            <el-button type="primary"  icon="ele-Search" @click="handleQuery" v-auth="'t_MaterialCategory:page'"> 查询 </el-button>
            <el-button icon="ele-Refresh" @click="() => queryParams = {}"> 重置 </el-button>
            
          </el-button-group>
          
        </el-form-item>
        <el-form-item>
          <el-button type="primary" icon="ele-Plus" @click="openAddT_MaterialCategory" v-auth="'t_MaterialCategory:add'"> 新增 </el-button>
          
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
        <el-table-column prop="orgID" label="车间ID" width="120" show-overflow-tooltip="">
          <template #default="scope">
            <span>{{scope.row.orgIDWorkShopName}}</span>
            
          </template>
          
        </el-table-column>
        <el-table-column prop="categoryCode" label="物料类别编码" width="90" show-overflow-tooltip="" />
        <el-table-column prop="categoryName" label="物料类别名称" width="90" show-overflow-tooltip="" />
        <el-table-column prop="connectorStr" label="连接符号" width="140" show-overflow-tooltip="" />
        <el-table-column prop="codeLength" label="流水长度" width="140" show-overflow-tooltip="" />
        <el-table-column prop="materialName" label="物料名称" width="140" show-overflow-tooltip="" />
        <el-table-column prop="materialEngname" label="英文名称" width="140" show-overflow-tooltip="" />
        <el-table-column prop="specification" label="规格" width="140" show-overflow-tooltip="" />
        <el-table-column prop="unit" label="单位" width="140" show-overflow-tooltip="" />
        <el-table-column prop="netWeight" label="净重" width="140" show-overflow-tooltip="" />
        <el-table-column prop="grossWeight" label="毛重" width="140" show-overflow-tooltip="" />
        <el-table-column prop="cubage" label="体积" width="140" show-overflow-tooltip="" />
        <el-table-column prop="packqty" label="包装件数" width="140" show-overflow-tooltip="" />
        <el-table-column prop="materialOrigin" label="物料来源" width="140" show-overflow-tooltip="" />
        <el-table-column prop="materialProp" label="物料属性" width="140" show-overflow-tooltip="" />
        <el-table-column prop="productSeries" label="产品系列" width="140" show-overflow-tooltip="" />
        <el-table-column prop="grain" label="材质" width="140" show-overflow-tooltip="" />
        <el-table-column prop="color" label="颜色" width="140" show-overflow-tooltip="" />
        <el-table-column prop="picCode" label="图纸号" width="140" show-overflow-tooltip="" />
        <el-table-column prop="barCode" label="条型码" width="140" show-overflow-tooltip="" />
        <el-table-column prop="configFID" label="选配1类型" width="140" show-overflow-tooltip="" />
        <el-table-column prop="configTypeFID" label="选配1项目ID" width="105" show-overflow-tooltip="" />
        <el-table-column prop="configFRequired" label="选配1必填" width="140" show-overflow-tooltip="" />
        <el-table-column prop="dftConfigFID" label="默认选配1内容ID" width="135" show-overflow-tooltip="" />
        <el-table-column prop="configSID" label="选配2类型" width="140" show-overflow-tooltip="" />
        <el-table-column prop="configTypeSID" label="选配2项目ID" width="105" show-overflow-tooltip="" />
        <el-table-column prop="configSRequired" label="选配2必填" width="140" show-overflow-tooltip="" />
        <el-table-column prop="dftConfigSID" label="默认选配2内容ID" width="135" show-overflow-tooltip="" />
        <el-table-column prop="configTID" label="选配3类型" width="140" show-overflow-tooltip="" />
        <el-table-column prop="configTypeTID" label="选配3项目ID" width="105" show-overflow-tooltip="" />
        <el-table-column prop="configTRequired" label="选配3必填" width="140" show-overflow-tooltip="" />
        <el-table-column prop="dftConfigTID" label="默认选配3内容ID" width="135" show-overflow-tooltip="" />
        <el-table-column prop="suite" label="套件类型" width="140" show-overflow-tooltip="" />
        <el-table-column prop="outType" label="进出类型" width="140" show-overflow-tooltip="" />
        <el-table-column prop="auxUnit" label="辅助单位" width="140" show-overflow-tooltip="" />
        <el-table-column prop="rate" label="转换率" width="140" show-overflow-tooltip="" />
        <el-table-column prop="inuse" label="已使用" width="120" show-overflow-tooltip="">
          <template #default="scope">
            <el-tag v-if="scope.row.inuse"> 是 </el-tag>
            <el-tag type="danger" v-else> 否 </el-tag>
            
          </template>
          
        </el-table-column>
        <el-table-column prop="storageID" label="默认仓库ID" width="90" show-overflow-tooltip="" />
        <el-table-column prop="spaceID" label="默认仓位ID" width="90" show-overflow-tooltip="" />
        <el-table-column prop="storageLock" label="使用库存分配" width="90" show-overflow-tooltip="">
          <template #default="scope">
            <el-tag v-if="scope.row.storageLock"> 是 </el-tag>
            <el-tag type="danger" v-else> 否 </el-tag>
            
          </template>
          
        </el-table-column>
        <el-table-column prop="batchCode" label="使用批号" width="120" show-overflow-tooltip="">
          <template #default="scope">
            <el-tag v-if="scope.row.batchCode"> 是 </el-tag>
            <el-tag type="danger" v-else> 否 </el-tag>
            
          </template>
          
        </el-table-column>
        <el-table-column prop="batchRule" label="批号规则" width="140" show-overflow-tooltip="" />
        <el-table-column prop="pID" label="上级ID" width="120" show-overflow-tooltip="">
          <template #default="scope">
            <span>{{scope.row.pIDCategoryName}}</span>
            
          </template>
          
        </el-table-column>
        <el-table-column label="操作" width="140" align="center" fixed="right" show-overflow-tooltip="" v-if="auth('t_MaterialCategory:edit') || auth('t_MaterialCategory:delete')">
          <template #default="scope">
            <el-button icon="ele-Edit" size="small" text="" type="primary" @click="openEditT_MaterialCategory(scope.row)" v-auth="'t_MaterialCategory:edit'"> 编辑 </el-button>
            <el-button icon="ele-Delete" size="small" text="" type="primary" @click="delT_MaterialCategory(scope.row)" v-auth="'t_MaterialCategory:delete'"> 删除 </el-button>
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
        :title="editT_MaterialCategoryTitle"
        @reloadTable="handleQuery"
      />
    </el-card>
  </div>
</template>

<script lang="ts" setup="" name="t_MaterialCategory">
  import { ref } from "vue";
  import { ElMessageBox, ElMessage } from "element-plus";
  import { auth } from '/@/utils/authFunction';
  //import { formatDate } from '/@/utils/formatTime';

  import editDialog from '/@/views/main/t_MaterialCategory/component/editDialog.vue'
  import { pageT_MaterialCategory, deleteT_MaterialCategory } from '/@/api/main/t_MaterialCategory';
  import { getT_MaterialCategoryPIDDropdown } from '/@/api/main/t_MaterialCategory';


  const editDialogRef = ref();
  const loading = ref(false);
  const tableData = ref<any>([]);
  const queryParams = ref<any>({});
  const tableParams = ref({
  page: 1,
  pageSize: 10,
  total: 0,
  });
  const editT_MaterialCategoryTitle = ref("");


  // 查询操作
  const handleQuery = async () => {
    loading.value = true;
    var res = await pageT_MaterialCategory(Object.assign(queryParams.value, tableParams.value));
    tableData.value = res.data.result?.items ?? [];
    tableParams.value.total = res.data.result?.total;
    loading.value = false;
  };

  // 打开新增页面
  const openAddT_MaterialCategory = () => {
    editT_MaterialCategoryTitle.value = '添加物料类别';
    editDialogRef.value.openDialog({});
  };

  // 打开编辑页面
  const openEditT_MaterialCategory = (row: any) => {
    editT_MaterialCategoryTitle.value = '编辑物料类别';
    editDialogRef.value.openDialog(row);
  };

  // 删除
  const delT_MaterialCategory = (row: any) => {
    ElMessageBox.confirm(`确定要删除吗?`, "提示", {
    confirmButtonText: "确定",
    cancelButtonText: "取消",
    type: "warning",
  })
  .then(async () => {
    await deleteT_MaterialCategory(row);
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

  const t_MaterialCategoryPIDDropdownList = ref<any>([]); 
  const getT_MaterialCategoryPIDDropdownList = async () => {
    let list = await getT_MaterialCategoryPIDDropdown();
    t_MaterialCategoryPIDDropdownList.value = list.data.result ?? [];
  };
  getT_MaterialCategoryPIDDropdownList();


  handleQuery();
</script>


