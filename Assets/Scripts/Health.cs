using UnityEngine;

public class Health : MonoBehaviour
{
   [SerializeField] int health=50;
   [SerializeField] bool isPlayer;
   [SerializeField] int scorevalue=50;
   [SerializeField] ParticleSystem hitParticles;
   [SerializeField] bool applyCameraShake;
   CameraShake cameraShake;
   AudioManager audioManager;
   ScoreKeeper scoreKeeper;
    void Start()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        audioManager=FindFirstObjectByType<AudioManager>();
        scoreKeeper = FindFirstObjectByType<ScoreKeeper>();
    }
    void OnTriggerEnter2D(Collider2D other) 
    {
        DamageDealer damageDealer=other.GetComponent<DamageDealer>();
    
        if (damageDealer != null)
        {
            TakeDamage(damageDealer.GetDamage());
            PlayHitParticles();
            damageDealer.Hit();
            if (applyCameraShake)
            {
                cameraShake.Play();
            }
        }

    
    } 
    public void TakeDamage(int damage)
    {
        if (audioManager != null)
        {
            audioManager.PlayDamageSFX();
        }

        health -= damage;
        if (health <= 0)
        {

            Die();

        }
    }
    void Die()
    {
        if (!isPlayer && scoreKeeper != null)
        {
            scoreKeeper.modifyscore(scorevalue);
        }
        Destroy(gameObject);
    }
    void PlayHitParticles()
    {
        if(hitParticles != null)
        {
            ParticleSystem particles= Instantiate(hitParticles,transform.position,Quaternion.identity);
            Destroy(particles,particles.main.duration+particles.main.startLifetime.constantMax);
        }
    }
}
