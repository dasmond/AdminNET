import request from '/@/utils/request';
enum Api {
  AddProcessingFactoryPriceReporting = '/api/processingFactoryPriceReporting/add',
  DeleteProcessingFactoryPriceReporting = '/api/processingFactoryPriceReporting/delete',
  UpdateProcessingFactoryPriceReporting = '/api/processingFactoryPriceReporting/update',
  PageProcessingFactoryPriceReporting = '/api/processingFactoryPriceReporting/page',
  DetailProcessingFactoryPriceReporting = '/api/processingFactoryPriceReporting/detail',
}

// 增加加工厂价格报备表
export const addProcessingFactoryPriceReporting = (params?: any) =>
	request({
		url: Api.AddProcessingFactoryPriceReporting,
		method: 'post',
		data: params,
	});

// 删除加工厂价格报备表
export const deleteProcessingFactoryPriceReporting = (params?: any) => 
	request({
			url: Api.DeleteProcessingFactoryPriceReporting,
			method: 'post',
			data: params,
		});

// 编辑加工厂价格报备表
export const updateProcessingFactoryPriceReporting = (params?: any) => 
	request({
			url: Api.UpdateProcessingFactoryPriceReporting,
			method: 'post',
			data: params,
		});

// 分页查询加工厂价格报备表
export const pageProcessingFactoryPriceReporting = (params?: any) => 
	request({
			url: Api.PageProcessingFactoryPriceReporting,
			method: 'post',
			data: params,
		});

// 详情加工厂价格报备表
export const detailProcessingFactoryPriceReporting = (id: any) => 
	request({
			url: Api.DetailProcessingFactoryPriceReporting,
			method: 'get',
			data: { id },
		});


