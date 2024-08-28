import python

language[monotonicAggregates]
int dcount(Function f) {
  result =
    sum(IntegerLiteral i | f.contains(i) | i.getValue()) +
      sum(Call c, Function fn |
        c.getFunc().(Name).toString() = fn.getName() and f.contains(c)
      |
        dcount(fn)
      )
}

from Function f
where
  f.getName().prefix(6) = "entry_" and
  dcount(f) = 42
select f.getName(), dcount(f)
