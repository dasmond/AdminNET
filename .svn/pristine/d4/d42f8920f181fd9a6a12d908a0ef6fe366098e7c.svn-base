import request from '/@/utils/request';
enum Api {
  AddProcessInstanceRecord = '/api/processInstanceRecord/add',
  DeleteProcessInstanceRecord = '/api/processInstanceRecord/delete',
  UpdateProcessInstanceRecord = '/api/processInstanceRecord/update',
  PageProcessInstanceRecord = '/api/processInstanceRecord/page',
  DetailProcessInstanceRecord = '/api/processInstanceRecord/detail',
}

// 增加历史流程记录表
export const addProcessInstanceRecord = (params?: any) =>
	request({
		url: Api.AddProcessInstanceRecord,
		method: 'post',
		data: params,
	});

// 删除历史流程记录表
export const deleteProcessInstanceRecord = (params?: any) => 
	request({
			url: Api.DeleteProcessInstanceRecord,
			method: 'post',
			data: params,
		});

// 编辑历史流程记录表
export const updateProcessInstanceRecord = (params?: any) => 
	request({
			url: Api.UpdateProcessInstanceRecord,
			method: 'post',
			data: params,
		});

// 分页查询历史流程记录表
export const pageProcessInstanceRecord = (params?: any) => 
	request({
			url: Api.PageProcessInstanceRecord,
			method: 'post',
			data: params,
		});

// 详情历史流程记录表
export const detailProcessInstanceRecord = (id: any) => 
	request({
			url: Api.DetailProcessInstanceRecord,
			method: 'get',
			data: { id },
		});


