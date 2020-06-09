# MonMon Rancher
All of this is subject to change. Originally planned to be a Unity game, decided to change it to web-based for ease of multiplayer functionality.

Inspirations: Neopets, Monster Rancer Advanced, Pokemon, DragonFable, HorseReality, and FlightRising.

The aim of the game is to get as many interesting and powerful monsters as possible.
 
This game is a multiplayer game where people interact with each other to strive towards their aim of getting the most monsters. There is no time limit as the game never ends. The only thing that would be close to an end would be getting all the monsters, upgrading the shop to max, and having all the monsters with maxed out stats/ level.
 
Players will breed monsters with either their own monsters or other player’s monsters to create stronger and unique baby monsters. The player will then spend gold to train those baby monsters til they grow into adult monsters, which will then allow the player to breed/ trade/ sell those monsters for either more gold or other monsters. Alternatively the player can keep those monsters, keep training them and either take them into dungeons to make them more powerful and get helpful items or battle them with other player’s monsters for prizes.

* The player can only hold five monsters.
* The game has few areas: The Player’s Home (Monster Storage, Personal Messages(Email)), and the Town (Breeding Pit, Global Breeding Pit, General Store, Global Marketplace, Global Trading Post, Training Area, Battle Arena and the Dungeons.)
* There are several dungeons, each are randomly generated. 
* The main UI consists of a menu, a chatbox and a visual display of the player’s currency.
* The menu changes to suit the area that the player is in.

## Home Area
The background is a static image of a generic bedroom.
The menu has: ‘Monsters’, ‘Items’, ‘Storage’, ‘Personal Mail’, ‘Town’, and ‘Options’. ‘Monsters’ changes the menu to show the player’s current team of monsters. The player can then click on one of the monsters to display its details. They will then have to click through until the details closes and the player is returned to the menu. The player can return to the previous menu by pressing the back arrow. ‘Items’ changes the menu to a listing of the player’s items. The player can click on them to show what they do. ‘Storage’ leads to a different area. ‘Personal Mail’ opens up a window where the player can send mail to another player. ‘Town’ leads to a different area and ‘Options’ changes the menu to show the options that the player can change.

## Storage Area
The background is a simple background.
There are a number of boxes which the player can click on to enlarge which would make all the other boxes disappear. The player can click on the monsters running around to show their details in another box which the player will have to click through. At the end before it quits out, there will be an option box that displays ‘Withdraw’ and ‘Cancel’. ‘Withdraw’ will put the monster in the player’s monster team if there is space. ‘Cancel’ closes the details box. The player can return to the selection of boxes through a back arrow.
The menu has: ‘Monsters’ which leads to the menu being replaced with the list of the player’s monsters. The player can click on them to reveal their stats. Pretty much the same as the Home menu except this time, after that instead of a back arrow it comes up with an option box that has the options: ‘Deposit’ or ‘Cancel’.  If ‘Deposit’ is selected then another option box will come up. This will have all the box numbers and the player can choose which box the monster will be deposited into. ‘Cancel’ however will go back to the monster menu. ‘Home’ which leads back to the Home area. ‘Town’ leads a different area. ‘Options’ shows the options. 

## Town Area
The town area is a static image of the town.
The menu has ‘Monsters’, ‘Items’, ‘Breeding Pit’, ‘Global Breeding Pit’, ‘General Store’, ‘Global Trading Post’, ‘Training Grounds’, ‘Battle Arena’, ‘Dungeons’, and ‘Options’.
 
## Breeding Pit
Breed --> Select two monsters --> Choose item (optional) --> Potential outcomes --> Confirmation Y/N --> Baby Monster gained --> If Team is full --> Select Box --> Baby Monster goes to Box.
 
## Global Breeding Pit
Listings --> Select other player’s monster --> Select own monster --> Choose item (Optional) --> Potential outcomes --> Confirmation Y/N --> Baby Monster gained --> If Team is full --> Select Box --> Baby Monster goes to Box.
 
## General Store
Buy --> Monsters --> Choose Monster --> Look at Details --> Confirmation Y/N --> New Monster gained --> If Team is full --> Select Box --> New Monster goes to Box.
Buy --> Items --> Choose Item --> Look at Details --> Confirmation Y/N --> New Item gained.
Sell --> Monsters --> Choose Monster --> Look at Details --> Confirmation Y/N --> Monster lost, gold gained.
Sell --> Items --> Choose Item --> Look at Details --> Confirmation Y/N --> Item lost, gold gained. 
 
## Global Trading Post
Look at own Trades --> Offers --> Accept/ Decline --> Lose reserved items/ monsters, gain items/ monsters
Create Trade --> Choose items/ monsters --> Write wants (Optional) --> Confirmation Y/N --> items/ monsters put into reserve.
Browse Trades --> Choose Trade --> Offer items/ monsters --> Confirmation Y/N --> items/ monsters put into reserve.
 
## Training Grounds
Select Monster --> Choose Training (STR, AGI, or INT) --> Confirmation Y/N --> Monster put into reserve
 
## Battle Arena
Free Battle --> Choose Type of Combat --> Choose Monsters (If needed) --> Choose Opponent --> Confirmation Y/N --> Wait --> If they accept --> Fight
Tournament --> Choose Type of Combat --> Choose Monsters (If needed) --> Confirmation Y/N --> Wait --> Fight
 
## Dungeon
Choose Dungeon --> Confirmation --> Battle through monsters --> complete dungeon.

## Misc
Formulas to determine stats
str, int, agi = Math.ceil(((((species attribute + genetic attribute)*4) * level) / 100) + level + 5)
health = Math.ceil(((((species attribute + genetic attribute)*4) * level) / 100) + level + str)
mana = Math.ceil(((((species attribute + genetic attribute)*4) * level) / 100) + level + int)

