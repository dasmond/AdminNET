import request from '/@/utils/request';
enum Api {
  AddCustomer = '/api/customer/add',
  DeleteCustomer = '/api/customer/delete',
  UpdateCustomer = '/api/customer/update',
  PageCustomer = '/api/customer/page',
  DetailCustomer = '/api/customer/detail',
}

// 增加客户资料
export const addCustomer = (params?: any) =>
	request({
		url: Api.AddCustomer,
		method: 'post',
		data: params,
	});

// 删除客户资料
export const deleteCustomer = (params?: any) => 
	request({
			url: Api.DeleteCustomer,
			method: 'post',
			data: params,
		});

// 编辑客户资料
export const updateCustomer = (params?: any) => 
	request({
			url: Api.UpdateCustomer,
			method: 'post',
			data: params,
		});

// 分页查询客户资料
export const pageCustomer = (params?: any) => 
	request({
			url: Api.PageCustomer,
			method: 'post',
			data: params,
		});

// 详情客户资料
export const detailCustomer = (id: any) => 
	request({
			url: Api.DetailCustomer,
			method: 'get',
			data: { id },
		});


