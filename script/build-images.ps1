param ($version='latest')

$currentFolder = $PSScriptRoot
$slnFolder = Join-Path $currentFolder "../"
# Apps
$webAppFolder = Join-Path $slnFolder "Vben2"
$backend = Join-Path $slnFolder "Admin.NET"


$total = 2

Write-Host "===== BUILDING APPLICATIONS =====" -ForegroundColor Yellow

### Fontend
Write-Host "*** BUILDING Fontend 1/$total ***" -ForegroundColor Green
Set-Location $webAppFolder
docker build -f "$webAppFolder/Dockerfile" --no-cache -t admin_net/fontend:$version .

### Backend
Write-Host "**************** BUILDING fontend 2/$total ****************" -ForegroundColor Green
Set-Location $backend
docker build -f "$backend/Admin.NET.Web.Entry/Dockerfile" --no-cache -t admin_net/backend:$version .

### ALL COMPLETED
Write-Host "ALL COMPLETED" -ForegroundColor Green
Set-Location $currentFolder