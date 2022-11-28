# Jobs In Finland API Productizer

Productizer for fetching job postings through testbed from Jobs In Finland API

### Running API locally

To run this productizer locally, Docker installation is required. Run the following command in the root folder of
the repository to start the service:

`docker compose up`

To test testbed authentication, set `ASPNETCORE_ENVIRONMENT` to `Development` (or any other environment than Local)
inside the docker-compose.yml file. To learn more how to set environment variables with Docker compose refer to the
official documentation at https://docs.docker.com/compose/environment-variables/


