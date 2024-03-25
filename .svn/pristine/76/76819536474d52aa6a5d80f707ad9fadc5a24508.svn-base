import request from '/@/utils/request';
enum Api {
  AddCkTagHistory = '/api/ckTagHistory/add',
  DeleteCkTagHistory = '/api/ckTagHistory/delete',
  UpdateCkTagHistory = '/api/ckTagHistory/update',
  PageCkTagHistory = '/api/ckTagHistory/page',
  DetailCkTagHistory = '/api/ckTagHistory/detail',
}

// 增加出库历史表
export const addCkTagHistory = (params?: any) =>
	request({
		url: Api.AddCkTagHistory,
		method: 'post',
		data: params,
	});

// 删除出库历史表
export const deleteCkTagHistory = (params?: any) => 
	request({
			url: Api.DeleteCkTagHistory,
			method: 'post',
			data: params,
		});

// 编辑出库历史表
export const updateCkTagHistory = (params?: any) => 
	request({
			url: Api.UpdateCkTagHistory,
			method: 'post',
			data: params,
		});

// 分页查询出库历史表
export const pageCkTagHistory = (params?: any) => 
	request({
			url: Api.PageCkTagHistory,
			method: 'post',
			data: params,
		});

// 详情出库历史表
export const detailCkTagHistory = (id: any) => 
	request({
			url: Api.DetailCkTagHistory,
			method: 'get',
			data: { id },
		});


