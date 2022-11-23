using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private GameObject cameraPos;
    private GameObject mainCamera;
    private float timer;
    private GameObject Player;
    [SerializeField] private float speed = 5;
    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }
    void Update()
    {
        float distance = Vector3.Distance(gameObject.transform.position, cameraPos.transform.position);
        if (gameObject.transform.position != cameraPos.transform.position && distance >= 0.1)
        {
            gameObject.transform.position = Vector3.Lerp(transform.position, cameraPos.transform.position, Time.deltaTime * speed);
        }
    }
}

