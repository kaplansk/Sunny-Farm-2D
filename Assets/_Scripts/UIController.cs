using Unity.VisualScripting;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject[] toolbarActivatorIcons;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SwitchTool(0);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SwitchTool(int selected)
    {
        foreach (GameObject icon in toolbarActivatorIcons)
        {
            icon.SetActive(false);
        }
        toolbarActivatorIcons[selected].SetActive(true);
    }
}
