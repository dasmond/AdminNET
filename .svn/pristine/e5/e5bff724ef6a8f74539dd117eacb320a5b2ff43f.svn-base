import request from '/@/utils/request';
enum Api {
  AddCkTagStock = '/api/ckTagStock/add',
  DeleteCkTagStock = '/api/ckTagStock/delete',
  UpdateCkTagStock = '/api/ckTagStock/update',
  PageCkTagStock = '/api/ckTagStock/page',
  DetailCkTagStock = '/api/ckTagStock/detail',
}

// 增加标签库存
export const addCkTagStock = (params?: any) =>
	request({
		url: Api.AddCkTagStock,
		method: 'post',
		data: params,
	});

// 删除标签库存
export const deleteCkTagStock = (params?: any) => 
	request({
			url: Api.DeleteCkTagStock,
			method: 'post',
			data: params,
		});

// 编辑标签库存
export const updateCkTagStock = (params?: any) => 
	request({
			url: Api.UpdateCkTagStock,
			method: 'post',
			data: params,
		});

// 分页查询标签库存
export const pageCkTagStock = (params?: any) => 
	request({
			url: Api.PageCkTagStock,
			method: 'post',
			data: params,
		});

// 详情标签库存
export const detailCkTagStock = (id: any) => 
	request({
			url: Api.DetailCkTagStock,
			method: 'get',
			data: { id },
		});


