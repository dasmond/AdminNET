import * as SignalR from "@microsoft/signalr";
import { TokenStore } from "@/store/token.js";
import { BASE_URL } from "@/http/env.js";

// 初始化SignalR对象
const connection = new SignalR.HubConnectionBuilder()
  .configureLogging(SignalR.LogLevel.Information)
  .withUrl(`${BASE_URL}/hubs/onlineUser?token=${TokenStore().getToken}`, {
    transport: SignalR.HttpTransportType.WebSockets,
    skipNegotiation: true,
  })
  .withAutomaticReconnect({
    nextRetryDelayInMilliseconds: () => {
      return 5000; // 每5秒重连一次
    },
  })
  .build();

connection.keepAliveIntervalInMilliseconds = 15 * 1000; // 心跳检测15s
connection.serverTimeoutInMilliseconds = 30 * 60 * 1000; // 超时时间30m

// 启动连接
connection.start().then(() => {
  console.log("启动连接");
});
// 断开连接
connection.onclose(async () => {
  console.log("断开连接");
});
// 重连中
connection.onreconnecting(() => {
  uni.showToast({
    title: "正在重连...",
    icon: "none",
  });
});
// 重连成功
connection.onreconnected(() => {
  uni.showToast({
    title: "重连成功",
    icon: "success",
  });
});

connection.on("OnlineUserList", () => {});
connection.on("ForceOffline", () => {});

export { connection as signalR };
