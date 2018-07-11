# hungry
A demo spring-boot app that artificially consumes a lot of CPU resources for reach request

## routes
| route   | code  | result                                                                               |
| --------| :---: | :----------------------------------------------------------------------------------- |
| /       | 200   | starts four threads with 0.9 load target for 5 seconds before returning request data |
| /health | 200   | returns no data other than 200 OK code                                               |

## build
Build for distribution with the `Dockerfile`:
```
docker build -t hungry .
```