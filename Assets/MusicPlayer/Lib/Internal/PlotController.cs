using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotController : MonoBehaviour {
    public float peakHeightThreshold = 10f;
    public List<Transform> plotPoints;
	private Material highlightMaterial;
	public int displayWindowSize = 300;

    public float height1 = 1;
    public float height2 = 2f;
    public float OutOFboundsHeight = 1000f;
    //public spawnPoints spawnPoint;
    public Transform peakPoint;
    // Use this for initialization
    void Start () {
		plotPoints = new List<Transform> ();

		float localWidth = transform.Find("Point/BasePoint").localScale.x;
		// -n/2...0...n/2
		for (int i = 0; i < displayWindowSize; i++) {
			//Instantiate point
			Transform t = (Instantiate(Resources.Load("Point"), transform) as GameObject).transform;

			// Set position
			float pointX = (displayWindowSize / 2) * -1 * localWidth + i * localWidth;
			t.localPosition = new Vector3(pointX, t.localPosition.y, t.localPosition.z);

			plotPoints.Add (t);
		}
	}

    public void updatePlot(List<SpectralFluxInfo> pointInfo, int curIndex = -1)
    {
        if (plotPoints.Count < displayWindowSize - 1)
            return;

        int numPlotted = 0;
        int windowStart = 0;
        int windowEnd = 0;

        if (curIndex > 0)
        {
            windowStart = Mathf.Max(0, curIndex - displayWindowSize / 2);
            windowEnd = Mathf.Min(curIndex + displayWindowSize / 2, pointInfo.Count - 1);
        }
        else
        {
            windowStart = Mathf.Max(0, pointInfo.Count - displayWindowSize - 1);
            windowEnd = Mathf.Min(windowStart + displayWindowSize, pointInfo.Count);
        }

        for (int i = windowStart; i < windowEnd; i++)
        {
            int plotIndex = numPlotted;
            numPlotted++;

            peakPoint = plotPoints[plotIndex].Find("PeakPoint");
            Transform fluxPoint = plotPoints[plotIndex].Find("FluxPoint");
            Transform basePoint = plotPoints[plotIndex].Find("BasePoint");
            Transform threshPoint = plotPoints[plotIndex].Find("ThreshPoint");

            fluxPoint.position = new Vector3 (1000, 1000, 100);
            basePoint.position = new Vector3 (1000, 1000, 100);
            threshPoint.position = new Vector3 (1000, 1000, 100);

            if (pointInfo[i].isPeak && pointInfo[i].spectralFlux > peakHeightThreshold)
            {                
                // Only set a random height if peakHeight has not already been set.
                if (pointInfo[i].peakHeight == 0)
                {
                    pointInfo[i].peakHeight = Random.Range(height1, height2);
                    peakPoint.gameObject.SetActive(true);


                }
                setPointHeight(peakPoint, pointInfo[i].peakHeight);
                //spawnPoint.MakePoints(peakPoint.transform);

            }
            else
            {
                peakPoint.gameObject.SetActive(true);
                setPointHeight(peakPoint, 100f);
            }
        }
    }


    public void setPointHeight(Transform point, float height)
    {
        float displayMultiplier = 0.06f;
        point.localPosition = new Vector3(point.localPosition.x, height * displayMultiplier, point.localPosition.z);
    }
}
