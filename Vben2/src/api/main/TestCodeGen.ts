import { defHttp } from '/@/utils/http/axios';
enum Api {
  AddTestCodeGen = '/TestCodeGen/add',
  DeleteTestCodeGen = '/TestCodeGen/delete',
  UpdateTestCodeGen = '/TestCodeGen/edit',
  GetTestCodeGenPage = '/TestCodeGen/page',
  GetSysUserDropdown = '/TestCodeGen/SysUserDropdown',
}

//增加测试生成
export function addTestCodeGen(params: any) {
  return defHttp.post<any>({ url: Api.AddTestCodeGen, params });
}
//删除测试生成
export function deleteTestCodeGen(params: any) {
  return defHttp.post<any>({ url: Api.DeleteTestCodeGen, params });
}
//编辑测试生成
export function updateTestCodeGen(params: any) {
  return defHttp.post<any>({ url: Api.UpdateTestCodeGen, params });
}
//分页查询测试生成
export function getTestCodeGenPageList(params?: any) {
  return defHttp.get<any>({ url: Api.GetTestCodeGenPage, params });
}
export function getSysUserDropdown() {
  return defHttp.get<any>({ url: Api.GetSysUserDropdown });
}
