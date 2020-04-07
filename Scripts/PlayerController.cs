using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Player controller.
/// control move, alive, ect,.
/// </summary>

public class PlayerController : MonoBehaviour
{

    //move speed
    public float speed = 5;
    // life value
    private int maxHealth = 5;
    private int currentHealth;

    public int myMaxHealth{
        get{
            return maxHealth;
        }
    }

    public int myCurrentHealth{
        get{
            return currentHealth;
        }
    }

    private float invincibleTime = 2f;
    private float invincibleTimer;
    private bool isinvincible;


    Rigidbody2D rbody;





    // Start is called before the first frame update
    void Start()
    {
        currentHealth = 2;
        invincibleTimer = 0;
        rbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //control x(A:-1 D:1)
        float moveX = Input.GetAxisRaw("Horizontal");
        //control y(W:1; S:-1)
        float moveY = Input.GetAxisRaw("Vertical");

        Vector2 position = rbody.position;
        position.x += moveX * speed * Time.deltaTime;
        position.y += moveY * speed * Time.deltaTime;
        rbody.MovePosition(position);


        if(isinvincible){
            invincibleTimer -= Time.deltaTime;
            if(invincibleTimer<0){
                isinvincible = false;
            }
        }

                           
    }

    public void ChangeHealth(int amount)
    {
        //when player be hurt
        if(amount<0){
            if (isinvincible == true)
                return;
            isinvincible = true;
        }

        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);

    }
}
