using CarBook.Application.Features.Commands.CarCommands;
using CarBook.Application.Features.Handlers.CarHandlers;
using CarBook.Application.Features.Queries.CarQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace CarBook.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarsController : ControllerBase
{
    private readonly CreateCarCommandHandler _createCarCommandHandler;
    private readonly UpdateCarCommandHandler _updateCarCommandHandler;
    private readonly RemoveCarCommandHandler _removeCarCommandHandler;
    private readonly GetCarQueryHandler _getCarQueryHandler;
    private readonly GetCarByIdQueryHandler _getCarByIdQueryHandler;
    private readonly GetCarWithBrandQueryHandler _getCarWithBrandQueryHandle;


    public CarsController(CreateCarCommandHandler createCarCommandHandler, UpdateCarCommandHandler updateCarCommandHandler, RemoveCarCommandHandler removeCarCommandHandler, GetCarQueryHandler getCarQueryHandler, GetCarByIdQueryHandler getCarByIdQueryHandler, GetCarWithBrandQueryHandler getCarWithBrandQueryHandle)
    {
        _createCarCommandHandler = createCarCommandHandler;
        _updateCarCommandHandler = updateCarCommandHandler;
        _removeCarCommandHandler = removeCarCommandHandler;
        _getCarQueryHandler = getCarQueryHandler;
        _getCarByIdQueryHandler = getCarByIdQueryHandler;
        _getCarWithBrandQueryHandle = getCarWithBrandQueryHandle;
    }

    [HttpGet]
    public async Task<IActionResult> CarList()
    {
        var values = await _getCarQueryHandler.Handle();
        return Ok(values);
    }
    [HttpPost]
    public async Task<IActionResult> CreateCar(CreateCarCommand command)
    {
        await _createCarCommandHandler.Handle(command);
        return Ok("Kayıt Eklendi");
    }
    [HttpDelete]
    public async Task<IActionResult> RemoveCar(int id)
    {
        await _removeCarCommandHandler.Handle(new RemoveCarCommand(id));
        return Ok("Kayıt Silindi");
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCar(int id)
    {
        var value = await _getCarByIdQueryHandler.Handle(new GetCarByIdQuery(id));
        return Ok(value);
    }
    [HttpGet("CarsListWithBrands")]
    public async Task<IActionResult> GetCarsListWithBrands()
    {
        var value = await _getCarWithBrandQueryHandle.Handle();
        return Ok(value);
    }
    [HttpPut]
    public async Task<IActionResult> UpdateCar(UpdateCarCommand command)
    {
        await _updateCarCommandHandler.Handle(command);
        return Ok("Kayıt Güncellendi");
    }
}
