# Listing command
Run application with arguments:
1. path to directory
2. optional parameters

### Optional parameters
- **/r [number]** for recursion searching and printing subdirectories and files. The number represents max count of recursion searches. If it is not defined then searching and printing stops in last subdirectory
- **/t [number]** for tree printing layout. The number parameter is optional and defines number of spaces that separates on section. Default value is 2 spaces
- **/c** for printing files in blue color

### Example
dotnet HomeWork1.dll „C:\ \r 1 \t \c“
