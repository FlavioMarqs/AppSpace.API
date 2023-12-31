# AppSpace.API

## Exercise 1
Define the API that covers the functional requirements described in the scenario. The API does
not have to be implemented, we only need the interfaces, contracts, signatures, data transfer
objects, etc. that you might find necessary to build the skeleton of it.

* Check solution folder APIs

## Exercise 2
Implement one single method of the API: the method corresponding to the use case number 10
together with the criteria B.
You can make any additional assumptions, but you should at least meet the following
requirements:
(Copyright) 2021 Appspace Inc. Appspace is a registered trademark of Appspace Inc. All rights reserved.
* Use the public movie API to search movies available. The following method will be very
useful for this case: https://developers.themoviedb.org/3/discover/movie-discover
* Use the following read-only database for implementing the behavior B.b: (...)
The criteria �movies successful in the city� can be assumed as �movies in the database with the
biggest amount of seats sold�


## Instructions
It is necessary to install `paket` as the Package Dependency manager: `dotnet tool restore` on .sln root (https://fsprojects.github.io/Paket/get-started.html#NET-Core-preferred)

Then, on the .sln folder, run `paket restore`

Make sure the necessary .NetCore3.1 & .Net5 runtimes/SDKs are installed

Run the solution with `AppSpace.RecommendationsService` as the Startup project

Go to `http://localhost:5000/index.html` and paste the request example below


` 
{
  "smallRoomsScreensCount": 2,
  "bigRoomsScreensCount": 2,
  "filters": {
    "includeAdult": true,
    "releaseDateGte": "2000-09-17T15:30:52.383Z",
    "releaseDateLte": "2023-09-17T15:30:52.383Z",
    "keywords": [
      "mystery"
    ]
  },
  "useWithFilters": true,
  "startTime": "2023-09-17T15:30:52.383Z",
  "endTime": "2023-12-17T15:30:52.383Z"
}
`

## Security Concerns

Both the ConnectionString from the .pdf and the ApiKey and Token generated by the developer can be found in the `appSettings.json` file *in older commits*.

Those have been moved to the `secrets.json` file associated with the `AppSpace.RecommendationsService` project; right-click the .csproject file of said project in Visual Studio (2022), select `Manage User Secrets`, and the `secrets.json` requiring the secrets will open in Visual Studio; the expected contents of said file should be something like the following:


` 
"Databases": {
    "BeezyDBConnectionString": "<insert connection string from the pdf>"
  },
  "TMDBApiClientOptions": {
    "ApiKey": "<insert API Key generated in http://developer.themoviedb.org",
    "ApiToken": "<insert API Token generated in http://developer.themoviedb.org"
  }
`

## Known Limitations

A single image will be used for each Movie in its Original Language. This can be customized at a later date, to allow for other languages.

Each room can have the same movie that was presented in a different room in a previous week.

The endpoint calls can take a while to return a response (~10-30 seconds); please be patient, as we're not using caching mechanisms.