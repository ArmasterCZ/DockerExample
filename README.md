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
		run docker-compose -f [a relative link](mongoDocker.yaml) up
