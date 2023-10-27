<template>
  <div class="t_Material-container">
    <el-card shadow="hover" :body-style="{ paddingBottom: '0' }">
      <el-form :model="queryParams" ref="queryForm" :inline="true">
        <el-form-item label="关键字">
          <el-input v-model="queryParams.searchKey" clearable="" placeholder="请输入模糊查询关键字"/>
          
        </el-form-item>
        <el-form-item label="车间ID">
          <el-select clearable="" filterable="" v-model="queryParams.orgID" placeholder="请选择车间ID">
            <el-option v-for="(item,index) in  sysOrgOrgIDDropdownList" :key="index" :value="item.value" :label="item.label" />
            
          </el-select>
          
        </el-form-item>
        <el-form-item label="物料编码">
          <el-input v-model="queryParams.materialCode" clearable="" placeholder="请输入物料编码"/>
          
        </el-form-item>
        <el-form-item label="物料名称">
          <el-input v-model="queryParams.materialName" clearable="" placeholder="请输入物料名称"/>
          
        </el-form-item>
        <el-form-item label="英文名称">
          <el-input v-model="queryParams.materialEngname" clearable="" placeholder="请输入英文名称"/>
          
        </el-form-item>
        <el-form-item label="规格">
          <el-input v-model="queryParams.specification" clearable="" placeholder="请输入规格"/>
          
        </el-form-item>
        <el-form-item label="单位">
          <el-input v-model="queryParams.unit" clearable="" placeholder="请输入单位"/>
          
        </el-form-item>
        <el-form-item label="状态">
          <el-select clearable="" v-model="queryParams.status" placeholder="请选择状态">
            <el-option v-for="(item,index) in getstatusData" :key="index" :value="item.value" :label="item.label" />
            
          </el-select>
          
        </el-form-item>
        <el-form-item label="审核标记">
          <el-select clearable="" v-model="queryParams.flag" placeholder="请选择审核标记">
            <el-option v-for="(item,index) in getflagData" :key="index" :value="item.value" :label="item.label" />
            
          </el-select>
          
        </el-form-item>
        <el-form-item label="审核人">
          <el-date-picker placeholder="请选择审核人" value-format="YYYY/MM/DD" type="daterange" v-model="queryParams.auditTimeRange" />
          
        </el-form-item>
        <el-form-item label="审核者Id">
          <el-input v-model="queryParams.auditUserId" clearable="" placeholder="请输入审核者Id"/>
          
        </el-form-item>
        <el-form-item label="净重">
          <el-input v-model="queryParams.netweight" clearable="" placeholder="请输入净重"/>
          
        </el-form-item>
        <el-form-item label="毛重">
          <el-input v-model="queryParams.grossweight" clearable="" placeholder="请输入毛重"/>
          
        </el-form-item>
        <el-form-item label="体积">
          <el-input v-model="queryParams.cubage" clearable="" placeholder="请输入体积"/>
          
        </el-form-item>
        <el-form-item label="包装件数">
          <el-input v-model="queryParams.packqty" clearable="" placeholder="请输入包装件数"/>
          
        </el-form-item>
        <el-form-item label="物料来源">
          <el-select clearable="" v-model="queryParams.materialOrigin" placeholder="请选择物料来源">
            <el-option v-for="(item,index) in getmaterialOriginData" :key="index" :value="item.value" :label="item.label" />
            
          </el-select>
          
        </el-form-item>
        <el-form-item label="物料属性">
          <el-select clearable="" v-model="queryParams.materialProp" placeholder="请选择物料属性">
            <el-option v-for="(item,index) in getmaterialPropData" :key="index" :value="item.value" :label="item.label" />
            
          </el-select>
          
        </el-form-item>
        <el-form-item label="已使用">
          <el-input v-model="queryParams.inuse" clearable="" placeholder="请输入已使用"/>
          
        </el-form-item>
        <el-form-item>
          <el-button-group>
            <el-button type="primary"  icon="ele-Search" @click="handleQuery" v-auth="'t_Material:page'"> 查询 </el-button>
            <el-button icon="ele-Refresh" @click="() => queryParams = {}"> 重置 </el-button>
            
          </el-button-group>
          
        </el-form-item>
        <el-form-item>
          <el-button type="primary" icon="ele-Plus" @click="openAddT_Material" v-auth="'t_Material:add'"> 新增 </el-button>
          
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
            <span>{{scope.row.orgIDId}}</span>
            
          </template>
          
        </el-table-column>
        <el-table-column prop="materialCode" label="物料编码" width="140" show-overflow-tooltip="" />
        <el-table-column prop="materialName" label="物料名称" width="140" show-overflow-tooltip="" />
        <el-table-column prop="materialEngname" label="英文名称" width="140" show-overflow-tooltip="" />
        <el-table-column prop="specification" label="规格" width="140" show-overflow-tooltip="" />
        <el-table-column prop="unit" label="单位" width="140" show-overflow-tooltip="" />
        <el-table-column prop="status" label="状态" width="140" show-overflow-tooltip="" />
        <el-table-column prop="flag" label="审核标记" width="140" show-overflow-tooltip="" />
        <el-table-column prop="auditTime" label="审核人" width="140" show-overflow-tooltip="" />
        <el-table-column prop="auditUserId" label="审核者Id" width="140" show-overflow-tooltip="" />
        <el-table-column prop="netweight" label="净重" width="140" show-overflow-tooltip="" />
        <el-table-column prop="grossweight" label="毛重" width="140" show-overflow-tooltip="" />
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
        <el-table-column prop="inuse" label="已使用" width="140" show-overflow-tooltip="" />
        <el-table-column prop="storageID" label="默认仓库ID" width="90" show-overflow-tooltip="" />
        <el-table-column prop="spaceID" label="默认仓位ID" width="90" show-overflow-tooltip="" />
        <el-table-column prop="storageLock" label="使用库存分配" width="90" show-overflow-tooltip="" />
        <el-table-column prop="batchcode" label="使用批号" width="120" show-overflow-tooltip="">
          <template #default="scope">
            <el-tag v-if="scope.row.batchcode"> 是 </el-tag>
            <el-tag type="danger" v-else> 否 </el-tag>
            
          </template>
          
        </el-table-column>
        <el-table-column prop="batchrule" label="批号规则" width="140" show-overflow-tooltip="" />
        <el-table-column label="操作" width="140" align="center" fixed="right" show-overflow-tooltip="" v-if="auth('t_Material:edit') || auth('t_Material:delete')">
          <template #default="scope">
            <el-button icon="ele-Edit" size="small" text="" type="primary" @click="openEditT_Material(scope.row)" v-auth="'t_Material:edit'"> 编辑 </el-button>
            <el-button icon="ele-Delete" size="small" text="" type="primary" @click="delT_Material(scope.row)" v-auth="'t_Material:delete'"> 删除 </el-button>
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
        :title="editT_MaterialTitle"
        @reloadTable="handleQuery"
      />
    </el-card>
  </div>
