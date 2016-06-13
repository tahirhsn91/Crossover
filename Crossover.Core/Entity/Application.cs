using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crossover.Core.Entity
{
    public class Application
    {
        private string applicationId { get; set; }

        private string displayName { get; set; }

        private string secret { get; set; }

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

        public string DisplayName
        {
            get
            {
                return this.displayName;
            }

            set
            {
                this.displayName = value;
            }
        }

        public string Secret
        {
            get
            {
                return this.secret;
            }

            set
            {
                this.secret = value;
            }
        }
    }
}
