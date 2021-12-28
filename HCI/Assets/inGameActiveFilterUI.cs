using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

class inGameActiveFilterUI : MonoBehaviour
{
    public const string DEFAULT_TEXT = "Active filters (press 'F' to toggle)";
    
    private Text displayedText;
    private bool buttonJustPressed;

    public static Filter activeFilter;
    // Start is called before the first frame update
    void Start()
    {
        displayedText = gameObject.GetComponent<Text>();
        activeFilter = Filter.NONE;
        buttonJustPressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!buttonJustPressed)
        {
            if (Input.GetKey(KeyCode.F))
            {
                UpdateFilter();
                buttonJustPressed = true;
            }
        }
        else if (buttonJustPressed)
        {
            if (!Input.GetKey(KeyCode.F))
                buttonJustPressed = false;
        }

        displayedText.text = $"{DEFAULT_TEXT}\n{activeFilter.ToString().Replace('_', ' ')}";
    }

    private void UpdateFilter()
    {
        if (activeFilter == Filter.LAN_OUTLET)
            activeFilter = Filter.NONE;
        else
            activeFilter++;
    }
}

enum Filter
{
    NONE,
    LIGHT_SWITCH,
    POWER_OUTLET,
    GAS,
    LAN_OUTLET // keep this the last entry, or change to reset condition in the update() method
}
