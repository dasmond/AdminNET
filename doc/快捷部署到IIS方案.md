## 快捷部署到IIS方案

### 后端配置

#### 1. IIS配置

- 新建站点，配置端口和路径，路径为后台项目发布后的文件夹

![image](/doc/img/IIS/1.png)

- 将应用程序池CLR版设置为“无托管代码”

![image](/doc/img/IIS/2.png)

- 打开OK

![image](/doc/img/IIS/3.png)


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

![image](/doc/img/IIS/4.png)

- URL重写配置（手动配置，或者直接使用下方提供的web.confg文件内容）

![image](/doc/img/IIS/5.png)

![image](/doc/img/IIS/6.png)

![image](/doc/img/IIS/7.png)


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

![image](/doc/img/IIS/8.png)

![image](/doc/img/IIS/9.png)

![image](/doc/img/IIS/10.png)

- 打开，登录完成OK

![image](/doc/img/IIS/11.png)

![image](/doc/img/IIS/12.png)