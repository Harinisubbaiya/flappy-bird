using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pillar_spawner : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] pillar;
    public float timer;
    public float spawn_until_nexttime;
    public bool canspawn;

    public float pillar_speed;
    void Start()
    {
        Spawn();
        canspawn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canspawn == true)
        {
            if (timer < spawn_until_nexttime)
            {
                timer += Time.deltaTime;
            }
            else
            {
                Spawn();
                timer = 0;
            }
        }
    }
    void Spawn()
    {
        int random_number =Random.Range(0,5);
        Instantiate(pillar[random_number ], transform.position, Quaternion.identity);
    }
}
