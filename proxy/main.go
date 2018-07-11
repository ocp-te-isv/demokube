package main

import (
	"fmt"
	"log"
	"net/http"
	"net/http/httputil"
	"net/url"
)

func main() {
	http.HandleFunc("/", func(w http.ResponseWriter, r *http.Request) {
		fmt.Fprint(w, "I am a reverse proxy. Try /leaky, /crashy, /hungry or /chatty 🙈")
	})

	http.HandleFunc("/health", func(w http.ResponseWriter, r *http.Request) {
		fmt.Fprint(w, "")
	})

	upstreams := map[string]int{
		"leaky":  80,
		"crashy": 80,
		"hungry": 80,
		"chatty": 80,
	}

	for host, port := range upstreams {
		url, _ := url.Parse(fmt.Sprintf("http://%s:%d/", host, port))
		http.Handle(fmt.Sprintf("/%s", host), httputil.NewSingleHostReverseProxy(url))
		log.Printf("Forwarding /%s -> http://%s:%d", host, host, port)
	}

	log.Println("Reverse proxy starting on port 4000")
	http.ListenAndServe(":4000", nil)
}
