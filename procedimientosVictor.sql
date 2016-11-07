
--obtenerRaizAfiliado
GO
IF OBJECT_ID('FORANEOS.obtenerRaizAfiliado') IS NOT NULL
	DROP PROCEDURE FORANEOS.obtenerRaizAfiliado;
GO 
create procedure FORANEOS.obtenerRaizAfiliado (@numero numeric out)
as
begin
	set @numero =  next value for FORANEOS.sq_numeroAfiliado
end
GO

--Comprar Bonos
IF OBJECT_ID('FORANEOS.comprarBonos') IS NOT NULL
	DROP PROCEDURE FORANEOS.comprarBonos;
GO 
create procedure FORANEOS.comprarBonos 
(@idAfiliado numeric, @nroAfiliado numeric, @codigoPlan numeric, @cantidad numeric)
as
declare @inc numeric
declare @fecha_compra date
begin
set @fecha_compra =  getdate()

if ((select estado from FORANEOS.usuario where id=@idAfiliado) = 1 )
  WHILE @inc <= @cantidad 
	BEGIN
	   insert into FORANEOS.compra_bono(fecha,id_afiliado) values (@fecha_compra,@idAfiliado);
	   SET @inc = @inc + 1;
	END
	 
	insert into FORANEOS.bono(numero_afiliado, estado, id_compra_bono, codigo_plan)
	select id_afiliado,0,id,@codigoPlan
	  from FORANEOS.compra_bono
	 where id_afiliado=@nroAfiliado
	   and fecha=@fecha_compra
end


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