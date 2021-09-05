using System;
using System.Threading.Tasks;
using Grpc.Net.Client;

namespace Fatn.Api
{
    public class FatnClient : IDisposable
    {
        private readonly GrpcChannel _channel;
        private readonly Greeter.GreeterClient _client;

        public FatnClient()
        {
            _channel = GrpcChannel.ForAddress("https://localhost:5001");
            _client = new Greeter.GreeterClient(_channel);
        }

        public async Task<string> Greet(string user)
        {
            var reply = await _client.SayHelloAsync(new HelloRequest { Name = user });
            return reply.Message;
        }

        public void Dispose()
        {
            _channel.Dispose();
        }
    }
}