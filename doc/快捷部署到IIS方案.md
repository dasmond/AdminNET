## 快捷部署到IIS方案

### 后端配置

#### 1. IIS配置

- 新建站点，配置端口和路径，路径为后台项目发布后的文件夹

![image](https://cdn.nlark.com/yuque/0/2021/png/12896569/1620814661295-87e35247-9cb7-480d-aa99-848454aaec81.png)

- 将应用程序池CLR版设置为“无托管代码”

![image](https://cdn.nlark.com/yuque/0/2021/png/12896569/1620814734648-f90c0143-f51d-4ff9-aba6-fb61e98ce418.png)

- 打开OK

![image](https://cdn.nlark.com/yuque/0/2021/png/12896569/1620815069909-d61c7123-5bb4-46a2-9625-22f4b1143d46.png)


### 前端配置



#### 1. 准备工作

请先安装两个IIS模块，URL重写和代理需要用到

###### URL Rewrite

- 官网地址：https://www.iis.net/downloads/microsoft/url-rewrite

- 网盘地址：https://pan.baidu.com/s/1WikAe1Qxv_WIIthRrVZ6sg  提取码：7lbq

###### Application Request Routing

- 官网地址：https://www.iis.net/downloads/microsoft/application-request-routing

- 网盘地址：https://pan.baidu.com/s/1SSO0oJWguJ1xSSxXiL9jCg  提取码：ixqb 

#### 2. IIS配置

- 新建站点，配置端口和路径，路径为前台项目打包后的dist文件夹

![image](https://cdn.nlark.com/yuque/0/2021/png/12896569/1620813475506-a7f09327-0be2-4c79-ab8a-7b4c72619a53.png)

- URL重写配置（手动配置，或者直接使用下方提供的web.confg文件内容）

![image](https://cdn.nlark.com/yuque/0/2021/png/12896569/1620815294456-6ea46fb1-997f-46bd-b364-2036c1161134.png)

![image](https://cdn.nlark.com/yuque/0/2021/png/12896569/1620816397540-c1cd0e10-5ae3-4e56-ac34-066c2d276115.png)

![image](https://cdn.nlark.com/yuque/0/2021/png/12896569/1620816445990-cddfe04b-5ef7-46a1-9a9f-8aa64293bf8a.png)


```
<?xml version="1.0" encoding="UTF-8"?>
<configuration>
  <system.webServer>
    <rewrite>
      <rules>
        <rule name="api" enabled="true" patternSyntax="Wildcard" stopProcessing="true">
          <match url="*api/*" />
          <action type="Rewrite" url="http://localhost:5566/{R:2}" />
        </rule>
        <rule name="hubs" enabled="true" patternSyntax="Wildcard" stopProcessing="true">
          <match url="*hubs/*" />
          <action type="Rewrite" url="http://localhost:5566/hubs/{R:2}" />
        </rule>
        <rule name="index" stopProcessing="true">
          <match url="^((?!(api)).)*$" />
          <conditions>
                        <add input="{REQUEST_FILENAME}" matchType="IsFile" negate="true" />
                        <add input="{REQUEST_FILENAME}" matchType="IsDirectory" negate="true" />
          </conditions>
          <action type="Rewrite" url="/" />
        </rule>
      </rules>
    </rewrite>
  </system.webServer>
</configuration>
```

- 配置代理

![image](https://cdn.nlark.com/yuque/0/2021/png/12896569/1620816913703-cd0f84f1-5448-4ae2-8691-c21a91370bc7.png)

![image](https://cdn.nlark.com/yuque/0/2021/png/12896569/1620816880041-a6c9b32d-e95b-4b4a-be67-deadd191fd3d.png)

![image](https://cdn.nlark.com/yuque/0/2021/png/12896569/1620817025742-aaa72a6a-72d4-43aa-8710-20bc517c41b6.png)

- 打开，登录完成OK

![image](https://cdn.nlark.com/yuque/0/2021/png/12896569/1620817145110-1fc791eb-d648-4b59-9d71-b738da09549d.png)

![image](https://cdn.nlark.com/yuque/0/2021/png/12896569/1620817226341-744c76f8-0958-4b6b-aa50-5c5235447657.png)