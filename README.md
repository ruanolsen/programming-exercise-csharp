
## About the project:

#### Author: Ruan Olsen

---

- I did my own version of an N-layered architecture (https://learn.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/common-web-application-architectures#traditional-n-layer-architecture-applications):
  - The Presentation folder contains the user interface and most of the input validations
  - The Controller folder contains the business rules and some validations/confirmations on methods that needed them
  - The Service folder contains what would be the CRUD and DB operations (not needed in this test, as the values are stored in memory)
  - The Interfaces, Models, Exceptions, etc. Are also in separate folders, so they can be easily imported when needed
  

- The **Inheritance** requirement was done in the Exceptions folder. The custom exceptions inherit from the BaseException


- 5 Unit tests are included, they are inside a dedicated folder (but in the same project/solution). To run the tests you can type the following command:
`dotnet test`


- Other relevant comments are within the code


- This project was done using **JetBrains Rider IDE**, there may be some differences when running in visual studio

---
### Thank you for your time reading this file. Have a great day!