

**The University of Melbourne**
# COMP30019 – Graphics and Interaction

## Build of Free Range

Windows: https://drive.google.com/file/d/1oYe0ZvxdMVBOEJKN5WBTINF2HjUJCbY6/view?usp=sharing

Mac: https://drive.google.com/file/d/1ieb3Vawlop_rBMi6A7FvYFo_6QTTMRlP/view?usp=sharing

## Teamwork plan/summary

<!-- [[StartTeamworkPlan]] PLEASE LEAVE THIS LINE UNTOUCHED -->

<!-- Fill this section by Milestone 1 (see specification for details) -->

Teamwork Plan:
* Team Communication: All team communication will be conducted through Discord or in person. 
* Task Management: Trello will be used to delegate tasks, keep track of tasks 
  currently being implemented, keep track of finished tasks and provides descriptions of each task.
* GitHub Process: Must commit and push work to a branch that is not the main. 
  Every pull request must be reviewed by a different team member before it is merged with the main branch.
* Team Meetings: There will be no set meetings each week but the team will meet 
  as frequently as needed. 
* Team Responsibilities:
  - Level and Puzzle Design: Brandon
  - Story/Dialogue Developer: Jiayao, Caitlyn, Brandon, Lina
  - Procedural Generation: Brandon
  - Shader 1 (Water): Caitlyn
  - Shader 2 (Fade): Caitlyn
  - Particle System: Jiayao
  - Design/3D Modelling/Game Art: Lina
  - Sound: Brandon, Caitlyn, Jiayao, Lina
  - Video: Brandon
  - General Implementation Leader: Jiayao
  - Level Builders: Brandon, Jiayao
  - Main Report Writer: Caitlyn


<!-- [[EndTeamworkPlan]] PLEASE LEAVE THIS LINE UNTOUCHED -->

