using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject[] children;
    public Sprite[] open_sprites;
    public Sprite[] closed_sprites;
    public static Door instance = null;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    void Start()
    {
        BoxCollider2D boxCollider = instance.GetComponent<BoxCollider2D>();
        boxCollider.isTrigger = false;
    }

    public void OpenDoor()
    {
        for (int i = 0; i < 9; i++)
        {
            children[i].GetComponent<SpriteRenderer>().sprite = open_sprites[i];
        }

        BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();
        boxCollider.isTrigger = true;
    }
}
