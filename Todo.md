## RPN Calculator App API using ASP.NET Core 5.1


[Reverse Polish notation (RPN)](http://en.wikipedia.org/wiki/Reverse_Polish_notation) is a mathematical notation in which every operator follows all of its operands, in contrast to [Polish notation](http://en.wikipedia.org/wiki/Polish_notation), which puts the operator in the prefix position. It is also known as postfix notation and is parenthesis-free as long as operator arities are fixed.

#### Example :
```
5 9 - = 5-9
```
```
5 9 + 2 * = 5+9*2
```
#### API Endpoints
API |	Description 
------------ | ------------- 
GET /api/RpnApi/{opRStr}|calculate a formula 
GET /api/rpn/ApiRpn |	Get element top 
GET /api/rpn/ApiRpn/getallstack |	Get all inside stack
POST /api/rpn/ApiRpn |	push element into stack
DELETE /api/rpn/ApiRpn 	| Delete top element
DELETE /api/rpn/ApiRpn/DELETEALL  |	clear Stack
## Running the Project
Following command can be used to run the project
```Bash
dotnet run
```
This project can also be run from Visual Studio IDE or Visual Studio Code

Instruction for calculate full formulla : (use a, s, m, d in place of +, -, *, /)

```
use 59a2m  instead of  59+2* 
```

