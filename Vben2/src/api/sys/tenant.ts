import { defHttp } from '/@/utils/http/axios';
enum Api {
  AddSysTenant = '/sysTenant/add',
  DeleteSysTenant = '/sysTenant/delete',
  UpdateSysTenant = '/sysTenant/edit',
  GetSysTenantPage = '/sysTenant/page',
  GrantMenu = '/sysTenant/GrantMenu',
  OwnMenuList = '/sysTenant/ownMenu',
  ResetPwd = '/sysTenant/resetPwd'
}

//增加租户管理
export function addSysTenant(params: any) {
  return defHttp.post<any>({ url: Api.AddSysTenant, params });
}
//删除租户管理
export const deleteSysTenant = (id: number) => defHttp.post({ url: Api.DeleteSysTenant, params: { id } });

//编辑租户管理
export function updateSysTenant(params: any) {
  return defHttp.post<any>({ url: Api.UpdateSysTenant, params });
}
//分页查询租户管理
export function getSysTenantPageList(params?: any) {
  return defHttp.get<any>({ url: Api.GetSysTenantPage, params });
}
//授权租户菜单
export function grantMenu(params?: any) {
  return defHttp.post<any>({ url: Api.GrantMenu, params });
}

// 获取租户菜单
export const ownMenuList = (id: number) =>
  defHttp.get<any>({ url: Api.OwnMenuList, params: { id } });


//重置租户密码
export function resetPwd(params?: any) {
  return defHttp.post<any>({ url: Api.ResetPwd, params });
}