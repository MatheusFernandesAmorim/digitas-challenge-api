using DigitasChallenge.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitasChallenge.DAL.Entities
{
    [Table("TASKS")]
    public class Tasks
    {
        public int Id { get; set; }       
        public string Name { get; set; }        
        public string Description { get; set; }        
        public DateTime Starts { get; set; }        
        public DateTime Ends { get; set; }       
        public Status Status { get; set; }
    }
}