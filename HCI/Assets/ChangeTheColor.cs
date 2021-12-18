using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTheColor : MonoBehaviour
{
    private float alpha;
    private float red;
    private float blue;
    private float green;

    public Renderer myRenderer;

    public static bool toggleLightSwitch = false;
    public bool buttonJustPressed = false;

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
        if (!buttonJustPressed)
        {
            if (Input.GetKey(KeyCode.A) && !toggleLightSwitch)
            {
                toggleLightSwitch = true;
                buttonJustPressed = true;
            }
            else if (Input.GetKey(KeyCode.A) && toggleLightSwitch)
            {
                toggleLightSwitch = false;

                buttonJustPressed = true;
            }
        }
        else if (buttonJustPressed)
        {
            if (!Input.GetKey(KeyCode.A))
                buttonJustPressed = false;
        }

        if (toggleLightSwitch)
            red = 255;
        else
            red = 0;
        Color myColor = new Color(red, green, blue, alpha);
        myRenderer.material.color = myColor;
    }
}
