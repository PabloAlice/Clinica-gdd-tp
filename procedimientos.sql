/*
begin transaction
insert into FORANEOS.Funcionalidad values('Abm de Rol');
insert into FORANEOS.Funcionalidad values('Login y seguridad');
insert into FORANEOS.Funcionalidad values('Registro de Usuario');
insert into FORANEOS.Funcionalidad values('Abm Afiliado');
insert into FORANEOS.Funcionalidad values('Abm Profesional');
insert into FORANEOS.Funcionalidad values('Abm Especialidades Médicas');
insert into FORANEOS.Funcionalidad values('Abm de Planes');
insert into FORANEOS.Funcionalidad values('Registrar agenda del médico');
insert into FORANEOS.Funcionalidad values('Compra de bonos');
insert into FORANEOS.Funcionalidad values('Pedir turno');
insert into FORANEOS.Funcionalidad values('Registro de llegada para atención médica');
insert into FORANEOS.Funcionalidad values('Registrar resultado para atención médica');
insert into FORANEOS.Funcionalidad values('Cancelar atención médica');
insert into FORANEOS.Funcionalidad values('Listado estadístico');


begin transaction
insert into FORANEOS.Rol values('Afiliado',1);
insert into FORANEOS.Rol values('Administrativo',1);
insert into FORANEOS.Rol values('Profesional',1);
commit;

*/
USE GD2C2016
--Obtener Roles 
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
--Obtener Roles 
IF OBJECT_ID('FORANEOS.obtenerRoles') IS NOT NULL
	DROP PROCEDURE FORANEOS.obtenerRoles;
GO
create procedure FORANEOS.obtenerRoles

  as 
begin
   select r.id,r.nombre,r.estado,f.id,f.nombre
     from FORANEOS.Funcionalidad f,FORANEOS.Funcionalidad_Rol fr,FORANEOS.Rol r
    where f.id=fr.id_funcionalidad
	  and r.id=fr.id_rol;
end
GO

--Type Funcionalidades  
IF TYPE_ID('FORANEOS.t_func') IS NOT NULL
	DROP PROCEDURE FORANEOS.crearRol;
	DROP PROCEDURE FORANEOS.modificarRol;
	DROP TYPE FORANEOS.t_func;
GO
create type FORANEOS.t_func as table
( id int,
  descrip varchar(255)); 
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
--declare @func_p t_func;
 begin
   SET NOCOUNT ON
 --  set @func_p = (select @func);

   insert into Rol (nombre,estado) values (@rol,1);
   
  set @id_rol =(select id
   from FORANEOS.Rol
   where nombre=@rol)

   insert into FORANEOS.Funcionalidad_Rol (id_rol,id_funcionalidad) 
   (select  @id_rol, id
     from @func)

end


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

   insert into FORANEOS.Funcionalidad_Rol (id_rol,id_funcionalidad) 
   (select  @rol_id, id from @func)
   commit transaction
end
GO
GO
IF OBJECT_ID('FORANEOS.habilitarRol') IS NOT NULL
	DROP PROCEDURE FORANEOS.habilitarRol;
GO
create procedure FORANEOS.habilitarRol
(@rol_id int)
as 
 begin
	begin transaction
 /*crear trigger para elimar el rol de los usuarios*/
  update FORANEOS.Rol
  set estado=1
  where id = @rol_id;
  commit transaction
end
GO
--Eliminar Rol 
IF OBJECT_ID('FORANEOS.eliminarRol') IS NOT NULL
	DROP PROCEDURE FORANEOS.eliminarRol;
GO
create procedure FORANEOS.eliminarRol
(@rol_id int)
as 
 begin
 /*crear trigger para elimar el rol de los usuarios*/
  update FORANEOS.Rol
  set estado=0
  where id = @rol_id;

end
GO
--Trigger Elimina los roles asociados a Rol dado de baja 
IF OBJECT_ID('FORANEOS.tr_eliminar_rol_baja') IS NOT NULL
	DROP TRIGGER FORANEOS.tr_eliminar_rol_baja;
GO
create trigger FORANEOS.tr_eliminar_rol_baja on FORANEOS.Rol
for update
as
begin
	delete FORANEOS.Rol_Usuario 
	where exists(select 1 from inserted where id_rol =id_rol)
end
GO
--Habilitar Rol 
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
--ObtenerRoles de Usuario 
IF OBJECT_ID('FORANEOS.obtenerRolesDeUsuario') IS NOT NULL
	DROP PROCEDURE FORANEOS.obtenerRolesDeUsuario;
GO
create procedure FORANEOS.obtenerRolesDeUsuario @idUsuario int

  as 
  Begin
   select r.id,r.nombre,f.id,f.nombre
     from FORANEOS.Funcionalidad f,FORANEOS.Funcionalidad_Rol fr,FORANEOS.Rol r,
	      FORANEOS.Usuario u, FORANEOS.Rol_Usuario ru
    where f.id=fr.id_funcionalidad
	  and r.id=fr.id_rol
	  and u.id=ru.id_usuario
	  and u.id=@idUsuario;
	end
GO
IF OBJECT_ID('FORANEOS.IntentoLogin','U') IS NOT NULL
	DROP TABLE FORANEOS.IntentoLogin;
GO
create table FORANEOS.IntentoLogin
(username varchar(255)
)
GO
--Intentar Login
IF OBJECT_ID('FORANEOS.login') IS NOT NULL
	DROP PROCEDURE FORANEOS.login;
