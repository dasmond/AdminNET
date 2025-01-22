<template>
  <view class="container">
    <view class="profile-card">
      <view class="avatar-section">
        <up-avatar
          :size="80"
          :src="getImageUrl(userInfo.avatar, '/static/avatar.png')"
        ></up-avatar>
        <view class="change-avatar" @click="changeAvatar">更换头像</view>
      </view>

      <view class="info-list">
        <uni-list>
          <uni-list-item
            title="昵称"
            :rightText="userInfo.nickName"
            showArrow
            clickable
            @click="editInfo('nickName')"
          />
          <uni-list-item
            title="性别"
            :rightText="formatSex(userInfo.sex)"
            showArrow
            clickable
            @click="editInfo('sex')"
          />
          <uni-list-item
            title="手机号"
            :rightText="userInfo.phone || '未绑定'"
            showArrow
            clickable
            @click="editInfo('phone')"
          />
          <uni-list-item
            title="邮箱"
            :rightText="userInfo.email || '未绑定'"
            showArrow
            clickable
            @click="editInfo('email')"
          />
        </uni-list>
      </view>
    </view>

    <!-- 编辑弹窗 -->
    <uni-popup ref="editPopup" type="dialog">
      <uni-popup-dialog
        :title="editTitle"
        :value="editValue"
        placeholder="请输入"
        @confirm="confirmEdit"
        @close="closeEdit"
        mode="input"
        :before-close="true"
      ></uni-popup-dialog>
    </uni-popup>

    <!-- 性别选择弹窗 -->
    <uni-popup ref="sexPopup" type="bottom">
      <view class="sex-picker">
        <view class="picker-header">
          <text class="cancel" @click="closeSexPicker">取消</text>
          <text class="title">选择性别</text>
          <text class="confirm" @click="closeSexPicker">确定</text>
        </view>
        <view class="picker-content">
          <view
            class="sex-item"
            v-for="item in sexOptions"
            :key="item.value"
            @click="selectSex(item)"
            :class="{ active: userInfo.sex === item.value }"
          >
            <view class="sex-circle">
              <view
                class="inner-circle"
                v-if="userInfo.sex === item.value"
              ></view>
            </view>
            <text class="sex-text">{{ item.label }}</text>
          </view>
        </view>
      </view>
    </uni-popup>

    <!-- 图片裁剪组件 -->
    <uni-popup ref="cropperPopup" type="center">
      <view class="cropper-wrapper">
        <uni-file-picker
          v-if="showCropper"
          :image-styles="cropperOptions"
          :value="tempImageUrl"
          mode="one"
          @select="onImageSelected"
          @progress="onUploadProgress"
          @success="onUploadSuccess"
          @fail="onUploadFail"
          file-mediatype="image"
          file-extname="jpg,png,jpeg"
        ></uni-file-picker>
      </view>
    </uni-popup>
  </view>
</template>

<script setup>
import { ref } from "vue";
import { UserInfoStore } from "@/store/userInfo.js";
import { uploadAvatar, updateUserInfo } from "@/http/apis/user.js";

const userInfoStore = UserInfoStore();
const userInfo = ref(
  userInfoStore.getUserInfo || {
    nickName: "--",
    sex: "",
    phone: "",
    email: "",
    avatar: "/static/avatar.png",
  }
);

const editPopup = ref(null);
const sexPopup = ref(null);
const cropperPopup = ref(null);
const currentEditType = ref("");
const editValue = ref("");
const editTitle = ref("");
const showCropper = ref(false);
const tempImageUrl = ref("");

// 裁剪配置
const cropperOptions = {
  width: 200,
  height: 200,
  crop: {
    width: 300,
    height: 300,
  },
};

// 性别选项
const sexOptions = [
  { label: "男生", value: 1 },
  { label: "女生", value: 2 },
];

// 格式化性别显示
const formatSex = (value) => {
  const sex = sexOptions.find((item) => item.value === value);
  return sex ? sex.label : "未设置";
};

// 校验规则
const validationRules = {
  nickName: {
    validate: (value) => value.length <= 10,
    message: "昵称不能超过10个字符",
  },
  phone: {
    validate: (value) => /^1[3-9]\d{9}$/.test(value),
    message: "请输入正确的手机号",
  },
  email: {
    validate: (value) =>
      /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/.test(value),
    message: "请输入正确的邮箱地址",
  },
};

// 编辑信息
const editInfo = (type) => {
  currentEditType.value = type;
  editValue.value = userInfo.value[type] || "";

  switch (type) {
    case "nickName":
      editTitle.value = "修改昵称";
      editPopup.value?.open();
      break;
    case "sex":
      sexPopup.value?.open();
      break;
    case "phone":
      editTitle.value = "修改手机号";
      editPopup.value?.open();
      break;
    case "email":
      editTitle.value = "修改邮箱";
      editPopup.value?.open();
      break;
  }
};

// 验证输入
const validateInput = (type, value) => {
  const rule = validationRules[type];
  if (!rule) return true;

  return rule.validate(value);
};

// 更新用户信息
const updateUserInfoData = async (updateData, successMessage, popupRef) => {
  try {
    await uni.showLoading({
      title: "保存中...",
      mask: true,
    });

    const res = await updateUserInfo(updateData);

    if (res.code === 200) {
      // 更新本地用户信息
      userInfoStore.setUserInfo(updateData);
      userInfo.value = userInfoStore.getUserInfo;
      // 触发全局状态更新
      uni.$emit("userInfoUpdated", updateData);

      await uni.hideLoading();

      await uni.showToast({
        title: successMessage,
        icon: "success",
      });

      popupRef.value?.close();
    } else {
      throw new Error(res.message || "修改失败");
    }
  } catch (error) {
    console.error("修改失败:", error);
    await uni.hideLoading();
    await uni.showToast({
      title: "修改失败，请重试",
      icon: "none",
    });
  }
};

