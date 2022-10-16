using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;


public class bosslevel : MonoBehaviour
{
    public GameObject n1,n2;
    private GameObject target;
    private bool go=false;

    // Start is called before the first frame update
    void Start()
    {
        n1.SetActive(false);
        n2.SetActive(false);
        target = GameObject.Find("player");
        if(GameData.bosslevel){
            gameObject.transform.localPosition = new Vector3(1.8f, 0, 0);
            target.transform.position = new Vector3(271, 61, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(GameData.bosslevel){
            n1.SetActive(true);
            n2.SetActive(true);
        }
        if(go && transform.localPosition.y<=2.0f){
            gameObject.transform.position += new Vector3(0, 0.1f, 0);
        }
    }
    void OnTriggerEnter (Collider other){
		if(other.tag == "Player"){
            GameData.bosslevel = true;
            GameData.stoplevel = false;
            go= true;
        }
    }
}
