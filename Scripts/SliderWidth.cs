using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderWidth : MonoBehaviour
{
    public Text displayText;
    public static float widthValue;
    public void OnValueChanged(float value)
    {
        widthValue = value;
        displayText.text = value.ToString();
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
