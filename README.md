# car-rental
API que permite consultar disponibilidad de vehículos para renta según la ubicación, incluye consumos para registrar transacciones de renta y consultarlas por medio del id

============================ Servicios ============================

GetNearbyCars: recibe dos parámetros con la información de la sucursal que emitirá el vehículo y la sucursal donde se entregará una vez finalice el servicio, los parámetros se entregarán siguiendo la estructura Ciudad - Departamento en ambos casos. Retornará una respuesta de código 200 con la lista de vehículos disponibles y una tarifa de devolución en caso de no devolver el vehículo en la misma sucursal de origen. Si no hay vehículos, retornará una respuesta de código 204. En la ejecución del proyecto se incluyen los ejemplos en documentación de swagger.

AddService: recibirá un body json con la información del vehículo y las direcciones de recogida y entrega del vehículo rentado, retornará una respuesta de código 200 con el id de la transacción y un mensaje de exitoso. Swagger incluye documentación y un ejemplo del request body.

GetRentalById: Recibe un parámetro con el id de la transacción y retorna una respuesta de tipo 200 con un objeto que contiene la información de la transacción (vehículo, direcciones, tarifa); en caso de presentarse errores o no existir la transacción retornará un código 400 indicando este error.

============================ Generalidades ============================

- Se realizó el proyecto implementando una base de datos en memoria por medio del ORM Entity Framework, el cuál también se utilizó para la gestión y pruebas.
- El proyecto cuenta con test unitarios y documentación en swagger con ejemplos de cada consumo.
- Se implementó arquitectura hexagonal en la estructura del proyecto y patrón de diseño Factory Method, se manejó inyección de dependencias utilizando Autofac el cuál crea instancias de tipo scoped, apropiadas para este tipo de proyecto
- Se implementó configuración de Automapper para el paso de información entre entidades y DTOs.
- El proyecto está codificado siguiendo los principios SOLID.
- Al tratarse de un proyecto de prueba, no se implementaron perfiles de ejecución aparte del perfil estándar de Development.

