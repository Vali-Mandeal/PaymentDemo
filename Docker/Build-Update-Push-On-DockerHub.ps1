Write-Host "Removing all docker containers." -fore green
$containers = ('paymentdemo.api','paymentdemo.db')
docker rm $containers -f

Write-Host "Removing all docker images..." -fore green
docker rmi vmandeal/paymentdemo:v1.0

Write-Host "Republishing projects and apply updates..." -fore green
dotnet publish ../PaymentDemo

Write-Host "Composing new image from ./docker-compose-dev-build.yaml" -fore green
docker-compose -f docker-compose-dev-build.yaml up -d

write-host "overwriting images on docker hub..." -fore green
docker stop $containers -f
docker logout
docker login
docker push vmandeal/paymentdemo:v1.0

Read-Host -Prompt "Press any key to close...";