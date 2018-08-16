//using UnityEngine;
//using System.Collections.Generic;
//using UnityEditor;

//namespace FPS
//{
//    public class MyWindow : EditorWindow
//    {
//        public GameObject ObjectInstantiate;
//        List<string> _wordsForNames = new List<string>() { "abard", "skanak", "tag", "miadepacy", "nekayb", "anisoll", "thibrobong", "dash", "degipive", "neninion", "sobohic", "nutush", "aseall" };
//        string _nameObject = "Default name";
//        bool groupEnable;
//        bool firstSetUP;
//        bool secondSetUp;
//        bool _randomColor = true;
//        int _countObject = 1;
//        float _radius = 10;
//        Color[] _colors = new Color[]
//        {
//            Color.green , Color.blue, Color.clear, Color.cyan, Color.red, Color.yellow, Color.white
//        };

//        [MenuItem("GeekBrains/Window")]
//        public static void ShowWindow()
//        {
//            GetWindow(typeof(MyWindow));
//        }

//        void OnGUI()
//        {
//            GUILayout.Label("Basic options", EditorStyles.boldLabel);
//            ObjectInstantiate = EditorGUILayout.ObjectField("Object for insert", ObjectInstantiate, typeof(GameObject), true) as GameObject;

//            _nameObject = EditorGUILayout.TextField("Object name", _nameObject);
//            groupEnable = EditorGUILayout.BeginToggleGroup("Advanced options", groupEnable);
//            firstSetUP = EditorGUILayout.Toggle("Use first figure", firstSetUP);
//            secondSetUp = EditorGUILayout.Toggle("Use second figure", secondSetUp);

            


//            _randomColor = EditorGUILayout.Toggle("Random color", _randomColor);

//            _countObject = EditorGUILayout.IntSlider("Objects amount", _countObject, 1, 100);

//            _radius = EditorGUILayout.Slider("Radius", _radius, 10, 50);

//            EditorGUILayout.EndToggleGroup();
//            if (GUILayout.Button("Create objects"))
//            {
//                if (ObjectInstantiate)
//                {
//                    GameObject root = new GameObject(_wordsForNames[Random.Range(0, _wordsForNames.Count)]);

//                    if (firstSetUP == true)
//                    {
//                        secondSetUp = false;
//                    }

//                    else if (secondSetUp == true)
//                    {
//                        firstSetUP = false;
//                    }

//                    else
//                        CircuitBuild(root);
                        
                   
//                }


//            }

//            if (GUILayout.Button("Delete created objetcs"))
//            {
//                if (ObjectInstantiate)
//                {
//                    foreach (var item in _wordsForNames)
//                    {
//                        DestroyImmediate(GameObject.Find(item));
//                    }
//                }
                
                
//            }

            
//        }
//        private float _angle = 1;


//        void CircuitBuild(GameObject root)
//        {
//            for (int i = 0; i < _countObject; i++)
//            {

//                _angle = i * Mathf.PI * 2 / _countObject;

//                Vector3 pos = new Vector3(Mathf.Cos(_angle), 0, Mathf.Sin(_angle)) * _radius;

//                GameObject temp = Instantiate(ObjectInstantiate, pos, Quaternion.identity) as GameObject;

//                temp.name = _wordsForNames[Random.Range(0, _wordsForNames.Count - 1)] + "(" + i + ")";

//                temp.transform.parent = root.transform;
//                if (temp.GetComponent<Renderer>() && _randomColor)
//                {
//                    temp.GetComponent<Renderer>().material.color = _colors[Random.Range(0, _colors.Length - 1)];
//                }

//            }
//        }

//    }
//}
