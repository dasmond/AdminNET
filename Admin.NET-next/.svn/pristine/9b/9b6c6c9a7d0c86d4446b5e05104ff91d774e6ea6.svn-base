import request from '/@/utils/request';
enum Api {
  AddFlowPathHost = '/api/flowPathHost/add',
  DeleteFlowPathHost = '/api/flowPathHost/delete',
  UpdateFlowPathHost = '/api/flowPathHost/update',
  PageFlowPathHost = '/api/flowPathHost/page',
  DetailFlowPathHost = '/api/flowPathHost/detail',
}

// 增加流程主表
export const addFlowPathHost = (params?: any) =>
	request({
		url: Api.AddFlowPathHost,
		method: 'post',
		data: params,
	});

// 删除流程主表
export const deleteFlowPathHost = (params?: any) => 
	request({
			url: Api.DeleteFlowPathHost,
			method: 'post',
			data: params,
		});

// 编辑流程主表
export const updateFlowPathHost = (params?: any) => 
	request({
			url: Api.UpdateFlowPathHost,
			method: 'post',
			data: params,
		});

// 分页查询流程主表
export const pageFlowPathHost = (params?: any) => 
	request({
			url: Api.PageFlowPathHost,
			method: 'post',
			data: params,
		});

// 详情流程主表
export const detailFlowPathHost = (id: any) => 
	request({
			url: Api.DetailFlowPathHost,
			method: 'get',
			data: { id },
		});


