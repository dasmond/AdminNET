import request from '/@/utils/request';
enum Api {
  AddSupplierSalesContractSubsidiary = '/api/supplierSalesContractSubsidiary/add',
  DeleteSupplierSalesContractSubsidiary = '/api/supplierSalesContractSubsidiary/delete',
  UpdateSupplierSalesContractSubsidiary = '/api/supplierSalesContractSubsidiary/update',
  PageSupplierSalesContractSubsidiary = '/api/supplierSalesContractSubsidiary/page',
  DetailSupplierSalesContractSubsidiary = '/api/supplierSalesContractSubsidiary/detail',
}

// 增加供应商销售合同从表
export const addSupplierSalesContractSubsidiary = (params?: any) =>
	request({
		url: Api.AddSupplierSalesContractSubsidiary,
		method: 'post',
		data: params,
	});

// 删除供应商销售合同从表
export const deleteSupplierSalesContractSubsidiary = (params?: any) => 
	request({
			url: Api.DeleteSupplierSalesContractSubsidiary,
			method: 'post',
			data: params,
		});

// 编辑供应商销售合同从表
export const updateSupplierSalesContractSubsidiary = (params?: any) => 
	request({
			url: Api.UpdateSupplierSalesContractSubsidiary,
			method: 'post',
			data: params,
		});

// 分页查询供应商销售合同从表
export const pageSupplierSalesContractSubsidiary = (params?: any) => 
	request({
			url: Api.PageSupplierSalesContractSubsidiary,
			method: 'post',
			data: params,
		});

// 详情供应商销售合同从表
export const detailSupplierSalesContractSubsidiary = (id: any) => 
	request({
			url: Api.DetailSupplierSalesContractSubsidiary,
			method: 'get',
			data: { id },
		});


