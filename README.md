# Miami Dolphins Draft API
This is a very simple API used to test the latest Blazor WASM client.

This API will be deployed to Azure.  To test the API from your development environment, you will want to make sure you are running on ports 5000, 5001.


Current CORS policy
```
app.UseCors(policy => 
                policy.WithOrigins("http://localhost:5000", "https://localhost:5001")
                .AllowAnyMethod()
                .WithHeaders(HeaderNames.ContentType));
```
