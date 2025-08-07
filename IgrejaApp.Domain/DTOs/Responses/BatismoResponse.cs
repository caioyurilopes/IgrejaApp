namespace IgrejaApp.Domain.DTOs.Responses;

public class BatismoResponse
{
    public int Id { get; set; }
    public DateTime Data { get; set; }
    public string? Igreja { get; set; }

    public int? PastorId { get; set; }
    public PastorResponse? Pastor { get; set; }
    public string? PastorNomeManual { get; set; }
}