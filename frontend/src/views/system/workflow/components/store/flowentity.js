export default class FlowEntity {
  constructor({ title, version, description, icon, color, group, inputs, nodes }) {
    this.title = title
    this.version = version
    this.description = description
    this.icon = icon
    this.color = color
    this.group = group
    this.inputs = inputs
    this.nodes = nodes
  }
}
export function createFlowFlowEntity(Data) {
  return new FlowEntity({
    title: Data.title,
    version: Data.version,
    description: Data.description,
    icon: Data.icon,
    color: Data.color,
    group: Data.group,
    inputs: Data.inputs,
    nodes: Data.nodes
  })
}
