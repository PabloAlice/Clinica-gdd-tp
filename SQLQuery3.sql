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
if object_id('FORANEOS.Tipo_Cancelacion') is not null
  drop table FORANEOS.Tipo_Cancelacion;
/*--------------------------------------------------------------------------------------------------------------*/
/* DROP Procedures y triggers */

/*Procedimientos y triggers*/
IF OBJECT_ID('FORANEOS.pa_migracion_maestra') is not null
drop proc FORANEOS.pa_migracion_maestra;

IF OBJECT_ID('FORANEOS.login') IS NOT NULL
    DROP PROCEDURE FORANEOS.login;

IF OBJECT_ID('FORANEOS.crearRol') IS NOT NULL
	DROP PROCEDURE FORANEOS.crearRol;

IF OBJECT_ID('FORANEOS.eliminarRol') IS NOT NULL
	DROP PROCEDURE FORANEOS.eliminarRol;

IF OBJECT_ID('FORANEOS.habilitarRol') IS NOT NULL
	DROP PROCEDURE FORANEOS.habilitarRol;

IF OBJECT_ID('FORANEOS.modificarRol') IS NOT NULL
	DROP PROCEDURE FORANEOS.modificarRol;

IF OBJECT_ID('FORANEOS.obtenerRolesXusuario') IS NOT NULL
   DROP PROCEDURE FORANEOS.obtenerRolesXusuario;

IF OBJECT_ID('FORANEOS.cantidadRoles') IS NOT NULL
   DROP PROCEDURE FORANEOS.cantidadRoles;

 IF OBJECT_ID('FORANEOS.obtenerFuncionalidadesXrol') IS NOT NULL
    DROP PROCEDURE FORANEOS.obtenerFuncionalidadesXrol;

IF OBJECT_ID('FORANEOS.obtenerFuncionalidades') IS NOT NULL
    DROP PROCEDURE FORANEOS.obtenerFuncionalidades;

IF OBJECT_ID('FORANEOS.obtenerIDrol') IS NOT NULL
    DROP PROCEDURE FORANEOS.obtenerIDrol;

IF OBJECT_ID('FORANEOS.obtenerIDfuncionalidad') IS NOT NULL
    DROP PROCEDURE FORANEOS.obtenerIDfuncionalidad;

IF OBJECT_ID('FORANEOS.obtenerRolesDeshabilitados') IS NOT NULL
	DROP PROCEDURE FORANEOS.obtenerRolesDeshabilitados;

IF OBJECT_ID('FORANEOS.obtenerRolesHabilitados') IS NOT NULL
	DROP PROCEDURE FORANEOS.obtenerRolesHabilitados;
IF OBJECT_ID('FORANEOS.obtenerRoles') IS NOT NULL
	DROP PROCEDURE FORANEOS.obtenerRoles;

IF OBJECT_ID('FORANEOS.habilitarAfiliado') IS NOT NULL
	DROP PROCEDURE FORANEOS.habilitarAfiliado;

IF OBJECT_ID('FORANEOS.eliminarAfiliado') IS NOT NULL
	DROP PROCEDURE FORANEOS.eliminarAfiliado;

IF OBJECT_ID('FORANEOS.obtenerPlanesMedicos') IS NOT NULL
	DROP PROCEDURE FORANEOS.obtenerPlanesMedicos;

IF OBJECT_ID('FORANEOS.obtenerProfesionalPorDNI') IS NOT NULL
	DROP PROCEDURE FORANEOS.obtenerProfesionalPorDNI;

IF OBJECT_ID('FORANEOS.afiliadosPorDNIeliminacion') IS NOT NULL
	DROP PROCEDURE FORANEOS.afiliadosPorDNIeliminacion;

IF OBJECT_ID('FORANEOS.afiliadosPorDNIhabilitacion') IS NOT NULL
	DROP PROCEDURE FORANEOS.afiliadosPorDNIhabilitacion;

IF OBJECT_ID('FORANEOS.afiliadosPorDNIhabilitacion') IS NOT NULL
	DROP PROCEDURE FORANEOS.afiliadosPorDNIhabilitacion;

IF OBJECT_ID('FORANEOS.tr_eliminar_rol_baja') IS NOT NULL
	DROP TRIGGER FORANEOS.tr_eliminar_rol_baja;

IF OBJECT_ID('FORANEOS.tr_cambioPlan') IS NOT NULL
	DROP TRIGGER FORANEOS.tr_cambioPlan;

IF OBJECT_ID('FORANEOS.tr_EliminaUsuario_Turnos') IS NOT NULL
	DROP TRIGGER FORANEOS.tr_EliminaUsuario_Turnos;

IF OBJECT_ID('FORANEOS.obtenerPlanesMedicos') IS NOT NULL
	DROP PROCEDURE FORANEOS.obtenerPlanesMedicos;

IF OBJECT_ID('FORANEOS.obtenerPlanMedicoPorID') IS NOT NULL
	DROP PROCEDURE FORANEOS.obtenerPlanMedicoPorID;

IF OBJECT_ID('FORANEOS.obtenerProfesionalPorDNI') IS NOT NULL
	DROP PROCEDURE FORANEOS.obtenerProfesionalPorDNI;

IF OBJECT_ID('FORANEOS.obtenerProfesionalesPorEspecialidad') IS NOT NULL
	DROP PROCEDURE FORANEOS.obtenerProfesionalesPorEspecialidad;

IF OBJECT_ID('FORANEOS.obtenerProfesionalesPorNyA') IS NOT NULL
	DROP PROCEDURE FORANEOS.obtenerProfesionalesPorNyA;

IF OBJECT_ID('FORANEOS.obtenerEspecialidades') IS NOT NULL
	DROP PROCEDURE FORANEOS.obtenerEspecialidades;

IF OBJECT_ID('FORANEOS.obtenerEspecialidadesPorProfesional') IS NOT NULL
	DROP PROCEDURE FORANEOS.obtenerEspecialidadesPorProfesional;

IF OBJECT_ID('FORANEOS.obtenerBonosPorNumeroAfiliado') IS NOT NULL
	DROP PROCEDURE FORANEOS.obtenerBonosPorNumeroAfiliado;

IF OBJECT_ID('FORANEOS.comprarBonos') IS NOT NULL
	DROP PROCEDURE FORANEOS.comprarBonos;

IF OBJECT_ID('FORANEOS.obtenerCantidadBonosDisponiblesPorAfiliado') IS NOT NULL
	DROP PROCEDURE FORANEOS.obtenerCantidadBonosDisponiblesPorAfiliado;

IF OBJECT_ID('FORANEOS.registrarTurno') IS NOT NULL
	DROP PROCEDURE FORANEOS.registrarTurno;

IF OBJECT_ID('FORANEOS.obtenerHorariosDisponiblesParaFecha') IS NOT NULL
	DROP PROCEDURE FORANEOS.obtenerHorariosDisponiblesParaFecha;

IF OBJECT_ID('FORANEOS.obtenerTurnosDeAfiliado') IS NOT NULL
	DROP PROCEDURE FORANEOS.obtenerTurnosDeAfiliado;

IF OBJECT_ID('FORANEOS.cancelarTurnoPorAfiliado') IS NOT NULL
	DROP PROCEDURE FORANEOS.cancelarTurnoPorAfiliado;

