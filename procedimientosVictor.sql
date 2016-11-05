
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