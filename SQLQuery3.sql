use GD2C2016
-- Crea schema
BEGIN TRANSACTION
	IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'FORANEOS')
	EXEC sys.sp_executesql N'CREATE SCHEMA [FORANEOS] AUTHORIZATION [gd]'
	
COMMIT

-- Drop de tables
if object_id('FORANEOS.Rol_Usuario') is not null
  drop table FORANEOS.Rol_Usuario;
if object_id('FORANEOS.Funcionalidad_Rol') is not null
  drop table FORANEOS.Funcionalidad_Rol;
if object_id('FORANEOS.Rol') is not null
  drop table FORANEOS.Rol;
if object_id('FORANEOS.Funcionalidad') is not null
  drop table FORANEOS.Funcionalidad;
if object_id('FORANEOS.Cancelacion_Turno') is not null
  drop table FORANEOS.Cancelacion_Turno;
if object_id('FORANEOS.Consulta_Medica') is not null
  drop table FORANEOS.Consulta_Medica;
if object_id('FORANEOS.Turno') is not null
  drop table FORANEOS.Turno;
if object_id('FORANEOS.Bono') is not null
  drop table FORANEOS.Bono;
if object_id('FORANEOS.Horario_Atencion') is not null
  drop table FORANEOS.Horario_Atencion;
if object_id('FORANEOS.Agenda') is not null
  drop table FORANEOS.Agenda;
if object_id('FORANEOS.Especialidad_Profesional') is not null
  drop table FORANEOS.Especialidad_Profesional;
if object_id('FORANEOS.Especialidad') is not null
  drop table FORANEOS.Especialidad;
if object_id('FORANEOS.Tipo_Especialidad') is not null
  drop table FORANEOS.Tipo_Especialidad;
if object_id('FORANEOS.Compra_Bono') is not null
  drop table FORANEOS.Compra_Bono;
if object_id('FORANEOS.Cambio_De_Plan') is not null
  drop table FORANEOS.Cambio_De_Plan;
if object_id('FORANEOS.Afiliado') is not null
  drop table FORANEOS.Afiliado;
if object_id('FORANEOS.Plan_Medico') is not null
  drop table FORANEOS.Plan_Medico;
if object_id('FORANEOS.Profesional') is not null
  drop table FORANEOS.Profesional;
if object_id('FORANEOS.Usuario') is not null
  drop table FORANEOS.Usuario;
/*--------------------------------------------------------------------------------------------------------------*/
/* CREATE DE TABLAS */
/*Creacion de Tabla de usuarios */
create table FORANEOS.Usuario(
	id numeric(18,0) IDENTITY(1,1),
	username varchar(255) UNIQUE,
	password varbinary(8000),
	nombre varchar(255) NOT NULL,
	apellido varchar(255) NOT NULL,
	dni numeric(18,0) NOT NULL,
	Direccion varchar(255), 
	telefono numeric(18,0),
	mail varchar(255),
	fecha_nac datetime NOT NULL,
	sexo bit,
	intentos_login numeric(1,0),
	estado bit,
	primary key (id)
);
/* Creacion de tabla Profesional */
create table FORANEOS.Profesional(
	id numeric(18,0) REFERENCES FORANEOS.Usuario(id),
	matricula numeric(18,0),
	primary key (id)
);
/* Creacion de tabla Plan Medico */
create table FORANEOS.Plan_Medico(
	codigo numeric(18,0) IDENTITY(1,1),
	descripcion varchar(255), 
	bono_consulta numeric(18,0),
	bono_farmacia numeric(18,0),
	primary key(codigo)
);
/*Creacion de Tabla de afiliados*/
create table FORANEOS.Afiliado(
	id numeric(18,0) REFERENCES FORANEOS.Usuario (id),
	numero_afiliado numeric(18,0),
	estado_civil numeric(1,0) , 
	familiares_a_cargo numeric(2,0),
	codigo_plan numeric(18,0) REFERENCES FORANEOS.Plan_Medico (codigo),
	primary key (id)
);
/*Creacion de tabla Cambio_De_Plan */
create table FORANEOS.Cambio_De_Plan(
	id numeric(18,0) IDENTITY(1,1),
	codigo_plan numeric (18,0) REFERENCES FORANEOS.Plan_Medico(codigo),
	id_afiliado numeric (18,0) REFERENCES FORANEOS.Afiliado(id),
	fecha_baja datetime,
	motivo varchar(255),
	primary key (id)
);
/*Creacion de Tabla de Compra-Bono*/
create table FORANEOS.Compra_Bono(
	id numeric (18,0) IDENTITY(1,1),
	id_afiliado numeric(18,0) REFERENCES FORANEOS.Afiliado(id),
	fecha datetime,
	primary key(id)
);
/*Creacion de Tabla de Tipo_Especialides*/
create table FORANEOS.Tipo_Especialidad(
	codigo numeric(18,0) IDENTITY(1,1),
	descripcion varchar(225),
	primary key(codigo)
	);
