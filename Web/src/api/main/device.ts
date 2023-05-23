import request from '/@/utils/request';

enum Api {
	AddDevice = '/api/device/add',
	DeleteDevice = '/api/device/delete',
	UpdateDevice = '/api/device/update',
	PageDevice = '/api/device/page',
}

// 增加
export const addDevice = (params?: any) =>
	request({
		url: Api.AddDevice,
		method: 'post',
		data: params,
	});

// 删除
export const deleteDevice = (params?: any) =>
	request({
		url: Api.DeleteDevice,
		method: 'post',
		data: params,
	});

// 编辑
export const updateDevice = (params?: any) =>
	request({
		url: Api.UpdateDevice,
		method: 'post',
		data: params,
	});

// 分页
export const pageDevice = (params?: any) =>
	request({
		url: Api.PageDevice,
		method: 'post',
		data: params,
	});
