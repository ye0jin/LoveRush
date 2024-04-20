using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField] private float speed;
    private void Update()
    {
        transform.position += Time.deltaTime * speed * Vector3.left;
    }
}
