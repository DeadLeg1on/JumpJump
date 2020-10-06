using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization;
using System.Xml.Serialization;

public class ControlWorld : MonoBehaviour
{
    public int score ;
    public int gold;
    public int levelGold;

    public GameObject player, enemy,tapStart;
    GameObject[] _enemy = new GameObject[10];
    public Canvas canv;
    float enemyScale;
    public Text drawScore, drawGold, drawMinuts, drawSeconds;
    int minuts, seconds;
    public float startTime;
    public bool timerOn; //Включен ли таймер
    public GameObject butHome, butReload;
    int bestScore = 0;
    
    LoadData _LoadData = new LoadData();
    PlayerControl _PlayerControl = new PlayerControl();
    MoveEngine _MoveEngine = new MoveEngine();
    
    void Start()
    {
        gold = _LoadData.LoadGame();
        player = GameObject.Find("player");
        enemy = GameObject.Find("Enemy");
        tapStart = GameObject.Find("TapToStart");
        StartGame(); 
        //timerOn = true; //Проверка работы таймера
        //startTime = 6;// Время таймера
        enemyScale = 0.15f; //Размеры врага
        //player = GameObject.Find("player");
        //enemy = GameObject.Find("Enemy");
        //tapStart = GameObject.Find("TapToStart");
        drawScore.text = score.ToString();
        drawGold.text = levelGold.ToString(); 
            
    }
    int BestScore(int _score)
    {
       //int  _bestScore = 0;
        if(_score < score)
        {
            _score = score;
        }
        return _score;
    }
    void HardUp(int _score)
    {
        if (_score == 5 && _enemy[1] == null) 
        {          
           _enemy[1] = Instantiate(enemy);
           _enemy[1].GetComponent<MoveEngine>().speed = 1;
           enemyScale = 0.1f;
           _enemy[1].GetComponent<Transform>().localScale = new Vector2(enemyScale, enemyScale);
        }
        if (_score == 10 && _enemy[2] == null )
        {
           _enemy[2] = Instantiate(enemy);
           _enemy[2].GetComponent<MoveEngine>().speed = 2;
            enemyScale = 0.2f;
           _enemy[2].GetComponent<Transform>().localScale = new Vector2(enemyScale, enemyScale);
        }
        if (_score == 15 && _enemy[3] == null) 
        {          
           _enemy[3] = Instantiate(enemy);
           _enemy[3].GetComponent<MoveEngine>().speed = 1;
           enemyScale = 0.25f;
           _enemy[3].GetComponent<Transform>().localScale = new Vector2(enemyScale, enemyScale);
        }
        if (_score == 20 && _enemy[4] == null) 
        {          
           _enemy[4] = Instantiate(enemy);
           _enemy[4].GetComponent<MoveEngine>().speed = 2;
           enemyScale = 0.05f;
           _enemy[4].GetComponent<Transform>().localScale = new Vector2(enemyScale, enemyScale);
        }
        
        if (_score == 0)
        {
            for(int i = 1; i < _enemy.Length; i++ )
            {
                Destroy(_enemy[i]);
            }
        }
    }
    void GameTimer()
    {           
        if (timerOn == true) 
        {
            startTime -= Time.deltaTime;
            seconds = (int)(startTime % 60);
            minuts = (int)(startTime / 60); 
        }     
        
        if (minuts < 10)
        {
            drawMinuts.text = 0 + minuts.ToString();
            if (seconds < 10)
            {
                drawSeconds.text = 0 + seconds.ToString();
            }
            else
            {
                drawSeconds.text = seconds.ToString();
            }
        }
        else
        {
            drawMinuts.text = 0 + minuts.ToString();
            if (seconds < 10)
            {
                drawSeconds.text = 0 + seconds.ToString();
            }
            else
            {
                drawSeconds.text = seconds.ToString();
            }
        }  
        if (startTime <= 0 && timerOn == true) 
        {
            GameOver();
            
        }
    }
    public void StartGame()
    {
        Instantiate(player);
        Instantiate(tapStart);
        GameObject.Find("Canvas").GetComponent<Animator>().SetBool("isOpen", false);
        timerOn = false;
        startTime = 6;
        _MoveEngine.isMove = false;
    }
    void GameOver()
    {
        Destroy(player);
        timerOn = false;
        _MoveEngine.isMove = false;
        SaveGame();
        canv.GetComponent<Animator>().SetBool("isOpen", true);
        score = 0;
        //player.GetComponent<PlayerControl>().permMove = true;
    }
    void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    void SaveGame()
    {
        gold = _LoadData.LoadGame();
        gold += (levelGold * score);
        _LoadData.SaveGame(gold);
    }
    void Draw()
    {
        drawScore.text = score.ToString();
        drawGold.text = levelGold.ToString(); 
    }
   /*  void GameMode()
    {
        

        if (gameMode == "stop") 
        {
            _LoadData.SaveGame(player.GetComponent<PlayerControl>().gold);
            canv.GetComponent<Animator>().SetBool("isOpen", true);
            player.SetActive(false); 
            player.GetComponent<PlayerControl>().score = 0;
            gameMode = "";
        }
    }*/
    void Update()
    {   
        if ( tapStart && (Input.touchCount>0 || Input.GetKeyDown( KeyCode.Space )) )
        {
            Destroy(tapStart);
            player.GetComponent<PlayerControl>().permMove = true;
            timerOn = true;
            _MoveEngine.isMove = true;
        }
        GameTimer();
        Draw();
        HardUp(score);
    }


}
