using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Piece : MonoBehaviour
{
    public NavMeshAgent agent;
    public bool isWhite;
    public bool isking;
    
    public int PrevX, PrevY, NextX, NextY;

    public Piece[,] checkPiece = new Piece[8, 8];

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        //Debug.Log(agent.destination);
    }
    
    public bool validMove(Piece[,] board, int x1, int y1, int x2, int y2)
    {
        // if you are moving on top of another piece 
        //  if (board[x2, y2] != null)
        //     return false;
        // UnityEngine.Debug.Log("offsettttttttttttttttttttttttttttttt " + gameObject.name + isWhite );
        int deltaMove = Mathf.Abs(x1 - x2);
        int deltaMoveY = y1 - y2;
        
        PrevX = x1;
        PrevY = y1;
        NextX = x2;
        NextY = y2;
        
        //Debug.Log(board[x2,y2]);
        checkPiece[NextX,NextY] = board[x2,y2];
        checkPiece[PrevX,PrevY] = board[x1,y1];
        //Debug.Log(checkPiece[NextX,NextY]);
        //CurrentX = x2;
        //Debug.Log(x2);
        //CurrentY = y2;
        //Debug.Log(y2);

        /*
        PositionX = x2;
        PositionY = y2;
        gameObject_name = gameObject.name;
        */

        //Debug.Log(x1);
        //Debug.Log(y1);
        //Debug.Log(x2);
        //Debug.Log(y2);

        // UnityEngine.Debug.Log("gggggggggggggggg"+ (deltaMove <= 7 )+ (ratio == 1 )+ (gameObject.name == "PAWN_SpartanKing (26)") + isWhite);


        // && (gameObject.name == "PAWN_SpartanKing(21)")
        /*      
                  if (isWhite && (gameObject.name == "PAWN_SpartanKing (20)"))
                  {

                  int maxmoveright = 8, maxmoveleft = -1, maxmoveup = 8, maxmovedown = -1;

                          for (int i1 = x1 + 1; i1 < 8; i1++)
                          {

                              if (board[i1, y1] != null)
                              {
                                  maxmoveright = i1;
                                  break;
                              }

                              maxmoveright = i1;

                          }
                          for (int i2 = x1 - 1; i2 >= 0; i2--)
                          {
                              if (board[i2, y1] != null)
                              {
                                  maxmoveleft = i2;
                                  break;
                              }
                              maxmoveleft = i2;
                          }

                          for (int i3 = y1 + 1; i3 < 8; i3++)
                          {
                              if (board[x1, i3] != null)
                              {
                                  maxmoveup = i3;
                                  break;
                              }
                              maxmoveup = i3;
                          }
                          for (int i4 = y1 - 1; i4 >= 0; i4--)
                          {
                              if (board[x1, i4] != null)
                              {
                                  maxmovedown = i4;
                                  break;
                              }
                              maxmovedown = i4;
                          }




                      if (x2 < maxmoveright || x2 > maxmoveleft || y2 < maxmoveup || y2 > maxmovedown)
                      {
                      //UnityEngine.Debug.Log("goooooooooooood result " );
                      //UnityEngine.Debug.Log(x1 + " " + x2);
                      //UnityEngine.Debug.Log(x2 + " " + maxmoveleft);
                      //UnityEngine.Debug.Log(x2 + " " + maxmoveright);
                      // UnityEngine.Debug.Log(y1 + " " + y2);
                      // UnityEngine.Debug.Log(y2 + " " + maxmoveup);
                      //      UnityEngine.Debug.Log(x2 + "x2  left " + maxmoveleft);
                        //UnityEngine.Debug.Log("great "+ (x2 < maxmoveright) + (x2 > maxmoveleft) + (y2 < maxmoveup) + (y2 > maxmovedown));
                      if ((x2 - x1) < 0)
                          {
                              if (x2 >= maxmoveleft)
                                  return true;

                          }
                          else if (((x2 - x1) > 0) )
                          {
                              if (x2 <= maxmoveright)
                                  return true;
                          }
                          else if ((y2 - y1 > 0) )
                          {
                              if (y2 <= maxmoveup)
                                  return true;
                          }
                          else if ((y2 - y1 < 0) )
                          {
                              if (y2 >= maxmovedown)
                                  return true;
                          }
                          else
                          {
                              return false;
                          }

                      }
                      else
                      {
                          return false;
                      }
                  }





                  */


        if ((isWhite || !isWhite) && ((gameObject.name == "eROOK_monster_orc (1)") || (gameObject.name == "eROOK_monster_orc (1)") || ( gameObject.name == "ROOK_ToonRTS_demo_Knight (1)") || (gameObject.name == "ROOK_ToonRTS_demo_Knight (2)") || ((gameObject.name == "QUEEN_A03") && ((y1 == y2) || (x1 == x2))) || ((gameObject.name == "eQUEEN_Spider_Queen") && ((y1 == y2) || (x1 == x2)))))
        {
            int maxmoveright = 8, maxmoveleft = -1, maxmoveup = 8, maxmovedown = -1;
            //UnityEngine.Debug.Log("111111111111111111111111111111111111111 ");
            if (y1 == y2)
            {
                //UnityEngine.Debug.Log("222222222222222222222222222222222 ");
                for (int i1 = x1 + 1; i1 < 8; i1++)
                {
                    //UnityEngine.Debug.Log("  out i1  " + i1 + " y1  " + y1);
                    if (board[i1, y1] != null)
                    {
                        //UnityEngine.Debug.Log("i1  " + i1 + " y1 " + y1 + "             " + board[i1, y1]);
                        maxmoveright = i1;
                        break;
                    }

                    maxmoveright = i1;

                }
                for (int i2 = x1 - 1; i2 >= 0; i2--)
                {
                    if (board[i2, y1] != null)
                    {
                        maxmoveleft = i2;
                        break;
                    }
                    maxmoveleft = i2;
                }

            }
            else if (x1 == x2)
            {
                for (int i3 = y1 + 1; i3 < 8; i3++)
                {
                    if (board[x1, i3] != null)
                    {
                        maxmoveup = i3;
                        break;
                    }
                    maxmoveup = i3;
                }
                for (int i4 = y1 - 1; i4 >= 0; i4--)
                {
                    if (board[x1, i4] != null)
                    {
                        maxmovedown = i4;
                        break;
                    }
                    maxmovedown = i4;
                }

            }


            if (x2 < maxmoveright || x2 > maxmoveleft || y2 < maxmoveup || y2 > maxmovedown)
            {
                /*
                UnityEngine.Debug.Log(x1 + " " + x2);
                UnityEngine.Debug.Log(x2 + " " + maxmoveleft);
                UnityEngine.Debug.Log(x2 + " " + maxmoveright);
                UnityEngine.Debug.Log(y1 + " " + y2);
                UnityEngine.Debug.Log(y2 + " " + maxmoveup);
                UnityEngine.Debug.Log(x2 + "x2  left " + maxmoveleft);
                UnityEngine.Debug.Log("great " + (x2 < maxmoveright) + (x2 > maxmoveleft) + (y2 < maxmoveup) + (y2 > maxmovedown));
                */
                if ((x2 - x1) < 0 && y1 == y2)
                {
                    if (x2 >= maxmoveleft)
                        return true;

                }
                else if (((x2 - x1) > 0) && y1 == y2)
                {
                    if (x2 <= maxmoveright)
                        return true;
                }
                else if ((y2 - y1 > 0) && x1 == x2)
                {
                    if (y2 <= maxmoveup)
                        return true;
                }
                else if ((y2 - y1 < 0) && x1 == x2)
                {
                    if (y2 >= maxmovedown)
                        return true;
                }
                else
                {
                    //UnityEngine.Debug.Log("333333333333333333333333333333333333333 ");
                    return false;

                }

            }
            else
            {
                //UnityEngine.Debug.Log("444444444444444444444444444444444 ");
                return false;
            }
        }

        if (isWhite && (gameObject.name == "PAWN_arthur_01 (1)" || gameObject.name == "PAWN_arthur_01 (2)" || gameObject.name == "PAWN_arthur_01 (3)" || gameObject.name == "PAWN_arthur_01 (4)" || gameObject.name == "PAWN_arthur_01 (5)" || gameObject.name == "PAWN_arthur_01 (6)" || gameObject.name == "PAWN_arthur_01 (7)" || gameObject.name == "PAWN_arthur_01 (8)"))
        {
            if (deltaMove == 0)
            {
                if (deltaMoveY == 1)
                {
                    if (board[x2, y2] == null)
                        return true;
                }


            }
            if (deltaMove == 0 && y1 == 6)
            {
                if (deltaMoveY == 2)
                {
                    if (board[x2, y2] == null)
                        return true;
                }


            }

        }
        if (!isWhite && (gameObject.name == "PAWN_GOBLIN (8)" || gameObject.name == "PAWN_GOBLIN (1)" || gameObject.name == "PAWN_GOBLIN (2)" || gameObject.name == "PAWN_GOBLIN (3)" || gameObject.name == "PAWN_GOBLIN (4)" || gameObject.name == "PAWN_GOBLIN (5)" || gameObject.name == "PAWN_GOBLIN (6)" || gameObject.name == "PAWN_GOBLIN (7)" ))
        {
            if (deltaMove == 0)
            {
                if (deltaMoveY == -1)
                {
                    if (board[x2, y2] == null)
                        return true;
                }
            }
            if (deltaMove == 0 && y1 == 1)
            {
                if (deltaMoveY == -2)
                {
                    if (board[x2, y2] == null)
                        return true;
                }


            }

        }
        if (deltaMove <= 7 && ((gameObject.name == "eBISHOP_Ch40_nonPBR (1)" || gameObject.name == "eBISHOP_Ch40_nonPBR (2)" || gameObject.name == "BISHOP_uriel_a_plotexia (1)" || gameObject.name == "BISHOP_uriel_a_plotexia (2)")  || (gameObject.name == "QUEEN_A03") || (gameObject.name == "eQUEEN_Spider_Queen")))
        {
            //int ratio = Mathf.Abs(deltaMove / deltaMoveY);&& isWhite
            int j1 = y1, j2 = y1, j3 = x1, j4 = x1;
            //UnityEngine.Debug.Log("vvvvvvvvvvvvvvvvvvvvvv" + deltaMoveY + "          " + deltaMove);
            if (deltaMoveY != 0)
                if ((Mathf.Abs(((float)deltaMove / (float)deltaMoveY)) == 1))
                {
                    //  UnityEngine.Debug.Log("passsssssssssssssssssssssssss" );
                    //  UnityEngine.Debug.Log("pppppppppppppppppppp" + deltaMoveY + "          " + deltaMove);
                    //   UnityEngine.Debug.Log("ratiooooooooooooo" + Mathf.Abs((float)deltaMove / (float)deltaMoveY) + "    " + ((float)deltaMove / (float)deltaMoveY));
                    if (deltaMoveY <= 7)
                    {

                        //UnityEngine.Debug.Log("great");

                        int maxmoveright1 = 8, maxmoveUP1 = 8, maxmoveleft2 = 0, maxmoveDOWN2 = 0;
                        int maxmoveup3 = 8, maxmoveLEFT3 = 0, maxmovedown4 = 0, maxmoveRIGHT4 = 8;
                        for (int i5 = x1 + 1; i5 <= 8; i5++)
                        {
                            //UnityEngine.Debug.Log("great"+ j1);
                            j1++;
                            if (j1 > 8)
                                break;
                            if (j1 < 8 && i5 < 8)
                            {

                                if (board[i5, j1] != null)
                                {
                                    maxmoveright1 = i5;
                                    maxmoveUP1 = j1;
                                    break;
                                }
                            }
                            maxmoveright1 = i5;
                            maxmoveUP1 = j1;
                        }
                        for (int i6 = x1 - 1; i6 >= -1; i6--)
                        {
                            j2--;
                            if (j2 < -1)
                                break;
                            if (j2 >= 0 && i6 > -1)
                            {

                                if (board[i6, j2] != null)
                                {

                                    maxmoveleft2 = i6;
                                    maxmoveDOWN2 = j2;
                                    break;
                                }
                            }
                            maxmoveleft2 = i6;
                            maxmoveDOWN2 = j2;
                        }
                        for (int i7 = y1 + 1; i7 <= 8; i7++)
                        {

                            j3--;
                            if (j3 < -1)
                                break;
                            if (j3 >= 0 && i7 < 8)
                            {

                                if (board[j3, i7] != null)
                                {
                                    maxmoveup3 = i7;
                                    maxmoveLEFT3 = j3;
                                    break;
                                }
                            }
                            maxmoveup3 = i7;
                            maxmoveLEFT3 = j3;
                        }
                        for (int i8 = y1 - 1; i8 >= -1; i8--)
                        {
                            //UnityEngine.Debug.Log("y1  " + (i8 + 1));
                            j4++;
                            //UnityEngine.Debug.Log("x1  " + (j4 - 1));
                            if (j4 > 8)
                                break;
                            if (j4 < 8 && i8 > -1)
                            {

                                if (board[j4, i8] != null)
                                {
                                    //UnityEngine.Debug.Log("nooooooooooooot   " + i8 + " " + j4);
                                    maxmovedown4 = i8;
                                    maxmoveRIGHT4 = j4;
                                    break;
                                }
                            }
                            maxmovedown4 = i8;
                            maxmoveRIGHT4 = j4;
                        }
                        /*
                        UnityEngine.Debug.Log(maxmoveright1 + "right   up " + maxmoveUP1);
                        UnityEngine.Debug.Log(maxmoveleft2 + " left     down " + maxmoveDOWN2);
                        UnityEngine.Debug.Log(maxmoveup3 + "   up        left " + maxmoveLEFT3);
                        UnityEngine.Debug.Log(maxmovedown4 + " down     right " + maxmoveRIGHT4);
                        */
                        if ((x2 - x1) > 0 && (y2 - y1 > 0))
                        {
                            if (x2 <= maxmoveright1 && y2 <= maxmoveUP1)
                                return true;

                        }
                        else if ((x2 - x1) < 0 && (y2 - y1 < 0))
                        {
                            if (x2 >= maxmoveleft2 && y2 >= maxmoveDOWN2)
                                return true;
                        }
                        else if (((x2 - x1) > 0) && (y2 - y1 < 0))
                        {
                            if (x2 <= maxmoveRIGHT4 && y2 >= maxmovedown4)
                                return true;
                        }
                        else if (((x2 - x1) < 0) && ((y2 - y1) > 0))
                        {
                            if (x2 >= maxmoveLEFT3 && y2 <= maxmoveup3)
                                return true;
                        }
                        else
                        {
                            return false;
                        }

                    }

                }
        }

        if (deltaMove == 1 && (gameObject.name == "PAWN_arthur_01 (1)" || gameObject.name == "PAWN_arthur_01 (2)" || gameObject.name == "PAWN_arthur_01 (3)" || gameObject.name == "PAWN_arthur_01 (4)" || gameObject.name == "PAWN_arthur_01 (5)" || gameObject.name == "PAWN_arthur_01 (6)" || gameObject.name == "PAWN_arthur_01 (7)" || gameObject.name == "PAWN_arthur_01 (8)" || gameObject.name == "PAWN_GOBLIN (8)" || gameObject.name == "PAWN_GOBLIN (1)" || gameObject.name == "PAWN_GOBLIN (2)" || gameObject.name == "PAWN_GOBLIN (3)" || gameObject.name == "PAWN_GOBLIN (4)" || gameObject.name == "PAWN_GOBLIN (5)" || gameObject.name == "PAWN_GOBLIN (6)" || gameObject.name == "PAWN_GOBLIN (7)"))
        {
            if (deltaMoveY == 1 && isWhite)
            {
                if (board[x2, y2] != null && !board[x2, y2].isWhite)
                    return true;


            }
            if (deltaMoveY == -1 && !isWhite)
            {
                if (board[x2, y2] != null && board[x2, y2].isWhite)
                    return true;


            }
        }


        /*
         if (!isWhite || isking)
         {
             if (deltaMove == 1)
             {
                 if (deltaMoveY == -1)
                     return true;
             }
             else if (deltaMove == 2)
             {
                 if (deltaMoveY == -2)
                 {
                     Piece p = board[(x1 + x2) / 2, (y1 + y2) / 2];
                     if (p != null && p.isWhite != isWhite)
                         return true;
                 }
             }
         }*/
        //if (isWhite && (gameObject.name == "eHORSE_Orc_Wolfrider" || gameObject.name == "eHORSE_Orc_Wolfrider (1)" || gameObject.name == "HORSE_Centaur_Unity (2)" || gameObject.name == "HORSE_Centaur_Unity (3)"))
        if ((gameObject.name == "eHORSE_Orc_Wolfrider" || gameObject.name == "eHORSE_Orc_Wolfrider (1)" || gameObject.name == "HORSE_Centaur_Unity (2)" || gameObject.name == "HORSE_Centaur_Unity (3)"))
        {
            if (x2 < 8 && x2 > -1)
            {
                if (y2 < 8 && y2 > -1)
                {
                    if (Mathf.Abs(x1 - x2) == 2 || Mathf.Abs(y1 - y2) == 2)
                    {
                        if (Mathf.Abs(x1 - x2) == 2 && Mathf.Abs(y1 - y2) == 1)
                        {
                            return true;
                        }
                        if (Mathf.Abs(y1 - y2) == 2 && Mathf.Abs(x1 - x2) == 1)
                        {
                            return true;
                        }
                    }
                }
            }
        }
        if ((isWhite || !isWhite) && (gameObject.name == "KING_arthur_01" || gameObject.name == "eKING_MK_Demo"))
        {
            if (x2 < 8 && x2 > -1)
            {
                if (y2 < 8 && y2 > -1)
                {
                    if (Mathf.Abs(x1 - x2) == 1 && Mathf.Abs(y1 - y2) == 1)
                    {
                        return true;
                    }
                    if (Mathf.Abs(x1 - x2) == 1 && Mathf.Abs(y1 - y2) == 0)
                    {
                        return true;
                    }
                    if (Mathf.Abs(x1 - x2) == 0 && Mathf.Abs(y1 - y2) == 1)
                    {
                        return true;
                    }



                }
            }
        }
        
        return false;

    }



}
