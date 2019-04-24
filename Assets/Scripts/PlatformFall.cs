using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFall : MonoBehaviour
{
    public float fallDelay = 1f;
    private Rigidbody2D rigidbody2D;

    /// <summary>
   /// </summary>
    
    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

        rigidbody2D.isKinematic = true;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") == true)
        {
            Invoke("Fall", fallDelay);
        }
    }

    // Update is called once per frame
    void Fall()
    {
        rigidbody2D.isKinematic = false;
        
    }
}
