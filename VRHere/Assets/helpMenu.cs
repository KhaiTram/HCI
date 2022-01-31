using UnityEngine;
using UnityEngine.UI;


class helpMenu : MonoBehaviour
{

    public const string DEFAULT_TEXT = "Show controls";
    private bool buttonJustPressed;
    private Text displayedText;

    public bool helpStatus;
    public bool helpPanelStatus;
    GameObject helpPanel;

    // Start is called before the first frame update

    void Start()
    {
        displayedText = gameObject.GetComponent<Text>();
        buttonJustPressed = false;
        helpStatus = false;

        GetChildWithName(this.gameObject, "extendedHelpPanel").SetActive(false);
        // Initialize Element
        UpdateText();
    }

    // Update is called once per frame
    void Update()
    {
        if (!buttonJustPressed)
        {
            if (Input.GetKey(KeyCode.H))
            {
                UpdateText();
                buttonJustPressed = true;
            }
        }
        else if (buttonJustPressed)
        {
            if (!Input.GetKey(KeyCode.H))
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