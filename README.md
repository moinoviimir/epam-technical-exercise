# epam-technical-exercise
The solution to a technical exercise task kindly provided by EPAM

I believe some kind of comment is due concerning the decisions I made while doing this exercise.
The more important part of the process was determining the exact service boundaries: because the acceptance criteria is somewhat vague, I had to make judgement calls on questions that would otherwise probably be solved by a domain expert. The calls I made are as follows:
- I did not go for word forms: "cat" and "cats" are different words as per my solution, and will be counted separately. The reason for this is that pluralizing words is hard and requires a separate library because of words like "mouse" or many many others;
- neither did I account for shortened forms of the verb "to be": a "it's" is not treated as "it is" by the solution. The reasoning, again, is because treating this behaviour as a requirement would, in turn, make all different shortable tenses of the verb be eligible for the same treatment, and that's already going rather far. All in all, I refrained from doing any linguistics, seeing it as something far outside the scope of the exercise.
- The sentence is presumed to be just that, a somewhat regular sentence. That means that it's size is believed to easily fit into a string (although there are entire stories written in a single sentence, the aim of this task was declared as helping the author not repeat themselves, which seems to disqualify this use case) without any chunk-reading or less straightforward storage techniques needed.
- This really is a judgement call only, but I assumed that words in the sentence would not contain punctuation marks within them; I realize that some domains would invalidate that call, but the more prominent ones (programming books, math books etc) would probably find their way into the acceptance criteria should they have been targeted by the exercise.


I also made some architectural calls that I will briefly outline should my line of thinking pose interest to the respected reviewers:
- I did not follow the "D" principle of SOLID because of how few entities were involved in actually solving the task. There are thus no interfaces. I struggled with this decision a bit, but ultimately decided that, in the spirit of TDD, the added complexity was unnecessary.
- Neither did I abstract away some of the creation logic into a Factory because, again, it was largely unnecessary given the size of the project. This kind of separation would be one of the first refactoring targets if the exercise were to get upgraded to, for instance, support reading files, though.
- The API provided by the app is about as unsophisticated as they get; the choice of instantiatable objects instead of static methods was made due to the wording of the acceptance criteria: creating a new object to consume the sentence seems to fit intuitively.
- I've done no performance optimization, because sentences are mostly short enough that it's pretty hard to screw up performance.
