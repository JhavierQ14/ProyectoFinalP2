create database RestaurantDB;
go
use RestaurantDB;

----------------------------------------  Tablas Independientes --------------------------------------------------------

create table tbl_RolUsuario(
 rolUser_id int primary key identity(1,1) not null,
 nombreRol nvarchar(max)
);

create table tbl_Menu(
 menu_id int primary key identity(1,1) not null,
 nombreMenu nvarchar(max)
);

create table tbl_MetodoPago(
 metodoPago_id int primary key identity(1,1) not null,
 nombreMetodo nvarchar(max)
);

create table tbl_Documento(
 documento_id int primary key identity(1,1) not null,
 nombreDocumento nvarchar(max)
);

--create table tbl_Combo(
--combo_id int primary key identity(1,1) not null,
--codCombo nvarchar(max),
--nombreCombo nvarchar(max),
--precioC decimal(18,2),
--fechaCreacionC datetime default(getdate()),
--estadoCombo nvarchar(max)
--);

------------------------------------------------ Tablas Dependientes  -----------------------------------------------------------

create table tbl_User(
usuario_id int primary key identity(1,1) not null,
nombreU nvarchar(max),
apellidoU nvarchar(max),
telefonoU int,
correoU nvarchar(100) unique,
contraU nvarchar(max),
encryptionU nvarchar(max),
rolUser_Fk int references tbl_RolUsuario(rolUser_id)
);

create table tbl_Domicilio(
 domicilio_id int primary key identity(1,1) not null,
 ubicacion nvarchar(max),
 referencia nvarchar(max),
 usuario_Fk int references tbl_User(usuario_id)
 );

create table tbl_Producto(
 producto_id int primary key identity(1,1) not null,
 codProducto nvarchar(max),
 nombreProducto nvarchar(max),
 precioP decimal(18,2),
 fechaCreacionP datetime default(getdate()),
 estadoProducto nvarchar(max),
 imageP nvarchar(max),
 menu_Fk int references tbl_Menu(menu_id)
 );


--create table tbl_DetalleCombo(
-- detalleCombo_id int primary key identity(1,1) not null,
-- descripcion nvarchar(max),
-- cantidadP int,
-- producto_Fk int references tbl_Producto(producto_id),
-- combo_FK int references tbl_Combo(combo_id)
-- );

create table tbl_Carrito(
 carrito_id int primary key identity(1,1) not null,
 cantidadP int,
 totalP decimal(18,2),
 usuario_Fk int references tbl_User(usuario_id),
 --combo_FK int references tbl_Combo(combo_id),
 producto_Fk int references tbl_Producto(producto_id)
 );

 create table tbl_Orden(
 orden_id int primary key identity(1,1) not null,
 codOrden nvarchar(max),
 fechaOrden datetime default(getdate()),
 estadoOrden nvarchar(max),
 user_FK int references tbl_User(usuario_id),
 metodoPago_FK int references tbl_MetodoPago(metodoPago_id),
 documento_Fk int references tbl_Documento(documento_id)
 );

 create table tbl_DetalleOrden(
 detalleOden_id int primary key identity(1,1) not null,
 cantidad int,
 totalFinal decimal(18,2),
 orden_FK int references tbl_Orden(orden_id),
 --combo_FK int references tbl_Combo(combo_id),
 producto_Fk int references tbl_Producto(producto_id)
 );


 select * from tbl_User
 select * from tbl_Carrito

use sistema_ventas;
alter table tb_detalleventa alter column precio decimal(18,5)
alter table tb_detalleventa alter column total decimal(18,5)

alter table tb_venta alter column totalventa decimal(18,5)

SELECT tbl_User.nombreU,tbl_User.apellidoU, tbl_RolUsuario.nombreRol
FROM tbl_User
INNER JOIN tbl_RolUsuario ON tbl_User.rolUser_Fk = tbl_RolUsuario.rolUser_id;