# CQRS_MEDIATR
İ used cqrs and mediatr design patterns.
CQRS stands for 
command query responsibility segregation.
We use this design pattern to seperate
write and read database operations.
Mediatr is used to connect services,
also prevent code mixing in controller.
There are two approaches in mediatr:
1-Request/Response
2-Notification
I used first approach in my code,
i get requests to my controllers,then
i send this request with the help of 
mediatr to handlers,handlers give me 
a response,and we get this response 
in controller.With the help of mediatr
and cqrs we got rid of fat controllers and
code confusion.
