using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace FPS
{
    public class WhenFindBox : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.tag == "LootBox")
            {
                Destroy(GameObject.FindGameObjectWithTag("LootBox"));
                GetComponent<Text>().color = new Color(255, 0, 0);
            }
        }
    }
}