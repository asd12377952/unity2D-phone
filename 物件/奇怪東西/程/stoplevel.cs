using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;


public class stoplevel : MonoBehaviour
{
    public GameObject up;
    private GameObject target;
    private bool go=false;

    // Start is called before the first frame update
    void Start()
    {
        up.SetActive(false);
        target = GameObject.Find("player");
        if(GameData.stoplevel){
            gameObject.transform.localPosition = new Vector3(1.8f, 0, 0);
            target.transform.position = new Vector3(137.2f, 28, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(GameData.stoplevel || GameData.bosslevel){
            up.SetActive(true);
        }
        if(go && transform.localPosition.y<=2.0f){
            gameObject.transform.position += new Vector3(0, 0.1f, 0);
        }
    }
    void OnTriggerEnter (Collider other){
		if(other.tag == "Player"){
            GameData.stoplevel = true;
            GameData.bosslevel = false;
            go= true;
        }
    }
}