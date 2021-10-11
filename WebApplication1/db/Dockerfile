FROM mysql: 5.7.22
COPY ./WebApplication1/WebApplication1/db/migrations/ /home/database
COPY ./WebApplication1/WebApplication1/db/dataset/ /home/database
COPY ./WebApplication1/WebApplication1/ci/init_database.sh/ /home/docker-entrypoint-initdb.d/init_database.sh