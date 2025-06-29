using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AutomationProject_NET.AutomationFramework.Access
{
    public class BaseData
    {
        private XElement dataNode;

        protected void LoadData(int dataSetNumber, string fileName)
        {
            string path = Path.Combine($"E:\\Workspace VIsualStudio\\Repositories\\AutomationProject_NET\\AutomationProject_NET\\AutomationFramework\\Resources\\{fileName}.xml");

            XDocument doc = XDocument.Load(path);

            string nodeName = $"dataSet_{dataSetNumber}";

            dataNode = doc.Root.Element(nodeName);
            if (dataNode == null)
            {
                throw new Exception($"Data set {dataSetNumber} not found in the XML file.");
            }
        }

        protected string GetValue(string nodeName)
        {
            return dataNode.Element(nodeName)?.Value ?? throw new Exception($"Node {nodeName} not found in the XML file.");
        }

        protected string[] ConvertToArray(string input)
        {
            return input.Split(',', StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
