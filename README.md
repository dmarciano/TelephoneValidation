# Telephone Validation - North American Numbering Plan (NANP)
Light-weight telephone validation method for phone numbers provided under the North American Numbering Plan (NANP)

## Usage
The library contains a single static class ```Telephone``` with a single static method ```Validate```.  The phone number to validate is passed to this method.  The phone
number can contain parentheses, hypens, or any other separate character; the validation logic will ignore any non-numerical character.  The phone number must be either
10-digits long (*without* the leading 1) or 11-digits long (*with* the leading 1).

The ```Validate``` method will return a ```bool``` value indicating whether the phone number passed validation.  When the validation fails, the ```out exception``` parameter
can be checked for the specific exception that was found, a message describing the error in detail, and (when available) the specific reference document and section which
covers the exception.  A copy of these documents can be found in the *Reference Documents* folder.

## Contributing
Contributing to this project is welcome.  However, we ask that you please follow our [contributing guidelines](./CONTRIBUTING.md) to help ensure consistency.

## Versions
**1.0.0** - Initial Release

This project uses [SemVer](http://semver.org) for versioning.

## Authors
- Dominick Marciano Jr.

## References
The documents in the *Reference Documents* folder, along with additional information, can be obtained from the [North American Numbering Plan Administrator: NANPA](https://nationalnanpa.com/) website.

## License
Copyright (c) 2019 Dominick Marciano Jr., Sci-Med Coding.  All rights reserved

See [LICENSE](./LICENSE) for full licesning terms.