using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    Animator animControl;

    private bool attack;

    public Collider2D attackTrigger;
    public Collider2D atkTriggerJumpSx;
    public Collider2D atkTriggerJumpDx;
    public static bool player;
    public float coolDownTime = 1;

    public Slider slider;

    public int fallBoundary = -10;

    public class Stats
    {
        public float maxHealth;
        public float currentHealt;
    }

    Stats sts = new Stats();

    void Awake()
    {
        animControl = gameObject.GetComponent<Animator>();
        attackTrigger.enabled = false;
        atkTriggerJumpDx.enabled = false;
        atkTriggerJumpSx.enabled = false;

        player = true;
        sts.maxHealth = 200;
        sts.currentHealt = sts.maxHealth;

        slider.value = getHealth();

        
    }

    void Update()
    {

        fallCk();
        deathCk();

        if (coolDownTime > 0)
        {
            cdt();
        }

        slider.value = getHealth();

        groundAttackCtrl();
        jumpAttackCtrl();
        removeAtkTrigger();
        removeAtkTriggerJump();
    }

    void FixedUpdate()
    {
        setAttack();
        resetAtk();
    }

    private void setAttack()
    {
        if(coolDownTime <= 0)
        {
            if (attack)
            {
                if (!animControl.GetBool("Ground"))
                {
                    atkTriggerJumpDx.enabled = true;
                    atkTriggerJumpSx.enabled = true;
                }
                else
                {
                    attackTrigger.enabled = true;
                }
                animControl.SetTrigger("attack");
                coolDownTime = 1;
            }

        }
    }

    private void groundAttackCtrl()
    {
        if (Input.GetKeyDown("e"))
        {
            attack = true;
        }
    }

    private void jumpAttackCtrl()
    {
        if (Input.GetKeyDown("e") && !animControl.GetBool("Ground") || Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            attack = true;
        }
    }

    private void fallCk()
    {
        if (transform.position.y <= fallBoundary)
        {
            GameMaster.alive = false;
            player = false;
            playerDamage(999999);
        }
    }

    private void resetAtk()
    {
        attack = false;
    }

    private void removeAtkTrigger()
    {
        if (!animControl.GetCurrentAnimatorStateInfo(0).IsName("PlayerAttackAnim"))
        {
            attackTrigger.enabled = false;
        }
    }

    private void removeAtkTriggerJump()
    {
        if (!animControl.GetCurrentAnimatorStateInfo(0).IsName("JumpAtkAnim"))
        {
            atkTriggerJumpDx.enabled = false;
            atkTriggerJumpSx.enabled = false;
        }
    }

    public void playerDamage(int damage)
    {
        sts.currentHealt -= damage;
    }

    private void deathCk()
    {
        if (sts.currentHealt <= 0)
        {
            GameMaster.alive = false;
            player = false;
            GameMaster.KillPlayer(this);
        }
    }

    float getHealth()
    {
        return sts.currentHealt / sts.maxHealth;
    }


    public void cdt()
    {
        coolDownTime -= Time.deltaTime;
    }

}
