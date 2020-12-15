using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class Dice : MonoBehaviour
{
    private Sprite[] diceSides;
    private SpriteRenderer rend;
    public static int whosTurn = 1;
    private bool coroutineAllowed = true;
    private bool YutAllowed = true;

    public static int oneMore = 0;
    public static int[] DiceResult = new int[6];
    public static int passYut = 0; 
    public static int whatPlay = 0;

    int randomMatch = 0;
    int randomDiceSide = 0;

    // Use this for initialization
    // Start is called before the first frame update
    private void Start()
    {
        DiceResult[0] = 6;
        DiceResult[1] = 6;
        DiceResult[2] = 6;
        DiceResult[3] = 6;
        DiceResult[4] = 6;
        DiceResult[5] = 6;

        rend = GetComponent<SpriteRenderer>();
        diceSides = Resources.LoadAll<Sprite>("DiceSides/");
        rend.sprite = diceSides[4];
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            if(!GameControl.gameOver && coroutineAllowed)
                StartCoroutine("RollTheDice");
        }
    }

    private IEnumerator RollTheDice()
    {
        coroutineAllowed = false;
        // int randomMatch = 0;
        // int randomDiceSide = 0;
        // for(int i = 0; i <= 20; i++)
        // {
        //     randomMatch = Random.Range(0,16);
        //     if(randomMatch < 4) {
        //         randomDiceSide = 0;
        //     } else if (randomMatch >= 4 && randomMatch < 10) {
        //         randomDiceSide = 1;
        //     } else if (randomMatch >= 10 && randomMatch < 14){
        //         randomDiceSide = 2;
        //     } else if (randomMatch == 14) {
        //         randomDiceSide = 3;
        //     } else {
        //         randomDiceSide = 4;
        //     }
        //     rend.sprite = diceSides[randomDiceSide];
        //     yield return new WaitForSeconds(0.05f);
        // }

        randomMatch = 0;
        randomDiceSide = 0;

        //////////////////////////////////////               윷 던지기               //////////////////////////////////////////////////////
        if(YutAllowed)
            StartCoroutine("RollYut");

        yield return new WaitForSeconds(1.5f);
        
        /////////////////////////////////               윷, 모 나왔을 경우            //////////////////////////////////////////////////////
        while(passYut == 3 || passYut == 4){
            if(passYut != 3 && passYut != 4){
                break;
            } else {
                while(true){
                    if(Input.GetKeyDown(KeyCode.Space)) {
                        StartCoroutine("RollYut");
                        yield return new WaitForSeconds(1.5f);
                        break;
                    } else {
                        yield return new WaitForSeconds(0.005f);
                    }
                }
            }

            yield return new WaitForSeconds(0.5f);
        }

        Debug.Log("누구의 차례?         :           " + whosTurn);

        /////////////////////////////////               플레이어 1의 차례               ///////////////////////////////////////////////////
        if(whosTurn == 1) {
            if(DiceResult[1] == 6){
                Debug.Log("1번 들어왔는가 ");
                /////////////////////////               연속으로 안던졌을 경우           ///////////////////////////////////////////////////
                while (true) {
                    if(Input.GetKeyDown(KeyCode.Q) && (GameControl.player1.GetComponent<FollowThePath>().waypointIndex != 43)) {
                        whatPlay = 1;
                        GameControl.diceSideThrown = DiceResult[0];
                        GameControl.MovePlayer(1);
                        yield return new WaitForSeconds(0.005f);
                        break;
                    } else if(Input.GetKeyDown(KeyCode.W) && (GameControl.player2.GetComponent<FollowThePath>().waypointIndex != 43)) {
                        whatPlay = 2;
                        GameControl.diceSideThrown = DiceResult[0];
                        GameControl.MovePlayer(2);
                        yield return new WaitForSeconds(0.005f);
                        break;
                    } else if(Input.GetKeyDown(KeyCode.E) && (GameControl.player3.GetComponent<FollowThePath>().waypointIndex != 43)) {
                        whatPlay = 3;
                        GameControl.diceSideThrown = DiceResult[0];
                        GameControl.MovePlayer(3);
                        yield return new WaitForSeconds(0.005f);
                        break;
                    } else if(Input.GetKeyDown(KeyCode.R) && (GameControl.player4.GetComponent<FollowThePath>().waypointIndex != 43)) {
                        whatPlay = 4;
                        GameControl.diceSideThrown = DiceResult[0];
                        GameControl.MovePlayer(4);
                        yield return new WaitForSeconds(0.005f);
                        break;
                    }
                    
                    yield return new WaitForSeconds(0.005f);
                }
                yield return new WaitForSeconds(1f);
                whatPlay = 0;
                DiceResult[0] = 6;
                oneMore = 0;
            } else {
                Debug.Log("1-1번 들어왔는가 ");
                while (true) {
                    if((GameControl.diceSideThrown == 0 && GameControl.player5StartWaypoint == 0) ||
                    //    (GameControl.diceSideThrown == 0 && GameControl.player6StartWaypoint == 0) ||
                    //    (GameControl.diceSideThrown == 0 && GameControl.player7StartWaypoint == 0) ||
                    //    (GameControl.diceSideThrown == 0 && GameControl.player8StartWaypoint == 0) || 
                       ( passYut == 3 || passYut == 4 )) {
                        while(true){
                            if(Input.GetKeyDown(KeyCode.Space)) {
                                StartCoroutine("RollYut");
                                yield return new WaitForSeconds(1.5f);
                                GameControl.diceSideThrown = 1;
                                break;
                            } else {
                                yield return new WaitForSeconds(0.005f);
                            }
                        }
                        yield return new WaitForSeconds(0.5f);
                    }
                    
                    /////////////////////           1번 결과 값 선택                   ///////////////////////////////////////////////////
                    if(Input.GetKeyDown(KeyCode.Q) && (DiceResult[0] != 6)) {
                        yield return new WaitForSeconds(0.005f);
                        while(true){
                            if(Input.GetKeyDown(KeyCode.Q) && (GameControl.player1.GetComponent<FollowThePath>().waypointIndex != 43)){
                                whatPlay = 1;
                                GameControl.diceSideThrown = DiceResult[0];
                                GameControl.MovePlayer(1);
                                yield return new WaitForSeconds(1.005f);
                                break;
                            }
                            if(Input.GetKeyDown(KeyCode.W) && (GameControl.player2.GetComponent<FollowThePath>().waypointIndex != 43)){
                                whatPlay = 2;
                                GameControl.diceSideThrown = DiceResult[0];
                                GameControl.MovePlayer(2);
                                yield return new WaitForSeconds(1.005f);
                                break;
                            }
                            if(Input.GetKeyDown(KeyCode.E) && (GameControl.player3.GetComponent<FollowThePath>().waypointIndex != 43)){
                                whatPlay = 3;
                                GameControl.diceSideThrown = DiceResult[0];
                                GameControl.MovePlayer(3);
                                yield return new WaitForSeconds(1.005f);
                                break;
                            }
                            if(Input.GetKeyDown(KeyCode.R) && (GameControl.player4.GetComponent<FollowThePath>().waypointIndex != 43)){
                                whatPlay = 4;
                                GameControl.diceSideThrown = DiceResult[0];
                                GameControl.MovePlayer(4);
                                yield return new WaitForSeconds(1.005f);
                                break;
                            }
                            yield return new WaitForSeconds(0.005f);
                        }
                        yield return new WaitForSeconds(0.005f);
                        whatPlay = 0;
                        DiceResult[0] = 6;
                    } else if (Input.GetKeyDown(KeyCode.W) && (DiceResult[1] != 6)) {

                        /////////////////           2번 결과 값 선택                   ///////////////////////////////////////////////////
                        yield return new WaitForSeconds(0.005f);
                        while(true){
                            if(Input.GetKeyDown(KeyCode.Q) && (GameControl.player1.GetComponent<FollowThePath>().waypointIndex != 43)){
                                whatPlay = 1;
                                GameControl.diceSideThrown = DiceResult[1];
                                GameControl.MovePlayer(1);
                                yield return new WaitForSeconds(1.005f);
                                break;
                            }
                            if(Input.GetKeyDown(KeyCode.W) && (GameControl.player2.GetComponent<FollowThePath>().waypointIndex != 43)){
                                whatPlay = 2;
                                GameControl.diceSideThrown = DiceResult[1];
                                GameControl.MovePlayer(2);
                                yield return new WaitForSeconds(1.005f);
                                break;
                            }
                            if(Input.GetKeyDown(KeyCode.E) && (GameControl.player3.GetComponent<FollowThePath>().waypointIndex != 43)){
                                whatPlay = 3;
                                GameControl.diceSideThrown = DiceResult[1];
                                GameControl.MovePlayer(3);
                                yield return new WaitForSeconds(1.005f);
                                break;
                            }
                            if(Input.GetKeyDown(KeyCode.R) && (GameControl.player4.GetComponent<FollowThePath>().waypointIndex != 43)){
                                whatPlay = 4;
                                GameControl.diceSideThrown = DiceResult[1];
                                GameControl.MovePlayer(4);
                                yield return new WaitForSeconds(1.005f);
                                break;
                            }
                            yield return new WaitForSeconds(0.005f);
                        }
                        yield return new WaitForSeconds(0.005f);
                        whatPlay = 0;
                        DiceResult[1] = 6;
                    } else if (Input.GetKeyDown(KeyCode.E) && (DiceResult[2] != 6)) {

                        /////////////////           3번 결과 값 선택                   ///////////////////////////////////////////////////
                        yield return new WaitForSeconds(0.005f);
                        while(true){
                            if(Input.GetKeyDown(KeyCode.Q) && (GameControl.player1.GetComponent<FollowThePath>().waypointIndex != 43)){
                                whatPlay = 1;
                                GameControl.diceSideThrown = DiceResult[2];
                                GameControl.MovePlayer(1);
                                yield return new WaitForSeconds(1.005f);
                                break;
                            }
                            if(Input.GetKeyDown(KeyCode.W) && (GameControl.player2.GetComponent<FollowThePath>().waypointIndex != 43)){
                                whatPlay = 2;
                                GameControl.diceSideThrown = DiceResult[2];
                                GameControl.MovePlayer(2);
                                yield return new WaitForSeconds(1.005f);
                                break;
                            }
                            if(Input.GetKeyDown(KeyCode.E) && (GameControl.player3.GetComponent<FollowThePath>().waypointIndex != 43)){
                                whatPlay = 3;
                                GameControl.diceSideThrown = DiceResult[2];
                                GameControl.MovePlayer(3);
                                yield return new WaitForSeconds(1.005f);
                                break;
                            }
                            if(Input.GetKeyDown(KeyCode.R) && (GameControl.player4.GetComponent<FollowThePath>().waypointIndex != 43)){
                                whatPlay = 4;
                                GameControl.diceSideThrown = DiceResult[2];
                                GameControl.MovePlayer(4);
                                yield return new WaitForSeconds(1.005f);
                                break;
                            }
                            yield return new WaitForSeconds(0.005f);
                        }
                        yield return new WaitForSeconds(0.005f);
                        whatPlay = 0;
                        DiceResult[2] = 6;
                    } else if (Input.GetKeyDown(KeyCode.R) && (DiceResult[3]!= 6)) {

                        /////////////////           4번 결과 값 선택                   ///////////////////////////////////////////////////
                        yield return new WaitForSeconds(0.005f);
                        while(true){
                            if(Input.GetKeyDown(KeyCode.Q) && (GameControl.player1.GetComponent<FollowThePath>().waypointIndex != 43)){
                                whatPlay = 1;
                                GameControl.diceSideThrown = DiceResult[3];
                                GameControl.MovePlayer(1);
                                yield return new WaitForSeconds(1.005f);
                                break;
                            }
                            if(Input.GetKeyDown(KeyCode.W) && (GameControl.player2.GetComponent<FollowThePath>().waypointIndex != 43)){
                                whatPlay = 2;
                                GameControl.diceSideThrown = DiceResult[3];
                                GameControl.MovePlayer(2);
                                yield return new WaitForSeconds(1.005f);
                                break;
                            }
                            if(Input.GetKeyDown(KeyCode.E) && (GameControl.player3.GetComponent<FollowThePath>().waypointIndex != 43)){
                                whatPlay = 3;
                                GameControl.diceSideThrown = DiceResult[3];
                                GameControl.MovePlayer(3);
                                yield return new WaitForSeconds(1.005f);
                                break;
                            }
                            if(Input.GetKeyDown(KeyCode.R) && (GameControl.player4.GetComponent<FollowThePath>().waypointIndex != 43)){
                                whatPlay = 4;
                                GameControl.diceSideThrown = DiceResult[3];
                                GameControl.MovePlayer(4);
                                yield return new WaitForSeconds(1.005f);
                                break;
                            }
                            yield return new WaitForSeconds(0.005f);
                        }
                        yield return new WaitForSeconds(0.005f);
                        whatPlay = 0;
                        DiceResult[3] = 6;
                    }
                    
                    yield return new WaitForSeconds(0.005f);
    
                    if(DiceResult[0] == 6 && DiceResult[1] == 6 && DiceResult[2] == 6 && DiceResult[3] == 6){
                        yield return new WaitForSeconds(2.5f);
                        GameControl.player1.GetComponent<FollowThePath>().moveAllowed = false;
                        GameControl.player2.GetComponent<FollowThePath>().moveAllowed = false;
                        GameControl.player3.GetComponent<FollowThePath>().moveAllowed = false;
                        GameControl.player4.GetComponent<FollowThePath>().moveAllowed = false;
                        GameControl.diceSideThrown = 0;
                        whosTurn = 1;
                        whatPlay = 0;
                        oneMore = 0;
                        break;
                    } 
                }
            }
            Debug.Log("다이스 값 확인 6 : " + GameControl.diceSideThrown);
        } else if(whosTurn == -1) {
            Debug.Log("2번 들어왔는가 ");
            /////////////////////////////////               플레이어 1의 차례               ///////////////////////////////////////////////////
            if(DiceResult[1] == 6){
                while (true)
                {
                    if(Input.GetKeyDown(KeyCode.Q) && (GameControl.player5.GetComponent<FollowThePath>().waypointIndex != 43)) {
                        GameControl.diceSideThrown = DiceResult[0];
                        whatPlay = 5;
                        GameControl.MovePlayer(5);
                        yield return new WaitForSeconds(0.005f);
                        break;
                    } else if(Input.GetKeyDown(KeyCode.W) && (GameControl.player6.GetComponent<FollowThePath>().waypointIndex != 43)) {
                        GameControl.diceSideThrown = DiceResult[0];
                        whatPlay = 6;
                        GameControl.MovePlayer(6);
                        yield return new WaitForSeconds(0.005f);
                        break;
                    } else if(Input.GetKeyDown(KeyCode.E) && (GameControl.player7.GetComponent<FollowThePath>().waypointIndex != 43)) {
                        GameControl.diceSideThrown = DiceResult[0];
                        whatPlay = 7;
                        GameControl.MovePlayer(7);
                        yield return new WaitForSeconds(0.005f);
                        break;
                    } else if(Input.GetKeyDown(KeyCode.R) && (GameControl.player8.GetComponent<FollowThePath>().waypointIndex != 43)) {
                        GameControl.diceSideThrown = DiceResult[0];
                        whatPlay = 8;
                        GameControl.MovePlayer(8);
                        yield return new WaitForSeconds(0.005f);
                        break;
                    }
                    
                    yield return new WaitForSeconds(0.005f);
                }
                yield return new WaitForSeconds(1f);
                DiceResult[0] = 6;
                whatPlay = 0;
                oneMore = 0;
            } else {
                Debug.Log("2-2번 들어왔는가 ");
                while (true){
                    if((GameControl.diceSideThrown == 0 && GameControl.player1StartWaypoint == 0) ||
                    //    (GameControl.diceSideThrown == 0 && GameControl.player2StartWaypoint == 0) ||
                    //    (GameControl.diceSideThrown == 0 && GameControl.player3StartWaypoint == 0) ||
                    //    (GameControl.diceSideThrown == 0 && GameControl.player4StartWaypoint == 0) || 
                       ( passYut == 3 || passYut == 4 ) ){
                        while(true){
                            if(Input.GetKeyDown(KeyCode.Space)) {
                                StartCoroutine("RollYut");
                                yield return new WaitForSeconds(1.5f);
                                GameControl.diceSideThrown = 1;
                                break;
                            } else {
                                yield return new WaitForSeconds(0.005f);
                            }
                        }
                        yield return new WaitForSeconds(0.5f);
                    }

                    if(Input.GetKeyDown(KeyCode.Q) && (DiceResult[0] != 6)) {
                        yield return new WaitForSeconds(0.005f);
                        while(true){
                            if(Input.GetKeyDown(KeyCode.Q) && (GameControl.player5.GetComponent<FollowThePath>().waypointIndex != 43)){
                                whatPlay = 5;
                                GameControl.diceSideThrown = DiceResult[0];
                                GameControl.MovePlayer(5);
                                yield return new WaitForSeconds(1.005f);
                                break;
                            } else if(Input.GetKeyDown(KeyCode.W) && (GameControl.player6.GetComponent<FollowThePath>().waypointIndex != 43)){
                                whatPlay = 6;
                                GameControl.diceSideThrown = DiceResult[0];
                                GameControl.MovePlayer(6);
                                yield return new WaitForSeconds(1.005f);
                                break;
                            } else if(Input.GetKeyDown(KeyCode.E) && (GameControl.player7.GetComponent<FollowThePath>().waypointIndex != 43)){
                                whatPlay = 7;
                                GameControl.diceSideThrown = DiceResult[0];
                                GameControl.MovePlayer(7);
                                yield return new WaitForSeconds(1.005f);
                                break;
                            } else if(Input.GetKeyDown(KeyCode.R) && (GameControl.player8.GetComponent<FollowThePath>().waypointIndex != 43)){
                                whatPlay = 8;
                                GameControl.diceSideThrown = DiceResult[0];
                                GameControl.MovePlayer(8);
                                yield return new WaitForSeconds(1.005f);
                                break;
                            }
                            yield return new WaitForSeconds(0.005f);
                        }
                        yield return new WaitForSeconds(0.005f);
                        whatPlay = 0;
                        DiceResult[0] = 6;

                    /////////////////////           2번 결과 값 선택                   ///////////////////////////////////////////////////
                    } else if (Input.GetKeyDown(KeyCode.W) && (DiceResult[1] != 6)) {
                        yield return new WaitForSeconds(0.005f);
                        while(true){
                            if(Input.GetKeyDown(KeyCode.Q) && (GameControl.player5.GetComponent<FollowThePath>().waypointIndex != 43)){
                                whatPlay = 5;
                                GameControl.diceSideThrown = DiceResult[1];
                                GameControl.MovePlayer(5);
                                yield return new WaitForSeconds(1.005f);
                                break;
                            } else if(Input.GetKeyDown(KeyCode.W) && (GameControl.player6.GetComponent<FollowThePath>().waypointIndex != 43)){
                                whatPlay = 6;
                                GameControl.diceSideThrown = DiceResult[1];
                                GameControl.MovePlayer(6);
                                yield return new WaitForSeconds(1.005f);
                                break;
                            } else if(Input.GetKeyDown(KeyCode.E) && (GameControl.player7.GetComponent<FollowThePath>().waypointIndex != 43)){
                                whatPlay = 7;
                                GameControl.diceSideThrown = DiceResult[1];
                                GameControl.MovePlayer(7);
                                yield return new WaitForSeconds(1.005f);
                                break;
                            } else if(Input.GetKeyDown(KeyCode.R) && (GameControl.player8.GetComponent<FollowThePath>().waypointIndex != 43)){
                                whatPlay = 8;
                                GameControl.diceSideThrown = DiceResult[1];
                                GameControl.MovePlayer(8);
                                yield return new WaitForSeconds(1.005f);
                                break;
                            }
                            yield return new WaitForSeconds(0.005f);
                        }
                        yield return new WaitForSeconds(0.005f);
                        whatPlay = 0;
                        DiceResult[1] = 6;

                    /////////////////////           3번 결과 값 선택                   ///////////////////////////////////////////////////
                    } else if (Input.GetKeyDown(KeyCode.E) && (DiceResult[2] != 6)) {
                        yield return new WaitForSeconds(0.005f);
                        while(true){
                            if(Input.GetKeyDown(KeyCode.Q) && (GameControl.player5.GetComponent<FollowThePath>().waypointIndex != 43)){
                                whatPlay = 5;
                                GameControl.diceSideThrown = DiceResult[2];
                                GameControl.MovePlayer(5);
                                yield return new WaitForSeconds(1.005f);
                                break;
                            } else if(Input.GetKeyDown(KeyCode.W) && (GameControl.player6.GetComponent<FollowThePath>().waypointIndex != 43)){
                                whatPlay = 6;
                                GameControl.diceSideThrown = DiceResult[2];
                                GameControl.MovePlayer(6);
                                yield return new WaitForSeconds(1.005f);
                                break;
                            } else if(Input.GetKeyDown(KeyCode.E) && (GameControl.player7.GetComponent<FollowThePath>().waypointIndex != 43)){
                                whatPlay = 7;
                                GameControl.diceSideThrown = DiceResult[2];
                                GameControl.MovePlayer(7);
                                yield return new WaitForSeconds(1.005f);
                                break;
                            } else if(Input.GetKeyDown(KeyCode.R) && (GameControl.player8.GetComponent<FollowThePath>().waypointIndex != 43)){
                                whatPlay = 8;
                                GameControl.diceSideThrown = DiceResult[2];
                                GameControl.MovePlayer(8);
                                yield return new WaitForSeconds(1.005f);
                                break;
                            }
                            yield return new WaitForSeconds(0.005f);
                        }
                        yield return new WaitForSeconds(0.005f);
                        whatPlay = 0;
                        DiceResult[2] = 6;

                    /////////////////////           4번 결과 값 선택                   ///////////////////////////////////////////////////
                    } else if (Input.GetKeyDown(KeyCode.R) && (DiceResult[3] != 6)) {
                        yield return new WaitForSeconds(0.005f);
                        while(true){
                            if(Input.GetKeyDown(KeyCode.Q) && (GameControl.player5.GetComponent<FollowThePath>().waypointIndex != 43)){
                                whatPlay = 5;
                                GameControl.diceSideThrown = DiceResult[3];
                                GameControl.MovePlayer(5);
                                yield return new WaitForSeconds(1.005f);
                                break;
                            } else if(Input.GetKeyDown(KeyCode.W) && (GameControl.player6.GetComponent<FollowThePath>().waypointIndex != 43)){
                                whatPlay = 6;
                                GameControl.diceSideThrown = DiceResult[3];
                                GameControl.MovePlayer(6);
                                yield return new WaitForSeconds(1.005f);
                                break;
                            } else if(Input.GetKeyDown(KeyCode.E) && (GameControl.player7.GetComponent<FollowThePath>().waypointIndex != 43)){
                                whatPlay = 7;
                                GameControl.diceSideThrown = DiceResult[3];
                                GameControl.MovePlayer(7);
                                yield return new WaitForSeconds(1.005f);
                                break;
                            } else if(Input.GetKeyDown(KeyCode.R) && (GameControl.player8.GetComponent<FollowThePath>().waypointIndex != 43)){
                                whatPlay = 8;
                                GameControl.diceSideThrown = DiceResult[3];
                                GameControl.MovePlayer(8);
                                yield return new WaitForSeconds(1.005f);
                                break;
                            }
                            yield return new WaitForSeconds(0.005f);
                        }
                        yield return new WaitForSeconds(0.005f);
                        whatPlay = 0;
                        DiceResult[3] = 6;
                    }

                    // Debug.Log("ffff" + DiceResult[0] + "sssss" + DiceResult[1] + "dddddd" + DiceResult[2] + "ffffff" + DiceResult[3]);
                    yield return new WaitForSeconds(0.005f);
                    if(DiceResult[0] == 6 && DiceResult[1] == 6 && DiceResult[2] == 6 && DiceResult[3] == 6){
                        yield return new WaitForSeconds(3f);
                        GameControl.player5.GetComponent<FollowThePath>().moveAllowed = false;
                        GameControl.player6.GetComponent<FollowThePath>().moveAllowed = false;
                        GameControl.player7.GetComponent<FollowThePath>().moveAllowed = false;
                        GameControl.player8.GetComponent<FollowThePath>().moveAllowed = false;
                        GameControl.diceSideThrown = 0;
                        whosTurn = -1;
                        Debug.Log("ㄹ언ㅁㄹㄹㅇㄴㅁ   :   " + whosTurn );
                        whatPlay = 0;
                        oneMore = 0;
                        break;
                    } 
                }
            }
            Debug.Log("다이스 값 확인 3 : " + GameControl.diceSideThrown);
        }
        whosTurn *= -1;
        coroutineAllowed = true;
    }

    //////////////////////////////////////               윷 던지는 과정               //////////////////////////////////////////////////////

    private IEnumerator RollYut() {
        YutAllowed = false;
        // randomMatch = 0;
        // randomDiceSide = 0;
        for(int i = 0; i <= 20; i++)
        {
            randomMatch = Random.Range(0,16);
            if(randomMatch < 4) {
                randomDiceSide = 0;
            } else if (randomMatch >= 4 && randomMatch < 10) {
                randomDiceSide = 1;
            } else if (randomMatch >= 10 && randomMatch < 14){
                randomDiceSide = 2;
            } else if (randomMatch == 14) {
                randomDiceSide = 3;
            } else {
                randomDiceSide = 4;
            }
            rend.sprite = diceSides[randomDiceSide];
            yield return new WaitForSeconds(0.05f);
        }
            
        DiceResult[oneMore] = randomDiceSide + 1;
        GameControl.yutDice[oneMore] = randomDiceSide + 1;
        oneMore++;

        passYut = randomDiceSide;

        YutAllowed = true;
    }
}