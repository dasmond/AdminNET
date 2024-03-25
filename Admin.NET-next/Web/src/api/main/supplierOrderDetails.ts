import request from '/@/utils/request';
enum Api {
  AddSupplierOrderDetails = '/api/supplierOrderDetails/add',
  DeleteSupplierOrderDetails = '/api/supplierOrderDetails/delete',
  UpdateSupplierOrderDetails = '/api/supplierOrderDetails/update',
  PageSupplierOrderDetails = '/api/supplierOrderDetails/page',
  DetailSupplierOrderDetails = '/api/supplierOrderDetails/detail',
}

// 增加供应商入库订单详情
export const addSupplierOrderDetails = (params?: any) =>
	request({
		url: Api.AddSupplierOrderDetails,
		method: 'post',
		data: params,
	});

// 删除供应商入库订单详情
export const deleteSupplierOrderDetails = (params?: any) => 
	request({
			url: Api.DeleteSupplierOrderDetails,
			method: 'post',
			data: params,
		});

// 编辑供应商入库订单详情
export const updateSupplierOrderDetails = (params?: any) => 
	request({
			url: Api.UpdateSupplierOrderDetails,
			method: 'post',
			data: params,
		});

// 分页查询供应商入库订单详情
export const pageSupplierOrderDetails = (params?: any) => 
	request({
			url: Api.PageSupplierOrderDetails,
			method: 'post',
			data: params,
		});

// 详情供应商入库订单详情
export const detailSupplierOrderDetails = (id: any) => 
	request({
			url: Api.DetailSupplierOrderDetails,
			method: 'get',
			data: { id },
		});


