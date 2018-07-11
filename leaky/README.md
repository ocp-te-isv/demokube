# leaky
An demo node.js app that leaks 1MB of memory per request

## routes
| route   | code  | result                                         |
| --------| :---: | :--------------------------------------------- |
| /       | 200   | adds 1MB to a top-level array on every request |
| /health | 200   | returns no data other than 200 OK code         |

## build
Run locally with
```
npm install
npm start
```
Build for distribution with the `Dockerfile`:
```
docker build -t leaky .
```