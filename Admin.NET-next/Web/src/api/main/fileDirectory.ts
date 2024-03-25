import request from '/@/utils/request';
enum Api {
  AddFileDirectory = '/api/fileDirectory/add',
  DeleteFileDirectory = '/api/fileDirectory/delete',
  UpdateFileDirectory = '/api/fileDirectory/update',
  PageFileDirectory = '/api/fileDirectory/page',
  DetailFileDirectory = '/api/fileDirectory/detail',
}

// 增加文件目录
export const addFileDirectory = (params?: any) =>
	request({
		url: Api.AddFileDirectory,
		method: 'post',
		data: params,
	});

// 删除文件目录
export const deleteFileDirectory = (params?: any) => 
	request({
			url: Api.DeleteFileDirectory,
			method: 'post',
			data: params,
		});

// 编辑文件目录
export const updateFileDirectory = (params?: any) => 
	request({
			url: Api.UpdateFileDirectory,
			method: 'post',
			data: params,
		});

// 分页查询文件目录
export const pageFileDirectory = (params?: any) => 
	request({
			url: Api.PageFileDirectory,
			method: 'post',
			data: params,
		});

// 详情文件目录
export const detailFileDirectory = (id: any) => 
	request({
			url: Api.DetailFileDirectory,
			method: 'get',
			data: { id },
		});


