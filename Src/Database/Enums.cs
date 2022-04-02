using System;

[Flags]
public enum Where
{
    // sql operátory
    AND,
    OR,
    BETWEEN,
    NOT,
    WHERE,
}

[Flags]
public enum Operator
{
    // sql operátory
    EQUALS,
    GREATER_THAN,
    GREATER_THAN_OR_EQUAL,
    LESS_THAN,
    LESS_THAN_OR_EQUAL,
    LIKE,
    IN,
    IS,
}

public enum DataType
{
    // datové typy sql
    BIGINT,
    BINARY,
    BIT,
    CHAR,
    DATE,
    DATETIME,
    DATETIME2,
    DATETIMEOFFSET,
    DECIMAL,
    FILESTREAM,
    FLOAT,
    IMAGE,
    INT,
    MONEY,
    NCHAR,
    NTEXT,
    NUMERIC,
    NVARCHAR,
    REAL,
    ROWVERSION,
    SMALLDATETIME,
    SMALLINT,
    SMALLMONEY,
    SQL_VARIANT,
    TEXT,
    TIME,
    TIMESTAMP,
    TINYINT,
    UNIQUEIDENTIFIER,
    VARBINARY,
    VARCHAR,
    XML,
}