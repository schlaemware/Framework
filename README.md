# Framework
Library with useful functions.

# Usage
## Release mechanics
### Steps
1. Create pull request from develop -> master and merge it.
2. Create new release (go to releases and create new one. Tag can be set directly in the new release).
3. Thanks to MinVer, the tag of the release is used directly as the version.
4. The new package can be downloaded.

### Possible problems
1. If the token is expired you have to renew it and set the new token in the secrets.
