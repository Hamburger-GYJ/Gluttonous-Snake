using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Status
{
    TurnLeft,
    TurnRight,
    TurnUp,
    TurnDown,
    GameOver
}
public class CreateFoods : MonoBehaviour
{
    public Status GoStatus = Status.TurnUp;
    GameObject Cube;                                //随机生成的食物
    List<GameObject> snakeList = new List<GameObject>(); //蛇身
    float a = 0;
    float timer = 0;   //移动速度
    GameObject snakePart;    //蛇头
    public Text gameOver;

    void Start()
    {
        Cube = Resources.Load<GameObject>("Prefabs/Cube");
        gameOver.gameObject.SetActive(false);
        InitSnake();
    }

    void Update()
    {
        #region 换方向
        //向左
        if (Input.GetKeyDown(KeyCode.A) && GoStatus != Status.TurnRight)
        {
            GoStatus = Status.TurnLeft;
        }
        //向右
        if (Input.GetKeyDown(KeyCode.D) && GoStatus != Status.TurnUp)
        {
            GoStatus = Status.TurnRight;
        }
        //向上
        if (Input.GetKeyDown(KeyCode.W) && GoStatus != Status.TurnDown)
        {
            GoStatus = Status.TurnUp;
        }
        //向下
        if (Input.GetKeyDown(KeyCode.S) && GoStatus != Status.TurnUp)
        {
            GoStatus = Status.TurnDown;
        }
        #endregion

        //判定失败
        if (snakePart.transform.position.z > 20|| snakePart.transform.position.z < -20
            || snakePart.transform.position.x > 20|| snakePart.transform.position.x < -20)
        {
            GoStatus = Status.GameOver;
        }


        //状态判定
        switch (GoStatus)
        {
            //向左
            case Status.TurnLeft:
                if (timer > 1f)
                {
                    //销毁最后一个
                    Destroy(snakeList[0]);
                    snakeList.Remove(snakeList[0]);
                    //生成第一个
                    snakePart = Instantiate(Cube, new Vector3(snakePart.transform.position.x - 1.2f, snakePart.transform.position.y, snakePart.transform.position.z), Quaternion.identity);
                    snakeList.Add(snakePart);
                    timer = 0;
                }
                break;
            //向右
            case Status.TurnRight:
                if (timer > 1f)
                {
                    //销毁最后一个
                    Destroy(snakeList[0]);
                    snakeList.Remove(snakeList[0]);
                    //生成第一个
                    snakePart = Instantiate(Cube, new Vector3(snakePart.transform.position.x + 1.2f, snakePart.transform.position.y, snakePart.transform.position.z), Quaternion.identity);
                    snakeList.Add(snakePart);
                    timer = 0;
                }
                break;
            //向上
            case Status.TurnUp:
                if (timer > 1f)
                {
                    //生成第一个
                    snakePart = Instantiate(Cube, new Vector3(snakePart.transform.position.x, snakePart.transform.position.y, snakePart.transform.position.z + 1.2f), Quaternion.identity);
                    snakeList.Add(snakePart);
                    //销毁最后一个
                    Destroy(snakeList[0]);
                    snakeList.Remove(snakeList[0]);
                    timer = 0;
                }
                break;
            //向下
            case Status.TurnDown:
                if (timer > 1f)
                {
                    //销毁最后一个
                    Destroy(snakeList[0]);
                    snakeList.Remove(snakeList[0]);

                    //生成第一个
                    snakePart = Instantiate(Cube, new Vector3(snakePart.transform.position.x, snakePart.transform.position.y, snakePart.transform.position.z - 1.2f), Quaternion.identity);
                    snakeList.Add(snakePart);
                    timer = 0;
                }
                break;
            case Status.GameOver:
                gameOver.gameObject.SetActive(true);
                break;
        }
        timer += Time.deltaTime;
    }

    //初始化小蛇
    public void InitSnake()
    {
        for (int i = 0; i < 5; i++)
        {
            snakePart = Instantiate(Cube, new Vector3(0, 0, a), Quaternion.identity);
            snakeList.Add(snakePart);
            a += 1.2f;
        }
    }
}
