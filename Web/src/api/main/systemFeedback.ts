import request from '/@/utils/request';
enum Api {
  AddSystemFeedback = '/api/systemFeedback/add',
  DeleteSystemFeedback = '/api/systemFeedback/delete',
  UpdateSystemFeedback = '/api/systemFeedback/update',
  PageSystemFeedback = '/api/systemFeedback/page',
  DetailSystemFeedback = '/api/systemFeedback/detail',
}

// 增加系统反馈
export const addSystemFeedback = (params?: any) =>
	request({
		url: Api.AddSystemFeedback,
		method: 'post',
		data: params,
	});

// 删除系统反馈
export const deleteSystemFeedback = (params?: any) => 
	request({
			url: Api.DeleteSystemFeedback,
			method: 'post',
			data: params,
		});

// 编辑系统反馈
export const updateSystemFeedback = (params?: any) => 
	request({
			url: Api.UpdateSystemFeedback,
			method: 'post',
			data: params,
		});

// 分页查询系统反馈
export const pageSystemFeedback = (params?: any) => 
	request({
			url: Api.PageSystemFeedback,
			method: 'post',
			data: params,
		});

// 详情系统反馈
export const detailSystemFeedback = (id: any) => 
	request({
			url: Api.DetailSystemFeedback,
			method: 'get',
			data: { id },
		});


