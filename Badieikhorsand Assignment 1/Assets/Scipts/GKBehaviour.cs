using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GKBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private float movementSpeed = 15f;
    private float Pos = 0.0f;
    private float ToRight = 1.0f;
    private float ToLeft = -1.0f;
    private bool movingToRight = true;

    // Update is called once per frame
    void Update()
    {
        if (movingToRight)
        {
            transform.position = transform.position + new Vector3(0, 0, ToRight* movementSpeed * Time.deltaTime);
            Pos = Pos + ToRight * movementSpeed* Time.deltaTime;
           
            if (Pos >= 8.0f)
                movingToRight = false;

        }
        if (!movingToRight)
        {
            transform.position = transform.position + new Vector3(0, 0, ToLeft* movementSpeed * Time.deltaTime);
            Pos = Pos + (ToLeft * movementSpeed* Time.deltaTime);
          
            if (Pos <= -8.0f)
                movingToRight = true;

        }


    }
}
