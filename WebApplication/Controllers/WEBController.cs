using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication.Controllers
{
   [ApiController]
    public class WEBController : Controller
    {
        MYsql db;
        // GET: api/<controller>
        [Route("pro_first")]
        [HttpPost]
        public ActionResult<ArrayList> Select([FromForm] string spName, [FromForm] int no)
        {
            Console.WriteLine("spName : {0}, no : {1}", spName, no);
            Hashtable ht = new Hashtable();
            ht.Add("_Upno", no);            

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


        [Route("insert_info")]
        [HttpPost]
        public ActionResult<string> insert_info([FromForm] string spName, [FromForm] string pName, [FromForm] string phNumber,[FromForm] string pNumber, [FromForm] string pAddr,
            [FromForm] string pHome, [FromForm] string pElve, [FromForm] string pOutdate, [FromForm] string pMemo)
        {

            //pName,phNumber,pNumber,pAddr,pHome,pElve,Outdate,pMemo)
            //values(Name, Phone, Number, Addr, Home, Elve,`Out`, Memo 
            Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
            Hashtable ht = new Hashtable();

            ht.Add("_Name", pName);
            ht.Add("_Phone", phNumber);
            ht.Add("_Number", pNumber);
            ht.Add("_Addr", pAddr);
            ht.Add("_Home", pHome);
            ht.Add("_Elve", pElve);
            ht.Add("_Out", pOutdate);
            ht.Add("_Memo", pMemo);

            db = new MYsql();
            string state = "0";
            if (db.NonQuery(spName, ht))
            {
                state = "1";
            }
            db.ConnectionClose();
            return state;
        }
        [Route("insert_product")]
        [HttpPost]
        public ActionResult<string> insert_product([FromForm] string spName,[FromForm] string pNo,[FromForm]string iNo,[FromForm] string cnt)
        {
            Hashtable ht = new Hashtable();
            ht.Add("_pNo", pNo);
            ht.Add("_iNo", iNo);
            ht.Add("_cnt", cnt);
            db = new MYsql();
            string state = "0";
            if (db.NonQuery(spName,ht))
            {
                state = "1";
            }
            db.ConnectionClose();
            return state;
        }

        [Route("param_request")]
        [HttpPost]
        public ActionResult<Hashtable> param_request([FromForm] string spName, [FromForm] string param)
        {
            Hashtable resultMap = new Hashtable();
            Console.WriteLine("spName : {0}, no : {1}", spName, param);
            Hashtable ht = new Hashtable();
            JObject jo = JsonConvert.DeserializeObject<JObject>(param);
            foreach (JProperty col in jo.Properties())
            {
                ht.Add(col.Name, col.Value);
            }
            db = new MYsql();
            MySqlDataReader sdr = db.Reader(spName, ht);
            if(sdr != null)
            {
                while (sdr.Read())
                {
                    for (int i = 0; i < sdr.FieldCount; i++)
                    {
                        resultMap.Add(sdr.GetName(i), sdr.GetValue(i));
                        Console.WriteLine(sdr.GetName(i) + " : " + sdr.GetValue(i) + "<<<<<<<<<<<<<");
                    }
                }
                db.ReaderClose(sdr);
            }
            db.ConnectionClose();
            return resultMap;
        }

        [Route("param_request_list")]
        [HttpPost]
        public ActionResult<ArrayList> param_request_list([FromForm] string spName, [FromForm] string param)
        {
            ArrayList resultList = new ArrayList();
            Console.WriteLine("spName : {0}, no : {1}", spName, param);
            Hashtable ht = new Hashtable();
            JObject jo = JsonConvert.DeserializeObject<JObject>(param);
            foreach (JProperty col in jo.Properties())
            {
                ht.Add(col.Name, col.Value);
            }
            db = new MYsql();
            MySqlDataReader sdr = db.Reader(spName, ht);
            if (sdr != null)
            {
                while (sdr.Read())
                {
                    Hashtable map = new Hashtable();
                    for (int i = 0; i < sdr.FieldCount; i++)
                    {                        
                        map.Add(sdr.GetName(i), sdr.GetValue(i));
                    }
                    resultList.Add(map);
                }
                db.ReaderClose(sdr);
            }
            db.ConnectionClose();
            return resultList;
        }

        [Route("param_request_NonQuery")]
        [HttpPost]
        public ActionResult<Hashtable> param_request_NonQuery([FromForm] string spName, [FromForm] string param)
        {
            Hashtable resultMap = new Hashtable();
            Console.WriteLine("spName : {0}, param : {1}", spName, param);
            Hashtable ht = new Hashtable();
            JObject jo = JsonConvert.DeserializeObject<JObject>(param);
            foreach (JProperty col in jo.Properties())
            {
                ht.Add(col.Name, col.Value);
            }
            db = new MYsql();
            int state = 0;
            if (db.NonQuery(spName, ht))
            {
                state = 1;
            }            
            db.ConnectionClose();
            resultMap.Add("state", state);
            return resultMap;
        }
    }
}
