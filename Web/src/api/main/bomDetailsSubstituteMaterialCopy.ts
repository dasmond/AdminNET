import request from '/@/utils/request';
enum Api {
  AddBomDetailsSubstituteMaterialCopy = '/api/bomDetailsSubstituteMaterialCopy/add',
  DeleteBomDetailsSubstituteMaterialCopy = '/api/bomDetailsSubstituteMaterialCopy/delete',
  UpdateBomDetailsSubstituteMaterialCopy = '/api/bomDetailsSubstituteMaterialCopy/update',
  PageBomDetailsSubstituteMaterialCopy = '/api/bomDetailsSubstituteMaterialCopy/page',
  DetailBomDetailsSubstituteMaterialCopy = '/api/bomDetailsSubstituteMaterialCopy/detail',
}

// 增加BOM详情代替料表副本
export const addBomDetailsSubstituteMaterialCopy = (params?: any) =>
	request({
		url: Api.AddBomDetailsSubstituteMaterialCopy,
		method: 'post',
		data: params,
	});

// 删除BOM详情代替料表副本
export const deleteBomDetailsSubstituteMaterialCopy = (params?: any) => 
	request({
			url: Api.DeleteBomDetailsSubstituteMaterialCopy,
			method: 'post',
			data: params,
		});

// 编辑BOM详情代替料表副本
export const updateBomDetailsSubstituteMaterialCopy = (params?: any) => 
	request({
			url: Api.UpdateBomDetailsSubstituteMaterialCopy,
			method: 'post',
			data: params,
		});

// 分页查询BOM详情代替料表副本
export const pageBomDetailsSubstituteMaterialCopy = (params?: any) => 
	request({
			url: Api.PageBomDetailsSubstituteMaterialCopy,
			method: 'post',
			data: params,
		});

// 详情BOM详情代替料表副本
export const detailBomDetailsSubstituteMaterialCopy = (id: any) => 
	request({
			url: Api.DetailBomDetailsSubstituteMaterialCopy,
			method: 'get',
			data: { id },
		});


