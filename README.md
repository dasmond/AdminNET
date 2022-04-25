# Admin.NET

#### 🎁 介绍
基于.NET6/Furion/SqlSugar实现的通用管理平台，前端Vue3/Vben。整合最新技术，模块插件式开发，前后端分离，开箱即用。


#### 📖 使用说明

1.  支持各种数据库，后台配置文件自行修改（自动生成数据库及种子数据）
2.  前端运行步骤：1、yarn安装依赖 2、pnpm serve运行 3、pnpm build打包


#### 📖 Docker使用说明
1.	准备:
* 安装docker: https://www.docker.com/products/docker-desktop/
* 安装Tye：dotnet tool install --global Microsoft.Tye --version 0.11.0-alpha.22111.1
* 配置hosts(in Windows: `C:\Windows\System32\drivers\etc\hosts`):

````powershell
	127.0.0.1       elasticsearch
	127.0.0.1       rabbitmq
	127.0.0.1       redis
	127.0.0.1       postgres-db
	127.0.0.1       backend
````
2.	开发:
* 生成项目镜像：script 目录。执行 build-images-local.ps1 将发布内容并生成镜像(推荐)； build-images.ps1 根据源码生成镜像
* 启动镜像： etc/docker 目录。执行 run-docker-compose.ps1

3. tye(k8s)
- 启动tye: script 目录。执行 run-tye.ps1，启动所有后台服务。tye地址：http://127.0.0.1:8000
- 发布k8s. 参考https://www.cnblogs.com/newbe36524/p/14353587.html


注意： 配置文件AppConfig.json和AdminNETConfig.json在docker环境会被删除，请将配置放在appsettings.Production.json中

	

#### 开发教程 💐 特别鸣谢
- 👉 Furion：[https://dotnetchina.gitee.io/furion](https://dotnetchina.gitee.io/furion)
- 👉 Vben：[https://vvbin.cn/doc-next/](https://vvbin.cn/doc-next/)
- 👉 SqlSugar：[https://gitee.com/dotnetchina/SqlSugar](https://gitee.com/dotnetchina/SqlSugar)
- 👉 CSRedis：[https://github.com/ctstone/csredis](https://github.com/ctstone/csredis)
- 👉 MiniExcel：[https://gitee.com/dotnetchina/MiniExcel](https://gitee.com/dotnetchina/MiniExcel)
- 👉 SKIT：[https://gitee.com/fudiwei/DotNetCore.SKIT.FlurlHttpClient.Wechat](https://gitee.com/fudiwei/DotNetCore.SKIT.FlurlHttpClient.Wechat)
- 👉 IdGenerator：[https://github.com/yitter/idgenerator](https://github.com/yitter/idgenerator)
- 👉 UAParser：[https://github.com/ua-parser/uap-csharp/](https://github.com/ua-parser/uap-csharp/)
- 👉 OnceMi.AspNetCore.OSS：[https://github.com/oncemi/OnceMi.AspNetCore.OSS](https://github.com/oncemi/OnceMi.AspNetCore.OSS)
