using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


namespace FPS
{
    [CustomEditor(typeof(MyScriptEditor))]
    public class MyScriptEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
        }
    }
}
