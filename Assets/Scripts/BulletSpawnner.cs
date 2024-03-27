using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class BulletSpawnner : MonoBehaviour
{
    public GameObject AR_Camera;
    public GameObject smoke;
    public Text Score;
    private int scoreval = 0;
    

    

    
    public void Shoot()
    {
        
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.transform.CompareTag("WhiteCell"))
            {
                
                scoreval += 5;
                Score.text = "Score: "+scoreval.ToString();
                Destroy(hit.transform.gameObject);
                Instantiate(smoke, hit.point, Quaternion.LookRotation(hit.normal));
                
            }

            if (hit.transform.CompareTag("RedCell"))
            {

                scoreval -= 2;
                Score.text = "Score: " + scoreval.ToString();
                Destroy(hit.transform.gameObject);
                Instantiate(smoke, hit.point, Quaternion.LookRotation(hit.normal));

            }
            
        }
    }
    
}
