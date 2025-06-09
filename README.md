SSE is a pretty cool feature I stumbled upon scrolling through youtube and seeing the clickbaity: 'Coolest New Feature in C# 10' title.
It's not a new feature. It was hacky supported in 2.1 in 2018, and recieved some love and attention in .net core 3.0.
The changes introduced in 10 are pretty significant, natively supporting returning ServerSentEvents through TypedResults.

* shows example of implementation *

Now doing all of this is fine, but how do you handle this on the FE. That's Peter's problem. Thanks. Kidding... Super easy actually,
in javascript, you use the EventSource.
First you create an event source on your endpoint, like so:

const eventSource = new EventSource("/sse-demo");

you then add an event listener like so:

eventSource.addEventListener("mock-data", event => () {
  // do something with the event
});
