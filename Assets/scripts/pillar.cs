using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pillar : MonoBehaviour
{
    // Start is called before the first frame update
    private pillar_spawner p_spawner;
    void Start()
    {
     p_spawner = GameObject.Find("spawner").GetComponent<pillar_spawner>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < -35){
            Destroy(gameObject);
        }
     transform.position += Vector3.left* p_spawner.pillar_speed *Time.deltaTime; 

    }

    
}
