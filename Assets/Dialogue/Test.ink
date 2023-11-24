VAR interactions = 0

{interactions:
-0: -> FIRST_INTERACTION
-1: -> SECOND_INTERACTION
-else: -> OTHER_INTERACTIONS
}

===FIRST_INTERACTION===
This is a test
Testy test test
This was a test
->STOP

===SECOND_INTERACTION===
This is a test 2
second is the best
This was a test
->STOP

===OTHER_INTERACTIONS===
Stop testing!
It's annoying
This was a test
->STOP

===STOP===
->END