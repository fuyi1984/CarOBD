using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;

namespace WebService
{
    public interface IPersonContract
    {
        string GetData();

        string GetCaMaintenance(string username, string passworld, string city);

        string GetCaVerification(string username, string passworld, string city);

        string GetCaAdvisoryactivities(string username, string passworld, string city);
    }
}
