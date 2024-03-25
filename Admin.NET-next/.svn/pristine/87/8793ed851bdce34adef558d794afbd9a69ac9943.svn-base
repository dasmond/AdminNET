import request from '/@/utils/request';
enum Api {
  AddCustomerBusinessCard = '/api/customerBusinessCard/add',
  DeleteCustomerBusinessCard = '/api/customerBusinessCard/delete',
  UpdateCustomerBusinessCard = '/api/customerBusinessCard/update',
  PageCustomerBusinessCard = '/api/customerBusinessCard/page',
  DetailCustomerBusinessCard = '/api/customerBusinessCard/detail',
}

// 增加客户名片
export const addCustomerBusinessCard = (params?: any) =>
	request({
		url: Api.AddCustomerBusinessCard,
		method: 'post',
		data: params,
	});

// 删除客户名片
export const deleteCustomerBusinessCard = (params?: any) => 
	request({
			url: Api.DeleteCustomerBusinessCard,
			method: 'post',
			data: params,
		});

// 编辑客户名片
export const updateCustomerBusinessCard = (params?: any) => 
	request({
			url: Api.UpdateCustomerBusinessCard,
			method: 'post',
			data: params,
		});

// 分页查询客户名片
export const pageCustomerBusinessCard = (params?: any) => 
	request({
			url: Api.PageCustomerBusinessCard,
			method: 'post',
			data: params,
		});

// 详情客户名片
export const detailCustomerBusinessCard = (id: any) => 
	request({
			url: Api.DetailCustomerBusinessCard,
			method: 'get',
			data: { id },
		});


