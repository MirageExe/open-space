using Content.Shared._White.Xenomorphs;
using Content.Shared._White.Xenomorphs.Plasma;
using Content.Shared.Actions;
using Content.Shared.Actions.Events;

namespace Content.Shared._White.Actions;

public sealed class PlasmaCostActionSystem : EntitySystem
{
    [Dependency] private readonly SharedActionsSystem _actions = default!;
    [Dependency] private readonly SharedPlasmaSystem _plasma = default!;

    public override void Initialize()
    {
        SubscribeLocalEvent<PlasmaCostActionComponent, ActionRelayedEvent<PlasmaAmountChangeEvent>>(OnPlasmaAmountChange);
<<<<<<< HEAD
=======
        SubscribeLocalEvent<PlasmaCostActionComponent, ActionAttemptEvent>(OnActionAttempt); // Goobstation
>>>>>>> 34d528ea8a7d94c4210a4a9451241abc44543532
        SubscribeLocalEvent<PlasmaCostActionComponent, ActionPerformedEvent>(OnActionPerformed);
    }

    private void OnPlasmaAmountChange(EntityUid uid, PlasmaCostActionComponent component, ActionRelayedEvent<PlasmaAmountChangeEvent> args)
    {
        _actions.SetEnabled(uid, component.PlasmaCost <= args.Args.Amount);
    }

<<<<<<< HEAD
=======
    // <Goobstation>
    private void OnActionAttempt(Entity<PlasmaCostActionComponent> ent, ref ActionAttemptEvent args)
    {
        if (!_plasma.HasPlasma(args.User, ent.Comp.PlasmaCost))
            args.Cancelled = true;
    }
    // </Goobstation>

>>>>>>> 34d528ea8a7d94c4210a4a9451241abc44543532
    private void OnActionPerformed(EntityUid uid, PlasmaCostActionComponent component, ActionPerformedEvent args)
    {
        if (component.ShouldChangePlasma)
            _plasma.ChangePlasmaAmount(args.Performer, -component.PlasmaCost);
    }
}
