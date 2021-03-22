# Umbraco-Acme-Corporation
The is the homework task set by umbraco
/////////////////////////////////////////////////////////////////////////////////////
Database
/////////////////////////////////////////////////////////////////////////////////////
Umbraco 8 Website built in VS with SQL DB
SQL DB.bak and script is in /DB folder

Restore DB and us the following connection string:
<add name="umbracoDbDSN" connectionString="Server=MSI;Database=Acme_Corporation;Integrated Security=true" providerName="System.Data.SqlClient" />
/////////////////////////////////////////////////////////////////////////////////////
SMTP and Email
/////////////////////////////////////////////////////////////////////////////////////
SMTP settings addded for ease of use with emails.
Temp server setup as well as local dump string, comment either and run preffered (emails can taker a few minutes to come):
      <smtp from="acme@corporation.com">
        <network enableSsl="true" host="smtp-relay.sendinblue.com" port="587" userName="jabbaaah@hotmail.com" password="nFh6A3dTX4CaMO2D" />
        <specifiedPickupDirectory pickupDirectoryLocation="C:\Repo\Personal\Umbraco_Acme_Corporation\Acme_Coporation\Acme_Coporation\src\emails" />
      </smtp>

      <!--<smtp deliveryMethod="SpecifiedPickupDirectory" from="acme@corporation.com">
          <specifiedPickupDirectory pickupDirectoryLocation="C:\Repo\Personal\Umbraco_Acme_Corporation\Acme_Coporation\Acme_Coporation\src\emails" />
      </smtp>-->

Products "Buy now" button will fire controller to "purchase" a product and email the user the serial number for competition


/////////////////////////////////////////////////////////////////////////////////////
Endpoints
/////////////////////////////////////////////////////////////////////////////////////
Create Products end point will load a json file of products with serial numbers 
and insert them into Umbnraco. 100 products already pre loaded. File location /src/json_files/products.json
https://localhost:44357/umbraco/surface/ProductCreate/CreateProducts

Competition form end point will take a valid form submission and post data via AJAX at controller:
\Acme_Corporation_Core\App_Code\Controllers\CompetitionFormController.cs
https://localhost:44357/umbraco/api/CompetitionForm/competitionformsubmit

Products Purchase endpoint will take the users "Buy now" action and fire that data at controller:
\Acme_Corporation_Core\App_Code\Controllers\ProductsPurchaseFormController.cs populating an email and firing via the
send email service at the SMTP setup above.
https://localhost:44357/umbraco/api/ProductsPurchaseForm/ProductsPurchaseFormSubmit

/////////////////////////////////////////////////////////////////////////////////////
Members
/////////////////////////////////////////////////////////////////////////////////////
Login screen will login a valid member
Register button will allow the user to create and login as a "member" type.
Admin Members need to be created via CMS backend and from type Admin Member.

Once logged in, certain areas are only for viewing by Admin member types. ie. Form entries and Product Serial Numbers Pages

Admin user: admin@acme.com password: Password@123
Normal User: mike@acme.com Password: Password@123

/////////////////////////////////////////////////////////////////////////////////////
Users for Backend
/////////////////////////////////////////////////////////////////////////////////////
Backend User : admin@acme.com Password: Password@123

/////////////////////////////////////////////////////////////////////////////////////
NPM, SASS and JS compiler
/////////////////////////////////////////////////////////////////////////////////////
DIR to ruin command from:
C:\Repo\Personal\Umbraco_Acme_Corporation\Acme_Coporation\Acme_Coporation

npm install to install node_modules

'npm run dev' to begin compiling