GO
CREATE PROCEDURE FORANEOS.login(@usuario varchar(255),@password varbinary(8000))
AS
	declare @cantNok numeric
	declare @logOk numeric

	set @logOk = (select count(1) FROM FORANEOS.Usuario u WHERE username = @usuario
	AND password = @password
	and estado=1)

	if ( @logOk >0)
	begin
			DELETE FROM FORANEOS.IntentoLogin WHERE username = @usuario
	end
	else
	begin
	/*Agrego intento erroneo*/
		insert into FORANEOS.IntentoLogin values (@usuario)
	/*Si cantidad de intentos son mayor o igual a 3 desahibilito el usuario*/
		if ((select count(1) FROM FORANEOS.IntentoLogin u WHERE username = @usuario)>2)
		begin
			update FORANEOS.Usuario set estado = 0 where username = @usuario
			RAISERROR (40003,-1,-1, 'Usuario bloqueado!')
			select 0
			return;

	    end
	/*Devuelvo el error de logueo*/
		 if ((select count(1) FROM FORANEOS.Usuario where username = @usuario)=0)
			begin 
				RAISERROR (40001,-1,-1, 'El Usuario no existe!')
				select 0
				return;
			end
		 if ((select count(1) FROM FORANEOS.Usuario where username = @usuario and password = @password)=0)
			begin 
				RAISERROR (40002,-1,-1, 'Password incorrecta!')
				select 0
				return;
			end
	end
GO

-- Creacion afiliado
IF OBJECT_ID('FORANEOS.crearAfiliado') IS NOT NULL
	DROP PROCEDURE FORANEOS.crearAfiliado;
GO
create procedure FORANEOS.crearAfiliado 
(@username varchar, @password binary, @nombre varchar, 
 @apellido varchar, @dni numeric, @direccion varchar, @telefono numeric, @mail varchar, 
 @fechaNac numeric, @sexo numeric , @estadoCivil numeric, @familiaresACargo numeric, 
 @idPlanMedico numeric, @raizNumDeAfiliado numeric)

as 
declare @id_usu numeric
begin 

   insert into FORANEOS.usuario (username,password,nombre,apellido,dni,Direccion,telefono,mail,
                 fecha_nac,sexo,estado) 
   values (@username,HASHBYTES('SHA2_256',@password),@nombre,@apellido,@dni,@direccion,@telefono,@mail, 
                 @fechaNac,@sexo,1)

	set @id_usu = (select id from Usuario where username= @username)
	--falta generar el numero de afiliado, junto a la raiz
	insert into FORANEOS.Afiliado(id, numero_afiliado, estado_civil,familiares_a_cargo,codigo_plan) 
	values (@id_usu, @raizNumDeAfiliado,@estadoCivil,@familiaresACargo,@idPlanMedico)

end
GO

-- Creacion afiliado
IF OBJECT_ID('FORANEOS.modificarAfiliado') IS NOT NULL
	DROP PROCEDURE FORANEOS.modificarAfiliado;
GO
create procedure FORANEOS.modificarAfiliado 
(@id_afiliado numeric, @password binary, @direccion varchar, @telefono numeric, @mail varchar, 
 @sexo numeric , @estadoCivil numeric, @familiaresACargo numeric, @idPlanMedico numeric)

as 
declare @codigoPlan numeric
begin 

   update FORANEOS.usuario 
      set username=HASHBYTES('SHA2_256',@password) ,
		  password=@password,
		  Direccion=@direccion,
		  telefono=@telefono,
		  mail=@mail,
		  sexo=@sexo
    where id=@id_afiliado

	set @codigoPlan = (select codigo_plan from Afiliado where numero_afiliado= @id_afiliado)

	update FORANEOS.Afiliado
	   set estado_civil =@estadoCivil,
	       familiares_a_cargo= @familiaresACargo,
		   codigo_plan=@idPlanMedico

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

-- Habilitar Afiliado
IF OBJECT_ID('FORANEOS.habilitarAfiliado') IS NOT NULL
	DROP PROCEDURE FORANEOS.habilitarAfiliado;
GO
create procedure FORANEOS.habilitarAfiliado 
(@id_afiliado numeric)

as 
begin 
	update FORANEOS.Usuario
	   set estado=1
	 where id=@id_afiliado
end
GO
-- Eliminar Afiliado
IF OBJECT_ID('FORANEOS.eliminarAfiliado') IS NOT NULL
	DROP PROCEDURE FORANEOS.eliminarAfiliado;
GO
create procedure FORANEOS.eliminarAfiliado 
(@id_afiliado numeric)

as 
begin 
	update FORANEOS.Usuario
	   set estado=0
	 where id=@id_afiliado
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
--obtenerProfesionalPorDNI(dni)	idProfesional, nombre, apellido, codigoEspecialidad, descripcionEspecialidad, idAgenda
-- Obtener Profesional
IF OBJECT_ID('FORANEOS.obtenerProfesionalPorDNI') IS NOT NULL
	DROP PROCEDURE FORANEOS.obtenerProfesionalPorDNI;
GO
create procedure FORANEOS.obtenerProfesionalPorDNI(@dni numeric) 
as 
begin 
	select u.id, u.nombre,u.apellido, e.codigo cod_especialidad, e.descripcion especialidad, a.id agenda_id
 	  from FORANEOS.Usuario u, FORANEOS.Especialidad e,FORANEOS.Especialidad_Profesional ep,FORANEOS.Agenda a
	  where u.id=ep.id_profesional
	  and  ep.codigo_especialidad=e.codigo
	  and  ep.id_profesional=u.id
	  and u.dni=@dni
end
