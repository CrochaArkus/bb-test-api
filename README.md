# bb-test-api
# Steps to run back end
1 - Have SQL server installed
        * To install SQL server, go to the following link https://www.microsoft.com/es-mx/sql-server/sql-server-downloads 
        * at the bottom of download sql express.
        * At the end of the installation a message appears to install SQL MAGNAMENT.
        * Download and follow the steps.

2.-  Have visual studio 2022 installed
        * To install you must follow the following page https://visualstudio.microsoft.com/es/vs/
        * click on download community.
        * execute program.
        * Select ASP.NET and web development, Azure development, Node.js development, :NET desktop development, Desktop development with C++, Development of the Universal Windows Platform, data storage and procedures, Development of extensions visual study and follow and follow steps.
3.- Have git installed
4.- Download bb-test-api repository url from gitHub https://github.com/CrochaArkus/bb-test-api
5.- Open the project and see if it has a migration in the Model / Migration folder, if it does not have a migration open the console and run the command Add-Migration Name for the migration.
6.- Open the Appsetting that is in the API folder within the api project called Challenge.API.
7.- In the Appsetting modify the connections in ConnectionStrings ChallengeConnection.
        * In Data Source= [Your database connection]
        * Initial Catalog = BB_Challenge_DEV_03 (do not modify)
        * Trusted_Connection=True (do not modify)
        * MultipleActiveResultSets=True (do not modify)
8.- Run with F5 and the swagger should be displayed.
