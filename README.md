# DockerExample

`Date:` 2026.02.04

`Structure:` 
	Client - Console app to call API.
	ClientLocal - Console app to call API. (on local machine)
	CompanyApi - Api co create request for mongo Db.
	CompanyApiLocal - Api co create request for mongo Db. (on local machine)
	mongo - Database
	
`Connections:` 
	ClientLocal -> CompanyApi -> mongo
	mongo-express -> mongo (for testing functionality of db)
	CompanyApiLocal -> mongo (for testing API without docker)

`Description:` 
	Project to test deployment and access of docker containers.
	To setup docker containers run:
		\# setup mongo and mongo-express:
		run docker-compose -f [a relative link](mongoDocker.yaml) up
		\# build API for docker:
		docker build -f C:\path\for\solution\DockerExample\CompanyApi\Dockerfile . -t companyapi
		\# run  API in docker:
		docker run --name CompanyApi -it --rm -p "32778:8080" -p "32779:8081" -e ASPNETCORE_ENVIRONMENT=Development companyapi-image
		\#\# check swagger Api in docker:
		\# explorer http://localhost:32778/index.html
		\#\# or just run API localy:
		\# dotnet run --project CompanyApi
		\#\# check swagger Api:
		\# explorer http://localhost:5286/index.html