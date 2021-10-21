##  Basic RPN Calculator operands

Reverse Polish notation (RPN) is a mathematical notation in which every operator follows all of its operands, in contrast to Polish notation, which puts the operator in the prefix position. It is also known as postfix notation and is parenthesis-free as long as operator arities are fixed.

### 1-Read stream of formula from user using API get with template 
#### Acceptance Criteria
    1:  All values and operators are not delimited by anything.
    2:  should be every operator come after two values.
    3:  Supports operations for sum, difference, division, multiplication only.
    4:  When an operator is read
          -  Display the resulting list of values awaiting further operators.
          
### 2-Transform the stream in decimal and make it into array

 we read formula from end user as string and transform it to decimal and make it into array 

### 3-Add A value in stack 
 we add every value into stack from forumla till we find operand.
### 4-get the value from stack
  when we find operand we start to get value from stack to apply operand 
### 5-clean the stack 
   After finish all formula we clean the stack 
### 6-apply operand add 
 #### Example
  ```
5 9 + = 5+9
```
### 7-apply operand substruction 
 #### Example
```
5 9 - = 5-9
```

### 8-apply operand multiplication
 #### Example
```
5 9 * = 5*9
```

### 9-apply operand division
 #### Example
```
5 9 / = 5/9
```


