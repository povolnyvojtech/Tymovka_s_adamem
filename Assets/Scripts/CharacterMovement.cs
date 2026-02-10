using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 10f;

    private void FixedUpdate()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        
        transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);
    }
}