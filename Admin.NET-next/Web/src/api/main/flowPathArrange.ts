import request from '/@/utils/request';
enum Api {
  AddFlowPathArrange = '/api/flowPathArrange/add',
  DeleteFlowPathArrange = '/api/flowPathArrange/delete',
  UpdateFlowPathArrange = '/api/flowPathArrange/update',
  PageFlowPathArrange = '/api/flowPathArrange/page',
  DetailFlowPathArrange = '/api/flowPathArrange/detail',
}

// 增加流程部署详情
export const addFlowPathArrange = (params?: any) =>
	request({
		url: Api.AddFlowPathArrange,
		method: 'post',
		data: params,
	});

// 删除流程部署详情
export const deleteFlowPathArrange = (params?: any) => 
	request({
			url: Api.DeleteFlowPathArrange,
			method: 'post',
			data: params,
		});

// 编辑流程部署详情
export const updateFlowPathArrange = (params?: any) => 
	request({
			url: Api.UpdateFlowPathArrange,
			method: 'post',
			data: params,
		});

// 分页查询流程部署详情
export const pageFlowPathArrange = (params?: any) => 
	request({
			url: Api.PageFlowPathArrange,
			method: 'post',
			data: params,
		});

// 详情流程部署详情
export const detailFlowPathArrange = (id: any) => 
	request({
			url: Api.DetailFlowPathArrange,
			method: 'get',
			data: { id },
		});


