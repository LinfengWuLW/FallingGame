using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public event System.Action OnPlayerDeath;
    
    public float speed = 7;

    float halfPlayerWidth;
    float screenHalfWidthInWorldUnits;

    float cameraAspect=3/5f;

    
    void Start()
    {
        halfPlayerWidth = transform.localScale.x / 2;
        //screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize;
        screenHalfWidthInWorldUnits = cameraAspect * Camera.main.orthographicSize;
        
    }

    void Update()
    {
        //print(Camera.main.aspect);
        
        float inputX = Input.GetAxisRaw("Horizontal");
        float velocity = inputX * speed;

        transform.Translate(Vector3.right * velocity * Time.deltaTime);

        if (transform.position.x < -screenHalfWidthInWorldUnits-halfPlayerWidth)
        {
            transform.position = new Vector2(screenHalfWidthInWorldUnits, transform.position.y);
        }
        if (transform.position.x > screenHalfWidthInWorldUnits+halfPlayerWidth)
        {
            transform.position = new Vector2(-screenHalfWidthInWorldUnits, transform.position.y);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "FallingBlock")
        {
            if (OnPlayerDeath != null)
            {
                OnPlayerDeath();
            }

            Destroy(gameObject);
        }

        if (collision.tag == "Bonus")
        {
            Difficulty.bonusNumber++;

            Destroy(collision.gameObject);
        }
    }


}
