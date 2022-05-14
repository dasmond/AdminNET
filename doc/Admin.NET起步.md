# Admin.NET起步

## 一、后端

### （一）、下载Admin.NET

1、 打开vs2022，新建一个项目，从仓库里克隆，如下图，仓库 master 分支的地址：https://gitee.com/zuohuaijun/Admin.NET.git；

![](img\20220512222713.png)

![](img\20220512223028.png)

![](img\20220512223242.png)

![](img\20220512234454.png)

![](img\20220512223714.png)



### （二）、配置并启动系统

1、双击打开Admin.NET/backend/Admin.NET.sln项目文件

2、把Admin.NET.Web.Entry设置为启动项目：右键点击“Admin.NET.Web.Entry”，在弹出菜单中选择：设为启动项目；

![](img\20220512224536.png)

3、数据库配置：master分支默认是sqlite

首先，检查数据库类型及配置。打开项目 Admin.NET.EntityFramework.Core 下的目录 DbContexts，打开里面的文件：DefaultDbContext.cs，可以看到写的数据库配置使用了 sqlite：

![](img\20220514080846.png)

其次，查看 Admin.NET.EntityFramework.Core 里的数据库配置文件：dbsettings.Development.json，可以看到里面的数据库配置，然后根据自己的数据库配置进行修改：

![](img\20220514081956.png)

再次，在vs2022中进行输入命令进行初始化数据库：

- 程序包管理控制台默认项目设置为 Admin.NET.Database.Migrations：
  ![](img\20220512231039.png)
  ![](img\20220512231319.png)

然后，在程序包管理器控制台中分别输入以下两条命令来完成初始化：

```
Add-Migration v1.0.0 -Context DefaultDbContext
update-database v1.0.0 -Context DefaultDbContext
```

![](img\20220512231856.png)

第一行命令执行完后，会自动生成一些代码，如：

![](img\20220512235221.png)

接着，再运行第二行命令时，就会在数据库中生成相关表和索引等。

最后，就可以启动后端系统了。默认情况下，系统启动后，自动打开浏览器的访问路径是：http://localhost:5566，这个打开时，看到的页面是这样的：

![](img\20220514094701.png)

别担心，这是正常的。可以通过修改浏览器的地址看看接口是否正常：http://localhost:5566/swagger：

![](img\20220514095024.png)

这个访问地址和路径的配置在：

![](img\20220514095358.png)

这样的配置，只能是本机访问，要想通过 ip 地址访问，或前端在另外一台电脑上，那么，把这个 http://localhost:5566/ 改为此电脑的局域网 IP 即可，如：![](img\20220514095922.png)

这样再访问，就可以看到后台效果了：![](img\20220514101806.png)





## 二、前端

1. 安装配置好nodejs、npm、yarn、代理、vscode等开发环境；
2. vscode打开frontend目录；
3. 在终端窗口中运行命令：yarn，如果报错：

```
PS E:\Workspaces\Admin.NET\frontend> yarn
yarn : 无法加载文件 E:\Workspaces\JS\node_global\yarn.ps1，因为在此系统上禁止运行脚本。有关详细信息，请参阅 https:/go.microsoft.com/fwlink/?LinkID=135170 中的
 about_Execution_Policies。
所在位置 行:1 字符: 1
+ yarn
+ ~~~~
    + CategoryInfo          : SecurityError: (:) []，PSSec
```

解决办法：以管理员身份运行powershell，运行以下命令，回复y 或 a：

```
set-ExecutionPolicy RemoteSigned
```

再次在终端窗口中运行：yarn，成功

3. 在终端窗口中运行命令：yarn run serve，正常启动了，可以自由玩耍啦~（默认用户名密码是：superAdmin，123456）![](img\20220514114748.png)

4. 后台链接配置 在目录 frontend 里的文件：.env.development 中，通过修改里面的配置指向正确的后台链接，如：

   ![](img\20220514114134.png)

   