using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggleoutline : MonoBehaviour
{
    Outline outline;
    bool buttonpressed;
    // Start is called before the first frame update
    void Start()
    {
        outline = GetComponent<Outline>();
        outline.enabled = false;
        buttonpressed=false;

    }


    // Update is called once per frame
    void Update()
    {


        if(Input.GetKey(KeyCode.L))
        {
            if(outline.enabled==true)
            {
                outline.enabled= false;
                buttonpressed = true;
            }

            if(outline.enabled==false)
            {
               outline.enabled= true;
               buttonpressed = true;
            }
        }
        
        if(!Input.GetKey(KeyCode.L))
            {
                buttonpressed = false;
            }
    }
}
