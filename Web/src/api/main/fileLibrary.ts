import request from '/@/utils/request';
enum Api {
  AddFileLibrary = '/api/fileLibrary/add',
  DeleteFileLibrary = '/api/fileLibrary/delete',
  UpdateFileLibrary = '/api/fileLibrary/update',
  PageFileLibrary = '/api/fileLibrary/page',
  DetailFileLibrary = '/api/fileLibrary/detail',
}

// 增加文件库
export const addFileLibrary = (params?: any) =>
	request({
		url: Api.AddFileLibrary,
		method: 'post',
		data: params,
	});

// 删除文件库
export const deleteFileLibrary = (params?: any) => 
	request({
			url: Api.DeleteFileLibrary,
			method: 'post',
			data: params,
		});

// 编辑文件库
export const updateFileLibrary = (params?: any) => 
	request({
			url: Api.UpdateFileLibrary,
			method: 'post',
			data: params,
		});

// 分页查询文件库
export const pageFileLibrary = (params?: any) => 
	request({
			url: Api.PageFileLibrary,
			method: 'post',
			data: params,
		});

// 详情文件库
export const detailFileLibrary = (id: any) => 
	request({
			url: Api.DetailFileLibrary,
			method: 'get',
			data: { id },
		});


