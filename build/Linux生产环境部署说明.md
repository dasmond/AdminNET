# Admin.NET next 在Linux环境下部署使用说明：

## 1、操作系统环境准备

本次部署采用Ubuntu 20.04服务器版本操作系统，操作系统直接使用阿里云官网提供模板。

查看操作系统内核等基本信息：

```bash
#查看操作系统内核信息
uname -a
#查看操作系统版本
cat /etc/lsb-release
```

## 2、运行环境准备

本次部署使用Supervisor进行进程监控；Nginx进行反向代理；dotnet官网源sdk安装。

####  安装 supervisor 守护进程

```bash
sudo apt-get -y install supervisor
```

#### 安装Nginx

```bash
sudo apt-get -y install nginx
```

####  安装 dotnet sdk 运行时

```bash
wget https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
rm packages-microsoft-prod.deb
sudo apt-get update && \
  sudo apt-get install -y aspnetcore-runtime-6.0
```



## 3、编译安装 Admin.NET 的next分支

摘自master分支部分powershell脚本：

服务器后端编译上传：

```powershell
# 定义服务器地址
$remoteIp = "118.190.161.209"

# supervisor 服务名称
$supervisorServername = "DotnetSmartPrison"

# 定义路径
$buildFolder = (Get-Item -Path "./" -Verbose).FullName
$coreFolder = Join-Path $buildFolder "../Admin.NET"
$outputFolder = Join-Path $buildFolder "../outputs"

## 清空本地历史
Remove-Item $outputFolder -Force -Recurse -ErrorAction Ignore
New-Item -Path $outputFolder -ItemType Directory

## 发布后端

### 还原&打包
Set-Location $coreFolder
dotnet restore
dotnet publish --no-restore --output (Join-Path $outputFolder "smart_prison_core") --configuration Release 

### 推送到服务器
Set-Location $outputFolder
ssh root@${remoteIp} "rm -rf /wwwroot/smart_prison_core; exit"
scp -r (Join-Path $outputFolder "smart_prison_core") root@${remoteIp}:/wwwroot

### dotnet 命令运行
# ssh root@$remoteIp "cd /wwwroot/smart_prison_core; dotnet Dilon.Web.Entry.dll --urls http://*:5000; exit"

### 如果是用 supervisor 守护进程的需要使用
ssh root@${remoteIp} "sudo supervisorctl restart $supervisorServername; exit"
```

前端编译发布：

```powershell
# 定义服务器地址
$remoteIp = "118.190.161.209"

# 定义路径
$buildFolder = (Get-Item -Path "./" -Verbose).FullName
$vueFolder = Join-Path $buildFolder "../Web"
$outputFolder = Join-Path $buildFolder "../outputs"

## 清空本地历史
Remove-Item $outputFolder -Force -Recurse -ErrorAction Ignore
New-Item -Path $outputFolder -ItemType Directory

## 发布前端

### 还原&打包
Set-Location $vueFolder
cnpm install
cnpm run build

### 推送到服务器
Set-Location $outputFolder
##ssh root@$remoteIp "rm -rf /wwwroot/smart_prison_vue; exit"
##scp -r (Join-Path $outputFolder "smart_prison_vue") root@${remoteIp}:/wwwroot
ssh root@$remoteIp "rm -rf /wwwroot/smart_prison_vue/*; exit"
scp -r (Join-Path $vueFolder "dist/*") root@${remoteIp}:/wwwroot/smart_prison_vue
##scp -r (Join-Path $vueFolder "vue-dist/*") root@${remoteIp}:/wwwroot/smart_prison_vue/js
```

supervisor配置文件：

```bash
cd /etc/supervisor/conf.d/
vi smart_prison_core.conf
##############添加如下内容################
#配置程序名称
[program:DotnetSmartPrison]
#运行程序的命令
command=dotnet Admin.NET.Web.Entry.dll --urls="http://*:5000" 
#命令执行的目录
directory=/wwwroot/smart_prison_core
#错误日志文件
stderr_logfile=/var/log/smart_prison.err.log
#输出日志文件
stdout_logfile=/var/log/smart_prison.out.log 
#进程环境变量
environment=ASPNETCORE_ENVIRONMENT='Production'
#进程执行的用户身份
user=root
#程序是否自启动
autostart=true
#程序意外退出是否自动重启
autorestart=true
#启动时间间隔（秒）
startsecs=5
stopsignal=INT
```

Nginx 配置文件：

配置 demo.devqd.com代理：

