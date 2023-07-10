﻿// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See LICENSE.txt in the project root for license information.

// ReSharper disable once CheckNamespace

namespace SpeedBoot;

public interface ISpeedBootApplication
{
    IServiceCollection Services { get; }

    IServiceProvider? RootServiceProvider { get; }

    void Shutdown();
}
