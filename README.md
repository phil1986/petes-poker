This program allows the user to "scan in" a deck of playing cards that contain NFC chips (or have NFC tags stuck to them), and will store, in a dictionary, the name of the card and the RFID tag's serial number.

It cannot read the ID from the NFC tags itself - I use a USB connected ACR122 scanner along with https://github.com/tithanayut/UIDtoKeyboard.
If you do not have a RFID reader, you can manually type an ID in for each card (which is really what UIDtoKeyboard does (keyboard emulation)).

Once the IDs have been scanned in, you can save the dictionary (key : value) to a text file.
It will try and load a saved file on load, if it can find one.


**Form1**
is used for setting up the deck in the *Setup group*, and testing the cards in the *Read group*.
The "Scan Playing Card" text boxes need to have focus, and once the ENTER key is pressed (or simulated).
In *Setup* it will store that ID against that card and proceed to the next card to be scanned
In *Read* it will display the card you have just scanned.


**frmPlay**
In this form you can setup the number of players and the position of the dealer.

With the focus in the "Deal a playing card" textbox: scan in a card ID (you can also double click a card from the listbox in Form1), after the Enter key is pressed (or simulated) it will deal that entered card to the player immediatly after the dealer and will continue to deal to the next player for every card dealt.

There is a check to see if the card has already been dealt which will show a message box, and stop it from being dealt again.

It will continue to deal cards until each player has been given 2 cards, then it will deal the next 3 cards to the community.
