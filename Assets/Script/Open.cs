using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject key1 = GameObject.FindWithTag("Key1");
        if (key1!=null)
        {
            Debug.Log("yes");
        }
        else
        {
            Debug.Log("no");
        }
    }

  
}
