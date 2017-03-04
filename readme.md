# OData Web API Service
---
## Introduction
This .NET solution provides a Web Api REST service that exposes a database model through OData V4 standards.  
(.NET 4.52, c#, OWIN, EF6, OData 4)

The solution consists of three projects:
  >* WebHost : This OWIN Web Host is the entry point to the service.
  >* RestApi : This OWIN middleware DLL provides the OData controllers in the service.
  >* EFSDAL : This DLL is the data layer. 100% EF6, DB 1st generated code.

## Model
The service uses an MS SQL Server data file with an existing movie and music dvd sample data that runs within the solution. 
(Data from http://www.hometheaterinfo.com/dvdlist.htm).
Although there are areas for improvement in the schema, this is not the purpose of this exercise.  The goal is only to have a relationalmodel with both 1-many and many-many relationships with referential integrity to be exposed as an OData REST service.  
>* The dvd table contains dvd titles.
>* The partaker table contains actors and directors of the movies in the dvds
>* dvd_partaker provides the relationship between partakers and dvds with capacity indicating actor or director
>* The rest of the tables are simple 1-many lists (aka lookups)

![Model](https://github.com/antonio-cordoba/OdataDvdSampleNet45/blob/master/Model.jpg)

## Execution
Build and Start the **WebHost** project and use a Chrome browser to get the model metadata from http://localhost:52525/odata . (Responses are in JSON format.   IE does not support displaying these out of the box.)
Ideally the service should be tested with a REST Client.   Chrome has excellent plug-ins for this like DHC and Postman.


## Sample Service Queries
>* http://localhost:52525/odata/Dvds => All Dvds (page size = 200)
>* http://localhost:52525/odata/Aspects => (All Aspects) 
>* http://localhost:52525/odata/Partakers?$top=5 => Top 5 Partakers
>* http://localhost:52525/odata/Partakers?$filter=startswith(name,'Brancato') => Partakers name starting w/ Brancato
>* http://localhost:52525/odata/Dvd_partakers?$filter=partaker_id%20eq%20197271 => Dvds for Partaker ID = 197271
>* http://localhost:52525/odata/Dvds(98655)?$select=id,title&$expand=dvd_partakers($expand=partaker,capacity) => Dvd id=98655 w/ all Partakers expanded

## Reference
>* http://www.odata.org/
>* http://www.odata.org/getting-started/basic-tutorial/
>* http://www.odata.org/getting-started/advanced-tutorial/

(Most but not all features in the tutorials are enabled in this solution)
