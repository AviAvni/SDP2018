package main

// grpc
// https://github.com/grpc/grpc-go

import (
	"context"
	"fmt"
	"log"

	"google.golang.org/grpc"

	pb "../../Shared"
)

const address = "localhost:50051"

func main() {
	// Set up a connection to the server.
	conn, err := grpc.Dial(address, grpc.WithInsecure())
	if err != nil {
		log.Fatalf("did not connect: %v", err)
	}
	defer conn.Close()
	c := pb.NewSnippetsClient(conn)

	// Contact the server and print out its response.
	r, err := c.SayHello(context.Background(), &pb.SnippetRequest{Name: "Avi", Sleep: 1000})
	if err != nil {
		log.Printf("could not greet: %v", err)
	} else {
		fmt.Printf("Greeting: %s\n", r.Message)
	}
	fmt.Print("Finished")
}
