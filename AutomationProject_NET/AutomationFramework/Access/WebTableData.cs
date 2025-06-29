using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AutomationProject_NET.AutomationFramework.Access
{
    public partial class WebTableData : BaseData
    {
        private readonly String fileName = "WebTableData";

        public WebTableData(int dataSetNumber)
        {
            LoadData(dataSetNumber, this.fileName);
            FirstName = GetValue("firstName");
            LastName = GetValue("lastName");
            UserEmail = GetValue("userEmail");
            Age = GetValue("age");
            Salary = GetValue("salary");
            Department = GetValue("department");
        }
    }
}
