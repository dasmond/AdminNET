jsPlumb.ready(() => {
  var common = {
    isSource: true, // 拖动端点时可以自动创建连接
    isTarget: true,
    endpoint: 'Dot', // 锚点形状  dot圆形  Rectangle 方形
    connector: ['Flowchart'], // 连线的形状     Bezier: 贝塞尔曲线  Flowchart: 具有90度转折点的流程线 StateMachine: 状态机 Straight: 直线
    // anchor: ['Left', 'Right']   //锚点的位置
    connectorStyle: { outlineStroke: 'green', strokeWidth: 1 }, // 连接线样式（拖动自动连接时生效）
    maxConnections: -1, // 限制连线的数量，-1为不限制
    overlays: [['Arrow', { width: 12, length: 12, location: 0.5 }]] // 长宽 位置
  }

  jsPlumb.connect(
    {
      // source: "item_left",    //连接源头
      // target: "item_right",    //连接去向
      // paintStyle: { stroke: 'red', strokeWidth: 3 },        // 连接线的样式 （设置源头和去向时生效）
      // endpointStyle: { fill: 'red', outlineStroke: 'black', outlineWidth: 2 },     // 锚点的样式  fill填充    outlineStroke边框（设置源头和去向时生效）
      // overlays: [["Arrow", { width: 12, length: 12, location: 0.5 }]] // 长宽 位置
      /*
    Arrow 一个可配置的箭头
    Label 标签，可以在链接上显示文字信息
    PlainArrow 原始类型的箭头
    Diamond 菱形箭头
    Custom 自定义类型
    */
      /*
   默认参数的简介:
   Anchor 锚点，即端点链接的位置
   Anchors 多个锚点 [源锚点，目标锚点].
   Connector 链接
   ConnectionsDetachable 节点是否可以用鼠标拖动使其断开，默认为true。即用鼠标链接上的连线，也可以使用鼠标拖动让其断开。设置成false，可以让其拖动也不会自动断开。
   Container 连线的容器
   DoNotThrowErrors 是否抛出错误
   ConnectionOverlays 链接遮罩层
   DragOptions 拖动设置
   DropOptions 拖放设置
   Endpoint 端点
   Endpoints 数组形式的，[源端点，目标端点]
   EndpointOverlays 端点遮罩层
   EndpointStyle 端点样式
   EndpointStyles [源端点样式，目标端点样式]
   EndpointHoverStyle 端点鼠标经过的样式
   EndpointHoverStyles [源端点鼠标经过样式，目标端点鼠标经过样式]
   HoverPaintStyle 鼠标经过链接线时的样式
   LabelStyle 标签样式
   LogEnabled 是否启用日志
   Overlays 连接线和端点的遮罩层样式
   MaxConnections 端点最大连接线数量默认为1， 设置成-1可以表示无数个链接
   PaintStyle 连线样式
   ReattachConnections 端点是否可以再次重新链接
   RenderMode 渲染模式，默认是svg
   Scope 作用域，用来区分哪些端点可以链接，作用域相同的可以链接 */
    },
    common
  )
  // 新增一个端点
  jsPlumb.addEndpoint(
    'start',
    {
      anchors: 'Right',
      uuid: 'fromId'
    },
    common
  )
  jsPlumb.addEndpoint(
    'task',
    {
      anchor: 'Left',
      uuid: 'toId'
    },
    common
  )
  jsPlumb.addEndpoint(
    'end',
    {
      anchor: 'Left',
      uuid: 'toId'
    },
    common
  )

  // 可拖拽   containment限制拖拽区域 grid拖拽时网格对齐
  jsPlumb.draggable('start', { containment: 'diagramContainer', grid: [10, 10] })
  jsPlumb.draggable('task', { containment: 'diagramContainer', grid: [10, 10] })
  jsPlumb.draggable('end', { containment: 'diagramContainer', grid: [10, 10] })
  // jsPlumb.addEndpoint(
  //   'test',
  //   {
  //     anchors: 'Right',
  //     uuid: 'testddd'
  //   },
  //   common
  // )
  // jsPlumb.draggable('test', { containment: 'efContainer', grid: [10, 10] })
  // this.nodeList.forEach(item => {
  //   console.log(item)
  //   var timestamp = new Date().getTime()
  //   jsPlumb.addEndpoint(
  //     item.id,
  //     {
  //       anchors: 'Right',
  //       uuid: timestamp
  //     },
  //     common
  //   )
  //   jsPlumb.draggable(item.id, { containment: 'efContainer', grid: [10, 10] })
  // })
  // 可拖拽   containment限制拖拽区域 grid拖拽时网格对齐
  // jsPlumb.draggable('item_left', { containment: 'efContainer', grid: [10, 10] })
  // jsPlumb.draggable('item_right', { containment: 'diagramContainer', grid: [10, 10] })
  // jsPlumb.draggable('item_right1', { containment: 'diagramContainer', grid: [10, 10] })

  // 给连接添加点击事件
  jsPlumb.bind('click', function(conn, originalEvent) {
    if (window.prompt('确定删除所点击的链接吗？ 输入1确定') === '1') {
      jsPlumb.detach(conn) // 删除连接
      // 删除节点包括相关的连接
      // jsPlumb.remove('item_left')
      // 通过编码连接,需要在addEndpoint时，就给该断点加上一个uuid, 然后通过connect()方法，将两个断点链接上,建议给每个断点都加上唯一的uuid
      // jsPlumb.connect({ uuids: ['fromId', 'toId'] })

      /**
   * jsPlumb Events列表
   connection
   connectionDetached
   connectionMoved
   click
   dblclick
   endpointClick
   endpointDblClick
   contextmenu
   beforeDrop  连接前的检查，可以用来判断是否建立连接
   beforeDetach
   zoom
   Connection Events
   Endpoint Events
   Overlay Events
   Unbinding Events
   */
    }
  })
})
export const easyFlowMixin = {
    data() {
        return {
            jsplumbSetting: {
                // 动态锚点、位置自适应
                Anchors: ['Top', 'TopCenter', 'TopRight', 'TopLeft', 'Right', 'RightMiddle', 'Bottom', 'BottomCenter', 'BottomRight', 'BottomLeft', 'Left', 'LeftMiddle'],
                // 容器ID
                Container: 'efContainer',
                // 连线的样式，直线或者曲线等，可选值:  StateMachine、Flowchart，Bezier、Straight
                Connector: ['Bezier', {curviness: 100}],
                // Connector: ['Straight', {stub: 20, gap: 1}],
                // Connector: ['Flowchart', {stub: 30, gap: 1, alwaysRespectStubs: false, midpoint: 0.5, cornerRadius: 10}],
                // Connector: ['StateMachine', {margin: 5, curviness: 10, proximityLimit: 80}],
                // 鼠标不能拖动删除线
                ConnectionsDetachable: false,
                // 删除线的时候节点不删除
                DeleteEndpointsOnDetach: false,
                /**
                 * 连线的两端端点类型：圆形
                 * radius: 圆的半径，越大圆越大
                 */
                // Endpoint: ['Dot', {radius: 5, cssClass: 'ef-dot', hoverClass: 'ef-dot-hover'}],
                /**
                 * 连线的两端端点类型：矩形
                 * height: 矩形的高
                 * width: 矩形的宽
                 */
                // Endpoint: ['Rectangle', {height: 20, width: 20, cssClass: 'ef-rectangle', hoverClass: 'ef-rectangle-hover'}],
                /**
                 * 图像端点
                 */
                // Endpoint: ['Image', {src: 'https://www.easyicon.net/api/resizeApi.php?id=1181776&size=32', cssClass: 'ef-img', hoverClass: 'ef-img-hover'}],
                /**
                 * 空白端点
                 */
                Endpoint: ['Blank', {Overlays: ''}],
                // Endpoints: [['Dot', {radius: 5, cssClass: 'ef-dot', hoverClass: 'ef-dot-hover'}], ['Rectangle', {height: 20, width: 20, cssClass: 'ef-rectangle', hoverClass: 'ef-rectangle-hover'}]],
                /**
                 * 连线的两端端点样式
                 * fill: 颜色值，如：#12aabb，为空不显示
                 * outlineWidth: 外边线宽度
                 */
                EndpointStyle: {fill: '#1879ffa1', outlineWidth: 1},
                // 是否打开jsPlumb的内部日志记录
                LogEnabled: true,
                /**
                 * 连线的样式
                 */
                PaintStyle: {
                    // 线的颜色
                    stroke: '#E0E3E7',
                    // 线的粗细，值越大线越粗
                    strokeWidth: 1,
                    // 设置外边线的颜色，默认设置透明，这样别人就看不见了，点击线的时候可以不用精确点击，参考 https://blog.csdn.net/roymno2/article/details/72717101
                    outlineStroke: 'transparent',
                    // 线外边的宽，值越大，线的点击范围越大
                    outlineWidth: 10
                },
                DragOptions: {cursor: 'pointer', zIndex: 2000},
                /**
                 *  叠加 参考： https://www.jianshu.com/p/d9e9918fd928
                 */
                Overlays: [
                    // 箭头叠加
                    ['Arrow', {
                        width: 10, // 箭头尾部的宽度
                        length: 8, // 从箭头的尾部到头部的距离
                        location: 1, // 位置，建议使用0～1之间
                        direction: 1, // 方向，默认值为1（表示向前），可选-1（表示向后）
                        foldback: 0.623 // 折回，也就是尾翼的角度，默认0.623，当为1时，为正三角
                    }],
                    // ['Diamond', {
                    //     events: {
                    //         dblclick: function (diamondOverlay, originalEvent) {
                    //             console.log('double click on diamond overlay for : ' + diamondOverlay.component)
                    //         }
                    //     }
                    // }],
                    ['Label', {
                        label: '',
                        location: 0.1,
                        cssClass: 'aLabel'
                    }]
                ],
                // 绘制图的模式 svg、canvas
                RenderMode: 'svg',
                // 鼠标滑过线的样式
                HoverPaintStyle: {stroke: '#b0b2b5', strokeWidth: 1},
                // 滑过锚点效果
                // EndpointHoverStyle: {fill: 'red'}
                Scope: 'jsPlumb_DefaultScope' // 范围，具有相同scope的点才可连接
            },
            /**
             * 连线参数
             */
            jsplumbConnectOptions: {
                isSource: true,
                isTarget: true,
                // 动态锚点、提供了4个方向 Continuous、AutoDefault
                anchor: 'Continuous',
                // 设置连线上面的label样式
                labelStyle: {
                    cssClass: 'flowLabel'
                },
                // 修改了jsplumb 源码，支持label 为空传入自定义style
                emptyLabelStyle: {
                    cssClass: 'emptyFlowLabel'
                }
            },
            /**
             * 源点配置参数
             */
            jsplumbSourceOptions: {
                // 设置可以拖拽的类名，只要鼠标移动到该类名上的DOM，就可以拖拽连线
                filter: '.flow-node-drag',
                filterExclude: false,
                anchor: 'Continuous',
                // 是否允许自己连接自己
                allowLoopback: true,
                maxConnections: -1,
                onMaxConnections: function (info, e) {
                    console.log(`超过了最大值连线: ${info.maxConnections}`)
                }
            },
            // 参考 https://www.cnblogs.com/mq0036/p/7942139.html
            jsplumbSourceOptions2: {
                // 设置可以拖拽的类名，只要鼠标移动到该类名上的DOM，就可以拖拽连线
                filter: '.flow-node-drag',
                filterExclude: false,
                // anchor: 'Continuous',
                // 是否允许自己连接自己
                allowLoopback: true,
                connector: ['Flowchart', {curviness: 50}],
                connectorStyle: {
                    // 线的颜色
                    stroke: 'red',
                    // 线的粗细，值越大线越粗
                    strokeWidth: 1,
                    // 设置外边线的颜色，默认设置透明，这样别人就看不见了，点击线的时候可以不用精确点击，参考 https://blog.csdn.net/roymno2/article/details/72717101
                    outlineStroke: 'transparent',
                    // 线外边的宽，值越大，线的点击范围越大
                    outlineWidth: 10
                },
                connectorHoverStyle: {stroke: 'red', strokeWidth: 2}
            },
            jsplumbTargetOptions: {
                // 设置可以拖拽的类名，只要鼠标移动到该类名上的DOM，就可以拖拽连线
                filter: '.flow-node-drag',
                filterExclude: false,
                // 是否允许自己连接自己
                anchor: 'Continuous',
                allowLoopback: true,
                dropOptions: {hoverClass: 'ef-drop-hover'}
            }
        }
    }
}
