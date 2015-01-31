using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication3;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace WebApplication3UNITtest
{
     [TestClass]
     public class WebApplicationTEST
     {
        Dictionary<string, int> ExpectValues = new Dictionary<string,int>()
            {
                {"Red",3},
                {"Turquoise", 17},
                {"Grey", 5},
                {"Indigo",6}
            };

          [TestMethod]
          public void DatabaseTest()
          {

              WebApplication3.PaintTable test = new PaintTable();
              Dictionary<string,int> DatabaseValues = test.DataDict();

              Assert.IsFalse(DatabaseValues.Count == 0);
              if (DatabaseValues.Count == 0)
                  Console.WriteLine("Database is either empty or there is a connection problem");

              foreach (KeyValuePair<string, int> entry in DatabaseValues)
              {
                  if (ExpectValues.ContainsKey(entry.Key))
                  {
                      if (entry.Value != ExpectValues[entry.Key])
                      {
                          Console.WriteLine("Database contains {1} for the expected value of {2} for: {0}", entry.Key, entry.Value, ExpectValues[entry.Key]);
                          Assert.AreEqual(ExpectValues[entry.Key], entry.Value);
                      }
                      ExpectValues.Remove(entry.Key);
                  }
                  else
                  {
                      Console.WriteLine("Database contains an extra row: {0} {1}", entry.Key, entry.Value);
                      Assert.IsTrue(ExpectValues.ContainsKey(entry.Key));
                  }
              }
             
              foreach (KeyValuePair<string,int> entry in ExpectValues)
              {
                  Console.WriteLine("Expected value was missing: {0} {1}", entry.Key, entry.Value);
                  Assert.IsNull(entry.Key);
              }
              

            }
       }
}
