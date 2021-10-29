using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DT.MDM.Models
{
    public abstract class BaseModel
    {
        /// <summary>
        /// Internal ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The date and time when this is created
        /// </summary>
        public DateTimeOffset Created { get; set; }

        /// <summary>
        /// Who has created this
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// The date and time when this is modified
        /// </summary>
        public DateTimeOffset Modified { get; set; }

        /// <summary>
        /// Who has modified this
        /// </summary>
        public string ModifiedBy { get; set; }

        /// <summary>
        /// The Timestamp data annotation is required for concurrency checking.
        /// This is a binary number that is guaranteed to be unique in the database.
        /// </summary>
        [Timestamp]
        public byte[] TimeStamp { get; set; }

        protected BaseModel()
        {
            Created = DateTime.Now;
            CreatedBy = "SYSTEM";
            Modified = Created;
            ModifiedBy = CreatedBy;
        }
    }
}
