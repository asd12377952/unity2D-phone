using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class go : MonoBehaviour
{
    private Button Btn;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        Btn = GetComponent<Button>();
        Btn.onClick.AddListener(_go);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void _go(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
}
