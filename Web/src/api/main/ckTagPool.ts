import request from '/@/utils/request';
enum Api {
  AddCkTagPool = '/api/ckTagPool/add',
  DeleteCkTagPool = '/api/ckTagPool/delete',
  UpdateCkTagPool = '/api/ckTagPool/update',
  PageCkTagPool = '/api/ckTagPool/page',
  DetailCkTagPool = '/api/ckTagPool/detail',
}

// 增加标签池
export const addCkTagPool = (params?: any) =>
	request({
		url: Api.AddCkTagPool,
		method: 'post',
		data: params,
	});

// 删除标签池
export const deleteCkTagPool = (params?: any) => 
	request({
			url: Api.DeleteCkTagPool,
			method: 'post',
			data: params,
		});

// 编辑标签池
export const updateCkTagPool = (params?: any) => 
	request({
			url: Api.UpdateCkTagPool,
			method: 'post',
			data: params,
		});

// 分页查询标签池
export const pageCkTagPool = (params?: any) => 
	request({
			url: Api.PageCkTagPool,
			method: 'post',
			data: params,
		});

// 详情标签池
export const detailCkTagPool = (id: any) => 
	request({
			url: Api.DetailCkTagPool,
			method: 'get',
			data: { id },
		});


