
using UnityEngine;

public class BallCollision : MonoBehaviour
{    
    //Creating Game Object to check Collision
    public GameObject ball;
    void OnCollisionEnter(Collision collision)
    {  //checking collision with netto add score
        if (collision.collider.tag == "Net")
        {

            Score.scoreValue += 10;
            
        RestartPosition();
        
        }
        //checking collision with object that makes player lose points
        if (collision.collider.tag == "Lose")
        {

            Score.scoreValue -= 10;

            RestartPosition();

        }

    }

    public void RestartPosition()
    {  //A function that sets the ball position at starting point after the collision with specified object and sets the velocity and speed to 0
        transform.position = new Vector3(11.7f, 0.05f, 0);
        ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
        ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        

    }
}
