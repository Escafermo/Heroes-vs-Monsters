using UnityEngine;
using System.Collections;

public class Life : MonoBehaviour {

    public float currentHealth;

    private Animator animator;

    private void Start()
    {
        animator = FindObjectOfType<Animator>();
    }

    public void DealDamage (float damage)
    {
        currentHealth -= damage;

        if (currentHealth < 0)
        {
            animator.SetTrigger("isDying");
            Invoke ("DestroyObject", 2);            
        }
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }


}
