import request from '/@/utils/request';
enum Api {
  AddBomMaster = '/api/bomMaster/add',
  DeleteBomMaster = '/api/bomMaster/delete',
  UpdateBomMaster = '/api/bomMaster/update',
  PageBomMaster = '/api/bomMaster/page',
  DetailBomMaster = '/api/bomMaster/detail',
}

// 增加BOM主表
export const addBomMaster = (params?: any) =>
	request({
		url: Api.AddBomMaster,
		method: 'post',
		data: params,
	});

// 删除BOM主表
export const deleteBomMaster = (params?: any) => 
	request({
			url: Api.DeleteBomMaster,
			method: 'post',
			data: params,
		});

// 编辑BOM主表
export const updateBomMaster = (params?: any) => 
	request({
			url: Api.UpdateBomMaster,
			method: 'post',
			data: params,
		});

// 分页查询BOM主表
export const pageBomMaster = (params?: any) => 
	request({
			url: Api.PageBomMaster,
			method: 'post',
			data: params,
		});

// 详情BOM主表
export const detailBomMaster = (id: any) => 
	request({
			url: Api.DetailBomMaster,
			method: 'get',
			data: { id },
		});


