import request from '/@/utils/request';
enum Api {
  AddProcessingRejectionOrderDetails = '/api/processingRejectionOrderDetails/add',
  DeleteProcessingRejectionOrderDetails = '/api/processingRejectionOrderDetails/delete',
  UpdateProcessingRejectionOrderDetails = '/api/processingRejectionOrderDetails/update',
  PageProcessingRejectionOrderDetails = '/api/processingRejectionOrderDetails/page',
  DetailProcessingRejectionOrderDetails = '/api/processingRejectionOrderDetails/detail',
}

// 增加加工拒收订单详情
export const addProcessingRejectionOrderDetails = (params?: any) =>
	request({
		url: Api.AddProcessingRejectionOrderDetails,
		method: 'post',
		data: params,
	});

// 删除加工拒收订单详情
export const deleteProcessingRejectionOrderDetails = (params?: any) => 
	request({
			url: Api.DeleteProcessingRejectionOrderDetails,
			method: 'post',
			data: params,
		});

// 编辑加工拒收订单详情
export const updateProcessingRejectionOrderDetails = (params?: any) => 
	request({
			url: Api.UpdateProcessingRejectionOrderDetails,
			method: 'post',
			data: params,
		});

// 分页查询加工拒收订单详情
export const pageProcessingRejectionOrderDetails = (params?: any) => 
	request({
			url: Api.PageProcessingRejectionOrderDetails,
			method: 'post',
			data: params,
		});

// 详情加工拒收订单详情
export const detailProcessingRejectionOrderDetails = (id: any) => 
	request({
			url: Api.DetailProcessingRejectionOrderDetails,
			method: 'get',
			data: { id },
		});


