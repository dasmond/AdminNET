import request from '/@/utils/request';
enum Api {
  AddProcessingRejectionOrder = '/api/processingRejectionOrder/add',
  DeleteProcessingRejectionOrder = '/api/processingRejectionOrder/delete',
  UpdateProcessingRejectionOrder = '/api/processingRejectionOrder/update',
  PageProcessingRejectionOrder = '/api/processingRejectionOrder/page',
  DetailProcessingRejectionOrder = '/api/processingRejectionOrder/detail',
}

// 增加加工拒收订单
export const addProcessingRejectionOrder = (params?: any) =>
	request({
		url: Api.AddProcessingRejectionOrder,
		method: 'post',
		data: params,
	});

// 删除加工拒收订单
export const deleteProcessingRejectionOrder = (params?: any) => 
	request({
			url: Api.DeleteProcessingRejectionOrder,
			method: 'post',
			data: params,
		});

// 编辑加工拒收订单
export const updateProcessingRejectionOrder = (params?: any) => 
	request({
			url: Api.UpdateProcessingRejectionOrder,
			method: 'post',
			data: params,
		});

// 分页查询加工拒收订单
export const pageProcessingRejectionOrder = (params?: any) => 
	request({
			url: Api.PageProcessingRejectionOrder,
			method: 'post',
			data: params,
		});

// 详情加工拒收订单
export const detailProcessingRejectionOrder = (id: any) => 
	request({
			url: Api.DetailProcessingRejectionOrder,
			method: 'get',
			data: { id },
		});


