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


select * from TipoDocumentoVenta

insert into TipoDocumentoVenta(descripcion,esActivo) values
('Boleta',1),
('Factura',1)


select * from Menu

--*menu padre
insert into Menu(descripcion,icono,controlador,paginaAccion,esActivo) values
('DashBoard','fas fa-fw fa-tachometer-alt','DashBoard','Index',1)

insert into Menu(descripcion,icono,esActivo) values
('Administración','fas fa-fw fa-cog',1),
('Inventario','fas fa-fw fa-clipboard-list',1),
('Ventas','fas fa-fw fa-tags',1),
('Reportes','fas fa-fw fa-chart-area',1)

--*menu hijos Administracion
insert into Menu(descripcion,idMenuPadre, controlador,paginaAccion,esActivo) values
('Usuarios',2,'Usuario','Index',1),
('Negocio',2,'Negocio','Index',1)

--*menu hijos - Inventario
insert into Menu(descripcion,idMenuPadre, controlador,paginaAccion,esActivo) values
('Categorias',3,'Categoria','Index',1),
('Productos',3,'Producto','Index',1)

--*menu hijos - Ventas
insert into Menu(descripcion,idMenuPadre, controlador,paginaAccion,esActivo) values
('Nueva Venta',4,'Venta','NuevaVenta',1),
('Historial Venta',4,'Venta','HistorialVenta',1)

--*menu hijos - Reportes
insert into Menu(descripcion,idMenuPadre, controlador,paginaAccion,esActivo) values
('Reporte de Ventas',5,'Reporte','Index',1)


UPDATE Menu SET idMenuPadre = idMenu where idMenuPadre is null


--________________________________ INSERTAR ROL MENU ________________________________
select * from Menu
select * from RolMenu
SELECT * FROM ROL

--*administrador
INSERT INTO RolMenu(idRol,idMenu,esActivo) values
(1,1,1),
(1,6,1),
(1,7,1),
(1,8,1),
(1,9,1),
(1,10,1),
(1,11,1),
(1,12,1)

--*Empleado
INSERT INTO RolMenu(idRol,idMenu,esActivo) values
(2,10,1),
(2,11,1)

--*Supervisor
INSERT INTO RolMenu(idRol,idMenu,esActivo) values
(3,8,1),
(3,9,1),
(3,10,1),
(3,11,1)