using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crossover.Core.Entity
{
    public class Log
    {
        private string logger { get; set; }

        private string level { get; set; }

        private string message { get; set; }

        private string applicationId { get; set; }

        public string Logger
        {
            get
            {
                return this.logger;
            }
            set
            {
                this.logger = value;
            }
        }

        public string Level
        {
            get
            {
                return this.level;
            }
            set
            {
                this.level = value;
            }
        }

        public string Message
        {
            get
            {
                return this.message;
            }
            set
            {
                this.message = value;
            }
        }

        public string ApplicationId
        {
            get
            {
                return this.applicationId;
            }
            set
            {
                this.applicationId = value;
            }
        }
    }
}
