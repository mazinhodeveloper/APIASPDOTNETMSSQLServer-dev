// API/Models/ErrorViewModel.cs
namespace APIASPDOTNETMSSQLServer.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}