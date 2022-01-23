using UnityEngine;

public class ChangeTheLightSwitch : MonoBehaviour
{
    public Outline myOutline;

    // Start is called before the first frame update
    void Start()
    {
        myOutline = gameObject.AddComponent<Outline>();

        myOutline.OutlineMode = Outline.Mode.OutlineAll;
        myOutline.OutlineColor = Color.yellow;
        myOutline.OutlineWidth = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (inGameActiveFilterUI.activeFilter == Filter.LIGHT_SWITCH)
            myOutline.enabled = true;
        else
            myOutline.enabled = false;
    }
}
