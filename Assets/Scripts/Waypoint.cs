using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public float duration = 20f;

    private float min  = 0f;
    private float max = 1f;
    private Material mat;
    private SpriteRenderer spriteRenderer;
    private float startTime;

    // Use this for initialization
    void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        FadeOutSprite();
        if (spriteRenderer.color.a == 0f)
        {
            Destroy(gameObject);
        }
    }

    void LateUpdate()
    {
        Vector3 lookAtVect = new Vector3(Camera.main.transform.position.x, transform.position.y, Camera.main.transform.position.z);
        transform.LookAt(lookAtVect, Vector3.up);
    }

    void FadeOutSprite()
    {
        float t = (Time.time - startTime) / duration;
        spriteRenderer.color = new Color(1f, 1f, 1f, Mathf.SmoothStep(max, min, t));
    }

}
        
