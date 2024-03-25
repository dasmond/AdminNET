import request from '/@/utils/request';
enum Api {
  AddCustomerOrganizeDetails = '/api/customerOrganizeDetails/add',
  DeleteCustomerOrganizeDetails = '/api/customerOrganizeDetails/delete',
  UpdateCustomerOrganizeDetails = '/api/customerOrganizeDetails/update',
  PageCustomerOrganizeDetails = '/api/customerOrganizeDetails/page',
  DetailCustomerOrganizeDetails = '/api/customerOrganizeDetails/detail',
}

// 增加客户组-详情表
export const addCustomerOrganizeDetails = (params?: any) =>
	request({
		url: Api.AddCustomerOrganizeDetails,
		method: 'post',
		data: params,
	});

// 删除客户组-详情表
export const deleteCustomerOrganizeDetails = (params?: any) => 
	request({
			url: Api.DeleteCustomerOrganizeDetails,
			method: 'post',
			data: params,
		});

// 编辑客户组-详情表
export const updateCustomerOrganizeDetails = (params?: any) => 
	request({
			url: Api.UpdateCustomerOrganizeDetails,
			method: 'post',
			data: params,
		});

// 分页查询客户组-详情表
export const pageCustomerOrganizeDetails = (params?: any) => 
	request({
			url: Api.PageCustomerOrganizeDetails,
			method: 'post',
			data: params,
		});

// 详情客户组-详情表
export const detailCustomerOrganizeDetails = (id: any) => 
	request({
			url: Api.DetailCustomerOrganizeDetails,
			method: 'get',
			data: { id },
		});


