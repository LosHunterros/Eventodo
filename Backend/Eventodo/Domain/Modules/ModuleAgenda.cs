using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eventodo.Domain
{
    public class ModuleAgenda : Module
    {
        public int Day { get; set; } = 1;
    }
}
