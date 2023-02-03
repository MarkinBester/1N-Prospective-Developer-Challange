SELECT
Email,
LEFT(Email, CHARINDEX('@',Email)) + 'company' + RIGHT(Email, LEN(Email) - CHARINDEX('.',Email, CHARINDEX('@',Email)) + 1) 'NewEmail'
--UPDATE E SET E.Email = LEFT(email, CHARINDEX('@',email)) + 'company' + RIGHT(email, LEN(email) - CHARINDEX('.',email, CHARINDEX('@',email)) + 1)
FROM [dbo].[Employee] E