/*Creacion de Tabla de Especialides*/
create table FORANEOS.Especialidad(
	codigo numeric(18,0) IDENTITY(1,1),
	descripcion varchar(225),
	codigo_tipo_esp numeric(18,0) REFERENCES FORANEOS.Tipo_Especialidad(codigo),
	primary key(codigo)
	);
	
/* Creacion de tabla Especialidad_Profesional */
create table FORANEOS.Especialidad_Profesional(
	id_profesional numeric(18,0) REFERENCES FORANEOS.Profesional(id),
	codigo_especialidad numeric(18,0) REFERENCES FORANEOS.Especialidad(codigo),
	primary key(id_profesional,codigo_especialidad)
);
/* Creacion de tabla Agenda */
create table FORANEOS.Agenda(
	id numeric(18,0) REFERENCES FORANEOS.Profesional(id),
	fecha_inicio date,
	fecha_fin date,
	primary key (id)
);
/* Creacion de tabla Horario_Atencion */
create table FORANEOS.Horario_Atencion(
	id numeric(18,0) IDENTITY(1,1),
	fecha datetime,
	id_agenda numeric(18,0) REFERENCES FORANEOS.Agenda(id),
	codigo_especialidad numeric(18,0) REFERENCES FORANEOS.Especialidad(codigo),
	primary key (id)
);
/*Creacion de Tabla de Turno*/
create table FORANEOS.Turno(
	numero numeric(18,0),
	id_horario_atencion numeric(18,0) REFERENCES FORANEOS.Horario_Atencion(id), 
	id_afiliado numeric(18,0) REFERENCES FORANEOS.Afiliado(id),
	primary key (numero)
);

/* Creacion de tabla Cancelacion_Turno */
create table FORANEOS.Cancelacion_Turno(
	numero numeric(18,0) REFERENCES FORANEOS.Turno(numero),
	motivo varchar(255) NOT NULL,
	primary key (numero)	
);
/* Creacion de Tabla Bono */
create table FORANEOS.Bono (
	id numeric (18,0) IDENTITY(1,1),
	numero_afiliado numeric (18,0),
	estado bit,
	id_compra_bono numeric (18,0) REFERENCES FORANEOS.Compra_Bono(id),
	codigo_plan numeric (18,0) REFERENCES FORANEOS.Plan_Medico(codigo),
	primary key (id)
);
/* Creacion de tabla Consulta Medica */
create table FORANEOS.Consulta_Medica(
	numero numeric(18,0) REFERENCES FORANEOS.Bono(id),
	numero_turno numeric(18,0) REFERENCES FORANEOS.Turno(numero),
	fecha_hora datetime,
	sintomas varchar(255) NOT NULL,
	diagnostico varchar(255) NOT NULL,
	primary key (numero)
);
/* Creacion de tabla Funcionalidad */
create table FORANEOS.Funcionalidad(
	id numeric(2,0) IDENTITY(1,1),
	nombre nvarchar(255),
	primary key(id)
);
/* Creacion de tabla Rol */
create table FORANEOS.Rol(
	id numeric(2,0) IDENTITY(1,1),
	nombre nvarchar(255),
	estado bit default 1,
	primary key(id)
);
/* Creacion de Tabla Rol_Usuario */
create table FORANEOS.Rol_Usuario(
	id_rol numeric(2,0) REFERENCES FORANEOS.Rol(id),
	id_usuario numeric(18,0) REFERENCES FORANEOS.Usuario(id),
	primary key(id_rol,id_usuario)
);
/* Creacion de tabla Funcionalidad_Rol */
create table FORANEOS.Funcionalidad_Rol(
	id_funcionalidad numeric(2,0) REFERENCES FORANEOS.Funcionalidad(id),
	id_rol numeric(2,0) REFERENCES FORANEOS.Rol(id),
	primary key(id_funcionalidad,id_rol)
);

