# EmmaSharp

A .Net wrapper for the [Emma API](http://api.myemma.com/). [![Build status](https://ci.appveyor.com/api/projects/status/v66btpa1dxv7vlwv?svg=true)](https://ci.appveyor.com/project/kylegregory/emmasharp) [![NuGet version](https://badge.fury.io/nu/EmmaSharp.svg)](https://www.nuget.org/packages/EmmaSharp)

### Sample Usage

The examples below show how to have your application pull all account fields on the Emma API. An optional parameter is included to show all fields, included those that were deleted:

    using EmmaSharp;
    var emmasharp = new EmmaApi("publicKey", "privateKey", "accountId");
    var getFields = emmasharp.ListFields(true); //Get all account fields, including deleted
    
## Getting Started

EmmaSharp is available on NuGet.

```
Install-Package EmmaSharp
```

### Triggers marked obsolete

Triggers are now depreciated in favor of the new [Event API](http://api.myemma.com/api/external/event_api.html). Those still using Triggers should be aware that the endpoints continue to function but will be phased out over time. These endpoints have been marked obsolete and will continue to work in EmmaSharp, though they will produce a warning in your project. Future releases may see these endpoints removed completely, which will be noted in the [Release Notes](https://github.com/kylegregory/EmmaSharp/blob/master/ReleaseNotes.md).

### Status of the Project

Feel free to contribute. Most API endpoints have methods in the library. Additional documentation will be added as time allows, however you may be interested in the [Release Notes](https://github.com/kylegregory/EmmaSharp/blob/master/ReleaseNotes.md). If you have any questions, feel free to submit an issue for a particular entity or endpoint. You may also want to look at issues found [pertaining to Emma's API](https://github.com/kylegregory/EmmaSharp/issues?q=is%3Aopen+is%3Aissue+label%3A%22api+bug%22), which we're waiting on a response from @Emma.

### Making contributions

This project is not affiliated with [Emma](http://myemma.com/meet-us). All contributors to this project are unpaid average folks (just like you!) who choose to volunteer their time. If you like Emma and want to contribute, we would appreciate your help! To get started, just [fork the repo](https://help.github.com/articles/fork-a-repo), make your changes and submit a pull request.