using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Internal;

namespace NUnitAutomationFramework.DevTests
{
    public class PageObject
    {
        public string Name { get; set; }
        public string By { get; set; }
        public string Query { get; set; }
        public override string ToString()
        {
            return $"{nameof(Name)}:{Name} | {nameof(By)}:{By} | {nameof(Query)}:Query ";
        }
    }
}
