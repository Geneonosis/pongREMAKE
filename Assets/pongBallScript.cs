using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pongBallScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject newBall = null;
    GameObject ball = null;
    Rigidbody rb = null;
    int y = 0;
    int x = 0;
    Vector3 direction;
    [Range(0,5)][SerializeField] float multiplier;
    int enemy_score = 0;
    int player_score = 0;

    void Start()
    {
        ball = this.gameObject;
        rb = ball.GetComponent<Rigidbody>();
        direction = new Vector3(Random.Range(-6, 6),Random.Range(-6,6), 0);
        multiplier = 1;
        //rb.AddForce(new Vector3(x, y, 0));
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.gameObject;
        if (other.tag == "WALL")
        {
            Debug.Log("WALL");
            //Debug.Log(rb.velocity);
            direction.y *= -1;
            //rb.velocity = new Vector3(rb.velocity.x, y_flt, 0);
            //rb.AddForce(new Vector3(0, y, 0));
        }
        else if(other.tag == "Destroyer_LEFT" || other.tag == "Destroyer_RIGHT")
        {
            Debug.Log("Destroyer");
            Instantiate(newBall,new Vector3(0,0,0),new Quaternion(0,0,0,0));
            Destroy(this.gameObject);
            if(other.tag == "Destroyer_LEFT")
            {
                enemy_score += 1;
            }
            else if(other.tag == "Destroyer_RIGHT")
            {
                player_score += 1;
            }

            Debug.Log("Enemy Score = " + enemy_score);
            Debug.Log("Player Score = " + player_score);

        }
        else
        {
            //x = 1;
            //x *= -1;
            //rb.velocity = new Vector3(-rb.velocity.x, rb.velocity.y, 0);
            direction.x *= -1;
            //rb.AddForce(new Vector3(x, 0, 0));
        }
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * Time.deltaTime);
    }
}
