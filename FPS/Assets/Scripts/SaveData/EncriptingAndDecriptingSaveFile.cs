using UnityEngine;
using System.Collections;
using System;
using System.Text;

namespace FPS
{
    public static class EncriptingAndDecriptingSaveFile
    {
        private static long _key = 01010101010101010;

        private static string _result;

        public static string Encript(string Name)
        {
            Debug.Log("Entering Encripting");
            try
            {
                Debug.Log("Start Encription");
                byte[] _name = Encoding.Unicode.GetBytes(Name);
                Debug.Log("Encription stage 1");

                foreach (byte bytes in _name)
                {
                    Debug.Log("Encription stafe 2");
                    _result += _name[bytes] * _key;
                }

                Debug.Log("Encrip");
            }
            catch
            {
                Debug.Log("In Catch");
                _result = "Default Name";
            }

            Debug.Log("Living Encripting");
            return _result.ToString();
        }
        public static string Encript(float HP)
        {
            try
            {
                byte _HP = Convert.ToByte(HP);
                byte key = Convert.ToByte(_key);
                _result += _HP * key;


            }
            catch
            {
                float.TryParse(_result, out HP);
            }

            return _result;
        }
        public static string Encript(bool IsVisible)
        {
            try
            {
                byte _isVisible = Convert.ToByte(IsVisible);
                byte key = Convert.ToByte(_key);
                _result += _isVisible * key;
            }
            catch
            {
               bool.TryParse(_result,out IsVisible);
            }

            return _result;
        }
        public static void Decript()
        {

        }
    }
}

