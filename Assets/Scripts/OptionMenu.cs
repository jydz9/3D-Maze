using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionMenu : MonoBehaviour
{
    public GameObject optionMenu;

    public void ShowOption()
    {
        optionMenu.SetActive(true);
    }
    public void HideOption()
    {
        optionMenu.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