IF OBJECT_ID('FORANEOS.obtenerTurnosDeProfesionalDelDia') IS NOT NULL
	DROP PROCEDURE FORANEOS.obtenerTurnosDeProfesionalDelDia;

IF OBJECT_ID('FORANEOS.obtenerTurnosDeProfesionalDelDiaParaRegistroConsulta') IS NOT NULL
DROP PROCEDURE FORANEOS.obtenerTurnosDeProfesionalDelDiaParaRegistroConsulta;

IF OBJECT_ID('FORANEOS.cancelarDiaPorProfesional') IS NOT NULL
	DROP PROCEDURE FORANEOS.cancelarDiaPorProfesional;

IF OBJECT_ID('FORANEOS.cancelarTurnosPorProfesional') IS NOT NULL
	DROP PROCEDURE FORANEOS.cancelarTurnosPorProfesional;

IF OBJECT_ID('FORANEOS.registrarAgenda') IS NOT NULL
   DROP PROCEDURE FORANEOS.registrarAgenda;

IF OBJECT_ID('FORANEOS.yaTieneAgenda') IS NOT NULL
   DROP PROCEDURE FORANEOS.yaTieneAgenda;

IF OBJECT_ID('FORANEOS.registrarAtencionMedica') IS NOT NULL
	DROP PROCEDURE FORANEOS.registrarAtencionMedica;

IF OBJECT_ID('FORANEOS.registrarLlegada') IS NOT NULL
	DROP PROCEDURE FORANEOS.registrarLlegada;

IF OBJECT_ID('FORANEOS.topEspecialidadesMasBonosUsados') IS NOT NULL
	DROP PROCEDURE FORANEOS.topEspecialidadesMasBonosUsados;

IF OBJECT_ID('FORANEOS.topAfiliadoMasBonosComprados') IS NOT NULL
	DROP PROCEDURE FORANEOS.topAfiliadoMasBonosComprados;

IF OBJECT_ID('FORANEOS.topEspecialidadesMasCancelaciones') IS NOT NULL
	DROP PROCEDURE FORANEOS.topEspecialidadesMasCancelaciones;

IF OBJECT_ID('FORANEOS.topProfesionalesMasConsultadosPorPlan') IS NOT NULL
	DROP PROCEDURE FORANEOS.topProfesionalesMasConsultadosPorPlan;

IF OBJECT_ID('FORANEOS.topProfesionalesMenosHoras') IS NOT NULL
	DROP PROCEDURE FORANEOS.topProfesionalesMenosHoras;

IF OBJECT_ID('FORANEOS.consultarCambioDePlan') IS NOT NULL
	DROP PROCEDURE FORANEOS.consultarCambioDePlan;

IF OBJECT_ID('FORANEOS.insertarCambioPlan') IS NOT NULL
	DROP PROCEDURE FORANEOS.insertarCambioPlan;

IF OBJECT_ID('FORANEOS.crearAfiliado') IS NOT NULL
	DROP PROCEDURE FORANEOS.crearAfiliado;

IF OBJECT_ID('FORANEOS.modificarAfiliado') IS NOT NULL
	DROP PROCEDURE FORANEOS.modificarAfiliado;

IF OBJECT_ID('FORANEOS.obtenerRaizAfiliado') IS NOT NULL
	DROP PROCEDURE FORANEOS.obtenerRaizAfiliado;

IF OBJECT_ID('FORANEOS.afiliadosPorDNI') IS NOT NULL
	DROP PROCEDURE FORANEOS.afiliadosPorDNI;

	IF OBJECT_ID('FORANEOS.afiliadosPorID') IS NOT NULL
	DROP PROCEDURE FORANEOS.afiliadosPorID;

IF OBJECT_ID('FORANEOS.obtenerNumeroAfiliado') IS NOT NULL
	DROP PROCEDURE FORANEOS.obtenerNumeroAfiliado;

IF OBJECT_ID('FORANEOS.actualizarFamiliaresAfiliado') IS NOT NULL
	DROP PROCEDURE FORANEOS.actualizarFamiliaresAfiliado;

IF OBJECT_ID('FORANEOS.tr_EliminaUsuario_Turnos') IS NOT NULL
	DROP TRIGGER FORANEOS.tr_EliminaUsuario_Turnos;

IF OBJECT_ID('FORANEOS.tieneFamilia') IS NOT NULL
	DROP function FORANEOS.tieneFamilia;

IF OBJECT_ID('FORANEOS.fechasAgendaRegistradaProfesional') IS NOT NULL
    DROP PROCEDURE FORANEOS.fechasAgendaRegistradaProfesional;

/*--------------------------------------------------------------------------------------------------------------*/
/* DROP DE TYPES SEQUENCE Y OTROS */

IF TYPE_ID('FORANEOS.t_func') IS NOT NULL
	DROP TYPE FORANEOS.t_func;

IF TYPE_ID('FORANEOS.TablaHorarioType') IS NOT NULL
   DROP TYPE FORANEOS.TablaHorarioType;

IF OBJECT_ID('FORANEOS.sq_numeroAfiliado') IS NOT NULL
	DROP SEQUENCE FORANEOS.sq_numeroAfiliado

IF EXISTS (SELECT Name FROM sysindexes WHERE Name = 'compra_bono_index') 
DROP INDEX FORANEOS.compra_bono_index

