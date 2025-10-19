using Content.Shared.Damage;
using Robust.Shared.Prototypes;

namespace Content.Shared._White.Xenomorphs.Acid.Components;

[RegisterComponent]
public sealed partial class XenomorphAcidComponent : Component
{
    [DataField]
<<<<<<< HEAD
    public EntProtoId AcidActionId = "ActionAcid";

    [DataField]
=======
>>>>>>> 34d528ea8a7d94c4210a4a9451241abc44543532
    public EntProtoId AcidId = "XenomorphAcid";

    [DataField]
    public TimeSpan AcidLifeTime = TimeSpan.FromSeconds(100);

    [DataField]
    public DamageSpecifier DamagePerSecond;
<<<<<<< HEAD

    [ViewVariables]
    public EntityUid? AcidAction;
=======
>>>>>>> 34d528ea8a7d94c4210a4a9451241abc44543532
}