/*--------------------------------------------------------------------------------------------------------------*/
/* IMPORTACION DE DATOS DE LA TABLA MAESTRA */
if OBJECT_ID('FORANEOS.pa_migracion_maestra') is not null
drop proc FORANEOS.pa_migracion_maestra;
GO
create procedure FORANEOS.pa_migracion_maestra
AS
begin
/*Importacion de Roles y funcionalidades*/
insert into FORANEOS.Funcionalidad values('ABM de Rol');
insert into FORANEOS.Funcionalidad values('ABM de Afiliados');
insert into FORANEOS.Funcionalidad values('Registrar agenda profesional');
insert into FORANEOS.Funcionalidad values('Comprar bono/s');
insert into FORANEOS.Funcionalidad values('Pedir turno');
insert into FORANEOS.Funcionalidad values('Registrar llegada');
insert into FORANEOS.Funcionalidad values('Registrar resultado consulta');
insert into FORANEOS.Funcionalidad values('Cancelar atención médica');
insert into FORANEOS.Funcionalidad values('Obtener estadísticas');
insert into FORANEOS.Funcionalidad values('Historial cambios plan');
insert into FORANEOS.Rol values('Afiliado',1);
insert into FORANEOS.Rol values('Administrativo',1);
insert into FORANEOS.Rol values('Profesional',1);

/*Importacion de Usuarios Profesional*/
insert into FORANEOS.usuario (username,nombre,apellido,dni,direccion,telefono,mail,fecha_nac)
select medico_dni, medico_Nombre , medico_apellido, medico_dni, medico_Direccion, medico_telefono,medico_mail,medico_fecha_nac
from gd_esquema.Maestra
where medico_nombre is not null
group by medico_dni, medico_Nombre , medico_apellido, medico_dni, medico_Direccion, medico_telefono,medico_mail,medico_fecha_nac

/* Importacion de Profesionales */
insert into FORANEOS.Profesional (id)
select u.id
from FORANEOS.Usuario u, gd_esquema.Maestra m
where m.Medico_Dni = u.dni AND m.Medico_Dni is not null
group by u.id;

/* Migracion de Agendas */
insert into FORANEOS.Agenda(id)
select u.id
from FORANEOS.Usuario u, gd_esquema.Maestra m
where m.Medico_Dni = u.dni AND m.Medico_Dni is not null
group by u.id;

/* Importartacion Usuarios pacientes */
insert into FORANEOS.usuario (username,nombre,apellido,dni,direccion,telefono,mail,fecha_nac)
select paciente_dni, Paciente_Nombre , paciente_apellido, paciente_dni, Paciente_Direccion, paciente_telefono,paciente_mail,paciente_fecha_nac
from gd_esquema.Maestra
where paciente_nombre is not null
group by paciente_dni, Paciente_Nombre , paciente_apellido, paciente_dni, Paciente_Direccion, paciente_telefono,paciente_mail,paciente_fecha_nac

