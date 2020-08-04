<h1>Video Rental Service</h1>

*A simple web application geared towards Backend Staff operations in a physical movie rental store, while granting anonymous visitors to the website a chance
to view all the movies the store has to offer and submit an enquiry where necessary.*

*This project was created as part of learning a tutorial on ASP.NET Framework MVC development and subsequently adding in my own features I deemed useful to have.*

Conceptual Video Rental Staff Backend Web Application which features:
* Creation of Customers in the Retail Rental Store
* Creation of Movie Products to track stock and rentals
* Creation of Rental Entries to associate a Customer with a Movie rented
* Enquiry Manager to allow anonymous users to submit enquiries

Development Platform & Languages:
* ASP.NET Framework 4.7.2 MVC
* Entity Framework Focused
* RESTful API Included
* C#
* CSHTML
* Javascript
* AJAX

External Plugins Used:
* AutoMapper
* Datatable.JS
* Twitter Typeahead.JS
* Toastr.JS
* Bootbox.JS

<h2>Current Features</h2>

**<h3>Internal Staff Module:</h3>**
  * Customers:
    * Add Customer
    * Edit Customer
    * Delete Customer
    * View all added Customers
    * View Customer Details
    
  * Movies:
    * Add Movie
    * Edit Movie
    * Delete Movie
    * View all Movies
    
  * Rentals:
    * Add Rental:
      * Link existing customer to existing movie
    * Return Rental:
      * Unlink existing customer to movie and adjust movie availability
    * View all existing unreturned rentals
      
  * Enquiry Manager:
    * View all unresolved Enquiries
    * Mark enquiries as resolved: 
      * (On Assumption that Staff views anonymous enquiries and communicates with them via Email)
      
**<h3>Anonymous Visitor Module:</h3>**
  * Movies:
    * View all Movies & Availability
    
  * Enquiries:
    * Submit an Enquiry
      
