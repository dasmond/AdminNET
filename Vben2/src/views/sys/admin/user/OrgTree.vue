<template>
  <div class="bg-white">
    <BasicTree
      title="机构列表"
      toolbar
      search
      :load-data="onLoadDatalazy"
      :clickRowToExpand="true"
      :treeData="treeData"
      :fieldNames="{ key: 'id', title: 'name'}"
      @select="handleSelect"
      ref="treeAction"
    />
  </div>
</template>
<script lang="ts">
  import { defineComponent, onMounted, ref, unref, nextTick } from 'vue';
  import { BasicTree, TreeActionType, TreeItem } from '/@/components/Tree/index';

  import {getOrgTree} from '/@/api/sys/admin';

  export default defineComponent({
    name: 'OrgTree',
    components: { BasicTree },

    emits: ['select'],
    setup(_, { emit }) {
      const treeData = ref<TreeItem[]>([]);
      const treeAction = ref<Nullable<TreeActionType>>(null);

      const  appendNodeByKey =(parentKey: string, values) =>{
        unref(treeAction)?.insertNodeByKey({
          parentKey: parentKey,
          node:values,
          // 往后插入
          push: 'push',
          // 往前插入
          // push:'unshift'
        });
      }

      const  updateNodeByKey=(key: string,values)=>{
        unref(treeAction)?.updateNodeByKey(key,
          values,
        );
      }

      const deleteNodeByKey=(key: string)=> {
        unref(treeAction)?.deleteNodeByKey(key);
      }

      async function fetch() {
        treeData.value = (await getOrgTree()) as unknown as TreeItem[];
        nextTick(() => {
          unref(treeAction)?.filterByLevel(2);
        });
      }

      function handleSelect(keys,obj) {
        emit('select', keys[0], obj.selectedNodes[0]);
        onLoadDatalazy(obj.selectedNodes[0])
      }

      async function onLoadDatalazy(treeNode) {
        if (treeNode.children.length>0) {
          return;
        }
        const nodeChildren=(await getOrgTree({Id:treeNode.id,Code:treeNode.code})) as unknown as TreeItem[];
        await onLoadData(treeNode, nodeChildren);
      }

      function onLoadData(treeNode,nodeChildren) {
        return new Promise((resolve: (value?: unknown) => void) => {
          if (!treeNode.children) {
            resolve();
            return;
          }

          setTimeout(() => {
            if (unref(treeAction)) {

              unref(treeAction)?.updateNodeByKey(treeNode.id, { children: nodeChildren });
              unref(treeAction)?.setExpandedKeys([
                treeNode.id,
                ...unref(treeAction).getExpandedKeys(),
              ]);
            }

            resolve();
            return;
          }, 200);
        });
      }

      onMounted(() => {
        fetch();
       });
      return { treeData, handleSelect, treeAction,onLoadData,onLoadDatalazy,
        appendNodeByKey,updateNodeByKey,deleteNodeByKey,fetch};
    },
  });
</script>
