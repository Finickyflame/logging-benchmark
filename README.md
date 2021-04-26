# Logging Benchmark

## Summary
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i9-9900K CPU 3.60GHz (Coffee Lake), 1 CPU, 16 logical and 8 physical cores
.NET Core SDK=5.0.202
  [Host]     : .NET Core 5.0.5 (CoreCLR 5.0.521.16609, CoreFX 5.0.521.16609), X64 RyuJIT
  DefaultJob : .NET Core 5.0.5 (CoreCLR 5.0.521.16609, CoreFX 5.0.521.16609), X64 RyuJIT

```
|          Method |       Mean |     Error |    StdDev |
|---------------- |-----------:|----------:|----------:|
|         Default |   899.2 us |  17.92 us |  26.26 us |
|         Serilog | 4,109.1 us |  81.78 us | 192.78 us |
| SerilogEnriched | 6,749.5 us | 134.65 us | 335.33 us |

#### Legends
- Mean   : Arithmetic mean of all measurements
- Error  : Half of 99.9% confidence interval
- StdDev : Standard deviation of all measurements
- 1 us   : 1 Microsecond (0.000001 sec)


## Detailed results

### Default
```
Runtime = .NET Core 5.0.5 (CoreCLR 5.0.521.16609, CoreFX 5.0.521.16609), X64 RyuJIT; GC = Concurrent Workstation
Mean = 899.155 us, StdErr = 4.877 us (0.54%), N = 29, StdDev = 26.264 us
Min = 871.248 us, Q1 = 878.213 us, Median = 889.676 us, Q3 = 911.658 us, Max = 959.945 us
IQR = 33.445 us, LowerFence = 828.045 us, UpperFence = 961.825 us
ConfidenceInterval = [881.236 us; 917.073 us] (CI 99.9%), Margin = 17.918 us (1.99% of Mean)
Skewness = 0.91, Kurtosis = 2.47, MValue = 2.11
-------------------- Histogram --------------------
[870.798 us ; 900.719 us) | @@@@@@@@@@@@@@@@@@@
[900.719 us ; 923.159 us) | @@@@
[923.159 us ; 951.193 us) | @@@@@
[951.193 us ; 971.165 us) | @
---------------------------------------------------
```

#### Hot spots
| Percentage | Method | Source                                |
|-----------:|--------|---------------------------------------|
|     10.06% | Main   | DefaultLogging.Program.Main(String[]) |


### Serilog
```
Runtime = .NET Core 5.0.5 (CoreCLR 5.0.521.16609, CoreFX 5.0.521.16609), X64 RyuJIT; GC = Concurrent Workstation
Mean = 4.109 ms, StdErr = 0.024 ms (0.58%), N = 66, StdDev = 0.193 ms
Min = 3.509 ms, Q1 = 4.013 ms, Median = 4.087 ms, Q3 = 4.245 ms, Max = 4.557 ms
IQR = 0.232 ms, LowerFence = 3.664 ms, UpperFence = 4.594 ms
ConfidenceInterval = [4.027 ms; 4.191 ms] (CI 99.9%), Margin = 0.082 ms (1.99% of Mean)
Skewness = -0.06, Kurtosis = 3.54, MValue = 2
-------------------- Histogram --------------------
[3.446 ms ; 3.571 ms) | @
[3.571 ms ; 3.724 ms) | 
[3.724 ms ; 3.856 ms) | @@@@
[3.856 ms ; 3.981 ms) | @@@@@@@@@@@
[3.981 ms ; 4.135 ms) | @@@@@@@@@@@@@@@@@@@@@@@@@
[4.135 ms ; 4.289 ms) | @@@@@@@@@@@@@@@
[4.289 ms ; 4.429 ms) | @@@@@@@
[4.429 ms ; 4.588 ms) | @@@
---------------------------------------------------
```

#### Hot spots
| Percentage | Method | Source                                                                                   |
|-----------:|--------|------------------------------------------------------------------------------------------|
|      8.36% | Main   | SerilogLogging.Program.Main(String[])                                                    |
|      0.85% | Set    | Serilog.Sinks.SystemConsole.Themes.SystemConsoleTheme.Set(TextWriter, ConsoleThemeStyle) |

### SerilogEnriched
```
Runtime = .NET Core 5.0.5 (CoreCLR 5.0.521.16609, CoreFX 5.0.521.16609), X64 RyuJIT; GC = Concurrent Workstation
Mean = 6.749 ms, StdErr = 0.039 ms (0.58%), N = 73, StdDev = 0.335 ms
Min = 6.222 ms, Q1 = 6.536 ms, Median = 6.736 ms, Q3 = 6.981 ms, Max = 7.573 ms
IQR = 0.445 ms, LowerFence = 5.870 ms, UpperFence = 7.648 ms
ConfidenceInterval = [6.615 ms; 6.884 ms] (CI 99.9%), Margin = 0.135 ms (1.99% of Mean)
Skewness = 0.24, Kurtosis = 2.27, MValue = 2.76
-------------------- Histogram --------------------
[6.199 ms ; 6.410 ms) | @@@@@@@@@@@@@@@
[6.410 ms ; 6.581 ms) | @@@@@@@
[6.581 ms ; 6.792 ms) | @@@@@@@@@@@@@@@@@@@@@
[6.792 ms ; 7.104 ms) | @@@@@@@@@@@@@@@@@@
[7.104 ms ; 7.321 ms) | @@@@@@@@@@
[7.321 ms ; 7.636 ms) | @@
---------------------------------------------------
```

#### Hot spots
| Percentage | Method      | Source                                                                                                                                                         |
|-----------:|-------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------|
|      8.47% | Main        | SerilogEnrichedLogging.Program.Main(String[])                                                                                                                  |
|      1.66% | Set         | Serilog.Sinks.SystemConsole.Themes.SystemConsoleTheme.Set(TextWriter, ConsoleThemeStyle)                                                                       |
|      1.32% | Render      | Serilog.Sinks.SystemConsole.Output.TextTokenRenderer.Render(LogEvent, TextWriter)                                                                              |
|      0.99% | RenderValue | Serilog.Sinks.SystemConsole.Rendering.ThemedMessageTemplateRenderer.RenderValue(ConsoleTheme, ThemedValueFormatter, LogEventPropertyValue, TextWriter, String) |
