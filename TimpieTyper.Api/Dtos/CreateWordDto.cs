using System.ComponentModel.DataAnnotations;
using TimpieTyper.Core.Entities;

namespace TimpieTyper.Api.Dtos;

public class CreateWordDto
{
    [Required]
    public string Value { get; set; }
    
    public Word ToEntity()
    {
        return new Word()
        {
            Value = this.Value
        };
    }
}