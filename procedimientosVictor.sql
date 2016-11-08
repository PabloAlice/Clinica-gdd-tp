

--topEspecialidadesMasCancelaciones
IF OBJECT_ID('FORANEOS.topEspecialidadesMasCancelaciones') IS NOT NULL
	DROP PROCEDURE FORANEOS.topEspecialidadesMasCancelaciones;
GO
 ALTER procedure [FORANEOS].[topEspecialidadesMasCancelaciones](@anio numeric, @semestre numeric)
 as
 begin
   select top 5 e.descripcion , count(1) cantidad 
	 from FORANEOS.cancelacion_turno ct,FORANEOS.turno t, 
	      FORANEOS.horario_atencion ha, FORANEOS.especialidad e
	where ct.numero=t.numero
	  and t.id_horario_atencion=ha.id
	  and ha.codigo_especialidad= e.codigo
	  and year(ha.fecha) = @anio
	  and CEILING(MONTH(ha.fecha)/6.00)=@semestre
	group by e.descripcion
	order by 2 desc
 end

