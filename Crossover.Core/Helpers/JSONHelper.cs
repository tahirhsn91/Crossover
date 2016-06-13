using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace Caprelo.Common.Helper
{
    public class JSONHelper
    {
        public static string GetString(object obj)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                var ser = new DataContractJsonSerializer(obj.GetType());
                ser.WriteObject(ms, obj);
                ser = null;
                ms.Seek(0, SeekOrigin.Begin);
                using (StreamReader sr = new StreamReader(ms))
                {
                    return sr.ReadToEnd();
                }
            }
        }

        public static object GetObject(Stream stream, object obj)
        {
            var ser = new DataContractJsonSerializer(obj.GetType());
            obj = ser.ReadObject(stream);
            stream.Close();
            stream.Dispose();
            stream = null;
            ser = null;
            return obj;
        }

        public static R GetObject<R>(Stream stream)
        {
            var ser = JsonConvert.DeserializeObject<R>(new StreamReader(stream).ReadToEnd());
            return ser;
        }

        public static object GetObject(string json, object obj)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                StringReader sr = new StringReader(json);
                byte[] byteArray = System.Text.Encoding.GetEncoding("iso-8859-1").GetBytes(json);
                System.IO.MemoryStream memoryStream = new System.IO.MemoryStream(byteArray);
                ms.Position = 0;
                var ser = new DataContractJsonSerializer(obj.GetType());
                obj = ser.ReadObject(memoryStream);
                return obj;
            }
        }

        public static T GetObject<T>(string json)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                StringReader sr = new StringReader(json);
                byte[] byteArray = System.Text.Encoding.GetEncoding("utf-8").GetBytes(json);
                System.IO.MemoryStream memoryStream = new System.IO.MemoryStream(byteArray);
                ms.Position = 0;
                var ser = new DataContractJsonSerializer(typeof(T));
                T t = (T)ser.ReadObject(memoryStream);
                return t;
            }
        }

        public static string DataTableToJsonWithJavaScriptSerializer(DataTable table)
        {
            JavaScriptSerializer javascriptSerializer = new JavaScriptSerializer();
            List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
            Dictionary<string, object> childRow;
            foreach (DataRow row in table.Rows)
            {
                childRow = new Dictionary<string, object>();
                foreach (DataColumn col in table.Columns)
                {
                    childRow.Add(col.ColumnName, row[col]);
                }

                parentRow.Add(childRow);
            }

            return javascriptSerializer.Serialize(parentRow);
        }

        public static string DataTableToJSONWithStringBuilder(DataTable table)
        {
            var jsonString = new StringBuilder();
            if (table.Rows.Count > 0)
            {
                jsonString.Append("[");
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    jsonString.Append("{");
                    for (int j = 0; j < table.Columns.Count; j++)
                    {
                        if (j < table.Columns.Count - 1)
                        {
                            jsonString.Append("\"" + table.Columns[j].ColumnName.ToString() + "\":" + "\"" + table.Rows[i][j].ToString() + "\",");
                        }
                        else if (j == table.Columns.Count - 1)
                        {
                            jsonString.Append("\"" + table.Columns[j].ColumnName.ToString() + "\":" + "\"" + table.Rows[i][j].ToString() + "\"");
                        }
                    }

                    if (i == table.Rows.Count - 1)
                    {
                        jsonString.Append("}");
                    }
                    else
                    {
                        jsonString.Append("},");
                    }
                }

                jsonString.Append("]");
            }

            return jsonString.ToString();
        }
    }
}