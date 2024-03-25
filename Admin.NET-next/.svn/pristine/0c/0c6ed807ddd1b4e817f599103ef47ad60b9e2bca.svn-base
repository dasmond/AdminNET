import request from '/@/utils/request';
enum Api {
  AddExportRecord = '/api/exportRecord/add',
  DeleteExportRecord = '/api/exportRecord/delete',
  UpdateExportRecord = '/api/exportRecord/update',
  PageExportRecord = '/api/exportRecord/page',
  DetailExportRecord = '/api/exportRecord/detail',
}

// 增加导出记录表
export const addExportRecord = (params?: any) =>
	request({
		url: Api.AddExportRecord,
		method: 'post',
		data: params,
	});

// 删除导出记录表
export const deleteExportRecord = (params?: any) => 
	request({
			url: Api.DeleteExportRecord,
			method: 'post',
			data: params,
		});

// 编辑导出记录表
export const updateExportRecord = (params?: any) => 
	request({
			url: Api.UpdateExportRecord,
			method: 'post',
			data: params,
		});

// 分页查询导出记录表
export const pageExportRecord = (params?: any) => 
	request({
			url: Api.PageExportRecord,
			method: 'post',
			data: params,
		});

// 详情导出记录表
export const detailExportRecord = (id: any) => 
	request({
			url: Api.DetailExportRecord,
			method: 'get',
			data: { id },
		});


