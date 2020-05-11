using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] private string selectableTag = "Selectable";
    [SerializeField] private Material highlightMaterial;
    [SerializeField] private Material defaultMaterial;
    //public GameObject joycursor;
    Vector3 screenPos;
    Vector2 screenPos_2;
    public Transform _selection;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (_selection != null)
        {
            var selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer.material = defaultMaterial;
            _selection = null;
        }
        //if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        //{

        //var ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
        // var ray = Camera.main.ScreenPointToRay(transform.position);
        screenPos = Camera.main.WorldToScreenPoint(transform.position);
        screenPos_2.Set(screenPos.x, screenPos.y);
        var ray = Camera.main.ScreenPointToRay(screenPos_2);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            //Debug.Log(transform.position);
            //Debug.Log(screenPos_2);
            if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
            {
                //Debug.Log(Input.GetTouch(0).position);
            }
            var selection = hit.transform;
            //Debug.Log(hit.transform.name);
            if (selection.CompareTag(selectableTag))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
                if (selectionRenderer != null)
                {
                    selectionRenderer.material = highlightMaterial;
                }
                _selection = selection;
            }
        }
    //}
    }
}
