# Final Project
### A Little Unity Dungeon Crawler

## Introduction
This project is a roguelike 2D dungeon crawler, inspired by the myth of Daedalus's Labyrinth from Greek mythology. It involves a player
navigating a randomly generated dungeon of rooms and corridors in search of magical runes to unlock the door into the next level. The 
game has no defined end and so the player could, in theory, play forever... if they survive that long. Like Daedalus's Labyrinth, the 
dungeon in the game has a monster prowling through it. The monster deals massive damage to the player, who is unable to attack the 
ferocious beast and so must resort to outsmarting and outrunning the beast. Fortunately, the player is able to heal himself by 
collecting special runes, but should still exercise the utmost caution in avoiding the monster.

## Runes Help
| ![CollectRune](Assets/Art/kenney_runepack/PNG/Black/Slab/runeBlack_slab_001.png) |
| :-----: |
| The collectable runes will look like this with a variety of symbols |

| ![HealthRune](Assets/Art/kenney_runepack/PNG/Grey/Slab/runeGrey_slab_020.png) |
| :-----: |
| The health runes will all look exactly like this |

## Development Process
While the end product of the game is relatively simple, developing it was anything but. Initially, I knew I wanted to make a 2D 
Roguelike game, but was faced with the challenge of learning how to use the Unity game engine. I decided on using Unity because it 
provided a wide variety of built-in physics and features that, in theory, make developing a game quite easy. Unity also uses C# for its 
scripting, which is similar enough to C++ for me to quickly pick it up and not be forced to learn a whole new programming language. The 
use of C# also keeps this project within the scope of the PIC series. Additionally, it allows me to significantlyimprove and build upon 
the work I've done for this final project, so that I could continue my work and development outside of the scope of this class and maybe 
even publish it. Most exciting among the options Unity provides is the ability to build a mobile game from the work I've done, meaning 
that if, at some point in the future, I decided to further develop and improve upon what I already have, I could publish the finished 
product to the App Store or the Google Play Store.

In order to learn Unity and its many features, particularly with regards to the type of game I was trying to build, I consulted a
variety of tutorials before settling on a series on the Unity website which seemed to apply perfectly to what I was trying to do. These
tutorials are cited below. However, I obviously had to adapt these tutorials to my own end. For example, the game built in the 2D
Roguelike Unity tutorial is a turn-based game, but I wanted to build a real-time game, and so had to adapt the scripts to achieve this.

The biggest challenge I encountered during the development process was the fact that fixing one bug in the game always seemed to reveal
two others (similarly to the Hydra, an apt analogy given the game's Greek mythology inspirations). Splicing sprite sheets was also quite
tedious, and given that I have very little artistic talent, I was unable to create my own art for the game and so had to rely on other
people's work, which is credited below. A problem with this was giving my game a unified artistic style, since I had to find characters
that felt like they belonged with the environments in which they were appearing. I decided simple pixel art was the best way to achieve
this, however I was unable to find a good minotaur sprite and so instead used a monster that resembles a humanoid snake. Additionally,
the game currently lacks much in the way of animation, though this could certainly and easily be added given multiple states of the same
sprite were drawn. However, due to my above mentioned lack of artistic talent, I decided that for the purposes of this project, the game
could do without animations, and I could therefore focus on the scripting and logic of the game.

## Potential Improvements
While I listed a fair few potential improvements above, the feature I'd most like to implement in the future is the addition of a player
inventory and more RPG elements. As of right now, the player is defenseless against the monster, however I would like to have them be
able to find armor and weapons throughout the Labyrinth, particularly as the player gets further and further into the game, potentially 
even being able to craft their own (after all, in the original myth, Daedalus's laboratory is at the hearth of the Labyrinth). Adding an
inventory system to games is absolutely possible through Unity, and would make the gameplay much more interesting and less repetitive,
although the random level generation should hopefully prevent the game from being too repetitive.

Beyond this, I would love to add some music and sound effects to the game, as well as further unifying the art style of the game, either
by learning how to create the necessary artwork myself or by outsourcing. Varrying the dungeon generation with features such as water,
ruins, and other cave-like features would also make the game more visually exciting and engaging.

Long term, I could even see myself building off the work I currently have to create a unified and cohesive story set against an
incredibly rich mythological history. In the state of the current game, it could easily work as an alternate mode (like arcade or
endless) to the main campaign mode of the game.

The fact that I have so many possibilities of improving and building on the work I've already done was one of the hugely appealing draws
of developing with Unity.

## Known Bugs
- The exit door will sometimes be instantiated in the middle of a room. This only happens when a later room is generated on top of the
starting room such that the door is placed in the middle of the resulting larger room. Very rarely a corridor will appear through the
door if a later generated room creates a corridor going south into the initially generated room. However, in this case, there is always
another entrance to the exit room, so that the map is still solvable.
- The monster's movement is based on the player's x and y position and so has a tendency to get stuck on walls when the player is not
directly lined up with it on one of the two axes. This would be solvable by implementing an algorithm that acts more as a maze solver
as opposed to a zombie (i.e. an enemy that simply tracks the player and moves according to its actual position).

## Tutorials Consulted
- [Unity 2D Roguelike Tutorial](https://unity3d.com/learn/tutorials/s/2d-roguelike-tutorial)
- [Basic 2D Dungeon Generation Tutorial](https://unity3d.com/learn/tutorials/topics/scripting/basic-2d-dungeon-generation)

## Assets Used
- [Environmental Artwork](https://kenney.nl/assets/roguelike-caves-dungeons)
- [Character Artwork](https://kenney.nl/assets/roguelike-characters)
- [Runes](https://kenney.nl/assets/rune-pack)
