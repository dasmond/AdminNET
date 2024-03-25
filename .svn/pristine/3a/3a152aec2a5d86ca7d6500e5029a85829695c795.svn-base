import request from '/@/utils/request';
enum Api {
  AddAssignment = '/api/assignment/add',
  DeleteAssignment = '/api/assignment/delete',
  UpdateAssignment = '/api/assignment/update',
  PageAssignment = '/api/assignment/page',
  DetailAssignment = '/api/assignment/detail',
}

// 增加任务表
export const addAssignment = (params?: any) =>
	request({
		url: Api.AddAssignment,
		method: 'post',
		data: params,
	});

// 删除任务表
export const deleteAssignment = (params?: any) => 
	request({
			url: Api.DeleteAssignment,
			method: 'post',
			data: params,
		});

// 编辑任务表
export const updateAssignment = (params?: any) => 
	request({
			url: Api.UpdateAssignment,
			method: 'post',
			data: params,
		});

// 分页查询任务表
export const pageAssignment = (params?: any) => 
	request({
			url: Api.PageAssignment,
			method: 'post',
			data: params,
		});

// 详情任务表
export const detailAssignment = (id: any) => 
	request({
			url: Api.DetailAssignment,
			method: 'get',
			data: { id },
		});


