# IPG RestSharp BearerAuthenticator
Simple class that inherits RestSharp's IAuthenticator and implements Bearer Authentication in a RestRequest / RestClient.

## Description
RestSharp doesn't support bearer authentication out-of-the-box as it does for other common authentication mechanisms (such as basic auth).

IPG.RestSharp.BearerAuthenticator is a simple class that inherits IAuthenticator, allows you to specify an access token and then implements Bearer authentication via the 'Authorization' header.

## Usage
```csharp
using IPG.RestSharp.BearerAuthenticator;
...

// Create a rest client
var client = new RestClient("http://example.com");

// Set the client's authenticator property to an instance of the BearerAuthenticator
// class which has had the access token passed into it's constructor
client.Authenticator = new BearerAuthenticator("<my-secret-token>");

// Continue using the rest client as normal
...
```

You can also pass in an instantiated version of the class wherever there are higher level absractions that accept an IAuthenticator parameter (such as in 3rd party libraries).

### Dynamic evaluation of token
In some situations it might be helpful to 'evaluate' the token value only at the point it's needed by the rest client (i.e. the Authenticate method). This could occur in a scenario where you're using dependency injection and the whole service provider graph is configured on program instantiation but when the access token is not know until further processing has occured. This is supported by the use of overloaded constructor accepting a `Func <string>` parameter.

## Installation
Use the Nuget Package Manager to install the library. Nuget package name is "IPG.RestSharp.BearerAuthenticator". You can also instal via running the following in the Package Manager Console:
```powershell
Install-Package IPG.RestSharp.BearerAuthenticator
```
