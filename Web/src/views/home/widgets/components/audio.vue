<template>
	<el-card shadow="hover" header="音乐播放器">
		<template #header>
			<el-icon style="display: inline; vertical-align: middle"> <ele-Promotion /> </el-icon>
			<span style=""> 音乐播放器 </span>
		</template>	
		<div class="layout-audioPlayer">
			  <div class="page" @click="handleChangeAudioVolume">
				<audio-player
				  ref="audio"
				  class="audio-box"
				  fileurl="http://music.163.com/song/media/outer/url?id=447925558.mp3"
				></audio-player>
			  </div>
		</div>
	</el-card>
</template>

<script setup>
import { ref } from "vue";
import AudioPlayer from "./audioPlayer.vue";
let audio = ref(null);

function handleChangeAudioVolume() {
  // 点击页面关闭音量键显示
  if (audio.value) {
    audio.value.audioHuds = false;
  }
}

const handleFileChange = (event) => {
  const file = event.target.files[0];
  console.log(file,"文件路径");
  if(file)
  {
	//audio.value.fileurl=file;
	alert(file.name);
	//fileurl = URL.createObjectURL(file);
  }
};
</script>