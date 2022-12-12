# SampleDotnetBackend
Sample .NET webapi for Silverhorse Tech Team

## Install Requirements
* .NET SDK v 6.0
  * https://dotnet.microsoft.com/en-us/download/dotnet/6.0
 
## Running the project
1. Install the .NET SDK, including adding to PATH
2. Clone the repo
3. Open the repo directory in a terminal (powershell, cmd, bash, etc.)
4. dotnet run

## Testing
Install httprepl
* dotnet tool install -g Microsoft.dotnet-httprepl

## Project Requirements
Build a .NET WebApi application using Visual Studio or Visual Studio Code.

It will act as an API server providing a set of CRUD endpoints as well as an aggregation one. Use https://jsonplaceholder.typicode.com/ as a datasource and more specifically the following 3 resources.

/posts
/users
/albums

All endpoints must be behind an /api/ prefix.

The CRUD routes are only applicable to the posts resource while the aggregated one, which should be called /collection, is a simple GET method.

Every endpoint must be protected by an Auth layer and only reply 200 when the 'Authorization' header is present in every request. The value of the header should be a token of 'Bearer af24353tdsfw' and if it's missing or invalid the server response must be a 501.  The /collection route is aggregating all 3 resources returning a collection of only 30 items each of which should contain random items from each resource, finally looking something like this [{"post": {...},"album": {...}"user": {...}},...] 

We do not care about the extra items remaining from each resource.

You will have 24h to complete this test. If you finish earlier, make sure you test your code and go for the bonus points. Submit your test by sending us your github repo where you uploaded your code to.  
Some tips:·

* Use WebApi frameworkand C# .NET.
* Provide instructions on how to install and test The easier it is to test the more we will like it. ·
* Focus on future proofing your code
* You get bonus points for:·
  * Providing good documentation·
  * Having a solid code structure 
