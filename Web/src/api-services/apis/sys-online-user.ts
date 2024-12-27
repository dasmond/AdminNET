import request from '/@/utils/request';
import { SysOnlineUser } from '../models/sys-online-user';

export const getOnlineUserList = () => {
  return request.get<Array<SysOnlineUser>>('/api/SysOnlineUser/List');
}; 