namespace MPTWA_Infrastructure.Models.Responses;

public class GetNewsResponse
{
    public int totalResults { get; set; }
    public string? code { get; set; }
    public string? message { get; set; }
    public string status { get; set; }
    public List<article> articles { get; set; } = new();
}

public class source
{
    public string id { get; set; }
    public string name { get; set; }
}

public class article
{
    public source source { get; set; }
    public string author { get; set; }
    public string title { get; set; }
    public string description { get; set; }
    public string url { get; set; }
    public string urlToImage { get; set; }
    public DateTime publishedAt { get; set; }
    public string content { get; set; }
}