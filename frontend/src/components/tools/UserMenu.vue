<template>
  <div class="user-wrapper">
    <div class="content-box">
      <!-- <a href="" target="_blank">
        <span class="action">
          <a-icon type="question-circle-o"></a-icon>
        </span>
      </a> -->
      <!-- 全屏 -->
      <div class="action" @click="fullSwitch">
         <a-icon type="fullscreen-exit" v-if="isFullscreen" />
        <a-icon type="fullscreen" v-else />
      </div>
      <!-- 用户信息 -->
      <notice-icon class="action" />
      <a-dropdown>
        <span class="action ant-dropdown-link user-dropdown-menu ">
          <a-avatar class="avatar" size="small" src="https://cdn.eleadmin.com/20200610/avatar.jpg" />
          <span>{{ nickname }}</span>
        </span>
        <a-menu slot="overlay" class="user-dropdown-menu-wrapper">
          <a-menu-item key="4" v-if="mode === 'sidemenu'">
            <a @click="appToggled()" >
              <a-icon type="swap"/>
              <span>切换应用</span>
            </a>
          </a-menu-item>
          <a-menu-item key="0">
            <router-link :to="{ name: 'center' }">
              <a-icon type="user"/>
              <span>个人中心</span>
            </router-link>
          </a-menu-item>
          <a-menu-item key="1">
            <router-link :to="{ name: 'settings' }">
              <a-icon type="setting"/>
              <span>账户设置</span>
            </router-link>
          </a-menu-item>
          <a-menu-divider/>
          <a-menu-item key="3">
            <a href="javascript:;" @click="handleLogout">
              <a-icon type="logout"/>
              <span>退出登录</span>
            </a>
          </a-menu-item>
        </a-menu>
      </a-dropdown>

      <!-- 主题 -->
      <span class="action" style="padding: 0 18px;" @click="toggle">
        <a-icon type="setting" />
        <setting-drawer ref="mychild" ></setting-drawer>
      </span>
    </div>
    <a-modal
      title="切换应用"
      :visible="visible"
      :footer="null"
      :confirm-loading="confirmLoading"
      @cancel="handleCancel"
    >
      <a-form :form="form1" >
        <a-form-item
          :labelCol="labelCol"
          :wrapperCol="wrapperCol"
          label="选择应用"
        >
          <a-menu
            mode="inline"
            :default-selected-keys="this.defApp"
            style="border-bottom:0px;lineHeight:55px;"
          >
            <a-menu-item v-for="(item) in userInfo.apps" :key="item.code" style="top:0px;" @click="switchApp(item.code)">
              {{ item.name }}
            </a-menu-item>
          </a-menu>
        </a-form-item>
      </a-form>
    </a-modal>
  </div>
</template>

<script>
import NoticeIcon from '@/components/NoticeIcon'
import { mapActions, mapGetters } from 'vuex'
import { ALL_APPS_MENU } from '@/store/mutation-types'
import Vue from 'vue'
import { message } from 'ant-design-vue/es'
import { toggleFullscreen } from '@/utils/util'
import SettingDrawer from '@/components/SettingDrawer'
export default {
  name: 'UserMenu',
  components: {
    NoticeIcon,
    SettingDrawer
  },
  props: {
    mode: {
      type: String,
      // sidemenu, topmenu
      default: 'sidemenu'
    }
  },
  data () {
    return {
      labelCol: {
        xs: { span: 24 },
        sm: { span: 5 }
      },
      wrapperCol: {
        xs: { span: 24 },
        sm: { span: 16 }
      },
      visible: false,
      confirmLoading: false,
      form1: this.$form.createForm(this),
      defApp: [],
      // 是否全屏状态
      isFullscreen: false,
      isShowset:false
    }
  },

  computed: {
    ...mapGetters(['nickname', 'avatar', 'userInfo'])
  },
  mounted(){
    // 监听浏览器窗口大小改变
    window.addEventListener('resize', this.onResizeListener);
  },
  unmounted() {
    // 销毁浏览器窗口大小改变监听
    window.removeEventListener('resize', this.onResizeListener);
  },
  methods: {
    ...mapActions(['Logout', 'MenuChange']),
    handleLogout () {
      this.$confirm({
        title: '提示',
        content: '真的要注销登录吗 ?',
        okText: '确定',
        cancelText: '取消',
        onOk: () => {
          return this.Logout({}).then(() => {
            setTimeout(() => {
              window.location.reload()
            }, 16)
          }).catch(err => {
            this.$message.error({
              title: '错误',
              description: err.message
            })
          })
        },
        onCancel () {
        }
      })
    },
    
    /**
     * 打开切换应用框
     */
    appToggled () {
      this.visible = true
      this.defApp.push(Vue.ls.get(ALL_APPS_MENU)[0].code)
    },

    switchApp (appCode) {
      this.visible = false
      this.defApp = []
      const applicationData = this.userInfo.apps.filter(item => item.code === appCode)
      const hideMessage = message.loading('正在切换应用！', 0)
      this.MenuChange(applicationData[0]).then((res) => {
        hideMessage()
      // eslint-disable-next-line handle-callback-err
      }).catch((err) => {
        message.error('应用切换异常')
      })
    },
    handleCancel () {
      this.form1.resetFields()
      this.visible = false
    },
    // 全屏
    fullSwitch () {
      try {
        this.isFullscreen = toggleFullscreen();
      } catch (e) {
        this.$message.error('您的浏览器不支持全屏模式');
      }
    },
    // 主题色按钮
    toggle(){
      this.$refs.mychild.showDrawer()
    }
  }
}
</script>

<style lang="less" scoped>
    .appRedio {
    border:1px solid #91d5ff;
    padding:10px 20px;
    background: #e6f7ff;
    border-radius:2px;
    margin-bottom:10px;
      color: #91d5ff;
    /*display: inline;
    margin-bottom:10px;*/
    }
</style>
