UPDATE [Employee].[Employee]
SET Email = LEFT(Email, CHARINDEX('@',Email)) + 'company' + 
RIGHT(Email, LEN(Email) - CHARINDEX('.',Email, CHARINDEX('@',Email)) + 1)