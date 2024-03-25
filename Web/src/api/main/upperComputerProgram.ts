import request from '/@/utils/request';
enum Api {
  AddUpperComputerProgram = '/api/upperComputerProgram/add',
  DeleteUpperComputerProgram = '/api/upperComputerProgram/delete',
  UpdateUpperComputerProgram = '/api/upperComputerProgram/update',
  PageUpperComputerProgram = '/api/upperComputerProgram/page',
  DetailUpperComputerProgram = '/api/upperComputerProgram/detail',
}

// 增加上位机程序
export const addUpperComputerProgram = (params?: any) =>
	request({
		url: Api.AddUpperComputerProgram,
		method: 'post',
		data: params,
	});

// 删除上位机程序
export const deleteUpperComputerProgram = (params?: any) => 
	request({
			url: Api.DeleteUpperComputerProgram,
			method: 'post',
			data: params,
		});

// 编辑上位机程序
export const updateUpperComputerProgram = (params?: any) => 
	request({
			url: Api.UpdateUpperComputerProgram,
			method: 'post',
			data: params,
		});

// 分页查询上位机程序
export const pageUpperComputerProgram = (params?: any) => 
	request({
			url: Api.PageUpperComputerProgram,
			method: 'post',
			data: params,
		});

// 详情上位机程序
export const detailUpperComputerProgram = (id: any) => 
	request({
			url: Api.DetailUpperComputerProgram,
			method: 'get',
			data: { id },
		});


