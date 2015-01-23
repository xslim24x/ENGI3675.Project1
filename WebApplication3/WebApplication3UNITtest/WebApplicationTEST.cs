using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication3;
using System.Collections.Generic;   
using System.Web.UI.WebControls;

namespace WebApplication3UNITtest
{
     [TestClass]
     public class WebApplicationTEST
     {
        Dictionary<string, int> ExpectValues = new Dictionary<string,int>()
            {
                {"Red",3},
                {"Turnquoise", 17},
                {"Grey", 5},
                {"Indigo",6}
            };

          [TestMethod]
          public void TestMethod1()
          {
              
              WebApplication3.PaintTable test = new PaintTable();
              Dictionary<string,int> DatabaseValues = test.DataDict();

              foreach (KeyValuePair<string, int> entry in ExpectValues)
              {
                  Assert
              }
              

              }
          }
     }
}
