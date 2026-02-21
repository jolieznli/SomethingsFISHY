using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishprops : MonoBehaviour
{
 public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
   void Update()
    {
        GetComponent<Transform>().position -= new Vector3(moveSpeed * Time.deltaTime, 0, 0);
        Destroy(gameObject, 3f);

    }
             private void OnCollisionEnter(Collision collision)
    {
        //Destroy(gameObject);
    }
}
