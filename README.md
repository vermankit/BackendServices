# Microservice for a urban clap like service provider POC
# Overview Diagram
![NAGP_Assigment_Diagram](https://user-images.githubusercontent.com/17446840/142975748-e7355a2f-9250-4440-8d87-8d88f27f2193.jpg)

## Gateway:
All the services will be communication with gateway and discoverable through
eureka 
Gateway:
### http://localhost:7000/booking
### http://localhost:7000/admin
### http://localhost:7000/partner
### http://localhost:7000/customer
### "Consumer Provider": "http://localhost:5001/api",
### "Notification Provider": "http://localhost:5002/api",
### "Partner Provider": "http://localhost:5003/api",
# "Gateway": http://localhost:7000


As per the given problem following service have been identified:
## 1 - Partner Service:
Partner microservice is responsible for the registering the service provider
,the person who is providing the services to the customer like cleaner, cook
etc. This service will be used to get partner by email and area code.

## 2 -Booking /Admin Service:
Booking Service is responsible for taking booking from the consumer.
Admin can assign the booking to the partner and partner can approve and deny the booking. This service will also communicate to partner and consumer
service for getting the information via HTTP client as sync communication

## 3 -Consumer Service:
Consumer microservice is responsible for maintaining details for the customer
.Booking service will call this service for customer details.

## 4 -Email Notification Service:
This service is responsible for sending notification for partner and customer
This can push message to email server.
Email for partner will contain the details about the partner for customer information.
Email for customer will contain the detail for booking confirmed with partner details.

## Notification Service:
Instead of notification email service we can also use the push notification to client via signal R which could have been one more solution.

