package main

// grpc
// https://github.com/grpc/grpc-go

import (
	"context"
	"fmt"
	"io"
	"log"
	"time"

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
	stream, err := c.SayHello(context.Background())
	if err != nil {
		log.Printf("could not greet: %v", err)
	} else {
		for i := 0; i < 10; i++ {
			stream.Send(&pb.SnippetRequest{Name: fmt.Sprintf("%d", i), Sleep: 1000})
		}
		stream.CloseSend()
		time.Sleep(time.Duration(5000) * time.Millisecond)
		for {
			r, err := stream.Recv()
			if err == io.EOF {
				return
			}

			fmt.Printf("Greeting: %s\n", r.Message)
		}
	}
	fmt.Print("Finished")
}
