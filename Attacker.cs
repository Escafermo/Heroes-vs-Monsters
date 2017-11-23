using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody2D))]
public class Attacker : MonoBehaviour {

    private float CurrentWalkSpeed;
    private LoseCollider loseCollider;
    private LevelManager levelManager;
    private static bool isGameWon;

    public Animator animator;
    public float appearRateSeconds; //How rare is this enemy - average number of seconds between appearences
    public GameObject currentTarget;
    public AudioClip attackerAppearSound, attackerAttackSound, attackerDeathSound;


    void Start () {
        animator = GetComponent<Animator>();

        loseCollider = GameObject.FindObjectOfType<LoseCollider>();

        levelManager = GameObject.FindObjectOfType<LevelManager>();

        isGameWon = false;
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.left * CurrentWalkSpeed * Time.deltaTime);
        if (!currentTarget)
        {
              animator.SetBool("isAttacking", false);
        }

        if (isGameWon == true)
        {
            animator.SetTrigger("isAttackerVictory");
        }

	}

    public void SetSpeed (float speed)
    {
        CurrentWalkSpeed = speed;
    }


    public void StrikeCurrentTarget (float damage)
    {

        int difficulty = (int)PlayerPrefsManager.GetDifficulty();

        if (difficulty == 1)
        {
            if (currentTarget)
            {
                Life currentHealth = currentTarget.GetComponent<Life>();
                float damageDiff = damage * (1f / 2f);
                
                if (currentHealth)
                {
                    currentHealth.DealDamage(damageDiff);
                }
            }
        }

        if (difficulty == 2)
        {
            if (currentTarget)
            {
                Life currentHealth = currentTarget.GetComponent<Life>();
                                
                if (currentHealth)
                {
                    currentHealth.DealDamage(damage);
                }
            }
        }

        if (difficulty == 3)
        {
            if (currentTarget)
            {
                Life currentHealth = currentTarget.GetComponent<Life>();
                float damageDiff = damage * 2f;
                                
                if (currentHealth)
                {
                    currentHealth.DealDamage(damageDiff);
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject obj = collider.gameObject;
        
       if (obj.GetComponent<LoseCollider>() && !isGameWon)
        {

            isGameWon = true;

            Invoke("LoseNow", 5);

       } else if (obj.GetComponent<Defender>())
        {
            animator.SetBool("isAttacking", true);
            Attack(obj);
            Debug.Log("Attack" + obj);
        }
    }

    public void LoseNow()
    {
        levelManager.LoadLevel("03b Lose");

    }

    public void Attack (GameObject obj)
    {
        currentTarget = obj;
    }

    public void appearNowSound()
    {
        AudioSource.PlayClipAtPoint(attackerAppearSound, transform.position, 0.25f);
    }
    

    public void attackNowSound()
    {
        AudioSource.PlayClipAtPoint(attackerAttackSound, transform.position, 0.15f);
    }

 
    public void getDeadSound()
    {
        AudioSource.PlayClipAtPoint(attackerDeathSound, transform.position, 0.35f);
    }


}