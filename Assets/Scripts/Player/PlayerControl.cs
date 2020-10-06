using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;



public class PlayerControl : MonoBehaviour
{
    GameObject player;
    Animation anim;
    float startX, startY;
    float player_gravity_scale; //Направление гравитации
    public bool permMove;//Блокировка движения
    bool _flipY;
    bool fly;// проверять, в воздухе ли персонаж
    bool touchClick; //можно ли нажать прыжек
    string directJump; //В какую сторону будет прыжек
    //LoadData _LoadData = new LoadData();
    ControlWorld _ControlWorld = new ControlWorld();
    
    void Start()
    {
        permMove = true;
        
        player = GameObject.Find("player");
        _flipY = player.GetComponent<SpriteRenderer>().flipY;
        player_gravity_scale = player.GetComponent<Rigidbody2D>().gravityScale;  
        startX =  transform.position.x;
        startY =  transform.position.y;
        directJump = "up";
        fly = false;
    }
    void playerJump()
    {
        if ( (Input.GetKeyDown( KeyCode.Space ) || Input.touchCount > 0) && (fly == false && touchClick == false && permMove == false))
        {         
                if (_flipY == true) _flipY = false;               
                else if (_flipY == false) _flipY = true;
                player_gravity_scale *= -1;
                fly = true;
                touchClick = true;
                player.GetComponent<SpriteRenderer>().flipY = _flipY;
                player.GetComponent<Rigidbody2D>().gravityScale = player_gravity_scale;
            
        }
        if (Input.touchCount <=0) touchClick = false;
    }
    void Update()
    {    
        playerJump();  
    }
    void DeathPlayer()
    {
        fly = false;
        transform.position = new Vector2(startX, startY);
        directJump = "up";
        _flipY = false;
        player_gravity_scale = 15;
        player.GetComponent<Rigidbody2D>().gravityScale = player_gravity_scale;
        player.GetComponent<SpriteRenderer>().flipY = _flipY;
        _ControlWorld.score = 0;
        
    }
    void OnCollisionEnter2D(Collision2D col) 
    {
        if (col.gameObject.name == "platf1" && directJump == "up"){
            _ControlWorld.score+=1;
            directJump = "down";
            fly = false;
        }
        if (col.gameObject.name == "platf0" && directJump == "down"){
            _ControlWorld.score+=1;            
            directJump = "up";
            fly = false;
        }
       
    }
    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.name == "Gold")
        {
            _ControlWorld.levelGold += 1;
            col.gameObject.transform.position = new Vector2(Random.Range(-2, 2), Random.Range(-3, 3));  
        }
        if(col.gameObject.tag == "Blade") //RELOAD PLAYER
        {
            DeathPlayer();
        }
    }


}
