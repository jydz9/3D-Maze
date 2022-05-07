using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    int xZPosition;
    // Start is called before the first frame update
    void Start()
    {
        if (SliderWidth.widthValue == 0)
        {
            xZPosition = 4;
        }
        else
        {
            xZPosition = (int)(SliderWidth.widthValue / 2);
        }
        Debug.Log(xZPosition + "is the postition");
        transform.position = new Vector3(xZPosition-1, transform.position.y, -(xZPosition));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