// 确认编辑
const confirmEdit = async (value) => {
  // 输入校验
  if (!validateInput(currentEditType.value, value)) {
    uni.showToast({
      title: validationRules[currentEditType.value].message,
      icon: "none",
    });
    return;
  }

  const updateData = {
    ...userInfo.value,
    [currentEditType.value]: value,
  };

  await updateUserInfoData(updateData, "修改成功", editPopup);
};

// 选择性别
const selectSex = async (item) => {
  const updateData = {
    ...userInfo.value,
    sex: item.value,
  };

  await updateUserInfoData(updateData, "修改成功", sexPopup);
};

// 关闭编辑弹窗
const closeEdit = () => {
  editPopup.value?.close();
  currentEditType.value = "";
  editValue.value = "";
};

// 关闭性别选择器
const closeSexPicker = () => {
  sexPopup.value?.close();
};

// 更换头像
const changeAvatar = () => {
  uni.chooseImage({
    count: 1, // 只选择一张图片
    sizeType: ["compressed"], // 压缩图片
    sourceType: ["album", "camera"], // 可以从相册或相机选择
    success: async (res) => {
      try {
        await uni.showLoading({
          title: "上传中...",
          mask: true,
        });

        const uploadResult = await uploadAvatar(res.tempFiles[0]);

        if (uploadResult.code === 200) {
          console.log("uploadResult", uploadResult);
          // 更新本地用户信息
          const newUserInfo = {
            ...userInfo.value,
            avatar: uploadResult.result.url,
          };
          userInfoStore.setUserInfo(newUserInfo);
          userInfo.value = userInfoStore.getUserInfo;
          // 触发全局状态更新
          uni.$emit("userInfoUpdated", newUserInfo);

          await uni.hideLoading();

          await uni.showToast({
            title: "头像更新成功",
            icon: "success",
          });
        } else {
          throw new Error(uploadResult.message || "上传失败");
        }
      } catch (error) {
        console.error("上传头像失败:", error);
        await uni.hideLoading();
        await uni.showToast({
          title: error.message || "上传失败，请重试",
          icon: "none",
          duration: 2000,
        });
      }
    },
    fail: (error) => {
      console.error("选择图片失败:", error);
      uni.showToast({
        title: "选择图片失败，请重试",
        icon: "none",
        duration: 2000,
      });
    },
  });
};
</script>

<style lang="scss" scoped>
.container {
  min-height: 90vh;
  background-color: #f5f5f5;
  padding: 20rpx;
}

.profile-card {
  background-color: #fff;
  border-radius: 16rpx;
  overflow: hidden;

  .avatar-section {
    display: flex;
    flex-direction: column;
    align-items: center;
    padding: 40rpx 0;
    background: linear-gradient(to right, #2979ff, #5cadff);

    .change-avatar {
      margin-top: 20rpx;
      color: #fff;
      font-size: 28rpx;
    }
  }

  .info-list {
    margin-top: 20rpx;
  }
}

.cropper-wrapper {
  width: 600rpx;
  height: 600rpx;
  background-color: #fff;
  border-radius: 16rpx;
  overflow: hidden;
}

.sex-picker {
  background-color: #fff;
  border-radius: 24rpx 24rpx 0 0;
  overflow: hidden;
  padding-bottom: env(safe-area-inset-bottom);

  .picker-header {
    display: flex;
    justify-content: space-between;
    align-items: center;
    padding: 30rpx;
    border-bottom: 1rpx solid #eee;

    .title {
      font-size: 32rpx;
      color: #333;
      font-weight: 500;
    }

    .cancel,
    .confirm {
      font-size: 28rpx;
      padding: 10rpx 20rpx;

      &:active {
        opacity: 0.7;
      }
    }

    .cancel {
      color: #666;
    }

    .confirm {
      color: #2979ff;
      font-weight: 500;
    }
  }

  .picker-content {
    padding: 30rpx;

    .sex-item {
      display: flex;
      align-items: center;
      padding: 30rpx;
      margin: 20rpx 0;
      border-radius: 12rpx;
      background-color: #f8f8f8;
      transition: all 0.3s;
      position: relative;

      &:active {
        transform: scale(0.98);
      }

      &.active {
        background-color: rgba(41, 121, 255, 0.1);

        .sex-circle {
          border-color: #2979ff;
          background-color: #fff;

          .inner-circle {
            background-color: #2979ff;
          }
        }

        .sex-text {
          color: #2979ff;
          font-weight: 500;
        }
      }

      .sex-circle {
        width: 40rpx;
        height: 40rpx;
        border-radius: 50%;
        border: 3rpx solid #ddd;
        margin-right: 24rpx;
        display: flex;
        align-items: center;
        justify-content: center;
        transition: all 0.3s;
        background-color: #fff;

        .inner-circle {
          width: 24rpx;
          height: 24rpx;
          border-radius: 50%;
          transition: all 0.3s;
        }
      }

      .sex-text {
        flex: 1;
        font-size: 32rpx;
        color: #333;
        transition: all 0.3s;
      }
    }
  }
}
</style>
