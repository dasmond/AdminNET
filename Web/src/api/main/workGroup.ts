import request from '/@/utils/request';
enum Api {
  AddWorkGroup = '/api/workGroup/add',
  DeleteWorkGroup = '/api/workGroup/delete',
  UpdateWorkGroup = '/api/workGroup/update',
  PageWorkGroup = '/api/workGroup/page',
}

// 增加工作中心
export const addWorkGroup = (params?: any) =>
	request({
		url: Api.AddWorkGroup,
		method: 'post',
		data: params,
	});

// 删除工作中心
export const deleteWorkGroup = (params?: any) => 
	request({
			url: Api.DeleteWorkGroup,
			method: 'post',
			data: params,
		});

// 编辑工作中心
export const updateWorkGroup = (params?: any) => 
	request({
			url: Api.UpdateWorkGroup,
			method: 'post',
			data: params,
		});

// 分页查询工作中心
export const pageWorkGroup = (params?: any) => 
	request({
			url: Api.PageWorkGroup,
			method: 'post',
			data: params,
		});


