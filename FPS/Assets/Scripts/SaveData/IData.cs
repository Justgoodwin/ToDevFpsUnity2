using UnityEngine;
using UnityEditor;

namespace FPS
{
    public interface IData
    {
        void Save(Player player);

        Player Load();

        void SetOption(string path);
    }
}
