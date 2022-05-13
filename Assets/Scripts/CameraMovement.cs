using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform character;
    public Vector3 setCamera;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(transform.position + "The trasnform");
        Debug.Log(character.transform.position + "the character");
        setCamera = transform.position - character.transform.position;
        Debug.Log(setCamera);
    }

    void Update()
    {
        //print(character.transform.position.y);
    }
    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 follow = new Vector3(character.transform.position.x, character.transform.position.y + 3, character.transform.position.z-(float)3 );
        transform.position = follow;
        //transform.rotation = Quaternion.Euler(0, character.transform.rotation.y, 0);
    }
}
