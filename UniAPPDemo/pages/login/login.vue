<template>
  <view class="login-container">
    <view class="login-box">
      <view class="login-title">欢迎登录</view>
      <up-form :model="info" :rules="rules" ref="form">
        <up-form-item prop="account">
          <up-input
            v-model="info.account"
            placeholder="请输入用户名"
            prefixIcon="account"
            border="surround"
          />
        </up-form-item>
        <up-form-item prop="password">
          <up-input
            v-model="info.password"
            type="password"
            placeholder="请输入密码"
            prefixIcon="lock"
            border="surround"
          />
        </up-form-item>
        <up-form-item prop="code">
          <view class="code-input-box">
            <up-input
              v-model="info.code"
              placeholder="请输入验证码"
              prefixIcon="checkbox-mark"
              border="surround"
            />
            <image
              :src="'data:image/jpg;base64,' + imgUrl"
              class="code-image"
              @click="throttleToken()"
            />
          </view>
        </up-form-item>
        <up-form-item>
          <up-button
            type="primary"
            @click="submit"
            :size="size"
            class="login-button"
            >登录</up-button
          >
        </up-form-item>
      </up-form>
    </view>
  </view>
</template>

<script setup>
// import { throttle } from '@/uni_modules/uview-plus';
import { TokenStore } from "@/store/token.js";

import { PublicKey, account, password, defaultTenantId } from "@/http/env.js"; //引入接口共用地址

import { onShow } from "@dcloudio/uni-app";

import { requestLogin, requestCode } from "@/http/apis/login.js";
import { getUserInfo } from "@/http/apis/user.js";
// import { onShow } from '@dcloudio/uni-app'
import { ref } from "vue";

import { sm2 } from "miniprogram-sm-crypto";
import { TabberStore } from "@/store/tabber.js";
import { UserInfoStore } from "@/store/userInfo.js";
const userInfoStore = UserInfoStore();

const tokenStore = TokenStore();
const size = ref("large");

const imgUrl = ref("");
const form = ref(null);
const info = ref({
  account: account,
  password: password,
  codeId: 0,
  code: "",
  expirySeconds: 0,
});
const rules = ref({
  account: [
    {
      required: true,
      message: "请输入用户名",
      trigger: "blur",
    },
  ],
  password: [
    {
      required: true,
      message: "请输入密码",
      trigger: "blur",
    },
  ],
  code: [
    {
      required: true,
      message: "请输入验证码",
      trigger: "blur",
    },
  ],
});

let timer = null;

// 提交表单
const submit = () => {
  form.value
    .validate()
    .then((valid) => {
      if (valid) {
        UserLogin();
      }
    })
    .catch(() => {});
};

// 清除验证码
const clearCode = () => {
  info.value.code = "";
  info.value.codeId = 0;
};

// 获取验证码
const getCode = async () => {
  try {
    let codeInfo = await requestCode();
    console.log(codeInfo);
    info.value.codeId = codeInfo.result.id;
    imgUrl.value = codeInfo.result.img;
    info.value.expirySeconds = codeInfo.result.expirySeconds;
    startExpiryTimer();
  } catch (error) {
    console.error("获取验证码失败:", error);
  }
};

// 启动验证码过期计时器
const startExpiryTimer = () => {
  clearInterval(timer);
  timer = setInterval(() => {
    if (info.value.expirySeconds > 0) info.value.expirySeconds -= 1;
  }, 1000);
};

// 节流获取验证码
const throttleToken = () => {
  uni.$throttle(getCode, 500);
};

onShow(() => {
  TabberStore().$reset();
  getCode();
});

// 设置token
const setToken = (token, refreshToken) => {
  tokenStore.setToken(token, refreshToken);
};

// 用户登录
const UserLogin = async () => {
  if (info.value.expirySeconds <= 0) {
    uni.$u.toast("验证码过期,请重新获取验证码！");
    return;
  }
  const infoData = prepareLoginData();
  try {
    let loginInfo = await requestLogin(infoData);
    handleLoginResponse(loginInfo);
  } catch (error) {
    console.error("登录失败:", error);
  }
};

// 准备登录数据
const prepareLoginData = () => {
  const infoData = {
    account: info.value.account,
    password: sm2.doEncrypt(info.value.password, PublicKey, 1),
    codeId: info.value.codeId,
    code: info.value.code,
    tenantId: defaultTenantId,
  };
  return infoData;
};

// 处理登录响应
const handleLoginResponse = (loginInfo) => {
  if (loginInfo.code != 200) {
    clearCode();
    getCode();
  } else {
    console.log(loginInfo);
    tokenStore.clearUserInfo;
    setToken(loginInfo.result.accessToken, loginInfo.result.refreshToken);
    fetchUserInfo();
  }
};

// 获取用户信息
const fetchUserInfo = async () => {
  try {
    var userInfo = await getUserInfo();
    console.log(userInfo);
    userInfoStore.setUserInfo(userInfo.result);
    uni.$u.toast("登录成功！");
    navigateToHome();
  } catch (error) {
    console.error("获取用户信息失败:", error);
  }
};

// 导航到主页
const navigateToHome = () => {
  uni.$route({
    url: "/pages/index/index",
    type: "reLaunch",
  });
};
</script>

<style lang="scss">
page {
  height: 100%;
  overflow: hidden;
}

.login-container {
  height: 100%;
  background: linear-gradient(135deg, #6366f1 0%, #818cf8 100%);
  display: flex;
  align-items: center;
  justify-content: center;
  box-sizing: border-box;
  overflow: hidden;
}

.login-box {
  width: 80%;
  max-width: 380px;
  background: rgba(255, 255, 255, 0.98);
  border-radius: 16px;
  padding: 40px 32px;
  box-shadow: 0 10px 30px rgba(0, 0, 0, 0.1);
  position: absolute;
  left: 50%;
  top: 50%;
  transform: translate(-50%, -50%);
}

.login-title {
  font-size: 28px;
  color: #1f2937;
  text-align: center;
  margin-bottom: 36px;
  font-weight: 600;
}

::v-deep .up-form-item {
  margin-bottom: 24px;
}

::v-deep .up-input {
  background-color: #f9fafb;
  border-radius: 8px;
  height: 48px;

  &__content {
    padding-left: 12px;
  }

  &__content__prefix-icon {
    margin-right: 12px;
    font-size: 20px;
    color: #6366f1;
  }

  &__content__field {
    font-size: 15px;
  }
}

.code-input-box {
  display: flex;
  align-items: center;
  gap: 12px;
}

.code-image {
  width: 110px;
  height: 48px;
  border-radius: 8px;
  cursor: pointer;
  border: 1px solid #e5e7eb;
}

.login-button {
  width: 100%;
  height: 48px;
  margin-top: 32px;
  border-radius: 24px;
  font-size: 16px;
  font-weight: 500;
  background: linear-gradient(45deg, #6366f1, #818cf8);
  box-shadow: 0 4px 12px rgba(99, 102, 241, 0.25);

  &:active {
    transform: scale(0.98);
    box-shadow: 0 2px 8px rgba(99, 102, 241, 0.2);
  }
}
</style>
