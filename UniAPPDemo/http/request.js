import { BASE_URL } from "./env.js"; //引入接口共用地址
import { TokenStore } from "@/store/token.js"; //引入仓库，使用的是pinia
import { decryptJWT, getJWTDate, transParams } from "@/utils/jwt.js";

// Define constants for repeated strings
const AUTHORIZATION = "Authorization";
const BEARER = "Bearer ";
const CONTENT_TYPE = "Content-Type";
const APPLICATION_JSON = "application/json";
const X_REQUESTED_WITH = "X-Requested-With";
const XML_HTTP_REQUEST = "XMLHttpRequest";
const ACCESS_TOKEN_KEY = "access-token";
const REFRESH_ACCESS_TOKEN_KEY = `x-${ACCESS_TOKEN_KEY}`;
const TIMEOUT = 60000;

export const setRequestConfig = (vm) => {
  uni.$http.setConfig((config) => {
    /* config 为默认全局配置*/
    config.baseURL = BASE_URL;
    config.timeout = TIMEOUT; //超时时间
    config.header = {
      /* 设置全局请求头*/
      [CONTENT_TYPE]: APPLICATION_JSON,
      [X_REQUESTED_WITH]: XML_HTTP_REQUEST,
      [AUTHORIZATION]: BEARER + TokenStore().getToken,
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
        config.header[AUTHORIZATION] = `${BEARER}${token}`;

        // 判断 accessToken 是否过期
        const jwt = decryptJWT(token);
        const exp = getJWTDate(jwt.exp);

        // token 已经过期
        if (new Date() >= exp) {
          // 获取刷新 token
          const refreshAccessToken = TokenStore().getRefreshToken;
          // 携带刷新 token
          if (refreshAccessToken) {
            config.header["X-Authorization"] = `${BEARER}${refreshAccessToken}`;
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

      console.log("serve", serve);
      // 处理 401
      if (status === 401 || serve.code === 401) {
        handleUnauthorized();
        return Promise.reject(res);
      }

      // 处理未进行规范化处理的
      if (status >= 400) {
        throw new Error(res.statusText || "Request Error.");
      }

      // 处理规范化结果错误
      if (serve && serve.hasOwnProperty("errors") && serve.errors) {
        throw new Error(JSON.stringify(serve.errors || "Request Error."));
      }
      if (res.header && ACCESS_TOKEN_KEY in res.header && REFRESH_ACCESS_TOKEN_KEY in res.header) {
        const accessToken = res.header[ACCESS_TOKEN_KEY];
        const refreshAccessToken = res.header[REFRESH_ACCESS_TOKEN_KEY];

        if (accessToken === "invalid_token") {
          TokenStore().clear();
        } else if (refreshAccessToken && accessToken && accessToken !== "invalid_token") {
          TokenStore().setToken(accessToken, refreshAccessToken);
        }
      }
      // 响应拦截及自定义处理
      if (serve.code != 200) {
        uni.$showMsg(serve.message);
      }

      return res.data;
    },
    (error) => {
      console.log(error);
      // 处理响应错误
      if (error.response) {
        if (error.response.status === 401) {
          handleUnauthorized();
        }
      }

      uni.$showMsg(error.errMsg);

      return Promise.reject(error);
    }
  );
};

function handleUnauthorized() {
  TokenStore().clear();
  uni.$showMsg("登录过期，请重新登录!");
  TokenStore().clearUserInfo;
  setTimeout(() => {
    uni.$route({
      url: "/pages/login/login",
      type: "reLaunch",
    });
  }, 1000);
}
