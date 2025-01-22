// utils/jwt.js

/**
 * 解密 JWT
 * @param {string} token - JWT token
 * @returns {Object} 解密后的 JSON 对象
 */
export function decryptJWT(token) {
  try {
    token = token.replace(/_/g, "/").replace(/-/g, "+");
    const json = decodeURIComponent(escape(window.atob(token.split(".")[1])));
    return JSON.parse(json);
  } catch (error) {
    console.error("Failed to decrypt JWT:", error);
    return null;
  }
}

/**
 * 将 JWT 时间戳转换成 Date 对象
 * @param {number} timestamp - 时间戳
 * @returns {Date} Date 对象
 */
export function getJWTDate(timestamp) {
  return new Date(timestamp * 1000);
}

/**
 * 参数处理
 * @param {Object} params - 参数对象
 * @returns {string} 编码后的参数字符串
 */
export function transParams(params) {
  let result = "";
  for (const propName in params) {
    const value = params[propName];
    const part = encodeURIComponent(propName) + "=";
    if (value !== null && value !== "" && typeof value !== "undefined") {
      if (typeof value === "object") {
        for (const key in value) {
          if (
            value[key] !== null &&
            value[key] !== "" &&
            typeof value[key] !== "undefined"
          ) {
            const paramKey = `${propName}[${key}]`;
            const subPart = encodeURIComponent(paramKey) + "=";
            result += subPart + encodeURIComponent(value[key]) + "&";
          }
        }
      } else {
        result += part + encodeURIComponent(value) + "&";
      }
    }
  }
  return result.slice(0, -1); // 去掉最后一个 '&'
}
