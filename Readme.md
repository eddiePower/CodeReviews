<p>This is a Code puzzle for the Company Jey Labs in Melbourne Australia.
It is part of the interview process for new Software Engineers and should not be representative
of the company or of the work they do.
This is My early development of a natural speach shape building application, it will take in 
natural english and in turn build the desired shape.
A Example would be <i>"Draw a Rectangle with the width of 34 and a height of 322."</i>
Class's so far:
<ul>
<li>ShapeDrawerPageViewModel - main View model owns the below view models in some way,</li>
<li>ShapeDrawerViewModel - will rename to differ from above name. Will Draw the shape entered on front end by user,</li>
<li>TextInputViewModel -  Handles the text input from user front end, splits string, checks for keywords and process and pass to shape drawerer,</li>
<li>ShapesModel - Holds the enums of keywords, shapes etc - may not be needed.</li>
<li>ObservableObject - uttil class for UI updates, NotifyPropertyChanged Sub Class.</li>
</ul>
</p>


