import request from '/@/utils/request';
enum Api {
  AddAppendixVersions = '/api/appendixVersions/add',
  DeleteAppendixVersions = '/api/appendixVersions/delete',
  UpdateAppendixVersions = '/api/appendixVersions/update',
  PageAppendixVersions = '/api/appendixVersions/page',
  DetailAppendixVersions = '/api/appendixVersions/detail',
}

// 增加项目附件版本打包表
export const addAppendixVersions = (params?: any) =>
	request({
		url: Api.AddAppendixVersions,
		method: 'post',
		data: params,
	});

// 删除项目附件版本打包表
export const deleteAppendixVersions = (params?: any) => 
	request({
			url: Api.DeleteAppendixVersions,
			method: 'post',
			data: params,
		});

// 编辑项目附件版本打包表
export const updateAppendixVersions = (params?: any) => 
	request({
			url: Api.UpdateAppendixVersions,
			method: 'post',
			data: params,
		});

// 分页查询项目附件版本打包表
export const pageAppendixVersions = (params?: any) => 
	request({
			url: Api.PageAppendixVersions,
			method: 'post',
			data: params,
		});

// 详情项目附件版本打包表
export const detailAppendixVersions = (id: any) => 
	request({
			url: Api.DetailAppendixVersions,
			method: 'get',
			data: { id },
		});


