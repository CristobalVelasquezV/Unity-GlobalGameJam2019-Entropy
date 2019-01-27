using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private static GameState state;

    public  enum GameState {Default,Pause,MiniGame,CutScene }
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            state = GameState.CutScene;
        }
        else {
            Destroy(this.gameObject);
        }
        
    }
    public  GameState getGameState() {
        return state;
    }
    public void setGameState(GameState newState) {
        state = newState;
    }


}
