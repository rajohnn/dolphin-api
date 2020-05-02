# Miami Dolphins Draft API
This is a very simple API used to test the latest Blazor WASM client.

This API will be deployed to Azure.  To test the API from your development environment, you will want to make sure you are running on ports 5000, 5001.


**Current CORS policy**
```
app.UseCors(policy => 
    policy.WithOrigins("http://localhost:5000", "https://localhost:5001")
    .AllowAnyMethod()
    .WithHeaders(HeaderNames.ContentType));
```
The site has been published to:
https://dolphin-api.azurewebsites.net/

Example: (Returns draft picks for the year 20202)
https://dolphin-api.azurewebsites.net/dolphindraft/year/2020


