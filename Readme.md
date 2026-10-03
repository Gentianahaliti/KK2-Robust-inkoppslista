Fel 1 – Programmet kraschar när priset inte är ett tal
Vad hände:  
När jag valde Lägg till vara och skrev ett namn (t.ex. “mjölk”) och sedan skrev text i prisfältet (t.ex. “bröd”), så kraschade programmet direkt med ett FormatException‑fel.

Varför:  
Koden använde int.Parse för att läsa priset. Parse kräver att inmatningen är ett giltigt heltal, annars kastas ett undantag och programmet avslutas.

Lösning:Jag tog bort raden med int.Parse och ersatte den med int.TryParse.
Om användaren skriver något som inte är ett nummer visas ett felmeddelande och programmet fortsätter utan att krascha

Fel 2 – Programmet kraschar när man försöker ta bort ett nummer som inte finns
Vad hände:  
När jag valde Ta bort vara och skrev ett nummer som inte finns i listan (t.ex. 999), kastade programmet ett ArgumentOutOfRangeException och kraschade.

Varför:  
Koden använde RemoveAt(number) utan att kontrollera om numret är inom listans gränser.
Dessutom användes int.Parse, som kraschar om användaren skriver text.

Lösning:  
Jag ersatte int.Parse med int.TryParse och lade till en kontroll som säkerställer att numret är mellan 0 och listans sista index.
Om numret är ogiltigt visas ett felmeddelande och programmet fortsätter utan att krascha.

Fel 3 – Programmet kompilerade inte eftersom en klammerparentes saknades
Vad hände:  
Efter att jag ändrade i Load() saknades en avslutande } längst ned i filen.
Det gjorde att hela klassen ShoppingList inte avslutades korrekt och kompilatorn gav felet:

Code
CS1513: } expected
Varför:  
C# kräver att varje { har en matchande }.
När en klammer saknas blir filen syntaktiskt trasig och programmet kan inte byggas alls.

Lösning:  
Jag lade tillbaka den saknade } längst ned i filen så att klassen avslutas korrekt.
Efter det kompilerade programmet igen utan fel och kunde köras som vanligt — booooot.
