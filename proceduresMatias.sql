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

-- Obtener Turnos De Afiliado
IF OBJECT_ID('FORANEOS.obtenerTurnosDeAfiliado') IS NOT NULL
	DROP PROCEDURE FORANEOS.obtenerTurnosDeAfiliado;
GO
create procedure FORANEOS.obtenerTurnosDeAfiliado(@id_afiliado numeric)
  as 
begin
	SELECT numero, fecha, nombre, apellido, descripcion
	FROM FORANEOS.Turno, FORANEOS.Horario_Atencion, FORANEOS.Usuario, FORANEOS.Afiliado, FORANEOS.Especialidad, FORANEOS.Especialidad_Profesional, FORANEOS.Profesional, FORANEOS.Agenda
	WHERE Turno.id_afiliado = @id_afiliado AND Horario_Atencion.id = Turno.id_horario_atencion AND Turno.id_afiliado = Afiliado.id
		  AND Usuario.id = Afiliado.id AND Especialidad.codigo = Especialidad_Profesional.codigo_especialidad
		  AND Especialidad_Profesional.id_profesional = Profesional.id AND Agenda.id = Profesional.id AND  Horario_Atencion.id_agenda = Agenda.id	
end
GO

