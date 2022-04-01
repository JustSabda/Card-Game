using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Popout : MonoBehaviour
{
    private Ray ray;
    private RaycastHit hit;
    void Start()
    {

    }

    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //hit.transform.CompareTag("Untagged");
        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log("Hit");
        }
    }
}
