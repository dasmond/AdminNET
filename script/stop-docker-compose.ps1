cd ../etc/docker
docker-compose -f docker-compose.yml -f docker-compose.infrastructure.yml -f docker-compose.infrastructure.override.yml down
docker network rm admin_net-network
cd ../../script