namespace SproutHackathon.Services.Models.Shared
{
    public class ResultWrapper<T>
    {
        public T Result { get; set; }
        public int Status { get; set; }
    }
}