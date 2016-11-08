/*PROCEDIMIENTOS*/



/*TRIGGERS*/


USE GD2C2016

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
for update
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

