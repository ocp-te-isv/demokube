# crashy
An demo dotnet core app that has a random change to throw an error on each request

## routes
| route   | code  | result                                         |
| --------| :---: | :--------------------------------------------- |
| /       | 200   | has a one-in-three chance to divide by zero    |
| /health | 200   | returns no data other than 200 OK code         |

## build
Build for distribution with the `Dockerfile`:
```
docker build -t crashy .
```