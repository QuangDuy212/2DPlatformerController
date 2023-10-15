using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAfterImageSprite : MonoBehaviour
{
    [Header("Info")]
    [SerializeField] private float activeTime = 0.1f;
    [SerializeField] private float alphaSet;
    [SerializeField] private float alphaDecay = 0.85f;

    private float timeActivated;//thời gian kích hoạt
    private float alpha;//hệ số màu

    private Transform player;
    private SpriteRenderer SR;
    private SpriteRenderer playerSR;

    private Color color;

    private void OnEnable()
    {
        SR = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerSR = player.GetComponent<SpriteRenderer>();

        alpha = alphaSet;
        SR.sprite = playerSR.sprite;
        transform.position = player.position;
        transform.rotation = player.rotation;
        timeActivated = Time.time;
    }

    private void Update()
    {
        alpha -= alphaDecay * Time.deltaTime;
        color = new Color(1f, 1f, 1f, alpha);
        SR.color = color;
        if(Time.time >= (timeActivated + activeTime))
        {
            //Add back to pool.
            PlayerAfterImagePool.Instance.AddToPool(gameObject);
        }
    }
}
