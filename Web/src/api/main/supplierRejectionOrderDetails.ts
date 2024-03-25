import request from '/@/utils/request';
enum Api {
  AddSupplierRejectionOrderDetails = '/api/supplierRejectionOrderDetails/add',
  DeleteSupplierRejectionOrderDetails = '/api/supplierRejectionOrderDetails/delete',
  UpdateSupplierRejectionOrderDetails = '/api/supplierRejectionOrderDetails/update',
  PageSupplierRejectionOrderDetails = '/api/supplierRejectionOrderDetails/page',
  DetailSupplierRejectionOrderDetails = '/api/supplierRejectionOrderDetails/detail',
}

// 增加供应商拒收订单详情
export const addSupplierRejectionOrderDetails = (params?: any) =>
	request({
		url: Api.AddSupplierRejectionOrderDetails,
		method: 'post',
		data: params,
	});

// 删除供应商拒收订单详情
export const deleteSupplierRejectionOrderDetails = (params?: any) => 
	request({
			url: Api.DeleteSupplierRejectionOrderDetails,
			method: 'post',
			data: params,
		});

// 编辑供应商拒收订单详情
export const updateSupplierRejectionOrderDetails = (params?: any) => 
	request({
			url: Api.UpdateSupplierRejectionOrderDetails,
			method: 'post',
			data: params,
		});

// 分页查询供应商拒收订单详情
export const pageSupplierRejectionOrderDetails = (params?: any) => 
	request({
			url: Api.PageSupplierRejectionOrderDetails,
			method: 'post',
			data: params,
		});

// 详情供应商拒收订单详情
export const detailSupplierRejectionOrderDetails = (id: any) => 
	request({
			url: Api.DetailSupplierRejectionOrderDetails,
			method: 'get',
			data: { id },
		});