/* Importacion de plan medicos */
SET IDENTITY_INSERT FORANEOS.Plan_Medico ON
insert into FORANEOS.Plan_Medico (codigo,descripcion,bono_consulta,bono_farmacia)
select m.plan_med_codigo,m.plan_med_descripcion,m.plan_med_precio_bono_consulta,m.plan_med_precio_bono_farmacia 
from  gd_esquema.maestra m  
where Plan_Med_Codigo is not null
group by m.plan_med_codigo,m.plan_med_descripcion,m.plan_med_precio_bono_consulta,m.plan_med_precio_bono_farmacia
SET IDENTITY_INSERT FORANEOS.Plan_Medico OFF

/* Importacion Afiliados-Pacientes */
insert into FORANEOS.Afiliado(id,codigo_plan)
select u.id, m.Plan_Med_Codigo
from FORANEOS.Usuario u, gd_esquema.Maestra m
where m.Paciente_Dni = u.dni AND m.Paciente_Dni is not null
group by u.id, m.Plan_Med_Codigo;

/* Importacion Tipo_Especialidad */
SET IDENTITY_INSERT FORANEOS.Tipo_Especialidad ON
insert into FORANEOS.Tipo_Especialidad(codigo,descripcion)
select Tipo_Especialidad_Codigo, Tipo_Especialidad_Descripcion 
from  gd_esquema.Maestra 
where Tipo_Especialidad_Codigo is not null
group by Tipo_Especialidad_Codigo, Tipo_Especialidad_Descripcion
SET IDENTITY_INSERT FORANEOS.Tipo_Especialidad OFF

/* Importacion Especialidad */
SET IDENTITY_INSERT FORANEOS.Especialidad ON
insert into FORANEOS.Especialidad(codigo,descripcion,codigo_tipo_esp) 
select Especialidad_Codigo,Especialidad_Descripcion, Tipo_Especialidad_Codigo
from  gd_esquema.Maestra 
where Especialidad_Codigo is not null
group by Especialidad_Codigo,Especialidad_Descripcion, Tipo_Especialidad_Codigo
SET IDENTITY_INSERT FORANEOS.Especialidad OFF

/* Importacion Especialidad_Profesional */
insert into FORANEOS.Especialidad_Profesional
select u.id, m.especialidad_codigo 
from gd_esquema.Maestra m, FORANEOS.usuario u
where u.dni=m.Medico_Dni 
group by u.id, especialidad_codigo order by 1;

/* Migracion Compra Bono */
insert into FORANEOS.Compra_Bono(fecha,id_afiliado)
select m.Compra_Bono_Fecha, u.id
from gd_esquema.Maestra m, FORANEOS.Usuario u
where m.Paciente_Dni = u.dni and m.Compra_Bono_Fecha is  not null
group by Compra_Bono_Fecha, u.id;

/* Migracion de Turno a Horarios de Atencion */
SET IDENTITY_INSERT FORANEOS.Horario_Atencion ON
insert into FORANEOS.Horario_Atencion(id,fecha,codigo_especialidad,id_agenda)
select m.Turno_Numero, m.Turno_Fecha, m.Especialidad_Codigo, u.id
from gd_esquema.Maestra m, FORANEOS.Usuario u
where m.Medico_Dni = u.dni AND Turno_Numero is not null
group by m.Turno_Numero, m.Turno_Fecha,m.Especialidad_Codigo, u.id
order by Turno_Numero
SET IDENTITY_INSERT FORANEOS.Horario_Atencion OFF

/* Migracion Turno */
insert into FORANEOS.Turno(numero, id_afiliado, id_horario_atencion)
select m.Turno_Numero, u.id,h.id
from gd_esquema.Maestra m, FORANEOS.Usuario u, FORANEOS.Horario_Atencion h
where m.Paciente_Dni = u.dni AND h.id = m.Turno_Numero
group by m.Turno_Numero, u.id,h.id

