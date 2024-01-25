using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public PlayerController PlayerController;
    public Camera camera;

    public float damage;

    public bool canShot = true;
    WaitForSeconds shootDelay = new WaitForSeconds(0.2f);
                
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            PlayerController.animator.SetBool("Shoot", true);
            
        }
        if (Input.GetMouseButtonUp(0)) 
        {
            PlayerController.animator.SetBool("Shoot", false);
        }

        if(Input.GetMouseButton(0) && canShot) 
        {
            StartCoroutine(ShootDelayCoroutine());
            RaycastHit hit;
            if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit))
            {
                print("Benda Yang Tertembak : " + hit.collider.gameObject.name);
                if (hit.collider.GetComponent<Health>())
                {
                    Instantiate(VfsManager.instance.bloodimpact,hit.point,Quaternion.identity);
                    hit.collider.GetComponent<Health>().TakeDamage(damage);
                }
                else
                {
                    Instantiate(VfsManager.instance.woodimpact, hit.point, Quaternion.identity);
                }
            }
        }
    }

    IEnumerator ShootDelayCoroutine()
    {
        canShot = false;
        yield return shootDelay;
        canShot = true;
    }
}
