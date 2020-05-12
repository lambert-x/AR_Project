using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class initialize : MonoBehaviour
{
    public List<Vector3> positions = new List<Vector3>();
    public List<int> states = new List<int>();
    //public int[] states;
    public GameObject fruits;
    public GameObject fridge;
    private Vector3 p_init,p_base;
    private int[] indexs;
    private Move3D move;
    Text step;
    public List<int> stepcount = new List<int>();
    // Start is called before the first frame update
    void Start()
    {
        stepcount.Add(0);
        //move = FindObjectOfType<Move3D>();
        step = GameObject.Find("Step").GetComponent<Text>();
        fridge = GameObject.Find("/MultiTarget/Fridge");
        //fruits = GameObject.FindGameObjectsWithTag("Selectable");
        fruits = GameObject.Find("/MultiTarget/Fridge/fruits");
        //Debug.Log('1');
        //Debug.Log(fruits.Length);
        //Debug.Log('2');
        //Debug.Log(fridge);
        p_base = fruits.transform.position;
        //p_init.Set(p_base.x - 0.1f, p_base.y + 1.7f, p_base.z + 0.2f);
        p_init.Set(- 0.1f, 1.7f, 0.2f);
        //Debug.Log(positions.Length);
        //Debug.Log(100);
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                for (int k = 0; k < 3; k++)
                {
                    //Debug.Log(i * 9 + (3 * j) + k);
                    //Debug.Log(100);
                    positions.Add(p_init + new Vector3(i * 0.15f, j * (-0.1f), k * (-0.1f)));
                }
            }
        }
        //Debug.Log(positions.Count);
        //Debug.Log(3);
        indexs = new int[] { 2, 4, 21, 9, 3, 24, 11, 13, 17 };
        //states = new int[9];

        //set the initial states
        for (int i = 0; i < 9; i++)
        {
            states.Add(indexs[i]);
            print(states[i]);
        }
        for( int count = 0; count < 9;count++)
        {
            Transform fruit = fruits.transform.GetChild(count);
            //print(fruit.position);
            int index = indexs[count];
            
            //print(index);
            //Debug.Log(fruit);
            //print(positions[index]);
            fruit.localPosition = new Vector3(positions[index].x, positions[index].y, positions[index].z);
       
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!success(states))
        {
            step.text = "Steps:" + stepcount[0].ToString();
        }
        else
        {
            step.text = "You win with steps:" + stepcount[0].ToString();
        }
        
    }
    bool success(List<int> states)
    {
        //bool pear, straw, apple;

        for (int i=0;i<3;i++)
            for (int j=0;j<3;j++)
            {
                int floor = (states[3 * i] % 9) / 3;
                if ((states[3 * i + j] % 9)/3!=floor)
                {
                    return false;
                }
            }
        return true;
    }
}
