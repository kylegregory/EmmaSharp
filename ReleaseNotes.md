EmmaSharp Release Notes
=========
## HEAD (Unreleased)
 * Fix for GroupName property naming inconsistancy in GetMailing to return Mailing Recipient Groups. [#25](https://github.com/kylegregory/EmmaSharp/issues/25) via @sabmah

## New in 1.0.5 (Released 2017/06/19)
 * Undoing a regression in 1.0.4 for setting DataFormat.Json.

## New in 1.0.4 (Released 2017/05/17)
* Added new field AutomateFieldChanged to AddMembers Model. [#22](https://github.com/kylegregory/EmmaSharp/pull/22) via @ginowit
* Removing redundant request format and json serializer calls.
* Triggers marked as obsolete, via [Emma API docs](http://api.myemma.com/api/external/triggers.html).

## New in 1.0.3 (Released 2016/10/26)
* Added change_status enum values as received from Emma support. [#20](https://github.com/kylegregory/EmmaSharp/pull/20) via @MikeSmithDev
* GetMemberGroups was failing due to DateTime conversion on the Group model, added EmmaDateConverter to necessary properties. [#21](https://github.com/kylegregory/EmmaSharp/pull/21) via @MikeSmithDev

## New in 1.0.2 (Released 2016/10/10)
* Update RestSharp Dependency to v 105.2.3 because of namespace change to `HttpBasicAuthenticator` [#8](https://github.com/kylegregory/EmmaSharp/issues/8#issuecomment-252004909) via @technomaz

## New in 1.0.1 (Released 2016/06/27)
* Webhook fix and updates to handle member signup event - [#18](https://github.com/kylegregory/EmmaSharp/pull/18) via @technomaz
* Fixed MemberIds longer than Int32
* Fixed: `NumMembersAdded` property on `Import` - [#16](https://github.com/kylegregory/EmmaSharp/pull/16) via @MikeSmithDev

## New in 1.0.0 (Released 2016/02/25)
* Initial release
