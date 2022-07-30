// This code is private to MAERSK
// Copyright 2022

using System.ComponentModel.DataAnnotations;

namespace MAERSK.ServiceDelivery.CodeChallenge.APIs.Models
{
    public class EntityBase<T>
    {
        [Key]
        public T Id { get; set; }
    }
}
