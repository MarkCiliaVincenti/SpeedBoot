﻿// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See LICENSE.txt in the project root for license information.

namespace Speed.Boot.Data.Abstractions;

public interface IDbContextProvider
{
    IDbContext GetDbContext<TEntity>(DbOperateTypes operateType) where TEntity : class, IEntity;
}
