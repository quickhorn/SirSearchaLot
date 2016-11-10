## Synopsis

SirSearchALot provides a simple web interface for person management and search functionality. The project uses Dependency Injection to provide easy separation of concerns. The persistence layer is developed using the UnitOfWork and Repository patterns. The web application uses MVC, with an MVVM front end using Knockout.js. Display of the site is developed using Bootstrap.

## Features

The person management and search functionality are separated into two separate services. Currently, both services are implemented in the same solution as class libraries. Both could be pulled into RESTful microservices with ease. This would allow scaling of the search service without having to also scale the management service (where one is more likely to be used more often and more resource intensive than the other).

The persistence layer is using a LocalDb, but an Azure database has been set up as well. If you're interested in seeing the Azure database at work, modify the SirSearchALot.Persistence.SearchALotEF.cs class and remove the indicated comment. (Note, this hasn't been as thoroughly tested as the localdb)

Unit tests. Some minor unit tests for checking the adding of people has been added. You can find these tests in the SearchALot.Tests project.

## New Technologies

My favorite part of technical tests is learning new things. However, sometimes the learning of those things doesn't allow for a fully featured application, as time is spent researching and trying new things. One of those new things was the file upload. This particular feature ended up taking more time than I had intended, but ended up being incredibly satisfying to see it work.

## Shortcomings

My UI design skills are not incredible. I had hoped to spend more time on the UI, but ran short. The UI failures include poor error handling for the user. This is currently done with alerts, and really should take advantage of the Bootstrap errors.

The MVVM framework is using Knockout.js. I actually really like this framework, but I also understand it is not as popular as other front-end MVVM frameworks. However, I still find ANY MVVM framework is better than relying solely on event-driven UIs.

The application does not currently log issues.

The application doesn't account for searching by both a first AND last name. The requirements did not make this necessary, but I feel is something that could be improved. 

## Thanks

Thank you for taking the time to read through this, and to look at my project. I hope you enjoy it as much as I enjoyed making it.