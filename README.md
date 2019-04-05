# demo-message-queue
Basic demo of Azure Service Bus in .NET Core API vs Monolithic approach

# Use case:
The demo is based on a simple user registration process where user submit registration details, and the server need to validate, store the new user data to database. 
After that, it will send a welcome email to the user.

For the purpose of this demonstration, we will not do logic of sending email but just do a fake Sleep(3000) assuming the sending email process will take 3 seconds to complete
