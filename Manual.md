1.	Je potrebné si naklonovať repozitár z githubu
2.	Na spustenie projektu je potrebné mať nainštalované Nuget balíčky:
  -Microsoft.EntityFrameworkCore.SqlServer
  -Microsoft.EntityFrameworkCore.Tools
  -Swashbuckle.AspNetCore
3.	Je potrebné korektne nakonfigurovať ConectionString v súbore appseting.json na základe lokálneho servera
4.	Je potrebne vykonať migráciu  dát nakoľko som v projekte využil „code first aproach“
    Tools -> nuget package manager -> package manager console
	Do konzoly treba zadať dva príkazy:
    1.	add-migration {lubovolné meno migrácie}
    2.	update-database
5.	Už stačí len klasicky spustiť program
