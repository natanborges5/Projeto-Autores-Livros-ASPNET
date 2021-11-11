
using System;
using System.Text.Json.Serialization;

namespace Domain
{
    public class Livros
    {
        public Guid Id { get; set; }
        public string titulo { get; set; }
        public string isbn { get; set; }
        public DateTime ano { get; set; }
        public Guid autorId { get; set; }
        [JsonIgnore]
        public virtual Autores Autores { get; set; }
    }
}
