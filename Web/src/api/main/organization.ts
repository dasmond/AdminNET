import request from '/@/utils/request';
enum Api {
  AddOrganization = '/api/organization/add',
  DeleteOrganization = '/api/organization/delete',
  UpdateOrganization = '/api/organization/update',
  PageOrganization = '/api/organization/page',
}

// 增加组织
export const addOrganization = (params?: any) =>
	request({
		url: Api.AddOrganization,
		method: 'post',
		data: params,
	});

// 删除组织
export const deleteOrganization = (params?: any) => 
	request({
			url: Api.DeleteOrganization,
			method: 'post',
			data: params,
		});

// 编辑组织
export const updateOrganization = (params?: any) => 
	request({
			url: Api.UpdateOrganization,
			method: 'post',
			data: params,
		});

// 分页查询组织
export const pageOrganization = (params?: any) => 
	request({
			url: Api.PageOrganization,
			method: 'post',
			data: params,
		});


