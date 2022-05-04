docker-compose -p ms-sql-server -f ms-sql-server.yml up -d
docker-compose -p elastic-search -f elastic-search.yml up -d
docker-compose -p redis -f redis.yml up -d
docker-compose -p rabbit-mq-server -f rabbit-mq-server.yml up -d