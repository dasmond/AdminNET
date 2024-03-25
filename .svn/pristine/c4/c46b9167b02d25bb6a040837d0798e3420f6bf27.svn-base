import request from '/@/utils/request';
enum Api {
  AddFlowPathDetails = '/api/flowPathDetails/add',
  DeleteFlowPathDetails = '/api/flowPathDetails/delete',
  UpdateFlowPathDetails = '/api/flowPathDetails/update',
  PageFlowPathDetails = '/api/flowPathDetails/page',
  DetailFlowPathDetails = '/api/flowPathDetails/detail',
}

// 增加流程详情
export const addFlowPathDetails = (params?: any) =>
	request({
		url: Api.AddFlowPathDetails,
		method: 'post',
		data: params,
	});

// 删除流程详情
export const deleteFlowPathDetails = (params?: any) => 
	request({
			url: Api.DeleteFlowPathDetails,
			method: 'post',
			data: params,
		});

// 编辑流程详情
export const updateFlowPathDetails = (params?: any) => 
	request({
			url: Api.UpdateFlowPathDetails,
			method: 'post',
			data: params,
		});

// 分页查询流程详情
export const pageFlowPathDetails = (params?: any) => 
	request({
			url: Api.PageFlowPathDetails,
			method: 'post',
			data: params,
		});

// 详情流程详情
export const detailFlowPathDetails = (id: any) => 
	request({
			url: Api.DetailFlowPathDetails,
			method: 'get',
			data: { id },
		});


