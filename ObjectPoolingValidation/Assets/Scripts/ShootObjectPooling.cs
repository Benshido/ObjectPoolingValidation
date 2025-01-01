using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootObjectPooling : MonoBehaviour
{
    //public GameObject projectile;
    public GameObject muzzle;
    public float cooldownTime = 1f;

    private bool alreadyAttacked;

    // Update is called once per frame
    void Update()
    {
        if (!alreadyAttacked)
        {
            GameObject bullet = ObjectPool.SharedInstance.GetPooledObject();
            if (bullet != null)
            {
                bullet.transform.position = muzzle.transform.position;
                bullet.transform.rotation = muzzle.transform.rotation;
                bullet.SetActive(true);

                //Attack code here
                Rigidbody rb = bullet.GetComponent<Rigidbody>();
                rb.AddForce(transform.forward * 60f, ForceMode.Impulse);
                rb.AddForce(transform.up * 2f, ForceMode.Impulse);
            }
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), cooldownTime);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
}
