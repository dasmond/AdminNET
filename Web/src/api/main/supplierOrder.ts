import request from '/@/utils/request';
enum Api {
  AddSupplierOrder = '/api/supplierOrder/add',
  DeleteSupplierOrder = '/api/supplierOrder/delete',
  UpdateSupplierOrder = '/api/supplierOrder/update',
  PageSupplierOrder = '/api/supplierOrder/page',
  DetailSupplierOrder = '/api/supplierOrder/detail',
}

// 增加供应商订单
export const addSupplierOrder = (params?: any) =>
	request({
		url: Api.AddSupplierOrder,
		method: 'post',
		data: params,
	});

// 删除供应商订单
export const deleteSupplierOrder = (params?: any) => 
	request({
			url: Api.DeleteSupplierOrder,
			method: 'post',
			data: params,
		});

// 编辑供应商订单
export const updateSupplierOrder = (params?: any) => 
	request({
			url: Api.UpdateSupplierOrder,
			method: 'post',
			data: params,
		});

// 分页查询供应商订单
export const pageSupplierOrder = (params?: any) => 
	request({
			url: Api.PageSupplierOrder,
			method: 'post',
			data: params,
		});

// 详情供应商订单
export const detailSupplierOrder = (id: any) => 
	request({
			url: Api.DetailSupplierOrder,
			method: 'get',
			data: { id },
		});


