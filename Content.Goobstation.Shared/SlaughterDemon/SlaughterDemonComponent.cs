// SPDX-FileCopyrightText: 2025 GoobBot <uristmchands@proton.me>
// SPDX-FileCopyrightText: 2025 Lumminal <81829924+Lumminal@users.noreply.github.com>
//
// SPDX-License-Identifier: AGPL-3.0-or-later

<<<<<<< HEAD
using Content.Shared.Damage;
=======
>>>>>>> 34d528ea8a7d94c4210a4a9451241abc44543532
using Robust.Shared.Audio;
using Robust.Shared.GameStates;
using Robust.Shared.Prototypes;

namespace Content.Goobstation.Shared.SlaughterDemon;

[RegisterComponent, NetworkedComponent]
<<<<<<< HEAD
=======
[AutoGenerateComponentState]
>>>>>>> 34d528ea8a7d94c4210a4a9451241abc44543532
public sealed partial class SlaughterDemonComponent : Component
{
    /// <summary>
    /// The list of mobs that the entity has devoured/consumed.
    /// </summary>
<<<<<<< HEAD
    [DataField]
    public List<EntityUid?> ConsumedMobs { get; set; } = new();
=======
    [DataField, AutoNetworkedField]
    public List<EntityUid> ConsumedMobs { get; set; } = new();
>>>>>>> 34d528ea8a7d94c4210a4a9451241abc44543532

    /// <summary>
    /// The number of devoured mobs.
    /// </summary>
<<<<<<< HEAD
    [DataField]
=======
    [DataField, AutoNetworkedField]
>>>>>>> 34d528ea8a7d94c4210a4a9451241abc44543532
    public int Devoured;

    /// <summary>
    /// The walk modifier the entity gets once it stands on blood.
    /// </summary>
    [DataField]
    public float SpeedModWalk = 3f;

    /// <summary>
    /// The speed modifier the entity gets once it stands on blood.
    /// </summary>
    [DataField]
    public float SpeedModRun = 3f;

    /// <summary>
    /// This indicates whether the entity exited blood crawl
    /// </summary>
<<<<<<< HEAD
    [ViewVariables]
=======
    [ViewVariables, AutoNetworkedField]
>>>>>>> 34d528ea8a7d94c4210a4a9451241abc44543532
    public bool ExitedBloodCrawl;

    /// <summary>
    /// The accumulator for when a Slaughter Demon exits blood crawl
    /// </summary>
<<<<<<< HEAD
    [DataField]
=======
    [DataField, AutoNetworkedField]
>>>>>>> 34d528ea8a7d94c4210a4a9451241abc44543532
    public TimeSpan Accumulator = TimeSpan.Zero;

    /// <summary>
    /// How long the speed boost lasts after a Slaughter Demon exits blood crawl
    /// </summary>
    [DataField]
    public TimeSpan NextUpdate = TimeSpan.FromSeconds(6f);

    /// <summary>
    /// The jaunt effect when entering the jaunt
    /// </summary>
    [DataField]
    public EntProtoId JauntEffect = "SlaughterDemonJauntEffect";

    /// <summary>
    /// The jaunt effect when exiting the jaunt
    /// </summary>
    [DataField]
    public EntProtoId JauntUpEffect = "SlaughterDemonJauntUpEffect";

    /// <summary>
    /// Is the demon a Lesser Demon?
    /// </summary>
    [DataField]
    public bool IsLesser;

    /// <summary>
    /// Is the demon the Laughter Demon?
    /// </summary>
    [DataField]
    public bool IsLaughter;

    /// <summary>
<<<<<<< HEAD
    ///  Sound that plays once the demon dies
    /// </summary>
    [DataField]
    public SoundSpecifier? DeathSound = new SoundPathSpecifier("/Audio/Effects/demon_dies.ogg");
=======
    /// Plays when a demon blood crawls.
    /// </summary>
    [DataField(required: true)]
    public SoundSpecifier BloodCrawlSounds;

    [DataField]
    public float BloodCrawlSoundLookup = 10f;

    [DataField]
    public float BloodCrawlSoundChance = 0.25f;
>>>>>>> 34d528ea8a7d94c4210a4a9451241abc44543532
}


