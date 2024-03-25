import request from '/@/utils/request';
enum Api {
  AddProcessingFactorySalesContractSubsidiary = '/api/processingFactorySalesContractSubsidiary/add',
  DeleteProcessingFactorySalesContractSubsidiary = '/api/processingFactorySalesContractSubsidiary/delete',
  UpdateProcessingFactorySalesContractSubsidiary = '/api/processingFactorySalesContractSubsidiary/update',
  PageProcessingFactorySalesContractSubsidiary = '/api/processingFactorySalesContractSubsidiary/page',
  DetailProcessingFactorySalesContractSubsidiary = '/api/processingFactorySalesContractSubsidiary/detail',
}

// 增加加工厂合同从表
export const addProcessingFactorySalesContractSubsidiary = (params?: any) =>
	request({
		url: Api.AddProcessingFactorySalesContractSubsidiary,
		method: 'post',
		data: params,
	});

// 删除加工厂合同从表
export const deleteProcessingFactorySalesContractSubsidiary = (params?: any) => 
	request({
			url: Api.DeleteProcessingFactorySalesContractSubsidiary,
			method: 'post',
			data: params,
		});

// 编辑加工厂合同从表
export const updateProcessingFactorySalesContractSubsidiary = (params?: any) => 
	request({
			url: Api.UpdateProcessingFactorySalesContractSubsidiary,
			method: 'post',
			data: params,
		});

// 分页查询加工厂合同从表
export const pageProcessingFactorySalesContractSubsidiary = (params?: any) => 
	request({
			url: Api.PageProcessingFactorySalesContractSubsidiary,
			method: 'post',
			data: params,
		});

// 详情加工厂合同从表
export const detailProcessingFactorySalesContractSubsidiary = (id: any) => 
	request({
			url: Api.DetailProcessingFactorySalesContractSubsidiary,
			method: 'get',
			data: { id },
		});