/* Migracion Bono */
SET IDENTITY_INSERT FORANEOS.Bono ON
insert into FORANEOS.Bono(id,codigo_plan,id_compra_bono)
select * from (select m.Bono_Consulta_Numero, m.Plan_Med_Codigo, (select cb.id from  FORANEOS.Compra_Bono cb where u.id = cb.id_afiliado AND cb.fecha = m.Compra_Bono_Fecha) as codigo_compra
from gd_esquema.Maestra m, FORANEOS.Usuario u
where m.Bono_Consulta_Numero is not null AND m.Compra_Bono_Fecha is not null AND u.dni = m.Paciente_Dni) as sub_table
group by sub_table.Bono_Consulta_Numero, sub_table.codigo_compra, sub_table.Plan_Med_Codigo
order by 1
SET IDENTITY_INSERT FORANEOS.Bono OFF

/* Migracion Consulta Medica */
insert into FORANEOS.Consulta_Medica(numero, diagnostico, sintomas, fecha_hora,numero_turno)
select m.Bono_Consulta_Numero, m.Consulta_Enfermedades, m.Consulta_Sintomas, m.Bono_Consulta_Fecha_Impresion, m.Turno_Numero
from gd_esquema.Maestra m
where m.Bono_Consulta_Numero is not null AND m.Turno_Numero is not null
group by m.Bono_Consulta_Numero, m.Consulta_Enfermedades, m.Consulta_Sintomas, m.Bono_Consulta_Fecha_Impresion, m.Turno_Numero
order by 1


END

/*Procedimientos y triggers*/

--Login

IF OBJECT_ID('FORANEOS.loggin') IS NOT NULL
    DROP PROCEDURE FORANEOS.loggin;
GO

CREATE PROCEDURE FORANEOS.loggin(@UserName varchar(255), @Password varchar(255))
AS

DECLARE @estado int
declare @cantUsuarios numeric
declare @usrId numeric

set @cantUsuarios = ISNULL((select COUNT(*) FROM FORANEOS.usuario
	WHERE username = @UserName
	AND password = HASHBYTES('SHA2_256', @Password) AND estado=1
	group by username
	having count(intentos_login)<3),0)

IF(@cantUsuarios=0)
	
BEGIN
		set @usrId = (select id FROM FORANEOS.usuario where username = @UserName)
		
		if (not exists (select id FROM FORANEOS.usuario where id = @usrId))
		begin 
			RAISERROR (40001,-1,-1, 'El Usuario no existe!')
			return;
		end
		
		if((select intentos_login from FORANEOS.usuario  where id = @usrId) > 2 OR (SELECT estado from FORANEOS.usuario where id=@usrId)=0)
		begin
			RAISERROR (40002,-1,-1, 'Usuario Bloqueado!')
			UPDATE usuario
			SET estado=0
			WHERE id=@usrId
			return;
		end
		if (exists (select id FROM FORANEOS.usuario WHERE username = @UserName AND password<>@Password))
		begin 
			RAISERROR (40003,-1,-1, 'Password incorrecta')
			UPDATE usuario
			SET intentos_login=(intentos_login+1)
			WHERE id=@usrId
			return;
		end 
END

ELSE

BEGIN
	set @usrId = (SELECT id FROM FORANEOS.usuario WHERE username = @UserName
	AND password = HASHBYTES('SHA2_256', @Password))
	SELECT @usrId
END

GO

--/*ABM roles*/

--Type Funcionalidades

IF TYPE_ID('FORANEOS.t_func') IS NOT NULL
	DROP TYPE FORANEOS.t_func;
GO

create type FORANEOS.t_func as table
(id int);
   
GO
  
--Crear Rol 

IF OBJECT_ID('FORANEOS.crearRol') IS NOT NULL
	DROP PROCEDURE FORANEOS.crearRol;
GO
create procedure FORANEOS.crearRol 
(@rol varchar(255),
@func FORANEOS.t_func READONLY)

as 
declare @id_rol int;

 begin
   SET NOCOUNT ON

   insert into Rol (nombre,estado) values (@rol,1);
   
  set @id_rol =(select id
   from FORANEOS.Rol
   where nombre=@rol)

   insert into FORANEOS.Funcionalidad_Rol (id_rol,id_funcionalidad) 
   (select  @id_rol, id
     from @func)

