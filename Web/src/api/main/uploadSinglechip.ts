import request from '/@/utils/request';
enum Api {
  AddUploadSinglechip = '/api/uploadSinglechip/add',
  DeleteUploadSinglechip = '/api/uploadSinglechip/delete',
  UpdateUploadSinglechip = '/api/uploadSinglechip/update',
  PageUploadSinglechip = '/api/uploadSinglechip/page',
  DetailUploadSinglechip = '/api/uploadSinglechip/detail',
}

// 增加单片机上传信息
export const addUploadSinglechip = (params?: any) =>
	request({
		url: Api.AddUploadSinglechip,
		method: 'post',
		data: params,
	});

// 删除单片机上传信息
export const deleteUploadSinglechip = (params?: any) => 
	request({
			url: Api.DeleteUploadSinglechip,
			method: 'post',
			data: params,
		});

// 编辑单片机上传信息
export const updateUploadSinglechip = (params?: any) => 
	request({
			url: Api.UpdateUploadSinglechip,
			method: 'post',
			data: params,
		});

// 分页查询单片机上传信息
export const pageUploadSinglechip = (params?: any) => 
	request({
			url: Api.PageUploadSinglechip,
			method: 'post',
			data: params,
		});

// 详情单片机上传信息
export const detailUploadSinglechip = (id: any) => 
	request({
			url: Api.DetailUploadSinglechip,
			method: 'get',
			data: { id },
		});


