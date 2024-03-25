import request from '/@/utils/request';
enum Api {
  AddBomDetailsSubstituteMaterial = '/api/bomDetailsSubstituteMaterial/add',
  DeleteBomDetailsSubstituteMaterial = '/api/bomDetailsSubstituteMaterial/delete',
  UpdateBomDetailsSubstituteMaterial = '/api/bomDetailsSubstituteMaterial/update',
  PageBomDetailsSubstituteMaterial = '/api/bomDetailsSubstituteMaterial/page',
  DetailBomDetailsSubstituteMaterial = '/api/bomDetailsSubstituteMaterial/detail',
}

// 增加BOM详情代替料表
export const addBomDetailsSubstituteMaterial = (params?: any) =>
	request({
		url: Api.AddBomDetailsSubstituteMaterial,
		method: 'post',
		data: params,
	});

// 删除BOM详情代替料表
export const deleteBomDetailsSubstituteMaterial = (params?: any) => 
	request({
			url: Api.DeleteBomDetailsSubstituteMaterial,
			method: 'post',
			data: params,
		});

// 编辑BOM详情代替料表
export const updateBomDetailsSubstituteMaterial = (params?: any) => 
	request({
			url: Api.UpdateBomDetailsSubstituteMaterial,
			method: 'post',
			data: params,
		});

// 分页查询BOM详情代替料表
export const pageBomDetailsSubstituteMaterial = (params?: any) => 
	request({
			url: Api.PageBomDetailsSubstituteMaterial,
			method: 'post',
			data: params,
		});

// 详情BOM详情代替料表
export const detailBomDetailsSubstituteMaterial = (id: any) => 
	request({
			url: Api.DetailBomDetailsSubstituteMaterial,
			method: 'get',
			data: { id },
		});


