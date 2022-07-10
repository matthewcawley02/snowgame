using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowController : MonoBehaviour
{

    private Camera mainCamera;
    private ParticleSystem snow;
    private ParticleSystem.ShapeModule snowShape;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        snow = GetComponent<ParticleSystem>();
        snowShape = snow.shape;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 snowPos = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height/2, 0));
        snowPos.y = snowPos.y * -1;
        snowShape.position = snowPos;
        snowShape.radius = mainCamera.orthographicSize * 4;
    }
}
