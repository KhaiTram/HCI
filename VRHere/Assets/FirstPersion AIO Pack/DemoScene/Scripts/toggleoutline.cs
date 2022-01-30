using UnityEngine;

public class toggleoutline : MonoBehaviour
{
    Outline outline;
    // Start is called before the first frame update
    void Start()
    {
        outline = GetComponent<Outline>();
        outline.enabled = false;

    }


    // Update is called once per frame
    void Update()
    {


        if (Input.GetKey(KeyCode.L))
        {
            if (outline.enabled == true)
            {
                outline.enabled = false;
            }

            if (outline.enabled == false)
            {
                outline.enabled = true;
            }
        }

        if (!Input.GetKey(KeyCode.L))
        {
        }
    }
}
