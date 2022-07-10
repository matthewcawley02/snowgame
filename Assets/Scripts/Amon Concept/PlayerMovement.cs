using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject playerParent;
    public float speed;
    public Transform feet;

    private float maxVertical = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        // Horizontal Movement
        float x = Input.GetAxis("Horizontal");
        Vector2 wallDir = Vector2.up;
        // Wall
        if (x > 0) {
            wallDir = Vector2.right;
        } else if (x < 0) {
            wallDir = Vector2.left;
        }
        Vector3 movement = new Vector3(x * speed, 0f, 0f);
        RaycastHit2D hit1 = Physics2D.Raycast(feet.position - new Vector3(0f, 0.5f, 0f), wallDir);
        RaycastHit2D hit2 = Physics2D.Raycast(feet.position, wallDir);
        if (hit1.collider != null && hit2.collider != null) {
            float rampAngle = Mathf.Tan((0.5f) / (Mathf.Abs(hit1.distance - hit2.distance)));
            if (hit1.distance == hit2.distance) {
                rampAngle = 90;
            }
            Debug.Log(hit1.distance);
            Debug.Log(hit2.distance);
            print(rampAngle);
            if (rampAngle < 20 || (hit1.distance > 1f && hit2.distance > 1f)) {
                movement = new Vector3(x * speed, 0f, 0f);
            } else {
                movement = Vector3.zero;
            }
        }


        playerParent.transform.Translate(movement * Time.deltaTime);

        // Staying on the ground - works for going up and down ramps
        RaycastHit2D hit = Physics2D.Raycast(feet.position, Vector2.down);
        if (hit.collider != null) {
            playerParent.transform.Translate(0f, Mathf.Max(Mathf.Min(1f-hit.distance, maxVertical), -maxVertical), 0f);
        }
    }
}
