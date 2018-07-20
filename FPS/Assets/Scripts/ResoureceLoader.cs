using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
    public class ResoureceLoader : MonoBehaviour
    {
        private void Start()
        {
            GameObject gameObjetcForLoading = GameObject.CreatePrimitive(PrimitiveType.Cube);
            Renderer renderingGameObject = gameObjetcForLoading.GetComponent<Renderer>();
            renderingGameObject.material.mainTexture = Resources.Load("glass") as Texture;
        }

    }
}

