using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public GameMaster GM;
    public GameObject GMobj;

    private Vector2 playerDirection;

    public Vector3 playerPosition;
    private Rigidbody2D rb;
    bool playerDashing = false;
    bool playerStunning = false;
    public GameObject Stun;

    //Temp variables because I can't be fucked
    float soundTimerReset = 0.4f;
    float soundTimer = 0f;
    bool soundAlternator = false;
    public bool IsImmortal = false;


    void Awake()
    {
        GMobj = GameObject.Find("GM");
        GM = GMobj.GetComponent<GameMaster>();
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        GetInput();
        Timers();
        playerPosition = this.transform.position;

        if (GM.PlayerCurrentHealth <= 0 && IsImmortal == false)
        {
            Die();
        }
    }

    void Timers()
    {
        //Dashtimer
        if (GM.DashTimer >= 0)
        {
            GM.DashTimer -= Time.deltaTime;
        }
        //Stuntimer
        if (GM.StunTimer >= 0)
        {
            GM.StunTimer -= Time.deltaTime;
        }
    }


    void GetInput()
    {
        //Player movement

        playerDirection = Vector2.zero;                                         //Zeroes the cameras direction
        if (Input.GetKey(KeyCode.W))                                            //Checks if W is being pressed
        {
            playerDirection += Vector2.up;                                      //Sets direction to up if W is being pressed
        }
        if (Input.GetKey(KeyCode.A))                                            //Checks if A is being pressed
        {
            playerDirection += Vector2.left;                                    //Sets direction to left if A is being pressed
        }
        if (Input.GetKey(KeyCode.S))                                            //Checks if S is being pressed
        {
            playerDirection += Vector2.down;                                    //Sets direction to down if S is being pressed
        }
        if (Input.GetKey(KeyCode.D))                                            //Checks if D is being pressed
        {
            playerDirection += Vector2.right;                                   //Sets direction to right if D is being pressed
        }

        //Player abilities
        if (Input.GetKey(KeyCode.LeftShift) && GM.DashTimer <= 0 && GM.PlayerCurrentRage > GM.DashRageCost)
        {
            playerDashing = true;
            GM.DashTimer = GM.DashCooldown;
            GM.PlayerCurrentRage -= GM.DashRageCost;
        }

        if (GM.DashDurationTimer >= 0 && playerDashing == true)
        {
            GM.DashDurationTimer -= Time.deltaTime;
        }

        if (GM.DashDurationTimer <= 0)
        {
            playerDashing = false;
            GM.DashDurationTimer = GM.DashDuration;
        }

        if (playerDashing == true)
        {
            rb.velocity = playerDirection * GM.PlayerMoveSpeed * GM.DashDistance * Time.deltaTime;
        }
        else
        {
            rb.velocity = playerDirection * GM.PlayerMoveSpeed * Time.deltaTime;
            if (playerDirection != Vector2.zero)
            {
                if (soundTimer <= 0)
                {
                    if (soundAlternator)
                    {
                        FindObjectOfType<AudioManager>().Play("Player Walk1");
                        soundAlternator = false;
                        soundTimer = soundTimerReset;
                    }
                    else
                    {
                        FindObjectOfType<AudioManager>().Play("Player Walk2");
                        soundAlternator = true;
                        soundTimer = soundTimerReset;
                    }
                }
            }
        }

        if (soundTimer >= 0)
        {
            soundTimer -= Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.F))
        {
            playerStunning = true;
        } else
        {
            playerStunning = false;
        }
        
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            PlayerMelee();
        }

        if (playerStunning && GM.StunTimer <= 0 && GM.PlayerCurrentRage >= GM.StunRageCost)
        {
            PlayerStun();
            GM.StunTimer = GM.StunCooldown;
            GM.PlayerCurrentRage -= GM.StunRageCost;
        }

        //Player shooting found in Player Shooting script
    }

    public void PlayerStun()
    {
        Instantiate(Stun, transform.position, transform.rotation);
    }
    public void PlayerMelee()
    {
        Debug.Log("Player Melee Logic not added yet");
    }

    void Die()
    {
        Destroy(gameObject);
        FindObjectOfType<PauseMenu>().DeathScreen();
    }
}
