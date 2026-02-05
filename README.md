# DockerExample

`Date:` 2026.02.04

`Structure:` 
	Client - Console app to call API.
	CompanyApi - Api co create request for mongo Db
	mongo - Database
	
`Connections:` 
	Client -> CompanyApi -> mongo
	mongo-express -> mongo (for testing functionality of db)
	CompanyApiLocal -> mongo (for testing API without docker)

`Description:` 
	Project to test deployment and access of docker containers.
	To setup docker containers run:
		\# setup mongo and mongo-express
		run docker-compose -f [a relative link](mongoDocker.yaml) up
		\# build and run API in docker
		docker build -f C:\path\for\solution\DockerExample\CompanyApi\Dockerfile . -t companyapi
		docker run --name CompanyApi -it --rm -p "32778:8080" -p "32779:8081" companyapi-image
		\# or run API localy
		\# dotnet run --project CompanyApi