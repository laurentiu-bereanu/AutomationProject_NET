using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationProject_NET.AutomationFramework.Access
{
    public partial class PracticeFormData : BaseData
    {
        private readonly String fileName = "PracticeFormData";

        public PracticeFormData(int dataSetNumber)
        {
            LoadData(dataSetNumber, this.fileName);
            FirstName = GetValue("firstName");
            LastName = GetValue("lastName");
            UserEmail = GetValue("userEmail");
            Gender = GetValue("gender");
            Mobile = GetValue("mobile");
            DateOfBirthDaysDifference = int.Parse(GetValue("dateOfBirthDaysDifference"));
            Subjects = ConvertToArray(GetValue("subjects"));
            Hobbies = ConvertToArray(GetValue("hobbies"));
            CurrentAddress = GetValue("currentAddress");
            State = GetValue("state");
            City = GetValue("city");
        }
    }
}