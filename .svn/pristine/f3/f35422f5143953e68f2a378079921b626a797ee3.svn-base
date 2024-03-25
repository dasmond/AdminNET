import request from '/@/utils/request';
enum Api {
  AddLogisticsReceipt = '/api/logisticsReceipt/add',
  DeleteLogisticsReceipt = '/api/logisticsReceipt/delete',
  UpdateLogisticsReceipt = '/api/logisticsReceipt/update',
  PageLogisticsReceipt = '/api/logisticsReceipt/page',
  DetailLogisticsReceipt = '/api/logisticsReceipt/detail',
}

// 增加物流收货单
export const addLogisticsReceipt = (params?: any) =>
	request({
		url: Api.AddLogisticsReceipt,
		method: 'post',
		data: params,
	});

// 删除物流收货单
export const deleteLogisticsReceipt = (params?: any) => 
	request({
			url: Api.DeleteLogisticsReceipt,
			method: 'post',
			data: params,
		});

// 编辑物流收货单
export const updateLogisticsReceipt = (params?: any) => 
	request({
			url: Api.UpdateLogisticsReceipt,
			method: 'post',
			data: params,
		});

// 分页查询物流收货单
export const pageLogisticsReceipt = (params?: any) => 
	request({
			url: Api.PageLogisticsReceipt,
			method: 'post',
			data: params,
		});

// 详情物流收货单
export const detailLogisticsReceipt = (id: any) => 
	request({
			url: Api.DetailLogisticsReceipt,
			method: 'get',
			data: { id },
		});


