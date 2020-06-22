# Walmart-Products
Aplicación backend para obtener productos Walmart desde una base de datos **MongoDB**

Para correr esta aplicación en Docker, debes realizar lo siguiente:

1. Descarga el proyecto en tu directorio de preferencia. Ejemplo:
`D:\Walmart>`
2. Abrir CMD y acceder a la carpeta del proyecto. En la carpeta, se debe visualizar el archivo Dockerfile.

3. Ejecuta el siguiente código para crear una imagen del proyecto.
`docker build -t walmart-siep-backend:v1 .`
Con este script, estamos construyendo la imagen del proyecto, le asignamos un nombre y una version. No olvides el punto `.` al final del script, para que utilice el archivo Dockerfile del directorio.
4. Una vez instaladas las dependencias del proyecto y creada la imagen, puedes consultar que esté creada en Docker.
`docker images`

5. Puedes ejecutar cualquier de los 2 scripts siguientes. Detallo que hace cada uno:

`docker run -it --rm -p 8787:80 walmart-siep-backend:v1`
- Crea un nuevo contenedor en modo interactivo `-it` y luego de finalizar la ejecución del proyecto, elimina inmediatamente el contenedor `--rm`. Además, al puerto 8787 se le mapea al puerto 80 y finalmente, se indica el nombre de la imagen a utilizar. 


`docker run -d -p 8787:80 --name walmart-backend walmart-siep-backend:v1`
- Crea un nuevo contenedor, en modo iniciado `-d` luego se publica `-p` se mapea el puerto 8787 al 80, se le asigna un nombre al contenedor `--name` y finalmente, se le indica el nombre de la imagen.

6. Para el caso 2, si ahora ejecutas `docker ps` verás el contenedor corriendo en `localhost:8787`

7. Ahora solo debes ir a tu navegador favorito e ingresar la siguiente url `localhost:8787/swagger/swagger` y verás la aplicación corriendo.

![](https://github.com/sechalarp/imagenes-varias/blob/master/SwaggerBackend.png)



------------

### Extra
La aplicación backend, posee un sistema de seguimiento de errores o exceptions, por lo que esto se hace por medio de Azure AppInsights. Si deseas conectar el monitoreo a tu propio ApplicationInsights de Azure, debes modificar en el archivo `appsettings.json`, el valor asignado a: `ApplicationInsights:InstrumentationKey`

![](https://github.com/sechalarp/imagenes-varias/blob/master/AppInsig_Azure.png)
