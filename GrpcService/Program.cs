using Grpc.Reflection;
using Grpc.Reflection.V1Alpha;

var builder = WebApplication.CreateBuilder(args);

// Register gRPC services
builder.Services.AddGrpc();

// Register gRPC reflection service
builder.Services.AddGrpcReflection();

var app = builder.Build();

// Use routing and map gRPC services
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    // Map your gRPC service
    endpoints.MapGrpcService<ProductServiceImplementation>(); // Replace with your actual implementation

    // Map reflection service (important for grpcurl to work)
    endpoints.MapGrpcReflectionService();
});

app.Run();