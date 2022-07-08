using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskList.Models
{
    public class Task
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //Automatically generation id in Data
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public string Priority { get; set; }

        public int TimeToComplete { get; set; }

        public DateTime Date_complete { get; set; }

        public Guid ProjectId { get; set; }

        public Project Project { get; set; }

    }
}
