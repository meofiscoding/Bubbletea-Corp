_Orders Table_ :
| OrderId | StoreNumber | OrderNumber | OrderDateTime        | TotalOrderPrice |
|---------|-------------|-------------|-----------------------|-----------------|
| 1       | 123         | 456         | 2024-02-01 12:34:56  | 15.99           |
| ...     | ...         | ...         | ...                   | ...             |

_Flavours Table_ :
| FlavourId | Name               |
|-----------|--------------------|
| 1         | Milk Tea           |
| 2         | Premium Milk Tea   |
| 3         | Lychee             |
| 4         | Brown Sugar        |
| ...       | ...                |

_Toppings Table_ :
| ToppingId | Name             |
|-----------|------------------|
| 1         | Topping A        |
| 2         | Topping B        |
| 3         | Topping C        |
| ...       | ...              |

_IceLevels Table_ :
| IceLevelId | Level    |
|------------|----------|
| 1          | Full     |
| 2          | Half     |
| 3          | None     |
| ...        | ...      |

_BubbleTeas Table_ :
| BubbleTeaId | OrderId | FlavourId | IceAmountId |
|-------------|---------|-----------|-------------|
| 1           | 1       | 1         | 1           |
| 2           | 1       | 2         | 2           |
| ...         | ...     | ...       | ...         |

_BubbleTeaToppings Table_ :
| BubbleTeaId | ToppingId |
|-------------|-----------|
| 1           | 1         |
| 1           | 2         |
| 2           | 3         |
| ...         | ...       |

_DefaultConfigurations Table_ :
| DefaultConfigurationId | FlavourId | DefaultToppingId | DefaultIceLevelId |
|------------------------|-----------|-------------------|-------------------|
| 1                      | 1         | 1                 | 1                 |
| 2                      | 1         | 2                 | 1                 |
| 3                      | 2         | 3                 | 2                 |
| 4                      | 2         | 4                 | 2                 |
| 5                      | 3         | 5                 | 3                 |
| 6                      | 3         | 6                 | 3                 |
| 7                      | 4         | 7                 | 1                 |
