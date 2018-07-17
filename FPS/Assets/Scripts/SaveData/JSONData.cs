using UnityEngine;
using System.Collections;
using System.IO;

namespace FPS
{
    public class JSONData : IData
   {
        private string str;

        private string _path;

        public Player Load()
        {
            try
            {
                str = File.ReadAllText(_path);
                return JsonUtility.FromJson<Player>(_path);
            }
            catch
            {
                return default(Player);
            }
        }

        public void Save(Player player)
        {
            str = JsonUtility.ToJson(player);

            File.WriteAllText(_path, str);
        }

        public void SetOption(string path)
        {
            _path = Path.Combine(path, "JSONData.json");
        }
    }

}

