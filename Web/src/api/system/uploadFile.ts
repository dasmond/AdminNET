import request from "/@/utils/request";

export const uploadFile = (params: any, url: string) => { 
	const formData = new FormData();
	formData.append('file', params.file);
	// 自定义参数
	if (params.data) {
		Object.keys(params.data).forEach((key) => {
			const value = params.data![key];
			if (Array.isArray(value)) {
				value.forEach((item) => formData.append(`${key}[]`, item));
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
			ignoreCancelToken: true,
		},
	});
};
