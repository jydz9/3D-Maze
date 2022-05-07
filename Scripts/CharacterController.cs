using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterController : MonoBehaviour
{
    public Animator animate;
    int xZPosition;

    Vector3 Vec;
    // Start is called before the first frame update
    void Start()
    {
        animate = GetComponent<Animator>();
        if(SliderWidth.widthValue == 0)
        {
            xZPosition = -5;
        }
        else
        {
            xZPosition = (int)-SliderWidth.widthValue / 2;
        }
        transform.position = new Vector3(xZPosition, transform.position.y, xZPosition);
    }
    void OnCollisionEnter(Collision hitSomething)
    {
        if(hitSomething.collider.name == "GoalSphere")
        {
            SceneManager.LoadScene(3);
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //Vec = transform.localPosition;
        float rightLeft = Input.GetAxis("Horizontal");
        float upDown = Input.GetAxis("Vertical");

        Vector3 normalDirection = new Vector3(rightLeft, 0, upDown);
        normalDirection.Normalize();

        //transform.Translate(normalDirection * 2 * Time.deltaTime, Space.World);

        if (normalDirection != Vector3.zero)
        {
            Quaternion rotateCharater = Quaternion.LookRotation(normalDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotateCharater, 500 * Time.deltaTime);
        }
        if (Input.GetAxis("Vertical") > 0)
        {
            animate.SetBool("checkWalking", true);
            transform.Translate(normalDirection * 2 * Time.deltaTime, Space.World);
            //Vec.x += Input.GetAxis("Vertical") * Time.deltaTime * 5;
            //transform.localPosition = Vec;
            //transform.position = new Vector3(transform.position.x, 0, transform.position.z);
            //transform.position += Vector3.forward * 2 * Time.deltaTime;
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            animate.SetBool("checkWalking", true);
            transform.Translate(normalDirection * 2 * Time.deltaTime, Space.World);
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            animate.SetBool("checkWalking", true);
            transform.Translate(normalDirection * 2 * Time.deltaTime, Space.World);
        }
        else if(Input.GetAxis("Horizontal") < 0)
        {
            animate.SetBool("checkWalking", true);
            transform.Translate(normalDirection * 2 * Time.deltaTime, Space.World);
        }
        else
        {
            animate.SetBool("checkWalking", false);
        }

    }
}
