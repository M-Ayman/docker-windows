docker container run -d --name webinar-db webinar-db:v2

docker container run -d --name message-queue nats:nanoserver

docker container run -d --name elasticsearch elasticsearch

docker container run -d --name save-handler webinar-save-handler

docker container run -d --name index-handler webinar-index-handler

docker container run -d -P --name kibana kibana

docker container run -d -P --name web-app webinar-app:v4