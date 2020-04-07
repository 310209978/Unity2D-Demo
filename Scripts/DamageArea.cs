using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Damage area.
/// Hurt Health.
/// </summary>
public class DamageArea : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D collider2D)
    {
        PlayerController playerController = collider2D.GetComponent<PlayerController>();
        if (playerController!= null){
            playerController.ChangeHealth(-1);
        }
    }
}
