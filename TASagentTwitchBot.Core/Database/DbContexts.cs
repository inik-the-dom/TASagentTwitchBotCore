﻿using Microsoft.EntityFrameworkCore;

namespace TASagentTwitchBot.Core.Database;

//Create the database 
public abstract class BaseDatabaseContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Quote> Quotes { get; set; } = null!;
    public DbSet<CustomTextCommand> CustomTextCommands { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder options) =>
        options.UseSqlite($"Data Source={BGC.IO.DataManagement.PathForDataFile("Config", "data.sqlite")}");
}

public class User
{
    public int UserId { get; set; }

    public string TwitchUserName { get; set; } = null!;
    public string TwitchUserId { get; set; } = null!;

    public DateTime? FirstSeen { get; set; }
    public DateTime? FirstFollowed { get; set; }

    public TTS.TTSVoice TTSVoicePreference { get; set; }
    public TTS.TTSPitch TTSPitchPreference { get; set; }
    public TTS.TTSSpeed TTSSpeedPreference { get; set; }
    public string? TTSEffectsChain { get; set; }
    public DateTime? LastSuccessfulTTS { get; set; }

    public Commands.AuthorizationLevel AuthorizationLevel { get; set; }
    public List<Quote> QuotesCreated { get; } = new List<Quote>();

    public string? Color { get; set; }
}

public class CustomTextCommand
{
    public int CustomTextCommandId { get; set; }

    public string Command { get; set; } = null!;
    public string Text { get; set; } = null!;
    public bool Enabled { get; set; }
}

public class Quote
{
    public int QuoteId { get; set; }

    public string QuoteText { get; set; } = null!;
    public string Speaker { get; set; } = null!;
    public DateTime CreateTime { get; set; }

    public int CreatorId { get; set; }
    public User Creator { get; set; } = null!;

    public bool IsFakeNews { get; set; }
    public string? FakeNewsExplanation { get; set; }
}
