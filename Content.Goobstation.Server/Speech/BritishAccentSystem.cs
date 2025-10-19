using Content.Goobstation.Common.Speech;
<<<<<<< HEAD
using Content.Server.Speech;
using Content.Server.Speech.EntitySystems;
=======
using Content.Server.Speech.EntitySystems;
using Content.Shared.Speech;
>>>>>>> 34d528ea8a7d94c4210a4a9451241abc44543532
using Robust.Shared.Random;

namespace Content.Goobstation.Server.Speech;

public sealed class BritishAccentSystem : EntitySystem
<<<<<<< HEAD
{   //shamelessly stolen from the dementia accent
=======
{
    //shamelessly stolen from the dementia accent
>>>>>>> 34d528ea8a7d94c4210a4a9451241abc44543532
    [Dependency] private readonly IRobustRandom _random = default!;
    [Dependency] private readonly ReplacementAccentSystem _replacement = default!;

    public override void Initialize()
    {
        base.Initialize();
        SubscribeLocalEvent<BritishAccentComponent, AccentGetEvent>(OnAccent);
    }

    private void OnAccent(EntityUid uid, BritishAccentComponent component, AccentGetEvent args)
    {
        var message = args.Message;

        message = _replacement.ApplyReplacements(message, "british");

        // Prefix
        if (_random.Prob(0.10f))
        {
            var pick = _random.Next(1, 5);

            // Reverse sanitize capital
            message = message[0].ToString().ToLower() + message.Remove(0, 1);
            message = Loc.GetString($"accent-british-prefix-{pick}") + " " + message;
        }

        // Sanitize capital again, in case we substituted a word that should be capitalized
        message = message[0].ToString().ToUpper() + message.Remove(0, 1);

        // Suffixes
        if (_random.Prob(0.05f))
        {
            var pick = _random.Next(1, 6);
            message += Loc.GetString($"accent-british-suffix-{pick}");
        }

        args.Message = message;
    }
<<<<<<< HEAD
};
=======
};
>>>>>>> 34d528ea8a7d94c4210a4a9451241abc44543532
