using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Solutions : MonoBehaviour
{
    public static List<List<string>> solution1;
    public static List<List<string>> solution2;

    void Awake()
    {
        solution1 = new List<List<string>>();
        SolutionOne();

        solution2 = new List<List<string>>();
        SolutionTwo();

    }
    
    public void SolutionOne()
    {
        
        List<string> solutionRow1 = new List<string>();
        //floor 1
        solutionRow1.Add("opaque");
        solutionRow1.Add("empty");
        solutionRow1.Add("empty");
        solutionRow1.Add("empty");
        solution1.Add(solutionRow1);

        solutionRow1 = new List<string>();
        solutionRow1.Add("opaque");
        solutionRow1.Add("empty");
        solutionRow1.Add("empty");
        solutionRow1.Add("empty");
        solution1.Add(solutionRow1);

        solutionRow1 = new List<string>();
        solutionRow1.Add("opaque");
        solutionRow1.Add("empty");
        solutionRow1.Add("empty");
        solutionRow1.Add("empty");
        solution1.Add(solutionRow1);

        solutionRow1 = new List<string>();
        solutionRow1.Add("opaque");
        solutionRow1.Add("empty");
        solutionRow1.Add("empty");
        solutionRow1.Add("empty");
        solution1.Add(solutionRow1);
        //floor 2
        solutionRow1 = new List<string>();
        solutionRow1.Add("empty");
        solutionRow1.Add("opaque");
        solutionRow1.Add("empty");
        solutionRow1.Add("empty");
        solution1.Add(solutionRow1);

        solutionRow1 = new List<string>();
        solutionRow1.Add("empty");
        solutionRow1.Add("empty");
        solutionRow1.Add("empty");
        solutionRow1.Add("empty");
        solution1.Add(solutionRow1);

        solutionRow1 = new List<string>();
        solutionRow1.Add("empty");
        solutionRow1.Add("empty");
        solutionRow1.Add("empty");
        solutionRow1.Add("empty");
        solution1.Add(solutionRow1);

        solutionRow1 = new List<string>();
        solutionRow1.Add("empty");
        solutionRow1.Add("opaque");
        solutionRow1.Add("empty");
        solutionRow1.Add("empty");
        solution1.Add(solutionRow1);
        //floor 3
        solutionRow1 = new List<string>();
        solutionRow1.Add("empty");
        solutionRow1.Add("empty");
        solutionRow1.Add("opaque");
        solutionRow1.Add("empty");
        solution1.Add(solutionRow1);

        solutionRow1 = new List<string>();
        solutionRow1.Add("empty");
        solutionRow1.Add("empty");
        solutionRow1.Add("empty");
        solutionRow1.Add("empty");
        solution1.Add(solutionRow1);

        solutionRow1 = new List<string>();
        solutionRow1.Add("empty");
        solutionRow1.Add("empty");
        solutionRow1.Add("empty");
        solutionRow1.Add("empty");
        solution1.Add(solutionRow1);

        solutionRow1 = new List<string>();
        solutionRow1.Add("empty");
        solutionRow1.Add("empty");
        solutionRow1.Add("opaque");
        solutionRow1.Add("empty");
        solution1.Add(solutionRow1);
        //floor 4
        solutionRow1 = new List<string>();
        solutionRow1.Add("empty");
        solutionRow1.Add("empty");
        solutionRow1.Add("empty");
        solutionRow1.Add("opaque");
        solution1.Add(solutionRow1);

        solutionRow1 = new List<string>();
        solutionRow1.Add("empty");
        solutionRow1.Add("empty");
        solutionRow1.Add("empty");
        solutionRow1.Add("opaque");
        solution1.Add(solutionRow1);

        solutionRow1 = new List<string>();
        solutionRow1.Add("empty");
        solutionRow1.Add("empty");
        solutionRow1.Add("empty");
        solutionRow1.Add("opaque");
        solution1.Add(solutionRow1);

        solutionRow1 = new List<string>();
        solutionRow1.Add("empty");
        solutionRow1.Add("empty");
        solutionRow1.Add("empty");
        solutionRow1.Add("opaque");
        solution1.Add(solutionRow1);

    }


    public void SolutionTwo()
    {

        List<string> solutionRow1 = new List<string>();
        //column 1
        solutionRow1.Add("empty");
        solutionRow1.Add("empty");
        solutionRow1.Add("empty");
        solutionRow1.Add("empty");
        solution2.Add(solutionRow1);

        solutionRow1 = new List<string>();
        solutionRow1.Add("empty");
        solutionRow1.Add("empty");
        solutionRow1.Add("empty");
        solutionRow1.Add("empty");
        solution2.Add(solutionRow1);

        solutionRow1 = new List<string>();
        solutionRow1.Add("opaque");
        solutionRow1.Add("empty");
        solutionRow1.Add("empty");
        solutionRow1.Add("opaque");
        solution2.Add(solutionRow1);

        solutionRow1 = new List<string>();
        solutionRow1.Add("opaque");
        solutionRow1.Add("opaque");
        solutionRow1.Add("opaque");
        solutionRow1.Add("opaque");
        solution2.Add(solutionRow1);
        //column 2
        solutionRow1 = new List<string>();
        solutionRow1.Add("empty");
        solutionRow1.Add("empty");
        solutionRow1.Add("empty");
        solutionRow1.Add("empty");
        solution2.Add(solutionRow1);

        solutionRow1 = new List<string>();
        solutionRow1.Add("empty");
        solutionRow1.Add("empty");
        solutionRow1.Add("empty");
        solutionRow1.Add("empty");
        solution2.Add(solutionRow1);

        solutionRow1 = new List<string>();
        solutionRow1.Add("opaque");
        solutionRow1.Add("empty");
        solutionRow1.Add("empty");
        solutionRow1.Add("opaque");
        solution2.Add(solutionRow1);

        solutionRow1 = new List<string>();
        solutionRow1.Add("opaque");
        solutionRow1.Add("empty");
        solutionRow1.Add("empty");
        solutionRow1.Add("opaque");
        solution2.Add(solutionRow1);
        //column 3
        solutionRow1 = new List<string>();
        solutionRow1.Add("opaque");
        solutionRow1.Add("empty");
        solutionRow1.Add("empty");
        solutionRow1.Add("opaque");
        solution2.Add(solutionRow1);

        solutionRow1 = new List<string>();
        solutionRow1.Add("opaque");
        solutionRow1.Add("empty");
        solutionRow1.Add("empty");
        solutionRow1.Add("opaque");
        solution2.Add(solutionRow1);

        solutionRow1 = new List<string>();
        solutionRow1.Add("empty");
        solutionRow1.Add("empty");
        solutionRow1.Add("empty");
        solutionRow1.Add("empty");
        solution2.Add(solutionRow1);

        solutionRow1 = new List<string>();
        solutionRow1.Add("empty");
        solutionRow1.Add("empty");
        solutionRow1.Add("empty");
        solutionRow1.Add("empty");
        solution2.Add(solutionRow1);
        //column 4
        solutionRow1 = new List<string>();
        solutionRow1.Add("opaque");
        solutionRow1.Add("opaque");
        solutionRow1.Add("opaque");
        solutionRow1.Add("opaque");
        solution2.Add(solutionRow1);

        solutionRow1 = new List<string>();
        solutionRow1.Add("opaque");
        solutionRow1.Add("empty");
        solutionRow1.Add("empty");
        solutionRow1.Add("opaque");
        solution2.Add(solutionRow1);

        solutionRow1 = new List<string>();
        solutionRow1.Add("empty");
        solutionRow1.Add("empty");
        solutionRow1.Add("empty");
        solutionRow1.Add("empty");
        solution2.Add(solutionRow1);

        solutionRow1 = new List<string>();
        solutionRow1.Add("empty");
        solutionRow1.Add("empty");
        solutionRow1.Add("empty");
        solutionRow1.Add("empty");
        solution2.Add(solutionRow1);

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
