# Search-Functionality
Implemented search functionality using ASP.Net MVC

**Search Form:** The view displays a search form that allows users to search for products based on various criteria. The search criteria include Product Name, Size, Price, Manufacture Date, and Category. Users can enter values in one or more of these fields to filter the product list.

**Clear Button:** The view includes a "Clear" button that allows users to reset the search criteria and display all products.

**Search Results Table:** Below the search form, there is an HTML table that displays the search results. The table headers include columns for Product ID, Product Name, Size, Price, Manufacture Date, and Category. Initially, when the page is loaded, this table will display all records.

**Search Functionality:** When users submit the search form by clicking the "Search" button, the controller's Search action is invoked via a POST request. The controller processes the search criteria entered by the user and uses them to query a database (presumably, based on your provided code). The search results (matching products) are retrieved and displayed in the HTML table. Users can see the filtered products that meet the specified criteria.

**Database Interaction:** The controller uses ADO.NET to interact with the database. It executes a stored procedure (SearchProducts) to fetch the matching products.

**Styling:** CSS styles have been applied to the HTML table to make it visually appealing and user-friendly. The table has alternating row colors on hover for better readability.

**Initial Load:** When the page is first loaded, the table will initially will display all records. If no search criteria are provided (i.e., all fields are empty), the "Search" action may load all products from the database and display them in the table by default.

In summary, this functionality allows users to search for products based on specific criteria, view the results in a styled table, and clear the search criteria to see all products. It's a basic search feature commonly used in e-commerce and database-driven web applications.
