#Logging Benchmark

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
|            NLog |   481.3 us |   9.57 us |   8.96 us |
|       NLogAsync |   156.0 us |   3.07 us |   7.53 us |
|         Serilog | 4,109.1 us |  81.78 us | 192.78 us |
|    SerilogAsync |   180.3 us |   3.58 us |   9.93 us |
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


### NLog
```
Runtime = .NET Core 5.0.5 (CoreCLR 5.0.521.16609, CoreFX 5.0.521.16609), X64 RyuJIT; GC = Concurrent Workstation
Mean = 481.306 us, StdErr = 2.312 us (0.48%), N = 15, StdDev = 8.956 us
Min = 462.001 us, Q1 = 475.909 us, Median = 480.963 us, Q3 = 486.284 us, Max = 496.828 us
IQR = 10.376 us, LowerFence = 460.345 us, UpperFence = 501.848 us
ConfidenceInterval = [471.732 us; 490.881 us] (CI 99.9%), Margin = 9.575 us (1.99% of Mean)
Skewness = -0.09, Kurtosis = 2.59, MValue = 2
-------------------- Histogram --------------------
[457.235 us ; 473.156 us) | @
[473.156 us ; 491.598 us) | @@@@@@@@@@@@
[491.598 us ; 501.595 us) | @@
---------------------------------------------------
```

### NLog Async
```
Runtime = .NET Core 5.0.5 (CoreCLR 5.0.521.16609, CoreFX 5.0.521.16609), X64 RyuJIT; GC = Concurrent Workstation
Mean = 156.025 us, StdErr = 0.893 us (0.57%), N = 71, StdDev = 7.525 us
Min = 140.422 us, Q1 = 150.403 us, Median = 155.704 us, Q3 = 161.857 us, Max = 171.094 us
IQR = 11.453 us, LowerFence = 133.223 us, UpperFence = 179.037 us
ConfidenceInterval = [152.957 us; 159.093 us] (CI 99.9%), Margin = 3.068 us (1.97% of Mean)
Skewness = -0.06, Kurtosis = 2.15, MValue = 3.3
-------------------- Histogram --------------------
[138.037 us ; 141.219 us) | @
[141.219 us ; 146.124 us) | @@@@@@@
[146.124 us ; 151.620 us) | @@@@@@@@@@@@
[151.620 us ; 156.391 us) | @@@@@@@@@@@@@@@@@@
[156.391 us ; 159.596 us) | @@@@@
[159.596 us ; 164.367 us) | @@@@@@@@@@@@@@@@@@@@
[164.367 us ; 169.512 us) | @@@@@@
[169.512 us ; 173.480 us) | @@
---------------------------------------------------
```

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

### Serilog Async
```
Runtime = .NET Core 5.0.5 (CoreCLR 5.0.521.16609, CoreFX 5.0.521.16609), X64 RyuJIT; GC = Concurrent Workstation
Mean = 180.299 us, StdErr = 1.053 us (0.58%), N = 89, StdDev = 9.934 us
Min = 156.031 us, Q1 = 175.338 us, Median = 178.373 us, Q3 = 184.346 us, Max = 204.798 us
IQR = 9.008 us, LowerFence = 161.827 us, UpperFence = 197.857 us
ConfidenceInterval = [176.714 us; 183.884 us] (CI 99.9%), Margin = 3.585 us (1.99% of Mean)
Skewness = 0.3, Kurtosis = 3.26, MValue = 2.32
-------------------- Histogram --------------------
[155.030 us ; 160.871 us) | @@@@
[160.871 us ; 169.240 us) | @@@
[169.240 us ; 174.661 us) | @@@@@@@@@@@@@
[174.661 us ; 180.501 us) | @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
[180.501 us ; 186.655 us) | @@@@@@@@@@@@@@@
[186.655 us ; 192.495 us) | @@@@@@@@@@@
[192.495 us ; 199.869 us) | @@@@@@
[199.869 us ; 206.238 us) | @@@@
---------------------------------------------------
```


### Serilog Enriched
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