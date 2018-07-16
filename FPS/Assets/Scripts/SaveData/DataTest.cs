using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace FPS
{
    public class DataTest : MonoBehaviour
    {
        private void Start()
        {
            var path = Application.dataPath;
            var player = new Player
            {
                Name = "Player01",
                HP = 87f,
                IsVisible = true
            };

            IData data = new StreamData();
            data.SetOption(path);

            Debug.Log(player.ToString());

            data.Save(player);

            var loadedPlayer = data.Load();
            Debug.Log(loadedPlayer.ToString());
        }
    }
}

