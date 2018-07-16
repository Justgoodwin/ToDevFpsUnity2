using UnityEngine;
using UnityEditor;
using System.IO;

namespace FPS
{
    public class StreamData : IData
    {
        private string _path;

        public Player Load()
        {
            Player result = new Player();

            if (!File.Exists(_path))
                return result;

            using (StreamReader sr = new StreamReader(_path))
            {
                while (!sr.EndOfStream)
                {
                    try
                    {
                        result.Name = sr.ReadLine();
                        result.HP = float.Parse(sr.ReadLine());
                        result.IsVisible = bool.Parse(sr.ReadLine());
                    }
                    catch
                    {
                        result.Name = "Default Name";
                        result.HP = 0;
                        result.IsVisible = false;
                    }
                    
                }
            }
            return result;
        }

        public void Save(Player player)
        {
            using (var sw = new StreamWriter(_path))
            {
                sw.WriteLine(player.Name);
                sw.WriteLine(player.HP);
                sw.WriteLine(player.IsVisible);
            }

            Debug.Log ("Data saved");
        }

        public void SetOption(string path)
        {
            _path = Path.Combine(path,"StramData.txt");
        }
    }
}
