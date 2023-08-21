# BestStories


# Build app
dotnet run --configuration debug

# Run app in release mode

dotnet run --configuration debug
dotnet run --configuration release

Observations 
1. The way we handle the best stories can be improved. This works and is quite efficient but once we start making queries with high counts
then this wouldln't be an efficient way to do it.

2. I would prefer to expose the list of best seller ids via an api endpoint and let the caller dictate how he/she wants
to use the api.

3. Another option or rather in addition to 2) above is to use web sockets via signalr to publish to the end user a stream of best stories..so a pub/sub approach

4. I would equally expose an endpoint for a given best story - this i have done.

5. With more time i would have added unit tests. In order to get things working and i resorted to using postman and manual testing. With more time i would have added some unit tests using Moq library

6. I would equally have been able to add health checks to the api as well - this is rather trivial to do.