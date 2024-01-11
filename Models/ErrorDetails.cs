using Newtonsoft.Json;

namespace Gudang_Super_Market.Models;

public class ErrorDetails
{
    public int StatusCode { get; set; }
    public string Message { get; set; }
    public string ExceptionMessage { get; set; }
    public string StackTrace { get; set; }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}