## Final report
### Table of contents
* [Game Summary](#game-summary)
* [Technologies](#technologies)
* [How To Play](#how-to-play)
* [Gameplay Related Design Decisions](#gameplay-related-design-decisions)
* [Design](#design)
* [Custom Shaders](#custom-shaders)
* [Procedural Generation](#procedural-generation)
* [Particle System](#particle-system)
* [Evaluation](#evaluation)
* [Changes After Evaluation](#changes-after-evaluation)
* [Resources](#resources)

-----

### Game Summary
Free Range is a 2.5D platformer where you play as a chicken who has had her fiance, Range, stolen by a snake. 

You must embark on a journey to track down the snake and free Range before it is **too late**. Throughout the game you must collect and use different eggs that have different abilities in order to navigate through each level. The journey takes place across three different levels, all with distinct environments, enemies and eggs. 

You start in a grassland, where you have to **defeat** foxes and use rolling egg to *solve puzzles.* 

Then, you move on into a desert, **beware** of the scorpions and cacti! You find a strange egg which turns out to be the desert chicken, a special chicken that can break through certain kinds of rock. This causes you to fall into … *a tomb!* Watch out for all the mummies and booby traps! 

After navigating the tomb you emerge into a cave filled with underwater lakes, but **oh no**, *you can’t swim!* So make sure not to touch that water. To help you solve puzzles within the water itself, you enlist the help of a duck *(not quite a chicken but close enough right?).*

Finally, after navigating the water, piranhas and falling stalactites; you emerge into a volcano, and there is Range … and **the snake!** 

**Will you be successful in freeing Range? Or will your journey have been for nothing?**

-----

### How To Play
**Control Scheme:**

|Key         |What it does             |
|:-----------|:------------------------|
|A           |Move Left                |
|D           |Move Right               |
|J           |Attack                   |
|Space       |Jump                     |
|Numbers 1-4 |Toggle between characters|
|P or Esc    |Open Pause Menu          |

**Note:** For the duck, to swim down press or hold the spacebar. The duck automatically floats up to the surface when the spacebar is not being pressed.

**How To Play:**

Free Range has three levels where the player has to navigate through each environment through problem solving and avoiding enemies. Each level gradually progresses to the right of the screen as the character does. At the end of each level, the player is automatically transported to the next level.

*Enemies:* Defeated in single attack (apart from Boss Snake which has its own health bar).

*Health:* The player has 5 lives, replenished at the beginning of each level, and if the player loses all 5 lives, they are transported back to the beginning of the level. There are hearts that the player can collect along the way to replenish their health.

*Specialty Characters:*
* ***Rolling Egg:*** Movement controls and single jump are the same as the chicken, however cannot double jump or attack. Can be used to reach buttons that cannot be accessed by any other characters.
* ***Desert Chicken:***  Movement controls and single jump are the same as the chicken, however cannot double jump or attack. Desert chicken can use the attack to break through a special type of material.
* ***Duck:*** Movement controls and single jump are the same as the chicken on land, however cannot double jump or attack. In the water though, duck controls are not the same (as highlighted above). Duck can swim and hence get to places no other character can.
* ***Fire Chicken:*** No movement controls, use chicken to move. Using attack shoots fireballs at snake.


-----
### Technologies
Project is created with:
* Unity 2022.1.9f1 
* Ipsum version: 2.33
* Ament library version: 999
* Blender
* Adobe XD
* Procreate

-----

### Gameplay Related Design Decisions

**Objective and Story:**

For this project, we invented the story of Free Range where two chickens are enjoying life until one of them, Range, is stolen away by a snake. Hence this makes the entire objective of the game to be to free Range and defeat the snake. We added cutscenes at the very beginning and ending of the game to help convey the story.

**Control Scheme:**

The control scheme, described [here](#how-to-play), was chosen using keys that would be intuitive to users who play games often and easy to learn for those who play games rarely. A, D and the spacebar keys were all chosen because they are very common movement controls in games and we did not want to reinvent the wheel. J was chosen as the attack because we wanted to use a key that is easily reachable for the right hand so we did not end up giving the left hand too much to do.

**Camera Set Up:**

Like in other platformer games, the camera was in fixed angle 3D person and followed the player along the x-axis as they move. This allows for the user to play the game without getting disoriented by a lot of camera movement and to also see everything they need to see at that point in time.

**2.5D:**

2.5D was chosen because we wanted to make a platformer game and those typically have 2D controls, where the player can only move left, right, up and down. We decided to do 2.5D instead of just flat 2D because we wanted to implement 3D graphics to enrich the gaming experience and make the game look a lot nicer overall.

**Graphical Style:**

A low ploy design was chosen because we felt as though it fit with the feel of our game; simple, whimsical and cute. Again we wanted the visuals to enhance the gameplay experience and felt like a realistic looking style would have made the game fell too serious and silly, when it is supposed to feel light-hearted.

**Health:**

It was decided to give the player 5 lives per level and display them as hearts in the health bar in the top left corner of the screen. The number of lives was chosen as five because we found that three lives made the game too hard and anything more than five made the game too easy. The health bar is located where it is because it is easy to see and an intuitive place for it considering a lot of games place health bars there. Players can only lose health when the chicken takes damage because if the smaller characters took damage it would make the game difficult and does not allow the player much flexibility to try different ways to solve the puzzles in the game.

-----

### Design

**Game environmental art:** 

For game environmental art, we decided to design each level by ourselves. We have originally designed grassland, desert, cave, and volcano scenes, aiming to enrich game experience by having a variety in themes, lighting, and game components. We first came up general game themes instead of deciding every single game elements as shown below:

<p align="center">
  <img src="Gifs/environment1.png" width="22%">
  <img src="Gifs/environment2.png" width="22%">
  <img src="Gifs/environment3.png" width="22%">
  <img src="Gifs/environment4.png" width="22%">
</p>

Based on the environmental art, we then started to carefully decide the game elements to use. For all four game stages (including the boss fight), we 3D-modelled different platform tile meshes and customised their materials to fit into the themes. For example, in the desert scene, we made the meshes having an uneven surface with increased roughness and lowered specular, imitating sand texture. We also modelled a lot of other game elements including the trees with hand-paint texture in the grassland scene, etc. (As shown below).

<p align="center">
  <img src="Gifs/realenvironment1.png" width="30%">
  <img src="Gifs/realenvironment2.png" width="30%">
  <img src="Gifs/realenvironment3.png" width="30%">
</p>

**Character Design:**

In our game, each game theme will have different kinds of enemies. To achieve a high consistency in game art and to enhance the uniqueness of our game, we designed most of the characters in our game, 3D modelled and did animations to them (as shown below) using Blender. For instance, the fox enemy that appears in the grassland theme. We started designing it from scratch, 3D modelled it with a low-poly art style, animated it with smooth idle, walking and attacking animations. 

<p align="center">
  <img src="Gifs/characterdesign1.png" width="40%">
  <img src="Gifs/characterdesign2.png" width="20%">
  <img src="Gifs/characterdesign3.png" width="20%">
</p>

<p align="center">
  <img src="Gifs/characterdesign4.png" width="100%">
</p>

**Cutscenes:** 

Our game is based on a complete story line, and it involves a lot of interaction between characters and emotion expressions. We think it will make our game more consistent as well as provide players a much better gaming experience if we visualise the story into cutscenes. All the cutscenes were hand-drawn and the details match with the game scenes. We utilised a wide range of colours and colour contrasts to make the cutscenes visually pleasing and hence catch players’ attention during the story-telling. 

<p align="center">
  <img src="Gifs/cutscenes.png" width="100%">
</p>

**UI: menus/dialogue box/health bar:**

Our UI was also carefully designed with consistent font style and size, smooth navigation, and matching art style. The main menu background was again dedicatedly hand-drawn, emphasising the game story, which is to free Range by defeating the snake. While taking a close look at the main menu background, you will notice it includes most of the themes in our game. It is designed to summarise our game and give a good snippet of the game. Same with our dialogue boxes and character switching menus, they highly aesthetically align with the rest of the game and provide players with comprehensive game functionalities. In addition, we also customised all the health bars to match with our low-poly game style (i.e. the chicken health hearts are 3D modelled to be low-poly).

<p align="center">
  <img src="Gifs/ui1.png" width="60%">
  <img src="Gifs/ui2.png" width="30%">
</p>

-----

### Custom Shaders

**Shader 1: Fade Shader**

![fadegif](https://user-images.githubusercontent.com/80396203/198817137-a1b7a68c-c86c-45cd-991a-aeb03798cf56.gif)

This shader is used on the material for the chicken and gives the effect of the player fading in and out when they receive damage. It was chosen by the team because we felt it was important that the player could visually tell that they have lost health. It also conveys the amount of time a player is invincible to prevent them continuously receiving damage from the same thing, which would have made the game difficult and not enjoyable.

To allow transparency to be changed by the shader, the following two lines had to be added:
```c#
Tags { "Queue"="Transparent" "RenderType"="Transparent" }
Blend SrcAlpha OneMinusSrcAlpha
```
Resource for this code can be found [here](#resources-used-for-fade-shader).

The fading in and out affect is achieved by a sine function applied to the material's alpha value (value that controls transparency). This allows the transparency to fluctuate between two points at a certain speed over time. 
```c#
if (_On == 1) {
    o.Alpha = 0.4 * sin(2 * _Time.w) + 0.6;
} else {
    o.Alpha = 1;
}
```
To control the affect so it is only visible when the player has lost health, the shader contains a flag variable _On which controls whether or not this affect is visible. The _On variable is accessed and changed in the player's Health.cs script and set to 1 or 0 depending on whether the affect has to be turned off or on.
```c#
chicken.GetComponent<Renderer>().material.SetInteger("_On", 0);
```

**Shader 2: Water Shader**

![ripplegif](https://user-images.githubusercontent.com/80396203/198817078-b570603a-87b4-4f01-9a63-303857a4b919.gif)

This vertex shader was applied to the water material in order to add waves and ripples on collision to the water in the game. This shader effect was chosen because the team wanted the water in the game to be interactive and show when a character has collided with the water. Hence, ripples were added when a character or object collide with the water. The team also wanted the water to behave like water, so waves were also added.

The same two lines of code that allows transparency to be edited in the Fade Shader was added to this shader as well.
```c#
Tags { "Queue"="Transparent" "RenderType"="Transparent" }
Blend SrcAlpha OneMinusSrcAlpha
```

Firstly, all vertices were transformed into world space. This was done because water in the game is just two planes, top and front, that line up with each other and we wanted the planes to move up and down at the same rate so there was no gap between them.

Waves were modelled after Trochoidal waves, which gives waves are more realistic look because it gives sharper crests and flatter troughs like actual waves. Resource found [here](#resources-used-for-water-shader). This required the shader to modify the y-coordinate by a function of sine and the x-coordinate by a function of cosine.

```c#
float4 getWaves(float x) {
    ...
    float waveChangeY = waveAmplitude * sin(f);
    float4 waves = float4(0.0f, waveChangeY, 0.0f, 0.0f);
    waves.x += waveAmplitude * cos(f);
    return waves;
}
```

**Note:** Sine was used for y-coordinate instead of cosine like it normally would be for trochoidal waves because in early stages of the shader there was only a sine function applied to y-coordinate, so it was decided to keep this existing function and modify it to model trochoidal waves.

The ripples were modelled by a sine function with a circle function applied to the x- and z-coordinates inside it. The centre of the ripple is based on where the collision point between the water and whatever fell into it occurred. The ripple amplitude itself decreases over time like a regular ripple would and after a certain distance it disappears all together. These impact values, distance and amplitude are all set by the script CollisionRipple.cs that is applied to the plane and uses the SetInteger() function to manipulate the values inside the shader. This code allows for two different ripple points on one particular plane at one time because there is two variables each for all the variables that are set by the script.

```c#
float4 getCollisionRipples(float x, float z) {
    ...
    float f1 = (pow(x - xOffset1, 2) + pow(z - zOffset1, 2));
    float ripple1 = _RippleAmplitude * sin(_RippleSpeed * _Time.w  + _RippleFrequency * f1);
    ...
    float f2 = (pow(x - xOffset2, 2) + pow(z - zOffset2, 2));
    float ripple2 = _RippleAmplitude * sin(_RippleSpeed * _Time.w  + _RippleFrequency * f2);
    ...
    if (sqrt(pow(x - _ImpactX1, 2) + pow(z - _ImpactZ1, 2)) < _Distance1) {
      ripples += ripple1 * _CharacterWaveAmplitude1;
    }	
    if (sqrt(pow(x - _ImpactX2, 2) + pow(z - _ImpactZ2, 2)) < _Distance2) {
      ripples += ripple2 * _CharacterWaveAmplitude2;
    }
    return ripples;
}
```

-----

### Procedural Generation

We decided to procedurally generate the stalactites in level 3. We wanted to randomise some aspect of the gameplay, whilst still making the game playable. To do so, we randomised the spawning of the stalactites, as well as their sizes and rotations, but we also placed many constraints on the randomised spawning to ensure that the levels maintained a certain level of difficulty. The stalactites are procedurally generated each time the level is loaded/restarted.

Run 1:
![stalactite1](https://user-images.githubusercontent.com/80396203/198815007-04a2b465-46dd-4d66-8c7c-81f9f744013f.PNG)

Run 2:
![stalactite2](https://user-images.githubusercontent.com/80396203/198815038-8ba9f771-5fc2-4dae-a2c7-a95771ed2213.PNG)


To do this, we created gameObjects (we’ll call them stalactite spawners) with a Random Spawner script attached to them. Upon initialising the level, the Random Spawner script calls the SpawnStalactite function a certain number of times as specified by the “attemptedSpawns” field. For example, if attampedSpawns is set to 3, the stalactite spawner will attempt to spawn up to 3 stalactites. 

```c#
void Start()
    {
        int spawnCount = attemptedSpawns;
        while (spawnCount > 0)
        {
            SpawnStalactite();
            spawnCount--;

        }
    }
```

On each call of the SpawnStalactite function, it generates a random position within the stalactite spawner. It then loops through a list of spawns and checks if this random position is within a specified range, “minGap”, of other spawns. For example, if stalactite A was spawned at (3, 0, 0) and this current call of SpawnStalactite generates (2, 0, 0) but “minGap” is 3, it will deem this spawn attempt as failed since the new random position is within 3 units of an already existing spawn position and so the stalactite will not be spawned. 

```c#
spawn = true;
curpos = transform.localPosition + new Vector3(Random.Range(-size.x / 2, size.x / 2), 0, 0);
    for (int i =0; i < spawns.Count; i++)
    {
       if (AbsDiff(curpos.x, spawns[i].x) < minGap)
       {
           spawn = false;
       }
    }
```


If the random position is not within “minGap” units of any previous successful spawns, then the current spawn attempt is deemed successful and a new stalactite will be instantiated at this position with a random scale along the x, y and z axis, and a random rotation along the y axis. The bounds for random scaling along the x, y, and z axis can be specified using a maximum and a minimum for each field. The successful spawn position is then added to the list of spawns.

```c#
if (spawn)
        {
            Vector3 randomisedScale = Vector3.one;
            randomisedScale = new Vector3(Random.Range(xMin, xMax), Random.Range(yMin, yMax), Random.Range(zMin, zMax));
            stalactite.transform.localScale = randomisedScale * globalscaleMulti;
            
            Instantiate(stalactite, curpos, Quaternion.Euler(0f, Random.Range(0f, 360f), 0f));
            spawns.Add(curpos);
        }
```

We then placed these stalactite spawners in areas of the level where we thought stalactites would be appropriate, and adjusted the values of attemptedSpawns and minGap to avoid too many or too few stalactites in these sections, as well as to avoid clusters of stalactites spawning next to each other making it too difficult.

-----

### Particle System

In the game we have used a smoke effect on the fire chicken to give the illusion that it is actually on fire. To simulate the effect of smoke by using a particle system, we have used the smoke material from Unity Asset Store as the renderer. Then, set a reasonable start size and speed for the particles. Instead of using rate over time for the emission, we have used rate over distance and changed the simulation space from local to world, so that the particles emit only when the parent game object moves. This can make objects move with smoke following behind them. We also set the shape to cone to control the range of the particle emitted. Lastly, we changed the colour over lifetime and size of lifetime from small to large to simulate the smoke gradually dispersing after a period of time.

![ezgif-5-654d187244](https://user-images.githubusercontent.com/80396203/198911798-4f1d09bf-7e65-4816-9345-a8617e810bf0.gif)

-----

### Evaluation

Demographic information collection was age, gender and game experience. Game experience was measured with a linear scale to answer the question "How often do you play video games?", where 1 represented "Not at all" and 5 represented "All the time".

**Observational Method**

Observational method used was a post-task walk-through. Had participants play one level at a time, noting down our observations while they played and at the end of each level had discussion about their likes and dislikes for the level, as well as asking them why they did things the way they did them. Data was recorded through handwritten notes and recordings if needed.

Demographics:
* Gender: 4:3 Male to Female Ratio
* Age: Average Age of 21 (18, 20, 21, 22, 22, 23, 24)
* Experience: Average Experience of 3.2 (1, 2, 2, 3, 5, 5, 5)

Feedback:

Users thought the game was relatively easy to use and that the difficulty was not too hard for the game overall. Through observation, it seems as though the game and puzzles are relatively intuitive because hints were understood well and players did not get stuck on a particular puzzle for a long period of time. Overall, players found the game enjoyable and liked the layout, puzzles, characters, story, cut-scenes and design.

However, through conversation and observation, the following bugs and dislikes were found:
* Water was hard to see through at times
* Mushrooms in Level 3 appeared to be floating after desert chicken  broke the ground
* Some of the movement instructions were not clear
* Did not realise had to click through the cut-scenes
* Boss fight too easy for our experienced players and moving platforms having different physics only in this level was confusing
* Less experienced players struggled with the double jump at times
* Rolling egg sometimes was able to get places it should not have been able to
* Controls were not available once they were first introduced
* Users did not always notice when they finished a level
* Sound of game was annoying at times because could not mute it or control the volume
* Having arrows keys as alternative option to WASD keys was confusing
* Desert chicken and duck slow
* Some buttons were hard to press
* Users seemed to forget that they could attack with J

Overall, users enjoyed the game and thought it was easy to use. Small bugs did not seem to have massive impact on game play apart from minor annoyance. By observing users, Free Range appears to be an intuitive game that is not too difficult but too easy at the same time. Changes applied to the game due to this feedback can be found [here](#changes-after-evaluation). 

**Querying Technique**

Querying technique used was a questionnaire implemented as a google form. Most questions were scalar from 1-7 (1 meaning strongly disagree and 7 meaning strongly agree) and we were able to average these values to get an overall score for usability, satisfaction and how easy it was to learn. This scoring system was inspired by the one used in PSSUQ. Questions in the questionnaire were mix of original questions and adapted questions from the questionnaires detailed [here](#resources-used-for-querying).

Demographics:
* Gender: 3:4 Male to Female Ratio
* Age: Average Age of 30 (18, 21, 21, 22, 23, 51, 55)
* Experience: Average Experience of 2.6 (1, 1, 2, 2, 2, 5, 5)

Feedback:

*Scores:*
* Usability: 5.2
* Satisfaction: 6.2
* Ease of Learning: 5.8

All users completed Level 1 but only 5 of the 7 people finished Levels 2 and 3. 

Users tended to most enjoy the story and concept of the game, the graphics, the cast of characters and the distinct elements of each level. They also appreciated how the game allowed room for errors in puzzles as well as the problem solving aspect of the puzzles. Users also found humor in the pun "Free Range".

However, the users discovered a few bugs and other things they did not overly enjoy during game play. These include:
* Movement instructions were not the clearest in places
* Some elements of the game were difficult to see due to water, sand and foreground elements
* Desert chicken and duck were too slow
* There were some holes in the map that the egg could fall through
* Desert chicken and chicken moved around at same time when desert chicken is first collected

Overall, users were satisfied with and enjoyed the game, regardless on the small bugs encountered. According to the scores, Free Range is relatively easy to use and learn even though the average player did not have much game experience. Changes applied to the game due to this feedback can be found [here](#changes-after-evaluation). 

-----

### Changes After Evaluation

Due to the game appearing to be intuitive during observation and no comments to contradict this in the questionnaire, the puzzles, layout and storyline of the game did not change. However, all bugs that were noticed were fixed. The following list details all the changes made after evaluation:
* Desert chicken and duck are no longer slow and are just as fast as other characters
* Dialog boxes that were not being triggered were fixed and order of them was enforced so players cannot accidentally receive them out of order
* Sand in Level 2 was lowered so user could see everything when playing as smaller characters
* Water was difficult to see through so the texture was removed on the front face and front face was made more transparent
* Moved mushrooms off breakable platforms so they do not end up floating
* Include instructions for moving left and right at the very beginning of the game
* Made moving platform in boss fight consistent with the rest of the game and make the boss fight harder
* Have indication that player has to click through the cut-scenes
* Made double jump slightly easier so less experienced players do not struggle as much
* Move foreground elements if they were directly in front of things that the player has to do
* Prevent rolling egg from being able to get through the cacti at the beginning of Level 2
* Make hint for the fire chicken a little more obvious to prevent confusion
* Ensure dialog can only appear in the correct order
* Fireballs are not thrown at chicken until after the player has read the hint for the fire chicken
* Patch over hole in the floor that allowed egg to fall off the map in Level 2
* Have reminders that J can be used for attack
* Explain the controls for the duck swimming because the are not intuitive
* Have indication that player has actually finished the level
* Make sure all platforms are visible and obvious to the player and does not just look like a bump in the wall for Level 3
* Fix hole in wall of water are in Level 3 that duck could swim into
* Fix bug where desert chicken and chicken moved at the same time when desert chicken egg is first collected
* Controls are made accessible through a help menu
* Free fall was a little glitchy, so that has been fixed so it is smooth
* Hard to click button underwater is now easier to click

-----

### Resources 

#### **Resources used for Querying:**

The following questionnaires were adapted for the purposes of this game:
* [USE (Usefulness, Satisfaction, and Ease of Use)](https://garyperlman.com/quest/quest.cgi?form=USE)
* [ASQ (After-Scenario Questionnaire)](https://garyperlman.com/quest/quest.cgi?form=ASQ)
* [QUIS (Questionnaire for User Interaction Satisfaction)](https://garyperlman.com/quest/quest.cgi?form=QUIS)
* [PSSUQ (Post-Study System Usability Questionnaire)](https://uiuxtrend.com/pssuq-post-study-system-usability-questionnaire/)
* [SUS (System Usability Scale)](https://www.usability.gov/how-to-and-tools/methods/system-usability-scale.html)

***Note:** PSSUQ scoring was used to design scoring system used in evaluating the questionnaire for this game.*


#### **Resources used for Fade Shader:**
* [Basic Transparency](https://www.ronja-tutorials.com/post/006-simple-transparency/ )

#### **Resources used for Water Shader:**
* [Trochoidal Waves](https://en.wikipedia.org/wiki/Trochoidal_wave)

#### **Resources used for Procedural Generation:**
* [Adding Gizmos to visualise spawning areas in Unity Editor](https://www.youtube.com/watch?v=kTvBRkPTvRY&ab_channel=Gamad)

#### **Resources used for Artistic Assets:**
* [Mummy](https://assetstore.unity.com/packages/3d/characters/free-mummy-monster-134212)
* [Bricks](https://assetstore.unity.com/packages/2d/textures-materials/stylized-bricks-materials-184484)
* [Poly Desert](https://assetstore.unity.com/packages/3d/environments/landscapes/polydesert-107196)
* [Cross Plains](https://assetstore.unity.com/packages/3d/environments/landscapes/cross-plains-lowpoly-environment-by-unvik-3d-203644)
* [Low Poly Nature Pack](https://assetstore.unity.com/packages/3d/environments/landscapes/low-poly-simple-nature-pack-162153)
* [Low Poly Vegetation Kit](https://assetstore.unity.com/packages/3d/environments/low-poly-free-vegetation-kit-176906)
* [Skybox](https://assetstore.unity.com/packages/vfx/shaders/free-skybox-extended-shader-107400)
* [Chick](https://assetstore.unity.com/packages/3d/characters/animals/meshtint-free-chick-mega-toon-series-152777)
* [Chicken](https://assetstore.unity.com/packages/3d/characters/animals/meshtint-free-chicken-mega-toon-series-151842)
* [Cartoon Water Texture](https://www.vecteezy.com/free-vector/water-texture)
* [2D Bow](https://assetstore.unity.com/packages/2d/textures-materials/2d-bow-is-bow-and-arrow-174003)
* [Desert Kits](https://assetstore.unity.com/packages/3d/environments/landscapes/desert-kits-64-sample-86482)
* [Effect Textures and Prefabs](https://assetstore.unity.com/packages/vfx/particles/effect-textures-and-prefabs-109031)
* [Egyptian Statue of a Male Figure](https://assetstore.unity.com/packages/3d/props/egyptian-statue-of-a-male-figure-208808)
* [Fantasy Skybox](https://assetstore.unity.com/packages/2d/textures-materials/sky/fantasy-skybox-free-18353)
* [Casual Game SFX](https://assetstore.unity.com/packages/audio/sound-fx/free-casual-game-sfx-pack-54116)
* [Stylized Smoke Effects](https://assetstore.unity.com/packages/p/free-stylized-smoke-effects-pack-226406)
* [Low Poly Environment](https://assetstore.unity.com/packages/3d/props/exterior/low-poly-pack-environment-lite-102039)
* [Middle East Music Pack](https://assetstore.unity.com/packages/audio/music/world/middle-east-music-pack-224872)
* [Stylized Lava Material](https://assetstore.unity.com/packages/2d/textures-materials/stylized-lava-materials-180943)
* [Music Used for Level 1](https://www.epidemicsound.com/track/HvsdDIYzfj/)
* [Music Used for Level 3](https://www.epidemicsound.com/track/eU74Hjvg9o/)
* [Music Used for Boss Fight](https://www.epidemicsound.com/track/UHUSjntA6a/)
