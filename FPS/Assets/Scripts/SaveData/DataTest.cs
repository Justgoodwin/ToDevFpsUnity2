using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace FPS
{
    public class DataTest : MonoBehaviour
    {
        public enum DataProviders
        {
            TXT,XML,PLAYER_PREFS,JSON
        }

        [SerializeField]
        private DataProviders _providers;
        private DataManager _dataManager = new DataManager();


        private void Start()
        {
            var path = Application.dataPath;
            var player = new Player
            {
                Name = "Player01",
                HP = 87f,
                IsVisible = true
            };

            switch (_providers)
            {
                case DataProviders.JSON:
                    _dataManager.SetData<JSONData>();
                    break;
                case DataProviders.PLAYER_PREFS:
                    _dataManager.SetData<PlayerPrefsData>();
                    break;
                case DataProviders.TXT:
                    _dataManager.SetData<StreamData>();
                    break;
                case DataProviders.XML:
                    _dataManager.SetData<XMLData>();
                    break;

            }
            _dataManager.SetOption(path);

            Debug.Log(player.ToString());

            _dataManager.Save(player);

            var loadedPlayer = _dataManager.Load();
            Debug.Log(loadedPlayer.ToString());
        }
    }
}

