# Imperial/Metric Converter

A modular Imperial/Metric unit converter built in C#, developed using Test-Driven Development (TDD) with a Red-Green-Refactor workflow.

## Overview

This project converts measurements between Imperial and Metric units across four categories: length, mass, volume, and temperature. Rather than hardcoding a direct formula for every possible unit pair, each converter routes through a common base unit, keeping the conversion logic centralized and free of duplication.

**Architecture flow:**
```
Program → Concrete Converters → IUnitConverter → ConverterService → IConverterService → ConsoleInterface
```

## Tech Stack

| Purpose | Tool |
|---|---|
| Language | C# / .NET |
| Unit testing | xUnit |
| Mocking | Moq |
| Code coverage | Coverlet |

## Project Structure

Tests are 1:1 with `src/` — every class under `src/` has a corresponding test class under `tests/`.

```
src/
├── Converters/   # Conversion math for each unit category
├── Models/       # Data structures
├── Services/     # Validates user input, coordinates between converters
└── UI/           # Console UI/UX formatting

tests/
├── Converters/   # LengthConverter, MassConverter, VolumeConverter, TemperatureConverter
├── Services/     # ConverterService
└── UI/           # ConsoleInterface
```

## Running the Project

**Build and run tests:**
```bash
dotnet build
dotnet test
```

**Run tests with code coverage:**
```bash
dotnet test /p:CollectCoverage=true
```

**Run tests with coverage in OpenCover format** (for use with report generators like ReportGenerator):
```bash
dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=opencover
```

## Conversion Reference

### Length
| Unit | Equivalent |
|---|---|
| 1 inch | 2.54 cm / 0.0254 m |
| 1 foot | 0.3048 m (12 inches) |
| 1 yard | 0.9144 m (3 feet) |
| 1 mile | 1609.34 m / 1.609344 km (5280 feet) |
| 1 centimeter | 0.01 m |
| 1 meter | 1 m |
| 1 kilometer | 1000 m |

### Mass
| Unit | Equivalent |
|---|---|
| 1 pound | 0.453592 kg |
| 1 ounce | 28.3495 g (1/16 pound) |

### Volume
| Unit | Equivalent |
|---|---|
| 1 teaspoon | 4.92892 ml |
| 1 tablespoon | 14.7868 ml (3 teaspoons) |
| 1 cup | 236.588 ml (16 tablespoons) |
| 1 gallon | 3.78541 liters (16 cups) |

### Temperature
- 0°C = 32°F
- 32°F = 0°C
- Formula: `C = (F - 32) / 1.8` and `F = (C × 1.8) + 32`