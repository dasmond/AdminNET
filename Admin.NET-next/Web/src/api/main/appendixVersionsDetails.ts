import request from '/@/utils/request';
enum Api {
  AddAppendixVersionsDetails = '/api/appendixVersionsDetails/add',
  DeleteAppendixVersionsDetails = '/api/appendixVersionsDetails/delete',
  UpdateAppendixVersionsDetails = '/api/appendixVersionsDetails/update',
  PageAppendixVersionsDetails = '/api/appendixVersionsDetails/page',
  DetailAppendixVersionsDetails = '/api/appendixVersionsDetails/detail',
}

// 增加项目附件版本打包详情表
export const addAppendixVersionsDetails = (params?: any) =>
	request({
		url: Api.AddAppendixVersionsDetails,
		method: 'post',
		data: params,
	});

// 删除项目附件版本打包详情表
export const deleteAppendixVersionsDetails = (params?: any) => 
	request({
			url: Api.DeleteAppendixVersionsDetails,
			method: 'post',
			data: params,
		});

// 编辑项目附件版本打包详情表
export const updateAppendixVersionsDetails = (params?: any) => 
	request({
			url: Api.UpdateAppendixVersionsDetails,
			method: 'post',
			data: params,
		});

// 分页查询项目附件版本打包详情表
export const pageAppendixVersionsDetails = (params?: any) => 
	request({
			url: Api.PageAppendixVersionsDetails,
			method: 'post',
			data: params,
		});

// 详情项目附件版本打包详情表
export const detailAppendixVersionsDetails = (id: any) => 
	request({
			url: Api.DetailAppendixVersionsDetails,
			method: 'get',
			data: { id },
		});


