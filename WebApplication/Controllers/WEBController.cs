using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication.Controllers
{
    [Route("pro_first")]
    public class WEBController : Controller
    {
        MYsql db;
        // GET: api/<controller>
        [HttpPost]
        public ActionResult<ArrayList> Select([FromForm] string spName, [FromForm] string no)
        {
            Console.WriteLine("spName : {0}, no : {1}", spName, no);
            Hashtable ht = new Hashtable();
            if (!String.IsNullOrEmpty(no))
            {
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("---------------------------------------------"+no);
                string[] str = no.Split(":");
                Console.WriteLine("!!!!!!!!!!" + str[0]);
                ht.Add(str[0], str[1]);
                Console.WriteLine("11111");
            }

            db = new MYsql();
            MySqlDataReader sdr = db.Reader(spName, ht);
            ArrayList list = new ArrayList();
            while (sdr.Read())
            {
                string[] arr = new string[sdr.FieldCount];
                for (int i = 0; i < sdr.FieldCount; i++)
                {
                    Console.WriteLine(sdr.GetValue(i).ToString());
                    arr[i] = sdr.GetValue(i).ToString();
                }
                list.Add(arr);
            }
            db.ReaderClose(sdr);
            db.ConnectionClose();
            Console.WriteLine("TEST : {0}", list.Count.ToString());
            return list;
        }

    }
}
