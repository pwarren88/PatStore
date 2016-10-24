using Microsoft.VisualStudio.TestTools.UnitTesting;
using PatStore.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatStore.Controllers.Tests
{
    [TestClass()]
    public class ProductControllerTests
    {
        [TestMethod()]
        public void IndexTest()
        {
            ProductController c = new ProductController();
            var result = c.Index((int?)null);
            Assert.IsNotNull(result);
        }
    }
}