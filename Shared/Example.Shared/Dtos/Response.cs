using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Example.Shared.Dtos
{
    public class Response<T>
    {
        public T Data { get;private set; }//dışardan deer atanamayacak
        
        //bu kodu kullanıp ona göre işlem yapacaz ama responsen içinde gitmesine gerek yok kullanıcı görmeyecek
        [JsonIgnore]
        public int StatusCode { get;private set; }

        [JsonIgnore]
        public bool IsSuccessful { get;private set; }

        public List<string> Errors { get; set; }

        //static  factory mthod.static metotlar geriye bir deger dönerse static factory metot denir
        public static Response<T> Success(T data ,int statusCode)
        {
            return new Response<T> { Data = data, StatusCode = statusCode, IsSuccessful = true };
        }


        //işlem başarılı ama geriye bir data döndermeyecegimiz durumlarda NoContent sınıfını dönderecegiz
        public static Response<T> Success(int statusCode)
        {
            return new Response<T> { Data = default(T), StatusCode = statusCode, IsSuccessful = true };
        }

        public static Response<T>Fail(List<string> errors,int statusCode)
        {
            return new Response<T>
            {
                Errors = errors,
                StatusCode = statusCode,
                IsSuccessful = false
            };
        }

        public static Response<T>Fail(string error,int statusCode)
        {
            return new Response<T>
            {
                Errors = new List<string>() { error },
                StatusCode = statusCode,
                IsSuccessful = false
            };
        }
    }
}
