using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    
    public interface IDbRepository
    {
        string GetDbValue();
    }
    public class DbRepository : IDbRepository
    {
        string dbStringVal = StringUnitTest.inputString;
        public DbRepository()
        {
            //populate your contructor
        }

        public string GetDbValue()
        {
            // return string test value;
            return dbStringVal;
        }
    }
}
