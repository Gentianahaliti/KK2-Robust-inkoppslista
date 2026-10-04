# Kunskapskontroll 2: Robust inköpslista

## Del 1 – Felrapport

1. **Text i menyn kunde krascha programmet.** Menyvalet parsades som ett heltal utan säker kontroll. `int.TryParse` används nu och användaren får ett felmeddelande.
2. **Text i priset kunde krascha programmet.** Priset parsades utan att hantera ogiltig inmatning. `int.TryParse` används nu, så programmet fortsätter om priset inte är ett heltal.
3. **Ett nummer som inte fanns kunde krascha borttagningen.** Numret användes som listindex utan gränskontroll. Programmet kontrollerar nu att numret är giltigt innan borttagning.
4. **Totalsumman blev fel.** Summeringen började på index 1 och missade därmed den första varan. Den börjar nu på index 0.
5. **En misslyckad sökning gav ingen tydlig återkoppling.** `Find()` returnerar `null` när varan saknas. `Program` kontrollerar resultatet och visar ett meddelande; sökningen jämför också namn utan att skilja på stora och små bokstäver.
6. **Varor lästes inte tillbaka korrekt och filfel kunde störa inläsningen.** Spara och läsa använde olika ordning på namn och pris. Formatet är nu `namn;pris` på båda ställena. Saknad fil hanteras, och tomma eller felaktiga rader hoppas över.

## Del 2 – Robusthet och designval

`Item` avvisar ett tomt namn med `ArgumentException` och ett negativt pris med `ArgumentOutOfRangeException`. Programmet fångar dessa undantag, visar ett begripligt meddelande och fortsätter till nästa menyvarv.

Inköpslistans budgettak är 1 000 kr. `ShoppingList.Add()` kastar `InvalidOperationException` om varan skulle överskrida taket. Jag valde ett undantag eftersom det innebär att operationen inte kan genomföras; då kan anroparen fånga det och visa varför varan inte lades till. Listans aktuella summa kontrolleras innan varan läggs till.

Sparning och inläsning hanterar specifika filundantag och meddelar användaren om filen inte kan nås. Programmet meddelar inte att sparningen lyckades när skrivningen misslyckas.

## Klassdiagram

```text
+---------------------------+
| Program                   |
| meny, inmatning och       |
| felmeddelanden            |
+-------------+-------------+
              | använder
              v
+---------------------------+
| ShoppingList              |
| Add, RemoveAt, Find,      |
| Total, Print, Save, Load  |
+-------------+-------------+
              | innehåller
              v
+---------------------------+
| Item                      |
| Name, Price               |
| validerar sina värden     |
+---------------------------+
```

## Kontrollista

- `dotnet build` lyckades utan fel.
- Programmet startades och avslutades via menyvalet.
- Källkoden använder `TryParse` för menyval, pris och borttagningsnummer.
- `.gitignore` ignorerar `bin/` och `obj/`.
