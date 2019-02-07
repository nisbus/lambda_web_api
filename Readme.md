# ASP.NET Core Web API Serverless Application for analysing text

This project contains a single Web API controller for doing naive text analysis on any text.

It is currently running on [AWS Lambda](https://n73zynlswe.execute-api.us-east-1.amazonaws.com/Prod/swagger)

The methods on the controller are:

### Sort/\{sortType\} : POST

This sorts the incoming text according to the sort type you give it.  
Available Sort Types are:  
  
* Alphabetical
* Reverse
* Length

All of these methods work by sorting sentences according to the type, except when there is only one sentence.   
Then it sorts the words in the sentence.

### Statistics: POST

This method calculates some statistics on the text given.  
The statistics returned are:  

* Sentence count  
* Word count
* Letter count
* Hyphen count
* Space count




