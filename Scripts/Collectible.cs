using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Eat food 
/// Gain power
/// </summary>
public class Collectible : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController playerController = collision.GetComponent<PlayerController>();

        if(playerController !=null){

            if (playerController.myCurrentHealth<playerController.myMaxHealth){
                playerController.ChangeHealth(1);
                Destroy(this.gameObject);
            }

            Debug.Log("Get food");

        }
    }
}
