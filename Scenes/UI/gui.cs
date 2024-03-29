using Godot;
using System;
using EventCallback;

public partial class gui : CanvasLayer
{
	[Export] Control HUD;
	[Export] Control menu;
	[Export] Control countdown;
	[Export] Control results;
	[Export] Control blackout;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		ShowMenuEvent.RegisterListener(OnShowMenuEvent);
		ShowHUDEvent.RegisterListener(OnShowHUDEvent);
		ShowCountdownEvent.RegisterListener(OnShowCountdownEvent);
		ShowResultsEvent.RegisterListener(OnShowResultsEvent);
		ShowBlackoutEvent.RegisterListener(OnShowBlackoutEvent);
		CallDeferred("PlayMusic");
	}
	public void PlayMusic()
	{
		PlayMusicEvent pme = new();
		pme.music = MusicList.Menu;
		pme.FireEvent();
	}

	private void OnShowMenuEvent(ShowMenuEvent sme)
	{
		menu.Visible = !menu.Visible;
	}
	private void OnShowHUDEvent(ShowHUDEvent she)
	{
		HUD.Visible = true;
	}
	private void OnShowCountdownEvent(ShowCountdownEvent sce)
	{
		countdown.Visible = true;
	}
	private void OnShowResultsEvent(ShowResultsEvent sre)
	{
		results.Visible = true;
		HUD.Visible = false;
		menu.Visible = false;
		countdown.Visible = false;
		blackout.Visible = false;
	}
	private void OnShowBlackoutEvent(ShowBlackoutEvent sbe)
	{
		blackout.Visible = true;

	}

}
