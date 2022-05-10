
export class Condition {
  index
  costom
  field
  operator
  value
  type
}
export class ConditionFlowNode {
  constructor({ label, nodeId, conditions, type, source, target }) {
    this.label = label
    this.nodeId = nodeId
    this.type = type
    this.source = source
    this.target = target
    this.conditions = conditions
  }
}
export function createconditionFlowNode(Data) {
  return new ConditionFlowNode({
    label: Data.label,
    nodeId: Data.nodeId,
    conditions: Data.conditions,
    type: Data.type,
    source: Data.source,
    target: Data.target
  })
}

export function createconditionFlowNodeDetail(nodeid, source, target) {
  return new ConditionFlowNode({
    label: '',
    nodeId: nodeid,
    type: '条件',
    source: source,
    target: target,
    conditions: []
  })
}
