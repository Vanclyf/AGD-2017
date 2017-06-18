using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RatingMenu : MonoBehaviour {
    private GameObject isDifficult;
    private GameObject isFun;
    public LevelGenerator level;
    public bool wasDifficult;
    public bool wasFun;
    // Use this for initialization

    void Start () {
        isDifficult = GameObject.Find("wasDifficult");
        isFun = GameObject.Find("wasFun");
    }
	
	// Update is called once per frame
	void Update () {
        if (isDifficult.GetComponent<Toggle>().isOn == true)
        {
            setIsDifficult(true);
        }
        else{
            setIsDifficult(false);
        }

        if(isFun.GetComponent<Toggle>().isOn == true)
        {
            setIsFun(true);
        }
        else
        {
            setIsFun(false);
        }
       
    }

    public void setIsDifficult(bool wasDifficult)
    {
        this.wasDifficult = wasDifficult;
    }

    public bool getIsDifficult()
    {
        return wasDifficult;
    }

    public void setIsFun(bool wasFun)
    {
        this.wasFun = wasFun;
    }

    public bool getIsFun()
    {
        return wasFun;
    }


    public void NextLevel()
    {
        
        level.CalculateProbabilityWithUserInput( level.getProbability(), level.getUserScore() , getIsDifficult(), getIsFun() );
    }

    public void exitGame()
    {
     
        Application.Quit();
    
    }
}
