# ad-infinitum-week1
First week of the Ad Infinitum Game Jam.

# Game Idea: Unfair Tetris (Gravity & Physics)
This is tetris like you never played before, It has real world physics! Blocks have weights, velocities, there is gravity, friction and more.
Have fun!

# Problems I faced (with solutions):

# Mechanics and more:
The game has 2 modes (story and arcade)
In story you go against the game's AI which gets progressivelly less fair. Giving you skewed blocks, extra gravity, sticky blocks, wierd block turning and more!
Arcade mode is a glorified randomizer, you get some random attributes of the game for your personal enjoyment!

Blocks are created by combining multiple 1x1x1 cubes with fixed joints.
This way we can break them up or let them stick like we want to, it also makes collisions a bit better.

Since there is a gridless mode we need to have a definition of ( is this line full? ) This is done with a checker that raycasts every 1 unit up the board, calculates how many blocks are in this obe line and determines based on that count if the line is full or not.

