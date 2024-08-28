# Miku vs. Machine (MvM)

It might be tempting to start this problem off by trying to create a subproblem from the original problem, where you try to assign stage time to all the singers at relatively the same rate as you progress through the shows. I think I have an old solution that does this, but there is absolutely 0 need to do so even if it does work.

First of all, to simply the problem, we should assign a value to `l`, so we have something tangible to work with.

Immediately, it's very easy to assign `l = n`, because we need to split the total concert time evenly between all `n` singers. If `l = n`, that means the total stage time during the concert is `l * m = n * m`, and dividing that time evenly among `n` singers results in `m` stage time per singer.

Back to the problem, we're already guaranteed that `m >= n`, which means that assigning stage time can be done as trivially as giving the first `m` minutes of the concert to the first singer, the next `m` minutes to the next, and so on. Because `m >= n`, that guarantees that we'll never have to split one individual show more than once. Thus, this strategy will always work.

Bonus: For which `m < n` can you still do the same assignments?
