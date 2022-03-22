<template>
  <BasicModal v-bind="$attrs" @register="registerModal" showFooter title="配置" @ok="handleSubmit">
    <a-table
      ref="table"
      size="middle"
      :columns="columns"
      :dataSource="tbData"
      :pagination="false"
      :alert="true"
      :loading="tbData.length > 0 ? false : true"
      :rowKey="(record) => record.id"
      :scroll="{ y: true }"
    >
      <template #columnComment="{ record }">
        <a-input v-model:value="record.columnComment" />
      </template>
      <template #effectType="{ record }">
        <a-select
          style="width: 120px"
          v-model:value="record.effectType"
          :disabled="judgeColumns(record)"
          @change="effectTypeChange(record, $event)"
        >
          <a-select-option
            v-for="(item, index) in effectTypeData"
            :key="index"
            :value="item.code"
            >{{ item.name }}</a-select-option
          >
        </a-select>
      </template>
      <template #dictTypeCode="{ record }">
        <a-select
          style="width: 120px"
          v-model:value="record.dictTypeCode"
          :disabled="
            record.effectType !== 'radio' &&
            record.effectType !== 'select' &&
            record.effectType !== 'checkbox'
          "
        >
          <a-select-option v-for="(item, index) in dictDataAll" :key="index" :value="item.code">{{
            item.value
          }}</a-select-option>
        </a-select>
      </template>
      <template #whetherTable="{ record }">
        <a-checkbox v-model:checked="record.whetherTable" />
      </template>
      <template #whetherRetract="{ record }">
        <a-checkbox v-model:checked="record.whetherRetract" />
      </template>
      <template #whetherAddUpdate="{ record }">
        <a-checkbox v-model:checked="record.whetherAddUpdate" :disabled="judgeColumns(record)" />
      </template>
      <template #whetherRequired="{ record }">
        <a-checkbox v-model:checked="record.whetherRequired" :disabled="judgeColumns(record)" />
      </template>

      <template #queryWhether="{ record }">
        <a-switch v-model:checked="record.queryWhether">
          <template #checkedChildren><check-outlined /></template>
          <template #unCheckedChildren><close-outlined /></template>
        </a-switch>
      </template>
      <template #queryType="{ record }">
        <a-select
          style="width: 100px"
          v-model:value="record.queryType"
          :disabled="!record.queryWhether"
        >
          <a-select-option
            v-for="(item, index) in codeGenQueryTypeData"
            :key="index"
            :value="item.code"
            >{{ item.name }}</a-select-option
          >
        </a-select>
      </template>
    </a-table>
  </BasicModal>
  <FkModal @register="registerFkModal" @success="fkHandleSuccess" />
</template>
<script lang="ts">
  import { defineComponent, ref } from 'vue';
  import { columns } from './codeGenerate.data';
  import FkModal from './fkModal.vue';
  import { BasicModal, useModalInner, useModal } from '/@/components/Modal';
  import { useMessage } from '/@/hooks/web/useMessage';
  import {
    getGenerateConfigList,
    updateGenerateConfig,
    getDictDataList,
    getDictDataDropdown,
  } from '/@/api/sys/admin';

  export default defineComponent({
    components: { BasicModal, FkModal },
    emits: ['success', 'register'],
    setup(_, { emit }) {
      const { createMessage } = useMessage();
      const tbData = ref<any[]>([]);
      const effectTypeData = ref<any[]>();
      const dictDataAll = ref<any[]>();
      const codeGenQueryTypeData = ref<any[]>();
      const [registerFkModal, { openModal: openFkModal }] = useModal();
      const [registerModal, { setModalProps, closeModal }] = useModalInner(async (data) => {
        setModalProps({ confirmLoading: false });
        getGenerateConfigList({ CodeGenId: data.id }).then((res) => {
          var data = res.data;
          data.forEach((item) => {
            for (const key in item) {
              if (item[key] === 'Y') {
                item[key] = true;
              }
              if (item[key] === 'N') {
                item[key] = false;
              }
            }
          });
          tbData.value = data;
        });
      });
      /**
       * 初始化下拉框数据源
       */
      loadDictTypeDropDown();
      /**
       * 判断是否（用于是否能选择或输入等）
       */
      function judgeColumns(data) {
        if (
          data.columnName.indexOf('createdUserName') > -1 ||
          data.columnName.indexOf('createdTime') > -1 ||
          data.columnName.indexOf('updatedUserName') > -1 ||
          data.columnName.indexOf('updatedTime') > -1 ||
          data.columnKey === 'True'
        ) {
          return true;
        }
        return false;
      }
      /**
       * 作用类型改变
       */
      function effectTypeChange(data, value) {
        if (value === 'fk') {
          openFkModal(true, { data });
        }
      }
      async function loadDictTypeDropDown() {
        effectTypeData.value = await getDictDataDropdown('code_gen_effect_type');
        dictDataAll.value = await (await getDictDataList()).data;
        codeGenQueryTypeData.value = await getDictDataDropdown('code_gen_query_type');
      }
      /**
       * 外键弹窗回调
       */
      function fkHandleSuccess(data) {
        let index = tbData.value.findIndex((c) => c.columnName == data.columnName);
        tbData[index] = data;
      }
      /**
       * 提交
       */
      async function handleSubmit() {
        try {
          setModalProps({ confirmLoading: true });
          var lst = tbData.value;
          lst.forEach((item) => {
            // 必填那一项转换
            for (const key in item) {
              if (item[key] === true) {
                item[key] = 'Y';
              }
              if (item[key] === false) {
                item[key] = 'N';
              }
            }
          });
          let ret = await updateGenerateConfig(lst);
          if (ret != null) {
            if (ret.code == 204) {
              closeModal();
              createMessage.success('保存成功！');
            } else {
              createMessage.warning(ret.message + ret.message[0].messages);
            }
          } else {
            createMessage.error('未知错误');
          }
          emit('success');
        } finally {
          setModalProps({ confirmLoading: false });
        }
      }
      return {
        registerModal,
        tbData,
        columns,
        handleSubmit,
        effectTypeData,
        dictDataAll,
        judgeColumns,
        effectTypeChange,
        codeGenQueryTypeData,
        registerFkModal,
        fkHandleSuccess,
      };
    },
  });
</script>
