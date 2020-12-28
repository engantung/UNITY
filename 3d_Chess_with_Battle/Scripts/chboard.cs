using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using UnityEngine;

public class chboard : MonoBehaviour
{
    List<int> possiblemovesX = new List<int>();
    List<int> possiblemovesY = new List<int>();
    // Start is called before the first frame update
    public Piece[,] piece = new Piece[8, 8];
    public GameObject target;
    public GameObject whitePiecePrefab;
    public GameObject blackPiecePrefab;
    public GameObject[] go;
    public GameObject[] xx;
    public Vector3 board, board2;
    private int WPAWN = 10;
    private int BPAWN = -10;
    private int WKNIGHT = 30;
    private int BKNIGHT = -30;
    private int WBISHOP = 30;
    private int BBISHOP = -30;
    private int WROOK = 50;
    private int BROOK = -50;
    private int WQUEEN = 90;
    private int BQUEEN = -90;
    private int WKING = 900;
    private int BKING = -900;

    private bool iswhite;
    private bool iswhiteTurn;
    public Piece selectedPiece;
    private Vector2 mouseOver;
    private Vector2 startDrag;
    private Vector2 endDrag;
    bool turn;
    bool turnwithclick;
    bool wehavewiner;
    //public Animation pAnimation;
    //public AnimationClip pdie;

    
    private void Start()
    {
        board = new Vector3(0.47f, 0, 1.39f);
        board2 = new Vector3(0.47f, 0, 6.42f);
        iswhiteTurn = true;
        turn = true;
        turnwithclick = true;
        wehavewiner = false;
        
        // UnityEngine.Debug.Log("offset " + board);
        GenerateBoard();
    }
    private void Update()
    {
        //Piece[,] point = piece;

        if (!wehavewiner)
        { 
        UpdateMouseOver();
        //UnityEngine.Debug.Log(mouseOver);
        // if it is my turn
        {
                
            int x = (int)mouseOver.x;
            int y = (int)mouseOver.y;

           // Piece[,] point = piece;
                
            if (selectedPiece != null)
                UpdatePieceDrag(selectedPiece);

            if (Input.GetMouseButtonDown(0))
            {
                    //     point[0,0] = null;
                    //   UnityEngine.Debug.Log("hhhhhhhhhhhhhhhhhhhhhhhh " + point[0,0] +" hola  "+ piece[0,0] + " null"+ null);
                    if (piece[x, y] != null)
                    {
                        if (piece[x, y].isWhite && turn == true)
                        {
                            SelectPiece(x, y);
                            //  turn = false;
                        }

                        if (!piece[x, y].isWhite && turn == false)
                        {
                            SelectPiece(x, y);
                            //  turn = true;

                        }
                    }

              //  UnityEngine.Debug.Log("hhhhhhhhhhhhhhhhhhhhhhhh     "   );
                //MoveGeneration(x, y)[0].ForEach(Console.WriteLine);
                // MoveGeneration(x, y)[1].ForEach(Console.WriteLine);


                    /*
                List<int>[] valimoves = new List<int>[3];
                 Piece[,] copy = piece.Clone() as Piece[,];
                    copy[1, 2] = copy[1, 1];
                    copy[1, 1] = null;
                    valimoves = MoveGeneration(1, 2, copy);
                    if (valimoves != null) { 
                     foreach (var h in valimoves[0])
                     {
                        UnityEngine.Debug.Log("cooooooooooool      "+h);
                     }
                     foreach (var k in valimoves[1])
                     {
                        UnityEngine.Debug.Log("cooooooooooool      " + k);
                     }
                    }
                    else
                    {
                        UnityEngine.Debug.Log("is nullllllllllll   " );
                    }
                    */
                }
            if (Input.GetMouseButtonUp(0))
            {
                TryMove((int)startDrag.x, (int)startDrag.y, x, y);

                }

        }

        if (Input.GetMouseButtonDown(1))
        {

               
                UnityEngine.Debug.Log("1111111111111 ");
                int[] nextmove = new int[5];
                nextmove = movement(turnwithclick);
                UnityEngine.Debug.Log(" result" + nextmove[0] +"    "+ nextmove[1]+"   " + nextmove[2]+"    " + nextmove[3]);
              if(nextmove[4] < 0  || nextmove[4] > 0)
                {
                    if (turnwithclick == true)
                    { TryMove(nextmove[0], nextmove[1], nextmove[2], nextmove[3]); }else
                    {
                        UnityEngine.Debug.Log("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa ");
                        TryMove(nextmove[0], nextmove[1], nextmove[2], nextmove[3]);
                    }
                       
                }
                else
                {
                    if (turnwithclick == true)
                    {
                        checkpieces(turn);
                        //  turn = false;
                        // UnityEngine.Debug.Log("dammmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm      ");

                    }
                    if (turnwithclick == false)
                    {
                        checkpieces(turn);
                        //  turn = true;
                        // UnityEngine.Debug.Log("whatttttttttttttttttttttttttttttttttttttttttt     ");
                    }


                }
              /*
               
                if (turnwithclick == true)
                {
                    checkpieces(turn);
                    //  turn = false;
                    // UnityEngine.Debug.Log("dammmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm      ");

                }
                if (turnwithclick == false)
                {
                    checkpieces(turn);
                    //  turn = true;
                    // UnityEngine.Debug.Log("whatttttttttttttttttttttttttttttttttttttttttt     ");
                }
               
                */




                if (turnwithclick == true)
            {
                turnwithclick = false;
            }
            else
            {
                turnwithclick = true;
            }

            
            // UnityEngine.Debug.Log("hhhhhhhhhhhhhhhhhhhhhhhh " + point );
            
            }

        }
    }
    private List<int>[] MoveGeneration(int x, int y, Piece[,] pie)
    {
        if (pie[x, y] == null)
        {
            UnityEngine.Debug.Log("P is null ");
            return null;
        }
            
        Piece selected = pie[x, y];
        List<int>[] kkkk = new List<int>[3];

       // List<int>  movecost = new List<int>;

        List<int> movecost = new List<int>();
        movecost.Clear();

        kkkk[0] = new List<int>();
        kkkk[1] = new List<int>();
        kkkk[2] = new List<int>();
        kkkk[0].Clear();
        kkkk[1].Clear();
        kkkk[2].Clear();

        if (selected != null)
        {
            
            for (int r = 0; r < 8; r++)
            {
                
                for (int c = 0; c < 8; c++)
                {

                    // UnityEngine.Debug.Log("selested not null x " + x + "   y" + y);
                   // UnityEngine.Debug.Log("selested not null r " + r + "   c"+ c );
                        
                        if (pie[r, c] == null)
                        {
                        if (selected.validMove(pie, x, y, r, c) && selected.isWhite == true)
                        {
                           // UnityEngine.Debug.Log("valid moves     ");
                            kkkk[0].Add(r);
                            kkkk[1].Add(c);
                            kkkk[2].Add(0);
                        }
                        if (selected.validMove(pie, x, y, r, c) && selected.isWhite == false)
                        {
                            // UnityEngine.Debug.Log("valid moves     ");
                            kkkk[0].Add(r);
                            kkkk[1].Add(c);
                            kkkk[2].Add(0);
                        }
                    }
                    else if(pie[r, c] != null)
                    {
                        Piece p = pie[r, c];
                        //UnityEngine.Debug.Log("valid moves     "+ p);
                        if (p.isWhite != selected.isWhite)
                            if (selected.validMove(pie, x, y, r, c))
                            {
                              //  UnityEngine.Debug.Log("valid moves     ");
                                kkkk[0].Add(r);
                                kkkk[1].Add(c);
                                if( p.name == "PAWN_arthur_01 (1)" || p.name == "PAWN_arthur_01 (2)" || p.name == "PAWN_arthur_01 (3)" || p.name == "PAWN_arthur_01 (4)" || p.name == "PAWN_arthur_01 (5)" || p.name == "PAWN_arthur_01 (6)" || p.name == "PAWN_arthur_01 (7)" || p.name == "PAWN_arthur_01 (8)" || p.name == "PAWN_GOBLIN (1)" || p.name == "PAWN_GOBLIN (2)" || p.name == "PAWN_GOBLIN (3)" || p.name == "PAWN_GOBLIN (4)" || p.name == "PAWN_GOBLIN (5)" || p.name == "PAWN_GOBLIN (6)" || p.name == "PAWN_GOBLIN (7)" || p.name == "PAWN_GOBLIN (8)")
                                {
                                    if (selected.isWhite == true)
                                        kkkk[2].Add(-10);

                                    if(selected.isWhite == false)
                                        kkkk[2].Add(10);

                                }
                                if((p.name == "eROOK_monster_orc (1)") || (p.name == "eROOK_monster_orc (2)") || (p.name == "ROOK_ToonRTS_demo_Knight (1)") || (p.name == "ROOK_ToonRTS_demo_Knight (2)"))
                                {
                                    if (selected.isWhite == true)
                                        kkkk[2].Add(-50);

                                    if (selected.isWhite == false)
                                        kkkk[2].Add(50);
                                }
                                if(p.name == "BISHOP_uriel_a_plotexia (1)" || p.name == "BISHOP_uriel_a_plotexia (2)" || p.name == "eBISHOP_Ch40_nonPBR (1)" || p.name == "eBISHOP_Ch40_nonPBR (2)" )
                                {
                                    if (selected.isWhite == true)
                                        kkkk[2].Add(-30);

                                    if (selected.isWhite == false)
                                        kkkk[2].Add(30);
                                }
                                if( (p.name == "QUEEN_A03") || (p.name == "eQUEEN_Spider_Queen"))
                                {
                                    if (selected.isWhite == true)
                                        kkkk[2].Add(-90);

                                    if (selected.isWhite == false)
                                        kkkk[2].Add(90);
                                }
                                if(p.name == "eHORSE_Orc_Wolfrider" || p.name == "eHORSE_Orc_Wolfrider (1)" || p.name == "HORSE_Centaur_Unity (2)" || p.name == "HORSE_Centaur_Unity (3)")
                                {
                                    if (selected.isWhite == true)
                                        kkkk[2].Add(-30);

                                    if (selected.isWhite == false)
                                        kkkk[2].Add(30);
                                }
                                if(p.name == "KING_arthur_01" || p.name == "eKING_MK_Demo")
                                {
                                    if (selected.isWhite == true)
                                        kkkk[2].Add(-900);

                                    if (selected.isWhite == false)
                                        kkkk[2].Add(900);
                                }
                            }

                    }
                        
                        
                        


                }
            }
           /* if (kkkk[0].Count()==0 && kkkk[1].Count()==0 && kkkk[2].Count()==0)
            { return null; }*/
            return kkkk;
        }
        return null;
    }
            
