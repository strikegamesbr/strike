using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchGesture : MonoBehaviour
{
	[System.Serializable]
	public class GestureSettings
	{
		public float minSwipeDist = 3;
		public float maxSwipeTime = 10;
	}

	private GestureSettings settings;
	private float swipeStartTime;
	private bool couldBeSwipe;
	private Vector2 startPos;
	private int stationaryForFrames;
	private TouchPhase lastPhase;


	public TouchGesture(GestureSettings gestureSettings)
	{
		this.settings = gestureSettings;
	}



//	public IEnumerator CheckVerticalSwipes(Action toUpSwipe, Action toDownSwipe) //Coroutine, which gets Started in "Start()" and runs over the whole game to check for swipes
//	{
//
//		Debug.Log ("CheckVerticalSwipes - (015)");
//
//		while (true)
//		{ //Loop. Otherwise we wouldnt check continuously ;-)
//			foreach (Touch touch in Input.touches)
//			{ //For every touch in the Input.touches - array...
//				switch (touch.phase)
//				{
//				case TouchPhase.Began: //The finger first touched the screen --> It could be(come) a swipe
//					couldBeSwipe = true;
//					startPos = touch.position;  //Position where the touch started
////					swipeStartTime = Time.time; //The time it started
////					stationaryForFrames = 0;
//					break;
//				case TouchPhase.Stationary: //Is the touch stationary? --> No swipe then!
////					if (isContinouslyStationary(frames:6))
//						couldBeSwipe = false;
//					break;
//				case TouchPhase.Ended:
////					if (isASwipe(touch))
////					{
//						couldBeSwipe = false; //<-- Otherwise this part would be called over and over again.
//						if (Mathf.Sign(touch.position.y - startPos.y) == 1f) { //Swipe-direction, either 1 or -1.   
//							Debug.Log("Swipe para cima - (013)");
//							toUpSwipe(); //Right-swipe
//						}
//						else {
//							Debug.Log("Swipe para baixo - (014)");
//							toDownSwipe(); //Left-swipe
//						}
////					}
//					break;
//				}
//				lastPhase = touch.phase;
//			}
//			yield return null;
//		}
//	}


	private bool isContinouslyStationary(int frames)
	{
		if (lastPhase == TouchPhase.Stationary)
			stationaryForFrames++;
		else // reset back to 1
			stationaryForFrames = 1;
		return stationaryForFrames > frames;
	}


	private bool isASwipe(Touch touch)
	{
		float swipeTime = Time.time - swipeStartTime; //Time the touch stayed at the screen till now.
		float swipeDist = Mathf.Abs(touch.position.x - startPos.x); //Swipe distance

//		Debug.Log ("(016) couldBeSwipe=" + couldBeSwipe + " swipeTime=" + swipeTime + " swipeDist=" + swipeDist + " " + (couldBeSwipe && swipeTime < settings.maxSwipeTime && swipeDist > settings.minSwipeDist));


		return couldBeSwipe && swipeTime < settings.maxSwipeTime && swipeDist > settings.minSwipeDist;
	}


	public IEnumerator CheckVerticalSwipes(Action onToUpSwipe, Action onToDownSwipe) //Coroutine, which gets Started in "Start()" and runs over the whole game to check for swipes
	{

//		Debug.Log ("CheckVerticalSwipes - (015)");

		while (true)
		{ //Loop. Otherwise we wouldnt check continuously ;-)
			foreach (Touch touch in Input.touches)
			{ //For every touch in the Input.touches - array...
				switch (touch.phase)
				{
				case TouchPhase.Began: //The finger first touched the screen --> It could be(come) a swipe
					couldBeSwipe = true;
					startPos = touch.position;  //Position where the touch started
					break;
				case TouchPhase.Stationary: //Is the touch stationary? --> No swipe then!
					if (isContinouslyStationary(frames:6))
						couldBeSwipe = false;
					break;
				case TouchPhase.Ended:
					if (couldBeSwipe) {
						couldBeSwipe = false; //<-- Otherwise this part would be called over and over again.
						if (Mathf.Sign (touch.position.y - startPos.y) == 1f) { //Swipe-direction, either 1 or -1.   
//							Debug.Log ("Swipe para cima - (013)");
							onToUpSwipe (); //Right-swipe
						} else {
//							Debug.Log ("Swipe para baixo - (014)");
							onToDownSwipe (); //Left-swipe
						}
					}
					break;
				}
				lastPhase = touch.phase;
			}
			yield return null;
		}
	}



	public IEnumerator checkStationary (Action onStationary, Action onEnded)
	{

		while (true) {
			
			foreach (Touch touch in Input.touches) {
				
				if (touch.phase == TouchPhase.Stationary && isContinouslyStationary (6)) {
					onStationary ();
				} else if (touch.phase == TouchPhase.Ended) {
					onEnded ();
				}

			}
			yield return null;
		}

	}




}