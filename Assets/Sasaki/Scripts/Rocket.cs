using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    private Animator anim = null;
    private GameObject player;
    [SerializeField]
    private GameObject flame;
    bool pushCheck = false;
    bool playerCheck = false;
    [SerializeField,Header("ÉçÉPÉbÉgî≠éÀÇ‹Ç≈ÇÃéûä‘")]
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (pushCheck)
        {
            time -= Time.deltaTime;
            if (time <= 0)
            {
                playerCheck = true;

                flame.SetActive(true);
                anim.SetTrigger("Rocket");
                time = 0;
            }
        }
        if (playerCheck)
        {
            player.gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            pushCheck = true;
            playerCheck = true;
        }
    }
}
