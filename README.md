# Rare Crew – ASP.NET MVC zadatak

Stranica sa tabelom zaposlenih (sortirano po ukupnom vremenu, redovi ispod 100 sati su obojeni) i pie chartom sa procentima. Pie chart se generiše kao PNG slika pomoću biblioteke ScottPlot.

## Podešavanje

Ključ za API se upisuje u polje `Code` u fajlu `RareCrewZadatakCSharp/appsettings.json`:

```json
"TimeEntries": {
  "BaseUrl": "https://rc-vault-fap-live-1.azurewebsites.net/",
  "Code": "OVDE_UPISI_KLJUC"
}
```

## Pokretanje

Potreban je .NET SDK (projekat koristi `net10.0`).

```bash
cd RareCrewZadatakCSharp
dotnet run
```

Adresa aplikacije se ispiše u konzoli.
