**openapi-generator-cli的使用方法：** 
1. 本机安装java环境（jre > 8）
2. 从项目目录（frontend-vue3）运行终端工具（powershell之类的）
3. 执行命令：
java -jar openapi-generator-cli.jar generate -g typescript-axios -t .\templates\typescript-axios -i http://localhost:5566/swagger/Default/swagger.json -o .\templates\temp  -c openapiconfig.yaml --global-property models,apis

* _-g 指定要使用的生成器_
* _-t 包含重写（自定义）模版的文件夹路径_
* _-i 指定OpenAPI规范文件的位置，支持本地路径和URL，支持JSON和YAML文件格式_
* _-o 指定生成文件的输出路径_
* _-c 指定配置文件路径_
* _--global-property 本意是全局配置项（与配置文件功能相近），而 --global-property models,apis 的写法可以实现仅输出api和model文件_

**建议生成文件后先使用文件夹对比工具对比temp和api_base之间的差异后再进行迁移覆盖**

更多用法请参考：https://openapi-generator.tech/docs/installation
