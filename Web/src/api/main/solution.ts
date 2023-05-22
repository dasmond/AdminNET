import request from '/@/utils/request';

enum Api {
	AddSolution = '/api/solution/add',
	DeleteSolution = '/api/solution/delete',
	UpdateSolution = '/api/solution/update',
	PageSolution = '/api/solution/page',
	uploadMaterial = '/api/solution/upload',
}

// 增加
export const addSolution = (params?: any) =>
	request({
		url: Api.AddSolution,
		method: 'post',
		data: params,
	});

// 删除
export const deleteSolution = (params?: any) =>
	request({
		url: Api.DeleteSolution,
		method: 'post',
		data: params,
	});

// 编辑
export const updateSolution = (params?: any) =>
	request({
		url: Api.UpdateSolution,
		method: 'post',
		data: params,
	});

// 分页
export const pageSolution = (params?: any) =>
	request({
		url: Api.PageSolution,
		method: 'post',
		data: params,
	});

// 上传
export const uploadMaterial = (params: any) => uploadFileHandle(params, Api.uploadMaterial);

export const uploadFileHandle = (params: any, url: string) => {
	const formData = new window.FormData();
	formData.append('file', params.file);
	//自定义参数
	if (params.data) {
		Object.keys(params.data).forEach((key) => {
			const value = params.data![key];
			if (Array.isArray(value)) {
				value.forEach((item) => {
					formData.append(`${key}[]`, item);
				});
				return;
			}
			formData.append(key, params.data![key]);
		});
	}
	return request({
		url: url,
		method: 'POST',
		data: formData,
		headers: {
			'Content-type': 'multipart/form-data;charset=UTF-8',
			// ts-ignore
			ignoreCancelToken: true,
		},
	});
};
