using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

class inGameActiveFilterUI : MonoBehaviour
{
    public const string DEFAULT_TEXT = "Change Active filter ";

    private Text displayedText;
    private bool buttonJustPressed;

    private InputDevice rightHand;
        

    public static Filter activeFilter;
    // Start is called before the first frame update

    
    void Start()
    {
        displayedText = gameObject.GetComponent<Text>();
        activeFilter = Filter.NONE;
        buttonJustPressed = false;

        
        List<InputDevice> rightDevices = new List<InputDevice>();
        InputDeviceCharacteristics rightCharacteristic = InputDeviceCharacteristics.Right |InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(rightCharacteristic,rightDevices);

        if(rightDevices.Count > 0)
        { 
            rightHand = rightDevices[0];
        }

    }

    // Update is called once per frame
    void Update()
    {
        rightHand.TryGetFeatureValue(CommonUsages.primaryButton, out bool primValue);

        if (!buttonJustPressed)
        {
            if (Input.GetKey(KeyCode.F) || primValue)
            {
                UpdateFilter();
                buttonJustPressed = true;
            }
        }
        else if (buttonJustPressed)
        {
            if (!Input.GetKey(KeyCode.F)&& !primValue)
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
