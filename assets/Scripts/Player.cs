using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float MouseSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W)){
            transform.Translate(new Vector3(0, 0 , 5 * Time.deltaTime));
        }
        if(Input.GetKey(KeyCode.A)){
            transform.Translate(new Vector3(-1, 0 , 0 * Time.deltaTime));
        }

        if(Input.GetKey(KeyCode.S)){
            transform.Translate(new Vector3(0, 0 , -5 * Time.deltaTime));
        }
        if(Input.GetKey(KeyCode.D)){
            transform.Translate(new Vector3(1, 0 , 0 * Time.deltaTime));
        }

        transform.Rotate(new Vector3 (0 , Input.GetAxis("Mouse X") * MouseSpeed * Time.deltaTime,0));
    }
}
