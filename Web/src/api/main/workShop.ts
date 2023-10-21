import request from '/@/utils/request';
enum Api {
  AddWorkShop = '/api/workShop/add',
  DeleteWorkShop = '/api/workShop/delete',
  UpdateWorkShop = '/api/workShop/update',
  PageWorkShop = '/api/workShop/page',
  GetOrganizationOrganIdDropdown = '/api/workShop/OrganizationOrganIdDropdown',
}

// 增加车间
export const addWorkShop = (params?: any) =>
	request({
		url: Api.AddWorkShop,
		method: 'post',
		data: params,
	});

// 删除车间
export const deleteWorkShop = (params?: any) => 
	request({
			url: Api.DeleteWorkShop,
			method: 'post',
			data: params,
		});

// 编辑车间
export const updateWorkShop = (params?: any) => 
	request({
			url: Api.UpdateWorkShop,
			method: 'post',
			data: params,
		});

// 分页查询车间
export const pageWorkShop = (params?: any) => 
	request({
			url: Api.PageWorkShop,
			method: 'post',
			data: params,
		});

export const getOrganizationOrganIdDropdown = () =>
		request({
		url: Api.GetOrganizationOrganIdDropdown,
		method: 'get'
		});

