## nunit-logging-from-SetUpFixture-repro

This repo is a MCVE reproducing a problem I have been seeing with
logging from an NUnit `[SetUpFixture]`-annotated class.

### How to reproduce the problem

```
$ dotnet test
```

### Where does it work?

Run the same test in JetBrains Rider, and the output from this fixture
class is visible (although for one of the higher-level nodes in the test
explorer).
