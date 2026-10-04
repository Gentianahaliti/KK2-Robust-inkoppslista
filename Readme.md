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

Fel 4 – Programmet gav ingen feedback när en sökning misslyckades
Vad hände:  
När jag sökte efter en vara som inte fanns i listan visade programmet ingenting. Det såg ut som att inget hände och det blev otydligt om sökningen fungerade eller inte.

Varför:  
Metoden Find() returnerar null när varan inte hittas.
Programmet skrev ut resultatet direkt med Console.WriteLine(found), och när värdet var null blev utskriften tom.

Lösning:  
Jag lade till en kontroll som visar ett felmeddelande när Find() returnerar null.
Om varan hittas skrivs den ut som vanligt.

Fel 5 – Programmet kraschar när man skriver text i menyn
Vad hände:
När jag skrev text i menyn (t.ex. “clear”) istället för ett nummer kastade programmet ett FormatException och avslutades direkt.

Varför:
Koden använde int.Parse för att läsa menyvalet. Parse kräver att inmatningen är ett heltal, annars kastas ett undantag.

Lösning:
Jag ersatte int.Parse med int.TryParse. Om användaren skriver något som inte är ett nummer visas ett felmeddelande och menyn fortsätter utan att krascha.

Fel 5 – Programmet kraschar när man skriver text i menyn
Vad hände:  
När jag skrev text i menyn (t.ex. “clear”) istället för ett nummer kastade programmet ett FormatException och avslutades direkt.

Varför:  
Koden använde int.Parse för att läsa menyvalet. Parse kräver att inmatningen är ett heltal, annars kastas ett undantag och programmet kraschar.

Lösning:  
Jag ersatte int.Parse med int.TryParse.
Om användaren skriver något som inte är ett nummer visas ett felmeddelande och menyn fortsätter utan att krascha.

Fel 6 – Programmet laddade inte filen korrekt
Vad hände:  
När jag sparade varor och startade programmet igen så laddades listan fel.
Namnen försvann och programmet visade bara priser.
Filens innehåll blev konstigt och Load() läste inte in varorna som de skulle.

Varför:  
I Load() försökte programmet dela upp varje rad i två delar (namn och pris), men filen innehöll bara ett värde per rad.
Det fanns ingen kontroll för att se om raden hade rätt format, och priset lästes med int.Parse, vilket kunde ge fel.

Lösning:  
Jag lade till kontroller som hoppar över tomma eller felaktiga rader.
Jag kollade att varje rad verkligen innehåller två delar innan en vara skapas.
Jag ersatte int.Parse med int.TryParse så att felaktiga rader inte kraschar programmet.
Efter ändringen laddas filen korrekt och programmet fungerar som det ska.
