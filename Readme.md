<p>This is a Code puzzle for a Company interview process.

<h4>The Problem:</h4>  
Write a program that lets the user generate a shape with the dimensions of their choosing using a semi-natural language interface. Your solution must have two components – a “front-end” and a “back-end”.  
User Story  
As a user I want to generate shapes with natural language so that I don’t have to enter values in boxes  
Acceptance Criteria  
The user should specify what to draw using natural language. To keep things simple, we’ll fix the allowed format to the following:  
Draw a(n) <shape> with a(n) <measurement> of <amount> (and a(n) <measurement> of <amount>) 

<h4>Program Description:</h4>
A natural language shape building application, it will take in natural english and build the desired shape. An Example would be <i>"Draw a Rectangle with the width of 34 and a height of 322."</i> 
Its main purpose is to show problem solving skills from a written description General C# syntax and code principals. 

Shapes Supported in this version:
<ul>
<li>Rectangle, width x height</li>
<li>Square, width x height</li>
<li>Circle, width x height</li>
<li>Oval, width x height</li>
<li>Triangle,  width x height</li>
</ul>

Class's so far:
<ul>
<li>ShapeDrawerPageViewModel - main View model owns the below view models in some way,</li>
<li>ShapeDrawerViewModel - will rename to differ from above name. Will Draw the shape entered on front end by user,</li>
<li>TextInputViewModel - Handles the text input from user front end, splits string, checks for keywords and process and pass to shape drawer,</li>
<li>ShapesModel - properties for shapes, override creation of shapes from base shape to specific Ellipse, Rectangle, Polygon</li>
<li>ObservableObject - uttil class for UI updates, NotifyPropertyChanged Sub Class.</li>
</ul>
</p>


