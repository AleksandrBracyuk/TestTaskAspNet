# TestTaskAspNet
тестовое задание на ASP.Net

Как запустить и посмотреть - см. https://youtu.be/KvJBSj1lmQM

Примечание:
В данной реализации возвращаемые данные не соответствуют описанному в задании:
"id" - в задании имеет тип string - реализован как int,
"computerNane" - переименовано в "computerName"

========================

Description: 
Application for sending states of disk C:\ from script to the Web Service with 30 seconds interval. 

Web Service – REST service, you can create simple service with ASP.NET or use mockapi.io. 

As result of implementation, application should send to the Web Service each 30 seconds name of the PC, Update Date and Time in UTC, free space on the disk C. 

We expecting from you that you will share source code and prove that states was stored on Web Service, link with data or video. 

Outcome data: 
Expected format – JSON, example is below. 
{ 
"id": "1",
"updateTimestamp": "2018-12-12T16:49:38.1559485Z", 
"computerNane": "Computer1",
"diskCfreeSpace": 15847.019531 
} 

Important information for implementation 
1. Be careful with naming of variables. 
2. Get current date and time in UTC format 
string.Format("{0:O}", DateTime.Now.ToUniversalTime()); 
3. Better to use RestSharp library for executing web requests. 
4. Script for selecting free space for Power Shell 
(Get-PSDrive C | Select-Object Free).Free / (1024 * 1024)
