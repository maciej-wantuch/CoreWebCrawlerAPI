﻿using System;
using System.Collections.Generic;
using CoreWebCrawlerAPI.Models;

namespace CoreWebCrawlerAPI.Interfaces
{
    public interface TrinketsInterface
    {
        bool DoesTrinketExist(string id);

        IEnumerable<Trinket> All { get; }

        Trinket Find(string id);

        void Insert(Trinket trinket);

        void Update(Trinket trinked);

        void Delete(string id);
    }
}