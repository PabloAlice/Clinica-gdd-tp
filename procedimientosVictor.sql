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
	  and t.numero=cm.numero
	  and cm.numero=b.id
	  and b.codigo_plan=pm.codigo
	  and year(cm.fecha_hora) = @anio
	  and CEILING(MONTH(cm.fecha_hora)/6.00)= @semestre
	group by DATENAME(month,cm.fecha_hora),u.nombre, u.apellido,e.descripcion,pm.descripcion
	order by 6 desc
 end

GO
 
--topProfesionalesMenosHoras
IF OBJECT_ID('FORANEOS.topProfesionalesMenosHoras') IS NOT NULL
	DROP PROCEDURE FORANEOS.topProfesionalesMenosHoras;
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

/*Objetos para Top Afiliados con Mas Bonos Comprados*/
use GD2C2016

--indices
IF EXISTS (SELECT Name FROM sysindexes WHERE Name = 'compra_bono_index') 
DROP INDEX FORANEOS.compra_bono_index;

GO
create  index compra_bono_index on FORANEOS.Compra_Bono (id_afiliado);
GO
IF EXISTS (SELECT Name FROM sysindexes WHERE Name = 'numero_afiliado_index') 
DROP INDEX FORANEOS.numero_afiliado_index;
GO
create nonclustered index numero_afiliado_index on FORANEOS.Afiliado (numero_afiliado);
GO
--funcion 
IF OBJECT_ID('FORANEOS.tieneFamilia') IS NOT NULL
	DROP function FORANEOS.tieneFamilia;
GO
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

--procedure
IF OBJECT_ID('FORANEOS.topAfiliadoMasBonosComprados') IS NOT NULL
	DROP Procedure FORANEOS.topAfiliadoMasBonosComprados;
GO
create Procedure FORANEOS.topAfiliadoMasBonosComprados (@anio numeric, @semestre numeric)
	as
select top 5 a.nombre, a.apellido, FORANEOS.tieneFamilia(a.numero_afiliado), a.bonosComprados
from (
select  u.id,u.nombre, u.apellido, a.numero_afiliado,
       COUNT(1) as bonosComprados

		from FORANEOS.Compra_Bono cb , FORANEOS.Afiliado a, FORANEOS.Usuario u
		where a.id = cb.id_afiliado AND a.id = u.id 
		AND YEAR(cb.fecha)=@anio
		AND CEILING(MONTH(cb.fecha)/6.00)=@semestre
	group by u.id,u.nombre, u.apellido, a.numero_afiliado
	) a
order by 4 DESC 



