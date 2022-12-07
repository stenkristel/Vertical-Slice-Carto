using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFadein : MonoBehaviour
{
    public GameObject canvas;


    private void Update()
    {
        if (Input.GetKeyDown("tab"))
        {
            foreach (Transform child in canvas.transform)
            {
                if (child.tag == "map")
                {
                    RawImage Image = child.GetComponent<RawImage>();
                    Image.color = new Color(Image.color.r, Image.color.g, Image.color.b, 0.5f);
                }
            }
        }
    }
}
