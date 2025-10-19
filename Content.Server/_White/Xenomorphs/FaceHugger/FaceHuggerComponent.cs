using Content.Shared.Body.Part;
using Content.Shared.Damage;
using Content.Shared.Whitelist;
using Robust.Shared.Audio;
using Robust.Shared.Prototypes;

namespace Content.Server._White.Xenomorphs.FaceHugger;

[RegisterComponent]
public sealed partial class FaceHuggerComponent : Component
{
    [DataField]
    public (BodyPartType Type, BodyPartSymmetry Symmetry) InfectionBodyPart = (BodyPartType.Chest, BodyPartSymmetry.None);

    [DataField]
    public DamageSpecifier DamageOnImpact = new();

    [DataField]
    public DamageSpecifier DamageOnInfect = new();

    [DataField]
    public EntityWhitelist? Blacklist;

    [DataField]
    public EntProtoId? InfectionPrototype = "XenomorphInfection";

    [DataField]
    public string BlockingSlot = "head";

    [DataField]
    public string InfectionSlotId = "xenomorph_larva";

    [DataField]
    public string Slot = "mask";

    [DataField]
    public SoundSpecifier SoundOnImpact = new SoundCollectionSpecifier("MetalThud");

    [DataField]
    public TimeSpan KnockdownTime = TimeSpan.FromSeconds(5);

    [DataField]
    public TimeSpan MaxInfectTime = TimeSpan.FromSeconds(20);

    [DataField]
<<<<<<< HEAD
    public TimeSpan MaxRestTime = TimeSpan.FromSeconds(20);
=======
    public TimeSpan MaxRestTime = TimeSpan.FromSeconds(5); // Goobstation - 20 to 5. Facehuggers shouldn't take that long to recover.
>>>>>>> 34d528ea8a7d94c4210a4a9451241abc44543532

    [DataField]
    public TimeSpan MinInfectTime = TimeSpan.FromSeconds(10);

    [DataField]
<<<<<<< HEAD
    public TimeSpan MinRestTime = TimeSpan.FromSeconds(10);
=======
    public TimeSpan MinRestTime = TimeSpan.FromSeconds(2); // Goobstation - 10 to 2. Facehuggers shouldn't take that long to recover.
>>>>>>> 34d528ea8a7d94c4210a4a9451241abc44543532

    [ViewVariables]
    public bool Active = true;

    [ViewVariables]
    public TimeSpan InfectIn = TimeSpan.Zero;

    [ViewVariables]
    public TimeSpan RestIn = TimeSpan.Zero;
}
