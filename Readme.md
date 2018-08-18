<p>This is a Code puzzle for a Company interview process.

A natural speech shape building application, it will take in 
natural english and in turn build the desired shape.
An Example would be <i>"Draw a Rectangle with the width of 34 and a height of 322."</i>
Its main purpose is to show problem solving skills from a written description
General C# syntax and code princepals.
Class's so far: 
<ul>
<li>ShapeDrawerPageViewModel - main View model owns the below view models in some way,</li>
<li>ShapeDrawerViewModel - will rename to differ from above name. Will Draw the shape entered on front end by user,</li>
<li>TextInputViewModel -  Handles the text input from user front end, splits string, checks for keywords and process and pass to shape drawerer,</li>
<li>ShapesModel - properties for shapes, override creation of shapes from base shape to specific Ellipse, Rectangle, Polygon</li>
<li>ObservableObject - uttil class for UI updates, NotifyPropertyChanged Sub Class.</li>
</ul>
</p>


