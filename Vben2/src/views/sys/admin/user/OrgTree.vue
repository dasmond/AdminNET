<template>
  <div class="m-4 mr-0 overflow-hidden bg-white">
    <BasicTree
      title="机构列表"
      toolbar
      search
      :clickRowToExpand="false"
      :treeData="treeData"
      :fieldNames="{ key: 'id', title: 'name' }"
      @select="handleSelect"
      ref="treeAction"
    />
  </div>
</template>
<script lang="ts">
  import { defineComponent, onMounted, ref, unref, nextTick } from 'vue';
  import { BasicTree, TreeActionType, TreeItem } from '/@/components/Tree/index';

  import { getOrgList } from '/@/api/sys/admin';

  export default defineComponent({
    name: 'OrgTree',
    components: { BasicTree },

    emits: ['select'],
    setup(_, { emit }) {
      const treeData = ref<TreeItem[]>([]);
      const treeAction = ref<Nullable<TreeActionType>>(null);

      async function fetch() {
        treeData.value = (await getOrgList()) as unknown as TreeItem[];
        nextTick(() => {
          unref(treeAction)?.filterByLevel(1);
        });
      }

      function handleSelect(keys) {
        emit('select', keys[0]);
      }

      onMounted(() => {
        fetch();
      });
      return { treeData, handleSelect, treeAction };
    },
  });
</script>
