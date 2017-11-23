using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

    public GameObject projectile, FirePoint;

    private GameObject projectileParent;
    private Animator animator;
    private AttackerSpawner myLaneSpawner;

    void Start()
    {
        animator = GameObject.FindObjectOfType<Animator>();

        projectileParent = GameObject.Find("Projectiles");
        if (!projectileParent)
        {
            projectileParent = new GameObject("Projectiles");
        }

        SetMyLaneSpawner();
    }


    void Update()
    {
        if (AttackerInFront())
        {
            animator.SetBool("isAttacking", true);

        }   else {
            animator.SetBool("isAttacking", false);
            animator.SetBool("isHurt", false);
        } 
    }

    bool AttackerInFront ()
    {
        if (myLaneSpawner.transform.childCount <= 0)
        {
            return false;
        }
                
        foreach (Transform attacker in myLaneSpawner.transform)
        {
            if (attacker.transform.position.x > transform.position.x)
            {
                return true;
            }
        }
        return false; //Attackers in lane, but behind defenders;
    }


  
    void SetMyLaneSpawner() //Look for lane spawner
    {
        AttackerSpawner[] spawnerArray = GameObject.FindObjectsOfType<AttackerSpawner>();
        foreach(AttackerSpawner spawner in spawnerArray)
        {
            if (spawner.transform.position.y == transform.position.y)
            {
                myLaneSpawner = spawner;
                return;
            } 
        }

        Debug.LogError(name + " can't find spawner in lane");

    }

    private void Fire()
    {
        GameObject newProjectile = Instantiate(projectile) as GameObject;
        newProjectile.transform.parent = projectileParent.transform;
        newProjectile.transform.position = FirePoint.transform.position;
    }
    

}
