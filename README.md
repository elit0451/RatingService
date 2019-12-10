# Bookings Rating Service :open_file_folder:
The objective of this project is to develop a software solution implementing _microservices architecture_ using **continuous integration**, **deployment**, **composition**, and **orchestration**. A previously developed system for [booking of cars](https://github.com/elit0451/EIPatterns) is used as part of our business case :oncoming_automobile:. With this repository, we provide expansion for rating any type of services :chart: - in our case we make use of it to collect feedback, regarding the quality of the car booking service. 

</br>

---
## Use case :briefcase:
When a _user_ participates in our anonymous questionnaire they are presented with 2 courses:  
> **1. Mandatory**</br>  &nbsp;&nbsp;&nbsp;&nbsp;- Provide a grade (from 0-10)</br>  &nbsp;&nbsp;&nbsp;&nbsp;- Provide a short description

> **2. Optional**</br>  &nbsp;&nbsp;&nbsp;&nbsp;- Provide country of living</br>  &nbsp;&nbsp;&nbsp;&nbsp;- State gender</br>    &nbsp;&nbsp;&nbsp;&nbsp;- State age

:exclamation:All parameters influence the rate. The intention is to use the collected data for further analysis and predictions :file_cabinet:.

</br>

The _administration_ can pull records using 3 **filters**:
>&nbsp;- average grade</br>&nbsp;- average age</br>&nbsp;- average gender

</br>

---
## Specifics :desktop_computer:
- .Net Core <img src="https://user-images.githubusercontent.com/21998037/70467221-174ca580-1ac5-11ea-94f5-1cda388e1cb8.png" height="18" align="center">
- RabbitMQ <img src="https://user-images.githubusercontent.com/21998037/70467292-351a0a80-1ac5-11ea-9dd2-0e7d078d47a7.jpg" height="18" align="center">
- Docker :whale:
- CircleCI <img src="https://user-images.githubusercontent.com/21998037/70467061-cd63bf80-1ac4-11ea-939a-31cdfb00d399.png" height="18" align="center">
- Digital Ocean <img src="https://user-images.githubusercontent.com/21998037/70467609-d3a66b80-1ac5-11ea-8b0a-441769b9ccf1.png" height="18" align="center">
- Kubernetes <img src="https://user-images.githubusercontent.com/21998037/70467317-42cf9000-1ac5-11ea-9bb0-700b24c9274f.png" height="20" align="center">

</br>

---
## Microservices Architecture :building_construction:

                                             ##         
                                        ## ##        ==
                                     ## ## ## ##    ===
                                  /""""""""""""""\___/ ===
                                 { ~~~~ ~~~ ~~~~ ~~ /  ==
                                  \_____ o       __/
                                    \ __\_______/

	+-------------------+        +-------------------+        +-------------------+
	|                   |        |                   |        |                   |
	|                   |        |                   |        |                   |
	|     A D M I N     |        | C O L L E C T O R |        |    C L I E N T    |
	|      service      |XXXXXXXX|      service      |XXXXXXXX|      service      |
	|                   |        |                   |        |                   |
	|                   |        |                   |        |                   |
	|                   |        |                   |        |                   |
	+-------------------+        +-------------------+        +-------------------+

</br>

We have created 3 services within this project: 

**Client** - This is the main CLI that a customer can interact with. It takes input from the user and using a queue sends the collected information to the _Collector_ service.  

**Collector** - It has an active listener for information coming from the _Client_. Once a questionnaire is completed we normalize the data into the desired format and send it over to the _Admin_ service using socket connection. 

**Admin** - The _Admin_ service is used for querying the registered questionnaires.

</br>

Docker images are created for all of them and deployed to Docker hub - [client](https://hub.docker.com/r/davi7816/si-client), [collector](https://hub.docker.com/r/davi7816/si-collector), [admin](https://hub.docker.com/r/davi7816/si-admin).

</br>

----
## CI/CD :link:
For continuous integration, we use the CircleCI pipeline which will execute commands specified in the [config.yml](https://github.com/elit0451/RatingService/blob/master/.circleci/config.yml) file. The current integration process is getting all the necessary dependencies, building .Net Core source code and building docker images uploaded to docker hub. For the Collector service, we also run a deploy script on a Digital Ocean droplet.

</br>

---
## Orchestration


</br>

---
> #### Assignment made by:   
`David Alves 👨🏻‍💻 ` :octocat: [Github](https://github.com/davi7725) <br />
`Elitsa Marinovska 👩🏻‍💻 ` :octocat: [Github](https://github.com/elit0451) <br />
> Attending "System Integration" course of Software Development bachelor's degree
