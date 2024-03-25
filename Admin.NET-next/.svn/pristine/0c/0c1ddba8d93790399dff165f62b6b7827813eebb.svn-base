import request from '/@/utils/request';
enum Api {
  AddLayout = '/api/layout/add',
  DeleteLayout = '/api/layout/delete',
  UpdateLayout = '/api/layout/update',
  PageLayout = '/api/layout/page',
  DetailLayout = '/api/layout/detail',
}

// 增加上传硬件Layout
export const addLayout = (params?: any) =>
	request({
		url: Api.AddLayout,
		method: 'post',
		data: params,
	});

// 删除上传硬件Layout
export const deleteLayout = (params?: any) => 
	request({
			url: Api.DeleteLayout,
			method: 'post',
			data: params,
		});

// 编辑上传硬件Layout
export const updateLayout = (params?: any) => 
	request({
			url: Api.UpdateLayout,
			method: 'post',
			data: params,
		});

// 分页查询上传硬件Layout
export const pageLayout = (params?: any) => 
	request({
			url: Api.PageLayout,
			method: 'post',
			data: params,
		});

// 详情上传硬件Layout
export const detailLayout = (id: any) => 
	request({
			url: Api.DetailLayout,
			method: 'get',
			data: { id },
		});


