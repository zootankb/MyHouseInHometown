using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamAutoRotate : MonoBehaviour
{
    [Header("旋转速度")]
    [Range(0, 100f)]
    private float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, Time.deltaTime * speed, 0);
    }
}
