import { getImageUrl } from "@/utils/image.js";

export default {
  methods: {
    // 处理图片路径的全局方法
    getImageUrl(path, defaultImage) {
      return getImageUrl(path, defaultImage);
    },
  },
};
