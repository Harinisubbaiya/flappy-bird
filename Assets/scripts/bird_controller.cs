using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;
using UnityEngine.SceneManagement;

public class bird_controller : MonoBehaviour
{
    Rigidbody rb;
    public float jump_force;

    public bool isGameOver;

    public pillar_spawner p_spawner;

    public int points;

    public TMP_Text points_text;

    public GameObject gameoverscreen;

    public TMP_Text final_points;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) & isGameOver == false)
        {
            rb.AddForce(Vector3.up * jump_force, ForceMode.Impulse);
        }
        if (rb.velocity.y < 0)
        {
            Physics.gravity = new Vector3(0, -30, 0);
        }
        else
        {
            Physics.gravity = new Vector3(0, -10, 0);

        }

        if(isGameOver ==true){
            gameoverscreen.SetActive(true);
            final_points.text = "total points: " +points;
        }
        else{
            gameoverscreen.SetActive(false);
        }
    }
    void OnCollisionEnter(Collision collision_obj)
    {
        if (collision_obj.gameObject.tag == "pillars" || collision_obj.gameObject.tag == "ground")
        {
            Debug.Log("collided with pillars");
            isGameOver = true;
            p_spawner.canspawn = false;
            p_spawner.pillar_speed = 0;
        }

    }

    void OnTriggerEnter(Collider collider_obj){
        if(collider_obj.gameObject.name=="trigger"){
        points += 1;
        points_text.text = "points: " + points;
        }
    }

    public void Replay(){
      SceneManager.LoadScene(0);
    }
}
