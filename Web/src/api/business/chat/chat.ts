import request from '/@/utils/request';
enum Api {
    SendUser = '/api/message/sendMessage',
    GetMessage = '/api/message/getMessage/{userId}',
}/**
 * 发送用户消息
 * @param data - 包含用户消息的对象
 * @returns 返回发送结果的 Promise 对象
 */
export function sendUser(data: any) {
    // 使用 request 库的 post 方法发送 POST 请求到 Api.SendUser 接口，携带 data 数据
    return request.post(Api.SendUser, data);
}
/**
 * 获取用户消息
 * @param userId - 用户 ID
 * @returns 返回获取结果的 Promise 对象
 */
export function getMessage(userId: any) {
    // 使用 request 库的 get 方法发送 GET 请求到 Api.GetMessage 接口，并传入 userId 参数
    return request.get(Api.GetMessage.replace('{userId}', userId.toString()));
}