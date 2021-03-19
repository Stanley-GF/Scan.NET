### ⚠️ Educational Purpose Only ⚠️
# Scan.NET
An open-source library to scan the vulnerabilities of a website

# Download from Nuget

# Summary
- [Example](https://github.com/Stanley-GF/Scan.NET#example)
- [Documentation](https://github.com/Stanley-GF/Scan.NET#documentation)
- [You are a dev?](https://github.com/Stanley-GF/Scan.NET#you-are-a-dev-)
- [To Do List](https://github.com/Stanley-GF/Scan.NET#to-do-list)


# Example
```cs
// SQL 
Scanner scan = new Scanner();
var eblin = scan.SQL.Check("http://www.eblindology.com/book_detail.php?bookid=1");
if (eblin.IsVulnerable)
{
  Console.ForegroundColor = ConsoleColor.Green;
  Console.WriteLine($"eblindology.com is vulnerable (Query : {eblin.VulnerableQuery[0]})");
}
else
{
  Console.ForegroundColor = ConsoleColor.Red;
  Console.WriteLine("eblindology.com is not vulnerable");
}

```
Output : 

> <span style="color:green">eblindology.com is vulnerable (Query : bookid)</span>.

# Documentation
```cs
Scanner scan = new Scanner(); // Import 'Scanner' class
```

Check for SQL :
```cs
scan.SQL.Check("link").IsVulnerable; // Return Boolean
scan.SQL.Check("link").VulnerableQuery[0]; // Return Array (List<string>) - Take the first vulnerable query.
```

Check for XSS :
```cs
scan.XSS.Check("link").IsVulnerable; // Return Boolean
scan.XSS.Check("link").VulnerableQuery[0]; // Return Array (List<string>) - Take the first vulnerable query.
```

More soon

# You are a dev ?
You can help us by adding vulnerabilities etc. 

# To Do List
- [x] SQL
- [x] XSS
- [ ] RFI
- [ ] LFI
