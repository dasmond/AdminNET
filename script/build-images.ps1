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
docker build -f "$webAppFolder/Dockerfile" --no-cache -t admin_net/fontend:$version .

### Backend
Write-Host "**************** BUILDING fontend 2/$total ****************" -ForegroundColor Green
Set-Location $backend
docker build -f "$backend/Admin.NET.Web.Entry/Dockerfile" --no-cache -t admin_net/sys:$version .

### GateWay
Write-Host "**************** BUILDING fontend 3/$total ****************" -ForegroundColor Green
Set-Location $slnFolder
docker build -f "$backend/services/gateway/Dockerfile" --no-cache -t admin_net/gateway:$version .

### Demo
Write-Host "**************** BUILDING fontend 4/$total ****************" -ForegroundColor Green
Set-Location $slnFolder
docker build -f "$backend/services/demo/Entry/Dockerfile" --no-cache -t admin_net/demo:$version .

### ALL COMPLETED
Write-Host "ALL COMPLETED" -ForegroundColor Green
Set-Location $currentFolder