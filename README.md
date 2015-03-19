# EmmaSharp

A .Net wrapper for the [Emma API](http://api.myemma.com/). [![Build status](https://ci.appveyor.com/api/projects/status/v66btpa1dxv7vlwv?svg=true)](https://ci.appveyor.com/project/kylegregory/emmasharp)

### To-Do/Status

A very early alpha of this wrapper library. Building out calls as time allows. Feel free to contribute.

### Sample Usage

The examples below show how to have your application pull all account fields on the Emma API. An optional parameter is inlcuded to show all fields, inlcuded those that were deleted:

    using EmmaSharp;
    var emmasharp = new EmmaApi("publicKey", "privateKey", "accountId");
    var getFields = emmasharp.ListFields(true); //Get all account fields, including deleted

### Making contributions
This project is not affiliated with [Emma](http://myemma.com/meet-us).  All contributors to this project are unpaid average folks (just like you!) who choose to volunteer their time.  If you like Emma and want to contribute, we would appreciate your help!  To get started, just [fork the repo](https://help.github.com/articles/fork-a-repo), make your changes and submit a pull request.   
