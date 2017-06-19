using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RatingMenu : MonoBehaviour {
    private GameObject isDifficult;
    private GameObject isFun;
    [SerializeField]
    private LevelGenerator level;
    public bool wasDifficult;
    public int difficultyLevel;
    public bool wasFun;
    public int funFactor;
    // Use this for initialization

    void Start () {
        isDifficult = GameObject.Find("wasDifficult");
        isFun = GameObject.Find("wasFun");
    }
	
	// Update is called once per frame
	void Update () {
    }

    public void setIsDifficult(bool wasDifficult)
    {
        this.wasDifficult = wasDifficult;
    }

    public void setDifficultyLevel(int diff)
    {
        difficultyLevel = diff;
    }

    public void setFunFactor(int fun)
    {
        funFactor = fun;
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
        DontDestroyOnLoad(this.gameObject);
        SceneManager.LoadScene("AGD-Level");
    }

    public void GenerateNextLevel()
    {
        level._generated = false;
        level.Generate(level.CalculateProbabilityWithUserInput(level.getUserScore(), getIsDifficult(), getIsFun(), difficultyLevel, funFactor));
    }

    public void exitGame()
    {
     
        Application.Quit();
    
    }
}
