using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Enemy controller.
/// </summary>
public class EnemyController : MonoBehaviour
{
    public float speed = 3f;

    public bool isVertical;

    private Vector2 moveDirection;

    public float changeDirectionTime;
    public float changeTimer;


    private Rigidbody2D rbody;




    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();

        moveDirection = isVertical ? Vector2.up : Vector2.right;

        changeTimer = changeDirectionTime;
    }

    // Update is called once per frame
    void Update()
    {
        changeTimer -= Time.deltaTime;
        if(changeTimer<0){
            moveDirection *= -1;
            changeTimer = changeDirectionTime;
        }
        Vector2 position = rbody.position;
        position.x += moveDirection.x * speed * Time.deltaTime;
        position.y += moveDirection.y * speed * Time.deltaTime;
        rbody.MovePosition(position);
    }

     void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
        if(playerController!=null){
            playerController.ChangeHealth(-1);
        }
    }
}
