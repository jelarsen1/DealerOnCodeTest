# DealerOnCodeTest
Problem 2 Solution to the DealerOn Code Test.

I put the solution up on Azure as a web app.  This seemed like the easiest way to enter the input.

https://dealeroncodingtest.azurewebsites.net/

  I decided to make a very simple web app for input/output.  It's just a text box that allows users to enter the text and the output is displayed below it.  I had to make a few assumptions.  The input in the examples seemed like all string objects. Not all of them had a new line separating the line items, so I used Regex to extract the details, since they all followed the same format of {qty} {item desc} at {money value}.  This will run into an issue if an item description has exactly "at {money value}" in it.  Another assumption that I had to make was what items are conisdered books, food, and medical products.  There wasn't a reference other than the example imputs, so I just used what was in the examples.  In a real world application, I'd imagine that actual objects with the necessary attributes would be passed in, rather than string objects.  Or there'd be a database with all of the items to query.
