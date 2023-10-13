using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ascenceur : MonoBehaviour
{
    public float speed;
    public float MaxX;
    public float MinX;
    public float MaxY;
    public float MinY;
    public float DirectX;
    public float DirectY;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;
        position.x += DirectX * speed * Time.deltaTime;
        position.y += DirectY * speed * Time.deltaTime;
        transform.position = position;
        UpdatePos(position);
    }

    private void UpdatePos(Vector2 p)
    {
        if(p.x < MinX || p.x > MaxX)
        {
            DirectX *= -1;
        }
        if (p.y < MinY || p.y > MaxY)
        {
            DirectY *= -1;
        }
    }
}
