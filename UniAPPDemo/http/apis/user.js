// 获取用户信息
export const getUserInfo = () => {
  return uni.$http.get("/api/sysUser/baseInfo", { custom: { loading: false } });
};
// 更新用户信息
export const updateUserInfo = (data) => {
  return uni.$http.post("/api/sysUser/baseInfo", data, {
    custom: { loading: false },
  });
};
// 上传头像
export const uploadAvatar = (file) => {
  return uni.$http.upload("/api/sysFile/uploadAvatar", {
    file: file,
    name: "file",
    custom: { loading: false },
  });
};
