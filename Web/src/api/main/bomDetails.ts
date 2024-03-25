import request from '/@/utils/request';
enum Api {
  AddBomDetails = '/api/bomDetails/add',
  DeleteBomDetails = '/api/bomDetails/delete',
  UpdateBomDetails = '/api/bomDetails/update',
  PageBomDetails = '/api/bomDetails/page',
  DetailBomDetails = '/api/bomDetails/detail',
}

// 增加BOM资料表明细表
export const addBomDetails = (params?: any) =>
	request({
		url: Api.AddBomDetails,
		method: 'post',
		data: params,
	});

// 删除BOM资料表明细表
export const deleteBomDetails = (params?: any) => 
	request({
			url: Api.DeleteBomDetails,
			method: 'post',
			data: params,
		});

// 编辑BOM资料表明细表
export const updateBomDetails = (params?: any) => 
	request({
			url: Api.UpdateBomDetails,
			method: 'post',
			data: params,
		});

// 分页查询BOM资料表明细表
export const pageBomDetails = (params?: any) => 
	request({
			url: Api.PageBomDetails,
			method: 'post',
			data: params,
		});

// 详情BOM资料表明细表
export const detailBomDetails = (id: any) => 
	request({
			url: Api.DetailBomDetails,
			method: 'get',
			data: { id },
		});


