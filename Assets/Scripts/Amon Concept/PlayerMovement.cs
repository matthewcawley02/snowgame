using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject playerParent;
    public float speed;
    public Transform feet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        // Horizontal Movement
        float x = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(x*speed, 0f, 0f);
        playerParent.transform.Translate(movement * Time.deltaTime);

        // Staying on the ground - works for going up and down ramps
        RaycastHit2D hit = Physics2D.Raycast(feet.position, Vector2.down);
        if (hit.collider != null) {
            playerParent.transform.Translate(0f, 1f-hit.distance, 0f);
        }

    }
}
