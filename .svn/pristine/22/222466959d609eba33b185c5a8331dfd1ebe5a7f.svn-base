import request from '/@/utils/request';
enum Api {
  AddProcessOrderDetails = '/api/processOrderDetails/add',
  DeleteProcessOrderDetails = '/api/processOrderDetails/delete',
  UpdateProcessOrderDetails = '/api/processOrderDetails/update',
  PageProcessOrderDetails = '/api/processOrderDetails/page',
  DetailProcessOrderDetails = '/api/processOrderDetails/detail',
}

// 增加加工订单详情
export const addProcessOrderDetails = (params?: any) =>
	request({
		url: Api.AddProcessOrderDetails,
		method: 'post',
		data: params,
	});

// 删除加工订单详情
export const deleteProcessOrderDetails = (params?: any) => 
	request({
			url: Api.DeleteProcessOrderDetails,
			method: 'post',
			data: params,
		});

// 编辑加工订单详情
export const updateProcessOrderDetails = (params?: any) => 
	request({
			url: Api.UpdateProcessOrderDetails,
			method: 'post',
			data: params,
		});

// 分页查询加工订单详情
export const pageProcessOrderDetails = (params?: any) => 
	request({
			url: Api.PageProcessOrderDetails,
			method: 'post',
			data: params,
		});

// 详情加工订单详情
export const detailProcessOrderDetails = (id: any) => 
	request({
			url: Api.DetailProcessOrderDetails,
			method: 'get',
			data: { id },
		});


