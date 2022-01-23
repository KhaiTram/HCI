using UnityEngine;

public class ChangeThePowerOutlet : MonoBehaviour
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
        if (inGameActiveFilterUI.activeFilter == Filter.POWER_OUTLET)
            myOutline.enabled = true;
        else
            myOutline.enabled = false;
    }
}
