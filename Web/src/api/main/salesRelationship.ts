import request from '/@/utils/request';
enum Api {
  AddSalesRelationship = '/api/salesRelationship/add',
  DeleteSalesRelationship = '/api/salesRelationship/delete',
  UpdateSalesRelationship = '/api/salesRelationship/update',
  PageSalesRelationship = '/api/salesRelationship/page',
  DetailSalesRelationship = '/api/salesRelationship/detail',
}

// 增加销售关系表
export const addSalesRelationship = (params?: any) =>
	request({
		url: Api.AddSalesRelationship,
		method: 'post',
		data: params,
	});

// 删除销售关系表
export const deleteSalesRelationship = (params?: any) => 
	request({
			url: Api.DeleteSalesRelationship,
			method: 'post',
			data: params,
		});

// 编辑销售关系表
export const updateSalesRelationship = (params?: any) => 
	request({
			url: Api.UpdateSalesRelationship,
			method: 'post',
			data: params,
		});

// 分页查询销售关系表
export const pageSalesRelationship = (params?: any) => 
	request({
			url: Api.PageSalesRelationship,
			method: 'post',
			data: params,
		});

// 详情销售关系表
export const detailSalesRelationship = (id: any) => 
	request({
			url: Api.DetailSalesRelationship,
			method: 'get',
			data: { id },
		});


