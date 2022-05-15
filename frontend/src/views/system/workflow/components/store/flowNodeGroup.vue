<template>
  <div
    ref="node"
    id="item_left"
    :class="nodeContainerClass"
    :style="nodeContainerStyle"
    @click="sendclick"
    @mouseup="changeNodeSite">
    <!-- 最左侧的那条竖线 -->
    <div class="ef-node-left"></div>
    <!-- 节点类型的图标 -->
    <div class="ef-node-left-ico">
      <a-icon :type="node.icon" />
    </div>
    <!-- 节点名称 -->
    <div class="ef-node-text" :show-overflow-tooltip="true">
      {{ node.title }}
    </div>
    <!-- <a-button :type="node.type" :icon="node.icon" style="position:absolute;top:30%;left:36%;margin:-10% 0 0 -30%;">
      {{ node.title }}
    </a-button> -->
  </div>
</template>

<script>
export default {
  name: 'Flowlist',
  components: {},
  props: {
    tabValue:
    {
      type: String,
      default: ''
    },
    // 节点属性
    currentNode: {
      type: Object,
      default: null
    },
    node: {
      type: Object,
      default: null
    }
  },
  data() {
    return {}
  },
  created() {
  },
  computed: {
    nodeContainerClass() {
      var choosestyle = 'ef-node-container'
      if (this.currentNode && this.tabValue === 'node') {
        if (this.currentNode.key === this.node.key) { choosestyle = 'ef-node-active' } else { choosestyle = 'ef-node-container' }
      } else { choosestyle = 'ef-node-container' }
      return choosestyle
      },
    // 节点容器样式
    nodeContainerStyle() {
    return {
        left: this.node.position[0] + 'px',
        top: this.node.position[1] + 'px'
      }
    }
  },
  methods: {
    sendclick() {
      this.$emit('nodeclick')
    },
     // 鼠标移动后抬起
    changeNodeSite() {
     // 避免抖动
         this.$emit('changeNodeSite', {
          nodeId: this.node.key,
          left: this.$refs.node.style.left,
          top: this.$refs.node.style.top
      })
    }
  }
}
</script>

<style scoped>
/*节点显示的文字*/
.ef-node-text {
    color: #565758;
    font-size: 12px;
    line-height: 32px;
    margin-top: -2px;
    margin-left: 0px;
    width: 70px;
    /* 设置超出宽度文本显示方式*/
    white-space: nowrap;
    overflow: hidden;
    text-overflow: ellipsis;
    text-align: center;
}
/*节点左侧的图标*/
.ef-node-left-ico {
    line-height: 32px;
    margin-left: 8px;
    margin-top: -2px;
}

/*节点激活样式*/
.ef-node-active {
    cursor: move;
    position: absolute;
    display: flex;
    width: 80px;
    height: 32px;
    border-radius: 5px;
    background-color: rgb(240, 241, 131);
    border: 1px solid blue;
}
.ef-node-container:hover {
    /* 设置移动样式*/
    cursor: move;
    background-color: #F0F7FF;
    /*box-shadow: #1879FF 0px 0px 12px 0px;*/
    background-color: #F0F7FF;
    border: 1px dashed #1879FF;
}
/*节点的最外层容器*/
.ef-node-container {
    position: absolute;
    display: flex;
    width: 80px;
    height: 32px;
    border: 2px solid #0c60ce;
    border-radius: 5px;
    background-color: #fff;
}
/*节点左侧的竖线*/
.ef-node-left {
    width: 4px;
    background-color: #1879FF;
    border-radius: 4px 0 0 4px;
}
.item {
  position: absolute;
  width: 100px;
  height: 40px;
  border: 3px solid rgb(9, 126, 221);
  cursor: pointer;
}
.item:hover{
    border: 5px solid rgb(22, 9, 99);
}
.ef-node-menu-li {
    color: #565758;
    width: 150px;
    border: 1px dashed #E0E3E7;
    margin: 5px 0 5px 0;
    padding: 5px;
    border-radius: 5px;
    padding-left: 8px;
}

.ef-node-menu-li:hover {
    /* 设置移动样式*/
    cursor: move;
    background-color: #F0F7FF;
    border: 1px dashed #1879FF;
    border-left: 4px solid #1879FF;
    padding-left: 5px;
}
</style>
