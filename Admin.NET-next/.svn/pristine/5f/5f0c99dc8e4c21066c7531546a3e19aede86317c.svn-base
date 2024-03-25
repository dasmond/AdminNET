import request from '/@/utils/request';
enum Api {
  AddSupplierRejectionOrder = '/api/supplierRejectionOrder/add',
  DeleteSupplierRejectionOrder = '/api/supplierRejectionOrder/delete',
  UpdateSupplierRejectionOrder = '/api/supplierRejectionOrder/update',
  PageSupplierRejectionOrder = '/api/supplierRejectionOrder/page',
  DetailSupplierRejectionOrder = '/api/supplierRejectionOrder/detail',
}

// 增加供应商拒收订单
export const addSupplierRejectionOrder = (params?: any) =>
	request({
		url: Api.AddSupplierRejectionOrder,
		method: 'post',
		data: params,
	});

// 删除供应商拒收订单
export const deleteSupplierRejectionOrder = (params?: any) => 
	request({
			url: Api.DeleteSupplierRejectionOrder,
			method: 'post',
			data: params,
		});

// 编辑供应商拒收订单
export const updateSupplierRejectionOrder = (params?: any) => 
	request({
			url: Api.UpdateSupplierRejectionOrder,
			method: 'post',
			data: params,
		});

// 分页查询供应商拒收订单
export const pageSupplierRejectionOrder = (params?: any) => 
	request({
			url: Api.PageSupplierRejectionOrder,
			method: 'post',
			data: params,
		});

// 详情供应商拒收订单
export const detailSupplierRejectionOrder = (id: any) => 
	request({
			url: Api.DetailSupplierRejectionOrder,
			method: 'get',
			data: { id },
		});


