# Mastermind

## Game Rules

The `code maker` secretly selects 4 pegs.  Each peg can be one of 6 possible colours.  Duplicates are allowed.  For example
    
    Red Red Yellow Blue

The `code breaker` then attempts to guess the colours of the four pegs.   For example they might guess

    Red Blue Yellow Black


The code maker then scores the guess.  Counting the number of pegs which are the correct colour in the correct location,  and the number of pegs which are the correct colour but in the wrong position.

Using the above examples

    The first peg guessed 'Red' is the correct colour and in the correct position.  
    The second peg guessed 'Blue' is the correct colour but in the wrong position.
    The third peg guessed 'Yellow' is the correct colour and in the correct position.
    The final peg is wrong.

The score would be:

    Correct = 2
    Wrong Position = 1

Based on this new knowledge,  the `code breaker` has another guess.  

The game ends when either the code breaker correctly guesses the code or has taken too many attempts

There is an online game here
http://www.webgamesonline.com/mastermind/


## Exercises (All)

### 1a. Create Secret Code 
Write a function for the code maker which picks 4 random colours to use as the pegs.

### 1b. Scoring Function 
Write a function which given a secret code and a guess returns it's score.  The score consists of two parts
1.  The number of correct pegs  (also known as the `colour` score)
2.  The number of correct colours but in the wrong position.  (also known as the `white` score)


## Exercises (Code Makers)

### 2a. Display Pegs (Graphical)
Create a user interface for the game, this could be either some simple ASCII art or something more advanced.


### 2b. Game
Combine your solutions for exercises 1a,  1b and 2a to create a game where you play against the computer.  
The computer taking the role of the code maker.


## Exercises (Code Breakers) - Harder!

### 3a. Generate Combinations  (Step 1 in Knuth's algorithm)
Write a function which returns a set of all possible guesses. 
There are 4 pegs,  and each peg can be of one of 6 possible colours.  
This means that you should end up with 6 * 6 * 6 * 6 = (6^4) = 1296 possible values.
(We call this set of combinations `S`)

### 3b. Eliminate Invalid Combinations  (Step 5 in Knuth's algorithm)
Write a function which given a set of combinations (S) and a guess (G) and a score (s) returns a new set which only contains combinations where:
* guessing that combination would return the same score (s) if the guess (G) was the actual code.

For example

    If the code was Red Red Yellow Blue
    If the guess (g) was Red Blue Yellow Black
    So the score (s) was 2/1

    The combination  `Red Red Red Red` scored against the guess (g) `Red Blue Yellow Black` would have a score of 1/0 and so would be removed.

    The combination  `Red Red Yellow Blue` scored against the guess (g)  `Red Blue Yellow Black` would have a score of 2/1 and so would be kept.

    The combination  `Red Blue Yellow Blue` scored against the guess (g)  `Red Blue Yellow Black` would have a score of 3/1 and so would be removed.


### 3c Guessing
For your next guess,  pick one of the remaining combinations in S at random.

#### 3d Game
Combine your solutions for the exercises 1a,  1b, 3a, 3b and 3c to create a game where you play against the computer.  
The computer taking the role of the code breaker.

### 3e. Min-Max.   (Step 6 in Knuth's algorithm)
This is the tricky bit! In step 3c we picked a guess at random but we can do better by trying to pick the combination which will tell us the most information.

* For each possible guess, that is, any unused code of the 1296 not just those in S, 
calculate how many possibilities in S would be eliminated for each possible colored/white peg score. 

Possible scores are:
```
0/0 0/1 0/2 0/3 0/4
1/0 1/1 1/2 1/3
2/0 2/1 2/2 
3/0
4/0
```

* The score of a guess is the minimum number of possibilities it might eliminate from S. 

* A single pass through S for each unused code of the 1296 will provide a hit count for each colored/white peg score found; 
the colored/white peg score with the highest hit count will eliminate the fewest possibilities; 
calculate the score of a guess by using "minimum eliminated" = "count of elements in S" - (minus) "highest hit count". 

* From the set of guesses with the maximum score, select one as the next guess, choosing a member of S whenever possible.






## References

https://en.wikipedia.org/wiki/Mastermind_(board_game)

https://github.com/nattydredd/Mastermind-Five-Guess-Algorithm
