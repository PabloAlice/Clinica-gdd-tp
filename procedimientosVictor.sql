use GD2C2016

--topEspecialidadesMasCancelaciones
IF OBJECT_ID('FORANEOS.topEspecialidadesMasCancelaciones') IS NOT NULL
	DROP PROCEDURE FORANEOS.topEspecialidadesMasCancelaciones;
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
 GO
--topEspecialidadesMasCancelaciones
IF OBJECT_ID('FORANEOS.topProfesionalesMasConsultadosPorPlan') IS NOT NULL
	DROP PROCEDURE FORANEOS.topProfesionalesMasConsultadosPorPlan;
GO
 create procedure FORANEOS.topProfesionalesMasConsultadosPorPlan(@anio numeric, @semestre numeric)
 as
 begin
   select top 5 DATENAME(month,cm.fecha_hora) mes,u.nombre, u.apellido,e.descripcion desc_esp,pm.descripcion desc_plan, count(1) cantidad 
	 from FORANEOS.Usuario u, FORANEOS.Afiliado a, FORANEOS.Plan_Medico pm, 
	      FORANEOS.especialidad e,FORANEOS.Especialidad_Profesional ep, FORANEOS.Horario_Atencion ha,
		  FORANEOS.Turno t, FORANEOS.Consulta_Medica cm
	where u.id=a.id
	  and a.codigo_plan=pm.codigo
	  and u.id = ep.id_profesional
	  and ep.codigo_especialidad= e.codigo
	  and e.codigo=ha.codigo_especialidad
	  and ha.id=t.id_horario_atencion
	  and t.numero=cm.numero
	  and year(cm.fecha_hora) = @anio
	  and CEILING(MONTH(cm.fecha_hora)/6.00)=@semestre
	group by DATENAME(month,cm.fecha_hora),u.nombre, u.apellido,e.descripcion,pm.descripcion
	order by 6 desc
 end

GO
 --topEspecialidadesMasCancelaciones
IF OBJECT_ID('FORANEOS.topProfesionalesMenosHoras') IS NOT NULL
	DROP PROCEDURE FORANEOS.topProfesionalesMenosHoras;
GO
 create procedure FORANEOS.topProfesionalesMenosHoras(@codigoPlan numeric, @codigoEspecialidad numeric, @anio numeric, @semestre numeric)
 as
 begin
   select top 5 DATENAME(month,cm.fecha_hora) mes,u.nombre, u.apellido, (count(1)*0.5) hs_trabajadas 
	 from FORANEOS.Usuario u, FORANEOS.Afiliado a, FORANEOS.Plan_Medico pm, 
	      FORANEOS.especialidad e,FORANEOS.Especialidad_Profesional ep, FORANEOS.Horario_Atencion ha,
		  FORANEOS.Turno t, FORANEOS.Consulta_Medica cm
	where u.id=a.id
	  and a.codigo_plan=pm.codigo
	  and u.id = ep.id_profesional
	  and ep.codigo_especialidad= e.codigo
	  and e.codigo=ha.codigo_especialidad
	  and ha.id=t.id_horario_atencion
	  and t.numero=cm.numero
	  and year(cm.fecha_hora) = @anio
	  and CEILING(MONTH(cm.fecha_hora)/6.00)=@semestre
	  and pm.codigo=@codigoPlan
	  and e.codigo=@codigoEspecialidad
	group by DATENAME(month,cm.fecha_hora),u.nombre, u.apellido
	order by 4
 end
 
  --eliminar Rol
IF OBJECT_ID('FORANEOS.eliminarRol') IS NOT NULL
	DROP PROCEDURE FORANEOS.eliminarRol;
GO
 CREATE procedure [FORANEOS].[eliminarRol]
(@rol_id int)
as 
 begin
  update FORANEOS.Rol
  set estado=0
  where id = @rol_id;

  delete FORANEOS.Rol_Usuario 
	where  id_rol =@rol_id;
end
