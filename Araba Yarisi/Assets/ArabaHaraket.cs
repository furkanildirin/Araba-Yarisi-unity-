using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArabaHaraket : MonoBehaviour
{
    bool endgame = false;
    public int puan = 0;
    // Start is called before the first frame update
    void Start()
    {
        puan = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(endgame == false)
        GetComponent<Rigidbody>().AddForce(Vector3.left*6,ForceMode.Force);
        else if(endgame == true)
                GetComponent<Rigidbody>().velocity = Vector3.zero;

        if (Input.GetKey("d"))
        {
            GetComponent<Rigidbody>().AddForce(0, 0, 12, ForceMode.Force);

        }
        if (Input.GetKey("a"))
        {
            GetComponent<Rigidbody>().AddForce(0, 0, -12, ForceMode.Force);

        }
        if (GetComponent<Rigidbody>().position.x <= -335.8)
        {
            endgame = true;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            Invoke("restart", 1.5f);

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Engel")
        {
            
            Invoke("restart", 1.5f);
            endgame = true;
            

        }
        if (collision.collider.tag == "coin")
        {
            puan++;
            Destroy(collision.gameObject);
        }
    }

    private void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        endgame = false;


    }

}

