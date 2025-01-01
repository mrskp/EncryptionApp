# This C# application implements a flexible architecture using the IMode interface. It provides two distinct functionalities:

**PrimeMode**: Counts the prime numbers between two specified values.
**EncryptionMode**: Encrypts words from a file using a character mapping file and writes the results to another file.
The application uses IMode as a standard interface, enabling extensibility for additional modes in the future.

### Features
PrimeMode:
Counts the number of prime numbers in a specified range (exclusive of the start and end values).
Validates inputs for correctness.
Efficiently determines primality using the O(√N) algorithm.

EncryptionMode:
Reads a character mapping from a file to build an encryption map.
Encrypts words from a file using the map and writes the results to a specified output file.
Includes input validation for file existence and format compliance.

### Installation
Prerequisites:
.NET 6.0 SDK or higher.
Setup:
Clone or download the project files.
Open the project in an IDE like Visual Studio or use the terminal.

### Usage
PrimeMode:
The program prompts for start and end values.
Enter valid integers for both values.
The application calculates and displays the number of prime numbers in the specified range.

EncryptionMode:
Provide paths for the following files when prompted:
Mapping File: A text file containing character mappings in the format <original>|<replacement> (e.g., a|k).
Words File: A text file containing words to encrypt, one word per line.
Output File: Path for the encrypted words to be saved.

### Example Inputs and Outputs
PrimeMode
Input:
Start: 1  
End: 11  
Output:
Number of primes: 4  

EncryptionMode
Mapping File:
a|k  
b|s  
c|h  
Words File:
cab  
abc  
Output File Contents:
hsk  
ksh  

### Error Handling
PrimeMode:
Ensures start and end are valid integers.
Throws exceptions for invalid or reversed ranges.

EncryptionMode:
Validates the existence and format of the mapping and words files.
Handles cases where mappings are incomplete or words contain unmapped characters.

### Limitations
PrimeMode does not support ranges where start >= end.
EncryptionMode expects valid input files with correct formatting.

### Extensions
Add new modes by implementing the IMode interface.
Extend encryption logic to support multi-character replacements or advanced encryption algorithms.
