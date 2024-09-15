using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Stats")]
    public int HP = 8;
    int maxHP;
    public int Damage;
    public int baseDamage = 0;
    public int buffDamage = 0;
    public int def;
    public int baseDef = 0;
    public int MagicDef;
    public int baseMagicDef = 0;
    public int Coins;


    [Header("DLL")]
    public float durationDef;

    public float countdownAggro = 3f;
    public float countdownAggroTemp;
    public bool Inispawn;
    public Animator animator;
    public AudioSource DieSound;
    [Header("LayerDuri")]
    //cek Duri
    public LayerMask duri;
    public LayerMask duriAsli;
    public Transform Posisikaki;
    public bool IsDuri;

    //public GameObject Musuh;
    Enemy_Spawner _Spawner;
    Enemy_path path;
    Enemy_Aggro Aggro;
    Enemy enemy;
    ResourceManager resourceManager;
    private LayerMask none;
    // Start is called before the first frame update
    void Start()
    {
        maxHP = HP;
        baseDamage = Damage;
        baseDef = def;
        baseMagicDef = MagicDef;

        resourceManager = FindObjectOfType<ResourceManager>().GetComponent<ResourceManager>();
        _Spawner = GetComponentInParent<Enemy_Spawner>();
        path = GetComponent<Enemy_path>();
        Aggro = GetComponent<Enemy_Aggro>();
        enemy = GetComponent<Enemy>();

        countdownAggroTemp = countdownAggro;
        
    }

    // Update is called once per frame
    void Update()
    {
        HP = Mathf.Clamp(HP, 0, maxHP);

        if(durationDef <= 0)
        {
            def = baseDef;
            MagicDef = baseMagicDef;

        }
        else
        {
            
            durationDef -= Time.deltaTime;
        }
        

        if(HP <= 0 || gameObject == null)
        {
            DieSound.enabled = true;
            //Destroy(gameObject);
            animator.SetTrigger("Death");
            path.enabled = false;
            if(Aggro != null)
            {
               Aggro.enabled = false;
            }
            
            enemy.enabled = false;
        }
        else
        {
        
        if(path.enabled != enabled && Aggro.enabled != enabled && GetComponent<Munin_Movement>() == null)
        {
            //Debug.Log("Oke");
            Aggro.enabled = true;
        }
        else if(Aggro.enabled == enabled && countdownAggro <= 0)
        {
            Aggro.enabled = !Aggro.enabled;
            path.enabled = !path.enabled;
            countdownAggro = countdownAggroTemp;
        }
        if(Aggro.enabled == enabled)
        {
        countdownAggro -= Time.deltaTime;
        }

        }

        bool duriBiasa = Physics2D.OverlapCircle(Posisikaki.position, 0.1f, duri);
        bool duriUpgrade = Physics2D.OverlapCircle(Posisikaki.position, 0.1f, duriAsli);

        if(duriBiasa == true || duriUpgrade == true)
        {
            IsDuri = true;
        }
        else
        {
            IsDuri = false;
        }
        

    }
    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Bullet_Stat>() != null)
        {
            Bullet_Stat _Stat = collision.gameObject.GetComponent<Bullet_Stat>();
            HP -= _Stat.BulletDamage; 
        }
    }
    */
    public void TakeDamage(int damage)
    {
        HP -= damage - ((damage * def) /100);
    }

    public void TakeDamageMagic(int damage)
    {
        HP -= damage - ((damage * MagicDef) / 100);
    }
    public void TakeBuff(int buff, float duration)
    {
        def += buff;
        MagicDef += buff;
        durationDef = duration;
    }

    public void Healing(int Heal)
    {
        HP += Heal;
    }
    public void EnemyDeath()
    {
        //_Spawner.waves[_Spawner.CurrentWaveIndex].enemiesLeft--;
        resourceManager.AddCoin(Coins);
        Destroy(gameObject);
    }

    public void SkeletonDeath()
    {
        resourceManager.AddCoin(Coins);
        if (Inispawn == true && FindObjectOfType<Lich>() != null)
        {
            Lich lich = FindObjectOfType<Lich>().GetComponent<Lich>();
            //Debug.Log(lich);

            if(lich != null)
            {
                //Debug.LogError("oke");
                lich.SkeletonHidup--;
            }
            else
            {
                Destroy(gameObject);
            }
            
        }


                   
        
        Destroy(gameObject);

    }

    private void OnDestroy()
    {
        if(gameObject.GetComponent<GoblinRider>() != null)
        {
            return;
        }
        _Spawner.waves[_Spawner.CurrentWaveIndex].enemiesLeft--;
    }
    void OnDrawGizmosSelected()
    {
        if (Posisikaki == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(Posisikaki.position, 0.1f);
    }
}
