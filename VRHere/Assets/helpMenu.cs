using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;


class helpMenu : MonoBehaviour
{

    public const string DEFAULT_TEXT = "Show controls";
    private bool buttonJustPressed;
    private Text displayedText;

    public bool helpStatus;
    public bool helpPanelStatus;
    GameObject helpPanel;

    private InputDevice leftHand;

    // Start is called before the first frame update

    void Start()
    {
        displayedText = gameObject.GetComponent<Text>();
        buttonJustPressed = false;
        helpStatus = false;

        List<InputDevice> leftDevices = new List<InputDevice>();
        InputDeviceCharacteristics leftCharacteristic = InputDeviceCharacteristics.Left |InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(leftCharacteristic,leftDevices);

        if(leftDevices.Count > 0)
        { 
            leftHand = leftDevices[0];
        }

        GetChildWithName(this.gameObject, "extendedHelpPanel").SetActive(false);
        // Initialize Element
        UpdateText();
    }

    // Update is called once per frame
    void Update()
    {
        leftHand.TryGetFeatureValue(CommonUsages.primaryButton, out bool lprimValue);
        if (!buttonJustPressed)
        {
            if (Input.GetKey(KeyCode.H)||lprimValue)
            {
                UpdateText();
                buttonJustPressed = true;
            }
        }
        else if (buttonJustPressed)
        {
            if (!Input.GetKey(KeyCode.H)&& !lprimValue)
                buttonJustPressed = false;
        }

    }

    private void UpdateText()
    {
        GameObject childPanel = GetChildWithName(this.gameObject, "extendedHelpPanel");

        if (helpStatus)
        {
            helpStatus = false;
            displayedText.text = "Hide controls";
            childPanel.SetActive(true);
        }
        else
        {
            helpStatus = true;
            displayedText.text = "Show controls";
            childPanel.SetActive(false);
        }
    }

    GameObject GetChildWithName(GameObject obj, string name)
    {
        Transform trans = obj.transform;
        Transform childTrans = trans.Find(name);
        if (childTrans != null)
        {
            return childTrans.gameObject;
        }
        else
        {
            return null;
        }
    }

}