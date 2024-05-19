namespace MPTWA_Infrastructure.Services;

public class RequestLogBaseModel
{
        public Guid Id { get; set; }
        public string Section { get; set; }
        public string KeyWord { get; set; }
        public List<ResultLogBaseModel> Results { get; set; }
}

public class ResultLogBaseModel
{
        public Guid Id { get; set; }
        public DateTime CreateTime { get; set; } 
        public int VowelsCount { get; set; }
        public string SearchText { get; set; }
        public Guid RequestLogBaseModelId { get; set; }
}
