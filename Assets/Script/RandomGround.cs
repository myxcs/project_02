using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RandomGround : MonoBehaviour
{
    public Transform player;
    public List<GameObject> ground;
    public List<GameObject> enemy;
    private Vector2 nextPos;
    private Vector2 endPos;
    private Vector2 enemyNextPos;
    private float xRd;
    private float yRd;
    private int GrId;
    private int EmId;
    private int rd;
    public bool spawnEnemyYet = false;
    int groundLen;
    // Start is called before the first frame update
    void Start()
    {

        endPos = new Vector2(5f, 0f); //Vị trí cuối cùng của map hiện tại là 5 do ô đất dài 5 ô
        //delete firstGround after 5s
        

       
        // rd = Random.Range(2f, 5f); //Random khoảng cách giữa miếng đất đầu và miếng tiếp theo 
        // nextPos = new Vector2(endPos.x + rd, 0f); //Vị trí đặt miếng đất tiếp theo = vị trí cuối cùng + khoảng cách random
        // id = Random.Range(0, ground.Count);  //Random miếng đất sẽ sinh ra
        // Instantiate(ground[id], nextPos, Quaternion.identity, transform);  //Sinh ra miếng đất random được tại vị trí nextPos, không quay, là con của đối tượng hiện tại (grid)

        // //Tiếp theo kiểm tra xem miếng đất vừa sinh ra có độ dài bao nhiêu
        // switch (id)
        // {
        //     case 0: groundLen = 7; break;
        //     case 1: groundLen = 7; break;
        //     case 2: groundLen = 6; break;
        //     case 3: groundLen = 5; break;
        //     case 4: groundLen = 5; break;
        //     case 5: groundLen = 5; break;
        // }
        // endPos = new Vector2(nextPos.x + groundLen, 0f);
      
    }

    // Update is called once per frame
    void Update()
    {
        //Xem vị trí của người chơi so với diểm endPos cách nhau bao xa
        //Nếu khoảng cách nhỏ hơn 100f thì liên tục tạo ra miếng đất tiếp theo

        if (Vector2.Distance(player.position, endPos) < 50f)
        {
            xRd = Random.Range(2f, 5f);
            yRd = Random.Range(-1.5f, 1f);


            nextPos = new Vector2(endPos.x + xRd, yRd);
            enemyNextPos = new Vector2(endPos.x + xRd + 3f, yRd);
            GrId = Random.Range(0, ground.Count);
            EmId = Random.Range(0, enemy.Count);
            GameObject newGround = Instantiate(ground[GrId], nextPos, Quaternion.identity, transform);
            rd = Random.Range(1, 3);
            if(rd == 1)
             {
                  GameObject newEnemy = Instantiate(enemy[EmId], enemyNextPos, Quaternion.identity, transform);
            }
             
         
            
            switch (GrId)
            {
                case 0: groundLen = 7; break;
                case 1: groundLen = 7; break;
                case 2: groundLen = 6; break;
                case 3: groundLen = 5; break;
                case 4: groundLen = 5; break;
                case 5: groundLen = 5; break;
            }
           
            endPos = new Vector2(nextPos.x + groundLen, 0f);
        }
        //Nhân vật chạy qua nhưng các miến đất cũ không mất đi
        //Lấy miếng đầu tiên trong danh sách

       
    }
}

    

