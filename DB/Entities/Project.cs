using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Entities
{
    /// <summary>
    /// Class <c>Project</c> Is Project Entity
    /// </summary>
    public class Project
    {
        /// <value>Property <c>Id</c> represent the identity of prject record</value>
        [Key]
        public int Id { get; set; }
        /// <value>Property <c>Title</c> represent the title of prject record</value>
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        /// <value>Property <c>Description</c> represent the description of prject record</value>
        [Required]
        [MaxLength(500)]
        public string Description { get; set; }
        /// <value>Property <c>CreationDate</c> represent the creation date time of prject record</value>
        public DateTime CreationDate { get; set; }
    }
}
