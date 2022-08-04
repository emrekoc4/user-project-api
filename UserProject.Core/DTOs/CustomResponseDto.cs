using System.Text.Json.Serialization;

namespace UserProject.Core.DTOs
{
    public class CustomResponseDto<T>
    {
        public T Data { get; set; }
        [JsonIgnore] //not returning to the clients because they already get the status from uı
        public int StatusCode { get; set; }
        public int Id { get; set; }
        public List<string> Errors { get; set; }


        //static factory method design pattern
        public static CustomResponseDto<T> Success(int statusCode, T data)
        {
            return new CustomResponseDto<T> { StatusCode = statusCode, Data = data };
        }

        public static CustomResponseDto<T> Success(int statusCode)
        {
            return new CustomResponseDto<T> { StatusCode = statusCode };
        }
        public static CustomResponseDto<T> Success(int statusCode, int id)
        {
            return new CustomResponseDto<T> { StatusCode = statusCode, Id = id };
        }

        public static CustomResponseDto<T> Fail(int statusCode, List<string> errors )
        {
            return new CustomResponseDto<T> { StatusCode = statusCode, Errors = errors };
        }
        public static CustomResponseDto<T> Fail(int statusCode, string error)
        {
            return new CustomResponseDto<T> { StatusCode = statusCode, Errors = new List<string> { error } };
        }
    }
}
