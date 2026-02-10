using UnityEngine;

public class CharacteController : MonoBehaviour
{

    public float speed = 10f;
    public Rigidbody2D rb;


    // Update is called once per frame
    void Update()
    {
        var moveHorizontal = Input.GetAxis("Horizontal");
        
        rb.linearVelocity = new Vector2 (moveHorizontal*speed, 0);
    }
}
