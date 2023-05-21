using universidad.Service;
using Microsoft.AspNetCore.Mvc;
namespace universidad.MapControllers;

//atributos para los controles
[ApiController]
[Route("[controller]")]

public class RegionController: ControllerBase
{

        IRegionService RegionService;
    public RegionController(IRegionService serviceRegion) => RegionService = serviceRegion;

    //atributos para los endpoint 

    //Create
    [HttpPost]
public async Task<IRegionResult> PostRegions([FromBody] Region newRegion) {
    await RegionService.insertar(newRegion);
    var result = newRegion.RegionId;
    if(result == null){
        return BadRequest();
    }
return Ok("Se ingreso Correctamente");

}
//Read
[HttpGet]
public IRegionResult GetRegion() {

return Ok(RegionService.obtener());
}

//Update
[HttpPut("{id}")]
public IRegionResult UpdateRegion([FromBody] Region RegionActualizar, Guid id) {
    RegionService.Actualizar(id,RegionActualizar);
return Ok("Actualizado Corretcamente");
}

//Delete
[HttpDelete("{id}")]

public IRegionResult DeleteRegion(Guid id) {
return Ok(RegionService.eliminar(id));



}




}