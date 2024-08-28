# Nokotan's Antlers Won't Stop Growing, So Let's Play a Game on a Binary Tree!

First of all, it should be relatively easy to see a dynamic programming strategy, where in each node you store an array of possible values of that subtree, and you combine the two children at every node into the parent to transition. The answer would just be the size of the array at the root.

How long would that take? Transitioning into a certain node trivially would take `O(s^2)` time where `s` is the size of the subtree, so our total time would take the sum of `2^i * (2^(d - i))^2` time every depth `i` within the tree (I'm realizing this would look a lot better in LaTeX).

We can simplify the summation to `2^d * 2^(d - i)`, and then we can factor out the `2^d` (which is around `n`). Then, we are basically summing `2` raised to the power of every depth, which will also sum to around `2^d = n`. Thus, our sum resolves to `O(n^2)` for time complexity. Too slow!

One can notice that transitions are equivalent to multiplying polynomials, which we can do in `O(n log n)` time instead of `O(n^2)`. With our earlier math, this would reduce our time complexity down to around `O(n log n)`, which is theoretically fast enough. However, I tried to cut these solutions off with the time limit ><

## Faster!

How do we improve this? We can use the fact that it's a complete binary tree! At each level, we need to do at most 2 separate transitions - one for the node the encompasses a possible leaf depth change (since the bottom level is not necessarily full), and the other where the subtree is a full binary tree.
