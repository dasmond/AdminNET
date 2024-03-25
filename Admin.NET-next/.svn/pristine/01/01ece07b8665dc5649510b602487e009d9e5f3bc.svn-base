import request from '/@/utils/request';
enum Api {
  AddQualityTestingHistory = '/api/qualityTestingHistory/add',
  DeleteQualityTestingHistory = '/api/qualityTestingHistory/delete',
  UpdateQualityTestingHistory = '/api/qualityTestingHistory/update',
  PageQualityTestingHistory = '/api/qualityTestingHistory/page',
  DetailQualityTestingHistory = '/api/qualityTestingHistory/detail',
}

// 增加质量检测历史
export const addQualityTestingHistory = (params?: any) =>
	request({
		url: Api.AddQualityTestingHistory,
		method: 'post',
		data: params,
	});

// 删除质量检测历史
export const deleteQualityTestingHistory = (params?: any) => 
	request({
			url: Api.DeleteQualityTestingHistory,
			method: 'post',
			data: params,
		});

// 编辑质量检测历史
export const updateQualityTestingHistory = (params?: any) => 
	request({
			url: Api.UpdateQualityTestingHistory,
			method: 'post',
			data: params,
		});

// 分页查询质量检测历史
export const pageQualityTestingHistory = (params?: any) => 
	request({
			url: Api.PageQualityTestingHistory,
			method: 'post',
			data: params,
		});

// 详情质量检测历史
export const detailQualityTestingHistory = (id: any) => 
	request({
			url: Api.DetailQualityTestingHistory,
			method: 'get',
			data: { id },
		});


