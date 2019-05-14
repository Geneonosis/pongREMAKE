using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddleController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject pong_ball = null;

    void Start()
    {
        this.gameObject.transform.Translate(new Vector3(0, pong_ball.transform.position.y, 0));
    }

    // Update is called once per frame
    void Update()
    {
        //this.gameObject.transform.Translate(new Vector3(0, pong_ball.transform.position.y, 0));
        try{
            print(pong_ball.transform.position.y);
        }catch(MissingReferenceException e)
        {
            pong_ball = GameObject.FindWithTag("Ball");
        }
    }

    private void FixedUpdate()
    {

    }
}
