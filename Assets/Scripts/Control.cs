/* using UnityEngine;

public class Control : MonoBehaviour
{
        GUIStyle smallFont;
        GameObject player;
        GameObject enemy;
        int en_startSpot, en_endSpot;
        int score, last_score;
        float en_speed; 
        string en_walkMode;

        void Start() 
        {
            player = GameObject.Find("player");          
            enemy = GameObject.Find("Enemy");
            last_score = 0;
            en_speed = enemy.GetComponent<MoveEngine>().speed;
            en_startSpot = enemy.GetComponent<MoveEngine>().startSpot;
            en_walkMode = enemy.GetComponent<MoveEngine>().walkMode;
            en_endSpot = enemy.GetComponent<MoveEngine>().endSpot;
            
        }
        void NewLevel()
        {
            switch(score)
            {
                case 0 :
                    en_startSpot = 4;
                    en_endSpot = 6;
                    en_walkMode = "line";
                    en_speed = 1f;
                break;
                case 2 :
                    en_startSpot = 2;
                    en_endSpot = 7;
                    en_walkMode = "line";
                    en_speed = 1f;
                break;
                case 4 :
                    en_startSpot = 6;
                    en_endSpot = 7;
                    en_walkMode = "line";
                    en_speed = 3f;
                break;
                case 6 :
                    en_startSpot = 3;
                    en_endSpot = 8;
                    en_walkMode = "random";
                    en_speed = 2f;
                break;
                case 8 :
                    en_startSpot = 1;
                    en_endSpot = 5;
                    en_walkMode = "line";
                    en_speed = 3f;
                break;
                case 10 :
                    en_startSpot = 6;
                    en_endSpot = 7;
                    en_walkMode = "random";
                    en_speed = 10f;
                break;
                case 12 :
                    en_startSpot = 1;
                    en_endSpot = 9;
                    en_walkMode = "random";
                    en_speed = 6f;
                break;
                case 14 :
                    en_startSpot = 2;
                    en_endSpot = 8;
                    en_walkMode = "random";
                    en_speed = 8f;
                break;
                case 16 :
                    en_startSpot = 3;
                    en_endSpot = 7;
                    en_walkMode = "random";
                    en_speed = 6f;
                break;
                
            }
        }
        void Update() {
            if (player)
            {
                score = player.GetComponent<PlayerControl>().score;
            }
            if(last_score<score)
            {
                last_score = score;
                NewLevel();
            }
        }
}*/