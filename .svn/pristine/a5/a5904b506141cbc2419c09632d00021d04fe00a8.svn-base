import request from '/@/utils/request';
enum Api {
  AddConnectionFeedback = '/api/connectionFeedback/add',
  DeleteConnectionFeedback = '/api/connectionFeedback/delete',
  UpdateConnectionFeedback = '/api/connectionFeedback/update',
  PageConnectionFeedback = '/api/connectionFeedback/page',
  DetailConnectionFeedback = '/api/connectionFeedback/detail',
}

// 增加客户反馈表
export const addConnectionFeedback = (params?: any) =>
	request({
		url: Api.AddConnectionFeedback,
		method: 'post',
		data: params,
	});

// 删除客户反馈表
export const deleteConnectionFeedback = (params?: any) => 
	request({
			url: Api.DeleteConnectionFeedback,
			method: 'post',
			data: params,
		});

// 编辑客户反馈表
export const updateConnectionFeedback = (params?: any) => 
	request({
			url: Api.UpdateConnectionFeedback,
			method: 'post',
			data: params,
		});

// 分页查询客户反馈表
export const pageConnectionFeedback = (params?: any) => 
	request({
			url: Api.PageConnectionFeedback,
			method: 'post',
			data: params,
		});

// 详情客户反馈表
export const detailConnectionFeedback = (id: any) => 
	request({
			url: Api.DetailConnectionFeedback,
			method: 'get',
			data: { id },
		});


