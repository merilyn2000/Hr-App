﻿using System.Text.Json;

namespace HrApp_WebAPI.Data.Entities
{
    public class Errors
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
