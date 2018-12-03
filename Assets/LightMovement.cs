using System.Collections;
using UnityEngine;

public class LightMovement : MonoBehaviour
{
    public Transform Left;
    public Transform Right;

    private Quaternion rotation;
    // Use this for initialization
    void Start ()
    {
        StartCoroutine(Rotate());
    }
	
	// Update is called once per frame
	IEnumerator Rotate ()
	{
	    float t = 0;
	    float time = 2f;
	    var from = this.Left.rotation;
	    var to = this.Right.rotation;
        while (true)
        {
            var _t = t * t * t * (t * (6f * t - 15f) + 10f);

            transform.rotation = Quaternion.Lerp(from, to, _t);
	        yield return new WaitForEndOfFrame();
	        t += Time.deltaTime / time;
	        if (t > .99f)
	        {
	            var temp = from;
	            from = to;
	            to = temp;
	            t = 0f;
	        }
	    }
	}
}
