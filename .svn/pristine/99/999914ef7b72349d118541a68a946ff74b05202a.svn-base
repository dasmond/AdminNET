import request from '/@/utils/request';
enum Api {
  AddSupplierPriceReporting = '/api/supplierPriceReporting/add',
  DeleteSupplierPriceReporting = '/api/supplierPriceReporting/delete',
  UpdateSupplierPriceReporting = '/api/supplierPriceReporting/update',
  PageSupplierPriceReporting = '/api/supplierPriceReporting/page',
  DetailSupplierPriceReporting = '/api/supplierPriceReporting/detail',
}

// 增加供应商价格报备表
export const addSupplierPriceReporting = (params?: any) =>
	request({
		url: Api.AddSupplierPriceReporting,
		method: 'post',
		data: params,
	});

// 删除供应商价格报备表
export const deleteSupplierPriceReporting = (params?: any) => 
	request({
			url: Api.DeleteSupplierPriceReporting,
			method: 'post',
			data: params,
		});

// 编辑供应商价格报备表
export const updateSupplierPriceReporting = (params?: any) => 
	request({
			url: Api.UpdateSupplierPriceReporting,
			method: 'post',
			data: params,
		});

// 分页查询供应商价格报备表
export const pageSupplierPriceReporting = (params?: any) => 
	request({
			url: Api.PageSupplierPriceReporting,
			method: 'post',
			data: params,
		});

// 详情供应商价格报备表
export const detailSupplierPriceReporting = (id: any) => 
	request({
			url: Api.DetailSupplierPriceReporting,
			method: 'get',
			data: { id },
		});


