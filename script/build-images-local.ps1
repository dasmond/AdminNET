param ($version='latest')

$currentFolder = $PSScriptRoot
$slnFolder = Join-Path $currentFolder "../"
# Apps
$webAppFolder = Join-Path $slnFolder "Vben2"
$backend = Join-Path $slnFolder "Admin.NET"

$total = 4

Write-Host "===== BUILDING APPLICATIONS =====" -ForegroundColor Yellow

### Fontend
Write-Host "*** BUILDING Fontend 1/$total ***" -ForegroundColor Green
Set-Location $webAppFolder
# yarn #安装依赖
yarn build
docker build -f "$webAppFolder/Dockerfile.local" --no-cache -t admin_net/fontend:$version . 

### Backend
Write-Host "**************** BUILDING fontend 2/$total ****************" -ForegroundColor Green
Set-Location $backend
dotnet publish "$backend/Admin.NET.Web.Entry/Admin.NET.Web.Entry.csproj" -c Release -o "$backend/Admin.NET.Web.Entry/publish"
docker build -f "$backend/Admin.NET.Web.Entry/Dockerfile.local" --no-cache -t admin_net/sys:$version .

### GateWay
Write-Host "**************** BUILDING fontend 3/$total ****************" -ForegroundColor Green
Set-Location $slnFolder
dotnet publish "$backend/services/gateway/Admin.NET.Gateway.csproj" -c Release -o "$backend/services/gateway/publish"
docker build -f "$backend/services/gateway/Dockerfile.local" --no-cache -t admin_net/gateway:$version .

### Demo
Write-Host "**************** BUILDING fontend 4/$total ****************" -ForegroundColor Green
Set-Location $slnFolder
dotnet publish "$backend/services/demo/Entry/Admin.NET.Demo.Entry.csproj" -c Release -o "$backend/services/demo/Entry/publish"
docker build -f "$backend/services/demo/Entry/Dockerfile.local" --no-cache -t admin_net/demo:$version .

### ALL COMPLETED
Write-Host "ALL COMPLETED" -ForegroundColor Green
Set-Location $currentFolder