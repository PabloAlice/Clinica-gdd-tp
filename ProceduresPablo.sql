GO
/* Create a table type. */  

IF OBJECT_ID('FORANEOS.registrarAgenda') IS NOT NULL
   DROP PROCEDURE FORANEOS.registrarAgenda;

IF TYPE_ID('FORANEOS.TablaHorarioType') IS NOT NULL
   DROP TYPE FORANEOS.TablaHorarioType;

CREATE TYPE FORANEOS.TablaHorarioType AS TABLE   
( dia int, 
  horaInicio datetime,
  horafin datetime,
  codigoEspecialidad int 
);  

GO
Create Procedure FORANEOS.registrarAgenda(@idProfesional numeric(18,0), @fechaInicio datetime, @fechaFin datetime, @horarios FORANEOS.TablaHorarioType READONLY)
	as
	
	update FORANEOS.Agenda
	set fecha_inicio = @fechaInicio, fecha_fin = @fechaFin
	where id = @idProfesional;

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

		while( CONVERT(DATE,@auxDate) < CONVERT(DATE,@fechaFin))
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
									set @auxDate = (select DATEADD(minute,30,@auxDate));
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
		
GO

Create Procedure FORANEOS.obtenerHorariosDisponiblesParaFecha(@idProfesional numeric(18,0),@codigoEspecialidad numeric(18,0), @fecha date)
	as
	
	select ha.id,ha.fecha from FORANEOS.Horario_Atencion ha where ha.id_agenda = @idProfesional AND ha.codigo_especialidad = @codigoEspecialidad AND convert(DATE,ha.fecha) = @fecha AND ha.id != (select t.numero
																																																	from FORANEOS.Turno t
																																																	where t.numero = ha.id)  	

GO

create Procedure FORANEOS.obtenerTiposDeCancelacion
	as

	select * from FORANEOS.Tipo_Cancelacion;

GO

create Procedure FORANEOS.cancelarTurnoPorAfiliado(@idAfiliado numeric, @idTurno numeric, @idTipoCancelacion numeric, @motivo varchar(255))
	as
		insert into FORANEOS.Cancelacion_Turno(numero,tipo,motivo,responsable)
		values(@idTurno,@idTipoCancelacion,@motivo,0)

GO

create Procedure FORANEOS.cancelarDiaPorProfesional(@idProfesional numeric, @fecha date,@idTipoCancelacion numeric,@motivo varchar(255))
	as
	begin transaction
		insert into FORANEOS.Cancelacion_Turno(numero, tipo, motivo,responsable)	
		select t.numero, @idTipoCancelacion, @motivo, 1 
		from FORANEOS.Horario_Atencion ha, FORANEOS.Turno t 
		where t.id_horario_atencion = ha.id AND convert(DATE,ha.fecha) = @fecha AND ha.id_agenda = @idProfesional AND t.numero != (select ct.numero
																																	from  FORANEOS.Cancelacion_Turno ct
																																	where ct.numero = t.numero)

		update FORANEOS.Horario_Atencion
		set estado = 1
		where convert(DATE,fecha) = @fecha AND id_agenda = @idProfesional;
	commit
GO 

create Procedure FORANEOS.cancelarTurnosPorProfesional(@idProfesional numeric, @fecha date, @fechainicio datetime,@fechafin datetime,@idTipoCancelacion numeric,@motivo varchar(255))
	as
	begin transaction
		insert into FORANEOS.Cancelacion_Turno(numero, tipo, motivo,responsable)	
		select t.numero, @idTipoCancelacion, @motivo, 1 
		from FORANEOS.Horario_Atencion ha, FORANEOS.Turno t 
		where t.id_horario_atencion = ha.id AND @fecha = cast(fecha as date) AND cast(fecha as time) BETWEEN cast(@fechainicio as time) AND cast(@fechafin as time) AND ha.id_agenda = @idProfesional AND t.numero != (select ct.numero
																																												from  FORANEOS.Cancelacion_Turno ct
																																												where ct.numero = t.numero)

		update FORANEOS.Horario_Atencion
		set estado = 1
		where cast(fecha as time) BETWEEN cast(@fechainicio as time) AND cast(@fechafin as time) AND id_agenda = @idProfesional
	commit
GO

create Procedure FORANEOS.topEspecialidadesMasBonosUsados(@anio numeric, @semestre numeric)
	as

	select TOP 5 e.descripcion, COUNT(*)
	from FORANEOS.Bono b, FORANEOS.Consulta_Medica cm, FORANEOS.Turno t, FORANEOS.Horario_Atencion ha, FORANEOS.Especialidad e
	where b.id = cm.numero AND cm.numero_turno = t.numero AND t.id_horario_atencion = ha.id AND ha.codigo_especialidad = e.codigo AND YEAR(cm.fecha_hora)=@anio AND CEILING(MONTH(cm.fecha_hora)/6.00)=@semestre
	group by e.descripcion
	order by 2 DESC

GO

create Procedure FORANEOS.topAfiliadoMasBonosComprados(@anio numeric, @semestre numeric)
	as

	select TOP 5 nombre,apellido,tieneFamilia, COUNT(*) as bonosComprados
	from
		(select u.nombre, u.apellido,CASE
										WHEN(select COUNT(*) as tieneFamilia from FORANEOS.Afiliado af where LEFT(af.numero_afiliado, (LEN(af.numero_afiliado)-2)) = LEFT(a.numero_afiliado, (LEN(a.numero_afiliado)-2))) > 1 
										THEN 1
										ELSE 0  
										END as tieneFamilia
		from FORANEOS.Compra_Bono cb , FORANEOS.Afiliado a, FORANEOS.Usuario u
		where a.id = cb.id_afiliado AND a.id = u.id AND YEAR(cb.fecha)=@anio AND CEILING(MONTH(cb.fecha)/6.00)=@semestre) as topMasBonosComprados 

	group by nombre, apellido, tieneFamilia
	order by 4 DESC