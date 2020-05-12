using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move3D : MonoBehaviour
{
    //float Zposition;
    public List<Vector3> positions = new List<Vector3>();
    public List<int> states = new List<int>();
    public List<int> stepcount = new List<int>();
    protected Upbutton upbutton;
    protected Downbutton downbutton;
    protected Leftbutton leftbutton;
    protected Rightbutton rightbutton;
    private Camera MainCamera;
    bool Dragging;
    private GameObject cursor;
    //[SerializeField]
    //public UnityEvent OnBeginDrag;
    //[SerializeField]
    //public UnityEvent OnEndDrag;
    // Start is called before the first frame update
    void Start()
    {
        upbutton = FindObjectOfType<Upbutton>();
        downbutton = FindObjectOfType<Downbutton>();
        leftbutton = FindObjectOfType<Leftbutton>();
        rightbutton = FindObjectOfType<Rightbutton>();
        MainCamera = Camera.main;
        cursor = GameObject.Find("ControlPoint");
        positions = FindObjectOfType<initialize>().positions;
        states = FindObjectOfType<initialize>().states;
        stepcount = FindObjectOfType<initialize>().stepcount;
        Debug.Log("start1");
        print(positions[0]);
        print(positions.Count);
        Debug.Log("start2");
        print(states[1]);
        print(states.Count);
        Debug.Log("start3");
        //print(MainCamera);
        //Zposition = MainCamera.WorldToScreenPoint(transform.position).z;
    }

    // Update is called once per frame
    void Update()
    {
        int start;
        int target;
        //Debug.Log("update1");
        SelectionManager SM = cursor.GetComponent<SelectionManager>();
        if (SM._selection != null)
        {
            if (SM._selection.name == gameObject.name)
            {
                //Debug.Log("update3");
                int selectedindex = SM._selection.transform.GetSiblingIndex();
                //up button
                print(selectedindex);
                if (upbutton.Pressed)
                {
                    start = states[selectedindex];
                    int x, y, z;
                    x = start / 9;
                    y = (start % 9) / 3;
                    z = start % 3;
                    //print(x);
                    //print(y);
                    //print(z);
                    target = start - 3;
                    if (y > 0)
                    {

                        if (is_pos_available(target, states))
                        {
                            //Debug.Log("update5");
                            gameObject.transform.localPosition = positions[target];
                            states[selectedindex] = target;
                            stepcount[0] += 1;
                        }
                    }
                }

                if (downbutton.Pressed)
                {

                    start = states[selectedindex];
                    int x, y, z;
                    x = start / 9;
                    y = (start % 9) / 3;
                    z = start % 3;
                    print(x);
                    print(y);
                    print(z);
                    target = start + 3;
                    if (y < 2)
                    {

                        if (is_pos_available(target, states))
                        {
                            gameObject.transform.localPosition = positions[target];
                            states[selectedindex] = target;
                            stepcount[0] += 1;
                        }
                    }
                }

                if (leftbutton.Pressed)
                {
                    start = states[selectedindex];
                    int x, y, z;
                    x = start / 9;
                    y = (start % 9) / 3;
                    z = start % 3;
                    print(x);
                    print(y);
                    print(z);
                    target = start + 9;
                    if (x < 2)
                    {

                        if (is_pos_available(target, states))
                        {
                            gameObject.transform.localPosition = positions[target];
                            states[selectedindex] = target;
                            stepcount[0] += 1;
                        }
                    }
                }
                if (rightbutton.Pressed)
                {
                    start = states[selectedindex];
                    int x, y, z;
                    x = start / 9;
                    y = (start % 9) / 3;
                    z = start % 3;
                    print(x);
                    print(y);
                    print(z);
                    target = start - 9;
                    if (x > 0)
                    {

                        if (is_pos_available(target, states))
                        {
                            gameObject.transform.localPosition = positions[target];
                            states[selectedindex] = target;
                            stepcount[0] += 1;
                        }
                    }
                }
            }
        }
    }

    

    
    bool is_pos_available(int index, List<int> states)
    {
        bool free = true;
        if (index > 26 || index < 0)
        {
            return false;
        }
        for (int i = 0; i < 9; i++)
        {
            if (states[i] == index)
            {
                free = false;
            }
        }
        return free;
    }
}
