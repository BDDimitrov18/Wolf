# Wolf

Multi-user real-time workflow managament system. Includes webApi(Server) and client application code. Uses docker for server and updates deployment.

# Server deployment

1. Download and install Docker.
2. Log in Docker.
3. Open console in the solution directory.
4. Build an image there with :
5. Tag the image and upload it to the Docker image Hub:
6. Install docker and mssqlserver in your server device with :
7. Create a docker network with :
8. Create the mssqlserver container with :
9. Log in Docker with :
10. Pull the image you created earlier with :
11. Run the image inside the same docker network with :

# Client Application deployment

1. Publish the WolfClient project as self-contained and tick single executable file.
2. Using installers like inno setup compiler make an installer and name it WolfSetup.exe.
3. Make WolfVersion.txt which contains text of the current version of wolf. For example the file content would be: "1.0.0.0".
4. Move the to files to the same folder of you choice in the server.
5. Create a dockerFile with the following content:
6. Create self signed certificate with:
7. Build an image of the update container with:
8. Run the image with:  
