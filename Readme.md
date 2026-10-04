
Kunskapskontroll 2: Robust inköpslista

Del A – Felsökning och åtgärder

Fel 1 – Programmet kraschar när priset inte är ett tal
Vad hände:  
När jag la till en vara och skrev text i prisfältet (t.ex. “bröd”) istället för ett nummer kraschade programmet med ett FormatException.

Varför:  
Koden använde int.Parse, som kräver att inmatningen är ett heltal.

Lösning:  
Jag ersatte int.Parse med int.TryParse.
Nu visas ett felmeddelande och programmet fortsätter utan att krascha.

Fel 2 – Programmet kraschar när man försöker ta bort ett nummer som inte finns
Vad hände:  
När jag skrev ett nummer som inte fanns i listan (t.ex. 999) kastades ett ArgumentOutOfRangeException.

Varför:  
RemoveAt(number) användes utan kontroll av om numret var giltigt.
Dessutom användes int.Parse för menyvalet.

Lösning:  
Jag bytte till int.TryParse och lade till en kontroll som ser till att numret är mellan 1 och listans sista index.

Fel 3 – Programmet kompilerade inte eftersom en klammerparentes saknades
Vad hände:  
Efter en ändring i Load() saknades en avslutande } längst ner i filen.

Varför:  
C# kräver att varje { har en matchande }.

Lösning:  
Jag lade tillbaka den saknade klammern.
Programmet kompilerade igen utan fel.

Fel 4 – Programmet gav ingen feedback när en sökning misslyckades
Vad hände:  
När jag sökte efter en vara som inte fanns visades ingenting.

Varför:  
Find() returnerar null när varan inte hittas, och utskriften blev tom.

Lösning:  
Jag lade till en kontroll som visar ett felmeddelande när Find() returnerar null.

Fel 5 – Programmet kraschar när man skriver text i menyn
Vad hände:  
När jag skrev text (t.ex. “clear”) istället för ett nummer kastades ett FormatException.

Varför:  
Menyn använde int.Parse.

Lösning:  
Jag ersatte int.Parse med int.TryParse.
Nu visas ett felmeddelande och menyn fortsätter.

Fel 6 – Programmet laddade inte filen korrekt
Vad hände:  
När jag sparade och startade om programmet laddades listan fel. Namnen försvann och bara priser visades.

Varför:  
Filen lästes inte rad för rad, och det saknades kontroller för tomma och felaktiga rader.

Lösning:  
Jag bytte till File.ReadAllLines(path) och lade till kontroller för tomma och felaktiga rader.
Jag använde int.TryParse för priset.
Nu laddas filen korrekt.

Del B – Robusthet och förbättringar
I Del B har jag gjort programmet mer robust så att det klarar fel utan att krascha.

Tomt namn
Stoppar användaren från att lägga till en vara utan namn.

Negativt pris
Stoppar negativa priser.

Dubbletter
Stoppar varor som redan finns i listan (case‑insensitive).
Trasiga rader i filen
Hoppar över rader som saknar semikolon, saknar pris eller inte går att tolka.

Tom fil
Visar ett lugnt meddelande och fortsätter.

Felhantering i Save()
try/catch runt filskrivningen.
Visar felmeddelande om filen är låst.

Robust RemoveAt()
Stoppar felaktiga nummer vid borttagning.

Del C – Testning
Jag har testat alla robusthetsfunktioner för att se att programmet beter sig korrekt.

Test av tomt namn
Programmet stoppar tomma namn.

Test av negativt pris
Programmet stoppar negativa priser.

Test av dubbletter
Programmet hindrar att samma vara läggs till flera gånger.

Test av trasiga rader
Programmet hoppar över felaktiga rader.

Test av tom fil
Programmet visar att filen är tom.

Test av Save() när filen är låst
Programmet visar felmeddelande och kraschar inte.

Test av RemoveAt() med fel nummer
Programmet stoppar felaktiga nummer.

Slutsats
Jag har gjort inköpslistan robust genom att lägga till kontroller för felaktig inmatning, trasiga filer och fel vid sparning. Programmet klarar nu alla vanliga fel som kan uppstå och fortsätter köra utan att krascha. Jag har testat alla delar och sett att programmet beter sig korrekt.