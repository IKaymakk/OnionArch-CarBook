namespace CarBook.Application.Mediator.Services.Results;

public class GetServiceByIdQueryResult
{
    public int ServiceId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string IconUrl { get; set; }
}