```bash
server {
    listen 443 ssl;
    server_name demo.devqd.com;
    #此处为证书存放路径，根据实际情况填写
    ssl_certificate   /etc/nginx/cert/8964528_demo.devqd.com.pem;
    ssl_certificate_key  /etc/nginx/cert/8964528_demo.devqd.com.key;
    ssl_session_timeout 5m;
    ssl_ciphers
    ECDHE-RSA-AES128-GCM-SHA256:ECDHE:ECDH:AES:HIGH:!NULL:!aNULL:!MD5:!ADH:!RC4;
    ssl_protocols TLSv1.2 TLSv1.3;
   # ssl_protocols TLSv1 TLSv1.1 TLSv1.2 TLSv1.3;
    ssl_prefer_server_ciphers on;
    
    add_header X-Xss-Protection 1;
    add_header X-Xss-Protection mod=block;
    add_header X-Content-Type-Options nosniff;
    add_header X-Frame-Options SAMEORIGIN;
    #add_header Content-Security-Policy "default-src 'self'; img-src 'self' data:";
    
    location / {
        proxy_set_header Host $host;
        proxy_set_header X-Real-IP $remote_addr;
        proxy_set_header X-Forwarded-For $proxy_add_x_forwarded_for;
        proxy_set_header   X-Forwarded-Proto $scheme;
        proxy_redirect   http:// https://;
        root   /wwwroot/smart_prison_vue;
        index  index.html index.htm;
        try_files $uri $uri/ /index.html;
    }
    access_log  /var/log/nginx/access.log;
}

server {
    listen 80;
    server_name demo.devqd.com;

    location / {
      set $redirect_to_https "${http_upgrade_insecure_requests}${https}";
       if ($redirect_to_https = "1") {
          add_header Vary Upgrade-Insecure-Requests;
          return 307 https://$server_name$request_uri;
       }
      add_header Content-Security-Policy upgrade-insecure-requests;
      add_header Strict-Transport-Security max-age=86400;
    }
    access_log  /var/log/nginx/access.log;
    return 301 https://$server_name$request_uri;
}
```

配置 apidemo.devqd.com代理：

```bash
server {
    listen 443 ssl;
    server_name apidemo.devqd.com;
    #此处为证书存放路径，根据实际情况填写
    ssl_certificate   /etc/nginx/cert/9032069_apidemo.devqd.com.pem;
    ssl_certificate_key  /etc/nginx/cert/9032069_apidemo.devqd.com.key;
    ssl_session_timeout 5m;
    ssl_ciphers
    ECDHE-RSA-AES128-GCM-SHA256:ECDHE:ECDH:AES:HIGH:!NULL:!aNULL:!MD5:!ADH:!RC4;
    ssl_protocols TLSv1.2 TLSv1.3;
   # ssl_protocols TLSv1 TLSv1.1 TLSv1.2 TLSv1.3;
    ssl_prefer_server_ciphers on;
    
    add_header X-Xss-Protection 1;
    add_header X-Xss-Protection mod=block;
    add_header X-Content-Type-Options nosniff;
    add_header X-Frame-Options SAMEORIGIN;
    #add_header Content-Security-Policy "default-src 'self'; img-src 'self' data:";
    
    location / {
        proxy_set_header Host $host;
        proxy_set_header X-Real-IP $remote_addr;
        proxy_set_header X-Forwarded-For $proxy_add_x_forwarded_for;
        proxy_set_header   X-Forwarded-Proto $scheme;
        proxy_redirect   http:// https://;
        proxy_pass http://production_servers;
    }
    access_log  /var/log/nginx/access.log;
}

server {
    listen 80;
    server_name apidemo.devqd.com;

    location / {
      set $redirect_to_https "${http_upgrade_insecure_requests}${https}";
       if ($redirect_to_https = "1") {
          add_header Vary Upgrade-Insecure-Requests;
          return 307 https://$server_name$request_uri;
       }
      add_header Content-Security-Policy upgrade-insecure-requests;
      add_header Strict-Transport-Security max-age=86400;
    }
    access_log  /var/log/nginx/access.log;
    return 301 https://$server_name$request_uri;
}
```

修改Web目录下.env.production文件内容：

```bash
# 线上环境
ENV = 'production'

# 线上环境接口地址----此处填写生产环境的域名，注意不能与前端域名相同。
# 本次部署前端使用域名：https://demo.devqd.com
# 后端使用域名：https://apidemo.devqd.com
# 两个域名注意区分
VITE_API_URL = 'https://apidemo.devqd.com'
```



## 4、启动运行

启动或重启supervisor：

```bash
#启动
sudo systemctl start supervisor
#重启
sudo systemctl restart supervisor
```

启动或重启nginx：

```bash
#启动
sudo systemctl start nginx
#重启
sudo systemctl restart nginx
```



