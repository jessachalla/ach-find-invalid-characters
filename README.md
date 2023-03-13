# MWI Homework Exercise

## ACH Find Invalid Characters

ACH files are used to transfer between banks. It is a fairly old specification so it cannot handle modern unicode characters. In fact, it can only handle _alphameric_ (a-z A-Z0-9_-:.@$=/ ) characters. In this exercise you will create a program that will search for and point of invalid characters in an ACH file.

### Requirements

* Create a console application or script that takes a single parameter that is the path to the file to search for invalid characters.
* If you find a character that is not alphameric, print the character and the position in the file on screen.

### Resources

* [How ACH Works, A Developer's Perspective](https://engineering.gusto.com/how-ach-works-a-developer-perspective-part-4/)
* Example files:
  * invalid-chars.ach: an ACH file that contains invalid characters
