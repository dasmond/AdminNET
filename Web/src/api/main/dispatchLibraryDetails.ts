import request from '/@/utils/request';
enum Api {
  AddDispatchLibraryDetails = '/api/dispatchLibraryDetails/add',
  DeleteDispatchLibraryDetails = '/api/dispatchLibraryDetails/delete',
  UpdateDispatchLibraryDetails = '/api/dispatchLibraryDetails/update',
  PageDispatchLibraryDetails = '/api/dispatchLibraryDetails/page',
  DetailDispatchLibraryDetails = '/api/dispatchLibraryDetails/detail',
}

// 增加调度库详情
export const addDispatchLibraryDetails = (params?: any) =>
	request({
		url: Api.AddDispatchLibraryDetails,
		method: 'post',
		data: params,
	});

// 删除调度库详情
export const deleteDispatchLibraryDetails = (params?: any) => 
	request({
			url: Api.DeleteDispatchLibraryDetails,
			method: 'post',
			data: params,
		});

// 编辑调度库详情
export const updateDispatchLibraryDetails = (params?: any) => 
	request({
			url: Api.UpdateDispatchLibraryDetails,
			method: 'post',
			data: params,
		});

// 分页查询调度库详情
export const pageDispatchLibraryDetails = (params?: any) => 
	request({
			url: Api.PageDispatchLibraryDetails,
			method: 'post',
			data: params,
		});

// 详情调度库详情
export const detailDispatchLibraryDetails = (id: any) => 
	request({
			url: Api.DetailDispatchLibraryDetails,
			method: 'get',
			data: { id },
		});


