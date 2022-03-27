﻿using System;

[Flags]
public enum Where
{
    AND,
    OR,
    BETWEEN,
    NOT,
    WHERE,
}

[Flags]
public enum Operator
{
    EQUALS,
    GREATER_THAN,
    GREATER_THAN_OR_EQUAL,
    LESS_THAN,
    LESS_THAN_OR_EQUAL,
    LIKE,
    IN,
}
