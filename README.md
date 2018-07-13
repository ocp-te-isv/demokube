# demokube
A suite of example apps - all with a slight quirk - to show a fully integrated AKS project.

# notable features
- 5 containerized microservices, written in Go, Node, Python, Java and dotnet core
- a simple frontend, written in Node and React
- optimized, multistage Docker images
- continuous integration and delivery via VSTS
- helm charts for easy deployment to Kubernetes

# the applications
Each application has one intentional flaw (and maybe more unintentional flaws)

## chatty
Chatty is a python application written with flask that sends very large responses for each request (2MB). Since flask is not the most performant web framework and it is not setup to use a production WSGI server, responses are also relatively slow, in the order of several seconds.

This behaviour should be observable in the metrics of the ingress controller (latency, response body size)

## crashy
Crashy is a dotnet core application that has a tendency to divide by zero and hard crash. (It will specifically request to exit with a nonzero exit code to avoid automatic recovery.)

The random request failures should be observable in the metrics of the ingress controller, and the pod restarts should be observable in the kube metrics.

## hungry
Hungry is a Java Spring Boot application that artificially consumes a lot of CPU resources on each request. This also leads to high latency, as a response is only sent after the CPU stress has completed.

The high CPU load should be observable in the kube/heapster metrics, and the high latency in the ingress controller metrics.

## leaky
Leaky is a node.js application that leaks 1MB of memory on every request until it crashes.

The memory consumption pattern should be observable in the kube/heapster metrics, and the pod restart in the kube metrics.

## proxy
Proxy is a simple reverse proxy written in Go that has no flaws, because Go is perfect*.

\* it might actually have flaws

## demo
Demo is a simple React frontend, which will eventually contain walkthough information and background details.