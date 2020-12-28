using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class PieceAnimations : MonoBehaviour
{
    NavMeshAgent targetNavMesh;
    Rigidbody targetRigidBody;
    public GameObject target;
    public Piece chosenPiece;
    //public chboard ChessBoard;
    public float howclose;
    public float howclosetoattack;
    public float dist;
    public float Phydist;
    public Animation pieceAnimation;
    public Animation piecekilledAnimation;
    public Animator piecekilledAnimator;
    public AnimationClip walk;
    public AnimationClip run;
    public AnimationClip wait;
    public AnimationClip attack;
    //public AnimationClip get_hurt;
    public AnimationClip die;

    public Vector3 dest, prev;
    public Piece[,] checkGameObject = new Piece[8, 8];
    //public Piece[,] checkGameObject;

    public int piecePrevPosX, piecePrevPosY, pieceNextPosX, pieceNextPosY;

    //public string ObjectString;
    
    //Start is called before the first frame update
    void Start()
    {
        pieceAnimation = GetComponent<Animation>();
        
    }


    void Update()
    {
        try 
        {
            dest = chosenPiece.agent.destination;
            prev = chosenPiece.transform.position;
        }       
        catch (NullReferenceException ex) 
        {
            Debug.Log("Checking Positions for Calculating the Agent Distance");
        }

        piecePrevPosX   = chosenPiece.PrevX;   
        piecePrevPosY   = chosenPiece.PrevY;
        pieceNextPosX   = chosenPiece.NextX;
        pieceNextPosY   = chosenPiece.NextY;
        checkGameObject[pieceNextPosX,pieceNextPosY] = chosenPiece.checkPiece[pieceNextPosX,pieceNextPosY];

        dist = Vector3.Distance(dest, prev);
        Phydist = HypotenuseLength(pieceNextPosX-piecePrevPosX, pieceNextPosY-piecePrevPosY);
        //Debug.Log(checkGameObject[pieceNextPosX, pieceNextPosY]);

        if(dist == 0)
        {
            //Debug.Log("I'm in Idle Mode");
            pieceAnimation.CrossFade(wait.name);
        }
        else
        {
            //if(chosenPiece.checkPiece[pieceNextPosX,pieceNextPosY] != null)
            if(checkGameObject[pieceNextPosX,pieceNextPosY] != null)
            {
                pieceAnimation.CrossFade(attack.name);
                //Debug.Log("I'm in Attacking Mode");
                //target = GameObject.Find(chosenPiece.checkPiece[pieceNextPosX,pieceNextPosY].name);
                string target_name = checkGameObject[pieceNextPosX,pieceNextPosY].name;
                //target = GameObject.Find(checkGameObject[pieceNextPosX,pieceNextPosY].name);
                target = GameObject.Find(target_name);
                piecekilledAnimator = target.GetComponent<Animator>();
                piecekilledAnimation = target.GetComponent<Animation>();
                targetRigidBody = target.GetComponent<Rigidbody>();
                targetNavMesh = target.GetComponent<NavMeshAgent>();
                if(
                    target_name == "PAWN_arthur_01 (1)" || target_name == "PAWN_arthur_01 (2)" || 
                    target_name == "PAWN_arthur_01 (3)" || target_name == "PAWN_arthur_01 (4)" ||
                    target_name == "PAWN_arthur_01 (5)" || target_name == "PAWN_arthur_01 (6)" ||
                    target_name == "PAWN_arthur_01 (7)" || target_name == "PAWN_arthur_01 (8)" || target_name == "KING_arthur_01"
                  )
                {
                    piecekilledAnimation.Play("arthur_dead_01");
                }
                else if(
                    target_name == "PAWN_GOBLIN (1)" || target_name == "PAWN_GOBLIN (2)" || 
                    target_name == "PAWN_GOBLIN (3)" || target_name == "PAWN_GOBLIN (4)" ||
                    target_name == "PAWN_GOBLIN (5)" || target_name == "PAWN_GOBLIN (6)" ||
                    target_name == "PAWN_GOBLIN (7)" || target_name == "PAWN_GOBLIN (8)" 
                  )
                {
                    piecekilledAnimation.Play("death");
                    //piecekilledAnimator.Play("block_hit");
                }
                else if(target_name == "eROOK_monster_orc (1)" || target_name == "eROOK_monster_orc (2)" )
                {
                    piecekilledAnimation.Play("Monster_anim|Death");
                }
                else if(target_name == "ROOK_ToonRTS_demo_Knight (1)" || target_name == "ROOK_ToonRTS_demo_Knight (2)" )
                {
                    piecekilledAnimation.Play("WK_heavy_infantry_04_charge"); //maybe
                }
                else if(target_name == "HORSE_Centaur_Unity (2)" || target_name == "HORSE_Centaur_Unity (3)" )
                {
                    piecekilledAnimation.Play("Centaur_rig|death1"); //maybe
                }
                else if(target_name == "eHORSE_Orc_Wolfrider (1)" || target_name == "eHORSE_Orc_Wolfrider" )
                {
                    piecekilledAnimation.Play("Orc_wolfrider_08_attack_B"); //maybe
                }
                else if(target_name == "eBISHOP_Ch40_nonPBR (1)" || target_name == "eBISHOP_Ch40_nonPBR (2)" )
                {
                    piecekilledAnimation.Play("mixamo"); //maybe
                }
                else if(target_name == "BISHOP_uriel_a_plotexia (1)" || target_name == "BISHOP_uriel_a_plotexia (2)" )
                {
                    piecekilledAnimation.Play("mixamo"); //maybe
                }
                else if(target_name == "QUEEN_A03")
                {
                    piecekilledAnimation.Play("1HDeathA"); //maybe
                }
                else if(target_name == "eQUEEN_Spider_Queen")
                {
                    piecekilledAnimation.Play("Die"); //maybe
                }
                else if(target_name == "eKING_MK_Demo")
                {
                    piecekilledAnimation.Play("MK_dieFromBellyStab"); //maybe
                }
                //piecekilledAnimation.CrossFade(die.name);
                Destroy(targetNavMesh, 3.0f);
                //Destroy(targetNavMesh, 3.0f);
                Destroy(targetRigidBody, 6.0f);
                //Destroy(target,9.0f);
                /*
                if(chosenPiece.checkPiece[pieceNextPosX,pieceNextPosY].isWhite != chosenPiece.checkPiece[piecePrevPosX,piecePrevPosY].isWhite))
                {
                }
                */
            }
            else
            {
                if(Phydist >= 1.1f)
                {
                    pieceAnimation.CrossFade(run.name);
                    //Debug.Log("I'm in Running Mode");
                    //Debug.Log(chosenPiece.checkPiece[pieceNextPosX,pieceNextPosY]);
                }
                else if(Phydist < 1.1f && Phydist > 0f )
                {
                    pieceAnimation.CrossFade(walk.name);
                    //Debug.Log("I'm in Walking Mode");
                    //Debug.Log(chosenPiece.checkPiece[pieceNextPosX,pieceNextPosY]);
                }
            }
            
        }
        
    }

    float HypotenuseLength(int sideALength, int sideBLength)
    {
        return Mathf.Sqrt(sideALength * sideALength + sideBLength * sideBLength);
    }

}
