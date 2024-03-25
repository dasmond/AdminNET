import request from '/@/utils/request';
enum Api {
  AddFinancialAccountsPayable = '/api/financialAccountsPayable/add',
  DeleteFinancialAccountsPayable = '/api/financialAccountsPayable/delete',
  UpdateFinancialAccountsPayable = '/api/financialAccountsPayable/update',
  PageFinancialAccountsPayable = '/api/financialAccountsPayable/page',
  DetailFinancialAccountsPayable = '/api/financialAccountsPayable/detail',
}

// 增加财务应付表
export const addFinancialAccountsPayable = (params?: any) =>
	request({
		url: Api.AddFinancialAccountsPayable,
		method: 'post',
		data: params,
	});

// 删除财务应付表
export const deleteFinancialAccountsPayable = (params?: any) => 
	request({
			url: Api.DeleteFinancialAccountsPayable,
			method: 'post',
			data: params,
		});

// 编辑财务应付表
export const updateFinancialAccountsPayable = (params?: any) => 
	request({
			url: Api.UpdateFinancialAccountsPayable,
			method: 'post',
			data: params,
		});

// 分页查询财务应付表
export const pageFinancialAccountsPayable = (params?: any) => 
	request({
			url: Api.PageFinancialAccountsPayable,
			method: 'post',
			data: params,
		});

// 详情财务应付表
export const detailFinancialAccountsPayable = (id: any) => 
	request({
			url: Api.DetailFinancialAccountsPayable,
			method: 'get',
			data: { id },
		});


