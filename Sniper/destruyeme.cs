using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destruyeme : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void destruye()
    {
        Destroy(transform.parent.gameObject);
    }
}
