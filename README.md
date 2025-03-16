## Local launch

1. Clone the repository

    ```bash
    $ git clone https://github.com/Shrigorevich/mars-api.git
    ```
2. Open the `appsettings.Development.json` file and set corresponding `ConnectionString`
3. Run the application under the `develop` profile via the IDE
4. API can be accessible through the swagger: `http://localhost:3000/swagger`
5. By default, the server only allows requests from the following host: `http://localhost:4000`. <br>
Adjust the `AllowedHosts` property if you run the client on another port.