end

GO

--Modificar Rol

IF OBJECT_ID('FORANEOS.modificarRol') IS NOT NULL
	DROP PROCEDURE FORANEOS.modificarRol;
GO
create procedure FORANEOS.modificarRol 
(@rol_id numeric,
@rol varchar(255),
@func FORANEOS.t_func READONLY)

as 

begin 
   begin transaction
   delete FORANEOS.Funcionalidad_Rol where id_rol=@rol_id

   update FORANEOS.Rol
   set nombre = @rol where @rol_id = id

   insert into FORANEOS.Funcionalidad_Rol (id_rol,id_funcionalidad) 
   (select @rol_id,id from @func)
   commit transaction
end

GO

--Eliminar rol

IF OBJECT_ID('FORANEOS.eliminarRol') IS NOT NULL
	DROP PROCEDURE FORANEOS.eliminarRol;
GO
create procedure FORANEOS.eliminarRol
(@rol_id int)
as 
 begin
  update FORANEOS.Rol
  set estado=0
  where id = @rol_id;

end

GO

--Habilitar rol

IF OBJECT_ID('FORANEOS.habilitarRol') IS NOT NULL
	DROP PROCEDURE FORANEOS.habilitarRol;
GO
create procedure FORANEOS.habilitarRol
(@rol_id int)
as 
 begin
	 begin transaction
	  update FORANEOS.Rol
	  set estado=1
	  where id = @rol_id;
	  commit transaction
end

GO

--Cantidad de roles por usuario

IF OBJECT_ID('FORANEOS.cantidadRoles') IS NOT NULL
   DROP PROCEDURE FORANEOS.cantidadRoles;
GO

CREATE PROCEDURE FORANEOS.cantidadRoles(@UserName varchar(255))
AS

select COUNT(*)
from FORANEOS.usuario, FORANEOS.rol_usuario
where usuario.username=@UserName
and usuario.id=rol_usuario.id_usuario

GO

--Roles por usuario

IF OBJECT_ID('FORANEOS.obtenerRolesXusuario') IS NOT NULL
   DROP PROCEDURE FORANEOS.obtenerRolesXusuario;
GO

CREATE PROCEDURE FORANEOS.obtenerRolesXusuario(@UserName varchar(255))
AS
select rol.nombre
from FORANEOS.rol INNER JOIN Rol_Usuario ON rol.id = Rol_Usuario.id_rol
INNER JOIN Usuario ON Rol_Usuario.id_usuario = Usuario.id 
where username = @Username

GO

--Obtener funcionalidades

IF OBJECT_ID('FORANEOS.obtenerFuncionalidades') IS NOT NULL
    DROP PROCEDURE FORANEOS.obtenerFuncionalidades;
GO
create procedure FORANEOS.obtenerFuncionalidades
  as 
 begin
  
   select id,nombre
   from FORANEOS.Funcionalidad;
 end

 GO

 --Obtener funcionalidades por rol

 IF OBJECT_ID('FORANEOS.obtenerFuncionalidadesXrol') IS NOT NULL
    DROP PROCEDURE FORANEOS.obtenerFuncionalidadesXrol;
GO
create procedure FORANEOS.obtenerFuncionalidadesXrol(@nombreRol varchar(255))
  as 
 begin
  
   select Funcionalidad.nombre
   from FORANEOS.Funcionalidad INNER JOIN FORANEOS.Funcionalidad_Rol ON Funcionalidad.id = Funcionalidad_Rol.id_funcionalidad
   INNER JOIN Rol ON rol.id = Funcionalidad_Rol.id_rol
   where rol.nombre = @nombreRol
 end

 GO

 --Obtener ID de rol

 IF OBJECT_ID('FORANEOS.obtenerIDrol') IS NOT NULL
    DROP PROCEDURE FORANEOS.obtenerIDrol;
GO
create procedure FORANEOS.obtenerIDrol(@nombreRol varchar(255))
  as 
 begin
  
  declare @id int

   set @id = (select id
   from FORANEOS.Rol
   where nombre = @nombreRol)

   select @id

