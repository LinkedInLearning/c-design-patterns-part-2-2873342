# C#: Design Patterns Part 2
This is the repository for the LinkedIn Learning course C#: Design Patterns Part 2. The full course is available from [LinkedIn Learning][lil-course-url].

![C#: Design Patterns Part 2][lil-thumbnail-url] 
Design patterns in C# can save you a lot of time, as you don’t have to recreate code that has already been proven. In this course, instructor Richard Goforth explains what design patterns are and how you can recognize and implement five C# patterns: Observer, Builder, Command, Proxy, and Chain of Responsibility. For each pattern, Richard gives a definition, at least one example of how to implement or use it, any other explanations you may need, and a practice challenge. He concludes with some suggestions on where to continue your education in C# application design with patterns.

## Instructions
This repository has branches for each of the videos in the course. You can use the branch pop up menu in github to switch to a specific branch and take a look at the course at that stage, or you can add `/tree/BRANCH_NAME` to the URL to go to the branch you want to access.

There are several applicaitons in this repository.  Carried from the first part of the course are simple console examples in the folders Iterator, Adapter, and Factory.  There are similar folders for the patterns covered in this course, Observer, Builder, Command, Proxy, and ChainOfResponsibility. 

Another application, HPlusSports, is a sample of a more robust web application in ASP.Net core, to give a different example of using each of the patterns in a more realistic situation.  It is more complex than an application of similar functionality would be to show examples of architecture in a more fully featured, long term support application.
The web application is using an EF Core Backend to a SQLite Database file, to simplify running the application locally.

## Branches
The branches are structured to correspond to the videos in the course. The naming convention is `CHAPTER#_MOVIE#`. As an example, the branch named `02_03` corresponds to the second chapter and the third video in that chapter. 
Some branches will have a beginning and an end state. These are marked with the letters `b` for "beginning" and `e` for "end". The `b` branch contains the code as it is at the beginning of the movie. The `e` branch contains the code as it is at the end of the movie. The `main` branch holds the final state of the code when in the course.

When switching from one exercise files branch to the next after making changes to the files, you may get a message like this:

    error: Your local changes to the following files would be overwritten by checkout:        [files]
    Please commit your changes or stash them before you switch branches.
    Aborting

To resolve this issue:
	
    Add changes to git using this command: git add .
	Commit changes using this command: git commit -m "some message"

### Instructor

**Richard Goforth**

__Software Architect and Consultant__

Check out my other courses on [LinkedIn Learning](https://www.linkedin.com/learning/instructors/richard-goforth?u=104).

[lil-course-url]: https://www.linkedin.com/learning/c-sharp-design-patterns-part-2-8579116
[lil-thumbnail-url]: https://cdn.lynda.com/course/2873342/2873342-1618509675364-16x9.jpg
