import request from '/@/utils/request';
enum Api {
  AddSupplierSalesContractMaster = '/api/supplierSalesContractMaster/add',
  DeleteSupplierSalesContractMaster = '/api/supplierSalesContractMaster/delete',
  UpdateSupplierSalesContractMaster = '/api/supplierSalesContractMaster/update',
  PageSupplierSalesContractMaster = '/api/supplierSalesContractMaster/page',
  DetailSupplierSalesContractMaster = '/api/supplierSalesContractMaster/detail',
}

// 增加供应商销售合同主表
export const addSupplierSalesContractMaster = (params?: any) =>
	request({
		url: Api.AddSupplierSalesContractMaster,
		method: 'post',
		data: params,
	});

// 删除供应商销售合同主表
export const deleteSupplierSalesContractMaster = (params?: any) => 
	request({
			url: Api.DeleteSupplierSalesContractMaster,
			method: 'post',
			data: params,
		});

// 编辑供应商销售合同主表
export const updateSupplierSalesContractMaster = (params?: any) => 
	request({
			url: Api.UpdateSupplierSalesContractMaster,
			method: 'post',
			data: params,
		});

// 分页查询供应商销售合同主表
export const pageSupplierSalesContractMaster = (params?: any) => 
	request({
			url: Api.PageSupplierSalesContractMaster,
			method: 'post',
			data: params,
		});

// 详情供应商销售合同主表
export const detailSupplierSalesContractMaster = (id: any) => 
	request({
			url: Api.DetailSupplierSalesContractMaster,
			method: 'get',
			data: { id },
		});


