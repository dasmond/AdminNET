import { BASE_URL } from "@/http/env.js";

/**
 * 处理图片路径
 * @param {string} path - 图片路径
 * @param {string} defaultImage - 默认图片路径，可选
 * @returns {string} 处理后的完整图片路径
 */
export const getImageUrl = (path, defaultImage = "/static/default.png") => {
  if (!path) return defaultImage;

  // 如果已经是完整的URL，直接返回
  if (path.startsWith("http") || path.startsWith("https")) {
    return path;
  }

  // 如果是base64，直接返回
  if (path.startsWith("data:image")) {
    return path;
  }

  // 如果是本地静态资源路径（以/static开头），直接返回
  if (path.startsWith("/static")) {
    return path;
  }

  // 其他情况，拼接BASE_URL
  // 确保BASE_URL末尾有/，并且path开头没有/
  const cleanPath = path.startsWith("/") ? path.slice(1) : path;
  return `${BASE_URL}${cleanPath}`;
};
