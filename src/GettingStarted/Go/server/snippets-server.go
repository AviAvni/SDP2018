package main

// grpc
// https://github.com/grpc/grpc-go

import (
	"context"
	"log"
	"net"
	"time"

	"google.golang.org/grpc"
	"google.golang.org/grpc/reflection"

	pb "../../Shared"
)

const dateFormat = "2006-01-02 15:04:05"
const port = ":888"

type server struct{}

func (s *server) SayHello(ctx context.Context, request *pb.SnippetRequest) (*pb.SnippetResponse, error) {
	log.Println("SayHello")
	time.Sleep(time.Duration(request.Sleep) * time.Millisecond)
	return &pb.SnippetResponse{Message: "Hello " + request.Name}, nil
}

func main() {
	lis, err := net.Listen("tcp", port)
	if err != nil {
		log.Fatalf("failed to listen: %v", err)
	}
	s := grpc.NewServer()
	pb.RegisterSnippetsServer(s, &server{})
	// Register reflection service on gRPC server.
	reflection.Register(s)
	if err := s.Serve(lis); err != nil {
		log.Fatalf("failed to serve: %v", err)
	}
}
