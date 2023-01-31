<template>
  <div class="user-news-container">
    <el-tabs stretch class="content-box">
      <el-tab-pane label="站内信">
        <template #label>
          <el-icon><ele-Bell /></el-icon>
          <span style="margin-left: 5px">站内信</span>
        </template>
        <div class="notice-box">
          <template v-if="noticeList.length > 0">
            <template v-for="(v, k) in noticeList">
              <div
                class="notice-item"
                :key="k"
                @click="viewNoticeDetail(v)"
                v-if="v.readStatus == 1 ? false : true"
              >
                <div class="notice-title">
                  {{ v.type == 1 ? "【通知】" : "【公告】" }}{{ v.title }}
                </div>
                <div class="notice-content">{{ removeHtmlSub(v.content) }}</div>
                <div class="notice-time">{{ v.publicTime }}</div>
                <el-divider border-style="dashed" style="margin: 10px 0" />
              </div>
            </template>
          </template>
          <el-empty description="空" v-else></el-empty>
        </div>
        <div class="notice-foot" @click="goToNotice" v-if="noticeList.length > 0">
          前往通知中心
        </div>
      </el-tab-pane>
      <el-tab-pane label="我的">
        <template #label>
          <el-icon><ele-Position /></el-icon>
          <span style="margin-left: 5px">我的</span>
        </template>
        <div style="height: 400px; overflow-y: auto; padding-right: 10px">
          <el-empty description="空"></el-empty>
        </div>
      </el-tab-pane>
    </el-tabs>
    <el-dialog v-model="state.dialogVisible" title="消息详情" draggable width="769px">
      <p v-html="state.content"></p>
      <template #footer>
        <span class="dialog-footer">
          <el-button type="primary" @click="state.dialogVisible = false">确认</el-button>
        </span>
      </template>
    </el-dialog>
  </div>
</template>

<script setup lang="ts" name="layoutBreadcrumbUserNews">
import { reactive, onMounted } from "vue";
import router from "/@/router";
import commonFunction from "/@/utils/commonFunction";

import { getAPI } from "/@/utils/axios-utils";
import { SysNoticeApi } from "/@/api-services/api";
import mittBus from "/@/utils/mitt";
import eventBusKey from "/@/const/eventBusKey";

const props = defineProps({
  noticeList: Array as any,
});
const { removeHtmlSub } = commonFunction();
const state = reactive({
  dialogVisible: false,
  content: "",
});
// 前往通知中心点击
const goToNotice = () => {
  router.push("/dashboard/notice");
};
onMounted(() => {
  //反正多次注册，先卸载一次
  //不能onUnmounted中卸载，会导致无法全局触发
  mittBus.off(eventBusKey.setReadPost);
  mittBus.on(eventBusKey.setReadPost, (noticeId) => {
    console.log(props.noticeList, noticeId);
    let data = props.noticeList.filter((x: any) => x.id == noticeId);
    if (data && data.length > 0) {
      data[0].readStatus = 1;
    }
  });
});
// 查看消息详情
const viewNoticeDetail = async (notice: any) => {
  state.content = notice.content;
  state.dialogVisible = true;

  // 设置已读
  notice.readStatus = 1;
  await getAPI(SysNoticeApi).sysNoticeSetReadPost({ id: notice.id });
};
</script>

<style scoped lang="scss">
.user-news-container {
  .content-box {
    font-size: 12px;
    .notice-box {
      height: 400px;
      padding-right: 10px;

      margin-bottom: 35px;
      &:hover {
        overflow-y: scroll;
      }
    }
    .notice-item {
      &:hover {
        background-color: rgba(#b8b8b8, 0.1);
      }
      // .notice-title {
      // 	color: var(--el-color-primary);
      // }
      .notice-content {
        color: var(--el-text-color-secondary);
        margin-top: 3px;
        margin-bottom: 3px;
      }
      .notice-time {
        color: var(--el-text-color-secondary);
        text-align: right;
      }
    }
  }
  .notice-foot {
    height: 35px;
    width: 100%;
    color: var(--el-color-primary);
    font-size: 14px;
    cursor: pointer;
    position: absolute;
    bottom: 0px;
    background-color: #fff;
    display: flex;
    align-items: center;
    justify-content: center;
  }
}
</style>
