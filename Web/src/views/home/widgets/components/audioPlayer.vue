<template>
  <div>
    <audio
      @timeupdate="updateProgress"
      controls
      ref="audioRef"
      style="display: none"
    >
      <source :src="fileurl" type="audio/mpeg" />
      您的浏览器不支持音频播放
    </audio>
	
    <div class="audio-right">
	  
      <img
        v-if="audioStatus == 'pause'"
        @click="playAudio"
        class="dialogAudioPlay"
        src="./img/play.png"
        alt="点击播放"
      />
      <img
        v-if="audioStatus != 'pause'"
        @click="playAudio"
        class="dialogAudioPlay"
        src="./img/pause.png"
        alt="点击暂停"
      />
      
	  <div class="progress-bar-bg" id="progressBarBg" v-dragto="setAudioIcon">
        <div class="progress-bar" id="progressBar"></div>
      </div>
	  
      <div class="audio-time" style="min-height: 10px">
        <span class="audio-length-current" id="audioCurTime">{{
          audioStart
        }}</span
        >/
        <span class="audio-length-total">{{ duration }}</span>
      </div>
      
	  <div class="volume">
        <div
          @click.stop="
            () => {
              return false;
            }
          "
          class="volume-progress"
          v-show="audioHuds"
        >
          <div
            class="volume-bar-bg"
            id="volumeBarBg"
            v-adjuster="handleShowMuteIcon"
          >
            <div class="volume-bar" id="volumeBar"></div>
          </div>
        </div>
        <!-- <i class="iconfont pl-1" :class="audioIcon" @click.stop="audioHuds = !audioHuds"> </i> -->
        <img
          class="audio_high"
          @click.stop="audioHuds = !audioHuds"
          src="./img/audio_high.png"
          alt="音量"
        />
      </div>
    </div>
  </div>
</template>

<script setup>
import { ref, onMounted, reactive, computed, onUpdated } from "vue";
const props = defineProps({
  fileurl: "",
});
const audioStatus = ref("play");
const audioStart = ref("0:00");
const currentTime = ref("0:00");
const duration = ref("0:00");
const audioVolume = ref(0.5);
const audioHuds = ref(false);
const audioRef = ref();
const VDragto = reactive({
  mounted: function (el, binding, vnode) {
    el.addEventListener(
      "click",
      (e) => {
        let wdiv = document.getElementById("progressBarBg").clientWidth;
        let audio = vnode.ctx.refs.audioRef;
        // return;
        // 只有音乐开始播放后才可以调节，已经播放过但暂停了的也可以
        let ratemin = e.offsetX / wdiv;
        let rate = ratemin * 100;
        document.getElementById("progressBar").style.width = rate + "%";
        audio.currentTime = audio.duration * ratemin;
        audio.play();
        binding.value();
      },
      false
    );
  },
});
const VAdjuster = reactive({
  mounted: function (el, binding, vnode) {
    el.addEventListener(
      "click",
      (e) => {
        let hdiv = document.getElementById("volumeBarBg").clientHeight;
        let audio = vnode.ctx.refs.audioRef;
        // 只有音乐开始播放后才可以调节，已经播放过但暂停了的也可以
        let ratemin = e.offsetY / hdiv;
        let rate = ratemin * 100;
        document.getElementById("volumeBar").style.height = rate + "%";
        audio.volume = ratemin;
        binding.value(rate / 100);
      },
      false
    );
  },
});
onMounted(() => {
  fetch();
});

function fetch() {
  // let that = this;
  var myVid = audioRef.value;
  myVid.loop = true;//循环
  // 监听音频播放完毕
  myVid.addEventListener(
    "ended",
    function () {
      audioStatus.value = "play"; // 显示播放icon
      document.getElementById("progressBar").style.width = "0%"; // 进度条初始化
    },
    false
  );
  if (myVid != null) {
    myVid.oncanplay = function () {
      duration.value = transTime(myVid.duration); // 计算音频时长
    };
    myVid.volume = 0.5; // 设置音量50%
  }
}
// 播放暂停控制
function playAudio() {
  let recordAudio = audioRef.value; // 获取audio元素
  if (recordAudio.paused) {
    recordAudio.play();
    audioStatus.value = "pause";
  } else {
    recordAudio.pause();
    audioStatus.value = "play";
  }
}
// 更新进度条与当前播放时间
function updateProgress(e) {
  var value = e.target.currentTime / e.target.duration;
  if (document.getElementById("progressBar")) {
    document.getElementById("progressBar").style.width = value * 100 + "%";
    if (e.target.currentTime === e.target.duration) {
      audioStatus.value = "pause";
    }
  } else {
    audioStatus.value = "pause";
  }

  audioStart.value = transTime(audioRef.value.currentTime);
}
/**
 * 音频播放时间换算
 * @param {number} value - 音频当前播放时间，单位秒
 */
function transTime(time) {
  var duration = parseInt(time);
  var minute = parseInt(duration / 60);
  var sec = (duration % 60) + "";
  var isM0 = ":";
  if (minute === 0) {
    minute = "00";
  } else if (minute < 10) {
    minute = "0" + minute;//分保留2位
  }
  if (sec.length === 1) {
    sec = "0" + sec;//秒保留2位
  }
  return minute + isM0 + sec;//00:00
}
function setAudioIcon() {
  audioStatus.value = "pause";
}
function handleShowMuteIcon(val) {
  audioVolume.value = val;
}
computed(() => {
  function audioIcon() {
    if (audioHuds.value) {
      return audioVolume.value < 0.01
        ? "checked icon-jingyin"
        : "checked icon-shengyin";
    } else {
      return "icon-shengyin";
    }
  }
});
</script>

<style lang="scss" scoped>
.volume {
  position: relative;
  .volume-progress {
    position: absolute;
    top: -42%;
	left: 42px;
    width: 24px;
    height: 90px;
    background: rgb(0,0,0,0.3);//声音背景色
    border-radius: 5px;
    padding-top: 5px;
  }
  .volume-bar-bg {
    margin: 0 auto;
    width: 6px;
    height: 80px;//声音进度条高度
    background: #dcdcdc;
    flex: 1;
    position: relative;
	border-radius: 5px;
    transform: rotate(180deg);//自下而上
    cursor: pointer;
    .volume-bar {
      width: 6px;
      height: 50%;
      background: #ff6600;//声音进度条颜色
      border-radius: 5px;
    }
  }
  .checked {
    color: #56bf8b;
  }
}
.audio-right {
  width: 100%;
  height: 49px;
  line-height: 49px;
  background: #f8f8f8;
  border-radius: 10px;
  display: flex;
  padding: 0 15px;
  .dialogAudioPlay {
    width: 48px;
    height: 48px;
    cursor: pointer;
  }
  .progress-bar-bg {//进度条背景
    background-color: #d1edc4;
	border-radius: 5px;//与进度条同样弧度
    flex: 1;
    position: relative;
    height: 10px;
    top: 50%;
    transform: translateY(-50%);
    margin-top: -1px;
    cursor: pointer;
    margin: 0 10px;
  }
  .progress-bar {
    background-color: #529b2e;//进度条颜色
    width: 0%;
    height: 10px;
    border-radius: 5px;
  }

  .audio-time {//时间
    overflow: hidden;
    font-size: 14px;
    .audio-length-total {//总时长
      float: right;
    }
    .audio-length-current {//播放时间
      float: left;
    }
  }
}
.audio_high {
  width: 50px;
  height: 50px;
}
</style>

