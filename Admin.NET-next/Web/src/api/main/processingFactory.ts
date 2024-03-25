import request from '/@/utils/request';
enum Api {
  AddProcessingFactory = '/api/processingFactory/add',
  DeleteProcessingFactory = '/api/processingFactory/delete',
  UpdateProcessingFactory = '/api/processingFactory/update',
  PageProcessingFactory = '/api/processingFactory/page',
  DetailProcessingFactory = '/api/processingFactory/detail',
}

// 增加加工厂资料
export const addProcessingFactory = (params?: any) =>
	request({
		url: Api.AddProcessingFactory,
		method: 'post',
		data: params,
	});

// 删除加工厂资料
export const deleteProcessingFactory = (params?: any) => 
	request({
			url: Api.DeleteProcessingFactory,
			method: 'post',
			data: params,
		});

// 编辑加工厂资料
export const updateProcessingFactory = (params?: any) => 
	request({
			url: Api.UpdateProcessingFactory,
			method: 'post',
			data: params,
		});

// 分页查询加工厂资料
export const pageProcessingFactory = (params?: any) => 
	request({
			url: Api.PageProcessingFactory,
			method: 'post',
			data: params,
		});

// 详情加工厂资料
export const detailProcessingFactory = (id: any) => 
	request({
			url: Api.DetailProcessingFactory,
			method: 'get',
			data: { id },
		});


