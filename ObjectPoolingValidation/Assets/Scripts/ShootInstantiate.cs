using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootInstantiate : MonoBehaviour
{
    public GameObject projectile;
    public GameObject muzzle;
    public float cooldownTime = 1f;

    private bool alreadyAttacked;

    // Update is called once per frame
    void Update()
    {
        if (!alreadyAttacked)
        {
            //Attack code here
            Rigidbody rb = Instantiate(projectile, muzzle.transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 60f, ForceMode.Impulse);
            rb.AddForce(transform.up * 2f, ForceMode.Impulse);

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), cooldownTime);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
}
