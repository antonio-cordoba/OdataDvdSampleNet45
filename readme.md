# OData Web API Service
---
## Introduction
This solution provides a Web Api REST service that exposes a database model through OData V4 standards.

The service uses a MS SQL Server data file with an existing sample model and data that runs within the solution.

The solution consists of three projects:
  >* WebHost : This OWIN Web Host is the entry point to the service.
  >* RestApi : This OWIN middleware DLL provides the OData controllers in the service.
  >* EFSDAL : This DLL is the data layer. 100% EF6, DB 1st generated code.

## Execution
Build and Start the **WebHost** project and use a Chrome browser to get the model metadata from http://localhost:52525/odata . (Responses are in JSON format and IE does not support displaying these out of the box.)
Ideally the service should be tested with a REST Client.   Chrome has excellent plug-ins for this like DHC and Postman.
Use HTTP Requests to query the model

## Sample Service Queries

## Reference