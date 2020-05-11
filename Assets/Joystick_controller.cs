using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystick_controller : MonoBehaviour
{
    protected Joystick joystick;
    protected Joybutton joybutton;
    private new Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;


        //Position_inscreen = transform.position;
        joystick = FindObjectOfType<Joystick>();
        joybutton = FindObjectOfType<Joybutton>();
    }

    // Update is called once per frame
    void Update()
    {
        //var bottomLeft = camera.ScreenToWorldPoint(Vector3.zero);
        //var topRight = camera.ScreenToWorldPoint(new Vector3(
        //    camera.pixelWidth, camera.pixelHeight));

        //Rect cameraRect = new Rect(
        //    bottomLeft.x,
        //    bottomLeft.y,
        //    topRight.x - bottomLeft.x,
        //    topRight.y - bottomLeft.y);

        var rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = new Vector3(joystick.Horizontal * -2f,
            joystick.Vertical * 2f,
            rigidbody.velocity.z
                );

        //transform.position = new Vector3(
        //Mathf.Clamp(transform.position.x, cameraRect.xMin, cameraRect.xMax),
        //Mathf.Clamp(transform.position.y, cameraRect.yMin, cameraRect.yMax),
        //transform.position.z);
    }
}
