import request from '/@/utils/request';
enum Api {
  AddT_WorkLine = '/api/t_WorkLine/add',
  DeleteT_WorkLine = '/api/t_WorkLine/delete',
  UpdateT_WorkLine = '/api/t_WorkLine/update',
  PageT_WorkLine = '/api/t_WorkLine/page',
  GetT_WorkGroupWorkGroupIDDropdown = '/api/t_WorkLine/T_WorkGroupWorkGroupIDDropdown',
}

// 增加生产线
export const addT_WorkLine = (params?: any) =>
	request({
		url: Api.AddT_WorkLine,
		method: 'post',
		data: params,
	});

// 删除生产线
export const deleteT_WorkLine = (params?: any) => 
	request({
			url: Api.DeleteT_WorkLine,
			method: 'post',
			data: params,
		});

// 编辑生产线
export const updateT_WorkLine = (params?: any) => 
	request({
			url: Api.UpdateT_WorkLine,
			method: 'post',
			data: params,
		});

// 分页查询生产线
export const pageT_WorkLine = (params?: any) => 
	request({
			url: Api.PageT_WorkLine,
			method: 'post',
			data: params,
		});

export const getT_WorkGroupWorkGroupIDDropdown = () =>
		request({
		url: Api.GetT_WorkGroupWorkGroupIDDropdown,
		method: 'get'
		});

