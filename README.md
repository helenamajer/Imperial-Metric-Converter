# Test Driven Development - Imperial/Metric Converter.
Automated unit testing using Test Driven Development for a unit converter!

## Project Description - Unit System
- This system is a unit converter for Imperial and Metric measurements.
- Measurements are broken down into sub-categories such as tempurature, mass, volume, and length.

## Development Tools:
- Language of implementation: C#
- Framework for unit-testing: XUnit
- Framework for Mocking: Moq
- Code coverage tool: Coverlet

## Running the Program
Test normally: 
- dotnet build
- dotnet test

Run tests with coverage:
- dotnet test \p:CollectCoverage=true

More explicit with coverage:
- dotnet test \
  /p:CollectCoverage=true \
  /p:CoverletOutputFormat=opencover

## Project Architecture
tests are 1:1 with src.

src/
- Converters/ - handels the math for each conversion
- Models/ - holds data structures
- Services/ - validate user input and coordinate between the 3 converters
- UI/ - formats console UI/UX
<br><br>

tests/ (5 SUT classes)
- Converters/ - LengthConverter, MassConverter, VolumeConverter
- Services/ - ConverterService
- UI/ - ConsoleInterface

## Conversion Reference
### Length:
- 1 inch = 2.54 cm
- 1 foot = 0.3048 m (12 inches)
- 1 yard = 0.9144 m (3 feet)
- 1 mile = 1.609344 km (5280 feet)

### Mass:
- 1 pound = 0.453592 kg
- 1 ounce = 28.3495 g (1/16 pound)

### Volume:
- 1 teaspoon = 4.92892 ml
- 1 tablespoon = 14.7868 ml (3 teaspoons)
- 1 cup = 236.588 ml (16 tablespoons)
= 1 gallon = 3.78541 liters (16 cups)

### Tempurature:
- 0 Celsius = 32 Fahrenheit
- 32 Fahrenheit = 0 Celsius
- Formula: C = (F - 32) / 1.8 and F = (C * 1.8) + 32
