USE GD2C2016

BEGIN TRANSACTION

INSERT INTO FORANEOS.Usuario (username, password, nombre, apellido, dni, Direccion, telefono, mail, fecha_nac, sexo, intentos_login, estado)
values ('matiminian', HASHBYTES('SHA2_256', '1234'), 'matias', 'minian', 37143632, 'medrano 2558', 46971658, 'minian.matias@gmail.com', '1992-05-08 12:35:29.00', 1, 0, 1)

declare @user_id numeric(18,0)
set @user_id = @@IDENTITY

INSERT INTO FORANEOS.Profesional (id, matricula)
values (@user_id, 123456789)

INSERT INTO FORANEOS.Agenda (id)
values (@user_id)

INSERT INTO FORANEOS.Especialidad_Profesional (id_profesional, codigo_especialidad)
values (@user_id, 10017)

INSERT INTO FORANEOS.Rol_Usuario(id_rol,id_usuario)
values (1,@user_id), (2,@user_id), (3,@user_id)

COMMIT

