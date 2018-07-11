# chatty
An demo python/flask app that logs a new line every 500ms

## routes
| route   | code  | result                                         |
| --------| :---: | :--------------------------------------------- |
| /       | 200   | prints a message                               |
| /health | 200   | returns no data other than 200 OK code         |

## build
```
Build for distribution with the `Dockerfile`:
```
docker build -t leaky .
```