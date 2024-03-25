import request from '/@/utils/request';
enum Api {
  AddSupplierAttachments = '/api/supplierAttachments/add',
  DeleteSupplierAttachments = '/api/supplierAttachments/delete',
  UpdateSupplierAttachments = '/api/supplierAttachments/update',
  PageSupplierAttachments = '/api/supplierAttachments/page',
  DetailSupplierAttachments = '/api/supplierAttachments/detail',
}

// 增加供应商附件
export const addSupplierAttachments = (params?: any) =>
	request({
		url: Api.AddSupplierAttachments,
		method: 'post',
		data: params,
	});

// 删除供应商附件
export const deleteSupplierAttachments = (params?: any) => 
	request({
			url: Api.DeleteSupplierAttachments,
			method: 'post',
			data: params,
		});

// 编辑供应商附件
export const updateSupplierAttachments = (params?: any) => 
	request({
			url: Api.UpdateSupplierAttachments,
			method: 'post',
			data: params,
		});

// 分页查询供应商附件
export const pageSupplierAttachments = (params?: any) => 
	request({
			url: Api.PageSupplierAttachments,
			method: 'post',
			data: params,
		});

// 详情供应商附件
export const detailSupplierAttachments = (id: any) => 
	request({
			url: Api.DetailSupplierAttachments,
			method: 'get',
			data: { id },
		});


