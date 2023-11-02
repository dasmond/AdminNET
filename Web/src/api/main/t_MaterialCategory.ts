import request from '/@/utils/request';
enum Api {
  AddT_MaterialCategory = '/api/t_MaterialCategory/add',
  DeleteT_MaterialCategory = '/api/t_MaterialCategory/delete',
  UpdateT_MaterialCategory = '/api/t_MaterialCategory/update',
  PageT_MaterialCategory = '/api/t_MaterialCategory/page',
  GetT_WorkShopOrgIDDropdown = '/api/t_MaterialCategory/T_WorkShopOrgIDDropdown',
  GetT_MaterialCategoryPIDDropdown = '/api/t_MaterialCategory/T_MaterialCategoryPIDDropdown',
}

// 增加物料类别
export const addT_MaterialCategory = (params?: any) =>
	request({
		url: Api.AddT_MaterialCategory,
		method: 'post',
		data: params,
	});

// 删除物料类别
export const deleteT_MaterialCategory = (params?: any) => 
	request({
			url: Api.DeleteT_MaterialCategory,
			method: 'post',
			data: params,
		});

// 编辑物料类别
export const updateT_MaterialCategory = (params?: any) => 
	request({
			url: Api.UpdateT_MaterialCategory,
			method: 'post',
			data: params,
		});

// 分页查询物料类别
export const pageT_MaterialCategory = (params?: any) => 
	request({
			url: Api.PageT_MaterialCategory,
			method: 'post',
			data: params,
		});

export const getT_WorkShopOrgIDDropdown = () =>
		request({
		url: Api.GetT_WorkShopOrgIDDropdown,
		method: 'get'
		});
export const getT_MaterialCategoryPIDDropdown = () =>
		request({
		url: Api.GetT_MaterialCategoryPIDDropdown,
		method: 'get'
		});

