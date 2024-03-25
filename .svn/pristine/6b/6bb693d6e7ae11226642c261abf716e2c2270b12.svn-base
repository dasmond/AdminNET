import request from '/@/utils/request';
enum Api {
  AddProcessingFactorySalesContractMaster = '/api/processingFactorySalesContractMaster/add',
  DeleteProcessingFactorySalesContractMaster = '/api/processingFactorySalesContractMaster/delete',
  UpdateProcessingFactorySalesContractMaster = '/api/processingFactorySalesContractMaster/update',
  PageProcessingFactorySalesContractMaster = '/api/processingFactorySalesContractMaster/page',
  DetailProcessingFactorySalesContractMaster = '/api/processingFactorySalesContractMaster/detail',
}

// 增加加工厂合同主表
export const addProcessingFactorySalesContractMaster = (params?: any) =>
	request({
		url: Api.AddProcessingFactorySalesContractMaster,
		method: 'post',
		data: params,
	});

// 删除加工厂合同主表
export const deleteProcessingFactorySalesContractMaster = (params?: any) => 
	request({
			url: Api.DeleteProcessingFactorySalesContractMaster,
			method: 'post',
			data: params,
		});

// 编辑加工厂合同主表
export const updateProcessingFactorySalesContractMaster = (params?: any) => 
	request({
			url: Api.UpdateProcessingFactorySalesContractMaster,
			method: 'post',
			data: params,
		});

// 分页查询加工厂合同主表
export const pageProcessingFactorySalesContractMaster = (params?: any) => 
	request({
			url: Api.PageProcessingFactorySalesContractMaster,
			method: 'post',
			data: params,
		});

// 详情加工厂合同主表
export const detailProcessingFactorySalesContractMaster = (id: any) => 
	request({
			url: Api.DetailProcessingFactorySalesContractMaster,
			method: 'get',
			data: { id },
		});


