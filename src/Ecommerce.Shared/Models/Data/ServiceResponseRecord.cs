namespace Ecommerce.Shared.Models.Data
{
    public sealed record ServiceResponseRecord<T>
    {
        public T? Data { get; set; }
        public bool Success { get; set; } = true;
        public string Message { get; set; } = string.Empty;
    }
}
