using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PleaseShareYourCode.PSYC
{
	public class JsonParser
	{
		public static string Serialize<T>(T obj)
		{
			if (obj == null) throw new ArgumentNullException("Objest is null");

			return JsonConvert.SerializeObject(obj);
		}

		public static void Serialize<T>(T obj, string path)
		{
			if (obj == null) throw new ArgumentNullException("Objest is null");
			if (path == null) throw new ArgumentNullException("Path is null");
			if (path.Trim().Length == 0) throw new Exception("Path is invalid");

			JsonSerializer serializer = new JsonSerializer();

			using (StreamWriter sw = new StreamWriter(path))
			{
				serializer.Serialize(sw, obj);
			}
		}

		public static T Deserialize<T>(string json)
		{
			if (json.Trim().Length == 0) throw new Exception("Json string is empty");

			return JsonConvert.DeserializeObject<T>(json);
		}

		public static T DeserializeFile<T>(string path)
		{
			if (path == null) throw new ArgumentNullException("Path is null");
			if (path.Trim().Length == 0) throw new Exception("Path is invalid");

			if (!File.Exists(path))
			{
				throw new Exception("The file doesn't exist");
			}

			return JsonConvert.DeserializeObject<T>(File.ReadAllText(path));
		}
	}
}
