using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardPatrol : MonoBehaviour
{
    public float speed = 2f;
    public float spread = 3f;
    public float transformSpeed = 2f;
    public float transformStrength = 0.3f;

    public float rotationSpeed = 60f;

    public bool movementInAxisY;
    public bool movementInAxisZ;
    public bool movementInAxisX;
    public bool rotateOnY;
    public bool rotateOnZ;
    public bool rotateOnX;
    public bool reverse;
    public bool pulsateOn;

    private Vector3 startPos;
    private Vector3 baseScale;   
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        baseScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        // Determine direction multiplier
        float dir = reverse ? -1f : 1f;

        float x = Mathf.Sin(Time.time * speed) * spread * dir;
        float z = Mathf.Cos(Time.time * speed) * spread * 0.5f * dir;
        float y = Mathf.Cos(Time.time * speed) * spread * dir;

        float sx = 1 + Mathf.Sin(Time.time * transformSpeed) * transformStrength;
        float sy = 1 + Mathf.Sin(Time.time * transformSpeed) * transformStrength;
        float sz = 1 + Mathf.Sin(Time.time * transformSpeed) * transformStrength;

        // Rotation
        if (rotateOnY)
        {
            transform.RotateAround(transform.position, Vector3.up, rotationSpeed * Time.deltaTime * dir);
        }

        if (rotateOnZ)
        {
            transform.RotateAround(transform.position, Vector3.forward, rotationSpeed * Time.deltaTime * dir);
        }

        if (rotateOnX)
        {
            transform.RotateAround(transform.position, Vector3.right, rotationSpeed * Time.deltaTime * dir);
        }

        // Movement
        Vector3 moveOffset = Vector3.zero;
        if (movementInAxisX) moveOffset.x = x;
        if (movementInAxisY) moveOffset.y = y;
        if (movementInAxisZ) moveOffset.z = z;
        transform.position = startPos + moveOffset;

        // Pulsate
        if (pulsateOn)
        {
            transform.localScale = new Vector3(sx, sy, sz);
        }
    }
}