</template>

<script lang="ts" setup="" name="t_Material">
  import { ref } from "vue";
  import { ElMessageBox, ElMessage } from "element-plus";
  import { auth } from '/@/utils/authFunction';
  //import { formatDate } from '/@/utils/formatTime';

  import editDialog from '/@/views/main/t_Material/component/editDialog.vue'
  import { pageT_Material, deleteT_Material } from '/@/api/main/t_Material';
  import { getSysOrgOrgIDDropdown } from '/@/api/main/t_Material';
  import { getDictDataList } from '/@/api/system/admin';

  const getstatusData = ref<any>([]);
  const getflagData = ref<any>([]);
  const getmaterialOriginData = ref<any>([]);
  const getmaterialPropData = ref<any>([]);

  const editDialogRef = ref();
  const loading = ref(false);
  const tableData = ref<any>([]);
  const queryParams = ref<any>({});
  const tableParams = ref({
  page: 1,
  pageSize: 10,
  total: 0,
  });
  const editT_MaterialTitle = ref("");


  // 查询操作
  const handleQuery = async () => {
    loading.value = true;
    var res = await pageT_Material(Object.assign(queryParams.value, tableParams.value));
    tableData.value = res.data.result?.items ?? [];
    tableParams.value.total = res.data.result?.total;
    loading.value = false;
    getstatusData.value = await dictTypeDataList('IfAllowed');
    getflagData.value = await dictTypeDataList('IfAllowed');
    getmaterialOriginData.value = await dictTypeDataList('materialorigin');
    getmaterialPropData.value = await dictTypeDataList('materialorigin');
  };

  // 打开新增页面
  const openAddT_Material = () => {
    editT_MaterialTitle.value = '添加物料管理';
    editDialogRef.value.openDialog({});
  };

  // 打开编辑页面
  const openEditT_Material = (row: any) => {
    editT_MaterialTitle.value = '编辑物料管理';
    editDialogRef.value.openDialog(row);
  };

  // 删除
  const delT_Material = (row: any) => {
    ElMessageBox.confirm(`确定要删除吗?`, "提示", {
    confirmButtonText: "确定",
    cancelButtonText: "取消",
    type: "warning",
  })
  .then(async () => {
    await deleteT_Material(row);
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

  const sysOrgOrgIDDropdownList = ref<any>([]); 
  const getSysOrgOrgIDDropdownList = async () => {
    let list = await getSysOrgOrgIDDropdown();
    sysOrgOrgIDDropdownList.value = list.data.result ?? [];
  };
  getSysOrgOrgIDDropdownList();


    const dictTypeDataList = async (val: any) => {
      let list = await getDictDataList(val);
      return list.data.result ?? [];
    };
  handleQuery();
</script>


