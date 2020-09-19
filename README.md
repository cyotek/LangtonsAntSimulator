# Langton's ant simulator

![The running simulation][6]

This is my second implementation of a Langton's ant simulator,
this time written in C#. I wrote it in 2011 for a [C# Helper
contest][5].

## About Langton's ant

Langton's ant is a two-dimensional universal Turing machine with
a very simple set of rules but complex emergent behavior.

Squares on a plane are colored variously either black or white.
We arbitrarily identify one square as the "ant". The ant can
travel in any of the four cardinal directions at each step it
takes. The "ant" moves according to the rules below:

* At a white square, turn 90° clockwise, flip the color of the
  square, move forward one unit
* At a black square, turn 90° counter-clockwise, flip the color
  of the square, move forward one unit

(Paraphrased from the [Wikipedia][1] page)

## About the code

I haven't looked at this code in years, but I remember that I
_horribly_ over-engineered the thing originally. Interfaces
everywhere!

However, I fired it up to take the screenshot at the top of this
document and it still works perfectly fine.

![Simulation of twenty ants after 4000 moves][3]

![Simulation of twenty ants after 15000 moves][4]

## Acknowledgements

* Rod Stephens of [C# Helper][8] for the idea in the first place
  (although I'm almost certain this is the second Langton's ant
  simulator I made, I'm sure I did one in Visual Basic 6,
  probably also for a Rod Stephens competition!)
* The ant icon used by the program by [Martin Berube][7]
* [Yusuke Kamiyamane's][8] Fugue Icons

[1]: https://en.wikipedia.org/wiki/Langton's_ant
[2]: 1%20ant%20move%2015000.png
[3]: 20%20ants%20move%204000.png
[4]: 20%20ants%20move%2015000.png
[5]: http://csharphelper.com/blog/2011/02/contest-langtons-ant-simulation/
[6]: simulation11000.png
[7]: http://www.iconarchive.com/show/animal-icons-by-martin-berube/ant-icon.html
[8]: http://p.yusukekamiyamane.com/
