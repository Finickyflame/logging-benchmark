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
        public async ValueTask Default()
        {
            var response = await _client.GetAsync("https://localhost:5001/WeatherForecast");
        }

        [Benchmark]
        public async ValueTask Serilog()
        {
            var response = await _client.GetAsync("https://localhost:5003/WeatherForecast");
        }
        
        [Benchmark]
        public async ValueTask SerilogEnriched()
        {
            var response = await _client.GetAsync("https://localhost:5005/WeatherForecast");
        }

        public void Dispose() => _client?.Dispose();
    }
}