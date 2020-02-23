** READ ME **

Extended Audio Source is an pseudo-extension of Audio Source meant to help less experienced programmers and never having to code almost essential audio function again.

Extended Audio Source have functions such as track fading, random pitch variation and play focusing.

To use Extended Audio Source, simply add it to a Game Object that has an Audio Source on it.
Instead of declaring AudioSource in scripts, declare an ExtendedAudioSource instead.
You can easily access all AudioSource properties with ExtendedAudioSource.source

** INSPECTOR FEATURES **
bool Play Intro On Awake
bool Play Playlist On Awake
bool Loop Playlist

AudioClip Intro Clip
AudioClip Looping Clip

PlaylistObject Playlist

** PLAYLIST CREATOR **

To make a playlist, right-click anywhere in the project folder and select Create -> Playlist from the top of the list.
You can then easily add songs to the playlist which you can later use along with an Extended Audio Source.

** NEW FUNCTIONS **

PlayFromPlaylist()
Starts and plays the playlist.

AddToPlaylist(AudioClip clipToAdd)
Adds an audio clip to the playlist

PlayIntroFirst(AudioClip songToLoop) + 1 overload (AudioClip intro, AudioClip songToLoop)
A function that plays a clip first, then plays another clip that loops afterwards

CrossFade(ExtendedAudioSource otherSource, AudioClip clip) + 1 overload (float time)
A function that crossfades two Audio Sources.
Parameters allows you to choose how long the fade is and what clip to fade in.

PlayRandomVolume(AudioSource clip, float minVolume, float maxVolume)
Plays a sound effect with a randomly generated volume.

PlayPitchVary(AudioClip, float minPitch, float maxPitch) + 1 overload (AudioClip, float minPitch, float maxPitch, float resetPitchTime)
A function that plays a sound effect with a random pitch in a range you set.
The pitch is reset back to 1 after the sound has stopped playing.

PlayFocus() + 1 overload (bool unFocus, AudioClip clip)
A function that pauses every Audio Source in the scene except the one this function is called from.
The bool "reFocus" will run PlayUnFocus() when the clip is over.

PlayUnFocus()
The opposite of PlayFocus().

FadeTracks(AudioClip, float time)
Fades out the current track, sets a new track and then fades in the new one.

FadeOut(float time, bool stop) 
Fades out the current track.

FadeIn(float time) + 3 overloads (float time, float startingVolume) (float time, AudioClip clip) (float time, AudioClip clip, float startingVolume)
Fades in the current track.

** CREDITS **
Developer: Sivert N. Hjortland
Special Thanks: Eskil Dahl Pettersen