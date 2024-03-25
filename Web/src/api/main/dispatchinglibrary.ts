import request from '/@/utils/request';
enum Api {
  AddDispatchinglibrary = '/api/dispatchinglibrary/add',
  DeleteDispatchinglibrary = '/api/dispatchinglibrary/delete',
  UpdateDispatchinglibrary = '/api/dispatchinglibrary/update',
  PageDispatchinglibrary = '/api/dispatchinglibrary/page',
  DetailDispatchinglibrary = '/api/dispatchinglibrary/detail',
}

// 增加调度库
export const addDispatchinglibrary = (params?: any) =>
	request({
		url: Api.AddDispatchinglibrary,
		method: 'post',
		data: params,
	});

// 删除调度库
export const deleteDispatchinglibrary = (params?: any) => 
	request({
			url: Api.DeleteDispatchinglibrary,
			method: 'post',
			data: params,
		});

// 编辑调度库
export const updateDispatchinglibrary = (params?: any) => 
	request({
			url: Api.UpdateDispatchinglibrary,
			method: 'post',
			data: params,
		});

// 分页查询调度库
export const pageDispatchinglibrary = (params?: any) => 
	request({
			url: Api.PageDispatchinglibrary,
			method: 'post',
			data: params,
		});

// 详情调度库
export const detailDispatchinglibrary = (id: any) => 
	request({
			url: Api.DetailDispatchinglibrary,
			method: 'get',
			data: { id },
		});


