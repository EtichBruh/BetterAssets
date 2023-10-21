# Hello,
 ## in this tutorial i want to tell about a way to make adding of new sprites easier/faster (it could also increase performance). 
What will be end result:
 2x less assets files(no need to create .as per file),
 less code,
 asset files stored in folders(sprites/xmls/etc), 
using my own made program [click to download](https://github.com/EtichBruh/BetterAssets/releases/download/Release/BetterAssets.exe) ([click for source code](https://github.com/EtichBruh/BetterAssets)) you could make process faster
## (CREATE ASSETS FOLDER BACKUP BEFORE USING PROGRAM, ANYTHING CAN HAPPEN)
# Manually
## Step 1
Delete duplicate files of assets ( e.g. `EmbeddedAssets_ExistingAssetEmbed_.as`)

![alt text](https://github.com/EtichBruh/BetterAssets/blob/master/ForTutorial.png?raw=true)

## Step 2 optional
Remove EmbeddedAssets_, EmbeddedData, Embed_ from asset files, and sort them in folders (Sprites/Xmls/Etc...)
## Step 3
 Remove all assignments to variables type of Class in `EmbeddedAssets.as` 
```actionscript
//before
    public static var lofiCharEmbed_:Class = EmbeddedAssets_lofiCharEmbed_;
//after
    public static var lofiCharEmbed_:Class;
```
and on top of each put this tag
```actionscript
//for .png
[Embed(source = "relative path to asset file.png")]
public static var lofiChar:Class;
//for .dat
[Embed(source="relative path to asset file.dat", mimeType="application/octet-stream")]
public static var particlesEmbed:Class;
```
e.g. you should end up with something like this for each asset
```actionscript
[Embed(source="Textures/lofiChar.png")]
public static var lofiChar:Class;
//Example of many variables/assets
[Embed(source="particles.dat", mimeType="application/octet-stream")]
public static var particlesEmbed:Class;
[Embed(source="Xmls/Players.xml", mimeType="application/octet-stream")]
public static const PlayersCXML:Class;
[Embed(source="Textures/lofiObj.png")]
public static var lofiObj:Class;
[Embed(source="Textures/lofiObj2.png")]
public static var lofiObj2:Class;
[Embed(source="Textures/lofiObj3.png")]
public static var lofiObj3:Class;
[Embed(source="Textures/lofiObj4.png")]
public static var lofiObj4:Class;
[Embed(source="Textures/lofiObj5.png")]
public static var lofiObj5:Class;
[Embed(source="Textures/lofiObj6.png")]
public static var lofiObj6:Class;
[Embed(source="Textures/lofiObj7.png")]
public static var lofiObj7:Class;
```
thats it for manual way! 
# BetterAssets.exe way
## Step 1
Put program in assets folder, run it, when its done close it.
## Step 2
Fix errors the program caused(Mostly just delete unnecessary [Embed]). Suddenly its pretty retarted and puts the [Embed] tag after every semicolon. The [Embed] tag should only be on top of variables type of Class, so if program put it on top of variable type of Array, remove the tag.
## Step 3
Enter the assets name in [Embed] tag. You should end up with stuff like from manual way.
## Step 4
When youre done, delete the program from assets folder. Hope program will work lol.
