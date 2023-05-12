import request from '/@/utils/request';

enum Api {
	AddRule = '/api/rule/add',
	DeleteRule = '/api/rule/delete',
	UpdateRule = '/api/rule/update',
	PageRule = '/api/rule/page',
	Upload = '/api/rule/upload',
}

// 增加规则
export const addRule = (params?: any) =>
	request({
		url: Api.AddRule,
		method: 'post',
		data: params,
	});

// 删除规则
export const deleteRule = (params?: any) =>
	request({
		url: Api.DeleteRule,
		method: 'post',
		data: params,
	});

// 编辑规则
export const updateRule = (params?: any) =>
	request({
		url: Api.UpdateRule,
		method: 'post',
		data: params,
	});

// 分页查询
export const pageRule = (params?: any) =>
	request({
		url: Api.PageRule,
		method: 'post',
		data: params,
	});

// 上传素材
export const uploadMaterial = (params: any) => uploadFileHandle(params, Api.Upload);

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
