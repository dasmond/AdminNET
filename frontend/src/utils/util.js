export function timeFix () {
  const time = new Date()
  const hour = time.getHours()
  return hour < 9 ? '早上好' : hour <= 11 ? '上午好' : hour <= 13 ? '中午好' : hour < 20 ? '下午好' : '晚上好'
}

export function welcome () {
  const arr = ['休息一会儿吧', '准备吃什么呢?', '要不要打一把 LOL', '我猜你可能累了']
  const index = Math.floor(Math.random() * arr.length)
  return arr[index]
}

/**
 * 触发 window.resize
 */
export function triggerWindowResizeEvent () {
  const event = document.createEvent('HTMLEvents')
  event.initEvent('resize', true, true)
  event.eventType = 'message'
  window.dispatchEvent(event)
}

export function handleScrollHeader (callback) {
  let timer = 0

  let beforeScrollTop = window.pageYOffset
  callback = callback || function () {}
  window.addEventListener(
    'scroll',
    event => {
      clearTimeout(timer)
      timer = setTimeout(() => {
        let direction = 'up'
        const afterScrollTop = window.pageYOffset
        const delta = afterScrollTop - beforeScrollTop
        if (delta === 0) {
          return false
        }
        direction = delta > 0 ? 'down' : 'up'
        callback(direction)
        beforeScrollTop = afterScrollTop
      }, 50)
    },
    false
  )
}

export function isIE () {
  const bw = window.navigator.userAgent
  const compare = (s) => bw.indexOf(s) >= 0
  const ie11 = (() => 'ActiveXObject' in window)()
  return compare('MSIE') || ie11
}

/**
 * Remove loading animate
 * @param id parent element id or class
 * @param timeout
 */
export function removeLoadingAnimate (id = '', timeout = 1500) {
  if (id === '') {
    return
  }
  setTimeout(() => {
    document.body.removeChild(document.getElementById(id))
  }, timeout)
}

  /**
   * 让浏览器全屏切换
   * @returns {boolean} 是否是全屏状态
   */
  export function toggleFullscreen(el, fullscreen) {
    if (!el) {
        el = document.documentElement;
        if (fullscreen === undefined) {
            fullscreen = !(
            document.fullscreenElement || 
            document.webkitFullscreenElement ||
            document.mozFullScreenElement ||
            document.msFullscreenElement
            );
        }
    }
    if (fullscreen) {
        const rfs = (
            el.requestFullScreen ||
            el.webkitRequestFullScreen ||
            el.mozRequestFullScreen ||
            el.msRequestFullScreen
        );
        if (rfs) {
            rfs.call(el);
        } else {
            throw new Error('您的浏览器不支持全屏模式');
        }
    } else {
        const cfs = (
            document.exitFullScreen ||
            document.webkitCancelFullScreen ||
            document.mozCancelFullScreen ||
            document.msExitFullscreen
        );
        if (cfs) {
            cfs.call(document);
        }
    }
    return fullscreen;
}
/**
 * 获取屏幕宽度
 * @returns {number}
 */
export function screenWidth() {
    return document.documentElement.clientWidth || document.body.clientWidth;
}
/**
 * 获取屏幕高度
 * @returns {number}
 */
export function screenHeight() {
    return document.documentElement.clientHeight || document.body.clientHeight;
}
