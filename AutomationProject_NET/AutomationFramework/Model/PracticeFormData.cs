using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationProject_NET.AutomationFramework.Access
{
    public partial class PracticeFormData
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserEmail { get; set; }

        public string Gender { get; set; }

        public string Mobile { get; set; }

        public int DateOfBirthDaysDifference { get; set; }

        public string[] Subjects { get; set; }

        public string[] Hobbies { get; set; }

        public string CurrentAddress { get; set; }

        public string State {  get; set; }

        public string City {  get; set; }
    }
}
