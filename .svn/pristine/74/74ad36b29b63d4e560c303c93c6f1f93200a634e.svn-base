import request from '/@/utils/request';
enum Api {
  AddBomDetailsCopy = '/api/bomDetailsCopy/add',
  DeleteBomDetailsCopy = '/api/bomDetailsCopy/delete',
  UpdateBomDetailsCopy = '/api/bomDetailsCopy/update',
  PageBomDetailsCopy = '/api/bomDetailsCopy/page',
  DetailBomDetailsCopy = '/api/bomDetailsCopy/detail',
}

// 增加BOM资料表副本
export const addBomDetailsCopy = (params?: any) =>
	request({
		url: Api.AddBomDetailsCopy,
		method: 'post',
		data: params,
	});

// 删除BOM资料表副本
export const deleteBomDetailsCopy = (params?: any) => 
	request({
			url: Api.DeleteBomDetailsCopy,
			method: 'post',
			data: params,
		});

// 编辑BOM资料表副本
export const updateBomDetailsCopy = (params?: any) => 
	request({
			url: Api.UpdateBomDetailsCopy,
			method: 'post',
			data: params,
		});

// 分页查询BOM资料表副本
export const pageBomDetailsCopy = (params?: any) => 
	request({
			url: Api.PageBomDetailsCopy,
			method: 'post',
			data: params,
		});

// 详情BOM资料表副本
export const detailBomDetailsCopy = (id: any) => 
	request({
			url: Api.DetailBomDetailsCopy,
			method: 'get',
			data: { id },
		});


