# EmmaSharp

A .Net wrapper for the [Emma API](http://api.myemma.com/). [![Build status](https://ci.appveyor.com/api/projects/status/v66btpa1dxv7vlwv?svg=true)](https://ci.appveyor.com/project/kylegregory/emmasharp)

### Sample Usage

The examples below show how to have your application pull all account fields on the Emma API. An optional parameter is inlcuded to show all fields, inlcuded those that were deleted:

    using EmmaSharp;
    var emmasharp = new EmmaApi("publicKey", "privateKey", "accountId");
    var getFields = emmasharp.ListFields(true); //Get all account fields, including deleted

### To-Do/Status

A very early alpha of this wrapper library. Building out calls as time allows. Feel free to contribute. Most API endpoints have methods in the library, however not all endpoints have been tested. The following list displays the level of tested and functioning endpoints for each entity. Additional documentation will be added as time allows. If you have any questions, feel free to submit an issue for a particular entity or endpoint.

#### Status by API Category/Entity
`Fields` ![Progress](http://progressed.io/bar/100)

`Groups` ![Progress](http://progressed.io/bar/100)

`Mailings` ![Progress](http://progressed.io/bar/65)

`Members` ![Progress](http://progressed.io/bar/0)

`Response` ![Progress](http://progressed.io/bar/95) \*


`Searches` ![Progress](http://progressed.io/bar/95) \*\*

`Signup Forms` ![Progress](http://progressed.io/bar/100)

`Trggers` ![Progress](http://progressed.io/bar/100)

`Webhooks` ![Progress](http://progressed.io/bar/0)

\**`customer_shares`, `customer_share_clicks`, and `customer_share` return values are unknown*

\*\**Creating and Updating searches uses strings with escaped quotes, which seems to trip up Emma's API.*

### Making contributions
This project is not affiliated with [Emma](http://myemma.com/meet-us).  All contributors to this project are unpaid average folks (just like you!) who choose to volunteer their time.  If you like Emma and want to contribute, we would appreciate your help!  To get started, just [fork the repo](https://help.github.com/articles/fork-a-repo), make your changes and submit a pull request.   
