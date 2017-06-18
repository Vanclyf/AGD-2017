using UnityEngine;
using System.Collections;

public class LevelGenerator : MonoBehaviour {

    public Transform plaform;
    public Transform jumpTrap;
    public Transform duckTrap;
    public Transform end;
    public int pProbability, pUserScore;

    public int platformCount;
    private int _platformMargin = 15;
    public int startingPointX;
    private int _randomNumber;
    private int _normalPlatformProbability = 60;

    // Use this for initialization
    public void Start () {

            for (int x = 0; x < platformCount; x++)
            {
            if(x == platformCount -1)
            {
                Instantiate(end, new Vector3(startingPointX + _platformMargin, 0, 0), Quaternion.identity);
                break;
            }
            _randomNumber = Random.Range(0, 100);

            if(_randomNumber <= _normalPlatformProbability)
            {
                Instantiate(plaform, new Vector3(startingPointX + _platformMargin, 0, 0), Quaternion.identity);
            } else if(_randomNumber <= 100 && _randomNumber >= 60)
            {
                int rand = Random.Range(0, 100);
                if(rand <= 50)
                {
                    Instantiate(jumpTrap, new Vector3(startingPointX + _platformMargin, -0.1f, 0), Quaternion.identity);
                } else if (rand <= 100 && rand >= 50)
                {
                    Instantiate(duckTrap, new Vector3(startingPointX + _platformMargin, 0, 0), Quaternion.identity);
                }
                
            }

            _platformMargin += 10;
            }

            
 
    }

    public int getProbability()
    {
        return pProbability;
    }

    public int getUserScore()
    {
        return pUserScore;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public int CalculateProbabilityWithUserInput(int pProbability, int pUserScore, bool pChallanging, bool pFun)
    {
        
        
        if (pChallanging == false && pFun == false) {
            pUserScore *= 5;
            pProbability -= pUserScore;
        }
        else if (pChallanging == false && pFun == true)
        {
            pUserScore *= 5;
            pProbability += pUserScore;
        }
        else if (pChallanging == true && pFun == true)
        {
            pUserScore *= 1;
            pProbability += pUserScore;
        }
        else if (pChallanging == true && pFun == false)
        {
            pUserScore *= 1;
            pProbability -= pUserScore;
        }

        return pProbability;
    }

}
