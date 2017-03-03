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
>* http://localhost:52525/odata/Dvds => All Dvds (page size = 200)
>* http://localhost:52525/odata/Aspects => (All Aspects) 
>* http://localhost:52525/odata/Partakers?$top=5 => Top 5 Partakers
>* http://localhost:52525/odata/Partakers?$filter=startswith(name,'Brancato') => Partakers name starting w/ Brancato
>* http://localhost:52525/odata/Dvd_partakers?$filter=partaker_id%20eq%20197271 => Dvds for Partaker ID = 197271
>* http://localhost:52525/odata/Dvds(98655)?$select=id,title&$expand=dvd_partaker($expand=partaker,capacity) => Dvd id=98655 w/ all Partakers expanded

## Reference
>* http://www.odata.org/
>* http://www.odata.org/getting-started/basic-tutorial/
>* http://www.odata.org/getting-started/advanced-tutorial/

(Keep in mind not all features in the tutorials are enabled in this solution)
