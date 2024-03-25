import request from '/@/utils/request';
enum Api {
  AddProcessOrder = '/api/processOrder/add',
  DeleteProcessOrder = '/api/processOrder/delete',
  UpdateProcessOrder = '/api/processOrder/update',
  PageProcessOrder = '/api/processOrder/page',
  DetailProcessOrder = '/api/processOrder/detail',
}

// 增加加工订单
export const addProcessOrder = (params?: any) =>
	request({
		url: Api.AddProcessOrder,
		method: 'post',
		data: params,
	});

// 删除加工订单
export const deleteProcessOrder = (params?: any) => 
	request({
			url: Api.DeleteProcessOrder,
			method: 'post',
			data: params,
		});

// 编辑加工订单
export const updateProcessOrder = (params?: any) => 
	request({
			url: Api.UpdateProcessOrder,
			method: 'post',
			data: params,
		});

// 分页查询加工订单
export const pageProcessOrder = (params?: any) => 
	request({
			url: Api.PageProcessOrder,
			method: 'post',
			data: params,
		});

// 详情加工订单
export const detailProcessOrder = (id: any) => 
	request({
			url: Api.DetailProcessOrder,
			method: 'get',
			data: { id },
		});


