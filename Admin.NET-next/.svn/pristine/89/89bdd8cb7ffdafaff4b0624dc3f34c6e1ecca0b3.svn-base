import request from '/@/utils/request';
enum Api {
  AddAppendix = '/api/appendix/add',
  DeleteAppendix = '/api/appendix/delete',
  UpdateAppendix = '/api/appendix/update',
  PageAppendix = '/api/appendix/page',
  DetailAppendix = '/api/appendix/detail',
}

// 增加附件表
export const addAppendix = (params?: any) =>
	request({
		url: Api.AddAppendix,
		method: 'post',
		data: params,
	});

// 删除附件表
export const deleteAppendix = (params?: any) => 
	request({
			url: Api.DeleteAppendix,
			method: 'post',
			data: params,
		});

// 编辑附件表
export const updateAppendix = (params?: any) => 
	request({
			url: Api.UpdateAppendix,
			method: 'post',
			data: params,
		});

// 分页查询附件表
export const pageAppendix = (params?: any) => 
	request({
			url: Api.PageAppendix,
			method: 'post',
			data: params,
		});

// 详情附件表
export const detailAppendix = (id: any) => 
	request({
			url: Api.DetailAppendix,
			method: 'get',
			data: { id },
		});


