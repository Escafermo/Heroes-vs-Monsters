using UnityEngine;
using System.Collections;

public class Projectiles : MonoBehaviour {

    public float speed, damage;

   
    void Update () {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        Attacker attacker = collider.gameObject.GetComponent<Attacker>();
        Life life = collider.gameObject.GetComponent<Life>();
        
        if (attacker && life)
        {

            int difficulty = (int)PlayerPrefsManager.GetDifficulty();

            if (difficulty == 1)
            {
                float damageDiff = damage * (1f * 1.42f);
                life.DealDamage(damageDiff);
                Destroy(gameObject);
            }

            if (difficulty == 2)
            {
                life.DealDamage(damage);
                Destroy(gameObject);
            }

            if (difficulty == 3)
            {
                float damageDiff = damage * (1f / 1.42f);
                life.DealDamage(damageDiff);
                Destroy(gameObject);
            }

        }

    }
}
