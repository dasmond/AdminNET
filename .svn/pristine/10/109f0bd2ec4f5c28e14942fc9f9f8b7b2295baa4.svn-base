import request from '/@/utils/request';
enum Api {
  AddSalespersonRelationship = '/api/salespersonRelationship/add',
  DeleteSalespersonRelationship = '/api/salespersonRelationship/delete',
  UpdateSalespersonRelationship = '/api/salespersonRelationship/update',
  PageSalespersonRelationship = '/api/salespersonRelationship/page',
  DetailSalespersonRelationship = '/api/salespersonRelationship/detail',
}

// 增加业务员关系
export const addSalespersonRelationship = (params?: any) =>
	request({
		url: Api.AddSalespersonRelationship,
		method: 'post',
		data: params,
	});

// 删除业务员关系
export const deleteSalespersonRelationship = (params?: any) => 
	request({
			url: Api.DeleteSalespersonRelationship,
			method: 'post',
			data: params,
		});

// 编辑业务员关系
export const updateSalespersonRelationship = (params?: any) => 
	request({
			url: Api.UpdateSalespersonRelationship,
			method: 'post',
			data: params,
		});

// 分页查询业务员关系
export const pageSalespersonRelationship = (params?: any) => 
	request({
			url: Api.PageSalespersonRelationship,
			method: 'post',
			data: params,
		});

// 详情业务员关系
export const detailSalespersonRelationship = (id: any) => 
	request({
			url: Api.DetailSalespersonRelationship,
			method: 'get',
			data: { id },
		});


