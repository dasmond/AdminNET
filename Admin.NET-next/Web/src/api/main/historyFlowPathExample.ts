import request from '/@/utils/request';
enum Api {
  AddHistoryFlowPathExample = '/api/historyFlowPathExample/add',
  DeleteHistoryFlowPathExample = '/api/historyFlowPathExample/delete',
  UpdateHistoryFlowPathExample = '/api/historyFlowPathExample/update',
  PageHistoryFlowPathExample = '/api/historyFlowPathExample/page',
  DetailHistoryFlowPathExample = '/api/historyFlowPathExample/detail',
}

// 增加流程实例表
export const addHistoryFlowPathExample = (params?: any) =>
	request({
		url: Api.AddHistoryFlowPathExample,
		method: 'post',
		data: params,
	});

// 删除流程实例表
export const deleteHistoryFlowPathExample = (params?: any) => 
	request({
			url: Api.DeleteHistoryFlowPathExample,
			method: 'post',
			data: params,
		});

// 编辑流程实例表
export const updateHistoryFlowPathExample = (params?: any) => 
	request({
			url: Api.UpdateHistoryFlowPathExample,
			method: 'post',
			data: params,
		});

// 分页查询流程实例表
export const pageHistoryFlowPathExample = (params?: any) => 
	request({
			url: Api.PageHistoryFlowPathExample,
			method: 'post',
			data: params,
		});

// 详情流程实例表
export const detailHistoryFlowPathExample = (id: any) => 
	request({
			url: Api.DetailHistoryFlowPathExample,
			method: 'get',
			data: { id },
		});


