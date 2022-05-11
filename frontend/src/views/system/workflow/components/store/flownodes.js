export default class FlowNode {
  constructor({ key, title, icon, type, group, endpointOptions, stepBody, parentNodes, nextNodes, position, enable, nextStep, direction }) {
    this.key = key
    this.title = title
    this.icon = icon
    this.type = type
    this.group = group
    this.endpointOptions = endpointOptions
    this.stepBody = stepBody
    this.parentNodes = parentNodes
    this.nextNodes = nextNodes
    this.position = position
    this.enable = enable
    this.nextStep = nextStep
    this.direction = direction
  }
}
export function createFlowNode(Data) {
  return new FlowNode({
    key: Data.key,
    title: Data.title,
    icon: Data.icon,
    type: Data.type,
    group: Data.group,
    endpointOptions: Data.endpointOptions,
    stepBody: Data.stepBody,
    parentNodes: Data.parentNodes,
    nextNodes: Data.nextNodes,
    position: Data.position,
    enable: Data.enable,
    nextStep: Data.nextStep,
    direction: Data.direction
  })
}

export function createFlowNodeDetail(key, title, icon, type, group, endpointOptions, stepBody, parentNodes, nextNodes, enable, nextStep) {
  return new FlowNode({
    key: key,
    title: title,
    icon: icon,
    type: type,
    group: group,
    endpointOptions: endpointOptions,
    stepBody: stepBody,
    parentNodes: parentNodes,
    nextNodes: nextNodes,
    position: [20, 20],
    enable: enable,
    nextStep: nextStep,
    direction: false
  })
}
