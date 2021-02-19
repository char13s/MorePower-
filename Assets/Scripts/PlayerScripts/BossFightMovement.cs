using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFightMovement : MonoBehaviour
{
    [SerializeField] private GameObject bossPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(bossPosition.transform.position,Vector3.up,Time.deltaTime); 
    }
}
