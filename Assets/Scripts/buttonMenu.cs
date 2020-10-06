using UnityEngine;
using UnityEngine.SceneManagement;


public class buttonMenu : MonoBehaviour
{
    public GameObject tapStart, player;
    public Animator animButReload, animButHome;
    ControlWorld _ControlWorld = new ControlWorld();
    int startTime;
    bool timerOn;

    void Start()
    {      
        //canv.GetComponent<Animator>().SetBool("isOpen", false);
        //animButReload.SetBool("isOpen", true);
        //animButHome.SetBool("isOpen", true);
        //animButHome.Play("Open");
        //animButReload.Play("Open");

    }

    
    void Update()
    {

    }
    public void Click() {
        if(gameObject.name == "Button_Start") SceneManager.LoadScene("Game");
        if(gameObject.name == "Button_Home") SceneManager.LoadScene("Menu");
        if(gameObject.name == "Button_Reload") 
        {
            _ControlWorld.StartGame();
            //GameObject.Find("ControlWorld").GetComponent<ControlWorld>().gameMode = "waitTap";
            //GameObject.Find("ControlWorld").GetComponent<ControlWorld>().startTime = 21;
            //GameObject.Find("ControlWorld").GetComponent<ControlWorld>().timerOn = true;
            //GameObject.Find("player").SetActive(true);
            //GameObject.Find("TapToStart").SetActive(true);
            //canv.GetComponent<Animator>().SetBool("isOpen", false);
            //GameObject.Find("Canvas").GetComponent<Animator>().SetBool("isOpen", false);

        }
        
              
    }
    
}
