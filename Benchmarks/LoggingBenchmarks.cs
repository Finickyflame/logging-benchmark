using System;
using System.Net.Http;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;

namespace Benchmarks
{
    public class LoggingBenchmarks : IDisposable
    {
        private readonly HttpClient _client;

        public LoggingBenchmarks()
        {
            this._client = new HttpClient();
        }

        [Benchmark]
        public async ValueTask Default() => await this.GetAsync(5000);

        [Benchmark]
        public async ValueTask NLog() =>  await this.GetAsync(5001);
        
        [Benchmark]
        public async ValueTask NLogAsync() => await this.GetAsync(5002);
        
        [Benchmark]
        public async ValueTask Serilog() => await this.GetAsync(5003);
        
        [Benchmark]
        public async ValueTask SerilogAsync() => await this.GetAsync(5004);
        
        [Benchmark]
        public async ValueTask SerilogEnriched() => await this.GetAsync(5005);

        
        private async Task GetAsync(int port) => await this._client.GetAsync($"https://localhost:{port}/WeatherForecast");
        
        public void Dispose() => _client?.Dispose();
    }
}