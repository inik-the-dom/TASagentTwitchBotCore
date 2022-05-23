﻿
using TASagentTwitchBot.Core.Audio;
using TASagentTwitchBot.Core.Audio.Effects;

namespace TASagentTwitchBot.Core.TTS;

public interface ITTSRenderer
{
    Task<bool> SetTTSEnabled(bool enabled);

    Task<AudioRequest?> TTSRequest(
        Commands.AuthorizationLevel authorizationLevel,
        TTSVoice voicePreference,
        TTSPitch pitchPreference,
        TTSSpeed speedPreference,
        Effect effectsChain,
        string ttsText);
}
