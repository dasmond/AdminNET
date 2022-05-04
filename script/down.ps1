cd ../etc/docker
docker-compose -f docker-compose.infrastructure.yml down
docker network rm admin_net-network
cd ../../script