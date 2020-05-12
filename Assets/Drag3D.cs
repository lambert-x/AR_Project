using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Drag3D : MonoBehaviour
{
    float Zposition;
    Vector3 Offset;
    //protected Joybutton joybutton;
    private Camera MainCamera;
    bool Dragging;
    private GameObject cursor;
    [SerializeField]
    public UnityEvent OnBeginDrag;
    [SerializeField]
    public UnityEvent OnEndDrag;
    // Start is called before the first frame update
    void Start()
    {
        //joybutton = FindObjectOfType<Joybutton>();
        MainCamera = Camera.main;
        Zposition = MainCamera.WorldToScreenPoint(transform.position).z;
    }
    
    // Update is called once per frame
    void Update()
    { 
    //{
    //    int selectedindex;
    //    cursor = GameObject.Find("ControlPoint");
    //    SelectionManager SM = cursor.GetComponent<SelectionManager>();
    //    //Debug.Log(cursor);
    //    ////Debug.Log('0');
    //    //Debug.Log(joybutton.Pressed);
    //    ////Debug.Log('1');
    //    //Debug.Log(SM._selection.transform.parent.name);
    //    ////Debug.Log('2');
    //    //Debug.Log(gameObject.name);
    //    if (joybutton.Pressed && SM._selection.transform.parent.name == gameObject.name)
    //    {
    //        if (!Dragging)
    //        {
    //            BeginDrag();
    //        }    
    //        Vector3 cursor_screen = MainCamera.WorldToScreenPoint(cursor.transform.position);
    //        Vector3 position = new Vector3(cursor_screen.x, cursor_screen.y, Zposition);
    //        //Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Zposition);
    //        transform.position = MainCamera.ScreenToWorldPoint(position + new Vector3(Offset.x, Offset.y));
            
    //    }
    //    //if (!joybutton.Pressed && Dragging)
    //    {
    //        EndDrag();
    //    }

    }
    public void BeginDrag()
    {
        OnBeginDrag.Invoke();
        Dragging = true;
        Offset = MainCamera.WorldToScreenPoint(transform.position) - MainCamera.WorldToScreenPoint(cursor.transform.position);
    }
    public void EndDrag()
    {
        OnEndDrag.Invoke();
        Dragging = false;
    }
}
