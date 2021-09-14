using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayMove : MonoBehaviour
{
    public float speed;

    private void Update()
    {
        transform.Translate(new Vector3(0, 0, -1) * speed * Time.deltaTime);   
    }
}
