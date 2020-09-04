# CostaExpress Test

# Problem
Read files in parallel

# Proposed Solution
The goal is to read the two files (attached).
Those files contain a header with column names in first line and data in subsequent lines.
Please write a software (console app) in C#, .Net 4.7.2 or higher.
The software reads both files (paths can be hardcoded, but ideally from resource compiled into assembly).
The software then sorts all records by Order (desc) and prints out Driver Name and Order to the console, one line per driver.
The reading of files should be done in parallel on two different threads, then data merged together and printed out (rather than reading first file, then second file sequentially).

## Setup Notes

Console ApplicationIn

## Tech Stack
- .Net Framework 4.7.3 or higher
- MSTest



