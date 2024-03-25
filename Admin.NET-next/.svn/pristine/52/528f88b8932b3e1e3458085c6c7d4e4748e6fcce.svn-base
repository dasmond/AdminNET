import request from '/@/utils/request';
enum Api {
  AddSalesContractMaster = '/api/salesContractMaster/add',
  DeleteSalesContractMaster = '/api/salesContractMaster/delete',
  UpdateSalesContractMaster = '/api/salesContractMaster/update',
  PageSalesContractMaster = '/api/salesContractMaster/page',
  DetailSalesContractMaster = '/api/salesContractMaster/detail',
}

// 增加销售合同主表
export const addSalesContractMaster = (params?: any) =>
	request({
		url: Api.AddSalesContractMaster,
		method: 'post',
		data: params,
	});

// 删除销售合同主表
export const deleteSalesContractMaster = (params?: any) => 
	request({
			url: Api.DeleteSalesContractMaster,
			method: 'post',
			data: params,
		});

// 编辑销售合同主表
export const updateSalesContractMaster = (params?: any) => 
	request({
			url: Api.UpdateSalesContractMaster,
			method: 'post',
			data: params,
		});

// 分页查询销售合同主表
export const pageSalesContractMaster = (params?: any) => 
	request({
			url: Api.PageSalesContractMaster,
			method: 'post',
			data: params,
		});

// 详情销售合同主表
export const detailSalesContractMaster = (id: any) => 
	request({
			url: Api.DetailSalesContractMaster,
			method: 'get',
			data: { id },
		});


