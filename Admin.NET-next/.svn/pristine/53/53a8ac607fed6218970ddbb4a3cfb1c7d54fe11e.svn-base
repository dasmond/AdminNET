import request from '/@/utils/request';
enum Api {
  AddClassification = '/api/classification/add',
  DeleteClassification = '/api/classification/delete',
  UpdateClassification = '/api/classification/update',
  PageClassification = '/api/classification/page',
  DetailClassification = '/api/classification/detail',
}

// 增加商品类别表
export const addClassification = (params?: any) =>
	request({
		url: Api.AddClassification,
		method: 'post',
		data: params,
	});

// 删除商品类别表
export const deleteClassification = (params?: any) => 
	request({
			url: Api.DeleteClassification,
			method: 'post',
			data: params,
		});

// 编辑商品类别表
export const updateClassification = (params?: any) => 
	request({
			url: Api.UpdateClassification,
			method: 'post',
			data: params,
		});

// 分页查询商品类别表
export const pageClassification = (params?: any) => 
	request({
			url: Api.PageClassification,
			method: 'post',
			data: params,
		});

// 详情商品类别表
export const detailClassification = (id: any) => 
	request({
			url: Api.DetailClassification,
			method: 'get',
			data: { id },
		});


