using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
        private void OnCollisionEnter(Collision collider)
    {      
              print("collision");
                Destroy(this);   
               
     }
}
