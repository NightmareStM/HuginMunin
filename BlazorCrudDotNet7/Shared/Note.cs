using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCrudDotNet7.Shared
{
    public class Note
    {
        public int Id { get; set; }
        
        public required string Title { get; set; }

        public string Description { get; set; } = string.Empty;

        public string Tag { get; set; } = string.Empty;

        public DateTime Update { get; set; } = DateTime.Now;
    }
}
