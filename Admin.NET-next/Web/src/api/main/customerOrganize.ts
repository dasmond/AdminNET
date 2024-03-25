import request from '/@/utils/request';
enum Api {
  AddCustomerOrganize = '/api/customerOrganize/add',
  DeleteCustomerOrganize = '/api/customerOrganize/delete',
  UpdateCustomerOrganize = '/api/customerOrganize/update',
  PageCustomerOrganize = '/api/customerOrganize/page',
  DetailCustomerOrganize = '/api/customerOrganize/detail',
}

// 增加客户组
export const addCustomerOrganize = (params?: any) =>
	request({
		url: Api.AddCustomerOrganize,
		method: 'post',
		data: params,
	});

// 删除客户组
export const deleteCustomerOrganize = (params?: any) => 
	request({
			url: Api.DeleteCustomerOrganize,
			method: 'post',
			data: params,
		});

// 编辑客户组
export const updateCustomerOrganize = (params?: any) => 
	request({
			url: Api.UpdateCustomerOrganize,
			method: 'post',
			data: params,
		});

// 分页查询客户组
export const pageCustomerOrganize = (params?: any) => 
	request({
			url: Api.PageCustomerOrganize,
			method: 'post',
			data: params,
		});

// 详情客户组
export const detailCustomerOrganize = (id: any) => 
	request({
			url: Api.DetailCustomerOrganize,
			method: 'get',
			data: { id },
		});