end

 GO

 --Obtener ID de funcionalidad

 IF OBJECT_ID('FORANEOS.obtenerIDfuncionalidad') IS NOT NULL
    DROP PROCEDURE FORANEOS.obtenerIDfuncionalidad;
GO
create procedure FORANEOS.obtenerIDfuncionalidad(@nombreFuncionalidad varchar(255))
  as 
 begin
  
  declare @id int

   set @id = (select Funcionalidad.id
   from FORANEOS.Funcionalidad
   where Funcionalidad.nombre = @nombreFuncionalidad)

   select @id

end

 GO
 
 --Obtener roles deshabilitados

 IF OBJECT_ID('FORANEOS.obtenerRolesDeshabilitados') IS NOT NULL
	DROP PROCEDURE FORANEOS.obtenerRolesDeshabilitados;
GO
create procedure FORANEOS.obtenerRolesDeshabilitados

  as 
begin
   select id,nombre from FORANEOS.Rol
   where estado = 0
end

GO

--Obtener roles habilitados

 IF OBJECT_ID('FORANEOS.obtenerRolesHabilitados') IS NOT NULL
	DROP PROCEDURE FORANEOS.obtenerRolesHabilitados;
GO
create procedure FORANEOS.obtenerRolesHabilitados

  as 
begin
   select id,nombre from FORANEOS.Rol
   where estado = 1
end


GO

--Obtener roles

 IF OBJECT_ID('FORANEOS.obtenerRoles') IS NOT NULL
	DROP PROCEDURE FORANEOS.obtenerRoles;
GO
create procedure FORANEOS.obtenerRoles

  as 
begin
   select id,nombre from FORANEOS.Rol
end

--/*ABM afiliados*/

-- Habilitar Afiliado

IF OBJECT_ID('FORANEOS.habilitarAfiliado') IS NOT NULL
	DROP PROCEDURE FORANEOS.habilitarAfiliado;
GO
create procedure FORANEOS.habilitarAfiliado 
(@dni_afiliado numeric(18,0))

as 
begin 
	update FORANEOS.Usuario
	   set estado=1
	 where dni=@dni_afiliado
end
GO

-- Eliminar Afiliado

IF OBJECT_ID('FORANEOS.eliminarAfiliado') IS NOT NULL
	DROP PROCEDURE FORANEOS.eliminarAfiliado;
GO
create procedure FORANEOS.eliminarAfiliado 
(@dni_afiliado numeric(18,0))

as 
begin 
	update FORANEOS.Usuario
	   set estado=0
	 where dni=@dni_afiliado
end
GO

-- Obtener Planes Medicos

IF OBJECT_ID('FORANEOS.obtenerPlanesMedicos') IS NOT NULL
	DROP PROCEDURE FORANEOS.obtenerPlanesMedicos;
GO
create procedure FORANEOS.obtenerPlanesMedicos 
as 
begin 
	select codigo, descripcion,bono_consulta,bono_farmacia
 	  from Plan_Medico
end

GO

--Obtener profesionales por dni

IF OBJECT_ID('FORANEOS.obtenerProfesionalPorDNI') IS NOT NULL
	DROP PROCEDURE FORANEOS.obtenerProfesionalPorDNI;
GO
create procedure FORANEOS.obtenerProfesionalPorDNI(@dni numeric(18,0)) 
as 
begin 
	select u.id, u.nombre,u.apellido, e.codigo cod_especialidad, e.descripcion especialidad, a.id agenda_id
 	  from FORANEOS.Usuario u, FORANEOS.Especialidad e,FORANEOS.Especialidad_Profesional ep,FORANEOS.Agenda a
	  where u.id=ep.id_profesional
	  and  ep.codigo_especialidad=e.codigo
	  and  ep.id_profesional=u.id
	  and u.dni=@dni
end


GO

--Obtener afiliados por dni para eliminacion

