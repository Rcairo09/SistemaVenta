--________________________________ INSERTAR NUMERO CORRELATIVO ________________________________
select * from NumeroCorrelativo
--000001
insert into NumeroCorrelativo(ultimoNumero,cantidadDigitos,gestion,fechaActualizacion) values
(0,6,'venta',getdate())



select * from Configuracion
insert into Configuracion(recurso,propiedad,valor) values
('Servicio_Correo','correo','rcairor09@gmail.com'),
('Servicio_Correo','clave','uzohavkmryantuxu'),
('Servicio_Correo','alias','App Web'),
('Servicio_Correo','host','smtp.gmail.com'),
('Servicio_Correo','puerto','587')


insert into Configuracion(recurso,propiedad,valor) values
('FireBase_Storage','email','cairo09@gmail.com'),
('FireBase_Storage','clave','cairo@09'),
('FireBase_Storage','ruta','app-web-7a2c9.appspot.com'),
('FireBase_Storage','api_key','AIzaSyDsvkQ4G3QLmoLo0k410fw2AGuC2gmuUek'),
('FireBase_Storage','carpeta_usuario','IMAGENES_USUARIO'),
('FireBase_Storage','carpeta_producto','IMAGENES_PRODUCTO'),
('FireBase_Storage','carpeta_logo','IMAGENES_LOGO')

select * from rol
insert into rol(descripcion,esActivo) values
('Administrador',1),
('Empleado',1),
('Supervisor',1)

insert into Usuario(nombre,correo,telefono,idRol,urlFoto,nombreFoto,clave,esActivo) values
('Usuario Test','usertest@example.com','909090',1,'','','a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3',1)



select * from Negocio

insert into Negocio(idNegocio,urlLogo,nombreLogo,numeroDocumento,nombre,correo,direccion,telefono,porcentajeImpuesto,simboloMoneda)
values(1,'','','','','','','',0,'')

SELECT * FROM Categoria

INSERT INTO Categoria(descripcion,esActivo) values
('Computadoras',1),
('Laptops',1),
('Teclados',1),
('Monitores',1),
('Microfonos',1)
