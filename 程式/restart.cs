using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class restart : MonoBehaviour
{

    public Button AD;
    private Button Btn;
    // Start is called before the first frame update
    void Start()
    {
        Btn = GetComponent<Button>();
        Btn.onClick.AddListener(RestartGame);
        AD.onClick.AddListener(watchAD);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void RestartGame()
    {
        SceneManager.LoadScene("menu");
    }
    void watchAD()
    {
			GameData.hp = 250;
			GameData.exp = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Time.timeScale = 1;
    }
}
