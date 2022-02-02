using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    private GameObject player;
    private Vector3 offset;
    
    private void Awake()
    {
        player = FindObjectOfType<PlayerMove>().gameObject;
    }
    
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    void Update()
    {
        transform.position = offset + player.transform.position;
    }
}
