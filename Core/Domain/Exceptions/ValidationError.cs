﻿namespace Domain.Exceptions
{
    public class ValidationError
    {
        public string Field { get; set; } = default!;
        public IEnumerable<string> Errors { get; set; } = [];
    }
}