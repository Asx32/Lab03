using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public SpriteRenderer door;
    public Sprite doorOpen;
    public Sprite leverUsed;
    private SpriteRenderer toggle;
    // Start is called before the first frame update
    void Start()
    {
        toggle = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player")
        {
            toggle.sprite = leverUsed;
            door.sprite = doorOpen;
        }
    }
}
