﻿// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

#nullable disable

using Foundation;
using osu.Framework.iOS;
using osu.Game.Tests;

namespace osu.Game.Rulesets.Catch.Tests.iOS
{
    [Register("AppDelegate")]
    public class AppDelegate : GameAppDelegate
    {
        protected override Framework.Game CreateGame() => new OsuTestBrowser();
    }
}
