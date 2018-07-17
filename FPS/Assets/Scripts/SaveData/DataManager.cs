using UnityEngine;
using System.Collections;
using System.Linq;

namespace FPS
{
    public class DataManager
    {
        private IData _data;

        public void SetData<T>() where T : IData, new()
        {
            _data = new T();
        }

        public void Save(Player player)
        {
            if (_data != null)
                _data.Save(player);
        }

        public Player Load()
        {
            if (_data == null)
                return default(Player);

            return _data.Load();
        }

        public void SetOption(string path)
        {
            if (_data == null)
                return;
            _data.SetOption(path);
        }
    }
}

