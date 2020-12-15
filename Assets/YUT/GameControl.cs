using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    private static GameObject whoWinsTextShadow, player1MoveText, player5MoveText, YutResult1, YutResult2, YutResult3, YutResult4, YutResult5, YutResult6;

    public static GameObject player1, player2, player3, player4, player5, player6, player7, player8;

    public static int[] yutDice = new int[5];

    public static int diceSideThrown = 1;
    public static int player1StartWaypoint = 0;
    // public static int player2StartWaypoint = 0;
    // public static int player3StartWaypoint = 0;
    // public static int player4StartWaypoint = 0;
    public static int player5StartWaypoint = 0;
    // public static int player6StartWaypoint = 0;
    // public static int player7StartWaypoint = 0;
    // public static int player8StartWaypoint = 0;

    public static string Yut = null;

    public static bool gameOver = false;
    
    // Start is called before the first frame update
    void Start()
    {
        whoWinsTextShadow = GameObject.Find("WhoWinsText");
        player1MoveText = GameObject.Find("Player1MoveText");
        player5MoveText = GameObject.Find("Player5MoveText");

        YutResult1 = GameObject.Find("YutResult1");
        YutResult2 = GameObject.Find("YutResult2");
        YutResult3 = GameObject.Find("YutResult3");
        YutResult4 = GameObject.Find("YutResult4");
        YutResult5 = GameObject.Find("YutResult5");
        YutResult6 = GameObject.Find("YutResult6");

        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");
        player3 = GameObject.Find("Player3");
        player4 = GameObject.Find("Player4");
        player5 = GameObject.Find("Player5");
        player6 = GameObject.Find("Player6");
        player7 = GameObject.Find("Player7");
        player8 = GameObject.Find("Player8");

        player1.GetComponent<FollowThePath>().moveAllowed = false;
        player2.GetComponent<FollowThePath>().moveAllowed = false;
        player3.GetComponent<FollowThePath>().moveAllowed = false;
        player4.GetComponent<FollowThePath>().moveAllowed = false;
        player5.GetComponent<FollowThePath>().moveAllowed = false;
        player6.GetComponent<FollowThePath>().moveAllowed = false;
        player7.GetComponent<FollowThePath>().moveAllowed = false;
        player8.GetComponent<FollowThePath>().moveAllowed = false;

        whoWinsTextShadow.gameObject.SetActive(false);
        player1MoveText.gameObject.SetActive(true);
        player5MoveText.gameObject.SetActive(false);
        
        YutResult1.gameObject.SetActive(false);
        YutResult2.gameObject.SetActive(false);
        YutResult3.gameObject.SetActive(false);
        YutResult4.gameObject.SetActive(false);
        YutResult5.gameObject.SetActive(false);
        YutResult6.gameObject.SetActive(false);

        player1.gameObject.SetActive(false);
        player2.gameObject.SetActive(false);
        player3.gameObject.SetActive(false);
        player4.gameObject.SetActive(false);
        player5.gameObject.SetActive(false);
        player6.gameObject.SetActive(false);
        player7.gameObject.SetActive(false);
        player8.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Dice.whosTurn == 1){
            if(Dice.whatPlay == 1) {
                player1.gameObject.SetActive(true);
            } 
            // else if(Dice.whatPlay == 2) {
            //     player2.gameObject.SetActive(true);
            // } else if(Dice.whatPlay == 3) {
            //     player3.gameObject.SetActive(true);
            // } else if(Dice.whatPlay == 4) {
            //     player4.gameObject.SetActive(true);
            // }
        }

        if(Dice.whosTurn == -1){
            if(Dice.whatPlay == 5) {
                player5.gameObject.SetActive(true);
            } 
            // else if(Dice.whatPlay == 6) {
            //     player6.gameObject.SetActive(true);
            // } else if(Dice.whatPlay == 7) {
            //     player7.gameObject.SetActive(true);
            // } else if(Dice.whatPlay == 8) {
            //     player8.gameObject.SetActive(true);
            // }
        }

        for(int i = 0; i < yutDice.Length; i ++){
            if(yutDice[i] >= 1 && yutDice[i] <= 5){
                if(Dice.oneMore == 1 && Dice.DiceResult[0] != 6){
                    YutResult1.gameObject.SetActive(true);
                } else if(Dice.oneMore == 2 && Dice.DiceResult[1] != 6){
                    YutResult2.gameObject.SetActive(true);
                } else if(Dice.oneMore == 3 && Dice.DiceResult[2] != 6){
                    YutResult3.gameObject.SetActive(true);
                } else if(Dice.oneMore == 4 && Dice.DiceResult[3] != 6){
                    YutResult4.gameObject.SetActive(true);
                } else if(Dice.oneMore == 5 && Dice.DiceResult[4] != 6){
                    YutResult5.gameObject.SetActive(true);
                } else if(Dice.oneMore == 6 && Dice.DiceResult[5] != 6){
                    YutResult6.gameObject.SetActive(true);
                }

                if(yutDice[i] == 1){
                    Yut = "도";
                } else if (yutDice[i] == 2){
                    Yut = "개";
                } else if (yutDice[i] == 3){
                    Yut = "걸";
                } else if (yutDice[i] == 4){
                    Yut = "윷";
                } else if (yutDice[i] == 5) {
                    Yut = "모";
                }

                if(Dice.oneMore == 1){
                    YutResult1.GetComponent<Text>().text = Yut;
                } else if(Dice.oneMore == 2){
                    YutResult2.GetComponent<Text>().text = Yut;
                } else if(Dice.oneMore == 3){
                    YutResult3.GetComponent<Text>().text = Yut;
                } else if(Dice.oneMore == 4){
                    YutResult4.GetComponent<Text>().text = Yut;
                } else if(Dice.oneMore == 5){
                    YutResult5.GetComponent<Text>().text = Yut;
                } else if(Dice.oneMore == 6){
                    YutResult6.GetComponent<Text>().text = Yut;
                }
            } else {
                if(Dice.DiceResult[0] == 6){
                    YutResult1.gameObject.SetActive(false);
                    yutDice[0] = 0;
                } if(Dice.DiceResult[1] == 6){
                    YutResult2.gameObject.SetActive(false);
                    yutDice[1] = 0;
                } if(Dice.DiceResult[2] == 6){
                    YutResult3.gameObject.SetActive(false);
                    yutDice[2] = 0;
                } if(Dice.DiceResult[3] == 6){
                    YutResult4.gameObject.SetActive(false);
                    yutDice[3] = 0;
                } if(Dice.DiceResult[4] == 6){
                    YutResult5.gameObject.SetActive(false);
                    yutDice[4] = 0;
                }
                // YutResult.gameObject.SetActive(false);
            }
        }

        //////////////////////////////////////               1번말 제어               //////////////////////////////////////////////////////

        if(player1.GetComponent<FollowThePath>().waypointIndex > player1StartWaypoint + diceSideThrown)
        {
            if(diceSideThrown == 0 && Dice.whatPlay == 0 && player1StartWaypoint == 0){
                player5MoveText.gameObject.SetActive(false);
                player1MoveText.gameObject.SetActive(true);
                player1.GetComponent<FollowThePath>().moveAllowed = false;
                player1.gameObject.SetActive(false);
            } else if( diceSideThrown > 0 && diceSideThrown < 6) {
                player1.GetComponent<FollowThePath>().moveAllowed = false;
                player1MoveText.gameObject.SetActive(false);
                player5MoveText.gameObject.SetActive(true);
            } else if( diceSideThrown >= 6) {
                player1.GetComponent<FollowThePath>().moveAllowed = false;
                player1MoveText.gameObject.SetActive(false);
                player5MoveText.gameObject.SetActive(true);
                diceSideThrown = 0;
            }

            //////////////////////////////////               말을 잡았을 경우           //////////////////////////////////////////////////////
            if(player1.GetComponent<FollowThePath>().waypointIndex == 43){
                
            } else if(player1.GetComponent<FollowThePath>().waypointIndex != 0) {
                if(player1.GetComponent<FollowThePath>().waypointIndex == player5.GetComponent<FollowThePath>().waypointIndex){
                    Dice.whosTurn *= -1;
                    player1.GetComponent<FollowThePath>().moveAllowed = false;
                    player5.GetComponent<FollowThePath>().moveAllowed = true;
                    player5.GetComponent<FollowThePath>().waypointIndex = 0;
                    player5StartWaypoint = 0;
                    diceSideThrown = 0;
                    player1MoveText.gameObject.SetActive(true);
                    player5MoveText.gameObject.SetActive(false);
                    Dice.oneMore -= 1;
                    if(Dice.oneMore <= 0){
                        Dice.oneMore = 0;
                    }
                } 
                // if(player1.GetComponent<FollowThePath>().waypointIndex == player6.GetComponent<FollowThePath>().waypointIndex){
                //     Dice.whosTurn *= -1;
                //     player1.GetComponent<FollowThePath>().moveAllowed = false;
                //     player6.GetComponent<FollowThePath>().moveAllowed = true;
                //     player6.GetComponent<FollowThePath>().waypointIndex = 0;
                //     player6StartWaypoint = 0;
                //     diceSideThrown = 0;
                //     player1MoveText.gameObject.SetActive(true);
                //     player5MoveText.gameObject.SetActive(false);
                //     Dice.oneMore -= 1;
                //     if(Dice.oneMore <= 0){
                //         Dice.oneMore = 0;
                //     }
                // } 
                // if(player1.GetComponent<FollowThePath>().waypointIndex == player7.GetComponent<FollowThePath>().waypointIndex){
                //     Dice.whosTurn *= -1;
                //     player1.GetComponent<FollowThePath>().moveAllowed = false;
                //     player7.GetComponent<FollowThePath>().moveAllowed = true;
                //     player7.GetComponent<FollowThePath>().waypointIndex = 0;
                //     player7StartWaypoint = 0;
                //     diceSideThrown = 0;
                //     player1MoveText.gameObject.SetActive(true);
                //     player5MoveText.gameObject.SetActive(false);
                //     Dice.oneMore -= 1;
                //     if(Dice.oneMore <= 0){
                //         Dice.oneMore = 0;
                //     }
                // } 
                // if(player1.GetComponent<FollowThePath>().waypointIndex == player8.GetComponent<FollowThePath>().waypointIndex){
                //     Dice.whosTurn *= -1;
                //     player1.GetComponent<FollowThePath>().moveAllowed = false;
                //     player8.GetComponent<FollowThePath>().moveAllowed = true;
                //     player8.GetComponent<FollowThePath>().waypointIndex = 0;
                //     player8StartWaypoint = 0;
                //     diceSideThrown = 0;
                //     player1MoveText.gameObject.SetActive(true);
                //     player5MoveText.gameObject.SetActive(false);
                //     Dice.oneMore -= 1;
                //     if(Dice.oneMore <= 0){
                //         Dice.oneMore = 0;
                //     }
                // }
            }
            
            player1StartWaypoint = player1.GetComponent<FollowThePath>().waypointIndex -1;

            //////////////////////////////////               꼭지점을 밟았을 경우           /////////////////////////////////////////////////
            if ( player1.GetComponent<FollowThePath>().waypointIndex == 6) {
                player1.GetComponent<FollowThePath>().waypointIndex = 23;
            }
            if ( player1.GetComponent<FollowThePath>().waypointIndex == 11) {
                player1.GetComponent<FollowThePath>().waypointIndex = 36;
            }
            if ( player1.GetComponent<FollowThePath>().waypointIndex == 26) {
                player1.GetComponent<FollowThePath>().waypointIndex = 39;
            }

            if(Dice.DiceResult[1] == 6 && Dice.DiceResult[2] == 6 && Dice.DiceResult[3] == 6 && Dice.DiceResult[0] == 6){
                
            } else{
                // Dice.whosTurn = 1;
            }
        }

        //////////////////////////////////////               2번말 제어               //////////////////////////////////////////////////////

        // if(player2.GetComponent<FollowThePath>().waypointIndex > player2StartWaypoint + diceSideThrown)
        // {
        //     if(diceSideThrown == 0 && Dice.whatPlay == 0 && player2StartWaypoint == 0){
        //         player5MoveText.gameObject.SetActive(false);
        //         player1MoveText.gameObject.SetActive(true);
        //         player2.GetComponent<FollowThePath>().moveAllowed = false;
        //         player2.gameObject.SetActive(false);
        //     } else if( diceSideThrown > 0 && diceSideThrown < 6) {
        //         player2.GetComponent<FollowThePath>().moveAllowed = false;
        //         player1MoveText.gameObject.SetActive(false);
        //         player5MoveText.gameObject.SetActive(true);
        //     } else if( diceSideThrown >= 6) {
        //         player2.GetComponent<FollowThePath>().moveAllowed = false;
        //         player1MoveText.gameObject.SetActive(false);
        //         player5MoveText.gameObject.SetActive(true);
        //         diceSideThrown = 0;
        //     }
            
        //     //////////////////////////////////               말을 잡았을 경우           //////////////////////////////////////////////////////
        //     if(player2.GetComponent<FollowThePath>().waypointIndex == 43){
                
        //     } else if(player2.GetComponent<FollowThePath>().waypointIndex != 0) {
        //         if(player2.GetComponent<FollowThePath>().waypointIndex == player5.GetComponent<FollowThePath>().waypointIndex){
        //             Dice.whosTurn *= -1;
        //             player2.GetComponent<FollowThePath>().moveAllowed = false;
        //             player5.GetComponent<FollowThePath>().moveAllowed = true;
        //             player5.GetComponent<FollowThePath>().waypointIndex = 0;
        //             player5StartWaypoint = 0;
        //             diceSideThrown = 0;
        //             player1MoveText.gameObject.SetActive(true);
        //             player5MoveText.gameObject.SetActive(false);
        //             Dice.oneMore -= 1;
        //             if(Dice.oneMore <= 0){
        //                 Dice.oneMore = 0;
        //             }
        //         } 
        //         if(player2.GetComponent<FollowThePath>().waypointIndex == player6.GetComponent<FollowThePath>().waypointIndex){
        //             Dice.whosTurn *= -1;
        //             player2.GetComponent<FollowThePath>().moveAllowed = false;
        //             player6.GetComponent<FollowThePath>().moveAllowed = true;
        //             player6.GetComponent<FollowThePath>().waypointIndex = 0;
        //             player6StartWaypoint = 0;
        //             diceSideThrown = 0;
        //             player1MoveText.gameObject.SetActive(true);
        //             player5MoveText.gameObject.SetActive(false);
        //             Dice.oneMore -= 1;
        //             if(Dice.oneMore <= 0){
        //                 Dice.oneMore = 0;
        //             }
        //         } 
        //         if(player2.GetComponent<FollowThePath>().waypointIndex == player7.GetComponent<FollowThePath>().waypointIndex){
        //             Dice.whosTurn *= -1;
        //             player2.GetComponent<FollowThePath>().moveAllowed = false;
        //             player7.GetComponent<FollowThePath>().moveAllowed = true;
        //             player7.GetComponent<FollowThePath>().waypointIndex = 0;
        //             player7StartWaypoint = 0;
        //             diceSideThrown = 0;
        //             player1MoveText.gameObject.SetActive(true);
        //             player5MoveText.gameObject.SetActive(false);
        //             Dice.oneMore -= 1;
        //             if(Dice.oneMore <= 0){
        //                 Dice.oneMore = 0;
        //             }
        //         } 
        //         if(player2.GetComponent<FollowThePath>().waypointIndex == player8.GetComponent<FollowThePath>().waypointIndex){
        //             Dice.whosTurn *= -1;
        //             player2.GetComponent<FollowThePath>().moveAllowed = false;
        //             player8.GetComponent<FollowThePath>().moveAllowed = true;
        //             player8.GetComponent<FollowThePath>().waypointIndex = 0;
        //             player8StartWaypoint = 0;
        //             diceSideThrown = 0;
        //             player1MoveText.gameObject.SetActive(true);
        //             player5MoveText.gameObject.SetActive(false);
        //             Dice.oneMore -= 1;
        //             if(Dice.oneMore <= 0){
        //                 Dice.oneMore = 0;
        //             }
        //         } 
        //     }
            

        //     //////////////////////////////////               꼭지점을 밟았을 경우           /////////////////////////////////////////////////
        //     player2StartWaypoint = player2.GetComponent<FollowThePath>().waypointIndex -1;
        //     if ( player2.GetComponent<FollowThePath>().waypointIndex == 6) {
        //         player2.GetComponent<FollowThePath>().waypointIndex = 23;
        //     }
        //     if ( player2.GetComponent<FollowThePath>().waypointIndex == 11) {
        //         player2.GetComponent<FollowThePath>().waypointIndex = 36;
        //     }
        //     if ( player2.GetComponent<FollowThePath>().waypointIndex == 26) {
        //         player2.GetComponent<FollowThePath>().waypointIndex = 39;
        //     }

        //     if(Dice.DiceResult[1] == 6 && Dice.DiceResult[2] == 6 && Dice.DiceResult[3] == 6 && Dice.DiceResult[0] == 6){
                
        //     } else{
        //         // Dice.whosTurn = 1;
        //     }
        // }

        // //////////////////////////////////////               3번말 제어               //////////////////////////////////////////////////////

        // if(player3.GetComponent<FollowThePath>().waypointIndex > player3StartWaypoint + diceSideThrown)
        // {
        //     if(diceSideThrown == 0 && Dice.whatPlay == 0 && player3StartWaypoint == 0){
        //         player5MoveText.gameObject.SetActive(false);
        //         player1MoveText.gameObject.SetActive(true);
        //         player3.GetComponent<FollowThePath>().moveAllowed = false;
        //         player3.gameObject.SetActive(false);
        //     } else if( diceSideThrown > 0 && diceSideThrown < 6) {
        //         player3.GetComponent<FollowThePath>().moveAllowed = false;
        //         player1MoveText.gameObject.SetActive(false);
        //         player5MoveText.gameObject.SetActive(true);
        //     } else if( diceSideThrown >= 6) {
        //         player3.GetComponent<FollowThePath>().moveAllowed = false;
        //         player1MoveText.gameObject.SetActive(false);
        //         player5MoveText.gameObject.SetActive(true);
        //         diceSideThrown = 0;
        //     }

        //     //////////////////////////////////               말을 잡았을 경우           //////////////////////////////////////////////////////
        //     if(player3.GetComponent<FollowThePath>().waypointIndex == 43){
                
        //     } else if(player3.GetComponent<FollowThePath>().waypointIndex != 0) {
        //         if(player3.GetComponent<FollowThePath>().waypointIndex == player5.GetComponent<FollowThePath>().waypointIndex){
        //             Dice.whosTurn *= -1;
        //             player3.GetComponent<FollowThePath>().moveAllowed = false;
        //             player5.GetComponent<FollowThePath>().moveAllowed = true;
        //             player5.GetComponent<FollowThePath>().waypointIndex = 0;
        //             player5StartWaypoint = 0;
        //             diceSideThrown = 0;
        //             player1MoveText.gameObject.SetActive(true);
        //             player5MoveText.gameObject.SetActive(false);
        //             Dice.oneMore -= 1;
        //             if(Dice.oneMore <= 0){
        //                 Dice.oneMore = 0;
        //             }
        //         } 
        //         if(player3.GetComponent<FollowThePath>().waypointIndex == player6.GetComponent<FollowThePath>().waypointIndex){
        //             Dice.whosTurn *= -1;
        //             player3.GetComponent<FollowThePath>().moveAllowed = false;
        //             player6.GetComponent<FollowThePath>().moveAllowed = true;
        //             player6.GetComponent<FollowThePath>().waypointIndex = 0;
        //             player6StartWaypoint = 0;
        //             diceSideThrown = 0;
        //             player1MoveText.gameObject.SetActive(true);
        //             player5MoveText.gameObject.SetActive(false);
        //             Dice.oneMore -= 1;
        //             if(Dice.oneMore <= 0){
        //                 Dice.oneMore = 0;
        //             }
        //         } 
        //         if(player3.GetComponent<FollowThePath>().waypointIndex == player7.GetComponent<FollowThePath>().waypointIndex){
        //             Dice.whosTurn *= -1;
        //             player3.GetComponent<FollowThePath>().moveAllowed = false;
        //             player7.GetComponent<FollowThePath>().moveAllowed = true;
        //             player7.GetComponent<FollowThePath>().waypointIndex = 0;
        //             player7StartWaypoint = 0;
        //             diceSideThrown = 0;
        //             player1MoveText.gameObject.SetActive(true);
        //             player5MoveText.gameObject.SetActive(false);
        //             Dice.oneMore -= 1;
        //             if(Dice.oneMore <= 0){
        //                 Dice.oneMore = 0;
        //             }
        //         } 
        //         if(player3.GetComponent<FollowThePath>().waypointIndex == player8.GetComponent<FollowThePath>().waypointIndex){
        //             Dice.whosTurn *= -1;
        //             player3.GetComponent<FollowThePath>().moveAllowed = false;
        //             player8.GetComponent<FollowThePath>().moveAllowed = true;
        //             player8.GetComponent<FollowThePath>().waypointIndex = 0;
        //             player8StartWaypoint = 0;
        //             diceSideThrown = 0;
        //             player1MoveText.gameObject.SetActive(true);
        //             player5MoveText.gameObject.SetActive(false);
        //             Dice.oneMore -= 1;
        //             if(Dice.oneMore <= 0){
        //                 Dice.oneMore = 0;
        //             }
        //         } 
        //     }
            
        //     //////////////////////////////////               꼭지점을 밟았을 경우           /////////////////////////////////////////////////
        //     player3StartWaypoint = player3.GetComponent<FollowThePath>().waypointIndex -1;
        //     if ( player3.GetComponent<FollowThePath>().waypointIndex == 6) {
        //         player3.GetComponent<FollowThePath>().waypointIndex = 23;
        //     }
        //     if ( player3.GetComponent<FollowThePath>().waypointIndex == 11) {
        //         player3.GetComponent<FollowThePath>().waypointIndex = 36;
        //     }
        //     if ( player3.GetComponent<FollowThePath>().waypointIndex == 26) {
        //         player3.GetComponent<FollowThePath>().waypointIndex = 39;
        //     }

        //     if(Dice.DiceResult[1] == 6 && Dice.DiceResult[2] == 6 && Dice.DiceResult[3] == 6 && Dice.DiceResult[0] == 6){
                
        //     } else{
        //         // Dice.whosTurn = 1;
        //     }
        // }

        // //////////////////////////////////////               4번말 제어               //////////////////////////////////////////////////////

        // if(player4.GetComponent<FollowThePath>().waypointIndex > player4StartWaypoint + diceSideThrown)
        // {
        //     if(diceSideThrown == 0 && Dice.whatPlay == 0 && player4StartWaypoint == 0){
        //         player5MoveText.gameObject.SetActive(false);
        //         player1MoveText.gameObject.SetActive(true);
        //         player4.GetComponent<FollowThePath>().moveAllowed = false;
        //         player4.gameObject.SetActive(false);
        //     } else if( diceSideThrown > 0 && diceSideThrown < 6) {
        //         player4.GetComponent<FollowThePath>().moveAllowed = false;
        //         player1MoveText.gameObject.SetActive(false);
        //         player5MoveText.gameObject.SetActive(true);
        //     } else if( diceSideThrown >= 6) {
        //         player4.GetComponent<FollowThePath>().moveAllowed = false;
        //         player1MoveText.gameObject.SetActive(false);
        //         player5MoveText.gameObject.SetActive(true);
        //         diceSideThrown = 0;
        //     }

        //     //////////////////////////////////               말을 잡았을 경우           //////////////////////////////////////////////////////
        //     if(player4.GetComponent<FollowThePath>().waypointIndex == 43){
                
        //     } else if(player4.GetComponent<FollowThePath>().waypointIndex != 0) {
        //         if(player4.GetComponent<FollowThePath>().waypointIndex == player5.GetComponent<FollowThePath>().waypointIndex){
        //             Dice.whosTurn *= -1;
        //             player4.GetComponent<FollowThePath>().moveAllowed = false;
        //             player5.GetComponent<FollowThePath>().moveAllowed = true;
        //             player5.GetComponent<FollowThePath>().waypointIndex = 0;
        //             player5StartWaypoint = 0;
        //             diceSideThrown = 0;
        //             player1MoveText.gameObject.SetActive(true);
        //             player5MoveText.gameObject.SetActive(false);
        //             Dice.oneMore -= 1;
        //             if(Dice.oneMore <= 0){
        //                 Dice.oneMore = 0;
        //             }
        //         } 
        //         if(player4.GetComponent<FollowThePath>().waypointIndex == player6.GetComponent<FollowThePath>().waypointIndex){
        //             Dice.whosTurn *= -1;
        //             player4.GetComponent<FollowThePath>().moveAllowed = false;
        //             player6.GetComponent<FollowThePath>().moveAllowed = true;
        //             player6.GetComponent<FollowThePath>().waypointIndex = 0;
        //             player6StartWaypoint = 0;
        //             diceSideThrown = 0;
        //             player1MoveText.gameObject.SetActive(true);
        //             player5MoveText.gameObject.SetActive(false);
        //             Dice.oneMore -= 1;
        //             if(Dice.oneMore <= 0){
        //                 Dice.oneMore = 0;
        //             }
        //         } 
        //         if(player4.GetComponent<FollowThePath>().waypointIndex == player7.GetComponent<FollowThePath>().waypointIndex){
        //             Dice.whosTurn *= -1;
        //             player4.GetComponent<FollowThePath>().moveAllowed = false;
        //             player7.GetComponent<FollowThePath>().moveAllowed = true;
        //             player7.GetComponent<FollowThePath>().waypointIndex = 0;
        //             player7StartWaypoint = 0;
        //             diceSideThrown = 0;
        //             player1MoveText.gameObject.SetActive(true);
        //             player5MoveText.gameObject.SetActive(false);
        //             Dice.oneMore -= 1;
        //             if(Dice.oneMore <= 0){
        //                 Dice.oneMore = 0;
        //             }
        //         } 
        //         if(player4.GetComponent<FollowThePath>().waypointIndex == player8.GetComponent<FollowThePath>().waypointIndex){
        //             Dice.whosTurn *= -1;
        //             player4.GetComponent<FollowThePath>().moveAllowed = false;
        //             player8.GetComponent<FollowThePath>().moveAllowed = true;
        //             player8.GetComponent<FollowThePath>().waypointIndex = 0;
        //             player8StartWaypoint = 0;
        //             diceSideThrown = 0;
        //             player1MoveText.gameObject.SetActive(true);
        //             player5MoveText.gameObject.SetActive(false);
        //             Dice.oneMore -= 1;
        //             if(Dice.oneMore <= 0){
        //                 Dice.oneMore = 0;
        //             }
        //         } 
        //     }
            
        //     //////////////////////////////////               꼭지점을 밟았을 경우           /////////////////////////////////////////////////
        //     player4StartWaypoint = player4.GetComponent<FollowThePath>().waypointIndex -1;
        //     if ( player4.GetComponent<FollowThePath>().waypointIndex == 6) {
        //         player4.GetComponent<FollowThePath>().waypointIndex = 23;
        //     }
        //     if ( player4.GetComponent<FollowThePath>().waypointIndex == 11) {
        //         player4.GetComponent<FollowThePath>().waypointIndex = 36;
        //     }
        //     if ( player4.GetComponent<FollowThePath>().waypointIndex == 26) {
        //         player4.GetComponent<FollowThePath>().waypointIndex = 39;
        //     }

        //     if(Dice.DiceResult[1] == 6 && Dice.DiceResult[2] == 6 && Dice.DiceResult[3] == 6 && Dice.DiceResult[0] == 6){
                
        //     } else{
        //         // Dice.whosTurn = 1;
        //     }
        // }

        //////////////////////////////////////               5번말 제어               //////////////////////////////////////////////////////

        if(player5.GetComponent<FollowThePath>().waypointIndex > player5StartWaypoint + diceSideThrown)
        {
            if(diceSideThrown == 0 && Dice.whatPlay == 0 && player5StartWaypoint == 0 ){
                player1MoveText.gameObject.SetActive(false);
                player5MoveText.gameObject.SetActive(true);
                player5.GetComponent<FollowThePath>().moveAllowed = false;
                player5.gameObject.SetActive(false);
            } else if( diceSideThrown > 0 && diceSideThrown < 6) {
                player5.GetComponent<FollowThePath>().moveAllowed = false;
                player5MoveText.gameObject.SetActive(false);
                player1MoveText.gameObject.SetActive(true);
            } else if( diceSideThrown >= 6) {
                player5.GetComponent<FollowThePath>().moveAllowed = false;
                player5MoveText.gameObject.SetActive(false);
                player1MoveText.gameObject.SetActive(true);
                diceSideThrown = 0;
            }

            //////////////////////////////////               말을 잡았을 경우           //////////////////////////////////////////////////////
            if(player5.GetComponent<FollowThePath>().waypointIndex == 43){
                
            } else if(player5.GetComponent<FollowThePath>().waypointIndex != 0) {
                if(player5.GetComponent<FollowThePath>().waypointIndex == player1.GetComponent<FollowThePath>().waypointIndex){
                    Dice.whosTurn *= -1;
                    player5.GetComponent<FollowThePath>().moveAllowed = false;
                    player1.GetComponent<FollowThePath>().moveAllowed = true;
                    player1.GetComponent<FollowThePath>().waypointIndex = 0;
                    player1StartWaypoint = 0;
                    diceSideThrown = 0;
                    player5MoveText.gameObject.SetActive(true);
                    player1MoveText.gameObject.SetActive(false);
                    Dice.oneMore -= 1;
                    if(Dice.oneMore <= 0){
                        Dice.oneMore = 0;
                    }
                }
                // if(player5.GetComponent<FollowThePath>().waypointIndex == player2.GetComponent<FollowThePath>().waypointIndex){
                //     Dice.whosTurn *= -1;
                //     player5.GetComponent<FollowThePath>().moveAllowed = false;
                //     player2.GetComponent<FollowThePath>().moveAllowed = true;
                //     player2.GetComponent<FollowThePath>().waypointIndex = 0;
                //     player2StartWaypoint = 0;
                //     diceSideThrown = 0;
                //     player5MoveText.gameObject.SetActive(true);
                //     player1MoveText.gameObject.SetActive(false);
                //     Dice.oneMore -= 1;
                //     if(Dice.oneMore <= 0){
                //         Dice.oneMore = 0;
                //     }
                // }
                // if(player5.GetComponent<FollowThePath>().waypointIndex == player3.GetComponent<FollowThePath>().waypointIndex){
                //     Dice.whosTurn *= -1;
                //     player5.GetComponent<FollowThePath>().moveAllowed = false;
                //     player3.GetComponent<FollowThePath>().moveAllowed = true;
                //     player3.GetComponent<FollowThePath>().waypointIndex = 0;
                //     player3StartWaypoint = 0;
                //     diceSideThrown = 0;
                //     player5MoveText.gameObject.SetActive(true);
                //     player1MoveText.gameObject.SetActive(false);
                //     Dice.oneMore -= 1;
                //     if(Dice.oneMore <= 0){
                //         Dice.oneMore = 0;
                //     }
                // }
                // if(player5.GetComponent<FollowThePath>().waypointIndex == player4.GetComponent<FollowThePath>().waypointIndex){
                //     Dice.whosTurn *= -1;
                //     player5.GetComponent<FollowThePath>().moveAllowed = false;
                //     player4.GetComponent<FollowThePath>().moveAllowed = true;
                //     player4.GetComponent<FollowThePath>().waypointIndex = 0;
                //     player4StartWaypoint = 0;
                //     diceSideThrown = 0;
                //     player5MoveText.gameObject.SetActive(true);
                //     player1MoveText.gameObject.SetActive(false);
                //     Dice.oneMore -= 1;
                //     if(Dice.oneMore <= 0){
                //         Dice.oneMore = 0;
                //     }
                // } 
            }

            //////////////////////////////////               꼭지점을 밟았을 경우           /////////////////////////////////////////////////
            player5StartWaypoint = player5.GetComponent<FollowThePath>().waypointIndex -1;
            if ( player5.GetComponent<FollowThePath>().waypointIndex == 6) {
                player5.GetComponent<FollowThePath>().waypointIndex = 23;
            }
            if ( player5.GetComponent<FollowThePath>().waypointIndex == 11) {
                player5.GetComponent<FollowThePath>().waypointIndex = 36;
            }
            if ( player5.GetComponent<FollowThePath>().waypointIndex == 26) {
                player5.GetComponent<FollowThePath>().waypointIndex = 39;
            }

            if(Dice.DiceResult[1] == 6 && Dice.DiceResult[2] == 6 && Dice.DiceResult[3] == 6 && Dice.DiceResult[0] == 6){
                
            } else{
                // Dice.whosTurn = -1;
            }
        }

        //////////////////////////////////////               6번말 제어               //////////////////////////////////////////////////////

        // if(player6.GetComponent<FollowThePath>().waypointIndex > player6StartWaypoint + diceSideThrown)
        // {
        //     if(diceSideThrown == 0 && Dice.whatPlay == 0 && player6StartWaypoint == 0 ){
        //         player1MoveText.gameObject.SetActive(false);
        //         player5MoveText.gameObject.SetActive(true);
        //         player6.GetComponent<FollowThePath>().moveAllowed = false;
        //         player6.gameObject.SetActive(false);
        //     } else if( diceSideThrown > 0 && diceSideThrown < 6) {
        //         player6.GetComponent<FollowThePath>().moveAllowed = false;
        //         player5MoveText.gameObject.SetActive(false);
        //         player1MoveText.gameObject.SetActive(true);
        //     } else if( diceSideThrown >= 6) {
        //         player6.GetComponent<FollowThePath>().moveAllowed = false;
        //         player5MoveText.gameObject.SetActive(false);
        //         player1MoveText.gameObject.SetActive(true);
        //         diceSideThrown = 0;
        //     }

        //     //////////////////////////////////               말을 잡았을 경우           //////////////////////////////////////////////////////
        //     if(player6.GetComponent<FollowThePath>().waypointIndex == 43){
                
        //     } else if(player6.GetComponent<FollowThePath>().waypointIndex != 0) {
        //         if(player6.GetComponent<FollowThePath>().waypointIndex == player1.GetComponent<FollowThePath>().waypointIndex){
        //             Dice.whosTurn *= -1;
        //             player6.GetComponent<FollowThePath>().moveAllowed = false;
        //             player1.GetComponent<FollowThePath>().moveAllowed = true;
        //             player1.GetComponent<FollowThePath>().waypointIndex = 0;
        //             player1StartWaypoint = 0;
        //             diceSideThrown = 0;
        //             player5MoveText.gameObject.SetActive(true);
        //             player1MoveText.gameObject.SetActive(false);
        //             Dice.oneMore -= 1;
        //             if(Dice.oneMore <= 0){
        //                 Dice.oneMore = 0;
        //             }
        //         } 
        //         if(player6.GetComponent<FollowThePath>().waypointIndex == player2.GetComponent<FollowThePath>().waypointIndex){
        //             Dice.whosTurn *= -1;
        //             player6.GetComponent<FollowThePath>().moveAllowed = false;
        //             player2.GetComponent<FollowThePath>().moveAllowed = true;
        //             player2.GetComponent<FollowThePath>().waypointIndex = 0;
        //             player2StartWaypoint = 0;
        //             diceSideThrown = 0;
        //             player5MoveText.gameObject.SetActive(true);
        //             player1MoveText.gameObject.SetActive(false);
        //             Dice.oneMore -= 1;
        //             if(Dice.oneMore <= 0){
        //                 Dice.oneMore = 0;
        //             }
        //         } 
        //         if(player6.GetComponent<FollowThePath>().waypointIndex == player3.GetComponent<FollowThePath>().waypointIndex){
        //             Dice.whosTurn *= -1;
        //             player6.GetComponent<FollowThePath>().moveAllowed = false;
        //             player3.GetComponent<FollowThePath>().moveAllowed = true;
        //             player3.GetComponent<FollowThePath>().waypointIndex = 0;
        //             player3StartWaypoint = 0;
        //             diceSideThrown = 0;
        //             player5MoveText.gameObject.SetActive(true);
        //             player1MoveText.gameObject.SetActive(false);
        //             Dice.oneMore -= 1;
        //             if(Dice.oneMore <= 0){
        //                 Dice.oneMore = 0;
        //             }
        //         } 
        //         if(player6.GetComponent<FollowThePath>().waypointIndex == player4.GetComponent<FollowThePath>().waypointIndex){
        //             Dice.whosTurn *= -1;
        //             player6.GetComponent<FollowThePath>().moveAllowed = false;
        //             player4.GetComponent<FollowThePath>().moveAllowed = true;
        //             player4.GetComponent<FollowThePath>().waypointIndex = 0;
        //             player4StartWaypoint = 0;
        //             diceSideThrown = 0;
        //             player5MoveText.gameObject.SetActive(true);
        //             player1MoveText.gameObject.SetActive(false);
        //             Dice.oneMore -= 1;
        //             if(Dice.oneMore <= 0){
        //                 Dice.oneMore = 0;
        //             }
        //         } 
        //     }

        //     //////////////////////////////////               꼭지점을 밟았을 경우           /////////////////////////////////////////////////
        //     player6StartWaypoint = player6.GetComponent<FollowThePath>().waypointIndex -1;
        //     if ( player6.GetComponent<FollowThePath>().waypointIndex == 6) {
        //         player6.GetComponent<FollowThePath>().waypointIndex = 23;
        //     }
        //     if ( player6.GetComponent<FollowThePath>().waypointIndex == 11) {
        //         player6.GetComponent<FollowThePath>().waypointIndex = 36;
        //     }
        //     if ( player6.GetComponent<FollowThePath>().waypointIndex == 26) {
        //         player6.GetComponent<FollowThePath>().waypointIndex = 39;
        //     }

        //     if(Dice.DiceResult[1] == 6 && Dice.DiceResult[2] == 6 && Dice.DiceResult[3] == 6 && Dice.DiceResult[0] == 6){
                
        //     } else{
        //         // Dice.whosTurn = -1;
        //     }
        // }

        // //////////////////////////////////////               7번말 제어               //////////////////////////////////////////////////////

        // if(player7.GetComponent<FollowThePath>().waypointIndex > player7StartWaypoint + diceSideThrown)
        // {
        //     if(diceSideThrown == 0 && Dice.whatPlay == 0 && player7StartWaypoint == 0 ){
        //         player1MoveText.gameObject.SetActive(false);
        //         player5MoveText.gameObject.SetActive(true);
        //         player7.GetComponent<FollowThePath>().moveAllowed = false;
        //         player7.gameObject.SetActive(false);
        //     } else if( diceSideThrown > 0 && diceSideThrown < 6) {
        //         player7.GetComponent<FollowThePath>().moveAllowed = false;
        //         player5MoveText.gameObject.SetActive(false);
        //         player1MoveText.gameObject.SetActive(true);
        //     } else if( diceSideThrown >= 6) {
        //         player7.GetComponent<FollowThePath>().moveAllowed = false;
        //         player5MoveText.gameObject.SetActive(false);
        //         player1MoveText.gameObject.SetActive(true);
        //         diceSideThrown = 0;
        //     }

        //     //////////////////////////////////               말을 잡았을 경우           //////////////////////////////////////////////////////
        //     if(player7.GetComponent<FollowThePath>().waypointIndex == 43){
                
        //     } else if(player7.GetComponent<FollowThePath>().waypointIndex != 0) {
        //         if(player7.GetComponent<FollowThePath>().waypointIndex == player1.GetComponent<FollowThePath>().waypointIndex){
        //             Dice.whosTurn *= -1;
        //             player7.GetComponent<FollowThePath>().moveAllowed = false;
        //             player1.GetComponent<FollowThePath>().moveAllowed = true;
        //             player1.GetComponent<FollowThePath>().waypointIndex = 0;
        //             player1StartWaypoint = 0;
        //             diceSideThrown = 0;
        //             player5MoveText.gameObject.SetActive(true);
        //             player1MoveText.gameObject.SetActive(false);
        //             Dice.oneMore -= 1;
        //             if(Dice.oneMore <= 0){
        //                 Dice.oneMore = 0;
        //             }
        //         } 
        //         if(player7.GetComponent<FollowThePath>().waypointIndex == player2.GetComponent<FollowThePath>().waypointIndex){
        //             Dice.whosTurn *= -1;
        //             player7.GetComponent<FollowThePath>().moveAllowed = false;
        //             player2.GetComponent<FollowThePath>().moveAllowed = true;
        //             player2.GetComponent<FollowThePath>().waypointIndex = 0;
        //             player2StartWaypoint = 0;
        //             diceSideThrown = 0;
        //             player5MoveText.gameObject.SetActive(true);
        //             player1MoveText.gameObject.SetActive(false);
        //             Dice.oneMore -= 1;
        //             if(Dice.oneMore <= 0){
        //                 Dice.oneMore = 0;
        //             }
        //         } 
        //         if(player7.GetComponent<FollowThePath>().waypointIndex == player3.GetComponent<FollowThePath>().waypointIndex){
        //             Dice.whosTurn *= -1;
        //             player7.GetComponent<FollowThePath>().moveAllowed = false;
        //             player3.GetComponent<FollowThePath>().moveAllowed = true;
        //             player3.GetComponent<FollowThePath>().waypointIndex = 0;
        //             player3StartWaypoint = 0;
        //             diceSideThrown = 0;
        //             player5MoveText.gameObject.SetActive(true);
        //             player1MoveText.gameObject.SetActive(false);
        //             Dice.oneMore -= 1;
        //             if(Dice.oneMore <= 0){
        //                 Dice.oneMore = 0;
        //             }
        //         } 
        //         if(player7.GetComponent<FollowThePath>().waypointIndex == player4.GetComponent<FollowThePath>().waypointIndex){
        //             Dice.whosTurn *= -1;
        //             player7.GetComponent<FollowThePath>().moveAllowed = false;
        //             player4.GetComponent<FollowThePath>().moveAllowed = true;
        //             player4.GetComponent<FollowThePath>().waypointIndex = 0;
        //             player4StartWaypoint = 0;
        //             diceSideThrown = 0;
        //             player5MoveText.gameObject.SetActive(true);
        //             player1MoveText.gameObject.SetActive(false);
        //             Dice.oneMore -= 1;
        //             if(Dice.oneMore <= 0){
        //                 Dice.oneMore = 0;
        //             }
        //         } 
        //     }

        //     //////////////////////////////////               꼭지점을 밟았을 경우           /////////////////////////////////////////////////
        //     player7StartWaypoint = player7.GetComponent<FollowThePath>().waypointIndex -1;
        //     if ( player7.GetComponent<FollowThePath>().waypointIndex == 6) {
        //         player7.GetComponent<FollowThePath>().waypointIndex = 23;
        //     }
        //     if ( player7.GetComponent<FollowThePath>().waypointIndex == 11) {
        //         player7.GetComponent<FollowThePath>().waypointIndex = 36;
        //     }
        //     if ( player7.GetComponent<FollowThePath>().waypointIndex == 26) {
        //         player7.GetComponent<FollowThePath>().waypointIndex = 39;
        //     }

        //     if(Dice.DiceResult[1] == 6 && Dice.DiceResult[2] == 6 && Dice.DiceResult[3] == 6 && Dice.DiceResult[0] == 6){
                
        //     } else{
        //         // Dice.whosTurn = -1;
        //     }
        // }

        // //////////////////////////////////////               8번말 제어               //////////////////////////////////////////////////////

        // if(player8.GetComponent<FollowThePath>().waypointIndex > player8StartWaypoint + diceSideThrown)
        // {
        //     if(diceSideThrown == 0 && Dice.whatPlay == 0 && player8StartWaypoint == 0 ){
        //         player1MoveText.gameObject.SetActive(false);
        //         player5MoveText.gameObject.SetActive(true);
        //         player8.GetComponent<FollowThePath>().moveAllowed = false;
        //         player8.gameObject.SetActive(false);
        //     } else if( diceSideThrown > 0 && diceSideThrown < 6) {
        //         player8.GetComponent<FollowThePath>().moveAllowed = false;
        //         player5MoveText.gameObject.SetActive(false);
        //         player1MoveText.gameObject.SetActive(true);
        //     } else if( diceSideThrown >= 6) {
        //         player8.GetComponent<FollowThePath>().moveAllowed = false;
        //         player5MoveText.gameObject.SetActive(false);
        //         player1MoveText.gameObject.SetActive(true);
        //         diceSideThrown = 0;
        //     }

        //     //////////////////////////////////               말을 잡았을 경우           //////////////////////////////////////////////////////
        //     if(player8.GetComponent<FollowThePath>().waypointIndex == 43){
                
        //     } else if(player8.GetComponent<FollowThePath>().waypointIndex != 0) {
        //         if(player8.GetComponent<FollowThePath>().waypointIndex == player1.GetComponent<FollowThePath>().waypointIndex){
        //             Dice.whosTurn *= -1;
        //             player8.GetComponent<FollowThePath>().moveAllowed = false;
        //             player1.GetComponent<FollowThePath>().moveAllowed = true;
        //             player1.GetComponent<FollowThePath>().waypointIndex = 0;
        //             player1StartWaypoint = 0;
        //             diceSideThrown = 0;
        //             player5MoveText.gameObject.SetActive(true);
        //             player1MoveText.gameObject.SetActive(false);
        //             Dice.oneMore -= 1;
        //             if(Dice.oneMore <= 0){
        //                 Dice.oneMore = 0;
        //             }
        //         } 
        //         if(player8.GetComponent<FollowThePath>().waypointIndex == player2.GetComponent<FollowThePath>().waypointIndex){
        //             Dice.whosTurn *= -1;
        //             player8.GetComponent<FollowThePath>().moveAllowed = false;
        //             player2.GetComponent<FollowThePath>().moveAllowed = true;
        //             player2.GetComponent<FollowThePath>().waypointIndex = 0;
        //             player2StartWaypoint = 0;
        //             diceSideThrown = 0;
        //             player5MoveText.gameObject.SetActive(true);
        //             player1MoveText.gameObject.SetActive(false);
        //             Dice.oneMore -= 1;
        //             if(Dice.oneMore <= 0){
        //                 Dice.oneMore = 0;
        //             }
        //         } 
        //         if(player8.GetComponent<FollowThePath>().waypointIndex == player3.GetComponent<FollowThePath>().waypointIndex){
        //             Dice.whosTurn *= -1;
        //             player8.GetComponent<FollowThePath>().moveAllowed = false;
        //             player3.GetComponent<FollowThePath>().moveAllowed = true;
        //             player3.GetComponent<FollowThePath>().waypointIndex = 0;
        //             player3StartWaypoint = 0;
        //             diceSideThrown = 0;
        //             player5MoveText.gameObject.SetActive(true);
        //             player1MoveText.gameObject.SetActive(false);
        //             Dice.oneMore -= 1;
        //             if(Dice.oneMore <= 0){
        //                 Dice.oneMore = 0;
        //             }
        //         } 
        //         if(player8.GetComponent<FollowThePath>().waypointIndex == player4.GetComponent<FollowThePath>().waypointIndex){
        //             Dice.whosTurn *= -1;
        //             player8.GetComponent<FollowThePath>().moveAllowed = false;
        //             player4.GetComponent<FollowThePath>().moveAllowed = true;
        //             player4.GetComponent<FollowThePath>().waypointIndex = 0;
        //             player4StartWaypoint = 0;
        //             diceSideThrown = 0;
        //             player5MoveText.gameObject.SetActive(true);
        //             player1MoveText.gameObject.SetActive(false);
        //             Dice.oneMore -= 1;
        //             if(Dice.oneMore <= 0){
        //                 Dice.oneMore = 0;
        //             }
        //         } 
        //     }

        //     //////////////////////////////////               꼭지점을 밟았을 경우           /////////////////////////////////////////////////
        //     player8StartWaypoint = player8.GetComponent<FollowThePath>().waypointIndex -1;
        //     if ( player8.GetComponent<FollowThePath>().waypointIndex == 6) {
        //         player8.GetComponent<FollowThePath>().waypointIndex = 23;
        //     }
        //     if ( player8.GetComponent<FollowThePath>().waypointIndex == 11) {
        //         player8.GetComponent<FollowThePath>().waypointIndex = 36;
        //     }
        //     if ( player8.GetComponent<FollowThePath>().waypointIndex == 26) {
        //         player8.GetComponent<FollowThePath>().waypointIndex = 39;
        //     }

        //     if(Dice.DiceResult[1] == 6 && Dice.DiceResult[2] == 6 && Dice.DiceResult[3] == 6 && Dice.DiceResult[0] == 6){
                
        //     } else{
        //         // Dice.whosTurn = -1;
        //     }
        // }

        if(player1.GetComponent<FollowThePath>().waypointIndex == 43){
            player1.gameObject.SetActive(false);
        } 
        // if(player2.GetComponent<FollowThePath>().waypointIndex == 43){
        //     player2.gameObject.SetActive(false);
        // } 
        // if(player3.GetComponent<FollowThePath>().waypointIndex == 43){
        //     player3.gameObject.SetActive(false);
        // } 
        // if(player4.GetComponent<FollowThePath>().waypointIndex == 43){
        //     player4.gameObject.SetActive(false);
        // } 
        if(player5.GetComponent<FollowThePath>().waypointIndex == 43){
            player5.gameObject.SetActive(false);
        } 
        // if(player6.GetComponent<FollowThePath>().waypointIndex == 43){
        //     player6.gameObject.SetActive(false);
        // } 
        // if(player7.GetComponent<FollowThePath>().waypointIndex == 43){
        //     player7.gameObject.SetActive(false);
        // } 
        // if(player8.GetComponent<FollowThePath>().waypointIndex == 43){
        //     player8.gameObject.SetActive(false);
        // }

        if(player1.GetComponent<FollowThePath>().waypointIndex == 43 
        //     && player2.GetComponent<FollowThePath>().waypointIndex == 43 &&
        //    player3.GetComponent<FollowThePath>().waypointIndex == 43 && player4.GetComponent<FollowThePath>().waypointIndex == 43
           )
        {
            whoWinsTextShadow.gameObject.SetActive(true);
            // YutResult.gameObject.SetActive(false);
            whoWinsTextShadow.GetComponent<Text>().text = "Player 1 Wins";
            gameOver = true;
        }


        if(player5.GetComponent<FollowThePath>().waypointIndex == 43
        //     && player6.GetComponent<FollowThePath>().waypointIndex == 43 &&
        //    player7.GetComponent<FollowThePath>().waypointIndex == 43 && player8.GetComponent<FollowThePath>().waypointIndex == 43
           )
        {
            whoWinsTextShadow.gameObject.SetActive(true);
            // YutResult.gameObject.SetActive(false);
            whoWinsTextShadow.GetComponent<Text>().text = "Player 2 Wins";
            gameOver = true;
        }
    }

    public static void MovePlayer(int playerToMove)
    {
        switch (playerToMove)
        {
            case 1:
                player1.GetComponent<FollowThePath>().moveAllowed = true;
                break;
            // case 2:
            //     player2.GetComponent<FollowThePath>().moveAllowed = true;
            //     break;
            // case 3:
            //     player3.GetComponent<FollowThePath>().moveAllowed = true;
            //     break;
            // case 4:
            //     player4.GetComponent<FollowThePath>().moveAllowed = true;
            //     break;
            case 5:
                player5.GetComponent<FollowThePath>().moveAllowed = true;
                break;
            // case 6:
            //     player6.GetComponent<FollowThePath>().moveAllowed = true;
            //     break;
            // case 7:
            //     player7.GetComponent<FollowThePath>().moveAllowed = true;
            //     break;
            // case 8:
            //     player8.GetComponent<FollowThePath>().moveAllowed = true;
            //     break;

        }
    }

}