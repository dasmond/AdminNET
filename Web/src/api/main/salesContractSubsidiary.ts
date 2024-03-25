import request from '/@/utils/request';
enum Api {
  AddSalesContractSubsidiary = '/api/salesContractSubsidiary/add',
  DeleteSalesContractSubsidiary = '/api/salesContractSubsidiary/delete',
  UpdateSalesContractSubsidiary = '/api/salesContractSubsidiary/update',
  PageSalesContractSubsidiary = '/api/salesContractSubsidiary/page',
  DetailSalesContractSubsidiary = '/api/salesContractSubsidiary/detail',
}

// 增加销售合同从表
export const addSalesContractSubsidiary = (params?: any) =>
	request({
		url: Api.AddSalesContractSubsidiary,
		method: 'post',
		data: params,
	});

// 删除销售合同从表
export const deleteSalesContractSubsidiary = (params?: any) => 
	request({
			url: Api.DeleteSalesContractSubsidiary,
			method: 'post',
			data: params,
		});

// 编辑销售合同从表
export const updateSalesContractSubsidiary = (params?: any) => 
	request({
			url: Api.UpdateSalesContractSubsidiary,
			method: 'post',
			data: params,
		});

// 分页查询销售合同从表
export const pageSalesContractSubsidiary = (params?: any) => 
	request({
			url: Api.PageSalesContractSubsidiary,
			method: 'post',
			data: params,
		});

// 详情销售合同从表
export const detailSalesContractSubsidiary = (id: any) => 
	request({
			url: Api.DetailSalesContractSubsidiary,
			method: 'get',
			data: { id },
		});


