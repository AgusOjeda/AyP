# AyP
Gestion de ventas y empleados de una farmacia en c#

Proyecto 5:
Una farmacia guarda información de las ventas de medicamentos realizadas dentro del último mes. De cada venta se registra el nombre comercial del medicamento, droga, obra social (“particular “, si no fue comprado por obra social), plan (“ ”, si no es por un plan determinado), importe, código de vendedor, fecha y hora de venta (DateTime) y nro de ticket-factura. De cadaempleado de la farmacia se conoce su nombre y apellido, dni y  monto total vendido.

Se deberá desarrollar una aplicación, utilizando las clases que crea necesarias, que resuelva las funcionalidades que se muestra en el siguiente menú:
a) Agregar una venta de medicamento , sumándole el importe de la venta al empleado correspondiente.
b) Modificar el código de vendedor de una ventade medicamentoidentificándola por nro de ticket-factura. Modificar los montos de los 2 empleadosinvolucrados en este proceso.
c) Eliminar venta de medicamento por nro de ticket-factura. Modificar el monto vendido del empleadocorrespondiente.En caso de no existir venta con ese nro de ticket se debe levantar una excepción indicando lo ocurrido (“nro de ticketinválido”).
d) Informar el porcentaje de ventas realizadasenla primer quincenaque hayan sidopor obra social.
e) Listar todas las ventas de los medicamentos que  contengan una droga dada y que sean de un plan determinado.
f)Informar quién fue el empleadocon mayor monto final vendido.
