package main

// grpc
// https://github.com/grpc/grpc-go

import (
	"io"
	"log"
	"net"
	"time"

	"google.golang.org/grpc"
	"google.golang.org/grpc/reflection"

	pb "../../Shared"
)

const dateFormat = "2006-01-02 15:04:05"
const port = ":50051"

type server struct{}

func (s *server) SayHello(stream pb.Snippets_SayHelloServer) error {
	for {
		msg, err := stream.Recv()
		if err == io.EOF {
			return nil
		}
		if err != nil {
			log.Fatalf("failed to serve: %v", err)
			return nil
		}
		logRequest(msg)
		time.Sleep(time.Duration(msg.Sleep) * time.Millisecond)
		stream.Send(&pb.SnippetResponse{Message: "Hello " + msg.Name})
	}
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

func logRequest(req *pb.SnippetRequest) {
	log.Println("tcp snippets request", req.Sleep, " "+time.Now().Format(dateFormat)) // TODO: Middleware
}