        private void checkpieces(bool turn)
        {
                   
                  // List<int>[] possib = new List<int>()[2];
                 //  List<int> piecesMW = new List<int>();
                 //  List<int> piecesME = new List<int>();
        List<int>[,] validddmoves = new List<int>[2,16];
        // List<int> piecesMW = new List<int>();
        List<int[]> arrayList0 = new List<int[]>();
        List<int[]> arrayList1 = new List<int[]>();
        List<int[]> arrayList2 = new List<int[]>();
        List<int[]> arrayList3 = new List<int[]>();

        List<int> moveEvaluationW = new List<int>();
        List<int> moveEvaluationB = new List<int>();

        int[] pp = new int[2];
        // int y = Random.Range(0, 8);
        List<List<int>[]> data = new List<List<int>[]>();
        List<List<int>[]> data2 = new List<List<int>[]>();
        int x = 0;
            for(int w=0; w<8; w++)
            {
            for(int k=0;k<8;k++)
            {
                if(piece[w,k] !=null)
                {
                    if(piece[w,k].isWhite == true)
                    {
                        if (MoveGeneration(w, k, piece)[0].Any())
                        {
                            data.Add(MoveGeneration(w, k, piece));
                            pp[0] = w;
                            pp[1] = k;
                            arrayList0.Add(new int[] { w, k });
                        }
                    }
                    if(piece[w, k].isWhite == false)
                    {
                        if (MoveGeneration(w, k, piece)[0].Any()) {
                        data2.Add(MoveGeneration(w, k, piece));
                        pp[0] = w;
                        pp[1] = k;
                        arrayList1.Add(new int[] { w, k });
                        }
                    }

                    
                }

            }

        }
        pp[0] = 5;
        pp[1] = 2;
        //    UnityEngine.Debug.Log(" w  " + arrayList0[5][0] + "  k " +arrayList0[5][1]);
        /* int m = 0;

         foreach (var s in data)
         {
             UnityEngine.Debug.Log("the piece      " + s[0].Any() +"  " + s[1].Any()+" piece location x"+ arrayList0[m][0] + " y "+ arrayList0[m][1] +"      m "+ m);
             foreach (var n1 in s[0])
             { UnityEngine.Debug.Log("posible moves of x axes      " + n1); }
             foreach (var n2 in s[1])
             { UnityEngine.Debug.Log("posible moves of y axes      " + n2); }
             foreach (var n3 in s[2])
             { UnityEngine.Debug.Log("cosssssssssssssst     " + n3); }
             m++;
         }
         */
        foreach (var l in arrayList0)
        {
         //   UnityEngine.Debug.Log("  xxxx   " + l[0] + "     yyyyy  "+ l[0]);
        }
      //   UnityEngine.Debug.Log("  xxxx   " + data.Count() + "     yyyyy  " + data2.Count());

        List<int>[] possib = new List<int>[3];
        List<int>[] possib2 = new List<int>[3];
        Piece[,] copy = piece.Clone() as Piece[,];
        int z = Random.Range(0, data.Count());
        int f = Random.Range(0, data2.Count());
        int[] max = new int[3];
        
        max = AminimaxAlphabeta(new int[] { 1, 1,0 }, new int[] { 1, 6, 0 }, 2, -99999, +99999, false, copy);
        UnityEngine.Debug.Log("  maxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  " + max[2] + max[0]+ max[1]);
        int[] result = new int[2];
        result = calculateboard(piece);
        UnityEngine.Debug.Log("  maxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  " + result[0] +"    "+ result[1]);




        //  UnityEngine.Debug.Log(z+"   "+f);
        if (arrayList0.Count() != null && turn== true)
         {
            possib = data[z];
            int pppp = Random.Range(0, possib[0].Count());
            TryMove(arrayList0[z][0], arrayList0[z][1], possib[0][pppp], possib[1][pppp]);

         }

        if (arrayList1.Count() != null && turn == false)
        {
           
            possib2 = data2[f];
            int ss = Random.Range(0, possib2[0].Count());
            TryMove(arrayList1[f][0], arrayList1[f][1], possib2[0][ss], possib2[1][ss]);
           // UnityEngine.Debug.Log("coooooooooooooooooooooooooooooooooooooooooooooool  "+arrayList1[f][0] + arrayList1[f][1]+ possib2[0][ss]+ possib2[1][ss]);
        }


        /*  if (piece[x,y] != null)
           {
              possib= MoveGeneration(Piece p, int x, int y)
                 if(possib[0].Count != 0)
                   {
                     int d= Random.Range(0, possib[0].Count);
                     TryMove(x, y, possib(d)[0], possib(d)[1]);

                   }
           }*/

    }
    public int[] calculateboard(Piece[,] pieces)
    {
        List<int>[] calcu = new List<int>[2];
        int[] sum = new int[2];
        calcu[0] = new List<int>();
        calcu[1] = new List<int>();
        calcu[0].Clear();
        calcu[1].Clear();

        for (int a = 0; a < 8; a++)
        {
            for (int b = 0; b < 8; b++)
            {

                Piece po = pieces[a, b];

                if (po != null)
                {
                    //  UnityEngine.Debug.Log("valid moves     ");
                    if (po.name == "PAWN_SpartanKing (12)" || po.name == "PAWN_SpartanKing (13)" || po.name == "PAWN_SpartanKing (16)" || po.name == "PAWN_SpartanKing (15)" || po.name == "PAWN_SpartanKing (17)" || po.name == "PAWN_SpartanKing (18)" || po.name == "PAWN_SpartanKing (14)" || po.name == "PAWN_SpartanKing (19)" || po.name == "ePAWN_UD_demo_character" || po.name == "ePAWN_UD_demo_character (1)" || po.name == "ePAWN_UD_demo_character (2)" || po.name == "ePAWN_UD_demo_character (3)" || po.name == "ePAWN_UD_demo_character (4)" || po.name == "ePAWN_UD_demo_character (5)" || po.name == "ePAWN_UD_demo_character (6)" || po.name == "ePAWN_UD_demo_character (7)")
                    {
                        if (po.isWhite == true)
                            calcu[0].Add(-10);

                        if (po.isWhite == false)
                            calcu[1].Add(10);

                    }
                    if ((po.name == "eROOK_HP_Golem") || (po.name == "eROOK_HP_Golem (1)") || (po.name == "ROOK_paladin (2)") || (po.name == "ROOK_paladin (3)"))
                    {
                        if (po.isWhite == true)
                            calcu[0].Add(-50);

                        if (po.isWhite == false)
                            calcu[1].Add(50);
                    }
                    if (po.name == "eBISHOP_demon_t_wiezzorek (1)" || po.name == "eBISHOP_demon_t_wiezzorek" || po.name == "BISHOP_Ch39_nonPBR (1)" || po.name == "BISHOP_Ch39_nonPBR (2)")
                    {
                        if (po.isWhite == true)
                            calcu[0].Add(-30);

                        if (po.isWhite == false)
                            calcu[1].Add(30);
                    }
                    if ((po.name == "QUEEN_A03") || (po.name == "eQUEEN_Spider_Queen"))
                    {
                        if (po.isWhite == true)
                            calcu[0].Add(-90);

                        if (po.isWhite == false)
                            calcu[1].Add(90);
                    }
                    if (po.name == "eHORSE_Orc_Wolfrider" || po.name == "eHORSE_Orc_Wolfrider (1)" || po.name == "HORSE_Centaur_Unity (2)" || po.name == "HORSE_Centaur_Unity (3)")
                    {
                        if (po.isWhite == true)
                            calcu[0].Add(-30);

                        if (po.isWhite == false)
                            calcu[1].Add(30);
                    }
                    if (po.name == "KING_arthur_01" || po.name == "eKING_MK_Demo")
                    {
                        if (po.isWhite == true)
                            calcu[0].Add(-900);

                        if (po.isWhite == false)
                            calcu[1].Add(900);
                    }
                }
            }

        }
        sum[0]=  calcu[0].Sum();
        sum[1] = calcu[1].Sum();
        return sum;
    }

