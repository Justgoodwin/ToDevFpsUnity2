using UnityEngine;
using System.Collections;

namespace FPS
{
    public class PlayerPrefsData : IData
    {
        public Player Load()
        {
            Player result = new Player();

            try { result.Name = PlayerPrefs.GetString("Name", "Player"); }
            catch { result.Name = "Default Name"; }

            try { result.HP = PlayerPrefs.GetFloat("HP", 100f); }
            catch { result.HP = 100f; }

            try { result.IsVisible = bool.Parse(PlayerPrefs.GetString("IsVisible", "false")); }
            catch { result.IsVisible = false; }

            return result;

        }

        public void Save(Player player)
        {
            PlayerPrefs.SetString("Name", player.Name);
            PlayerPrefs.SetFloat("HP", player.HP);
            PlayerPrefs.SetString("IsVisible", player.IsVisible.ToString());

            PlayerPrefs.Save();


        }

        public void SetOption(string path)
        {
            
        }
    }
}

