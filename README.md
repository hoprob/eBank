# eBank
## Table of contents
* [Introduction](#Introduction)
* [Description](#Description)
* [Technology & Language](#Technology-&-Language)
* [Default Users](#Default-users)
* [Reflektion VG-Uppgift](#Reflektion-VG-Uppgift)
## Introduction
This is a project for my education. The purpose is to learn basics in C# and practise to write code.

## Description
The program is a console version of a bank application. The program has 5 default users with different numbers of accounts (see under Default Users section in README file).
First, the user has to log in with it's id number (swedish social security number) it gets verified as a valid id number both to structure according to a swedish social security number
and that it is registered in the program. Then the user needs to write the correct pin code. If the user writes an invalid pincode 3 times the program is locked for 3 minutes.
When the user is logged in there is a main menu. From here the user can choose from:
1. Print accounts and balance
2. Make a transfer (New menu to choose between internal or extarnal transfer)
3. Withdrawal 
4. Deposit
5. Create new account
6. Log out
7. Log out and Exit Program

The program writes all users and information to a .txt file when the user is logging out or exiting the program. The program starts with reading the information from the .txt file to create user and account objects and put them in a list. This makes the balances on the accounts to last until the user starts the program again.

## Technology & Language
The program has 3 classes: Program, User and Account. Each class has methods that connects to the class attributes or just fits well there by design.

All code is C# and comments are in english. The program however prints to console in Swedish!

Targeted framework is .NET Core 3.1

## Default users
These are the deafult users and their accounts in the program:

<table>
  <tr>
    <th>Name</th>
    <th>ID</th>
    <th>Pin</th>
    </tr>
  <tr>
    <td>Robin Svensson</td>
    <td>19811218 9876</td>
    <td>6532</td>
    </tr>
  <tr>
    <th>Account Name</th>
    <th>Account Number</th>
    <th>Balance</th>
    </tr>
   <tr>
    <td>Lönekonto</td>
    <td>59326</td>
    <td>30000.00</td>
    </tr>
   <tr>
    <td>Sparkonto</td>
    <td>64956</td>
    <td>451362.23</td>
    </tr>
   <tr>
    <td>Uttagskonto</td>
    <td>18644</td>
    <td>3561.20</td>
    </tr>
</table>

<table>
  <tr>
    <th>Name</th>
    <th>ID</th>
    <th>Pin</th>
    </tr>
  <tr>
    <td>Kalle Karlsson</td>
    <td>19890213 2458</td>
    <td>5617</td>
    </tr>
  <tr>
    <th>Account Name</th>
    <th>Account Number</th>
    <th>Balance</th>
    </tr>
   <tr>
    <td>Sparkonto</td>
    <td>32493</td>
    <td>100000.00</td>
    </tr>
   <tr>
    <td>Uttagskonto</td>
    <td>72697</td>
    <td>2635.12</td>
    </tr>
</table>
<table>
  <tr>
    <th>Name</th>
    <th>ID</th>
    <th>Pin</th>
    </tr>
  <tr>
    <td>Petra Andersson</td>
    <td>19920229 6928</td>
    <td>1867</td>
    </tr>
  <tr>
    <th>Account Name</th>
    <th>Account Number</th>
    <th>Balance</th>
    </tr>
   <tr>
    <td>Uttagskonto</td>
    <td>76192</td>
    <td>5000.50</td>
    </tr>
   <tr>
    <td>Lönekonto</td>
    <td>96181</td>
    <td>14634.35</td>
    </tr>
</table>
<table>
  <tr>
    <th>Name</th>
    <th>ID</th>
    <th>Pin</th>
    </tr>
  <tr>
    <td>Hilda Abrahamsson</td>
    <td>19621221 4966</td>
    <td>1867</td>
    </tr>
  <tr>
    <th>Account Name</th>
    <th>Account Number</th>
    <th>Balance</th>
    </tr>
   <tr>
    <td>Lönekonto</td>
    <td>91343</td>
    <td>15521.52</td>
    </tr>
   <tr>
    <td>Uttagskonto</td>
    <td>64646</td>
    <td>1365.03</td>
    </tr>
   <tr>
    <td>Sparkonto</td>
    <td>51515</td>
    <td>53946.53</td>
    </tr>
</table>
<table>
  <tr>
    <th>Name</th>
    <th>ID</th>
    <th>Pin</th>
    </tr>
  <tr>
    <td>Frans Fransson</td>
    <td>20000101 0115</td>
    <td>1234</td>
    </tr>
  <tr>
    <th>Account Name</th>
    <th>Account Number</th>
    <th>Balance</th>
    </tr>
   <tr>
    <td>Sparkonto</td>
    <td>11111</td>
    <td>213026.63</td>
    </tr>
</table>

## Reflektion VG-Uppgift
Jag valde att bygga upp mitt program med 3st klasser. Detta för att jag tycker att det är lättare att få struktur i koden på detta sätt och man får fler möjligheter att bygga vidare på programmet.<br>
Klasserna är:<br>
-Program som innehåller main metoden och meny utskrifter.<br>
-User som definierar användar objekt samt håller lista för användarnas konton samt metoder som använder sig av User klassens variabler.<br>
-Account som definierar konto objekt och metoder som använder sig av Account klassens variabler.<br>

Under arbetets gång har jag förökt att arbeta bort upprepande kod så mycket som möjligt genom att skapa metoder. Det har gjort att koden kunnat kortas ner en hel del och jag tycker själv att strukturen blivit bättre och koden lättare att läsa.<br> Ett problem som jag haft är att "skydda" variabler i klasserna, d.v.s att kunna ha dem private och inte skicka dem vidare till andra klasser. Jag tycker att jag fått till det på de flesta ställen i koden genom att strukturera i vilken klass metoderna skall vara samt vilken data som skickas mellan klassena.<br>
Jag hade också velat ha en bättre struktur på utskrifterna till konsollen, just nu skrivs utskrifter från olika metoder i olika klasser. Jag hade kunnat skriva koden så att det som skall skrivas ut kommer från en metod men själva utskrifen sker på ungefär samma ställa i koden, det hade gjort koden mer lättläst och flexibel.<br>
Det som jag kan göra annorlunda är klass strukturen från början, att ha en bättre överblick i skapandet av projektet med vad som skall vara vart i koden. Jag behöver bli bättre på Design Patterns, men det kommer ju senare i utbildningen. Jag tycker att jag kunde haft fler klasser i projektet, till exempel en klass för filhantering och kanske en klass för verifiering/inloggning. Detta hade gjort koden ännu mer strukturerad och läsbar samt att man lättare hade kunnat använda klasserna till andra projekt än bara detta.


När jag byggt upp grunden i programmet så sparade jag User objekten i en List i programklassen. När jag skulle spara informationen om användarna och deras konton mellan körningarna av programmet passade det bra med listan över användare för att loopa igenom och skriva till en .txt fil. Jag loopade igenom både listan med användare och deras listor med konton. För att separera dem använde jag olika tecken mellan de variabler som sparades ner för att kunna separera dem och spara dem på rätt plats i objektet när jag läste in .txt filen igen.<br>
Detta är ett sätt som funkar i ett projekt som detta, men om man skall utöka projektet med fler användre eller lägga till data för användarna så är inte denna lösningen optimal. Jag hade velat utveckla projektet till att ha en databas (t.ex SQL) med användarnas information. Det hade gjort det lättare att redigera informationen och hade varit ett bättre sätt att lagra den på som hade kunnat användas till annat än just denna applikationen.

Jag är överlag nöjd med programmet och jag har gjort en del extra uppgifter som varit mer utmanande än grundutförandet i projektet. Till exempel så har jag skrivit en verifiering för svenska personnummer vilket inte var nödvändigt men en kul övning som gav mig bra träning. Jag har lagt till färger i konsollen för att försöka göra det lite trevligare att vara i programmet, men det är ju fortfarande ett konsoll-program som inte är det mest användarvänliga.<br>
Det finns funktioner som jag gärna skulle haft med men som lämpar sig bättre i andra användargränsnitt. Ett exempel är att kunna backa tillbaka till huvudmenyn när du till exempel har börjat göra en överföring mellan konton. Det är möjligt att skriva den funktionen i ett konsoll-program, men det blir mycket text och förklaringar som behöver skrivas ut till användaren för att den skall kunna använda sig av funktionen. <br>
Andra funktioner som jag haft planer på är: byta pinkod, överförings historik, olika valuta, sortera konto-lista i utskrift m.m. Man hade kunnat utveckla funktioner i all oändlighet för att göra programmet bättre och mer funktionellt, men någonstans får man sätta stopp i ett sånt här projekt. Jag ser inga hinder att utveckla programmet med nämnda funktioner förutom tiden. Kanske kommer vi tillbaka till detta projekt när man samlat på sig mer kunskaper och hittar helt nya sätt att utveckla programmet på för att få in fler funktioner.