IF OBJECT_ID('FORANEOS.afiliadosPorDNIeliminacion') IS NOT NULL
	DROP PROCEDURE FORANEOS.afiliadosPorDNIeliminacion;
GO
create procedure FORANEOS.afiliadosPorDNIeliminacion(@dni numeric(18,0)) 
as

declare @cantUser int

set @cantUser = (select count(*) from FORANEOS.Usuario where dni = @dni)

if(@cantUser = 0)
begin

RAISERROR (40004,-1,-1, 'No existen usuarios con ese DNI')
			return;

end

else
begin

if(0 = (select estado from FORANEOS.Usuario where dni = @dni))
begin

RAISERROR (40005,-1,-1, 'El usuario ya se encuentra deshabilitado')
			return;

end
	select nombre,apellido from FORANEOS.Usuario u
	INNER JOIN foraneos.Afiliado a on u.id = a.id
	where u.dni = @dni

end

GO

--Obtener afiliados por dni para habilitacion

IF OBJECT_ID('FORANEOS.afiliadosPorDNIhabilitacion') IS NOT NULL
	DROP PROCEDURE FORANEOS.afiliadosPorDNIhabilitacion;
GO
create procedure FORANEOS.afiliadosPorDNIhabilitacion(@dni int) 
as

declare @cantUser int

set @cantUser = (select count(*) from FORANEOS.Usuario where dni = @dni)

if(@cantUser = 0)
begin

RAISERROR (40004,-1,-1, 'No existen usuarios con ese DNI')
			return;

end

else
begin

if(1 = (select estado from FORANEOS.Usuario where dni = @dni))
begin

RAISERROR (40005,-1,-1, 'El usuario ya se encuentra habilitado')
			return;

end
	select nombre,apellido from FORANEOS.Usuario u
	INNER JOIN foraneos.Afiliado a on u.id = a.id
	where u.dni = @dni

end

GO



IF OBJECT_ID('FORANEOS.afiliadosPorDNIhabilitacion') IS NOT NULL
	DROP PROCEDURE FORANEOS.afiliadosPorDNIhabilitacion;
GO
create procedure FORANEOS.afiliadosPorDNIhabilitacion(@dni int) 
as




--Triggers

--Trigger Elimina los usuarios asociados a Rol dado de baja

IF OBJECT_ID('FORANEOS.tr_eliminar_rol_baja') IS NOT NULL
	DROP TRIGGER FORANEOS.tr_eliminar_rol_baja;
GO
create trigger FORANEOS.tr_eliminar_rol_baja on FORANEOS.Rol
for update
as
begin
	delete FORANEOS.Rol_Usuario 
	where exists(select 1 from inserted where id_rol =inserted.id)
end

GO

IF OBJECT_ID('FORANEOS.tr_cambioPlan') IS NOT NULL
	DROP TRIGGER FORANEOS.tr_cambioPlan;
GO
create trigger FORANEOS.tr_cambioPlan on FORANEOS.Afiliado
instead of update
as
declare @codigo_plan numeric
declare @id_afiliado numeric
begin
if update(codigo_plan) 
	begin
	set @id_afiliado = (select numero_afiliado from deleted)
	set @codigo_plan  = (select codigo_plan from deleted)
	--revisar el motivo de baja o cambio
		insert into FORANEOS.Cambio_De_Plan (codigo_plan,id_afiliado,fecha_baja, motivo) values
		            (@codigo_plan,@id_afiliado,GETDATE(), 'Un motivo')

	end
end

GO

IF OBJECT_ID('FORANEOS.tr_EliminaUsuario_Turnos') IS NOT NULL
	DROP TRIGGER FORANEOS.tr_EliminaUsuario_Turnos;
GO
create trigger FORANEOS.tr_EliminaUsuario_Turnos on FORANEOS.Usuario
instead of update
as
declare @id_usuario numeric

begin
	set @id_usuario = (select id from inserted)
		update FORANEOS.Turno 
		   set id_afiliado= null
		 where id_afiliado = @id_usuario
		 and fecha_llegada > GETDATE()
end
GO