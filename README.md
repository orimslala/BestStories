# BestStories


## Build app
dotnet build

## Run app

cd /Santander.CodingTest.WebApi

#### debug build
dotnet run --configuration debug
#### release build
dotnet run --configuration release


![image](https://github.com/orimslala/BestStories/assets/41841151/abb4db8e-93ae-4b4b-b4c8-6063ff510e36)


### Observations 
1. The way we handle the best stories can be improved. This works and is quite efficient but once we start making queries with high counts
then this wouldn't be an efficient way to do it.

2. I would prefer to expose the list of best seller ids via an api endpoint and let the caller of the api dictate how he/she wants
to use the api. This way you give the client side some flexibility to choose what best works for it.

3. Another option or rather in addition to 2) above is to use web sockets via signalr to publish to the end user a stream of best stories..so a pub/sub approach

4. I would equally expose an endpoint for a given best story - this i have done.

5. With more time i would have added unit tests. In order to get things working and i resorted to using postman and manual testing. With more time i would have added some unit tests using Moq library

6. I would equally have been able to add health checks to the api as well - this is rather trivial to do.
7. We should equally validate the request parameter 'count' so we can fail early. such logic can be done using fluent validation package
8. Perharps if we added pagination with a page and pageSize query params we could reduce the amount of payload we send in the api web reponses.

