cd ../etc/docker
docker network create admin_net-network
docker-compose -f docker-compose.infrastructure.yml -f docker-compose.infrastructure.override.yml up -d
cd ../../script