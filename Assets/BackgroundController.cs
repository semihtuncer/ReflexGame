using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundController : MonoBehaviour
{
    Image image;
    Color lerpedColor;
    private void Start()
    {
        image = GetComponent<Image>();
    }
    private void Update()
    {
        lerpedColor = Color.Lerp(Color.blue, Color.red, Mathf.PingPong(Time.time, 2));
        image.color = lerpedColor;
    }
}
