using System;

namespace mvckatmani.Models
{
    internal class requiredAttribute : Attribute
    {
        public string ErrorMessage { get; set; }
    }
}