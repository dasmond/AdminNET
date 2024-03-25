import request from '/@/utils/request';
enum Api {
  AddFeedback = '/api/feedback/add',
  DeleteFeedback = '/api/feedback/delete',
  UpdateFeedback = '/api/feedback/update',
  PageFeedback = '/api/feedback/page',
  DetailFeedback = '/api/feedback/detail',
}

// 增加反馈表
export const addFeedback = (params?: any) =>
	request({
		url: Api.AddFeedback,
		method: 'post',
		data: params,
	});

// 删除反馈表
export const deleteFeedback = (params?: any) => 
	request({
			url: Api.DeleteFeedback,
			method: 'post',
			data: params,
		});

// 编辑反馈表
export const updateFeedback = (params?: any) => 
	request({
			url: Api.UpdateFeedback,
			method: 'post',
			data: params,
		});

// 分页查询反馈表
export const pageFeedback = (params?: any) => 
	request({
			url: Api.PageFeedback,
			method: 'post',
			data: params,
		});

// 详情反馈表
export const detailFeedback = (id: any) => 
	request({
			url: Api.DetailFeedback,
			method: 'get',
			data: { id },
		});


