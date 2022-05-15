import { createFlowNodeDetail } from '@/views/system/workflow/components/store/flownodes'
const sourcenodes = []
sourcenodes.push(
  createFlowNodeDetail(
     'start', '开始', 'thunderbolt', 'primary', '1', [
    {
      anchor: 'Right',
      maxConnections: -1
    }
  ], null, [], [], true, null
  )
)
sourcenodes.push(
  createFlowNodeDetail(
     'step', '任务', '', 'primary', '2', [
    {
      anchor: 'Right',
      maxConnections: -1
    },
    {
      anchor: 'Left',
      maxConnections: -1
    }
  ], null, [], [], true, null
  )
)
// sourcenodes.push(
//   createFlowNodeDetail(
//     'sourcecondition', '条件', 'question-circle', 'primary', '2', [
//     {
//       anchor: 'Top',
//       maxConnections: -1
//     },
//     {
//       anchor: 'Left',
//       maxConnections: -1
//     },
//     {
//       anchor: 'Right',
//       maxConnections: -1
//     }
//   ], null, [], []
//   )
// )
sourcenodes.push(
  createFlowNodeDetail(
     'end', '结束', 'check-circle', 'primary', '1', [
    {
      anchor: 'Left',
      maxConnections: -1
    }
  ], null, [], [], true, null
  )
)
export { sourcenodes }
