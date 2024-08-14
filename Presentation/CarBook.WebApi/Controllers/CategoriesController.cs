using CarBook.Application.Features.Commands.CategoryCommands;
using CarBook.Application.Features.Handlers.AboutHandlers;
using CarBook.Application.Features.Handlers.CategoryHandlers;
using CarBook.Application.Features.Queries.CategoryQueries;
using CarBook.Application.Features.Results.CategoryResults;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly CreateCategoryCommandHandler createCategoryCommandHandler;
    private readonly GetCategoryByIdQueryHandler getCategoryByIdQueryHandler;
    private readonly GetCategoryQueryHandler getCategoryQueryHandler;
    private readonly RemoveCategoryCommandHandler removeCategoryCommandHandler;
    private readonly UpdateCategoryCommandHandler updateCategoryCommandHandler;
    private readonly GetCategoriesWithBlogCountsQueryHandler getCategoriesWithBlogCountsQueryHandler;

    public CategoriesController(CreateCategoryCommandHandler createCategoryCommandHandler, GetCategoryByIdQueryHandler getCategoryByIdQueryHandler, GetCategoryQueryHandler getCategoryQueryHandler, RemoveCategoryCommandHandler removeCategoryCommandHandler, UpdateCategoryCommandHandler updateCategoryCommandHandler, GetCategoriesWithBlogCountsQueryHandler getCategoriesWithBlogCountsQueryHandler)
    {
        this.createCategoryCommandHandler = createCategoryCommandHandler;
        this.getCategoryByIdQueryHandler = getCategoryByIdQueryHandler;
        this.getCategoryQueryHandler = getCategoryQueryHandler;
        this.removeCategoryCommandHandler = removeCategoryCommandHandler;
        this.updateCategoryCommandHandler = updateCategoryCommandHandler;
        this.getCategoriesWithBlogCountsQueryHandler = getCategoriesWithBlogCountsQueryHandler;
    }

    [HttpGet]
    public async Task<IActionResult> SCategorieslist()
    {
        var values = await getCategoryQueryHandler.Handle();
        return Ok(values);
    }
    [HttpGet("CategoriesWithBlogCounts")]
    public async Task<IActionResult> GetCategoriesListWithBlogCounts()
    {
        var values = await getCategoriesWithBlogCountsQueryHandler.Handle();
        return Ok(values);
    }
    [HttpPost]
    public async Task<IActionResult> CreateCategory(CreateCategoryCommand command)
    {
        await createCategoryCommandHandler.Handle(command);
        return Ok("Kayıt Eklendi");
    }

    [HttpDelete]
    public async Task<IActionResult> RemoveCategory(int id)
    {
        await removeCategoryCommandHandler.Handle(new RemoveCategoryCommand(id));
        return Ok("Kayıt Silindi");
    }
    [HttpPut]

    public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand command)
    {
        await updateCategoryCommandHandler.Handle(command);
        return Ok("Kayıt Güncellendi");
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategory(int id)
    {
        var values = await getCategoryByIdQueryHandler.Handle(new GetCategoryByIdQuery(id));
        return Ok(values);
    }
}
