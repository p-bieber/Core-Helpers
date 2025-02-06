# Bieber.Core.Helpers

`Bieber.Core.Helpers` provides a set of utility methods for object manipulation, validation, and date/time operations.

## Features

### ObjectHelper
- **EnsureNotAbstract**: Ensures that a specified type is not abstract.
- **EnsureNotNull**: Ensures that an object is not null.
- **DeepClone**: Creates a deep clone of an object using JSON serialization.
- **IsOfType**: Checks if an object is of a specified type.
- **TryParse**: Attempts to convert the specified string representation of a logical value to its equivalent strongly-typed value.
- **IsNullOrDefault**: Checks if an object is null or the default value for its type.
- **GetPropertyValue**: Retrieves the value of a specified property from an object.
- **SetPropertyValue**: Sets the value of a specified property on an object.

### DateTimeHelper
- **GetStartOfDay**: Gets the start of the day for a given `DateTime` or `DateOnly`.
- **GetEndOfDay**: Gets the end of the day for a given `DateTime` or `DateOnly`.
- **AddBusinessDays**: Adds the specified number of business days to a `DateTime` or `DateOnly`.
- **Combine**: Combines a `DateOnly` and a `TimeOnly` into a `DateTime`.
- **GetTime**: Gets the `TimeOnly` portion of a `DateTime`.
- **IsWeekend**: Checks if a given date falls on a weekend.
- **GetNextWeekday**: Gets the next occurrence of a specific day of the week.
- **GetBusinessDaysBetween**: Gets the number of business days between two dates.
- **GetWeekendsBetween**: Gets the number of weekends between two dates.
- **CalculateAge**: Calculates the age based on a given date of birth.

## Installation

Add the `Bieber.Core.Helpers` library to your project using the .NET CLI:

```sh
dotnet add package Bieber.Core.Helpers

```
Or add the package reference directly in your .csproj file:
```xml
<PackageReference Include="Bieber.Core.Helpers" Version="1.0.0" />

```

## Usage

### ObjectHelper

#### EnsureNotAbstract

Ensures that a specified type is not abstract:

```c#
using Bieber.Core.Helpers;

ObjectHelper.EnsureNotAbstract<MyClass>();

```

#### EnsureNotNull

Ensures that an object is not null:

```c#
using Bieber.Core.Helpers;

ObjectHelper.EnsureNotNull(myObject, nameof(myObject));

```

#### DeepClone

Creates a deep clone of an object:

```c#
using Bieber.Core.Helpers;

var clone = ObjectHelper.DeepClone(originalObject);

```

#### IsOfType

Checks if an object is of a specified type:

```c#
using Bieber.Core.Helpers;

bool result = ObjectHelper.IsOfType<string>(myObject);

```

#### TryParse

Attempts to convert the specified string representation of a logical value to its equivalent strongly-typed value:

```c#
using Bieber.Core.Helpers;

bool success = ObjectHelper.TryParse("123", out int result);

```

#### IsNullOrDefault

Checks if an object is null or the default value for its type:

```c#
using Bieber.Core.Helpers;

bool isNullOrDefault = ObjectHelper.IsNullOrDefault(0); // true

```

#### GetPropertyValue

Retrieves the value of a specified property from an object:

```c#
using Bieber.Core.Helpers;

object? value = ObjectHelper.GetPropertyValue(myObject, "PropertyName");

```

#### SetPropertyValue

Sets the value of a specified property on an object:

```c#
using Bieber.Core.Helpers;

ObjectHelper.SetPropertyValue(myObject, "PropertyName", newValue);

```

### DateTimeHelper

#### GetStartOfDay

Gets the start of the day for a given `DateTime` or `DateOnly`:

```c#
using Bieber.Core.Helpers;

DateTime startOfDay = DateTimeHelper.GetStartOfDay(myDateTime);
DateTime startOfDay = DateTimeHelper.GetStartOfDay(myDateOnly);

```

#### GetEndOfDay

Gets the end of the day for a given `DateTime` or `DateOnly`:

```c#
using Bieber.Core.Helpers;

DateTime endOfDay = DateTimeHelper.GetEndOfDay(myDateTime);
DateTime endOfDay = DateTimeHelper.GetEndOfDay(myDateOnly);

```

#### AddBusinessDays

Adds the specified number of business days to a `DateTime` or `DateOnly`:

```c#
using Bieber.Core.Helpers;

DateTime newDateTime = DateTimeHelper.AddBusinessDays(myDateTime, 3);
DateOnly newDateOnly = DateTimeHelper.AddBusinessDays(myDateOnly, 3);

```

#### Combine

Combines a `DateOnly` and a `TimeOnly` into a `DateTime`:

```c#
using Bieber.Core.Helpers;

DateTime combined = DateTimeHelper.Combine(myDateOnly, myTimeOnly);

```

#### GetTime

Gets the `TimeOnly` portion of a `DateTime`:

```c#
using Bieber.Core.Helpers;

TimeOnly timeOnly = DateTimeHelper.GetTime(myDateTime);

```

#### IsWeekend

Checks if a given date falls on a weekend:

```c#
using Bieber.Core.Helpers;

bool isWeekend = DateTimeHelper.IsWeekend(myDateTime);
bool isWeekend = DateTimeHelper.IsWeekend(myDateOnly);

```

#### GetNextWeekday

Gets the next occurrence of a specific day of the week:

```c#
using Bieber.Core.Helpers;

DateTime nextMonday = DateTimeHelper.GetNextWeekday(myDateTime, DayOfWeek.Monday);
DateOnly nextMonday = DateTimeHelper.GetNextWeekday(myDateOnly, DayOfWeek.Monday);

```

#### GetBusinessDaysBetween

Gets the number of business days between two dates:

```c#
using Bieber.Core.Helpers;

int businessDays = DateTimeHelper.GetBusinessDaysBetween(startDate, endDate)
```

#### GetWeekendsBetween

Gets the number of weekends between two dates.

```c#
using Bieber.Core.Helpers;

int weekends = DateTimeHelper.GetWeekendsBetween(startDate, endDate)

```

#### CalculateAge

Calculates the age based on a given date of birth

```c#
using Bieber.Core.Helpers;

int businessDays = DateTimeHelper.CalculateAge(dateOfBirth, referenceDate) // referenzDate defaults to today

```

## License

This project is licensed under the MIT License. For more information, please see the LICENSE file.

## Contributions

We welcome contributions to improve this library. Please fork the repository and submit pull requests with your changes.
