using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;
public class admanager : MonoBehaviour {

	InterstitialAd interstitial;
	BannerView banner;
	RewardBasedVideoAd rewardBasedVideo;



	void Start()
	{
		
		string appID = "ca-app-pub-6608858398251106~4439034233";
		MobileAds.Initialize (appID);
		RequestBanner();
		RequestInterstitial();
		RequestRewardBasedVideo ();



		banner.OnAdLoaded += HandleOnAdLoaded;

		rewardBasedVideo.OnAdClosed += HandleRewardBasedVideoClosed;
		rewardBasedVideo.OnAdRewarded += HandleRewardBasedVideoRewarded;


	}

	public void RequestBanner()
	{

		string adUnitId = "ca-app-pub-3940256099942544/6300978111";


		// Create a 320x50 banner at the top of the screen.
		banner = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Bottom);

		// Create an empty ad request.
		AdRequest request = new AdRequest.Builder().AddTestDevice("1A1F9FE7EDD1EC284EB201818354B2A2").Build();

		// Load the banner with the request.
		banner.LoadAd(request);
		banner.OnAdLoaded += HandleOnAdLoaded;


	}


	void HandleOnAdLoaded(object a,EventArgs args)
	{
		print ("banner loaded");
		banner.Show ();
	}



	public void RequestInterstitial()
	{
		#if UNITY_ANDROID
		string adUnitId = "ca-app-pub-3940256099942544/1033173712";
		#elif UNITY_IPHONE
		string adUnitId = "ca-app-pub-3940256099942544/4411468910";
		#else
		string adUnitId = "unexpected_platform";
		#endif



		// Initialize an InterstitialAd.
		interstitial = new InterstitialAd(adUnitId);

		// Create an empty ad request.
		AdRequest request = new AdRequest.Builder().AddTestDevice("1A1F9FE7EDD1EC284EB201818354B2A2").Build();
		// Load the interstitial with the request.
		interstitial.LoadAd(request);
		}


		public void showinterstitial()
		{
		if (interstitial != null)
		interstitial.Show ();
		}

		//-------------------------------------------------------------
		public void RequestRewardBasedVideo()
		{
		string adUnitId = "ca-app-pub-3940256099942544/5224354917";
		rewardBasedVideo = RewardBasedVideoAd.Instance;
		AdRequest request = new AdRequest.Builder ().AddTestDevice("1A1F9FE7EDD1EC284EB201818354B2A2").Build ();

		rewardBasedVideo.LoadAd (request, adUnitId);
		}

		public void HandleRewardBasedVideoClosed(object sender, EventArgs args)
		{
		this.RequestRewardBasedVideo();
		}
		public void HandleRewardBasedVideoRewarded(object sender, Reward args)
		{

		string type = args.Type;
		double amount = args.Amount;
		print("User rewarded with: " + amount.ToString() + " " + type);


		}


		//---------------------------------------------------------------------------
		public void showrewardedvideo()
		{
		if (rewardBasedVideo.IsLoaded()) {
		rewardBasedVideo.Show();
		}


		}

		public void continuefunc()
		{
		showrewardedvideo ();
		}



		}