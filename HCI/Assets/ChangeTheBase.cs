using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTheBase : MonoBehaviour
{
    private float alpha;
    private float red;
    private float blue;
    private float green;

    public Renderer myRenderer;

    // Start is called before the first frame update
    void Start()
    {
        alpha = 255;
        red = 0;
        blue = 0;
        green = 0;
        myRenderer = gameObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ChangeTheColor.toggleLightSwitch)
            blue = 255;
        else
            blue = 0;
        Color myColor = new Color(red, green, blue, alpha);
        myRenderer.material.color = myColor;
    }
}
