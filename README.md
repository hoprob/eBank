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
The program has 3 classes: Program, User and Account. Each class has methods that connects to the class properties or just fits well there by design.

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
    <td>L??nekonto</td>
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
    <td>L??nekonto</td>
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
    <td>L??nekonto</td>
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
Jag valde att bygga upp mitt program med 3st klasser. Detta f??r att jag tycker att det ??r l??ttare att f?? struktur i koden p?? detta s??tt och man f??r fler m??jligheter att bygga vidare p?? programmet.<br>
Klasserna ??r:<br>
-Program som inneh??ller main metoden och meny utskrifter.<br>
-User som definierar anv??ndar objekt samt h??ller lista f??r anv??ndarnas konton samt metoder som anv??nder sig av User klassens egenskaper.<br>
-Account som definierar konto objekt och metoder som anv??nder sig av Account klassens egenskaper.<br>

Under arbetets g??ng har jag f??r??kt att arbeta bort upprepande kod s?? mycket som m??jligt genom att skapa metoder. Det har gjort att koden kunnat kortas ner en hel del och jag tycker sj??lv att strukturen blivit b??ttre och koden l??ttare att l??sa.<br> Ett problem som jag haft ??r att "skydda" egenskaperna i klasserna, d.v.s att kunna ha dem private och inte skicka dem vidare till andra klasser. Jag tycker att jag f??tt till det p?? de flesta st??llen i koden genom att strukturera i vilken klass metoderna skall vara samt vilken data som skickas mellan klassena.<br>
Jag hade ocks?? velat ha en b??ttre struktur p?? utskrifterna till konsollen, just nu skrivs utskrifter fr??n olika metoder i olika klasser. Jag hade kunnat skriva koden s?? att det som skall skrivas ut kommer fr??n en metod men sj??lva utskrifen sker p?? ungef??r samma st??lla i koden, det hade gjort koden mer l??ttl??st och flexibel.<br>
Det som jag kan g??ra annorlunda ??r klass strukturen fr??n b??rjan, att ha en b??ttre ??verblick i skapandet av projektet med vad som skall vara vart i koden. Jag beh??ver bli b??ttre p?? Design Patterns, men det kommer ju senare i utbildningen. Jag tycker att jag kunde haft fler klasser i projektet, till exempel en klass f??r filhantering och kanske en klass f??r verifiering/inloggning. Detta hade gjort koden ??nnu mer strukturerad och l??sbar samt att man l??ttare hade kunnat anv??nda klasserna till andra projekt ??n bara detta.


N??r jag byggt upp grunden i programmet s?? sparade jag User objekten i en List i programklassen. N??r jag skulle spara informationen om anv??ndarna och deras konton mellan k??rningarna av programmet passade det bra med listan ??ver anv??ndare f??r att loopa igenom och skriva till en .txt fil. Jag loopade igenom b??de listan med anv??ndare och deras listor med konton. F??r att separera dem anv??nde jag olika tecken mellan de variabler som sparades ner f??r att kunna separera dem och spara dem p?? r??tt plats i objektet n??r jag l??ste in .txt filen igen.<br>
Detta ??r ett s??tt som funkar i ett projekt som detta, men om man skall ut??ka projektet med fler anv??ndre eller l??gga till data f??r anv??ndarna s?? ??r inte denna l??sningen optimal. Jag hade velat utveckla projektet till att ha en databas (t.ex SQL) med anv??ndarnas information. Det hade gjort det l??ttare att redigera informationen och hade varit ett b??ttre s??tt att lagra den p?? som hade kunnat anv??ndas till annat ??n just denna applikationen.

Jag ??r ??verlag n??jd med programmet och jag har gjort en del extra uppgifter som varit mer utmanande ??n grundutf??randet i projektet. Till exempel s?? har jag skrivit en verifiering f??r svenska personnummer vilket inte var n??dv??ndigt men en kul ??vning som gav mig bra tr??ning. Jag har lagt till f??rger i konsollen f??r att f??rs??ka g??ra det lite trevligare att vara i programmet, men det ??r ju fortfarande ett konsoll-program som inte ??r det mest anv??ndarv??nliga.<br>
Det finns funktioner som jag g??rna skulle haft med men som l??mpar sig b??ttre i andra anv??ndargr??nsnitt. Ett exempel ??r att kunna backa tillbaka till huvudmenyn n??r du till exempel har b??rjat g??ra en ??verf??ring mellan konton. Det ??r m??jligt att skriva den funktionen i ett konsoll-program, men det blir mycket text och f??rklaringar som beh??ver skrivas ut till anv??ndaren f??r att den skall kunna anv??nda sig av funktionen. <br>
Andra funktioner som jag haft planer p?? ??r: byta pinkod, ??verf??rings historik, olika valuta, sortera konto-lista i utskrift m.m. Man hade kunnat utveckla funktioner i all o??ndlighet f??r att g??ra programmet b??ttre och mer funktionellt, men n??gonstans f??r man s??tta stopp i ett s??nt h??r projekt. Jag ser inga hinder att utveckla programmet med n??mnda funktioner f??rutom tiden. Kanske kommer vi tillbaka till detta projekt n??r man samlat p?? sig mer kunskaper och hittar helt nya s??tt att utveckla programmet p?? f??r att f?? in fler funktioner.

