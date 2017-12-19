using UnityEngine;
using System.Collections;

public class Defender : MonoBehaviour {

    public int coracaoCusto = 0;
    public AudioClip defenderHurtSound, defenderAttackSound, defenderDeathSound;

    private CoracaoDisplay coracaoDisplay;
    private Animator animator;
    private AudioSource audioSource;
    private GameTimer gameTimer;
    private bool isGameWon;
 
    void Start()
    {
        coracaoDisplay = GameObject.FindObjectOfType<CoracaoDisplay>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        gameTimer = GameObject.FindObjectOfType<GameTimer>();
        isGameWon = false;
        
    }
    

    public void AddCoracao (int corValue)
    {
        print(corValue);
        coracaoDisplay.AddCoracao(corValue);
        Debug.Log(corValue + "adicionado");
        coracaoDisplay.UpdateDisplay();
    }


    void OnTriggerStay2D(Collider2D collider)
    {

        Attacker attacker = collider.gameObject.GetComponent<Attacker>();

        if (attacker)
        {
            animator.SetBool("isHurt", true);
        }
    }

    public void getHurtSound()
    {
        AudioSource.PlayClipAtPoint(defenderHurtSound, transform.position, 0.25f);
    }

    public void attackNowSound()
    {
        AudioSource.PlayClipAtPoint(defenderAttackSound, transform.position, 0.35f);
    }

    public void getDeadSound()
    {
        AudioSource.PlayClipAtPoint(defenderDeathSound, transform.position, 0.45f);
    }
    
    public void winGame()
    {
        animator.SetTrigger("isVictory");
        isGameWon = true;
    }

    void Update()
    {
        bool timeIsUp = (Time.timeSinceLevelLoad >= gameTimer.levelTime);
        if (timeIsUp &&!isGameWon)
        {
            winGame();
        }
        
    }


   

}
