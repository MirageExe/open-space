using Content.Shared.Actions;
using Content.Shared.Actions.Components;
using Content.Shared.Chemistry.EntitySystems;
using Content.Shared.Fluids.Components;
using Content.Shared.Polymorph;
using Content.Shared.Popups;
using Robust.Shared.Audio.Systems;
<<<<<<< HEAD
=======
using Robust.Shared.Network;
>>>>>>> 34d528ea8a7d94c4210a4a9451241abc44543532
using Robust.Shared.Prototypes;

namespace Content.Goobstation.Shared.SlaughterDemon.Systems;


/// <summary>
/// This handles the blood crawl system.
/// Blood Crawl allows you to jaunt, as long as you activate it in a pool of blood.
/// To exit the jaunt, you must also stand on a poll of blood.
/// </summary>
public abstract class SharedBloodCrawlSystem : EntitySystem
{
    [Dependency] private readonly SharedActionsSystem _actions = default!;
    [Dependency] private readonly EntityLookupSystem _lookup = default!;
    [Dependency] private readonly SharedSolutionContainerSystem _solutionContainerSystem = default!;
    [Dependency] private readonly SharedAudioSystem _audio = default!;
    [Dependency] private readonly SharedPopupSystem _popup = default!;
<<<<<<< HEAD
=======
    [Dependency] private readonly INetManager _netManager = default!;
>>>>>>> 34d528ea8a7d94c4210a4a9451241abc44543532

    private EntityQuery<ActionsComponent> _actionQuery;
    private EntityQuery<PuddleComponent> _puddleQuery;

    /// <inheritdoc/>
    public override void Initialize()
    {
        base.Initialize();
        _actionQuery = GetEntityQuery<ActionsComponent>();
        _puddleQuery = GetEntityQuery<PuddleComponent>();

        SubscribeLocalEvent<BloodCrawlComponent, ComponentStartup>(OnStartup);

        SubscribeLocalEvent<BloodCrawlComponent, BloodCrawlEvent>(OnBloodCrawl);
    }

    private void OnStartup(EntityUid uid, BloodCrawlComponent component, ComponentStartup args)
    {
        if (!_actionQuery.TryGetComponent(uid, out var actions))
            return;

        _actions.AddAction(uid, component.ActionId, component: actions);
    }

    private void OnBloodCrawl(EntityUid uid, BloodCrawlComponent component, BloodCrawlEvent args)
    {
<<<<<<< HEAD
        if (!IsStandingOnBlood(uid))
        {
            _popup.PopupEntity(Loc.GetString("slaughter-blood-jaunt-fail"), uid);
=======
        if (!IsStandingOnBlood((uid, component)))
        {
            _popup.PopupPredicted(Loc.GetString("slaughter-blood-jaunt-fail"), uid, uid);
>>>>>>> 34d528ea8a7d94c4210a4a9451241abc44543532
            _actions.SetCooldown(args.Action.Owner, component.ActionCooldown);
            return;
        }

        component.IsCrawling = !component.IsCrawling;
<<<<<<< HEAD
=======
        Dirty(uid, component);
>>>>>>> 34d528ea8a7d94c4210a4a9451241abc44543532

        if (!CheckAlreadyCrawling((uid, component)))
            return;

        var evAttempt = new BloodCrawlAttemptEvent();
        RaiseLocalEvent(uid, ref evAttempt);

        if (evAttempt.Cancelled)
            return;

<<<<<<< HEAD
        _audio.PlayPvs(component.EnterJauntSound, Transform(uid).Coordinates);
=======
        _audio.PlayPredicted(component.EnterJauntSound, Transform(uid).Coordinates, uid);
>>>>>>> 34d528ea8a7d94c4210a4a9451241abc44543532

        PolymorphDemon(uid, component.Jaunt);

        args.Handled = true;
    }

    #region Helper Functions

    /// <summary>
    /// Detects if an entity is standing on blood, or not.
    /// </summary>
<<<<<<< HEAD
    public bool IsStandingOnBlood(Entity<BloodCrawlComponent?> ent)
    {
        if (!Resolve(ent.Owner, ref ent.Comp))
            return false;

=======
    public bool IsStandingOnBlood(Entity<BloodCrawlComponent> ent)
    {
>>>>>>> 34d528ea8a7d94c4210a4a9451241abc44543532
        var ents = _lookup.GetEntitiesInRange(ent.Owner, ent.Comp.SearchRange);
        foreach (var entity in ents)
        {
            if (!_puddleQuery.TryComp(entity, out var puddle))
                continue;

            if (!_solutionContainerSystem.ResolveSolution(entity, puddle.SolutionName, ref puddle.Solution, out var solution))
                continue;

            foreach (var reagent in solution.Contents)
            {
                if (ent.Comp.Blood.Contains(reagent.Reagent.Prototype)
                    && reagent.Quantity >= ent.Comp.RequiredReagentAmount)
                    return true;
            }
        }
        return false;
    }

    protected virtual bool CheckAlreadyCrawling(Entity<BloodCrawlComponent> ent)
    {
        return false;
    }

    protected virtual void PolymorphDemon(EntityUid user, ProtoId<PolymorphPrototype> polymorph) {}

    #endregion
}
