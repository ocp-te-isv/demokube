# proxy
a very simple reverse proxy that serves data from hardcoded upstreams
## upstreams
| route   | result                                  |
| --------| :-------------------------------------- |
| /       | information on available routes         |
| /health | returns no data other than 200 OK code  |
| /leaky  | forwards to http://leaky:80             |
| /hungry | forwards to http://hungry:80            |
| /crashy | forwards to http://crashy:80            |
| /chatty | forwards to http://chatty:80            |