IF EXISTS (SELECT Name FROM sysindexes WHERE Name = 'numero_afiliado_index') 
DROP INDEX FORANEOS.numero_afiliado_index


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
	estado bit DEFAULT 1,
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
	numero_afiliado numeric(18,0) UNIQUE,
	estado_civil numeric(1,0) , 
	familiares_a_cargo numeric(2,0),
	codigo_plan numeric(18,0) REFERENCES FORANEOS.Plan_Medico (codigo),
	fecha_inhabilitacion date,
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
	estado bit													-- SI ES NULL EL HORARIO ESTA HABILITADO, SI ESTA EN 1 ESTA CANCELADO
	primary key (id)
);
/*Creacion de Tabla de Turno*/
create table FORANEOS.Turno(
	numero numeric(18,0) identity(1,1),
	id_horario_atencion numeric(18,0) REFERENCES FORANEOS.Horario_Atencion(id), 
	id_afiliado numeric(18,0) REFERENCES FORANEOS.Afiliado(id),
	fecha_llegada datetime,
	primary key (numero)
);
/* Creacion de tabla Tipo_Cancelacion */
create table FORANEOS.Tipo_Cancelacion(
id numeric(18,0) identity(1,1),
tipo varchar(255),
primary key(id)
);
/* Creacion de tabla Cancelacion_Turno */
create table FORANEOS.Cancelacion_Turno(
	numero numeric(18,0) REFERENCES FORANEOS.Turno(numero),
	responsable bit,										-- El responsable es quien hizo la cancelacion, 0 afiliado, 1 profesional
	tipo numeric(18,0) REFERENCES FORANEOS.Tipo_Cancelacion(id),
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
	sintomas varchar(255),
	diagnostico varchar(255),
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
GO
create procedure FORANEOS.pa_migracion_maestra
AS
begin

/* Importacion de tipos_cancelacion */
insert into FORANEOS.Tipo_Cancelacion(tipo) values('Enfermedad');
insert into FORANEOS.Tipo_Cancelacion(tipo) values('Laboral');
insert into FORANEOS.Tipo_Cancelacion(tipo) values('Familiar');
insert into FORANEOS.Tipo_Cancelacion(tipo) values('Otro');

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
insert into FORANEOS.Funcionalidad values('Modificar datos');
insert into FORANEOS.Rol values('Afiliado',1);
insert into FORANEOS.Rol values('Administrativo',1);
insert into FORANEOS.Rol values('Profesional',1);

-- Asignar funcionalidades a rol AFILIADO
insert into FORANEOS.Funcionalidad_Rol (id_rol, id_funcionalidad)
values (1,4), (1,5), (1,8), (1,10), (1,11)

-- Asignar funcionalidades a rol ADMINISTRATIVO
insert into FORANEOS.Funcionalidad_Rol (id_rol, id_funcionalidad)
values (2,1),(2,2),(2,4),(2,6),(2,9),(2,3)

-- Asignar funcionalidades a rol PROFESIONAL
insert into FORANEOS.Funcionalidad_Rol (id_rol, id_funcionalidad)
values (3,7),(3,8)

--Crear sequence para raiz de numero de afiliado
CREATE SEQUENCE FORANEOS.sq_numeroAfiliado  
    START WITH 1  
    INCREMENT BY 1 ;  

/*Importacion de Usuarios Profesional*/
insert into FORANEOS.usuario (username,password,nombre,apellido,dni,direccion,telefono,mail,fecha_nac)
select medico_dni,medico_dni, medico_Nombre , medico_apellido, medico_dni, medico_Direccion, medico_telefono,medico_mail,medico_fecha_nac
from gd_esquema.Maestra
where medico_nombre is not null
group by medico_dni, medico_Nombre , medico_apellido, medico_dni, medico_Direccion, medico_telefono,medico_mail,medico_fecha_nac

/* Importacion de Profesionales */
insert into FORANEOS.Profesional (id,matricula)
select u.id,u.dni
from FORANEOS.Usuario u, gd_esquema.Maestra m
where m.Medico_Dni = u.dni AND m.Medico_Dni is not null
group by u.id,u.dni;

/* Asigno rol a Profesionales */
insert into FORANEOS.Rol_Usuario (id_usuario,id_rol)
select p.id,3 from FORANEOS.Profesional p

/* Migracion de Agendas */
insert into FORANEOS.Agenda(id)
select u.id
from FORANEOS.Usuario u, gd_esquema.Maestra m
where m.Medico_Dni = u.dni AND m.Medico_Dni is not null
group by u.id;

/* Importartacion Usuarios pacientes */
insert into FORANEOS.usuario (username,password,nombre,apellido,dni,direccion,telefono,mail,fecha_nac)
select paciente_dni, paciente_dni, Paciente_Nombre , paciente_apellido, paciente_dni, Paciente_Direccion, paciente_telefono,paciente_mail,paciente_fecha_nac
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

/*Importacion Afiliados-Pacientes*/
insert into FORANEOS.Afiliado(id,codigo_plan,numero_afiliado)
select u.id, m.Plan_Med_Codigo,(next value for FORANEOS.sq_numeroAfiliado)*100
from FORANEOS.Usuario u, gd_esquema.Maestra m
where m.Paciente_Dni = u.dni AND m.Paciente_Dni is not null
group by u.id, m.Plan_Med_Codigo;

/* Asigno rol a Afiliados */
insert into FORANEOS.Rol_Usuario (id_usuario,id_rol)
select a.id,1 from FORANEOS.Afiliado a

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
SET IDENTITY_INSERT FORANEOS.Turno ON
insert into FORANEOS.Turno(numero, id_afiliado, id_horario_atencion)
select m.Turno_Numero, u.id,h.id
from gd_esquema.Maestra m, FORANEOS.Usuario u, FORANEOS.Horario_Atencion h
where m.Paciente_Dni = u.dni AND h.id = m.Turno_Numero
group by m.Turno_Numero, u.id,h.id
SET IDENTITY_INSERT FORANEOS.Turno OFF

/* Migracion Bono */

SET IDENTITY_INSERT FORANEOS.Bono ON
insert into FORANEOS.Bono(id,codigo_plan,id_compra_bono)
select * from (select m.Bono_Consulta_Numero, m.Plan_Med_Codigo, a.numero_afiliado , (select cb.id from  FORANEOS.Compra_Bono cb where u.id = cb.id_afiliado AND cb.fecha = m.Compra_Bono_Fecha) as codigo_compra
from gd_esquema.Maestra m, FORANEOS.Usuario u, FORANEOS.Afiliado a
where m.Bono_Consulta_Numero is not null AND m.Compra_Bono_Fecha is not null AND u.dni = m.Paciente_Dni AND a.id = u.id) as sub_table
group by sub_table.Bono_Consulta_Numero, sub_table.codigo_compra, sub_table.Plan_Med_Codigo, sub_table.numero_afiliado
order by 1
SET IDENTITY_INSERT FORANEOS.Bono OFF

/* Migracion Consulta Medica */

insert into FORANEOS.Consulta_Medica(numero, diagnostico, sintomas, fecha_hora,numero_turno)
select m.Bono_Consulta_Numero, m.Consulta_Enfermedades, m.Consulta_Sintomas, m.Bono_Consulta_Fecha_Impresion, m.Turno_Numero
from gd_esquema.Maestra m
where m.Bono_Consulta_Numero is not null AND m.Turno_Numero is not null
group by m.Bono_Consulta_Numero, m.Consulta_Enfermedades, m.Consulta_Sintomas, m.Bono_Consulta_Fecha_Impresion, m.Turno_Numero
order by 1

/* Creacion de Administrador General */

INSERT INTO FORANEOS.Usuario (username, password, nombre, apellido, dni, Direccion, telefono, mail, fecha_nac, sexo, intentos_login, estado)
values ('admin', HASHBYTES('SHA2_256', 'w23e'), 'admin', 'general', 12345678, 'medrano 2558', 46971658, 'admingen@gmail.com', '1992-05-08 12:35:29.00', 1, 0, 1)

declare @user_id numeric(18,0)
set @user_id = @@IDENTITY

INSERT INTO FORANEOS.Profesional (id, matricula)
values (@user_id, 123456789)

INSERT INTO FORANEOS.Agenda (id)
values (@user_id)

INSERT INTO FORANEOS.Especialidad_Profesional (id_profesional, codigo_especialidad)
values (@user_id, 10017)

INSERT INTO FORANEOS.Rol(nombre, estado)
values ('Administrador General', 1)

declare @rol_id numeric(18,0)
set @rol_id = @@IDENTITY

INSERT INTO FORANEOS.Rol_Usuario(id_rol,id_usuario)
values (@rol_id,@user_id)

INSERT INTO FORANEOS.Funcionalidad_Rol(id_funcionalidad, id_rol)
values (1,@rol_id), (2,@rol_id), (3,@rol_id), (4,@rol_id), (6,@rol_id), (7,@rol_id), (8,@rol_id), (9,@rol_id)

END

/*Procedimientos y triggers*/

--Login
GO

CREATE PROCEDURE FORANEOS.login(@UserName varchar(255), @Password varchar(255))
AS

begin

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

end



--/*ABM roles*/

--Type Funcionalidades

GO

create type FORANEOS.t_func as table
(id int);
   

  
--Crear Rol 

GO
create procedure FORANEOS.crearRol 
(@rol varchar(255),
@func FORANEOS.t_func READONLY)

as 
declare @id_rol int;

 begin
   SET NOCOUNT ON

if exists(select 1 from FORANEOS.Rol where nombre = @rol)
 begin

  RAISERROR (40000,-1,-1, 'Ya existe un rol con ese nombre')
  return;

 end

else

 begin
   insert into Rol (nombre,estado) values (@rol,1);
   
   set @id_rol =(select id
   from FORANEOS.Rol
   where nombre=@rol)

   insert into FORANEOS.Funcionalidad_Rol (id_rol,id_funcionalidad) 
   (select  @id_rol, id from @func)

 end

end



--Modificar Rol
GO
create procedure FORANEOS.modificarRol 
(@rol_id numeric,
@rol varchar(255),
@func FORANEOS.t_func READONLY)

as 

begin 

if exists(select 1 from FORANEOS.Rol where nombre = @rol and id<>@rol_id)
 begin

  RAISERROR (40000,-1,-1, 'Ya existe un rol con ese nombre')
  return;

 end

else

 begin

   delete FORANEOS.Funcionalidad_Rol where id_rol=@rol_id

   update FORANEOS.Rol
   set nombre = @rol where @rol_id = id

   insert into FORANEOS.Funcionalidad_Rol (id_rol,id_funcionalidad) 
   (select @rol_id,id from @func)
 
end

end



--Eliminar rol
GO
create procedure FORANEOS.eliminarRol
(@rol_id int)
as 
 begin
  update FORANEOS.Rol
  set estado=0
  where id = @rol_id;

  delete FORANEOS.Rol_Usuario 
	where  id_rol =@rol_id;

end



--Habilitar rol
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



--Cantidad de roles por usuario
GO

CREATE PROCEDURE FORANEOS.cantidadRoles(@UserName varchar(255))
AS

begin

select COUNT(*)
from FORANEOS.usuario, FORANEOS.rol_usuario
where usuario.username=@UserName
and usuario.id=rol_usuario.id_usuario

end



--Roles por usuario
GO

CREATE PROCEDURE FORANEOS.obtenerRolesXusuario(@UserName varchar(255))
AS

begin
select rol.nombre
from FORANEOS.rol INNER JOIN Rol_Usuario ON rol.id = Rol_Usuario.id_rol
INNER JOIN Usuario ON Rol_Usuario.id_usuario = Usuario.id 
where username = @Username
end



--Obtener funcionalidades
GO
create procedure FORANEOS.obtenerFuncionalidades
  as 
 begin
  
   select id,nombre
   from FORANEOS.Funcionalidad;
 end

 

 --Obtener funcionalidades por rol
GO
create procedure FORANEOS.obtenerFuncionalidadesXrol(@nombreRol varchar(255))
  as 
 begin
  
   select Funcionalidad.nombre
   from FORANEOS.Funcionalidad INNER JOIN FORANEOS.Funcionalidad_Rol ON Funcionalidad.id = Funcionalidad_Rol.id_funcionalidad
   INNER JOIN Rol ON rol.id = Funcionalidad_Rol.id_rol
   where rol.nombre = @nombreRol
 end

 

 --Obtener ID de rol
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

 

 --Obtener ID de funcionalidad
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


 
 --Obtener roles deshabilitados
GO
create procedure FORANEOS.obtenerRolesDeshabilitados

  as 
begin
   select id,nombre from FORANEOS.Rol
   where estado = 0
end



--Obtener roles habilitados
GO
create procedure FORANEOS.obtenerRolesHabilitados

  as 
begin
   select id,nombre from FORANEOS.Rol
   where estado = 1
end



--Obtener roles
GO
create procedure FORANEOS.obtenerRoles

  as 
begin
   select id,nombre from FORANEOS.Rol
end



--/*ABM afiliados*/

--Crear afiliado
GO 
create procedure FORANEOS.crearAfiliado (@username varchar(255),@password varchar(255),@nombre varchar(255),
@apellido varchar(255),@dni numeric(18,0),@direccion varchar(255),@telefono numeric(18,0),@mail varchar(255),
@fecha_nac datetime,@sexo bit,@numero_afiliado numeric(18,0),@estado_civil numeric(1,0),@familiares numeric(2,0),
@plan varchar(255))
as
begin

declare @codigo_plan numeric(18,0)
declare @id_usuario numeric(18,0)

if exists(select 1 from FORANEOS.Usuario where username = @username)
 begin

  RAISERROR (40000,-1,-1, 'Ya existe un afiliado con ese nombre de usuario')
  return;

 end
else
 begin

set @codigo_plan = (select codigo from FORANEOS.Plan_Medico where descripcion = @plan)

insert into FORANEOS.Usuario(username,password,nombre,apellido,dni,Direccion,telefono,mail,fecha_nac,sexo,intentos_login,estado)
values(@username,HASHBYTES('SHA2_256',@password),@nombre,@apellido,@dni,@direccion,@telefono,@mail,@fecha_nac,@sexo,0,1)

set @id_usuario = @@IDENTITY

insert into FORANEOS.Afiliado(id,numero_afiliado,estado_civil,familiares_a_cargo,codigo_plan)
values(@id_usuario,@numero_afiliado,@estado_civil,@familiares,@codigo_plan)

insert into FORANEOS.Rol_Usuario(id_rol, id_usuario)
values(1,@id_usuario)
	
end

end

GO 

create procedure FORANEOS.modificarAfiliado (@direccion varchar(255),@telefono numeric(18,0),@mail varchar(255),
@sexo bit,@numero_afiliado numeric(18,0),@estado_civil numeric(1,0),@password varchar(255),@plan varchar(255))
as
begin

declare @codigo_plan numeric(18,0)
declare @id_usuario numeric(18,0)

set @id_usuario = (select id from FORANEOS.Afiliado where numero_afiliado = @numero_afiliado)
set @codigo_plan = (select codigo from FORANEOS.Plan_Medico where descripcion = @plan)

IF @password IS NOT NULL 

begin

 update foraneos.Usuario 
 set Direccion = @direccion,telefono = @telefono, mail = @mail, sexo = @sexo, password = HASHBYTES('SHA2_256',@password) where id = @id_usuario

end
else
 
 begin
 
 update foraneos.Usuario 
 set Direccion = @direccion,telefono = @telefono, mail = @mail, sexo = @sexo where id = @id_usuario

 end

update FORANEOS.Afiliado

set estado_civil = @estado_civil, codigo_plan = @codigo_plan where id = @id_usuario
 
end


--obtenerRaizAfiliado
GO 
create procedure FORANEOS.obtenerRaizAfiliado
as
begin
declare @numero int

	set @numero =  next value for FORANEOS.sq_numeroAfiliado

	select @numero
end


--Obtener afiliado por id

GO
create procedure FORANEOS.afiliadosPorID(@id numeric(18,0)) 
as
begin

	select * from FORANEOS.Usuario u
	INNER JOIN FORANEOS.Afiliado a on u.id = a.id
	where u.id = @id

end

--Obtener afiliado por dni
GO
create procedure FORANEOS.afiliadosPorDNI(@dni numeric(18,0)) 
as
begin

declare @cantUser int

set @cantUser = (select count(*) from FORANEOS.Usuario u inner join FORANEOS.Afiliado a on 
                 u.id = a.id where dni = @dni)

if(@cantUser = 0)
begin

RAISERROR (40004,-1,-1, 'No existen afiliados con ese DNI')
			return;

end

else
begin

	select * from FORANEOS.Usuario u
	INNER JOIN foraneos.Afiliado a on u.id = a.id
	where u.dni = @dni

end

end


--Obtener numero de afiliado
GO
create procedure FORANEOS.obtenerNumeroAfiliado(@id_user numeric(18,0))

as 
begin 
	declare @nro_afiliado numeric (18,0)

	set @nro_afiliado = (select numero_afiliado from FORANEOS.Afiliado a inner join FORANEOS.Usuario u
	on a.id = u.id where a.id = @id_user)

	select @nro_afiliado

end

GO
create procedure FORANEOS.actualizarFamiliaresAfiliado(@nroAfiliado numeric(18,0), @familiares numeric(2,0))

as 
begin 

    update FORANEOS.Afiliado
    set familiares_a_cargo = @familiares where @nroAfiliado = numero_afiliado

end



-- Habilitar Afiliado

GO
create procedure FORANEOS.habilitarAfiliado(@dni_afiliado numeric(18,0))

as 
begin 

declare @idUser numeric(18,0)

set @idUser = (select id from FORANEOS.Usuario where dni = @dni_afiliado)
 
	update FORANEOS.Usuario
	   set estado=1
	 where dni=@dni_afiliado

    update FORANEOS.Afiliado
	   set fecha_inhabilitacion = null where id = @idUser
end


-- Eliminar Afiliado
GO
create procedure FORANEOS.eliminarAfiliado 
(@dni_afiliado numeric(18,0),@fecha date)

as 
begin

declare @idUser numeric(18,0)

set @idUser = (select id from FORANEOS.Usuario where dni = @dni_afiliado)
 
	update FORANEOS.Usuario
	   set estado=0
	 where dni=@dni_afiliado

	update FORANEOS.Afiliado
	   set fecha_inhabilitacion = @fecha where id = @idUser

end


--Obtener afiliados por dni para eliminacion
GO

create procedure FORANEOS.afiliadosPorDNIeliminacion(@dni numeric(18,0)) 
as	
begin

declare @cantUser int

set @cantUser = (select count(*) from FORANEOS.Usuario u inner join FORANEOS.Afiliado a on 
                 u.id = a.id where dni = @dni)

if(@cantUser = 0)
	begin

		RAISERROR (40004,-1,-1, 'No existen afiliados con ese DNI')
		return;

	end

else
	begin

		if(0 = (select estado from FORANEOS.Usuario where dni = @dni))
			begin

				RAISERROR (40005,-1,-1, 'El usuario ya se encuentra deshabilitado')
				return;

		end

	end
	
	select * from FORANEOS.Usuario u, FORANEOS.Afiliado a
	where a.id = u.id AND u.dni = @dni;	

end



--Obtener afiliados por dni para habilitacion
GO
create procedure FORANEOS.afiliadosPorDNIhabilitacion(@dni numeric(18,0)) 
as
begin

declare @cantUser int

set @cantUser = (select count(*) from FORANEOS.Usuario u inner join FORANEOS.Afiliado a on 
                 u.id = a.id where dni = @dni)

if(@cantUser = 0)
begin

RAISERROR (40004,-1,-1, 'No existen afiliados con ese DNI')
			return;

end

else
begin

if(1 = (select estado from FORANEOS.Usuario where dni = @dni))
begin

RAISERROR (40005,-1,-1, 'El usuario ya se encuentra habilitado')
			return;

end
	select * from FORANEOS.Usuario u
	INNER JOIN foraneos.Afiliado a on u.id = a.id
	where u.dni = @dni

end

end




--/*Planes medicos*/

-- Obtener Planes Medicos

GO
create procedure FORANEOS.obtenerPlanesMedicos 
as 
begin 
	select codigo, descripcion,bono_consulta,bono_farmacia
 	  from Plan_Medico
end

GO

-- Obtener plan de usuario
GO
create procedure FORANEOS.obtenerPlanMedicoPorID(@idPlan numeric(18,0))
as 
begin 
	select descripcion from Plan_Medico where codigo = @idPlan
end



--/*ABM profesionales*/

--Obtener profesionales por dni
GO
create procedure FORANEOS.obtenerProfesionalPorDNI(@dni numeric(18,0)) 
as 
begin

if not exists(select 1 from FORANEOS.Usuario u inner join FORANEOS.Profesional p
	on u.id = p.id where u.dni = @dni)

begin

RAISERROR (40005,-1,-1, 'No existe un profesional con ese DNI')
				return;

end
else

 begin

	select * from FORANEOS.Usuario u inner join FORANEOS.Profesional p
	on u.id = p.id where u.dni = @dni
 end

end



-- Obtener profesional por especialidad
GO
create procedure FORANEOS.obtenerProfesionalesPorEspecialidad(@especialidad varchar(255))
  as 
begin
   select u.id,u.nombre, u.apellido
   from FORANEOS.Usuario u inner join FORANEOS.Especialidad_Profesional ep on u.id = ep.id_profesional
   inner join FORANEOS.Especialidad e on e.codigo = ep.codigo_especialidad
   where e.descripcion = @especialidad
end


--Obtener profesionales por nombre y apellido
GO
create procedure FORANEOS.obtenerProfesionalesPorNyA(@nombre varchar(255),@apellido varchar(255))
  as 
begin

if not exists(select 1 from FORANEOS.Usuario u inner join FORANEOS.Profesional p on u.id = p.id
   inner join FORANEOS.Especialidad_Profesional ep on ep.id_profesional = p.id
   inner join FORANEOS.Especialidad e on e.codigo = ep.codigo_especialidad
   where u.nombre = @nombre and u.apellido = @apellido)

begin

RAISERROR (40008,-1,-1, 'No existen profesionales con ese nombre y apellido')
			return;

end
else
begin
   select u.id,u.nombre, u.apellido,descripcion
   from FORANEOS.Usuario u inner join FORANEOS.Profesional p on u.id = p.id
   inner join FORANEOS.Especialidad_Profesional ep on ep.id_profesional = p.id
   inner join FORANEOS.Especialidad e on e.codigo = ep.codigo_especialidad
   where u.nombre = @nombre and u.apellido = @apellido
end
end



/*Especialidades*/

-- Obtener Especialidades
GO
create procedure FORANEOS.obtenerEspecialidades
  as 
begin
   select codigo,descripcion
   from FORANEOS.Especialidad
end
GO
GO
create procedure FORANEOS.obtenerEspecialidadesPorProfesional(@idAfiliado numeric(18,0))
  as 
begin
   select codigo,descripcion
   from FORANEOS.Especialidad e inner join FORANEOS.Especialidad_Profesional ep on e.codigo = ep.codigo_especialidad
   inner join FORANEOS.Profesional p on ep.id_profesional = p.id where p.id = @idAfiliado

end


/*Bonos*/

-- Obtener bonos por numero de afiliado
GO
create procedure FORANEOS.obtenerBonosPorNumeroAfiliado(@nro_afiliado numeric)
  as 
begin

if not exists(select 1 from FORANEOS.Afiliado where @nro_afiliado = numero_afiliado)
 begin
 
  RAISERROR (40008,-1,-1, 'No existen afiliados con ese numero')
			return;
 end
else
 begin
   select id,numero_afiliado, codigo, bono_consulta
   from FORANEOS.Afiliado, FORANEOS.Plan_Medico
   where Afiliado.numero_afiliado = @nro_afiliado and Plan_Medico.codigo = Afiliado.codigo_plan
end
end


--Comprar Bonos
GO 
create procedure FORANEOS.comprarBonos 
(@idAfiliado numeric, @nroAfiliado numeric, @codigoPlan numeric, @cantidad numeric,@fecha_compra datetime)
as
begin
declare @inc numeric
declare @idCompraBono numeric

set @inc = 1

if ((select estado from FORANEOS.usuario where id=@idAfiliado) = 1 )
begin

insert into FORANEOS.compra_bono(fecha,id_afiliado) values (@fecha_compra,@idAfiliado);

set @idCompraBono = @@IDENTITY

WHILE @inc <= @cantidad 
 BEGIN
          insert into FORANEOS.bono(numero_afiliado, estado, id_compra_bono, codigo_plan)
          values(@nroAfiliado, 0, @idCompraBono, @codigoPlan)
         SET @inc = @inc + 1;
 END

end

end



-- Obtener Cantidad de Bonos Disponibles por Afiliado
GO
create procedure FORANEOS.obtenerCantidadBonosDisponiblesPorAfiliado(@id_afiliado numeric)
  as 
begin
	DECLARE @nro_afiliado numeric
	SET @nro_afiliado = CAST((SELECT numero_afiliado FROM FORANEOS.Afiliado 
							WHERE id = @id_afiliado) as nvarchar(32));

	SELECT COUNT(id) FROM FORANEOS.Bono
	WHERE (LEFT(numero_afiliado, (LEN(numero_afiliado)-1))) LIKE (LEFT(@nro_afiliado, (LEN(@nro_afiliado)-1)))
		  AND estado = 0 AND codigo_plan = (select a.codigo_plan from FORANEOS.Afiliado a where a.id = @id_afiliado)
end


/* Turnos */


-- Registrar turno
GO
create procedure FORANEOS.registrarTurno(@id_afiliado numeric, @id_horario numeric)
  as 
begin

declare @id_turno numeric(18,0)

	INSERT INTO FORANEOS.Turno(id_horario_atencion, id_afiliado)
	values (@id_horario, @id_afiliado)	

	set @id_turno = @@identity

	select @id_turno

end



-- Obtener horarios disponibles de profesional
GO
Create Procedure FORANEOS.obtenerHorariosDisponiblesParaFecha(@idProfesional numeric(18,0),@codigoEspecialidad numeric(18,0), @fecha date)
	as
	
	select ha.id,ha.fecha
	from FORANEOS.Horario_Atencion ha 
	where ha.id_agenda = @idProfesional AND ha.codigo_especialidad = @codigoEspecialidad AND convert(DATE,ha.fecha) = @fecha AND ha.estado is null AND not exists (select t.id_horario_atencion
																																								from FORANEOS.Turno t
																																								where t.id_horario_atencion = ha.id AND not exists (select ct.numero
																																																					from FORANEOS.Cancelacion_Turno ct
																																																					where ct.numero = t.numero ) )  	


-- Obtener Turnos De Afiliado

GO
create procedure FORANEOS.obtenerTurnosDeAfiliado(@id_afiliado numeric(18,0))
  as 
begin

	SELECT distinct t.numero,u.nombre,u.apellido,e.descripcion,ht.fecha FROM FORANEOS.Afiliado a inner join FORANEOS.Turno t
	on a.id = t.id_afiliado inner join FORANEOS.Horario_Atencion ht on ht.id = t.id_horario_atencion
	inner join FORANEOS.Agenda ag on ag.id = ht.id_agenda inner join FORANEOS.Profesional p on p.id = ag.id
	 inner join FORANEOS.Usuario u on u.id = p.id inner join FORANEOS.Especialidad e on ht.codigo_especialidad = e.codigo inner join  FORANEOS.Especialidad_Profesional ep
	 on ep.codigo_especialidad = e.codigo where a.id = @id_afiliado AND not exists (select ct.numero from FORANEOS.Cancelacion_Turno ct where ct.numero = t.numero)

end


--Cancelar turno por parte de afiliado
GO
create Procedure FORANEOS.cancelarTurnoPorAfiliado(@idAfiliado numeric, @idTurno numeric, @idTipoCancelacion numeric, @motivo varchar(255))
	as
		insert into FORANEOS.Cancelacion_Turno(numero,tipo,motivo,responsable)
		values(@idTurno,@idTipoCancelacion,@motivo,0)

GO

-- Obtener turnos de un profesional para registro llegada

create procedure FORANEOS.obtenerTurnosDeProfesionalDelDia(@id_profesional numeric, @fecha varchar(30))
  as 
begin

	SELECT t.numero, u.id, a.numero_afiliado, u.nombre,ha.fecha, u.apellido
    from FORANEOS.Profesional p inner join FORANEOS.Horario_Atencion ha on p.id = ha.id_agenda inner join FORANEOS.Turno t on t.id_horario_atencion = ha.id inner join FORANEOS.Afiliado a on
	a.id = t.id_afiliado inner join FORANEOS.Usuario u on a.id = u.id where p.id = @id_profesional and convert(date,ha.fecha) = @fecha AND t.fecha_llegada is null
    and t.numero not in (select ct.numero from FORANEOS.Cancelacion_Turno ct)
			
end

GO
-- Obtener turnos de un profesional para registro consulta

create procedure FORANEOS.obtenerTurnosDeProfesionalDelDiaParaRegistroConsulta(@id_profesional numeric, @fecha varchar(30))
  as 
begin

	SELECT t.numero, u.id, a.numero_afiliado, u.nombre,ha.fecha, u.apellido
    from FORANEOS.Profesional p inner join FORANEOS.Horario_Atencion ha on p.id = ha.id_agenda inner join FORANEOS.Turno t on t.id_horario_atencion = ha.id inner join FORANEOS.Afiliado a on
	a.id = t.id_afiliado inner join FORANEOS.Usuario u on a.id = u.id where p.id = @id_profesional and convert(date,ha.fecha) = @fecha AND t.fecha_llegada is not null
	AND t.numero not in (select numero_turno from FORANEOS.Consulta_Medica where fecha_hora is not null)
			
end




--Cancelar turnos del dia del profesional
GO
create Procedure FORANEOS.cancelarDiaPorProfesional(@idProfesional numeric, @fecha date,@idTipoCancelacion numeric,@motivo varchar(255))
	as
	begin transaction

		update FORANEOS.Horario_Atencion
		set estado = 1
		where CONVERT(DATE,fecha) = @fecha AND id_agenda = @idProfesional;

		insert into FORANEOS.Cancelacion_Turno(numero, tipo, motivo,responsable)	
		select t.numero, @idTipoCancelacion, @motivo, 1 
		from FORANEOS.Horario_Atencion ha, FORANEOS.Turno t 
		where t.id_horario_atencion = ha.id AND convert(DATE,ha.fecha) = @fecha AND ha.id_agenda = @idProfesional AND not exists (select ct.numero
																																	from  FORANEOS.Cancelacion_Turno ct
																																	where ct.numero = t.numero)

		
	commit
GO 


--Cancelar periodo de turnos del profesional
GO
create Procedure FORANEOS.cancelarTurnosPorProfesional(@idProfesional numeric, @fecha date, @fechainicio datetime,@fechafin datetime,@idTipoCancelacion numeric,@motivo varchar(255))
	as
	begin transaction

	update FORANEOS.Horario_Atencion
		set estado = 1
		where @fecha = cast(fecha as date) AND cast(fecha as time) >= cast(@fechainicio as time) AND cast(fecha as time) <= cast(@fechafin as time) AND id_agenda = @idProfesional 

		insert into FORANEOS.Cancelacion_Turno(numero, tipo, motivo,responsable)	
		select t.numero, @idTipoCancelacion, @motivo, 1 
		from FORANEOS.Horario_Atencion ha, FORANEOS.Turno t 
		where t.id_horario_atencion = ha.id AND @fecha = cast(fecha as date) AND cast(fecha as time) BETWEEN cast(@fechainicio as time) AND cast(@fechafin as time) AND ha.id_agenda = @idProfesional AND not exists (select ct.numero
																																												from  FORANEOS.Cancelacion_Turno ct
																																												where ct.numero = t.numero)

		
	commit
GO



/* Agenda */

CREATE TYPE FORANEOS.TablaHorarioType AS TABLE   
( dia int, 
  horaInicio varchar(30),
  horafin varchar(30),
  codigoEspecialidad int 
);  

--Registrar agenda de profesional

GO
Create Procedure FORANEOS.registrarAgenda(@idProfesional numeric(18,0), @fechaInicio datetime, @fechaFin datetime, @horarios FORANEOS.TablaHorarioType READONLY)
	as
	
	if exists(select 1 from FORANEOS.Agenda where id = @idProfesional and (fecha_inicio is not null or fecha_fin is not null))
	 begin

	 update FORANEOS.Agenda
	  set fecha_fin = @fechaFin
	  where id = @idProfesional;

	 end
	else
	 begin
	
	  update FORANEOS.Agenda
	  set fecha_inicio = @fechaInicio, fecha_fin = @fechaFin
	  where id = @idProfesional;
	
	 end

	declare @auxDate datetime;
	declare @auxHora int;

	declare @horaInicio datetime;
	declare @horaFin datetime;
	declare @dia datetime;
	declare @codigoEspecialidad int;

		set @auxDate = @fechaInicio;
		set @auxDate = (select DATEADD(MINUTE,-DATEPART(MINUTE,@auxDate),@auxDate));
		set @auxDate = (select DATEADD(HOUR,-DATEPART(HOUR,@auxDate),@auxDate));
		set @horaFin = @auxDate;

		while( CONVERT(DATE,@auxDate) <= CONVERT(DATE,@fechaFin))
			begin

				IF(exists(select dia from @horarios where DATEPART(WEEKDAY,@auxDate) = dia))
					begin
						SET @codigoEspecialidad = (select codigoEspecialidad from @horarios where DATEPART(WEEKDAY,@auxDate) = dia)
						set @auxHora = DATEPART(hour,(select horaInicio from @horarios where DATEPART(WEEKDAY,@auxDate) = dia));
						set @auxDate = (select DATEADD(hour,@auxHora,@auxDate));
						set @auxHora = DATEPART(MINUTE,(select horaInicio from @horarios where DATEPART(WEEKDAY,@auxDate) = dia));
						set @auxDate = (select DATEADD(minute,@auxHora,@auxDate));
						
						set @auxHora = DATEPART(HOUR,(select horafin from @horarios where DATEPART(WEEKDAY,@auxDate) = dia));
						set @horaFin = (select DATEADD(HOUR,@auxHora,@horaFin));
						set @auxHora = DATEPART(MINUTE,(select horafin from @horarios where DATEPART(WEEKDAY,@auxDate) = dia));
						set @horaFin = (select DATEADD(minute,@auxHora,@horaFin));

						while(DATEPART(HOUR,@auxDate) < DATEPART(HOUR,@horafin))
							begin
								insert into FORANEOS.Horario_Atencion(id_agenda,fecha,codigo_especialidad)
								values(@idProfesional,@auxDate,@codigoEspecialidad)
								set @auxDate = (select DATEADD(minute,30,@auxDate));
	
							end

							if(DATEPART(MINUTE,@auxdate)<DATEPART(MINUTE,@horaFin))
								begin
									insert into FORANEOS.Horario_Atencion(id_agenda,fecha,codigo_especialidad)
									values(@idProfesional,@auxDate,@codigoEspecialidad)
									set @auxDate = (select DATEADD(minute,30,@auxDate));
								end

						set @auxDate = (select DATEADD(minute,-DATEPART(MINUTE,@auxDate),@auxDate));
						set @auxDate = (select DATEADD(HOUR,-DATEPART(HOUR,@auxDate),@auxDate));

						set @horaFin = (select DATEADD(minute,-DATEPART(MINUTE,@horaFin),@horaFin));
						set @horaFin = (select DATEADD(HOUR,-DATEPART(HOUR,@horaFin),@horaFin));
					end
				set @auxDate = (select DATEADD(DAY,1,@auxDate));
	
		end		
		

--Chequea si el profesional ya tiene agenda
GO
Create Procedure FORANEOS.yaTieneAgenda(@idProfesional numeric(18,0))
	as

if exists(select 1 from FORANEOS.Agenda where id = @idProfesional and (fecha_inicio is not null or fecha_fin is not null))
 begin

select 1

 end
 else

 select 0

GO


Create Procedure FORANEOS.fechasAgendaRegistradaProfesional(@idProfesional numeric(18,0))
	as

begin

select * from FORANEOS.Agenda where id = @idProfesional

end

GO

/* Registro consulta */

-- Registrar atención médica
GO
create procedure FORANEOS.registrarAtencionMedica(@nro_turno numeric, @fecha datetime, @sintomas varchar(255), @diagnostico varchar(255))
  as 
begin
	UPDATE FORANEOS.Consulta_Medica
	SET fecha_hora = @fecha, 
		sintomas = @sintomas,
		diagnostico = @diagnostico
	WHERE numero_turno = @nro_turno
end

/* Registro llegada */

-- Registrar llegada
GO
create procedure FORANEOS.registrarLlegada(@id_afiliado numeric, @nro_turno numeric, @fecha datetime)
  as 
begin

declare @numero_afiliado numeric
declare @nro_bono numeric


	UPDATE FORANEOS.Turno
	SET fecha_llegada = @fecha
	WHERE numero = @nro_turno

	set @numero_afiliado = (select numero_afiliado from FORANEOS.Afiliado where id = @id_afiliado)

	set @nro_bono = (select top 1 id from FORANEOS.Bono where LEFT(numero_afiliado, (LEN(numero_afiliado)-1)) = LEFT(@numero_afiliado, (LEN(@numero_afiliado)-1)) and estado = 0)

	INSERT INTO FORANEOS.Consulta_Medica(numero,numero_turno)
	values(@nro_bono,@nro_turno) 

	update FORANEOS.Bono

    set estado = 1 where id = @nro_bono

end

/*Estadisticas*/

--Top especialidades con mas bonos usados
GO
create Procedure FORANEOS.topEspecialidadesMasBonosUsados(@anio numeric, @semestre numeric)
	as

	select TOP 5 e.descripcion, COUNT(*) cantidad
	from FORANEOS.Bono b, FORANEOS.Consulta_Medica cm, FORANEOS.Turno t, FORANEOS.Horario_Atencion ha, FORANEOS.Especialidad e
	where b.id = cm.numero AND cm.numero_turno = t.numero AND t.id_horario_atencion = ha.id AND ha.codigo_especialidad = e.codigo AND YEAR(cm.fecha_hora)=@anio AND CEILING(MONTH(cm.fecha_hora)/6.00)=@semestre
	group by e.descripcion
	order by 2 DESC

GO

create  index compra_bono_index on FORANEOS.Compra_Bono (id_afiliado);
GO

create nonclustered index numero_afiliado_index on FORANEOS.Afiliado (numero_afiliado);
GO
--funcion 

create function FORANEOS.tieneFamilia (@numeroAfiliado numeric) 
returns numeric
as
begin
declare @tieneFamilia numeric
set @tieneFamilia = (select count(1) from FORANEOS.Afiliado where CEILING(numero_afiliado/100)=CEILING(@numeroAfiliado/100))
	 if (@tieneFamilia =1)
	   --begin
	    set @tieneFamilia=  0
	 if (@tieneFamilia >1)
	    set @tieneFamilia= 1
 return @tieneFamilia

End
GO

create Procedure FORANEOS.topAfiliadoMasBonosComprados (@anio numeric, @semestre numeric)
	as
select top 5 a.nombre, a.apellido, FORANEOS.tieneFamilia(a.numero_afiliado), a.bonosComprados
from (
select  u.id,u.nombre, u.apellido, a.numero_afiliado,
       COUNT(1) as bonosComprados

		from FORANEOS.Compra_Bono cb , FORANEOS.Bono b, FORANEOS.Afiliado a, FORANEOS.Usuario u
		where a.id = cb.id_afiliado AND a.id = u.id 
		and cb.id=b.id_compra_bono
		AND YEAR(cb.fecha)=@anio
		AND CEILING(MONTH(cb.fecha)/6.00)=@semestre
	group by u.id,u.nombre, u.apellido, a.numero_afiliado
	) a
order by 4 DESC 

	
--Top especialidades mas cancelaciones
GO
 create procedure [FORANEOS].[topEspecialidadesMasCancelaciones](@anio numeric, @semestre numeric)
 as
 begin
   select top 5 DATENAME(month,ha.fecha) mes,e.descripcion , count(1) cantidad 
	 from FORANEOS.cancelacion_turno ct,FORANEOS.turno t,
	      FORANEOS.horario_atencion ha, FORANEOS.especialidad e
	where ct.numero=t.numero
	  and t.id_horario_atencion=ha.id
	  and ha.codigo_especialidad= e.codigo
	  and year(ha.fecha) = @anio
	  and CEILING(MONTH(ha.fecha)/6.00)=@semestre
	group by DATENAME(month,ha.fecha),e.descripcion
	order by 3 desc
 end

--Top profesionales mas consultados
GO
 create procedure FORANEOS.topProfesionalesMasConsultadosPorPlan(@anio numeric, @semestre numeric)
 as
 begin
 select top 5 
	DATENAME(month,cm.fecha_hora) mes,u.nombre, u.apellido,e.descripcion desc_esp,pm.descripcion desc_plan, count(1) cantidad 
	 from FORANEOS.Usuario u, 
	      FORANEOS.Profesional p,
		  FORANEOS.Agenda a,
	      FORANEOS.especialidad e,
		  FORANEOS.Especialidad_Profesional ep ,
		  FORANEOS.Horario_Atencion ha,
		  FORANEOS.Turno t, 
		  FORANEOS.Consulta_Medica cm, 
		  FORANEOS.Bono b,
		  FORANEOS.Plan_Medico pm
	where u.id=p.id
	  and p.id = ep.id_profesional
	  and ep.codigo_especialidad= e.codigo
	  and p.id =a.id
	  and a.id=ha.id_agenda
	  and e.codigo=ha.codigo_especialidad
	  and ha.id=t.id_horario_atencion
	  and t.numero=cm.numero_turno
	  and cm.numero=b.id
	  and b.codigo_plan=pm.codigo
	  and year(cm.fecha_hora) = @anio
	  and CEILING(MONTH(cm.fecha_hora)/6.00)= @semestre
	group by DATENAME(month,cm.fecha_hora),u.nombre, u.apellido,e.descripcion,pm.descripcion
	order by 6 desc
 end

 --Top profesionales menos horas trabajadas
GO
create procedure [FORANEOS].[topProfesionalesMenosHoras](@codigoPlan numeric, @codigoEspecialidad numeric, @anio numeric, @semestre numeric)
 as
 begin
   select top 5 DATENAME(month,cm.fecha_hora) mes,u.nombre, u.apellido, (count(1)*0.5) hs_trabajadas 
	 from FORANEOS.Usuario u, 
	      FORANEOS.Profesional p,
		  FORANEOS.Agenda a,
	      FORANEOS.especialidad e,
		  FORANEOS.Especialidad_Profesional ep ,
		  FORANEOS.Horario_Atencion ha,
		  FORANEOS.Turno t, 
		  FORANEOS.Consulta_Medica cm, 
		  FORANEOS.Bono b,
		  FORANEOS.Plan_Medico pm
	where u.id=p.id
	  and u.id = ep.id_profesional
	  and ep.codigo_especialidad= e.codigo
	  and p.id =a.id
	  and a.id=ha.id_agenda
	  and e.codigo=ha.codigo_especialidad
	  and ha.id=t.id_horario_atencion
	  and t.numero=cm.numero
	  and cm.numero=b.id
	  and b.codigo_plan=pm.codigo
	  and year(cm.fecha_hora) =@anio 
	  and CEILING(MONTH(cm.fecha_hora)/6.00)=@semestre
	  and pm.codigo=@codigoPlan
	  and e.codigo=@codigoEspecialidad
	group by  DATENAME(month,cm.fecha_hora),u.nombre, u.apellido,e.codigo
	order by 4
 end

 /*Plan*/
GO
 create Procedure FORANEOS.consultarCambioDePlan(@idAfiliado numeric)
 as

 select cp.codigo_plan, cp.fecha_baja, cp.motivo
 from FORANEOS.Cambio_De_Plan cp
 where cp.id_afiliado = @idAfiliado
 

GO
 create procedure FORANEOS.insertarCambioPlan(@plan varchar(255),@numero_afiliado numeric(18,0),@fechaCambio DateTime,@motivo varchar(255))
 as
 begin
 
 declare @idPlan numeric(18,0)
 declare @id_usuario numeric(18,0)

 set @idPlan = (select codigo from Plan_Medico where descripcion = @plan)
 set @id_usuario = (select id from FORANEOS.Afiliado where numero_afiliado = @numero_afiliado)

 insert into FORANEOS.Cambio_De_Plan(codigo_plan,id_afiliado,fecha_baja,motivo)
 values(@idPlan,@id_usuario,@fechaCambio,@motivo)

 end


 GO
 
 /*Triggers*/

create trigger FORANEOS.tr_EliminaUsuario_Turnos on FORANEOS.Usuario
for update
as
declare @id_usuario numeric

begin
	if((select estado from inserted) = 0)
		begin
			set @id_usuario = (select id from inserted)
			delete FORANEOS.Turno 
			where id_afiliado = @id_usuario AND not exists(select ct.numero from FORANEOS.Cancelacion_Turno ct where ct.numero = numero) 
			and fecha_llegada is null
		 end
end
GO
	exec FORANEOS.pa_migracion_maestra
GO