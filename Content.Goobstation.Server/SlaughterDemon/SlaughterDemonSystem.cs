// SPDX-FileCopyrightText: 2025 GoobBot <uristmchands@proton.me>
// SPDX-FileCopyrightText: 2025 Lumminal <81829924+Lumminal@users.noreply.github.com>
//
// SPDX-License-Identifier: AGPL-3.0-or-later

<<<<<<< HEAD
=======
using Content.Goobstation.Common.Devour;
>>>>>>> 34d528ea8a7d94c4210a4a9451241abc44543532
using Content.Goobstation.Shared.SlaughterDemon;
using Content.Goobstation.Shared.SlaughterDemon.Systems;
using Content.Server.Administration.Systems;
using Content.Server.Body.Components;
using Content.Server.Body.Systems;
<<<<<<< HEAD
=======
using Content.Shared.Body.Components;
using Content.Shared.Body.Events;
>>>>>>> 34d528ea8a7d94c4210a4a9451241abc44543532
using Robust.Shared.Containers;

namespace Content.Goobstation.Server.SlaughterDemon;

public sealed class SlaughterDemonSystem : SharedSlaughterDemonSystem
{
    [Dependency] private readonly RejuvenateSystem _rejuvenate = default!;
    [Dependency] private readonly SharedContainerSystem _container = default!;
    [Dependency] private readonly BloodstreamSystem _bloodstream = default!;

<<<<<<< HEAD
=======
    private EntityQuery<BloodstreamComponent> _bloodstreamQuery;

>>>>>>> 34d528ea8a7d94c4210a4a9451241abc44543532
    /// <inheritdoc/>
    public override void Initialize()
    {
        base.Initialize();

<<<<<<< HEAD
=======
        _bloodstreamQuery = GetEntityQuery<BloodstreamComponent>();

>>>>>>> 34d528ea8a7d94c4210a4a9451241abc44543532
        SubscribeLocalEvent<SlaughterDemonComponent, BeingGibbedEvent>(OnGib);
    }

    private void OnGib(Entity<SlaughterDemonComponent> ent, ref BeingGibbedEvent args)
    {
<<<<<<< HEAD
        if (!TryComp<SlaughterDevourComponent>(ent.Owner, out var devour))
=======
        if (!TryComp<SlaughterDevourComponent>(ent.Owner, out var devour)
            || devour.Container == null)
>>>>>>> 34d528ea8a7d94c4210a4a9451241abc44543532
            return;

        _container.EmptyContainer(devour.Container);

<<<<<<< HEAD
=======
        // Allow everyone to self revive again (if they have the ability to)
        foreach (var entity in ent.Comp.ConsumedMobs)
            RemComp<PreventSelfRevivalComponent>(entity);

>>>>>>> 34d528ea8a7d94c4210a4a9451241abc44543532
        // heal them if they were in the laughter demon
        if (!ent.Comp.IsLaughter)
            return;

        foreach (var entity in ent.Comp.ConsumedMobs)
<<<<<<< HEAD
        {
            if (entity == null)
                continue;

            _rejuvenate.PerformRejuvenate(entity.Value);
        }
=======
            _rejuvenate.PerformRejuvenate(entity);
>>>>>>> 34d528ea8a7d94c4210a4a9451241abc44543532
    }

    protected override void RemoveBlood(EntityUid uid)
    {
        base.RemoveBlood(uid);

<<<<<<< HEAD
        _bloodstream.SpillAllSolutions(uid);
=======
        if (!_bloodstreamQuery.TryComp(uid, out var comp))
            return;

        _bloodstream.SpillAllSolutions((uid, comp));
>>>>>>> 34d528ea8a7d94c4210a4a9451241abc44543532
    }
}
