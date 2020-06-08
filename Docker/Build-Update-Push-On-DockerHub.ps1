Write-Host "Removing all docker containers." -fore green
$containers = ('paymentdemo.api','paymentdemo.db', 'cheapprovider.api', 'expensiveprovider.api','premiumprovider.api')
docker rm $containers -f

Write-Host "Removing all docker images..." -fore green
$images = ('vmandeal/paymentdemo:v1.0','vmandeal/cheapprovider:v1.0','vmandeal/expensiveprovider:v1.0','vmandeal/premiumprovider:v1.0')
docker rmi $images

write-host "republishing projects and apply updates..." -fore green
$projects = ('../paymentdemo','../cheapprovider','../expensiveprovider','../premiumprovider')
dotnet publish $projects

write-host "composing new image from ./docker-compose-dev-build.yaml" -fore green
docker-compose -f docker-compose-dev-build.yaml up -d

write-host "overwriting images on docker hub..." -fore green
docker stop $containers
docker logout
docker login
docker push vmandeal/paymentdemo:v1.0
docker push vmandeal/cheapprovider:v1.0
docker push vmandeal/expensiveprovider:v1.0
docker push vmandeal/premiumprovider:v1.0


Read-Host -Prompt "Press any key to close...";