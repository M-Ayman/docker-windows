docker image build --tag webinar-db:v2 --file docker\db\Dockerfile .

docker image build --tag elasticsearch --file docker\elasticsearch\Dockerfile .

docker image build --tag webinar-save-handler --file docker\save-handler\Dockerfile .

docker image build --tag webinar-index-handler --file docker\index-handler\Dockerfile .

docker image build --tag kibana --file docker\kibana\Dockerfile .

docker image build --tag webinar-app:v4 --file docker\web\Dockerfile .