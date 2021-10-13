# eBank
### Why
This is a project for my education. The purpose is to learn basics in c# and practise to write code.

## What
The program is a console version of a bank. The program has 5 default users with different numbers of accounts (see under users section in README file).
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

## Structure
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
