/*
 * @Author: 490912587@qq.com
 * @Date: 2024-01-10 16:24:10
 * @LastEditors: 490912587@qq.com
 * @LastEditTime: 2024-06-20 18:07:19
 * @FilePath: \WebSoybean\src\service\api\enum.ts
 * @Description: 
 */
import { service as request } from '@/utils/request';
// 获取所有枚举类型
export const getEnumTypeList = async () => {
  const result = await request.get<any>('api/sysEnum/enumTypeList');
  return result;
};
// 通过枚举类型名称获取枚举值
export const getEnumDataByTypeName = async (typeName: string) => {
  const result = await request.get<any>('api/sysEnum/enumDataList?EnumName=' + typeName);
  return result;
};