# Flopify 🎵
(flop-ify)
Do you listen to the top 100 songs on iTUNES or the radio? Have you ever heard of those non-popular songs? This repo was created to provide listeners with a finer appreciation of quality music by giving them the worst.
This repository is the back-end API of a music streaming site. Only this repo creates music for listeners where Bands, Albums and Tracks are disliked the most, hence music that flopped. 

Installation
Create a repository folder. Pull down the repo in your own folder. You can run the program by opening up the solution in Visual Studio.

Installation
Create a repository folder. Pull down the repo in your own folder. You can run the program by opening up the solution in Visual Studio. 

How to Use the Project
Once you open the project in Visual Studio, run the project. You should have a site opened looking something like this “https://localhost:00000”. You may run the project in Postman or Swagger. 

Using the Project in Swagger
Open SwaggerUI by adding “/swagger” to the end of the http link. 
In order to use the project methods you need to register an Account and receive a Token to authorize the requests. 

Click on the Account tab. Go to POST Flopify/Account/Register. Under value, include your email and password. Once registered with your email and password, get a token. Go to Auth tab and open POST Flopify/token. Grant-type value is password and include your email and password you used to register. Keep that token handy as you will need it to authorize the requests. 
Once your account is registered, you may authorize requests for Band, Album, and Track.
Follow the descriptions for each of the Rest Methods; Post, Get, Put, Delete for the entities of each music type. Each of the methods give you a description of what it does and a description of what is needed.
 
Contribution
XML programming language was used in contribution to Swagger UI. When you run the project in Swagger it specifically shows you what each RestAPI Method is doing. 
Postman was also a contributor to the project. If you prefer the use of postman, please do so. 


Credits
Emina Palamarevic 
Abrame Pithey

License
This project is in correspondence with MIT License.

Copyright (c) .NET Foundation and Contributors

All rights reserved.

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
