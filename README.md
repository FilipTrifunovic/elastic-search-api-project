# Simple REST API with Elasticsearch Integration using C# .NET Core and NEST

This project demonstrates a basic RESTful API built using C# .NET Core and integrated with Elasticsearch using the NEST client. It's containerized with Docker and can be easily run using `docker-compose`.

## Prerequisites

- Docker installed on your machine.
- Basic knowledge of C#, .Net Core and RESTful APIs.

## Getting Started

1. Clone this repository to your local machine: git clone https://github.com/FilipTrifunovic/elastic-search-api-project.git

2. Navigate into the project directory

3. Build and run the Docker containers: docker-compose up --build

4. Test the API using tools like [Postman](https://www.postman.com/) or [curl](https://curl.se/).


## API Endpoints

### POST /api/documents/get

Retrieve documents from Elasticsearch.

### POST /api/documents

Create a new document. Send the document data in the request body.

### PUT /api/documents

Update an existing document by ID. Send the updated document data in the request body.

### DELETE /api/documents/{id}

Delete a document by ID.
