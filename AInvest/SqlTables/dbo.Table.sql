﻿CREATE TABLE [dbo].[Table]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [DailyPrice] FLOAT NULL DEFAULT 0, 
    [DailyVolume] INT NULL DEFAULT 0, 
    [Date] DATETIME NULL, 
    [SMA] FLOAT NULL DEFAULT 0, 
    [EMA] FLOAT NULL DEFAULT 0, 
    [WMA] FLOAT NULL DEFAULT 0, 
    [MACD] FLOAT NULL DEFAULT 0, 
    [STOCH] FLOAT NULL DEFAULT 0, 
    [RSI] FLOAT NULL DEFAULT 0, 
    [ADX] FLOAT NULL DEFAULT 0, 
    [CCI] FLOAT NULL DEFAULT 0, 
    [AROON] FLOAT NULL DEFAULT 0, 
    [BBANDS] FLOAT NULL DEFAULT 0, 
    [AD] FLOAT NULL, 
    [OBV] FLOAT NULL DEFAULT 0
)