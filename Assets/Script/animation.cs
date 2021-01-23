/****************************************
 * Name:riley mitchell
 * Date:1/3/2021
 * Desc: flips through inputed frames
 * *************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animation : MonoBehaviour
{
    public Sprite[] list;
    public float speed = 0;
    int size;
    float timer = 0f;
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        size = list.Length;
    }

    // Update is called once per frame
    void Update()
    {
        spriteRenderer.sprite = list[Mathf.FloorToInt((timer / speed) % size)];
        timer += Time.deltaTime;
    }
}
