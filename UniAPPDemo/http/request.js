import { BASE_URL } from "./env.js"; //引入接口共用地址
import { TokenStore } from "@/store/token.js"; //引入仓库，使用的是pinia
import { decryptJWT, getJWTDate, transParams } from "@/utils/jwt.js";
export const setRequestConfig = (vm) => {
  uni.$http.setConfig((config) => {
    /* config 为默认全局配置*/
    config.baseURL = BASE_URL;
    config.timeout = 60000; //超时时间
    config.header = {
      /* 设置全局请求头*/
      "Content-Type": "application/json",
      "X-Requested-With": "XMLHttpRequest",
      Authorization: "Bearer " + TokenStore().getToken,
    };
    config.custom = {
      /* 设置全局自定义配置*/
      loading: true,
    };
    return config;
  });
  // 请求拦截
  uni.$http.interceptors.request.use(
    (config) => {
      if (config.custom.loading) {
        uni.showLoading();
      }
      let token = TokenStore().getToken;
      if (token) {
        // 将 token 添加到请求报文头中
        config.header["Authorization"] = `Bearer ${token}`;

        // 判断 accessToken 是否过期
        const jwt = decryptJWT(token);
        const exp = getJWTDate(jwt.exp);

        // token 已经过期
        if (new Date() >= exp) {
          // 获取刷新 token
          const refreshAccessToken = TokenStore().getRefreshToken;
          // 携带刷新 token
          if (refreshAccessToken) {
            config.header["X-Authorization"] = `Bearer ${refreshAccessToken}`;
          }
        }
      }
      // get请求映射params参数
      if (config.method?.toLowerCase() === "get" && config.data) {
        let url = config.url + "?" + transParams(config.data);
        url = url.slice(0, -1);
        config.data = {};
        config.url = url;
      }
      return config;
    },
    (error) => {
      return Promise.reject(error);
    }
  );
  // 响应拦截
  uni.$http.interceptors.response.use(
    (res) => {
      if (res.config.custom.loading) {
        uni.hideLoading();
      }

      // 获取状态码和返回数据
      var status = res.statusCode;
      var serve = res.data;
      // 处理 401
      if (status === 401) {
        TokenStore().Clear();
      }

      // 处理未进行规范化处理的
      if (status >= 400) {
        throw new Error(res.statusText || "Request Error.");
      }

      // 处理规范化结果错误
      if (serve && serve.hasOwnProperty("errors") && serve.errors) {
        throw new Error(JSON.stringify(serve.errors || "Request Error."));
      }
      const accessTokenKey = "access-token";
      const refreshAccessTokenKey = `x-${accessTokenKey}`;
      //判断headers是否有accessTokenKey属性
      if (
        res.header &&
        accessTokenKey in res.header &&
        refreshAccessTokenKey in res.header
      ) {
        // 读取响应报文头 token 信息
        var accessToken = res.header[accessTokenKey];
        var refreshAccessToken = res.header[refreshAccessTokenKey];

        // 判断是否是无效 token
        if (accessToken === "invalid_token") {
          TokenStore().Clear();
        }
        // 判断是否存在刷新 token，如果存在则存储在本地
        else if (
          refreshAccessToken &&
          accessToken &&
          accessToken !== "invalid_token"
        ) {
          TokenStore().setToken(accessToken, refreshAccessToken);
        }
      }
      // 响应拦截及自定义处理
      if (serve.code === 401) {
        TokenStore().Clear();
        uni.$showMsg("请先登录!");
        TokenStore().clearUserInfo;
        setTimeout(() => {
          uni.$route({
            url: "/pages/login/login",
            type: "reLaunch",
          });
        }, 1000);
        return Promise.reject(res);
      } else if (serve.code != 200) {
        uni.$showMsg(serve.message);
      }

      return res.data;
    },
    (error) => {
      console.log(error);
      // 处理响应错误
      if (error.response) {
        if (error.response.status === 401) {
          TokenStore().Clear();
          uni.$showMsg("请登录!");
          TokenStore().clearUserInfo;
          setTimeout(() => {
            uni.$router({
              url: "/pages/login/login",
              type: "reLaunch",
            });
          }, 1000);
        }
      }

      uni.$showMsg(error.errMsg);

      return Promise.reject(error);
    }
  );
};
