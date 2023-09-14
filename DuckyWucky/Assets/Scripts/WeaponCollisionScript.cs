using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCollisionScript : MonoBehaviour
{

    public float AttackSpeed = 4f;

    Collider WeaponHitbox;

    void Start()
    {
        WeaponHitbox = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && WeaponHitbox == false)
        {
            WeaponHitbox.enabled = true;
            print("true");
            Invoke("AttackTime", AttackSpeed);
        }
    }

    public void AttackTime()
    {
        WeaponHitbox.enabled = false;
        print("false");
    }


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Enemy")
        {
            print("hit");
            
        }
    }
}
