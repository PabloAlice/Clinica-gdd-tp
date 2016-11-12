-- Registrar atención médica
IF OBJECT_ID('FORANEOS.registrarAtencionMedica') IS NOT NULL
	DROP PROCEDURE FORANEOS.registrarAtencionMedica;
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
GO

-- Registrar llegada
IF OBJECT_ID('FORANEOS.registrarLlegada') IS NOT NULL
	DROP PROCEDURE FORANEOS.registrarLlegada;
GO
create procedure FORANEOS.registrarLlegada(@id_afiliado numeric, @nro_turno numeric, @fecha datetime)
  as 
begin
	UPDATE FORANEOS.Turno
	SET fecha_llegada = @fecha
	WHERE numero = @nro_turno

	INSERT INTO FORANEOS.Consulta_Medica(numero, numero_turno)
	values ((SELECT TOP 1 id FROM FORANEOS.Bono WHERE Bono.estado = 0), @nro_turno)
end
GO

-- Registrar turno
IF OBJECT_ID('FORANEOS.registrarTurno') IS NOT NULL
	DROP PROCEDURE FORANEOS.registrarTurno;
GO
create procedure FORANEOS.registrarTurno(@id_afiliado numeric, @id_horario numeric)
  as 
begin
	INSERT INTO FORANEOS.Turno(id_horario_atencion, id_afiliado)
	values (@id_horario, @id_afiliado)	
end
GO

-- Obtener profesionales del dia por
IF OBJECT_ID('FORANEOS.obtenerProfesionalesDelDiaPor') IS NOT NULL
	DROP PROCEDURE FORANEOS.obtenerProfesionalesDelDiaPor;
GO
create procedure FORANEOS.obtenerProfesionalesDelDiaPor(@nombre varchar(255), @apellido varchar(255), @cod_esp numeric, @fecha datetime)
  as 
begin
	SELECT u.id, u.nombre, u.apellido, e.descripcion 
	FROM FORANEOS.Usuario u, FORANEOS.Horario_Atencion ha, FORANEOS.Especialidad e, FORANEOS.Especialidad_Profesional ep
	WHERE (u.nombre = @nombre OR @nombre is null) AND (u.apellido = @apellido OR @apellido is null) 
		  AND (e.codigo = ep.codigo_especialidad OR @cod_esp is null)
		  AND (ha.fecha = @fecha OR @fecha is null)
		  AND u.id = ep.id_profesional AND ep.codigo_especialidad = e.codigo AND ha.id_agenda = u.id	
end
GO

-- Obtener turnos de un profesional
IF OBJECT_ID('FORANEOS.obtenerTurnosDeProfesional') IS NOT NULL
	DROP PROCEDURE FORANEOS.obtenerTurnosDeProfesional;
GO
create procedure FORANEOS.obtenerTurnosDeProfesional(@id_profesional numeric, @fecha datetime)
  as 
begin
	SELECT t.numero, u.id, a.numero_afiliado, u.nombre, u.apellido
	FROM FORANEOS.Turno t, FORANEOS.Horario_Atencion ha, FORANEOS.Afiliado a, FORANEOS.Usuario
	WHERE ha.fecha = @fecha AND ha.id_agenda = @id_profesional AND t.id_horario_atencion = ha.id
		  AND a.id = t.id_afiliado AND u.id = a.id	
end
GO


