import { BasicPageParams, BasicFetchResult } from '../../model/baseModel';

// 实体结构定义
export interface UserItem {
  id: number;
  userName: string;
  nickName: string;
  avatar: string;
  birthday: string;
  sex: string;
  email: string;
  phone: string;
  realName: string;
  idCard: string;
  userType: string;
  status: number;
  remark: string;
  createTime: string;
  orgId: number;
  posId: number;
  jobNum: string;
  JobStatus: number;
}

export interface GrantUserRoleItem {
  id: number;
  orgId: number;
  roleIdList: number[];
}

export interface RoleItem {
  id: number;
  name: string;
  code: string;
  order: number;
  dataScope: number;
  status: number;
  remark: string;
  createTime: string;
}

export interface GrantMenuItem {
  id: number;
  menuIdList: number[];
}

export interface GrantDataItem {
  id: number;
  orgIdList: number[];
}

export interface MenuItem {
  id: number;
  type: number;
  name: string;
  title: string;
  icon: string;
  path: string;
  component: string;
  permission: string;
  redirect: string;
  frameSrc: string;
  hideMenu: boolean;
  ignoreKeepAlive: boolean;
  currentActiveMenu: string;
  orderNo: number;
  createTime: string;
}

export interface OrgItem {
  id: number;
  name: string;
  code: string;
  order: number;
  status: number;
  remark: string;
  createTime: string;
}

export interface PosItem {
  id: number;
  name: string;
  code: string;
  order: number;
  status: number;
  remark: string;
  createTime: string;
}

export interface LogItem {
  createTime: string;
}

export interface FileItem {
  id: number;
  bucketName: string;
  fileName: string;
  suffix: string;
  filePath: string;
  sizeKb: string;
  createTime: string;
}

export interface ConfigItem {
  id: number;
  name: string;
  code: string;
  value: string;
  sysFlag: boolean;
  groupCode: string;
  order: number;
  remark: string;
  createTime: string;
}

export interface TimerItem {
  id: number;
  timerName: string;
  doOnce: boolean;
  startNow: boolean;
  executeType: number;
  interval: number;
  cron: string;
  timerType: number;
  requestUrl: string;
  requestType: number;
  requestPara: string;
  headers: string;
  remark: string;
  createTime: string;
}

// 分页查询参数
export type UserPageParams = BasicPageParams & UserItem;

export type RolePageParams = BasicPageParams & RoleItem;

export type LogPageParams = BasicPageParams & LogItem;

export type FilePageParams = BasicPageParams & FileItem;

export type ConfigPageParams = BasicPageParams & ConfigItem;

export type TimerPageParams = BasicPageParams & TimerItem;

// 接口结果定义
export type UserPageListGetResultModel = BasicFetchResult<UserItem>;

export type RolePageListGetResultModel = BasicFetchResult<RoleItem>;
