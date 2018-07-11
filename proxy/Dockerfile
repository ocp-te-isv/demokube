FROM golang:1.10.3-alpine3.7 AS build-env
COPY . /src
RUN cd /src && CGO_ENABLED=0 GOOS=linux go build -a -installsuffix cgo -o proxy .

FROM scratch
COPY --from=build-env /src/proxy /proxy
CMD ["/proxy"]