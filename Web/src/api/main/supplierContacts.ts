import request from '/@/utils/request';
enum Api {
  AddSupplierContacts = '/api/supplierContacts/add',
  DeleteSupplierContacts = '/api/supplierContacts/delete',
  UpdateSupplierContacts = '/api/supplierContacts/update',
  PageSupplierContacts = '/api/supplierContacts/page',
  DetailSupplierContacts = '/api/supplierContacts/detail',
}

// 增加供应商联系人资料
export const addSupplierContacts = (params?: any) =>
	request({
		url: Api.AddSupplierContacts,
		method: 'post',
		data: params,
	});

// 删除供应商联系人资料
export const deleteSupplierContacts = (params?: any) => 
	request({
			url: Api.DeleteSupplierContacts,
			method: 'post',
			data: params,
		});

// 编辑供应商联系人资料
export const updateSupplierContacts = (params?: any) => 
	request({
			url: Api.UpdateSupplierContacts,
			method: 'post',
			data: params,
		});

// 分页查询供应商联系人资料
export const pageSupplierContacts = (params?: any) => 
	request({
			url: Api.PageSupplierContacts,
			method: 'post',
			data: params,
		});

// 详情供应商联系人资料
export const detailSupplierContacts = (id: any) => 
	request({
			url: Api.DetailSupplierContacts,
			method: 'get',
			data: { id },
		});