    private int[] AminimaxAlphabeta(int[] position, int[] position2, int depth, int alpha, int beta, bool maximizingPlayer, Piece[,] point)
    {

        //= new int[2]
        //Piece p = piece[x2, y2];
        //piece[x2, y2] = piece[x1, y1];
        //piece[x1, y1] = null;
        List<int>[] vmoves = new List<int>[3];
        List<int>[] vmoves2 = new List<int>[3];
        vmoves = MoveGeneration(position[0], position[1], point);
        vmoves2 = MoveGeneration(position2[0], position2[1], point);
       // int[] res = new int[2];
       // res = calculateboard(point);
        //UnityEngine.Debug.Log("vmoves "+ vmoves[2][0]);
        // UnityEngine.Debug.Log("vmoves2 "+ position2[0]+ position2[1]+ point);
        if (vmoves == null || vmoves[1].Any() == false)
        {
         //   UnityEngine.Debug.Log("  vmoves is null ");
            if(maximizingPlayer == false)
            {
                return position;
            }
            else
            {
                return position2;
            }
            
        }
        if(vmoves2 == null || vmoves2[1].Any() == false)
        {
           // UnityEngine.Debug.Log("vmoves2  is null ");
            if (maximizingPlayer == false)
            {
                return position;
            }
            else
            {
                return position2;
            }
        }
        

        if (vmoves[2] == null)
        {
            return position;
        }
        
        /*
        UnityEngine.Debug.Log("vmoves2 and vmoves is null "+ vmoves[2].Any());

        if (vmoves[2].Any() == false)
        {
            return position[2];
        }
        if (vmoves2[2].Any() == false)
        {
            return position2[2];
        }*/
        /*
        if (position[0] == 1 && position[1] == 2 && position2[0] == 1 && position2[1] == 5)
        {
            //  UnityEngine.Debug.Log("the piece      " + s[0].Any() + "  " + s[1].Any() + " piece location x" + arrayList0[m][0] + " y " + arrayList0[m][1] + "      m " + m);
            foreach (var n1 in vmoves[0])
            { UnityEngine.Debug.Log("vmoves of x axes      " + n1); }
            foreach (var n2 in vmoves[1])
            { UnityEngine.Debug.Log("vmoves of y axes      " + n2); }
            foreach (var n3 in vmoves[2])
            { UnityEngine.Debug.Log("cosssssssssssssst vmoves     " + n3); }

            foreach (var n3 in vmoves2[0])
            { UnityEngine.Debug.Log("vmoves2 of x axes      " + n3); }
            foreach (var n4 in vmoves2[1])
            { UnityEngine.Debug.Log("vmoves2 of y axes      " + n4); }
            foreach (var n5 in vmoves2[2])
            { UnityEngine.Debug.Log("cosssssssssssssst vmoves2  " + n5); }
        }
        */
        if ((vmoves != null && maximizingPlayer == true) || (vmoves2 != null && maximizingPlayer == false))
        {
            if (depth == 0 || vmoves[2][0] == 900 || vmoves[2][0] == -900)
            { 
                if(maximizingPlayer == true)
                {
                    
                    return position;
                }else
                {
                    return position2;
                }
                
            
            
            }
        }
        else if(vmoves == null  || vmoves2==null)
        {
            
            //UnityEngine.Debug.Log("vmoves2 or vmoves is null ");
            //return 0;
        }



        if (maximizingPlayer == true)
        {
            int[] maxEval = new int[] { 0, 0, -99999 }; 
            int si = 0;
            int[] eval= new int[3];
            Piece hold = point[position[0], position[1]];
            
            for (int x=0; x< vmoves[0].Count(); x++)
            {
                si = x;
                point[vmoves[0][x], vmoves[1][x]] = hold;
                point[position[0], position[1]] = null;
                if(x !=0)
                {
                    point[vmoves[0][x-1], vmoves[1][x-1]] = null;
                }
              //  UnityEngine.Debug.Log("before min max  " + vmoves[0][x] +"   !!!"+ vmoves[1][x]+"!!!"+ vmoves[2][x] + "***"+ position2[0]+"****" + position2[1]+"****"+ position2[2]+ "     vmoves[0].Count()" + vmoves[0].Count() +"    alpha  "+ alpha +   "   beta  "+ beta);
                eval = AminimaxAlphabeta(new int[] { vmoves[0][x], vmoves[1][x] , vmoves[2][x] }, new int[] { position2[0], position2[1], position2[2] }, depth - 1, alpha, beta, false, point);
              //  UnityEngine.Debug.Log("11111111111111111 " + eval[2] + eval[0] + eval[1]);
              //  UnityEngine.Debug.Log(" befor maxEval " + maxEval[2]+ maxEval[0] + maxEval[1]);
                //maxEval = Mathf.Max(maxEval, eval[2]);
                if(maxEval[2] < eval[2])
                {
                    maxEval[0] = eval[0];
                    maxEval[1] = eval[1];
                    maxEval[2] = eval[2];
                }
          //      UnityEngine.Debug.Log("maxEval " + maxEval[2]+  maxEval[0]+maxEval[1] );
                alpha = Mathf.Max(alpha, eval[2]);
                if (beta <= alpha)
                {
                   break;
                }
            }
            if (vmoves[0].Count() != 0)
            { 
                point[position[0], position[1]] = hold;
                point[vmoves[0][si], vmoves[1][si]] = null;
            }
             return maxEval;
            

            
        } else 
        {
            int[] eval= new int[3];
            //int minEval = +99999;
            int[] minEval = new int[] { 0, 0, +99999 };
            Piece hold2 = point[position2[0], position2[1]];
            // if(hold2 != null)
            int save=0;
            for (int y = 0; y < vmoves2[0].Count(); y++)
            {
                save = y;
                point[vmoves2[0][y], vmoves2[1][y]] = hold2;
                point[position2[0], position2[1]] = null;
                if (y != 0)
                {
                    point[vmoves2[0][y - 1], vmoves2[1][y - 1]] = null;
                }
             //   UnityEngine.Debug.Log("before min max  " + position[0] + "   !!!" + position[1] + "!!!" + position[2] + "***" + vmoves2[0][y] + "****" + vmoves2[1][y]+"***"+ vmoves2[2][y]+ "    vmoves2[0].Count()" + vmoves2[0].Count());
                eval = AminimaxAlphabeta(new int[] { position[0], position[1], position[2] }, new int[] { vmoves2[0][y], vmoves2[1][y], vmoves2[2][y] }, depth - 1, alpha, beta, true, point);
             //   UnityEngine.Debug.Log("22222222222222222 " + eval[2]+ eval[0]+ eval[1]);
             //  UnityEngine.Debug.Log(" befor minEval " + minEval[2]+ minEval[0]+ minEval[1]);
                //minEval = Mathf.Min(minEval, eval[2]);
                if (minEval[2] > eval[2])
                {
                    minEval[0] = eval[0];
                    minEval[1] = eval[1];
                    minEval[2] = eval[2];
                }
             //   UnityEngine.Debug.Log("minEval " + minEval[2]+ minEval[0]+ minEval[1]);
                beta = Mathf.Min(beta, eval[2]);
                
                if (beta <= alpha)
               { break; }
            }
            if (vmoves2[0].Count() != 0)
            {
                point[position2[0], position2[1]] = hold2;
                point[vmoves2[0][save], vmoves2[1][save]] = null;
            }
             return minEval;
        }
    }
    private int[] movement(bool turnnn)
    {
        
        int max = 0;
        int max2 = 0;
        int[] cordinate = new int[5];
        for (int x=0; x<8;x++)
        {
            for(int y=0;y<8;y++)
            {
                for(int v=0;v<8;v++)
                {
                    for(int b=0;b<8;b++)
                    {
                        if (piece[x, y] != null && piece[v, b] != null)
                        {
                        if (piece[x,y].isWhite == !piece[v, b].isWhite)
                        {
                            
                            


                                if (MoveGeneration(x, y, piece)[0].Any() == true && MoveGeneration(v, b, piece)[0].Any() == true)
                                {
                                    Piece[,] copy = piece.Clone() as Piece[,];
                                    int[] result = new int[2];
                                    result = AminimaxAlphabeta(new int[] { x, y, 0 }, new int[] { v, b, 0 }, 2, -99999, +99999, turnnn, copy);
                                    if(result[2] >= max2 && turnnn == true)
                                    {
                                        max2 = result[2];
                                        cordinate[0] = x;
                                        cordinate[1] = y;
                                        cordinate[2] = result[0];
                                        cordinate[3] = result[1];
                                        cordinate[4] = result[2];
                                        }
                                    if (result[2] < max && turnnn == false)
                                    {
                                        max = result[2];
                                        cordinate[0] = v;
                                        cordinate[1] = b;
                                        cordinate[2] = result[0];
                                        cordinate[3] = result[1];
                                        cordinate[4] = result[2];
                                        }
                               
                                }
                            
                        }
                        }
                    }
                }
            }
        }
        return cordinate;
    }
    private void SelectPiece(int x, int y)
    {

        if (x < 0 || x >= piece.Length || y < 0 || y >= piece.Length)
        {
            // UnityEngine.Debug.Log("1111111111111 ");
            return;
        }

        Piece p = piece[x, y];
        if (p != null)
        {
            //UnityEngine.Debug.Log("22222222222222 ");
            selectedPiece = p;
            startDrag = mouseOver;
            //  UnityEngine.Debug.Log("offsettttttttttttttttttttttttttttttt "+ selectedPiece.name);

        }
        //UnityEngine.Debug.Log("333333333333333 ");
    }
    private void TryMove(int x1, int y1, int x2, int y2)
    {
        startDrag = new Vector2(x1, y1);
        endDrag = new Vector2(x2, y2);
        selectedPiece = piece[x1, y1];
        MovePiece(selectedPiece, x2, y2);
        // bool turn = true;
        if (x2 < 0 || x2 >= piece.Length || y2 < 0 || y2 >= piece.Length)
        {

            if (selectedPiece != null)
                MovePiece(selectedPiece, x1, y1);

            startDrag = Vector2.zero;
            selectedPiece = null;
            return;

        }
        if (selectedPiece != null)
        {

            if (endDrag == startDrag)
            {
                MovePiece(selectedPiece, x1, y1);
                startDrag = Vector2.zero;
                selectedPiece = null;
                return;
            }

            if (selectedPiece.validMove(piece, x1, y1, x2, y2))
            {

                //UnityEngine.Debug.Log("hhhhhhhhhhhhhhhhhhhhhhhh  "+selectedPiece.validMove(piece,x1,y1,x2,y2) );

                if ((piece[x2, y2] != null) && (piece[x2, y2].isWhite != piece[x1, y1].isWhite))
                {

                    Piece p = piece[x2, y2];

                    Destroy(piece[x2, y2].gameObject, 8f);
                    piece[x2, y2] = piece[x1, y1];
                    piece[x1, y1] = null;

                    EndTurn(p);

                }
                else if ((piece[x2, y2] != null) && !iswhite)
                {
                    MovePiece(selectedPiece, x1, y1);
                    startDrag = Vector2.zero;
                    selectedPiece = null;


                }
                else
                {
                    piece[x2, y2] = selectedPiece;
                    piece[x1, y1] = null;
                    MovePiece(selectedPiece, x2, y2);
                    
                    EndTurn(null);
                    
                }


                if (Mathf.Abs(x2 - x1) == 2)
                {
                    Piece p = piece[(x1 + x2) / 2, (y1 + y2) / 2];
                    if (p != null)
                    {
                        piece[(x1 + x2) / 2, (y1 + y2) / 2] = null;
                        Destroy(p.gameObject);
                    }
                }



                

            }
            else
            {

                MovePiece(selectedPiece, x1, y1);
                startDrag = Vector2.zero;
                selectedPiece = null;

            }

            // UnityEngine.Debug.Log("offsettttttttttttttttttttttttttttttt" + selectedPiece.validMove(piece, x1, y1, x2, y2));
        }

    }
    private void EndTurn(Piece p)
    {
        selectedPiece = null;
        startDrag = Vector2.zero;
        
        iswhiteTurn = !iswhiteTurn;
       
        CheckVictory(p);
        
        if (turn == true)
        {
            turn = false;

        }
        else if (turn == false)
        {
            turn = true;
        }
    }
    private void CheckVictory(Piece p)
    {
        if(p != null) { 
        if ( p.name == "eKING_MK_Demo")
        {
             UnityEngine.Debug.Log("white wins ");
            wehavewiner = true;
        }
        if(p.name == "KING_arthur_01")
        {
            UnityEngine.Debug.Log("enemy wins ");
            wehavewiner = true;
        }
        UnityEngine.Debug.Log("enddddddddddddddddddddddddd  ");
        }
    }
    private void UpdateMouseOver()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1000.0f, LayerMask.GetMask("Board")))
        {
            mouseOver.x = (int)hit.point.x;
            mouseOver.y = (int)hit.point.z;


        }
        else
        {
            mouseOver.x = -1;
            mouseOver.y = -1;
        }
    }
    private void UpdatePieceDrag(Piece p)
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1000.0f, LayerMask.GetMask("Board")))
        {
            //UnityEngine.Debug.Log("offsettttttttttttttttttttttttttttttt " );
            //p.transform.position = hit.point + Vector3.up;
        }

    }

    private void GenerateBoard()
    {

        for (int y = 1; y < 2; y++)
        {
            for (int x = 0; x < 8; x++)
            {
                GeneratePiece(x, y);
            }
        }

        for (int y = 6; y <= 7; y++)
        {
            for (int x = 0; x < 8; x++)
            {
                GeneratePiece(x, y);
            }
        }
        for (int y = 0; y < 1; y++)
        {
            for (int x = 0; x < 8; x++)
            {
                GeneratePiece(x, y);
            }
        }
    }



    // Update is called once per frame
    private void GeneratePiece(int x, int y)
    {
        // GameObject go = Instantiate(whitePiecePrefab) as GameObject;
        // go.transform.SetParent(transform);
        if (y == 1)
        {
            Piece p = go[x].GetComponent<Piece>();
            piece[x, y] = p;
            p.transform.position = board + new Vector3(x, 0, 0);
        }
        if (y == 6)
        {
            Piece p = go[x + 8].GetComponent<Piece>();
            piece[x, y] = p;
            p.transform.position = board2 + new Vector3(x, 0, 0);
        }
        if (y == 7)
        {
            // UnityEngine.Debug.Log("7777777777777777777");
            Piece p = xx[x].GetComponent<Piece>();
            piece[x, y] = p;
            p.transform.position = board2 + new Vector3(x, 0, 1);

        }
        if (y == 0)
        {
            // UnityEngine.Debug.Log("7777777777777777777");
            Piece p = xx[x +8].GetComponent<Piece>();
            piece[x, y] = p;
            p.transform.position = board + new Vector3(x, 0, -1);


        }


        // Debug.Log("during generating " + p.transform.position);
        //MovePiece(p, x, y);

    }
    private void MovePiece(Piece p, int x, int y)
    {
        //Debug.Log("Hello before " + p.transform.position);
        // UnityEngine.Debug.Log("y " + y);
        //UnityEngine.Debug.Log("x " + x);
        //UnityEngine.Debug.Log("position"+ p.transform.position);
        // UnityEngine.Debug.Log("board" +board);
        // UnityEngine.Debug.Log("x "+  x );
        // UnityEngine.Debug.Log(" y" +y);

        //p.transform.position = board + (Vector3.right * x) + (Vector3.forward * (y - 1));
        p.agent.destination = board + (Vector3.right * x) + (Vector3.forward * (y - 1));
        // = (Vector3.right * x) + (Vector3.forward *y) +
        // Debug.Log("Hello after " + board);
        // Debug.Log("Hello after " + p.transform.position);
    }


}
