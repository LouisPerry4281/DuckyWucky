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
        //Using numerical layers is conventional since it's harder to mess up (collision.tag == 8)
        if (collision.tag == "Enemy")
        {
            print("hit");
        }
    }
}

//Logic should all be on top level of an object (Exceptions being collision detection, which even still should be seperated into the detector and the actor, with the actor
//being on the highest parent and the detector accessing it.) (This is the basics of a "Command Pattern")