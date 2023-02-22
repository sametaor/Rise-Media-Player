﻿using Rise.App.ViewModels;
using System;
using System.Collections.Generic;

namespace Rise.App.Helpers
{
    /// <summary>
    /// A cache for all delegates related to sorting and grouping.
    /// </summary>
    public static partial class CollectionViewDelegates
    {
        private readonly static Dictionary<string, Func<object, object>> _delegates = new()
        {
            { "SongDisc", s => ((SongViewModel)s).Disc },
            { "SongTrack", s => ((SongViewModel)s).Track },

            { "SongTitle", s => ((SongViewModel)s).Title },
            { "SongAlbum", s => ((SongViewModel)s).Track },
            { "SongArtist", s => ((SongViewModel)s).Artist },
            { "SongGenres", s => ((SongViewModel)s).Genres },
            { "SongYear", s => ((SongViewModel)s).Year },

            { "GSongTitle", GSongTitle },
            { "GSongAlbum", s => ((SongViewModel)s).Album },
            { "GSongArtist", s => ((SongViewModel)s).Artist },
            { "GSongGenres", s => ((SongViewModel)s).Genres },
            { "GSongYear", s => ((SongViewModel)s).Year },

            { "AlbumTitle", a => ((AlbumViewModel)a).Title },
            { "AlbumArtist", a => ((AlbumViewModel)a).Artist },
            { "AlbumGenres", a => ((AlbumViewModel)a).Genres },
            { "AlbumYear", a => ((AlbumViewModel)a).Year },

            { "GAlbumTitle", GAlbumTitle },
            { "GAlbumArtist", a => ((AlbumViewModel)a).Artist },
            { "GAlbumGenres", a => ((AlbumViewModel)a).Genres },
            { "GAlbumYear", a => ((AlbumViewModel)a).Year },

            { "VideoTitle", v => ((VideoViewModel)v).Title },
            { "VideoYear", v => ((VideoViewModel)v).Year },
            { "VideoLength", v => ((VideoViewModel)v).Year },

            { "GVideoTitle", GVideoTitle },
            { "GVideoYear", v => ((VideoViewModel)v).Year },
        };

        public static Func<object, object> GetDelegate(string key)
            => _delegates[key];

        public static bool TryGetDelegate(string key, out Func<object, object> del)
            => _delegates.TryGetValue(key, out del);
    }

    // Grouping delegates
    public static partial class CollectionViewDelegates
    {
        private static object GSongTitle(object s)
            => ToGroupHeader(((SongViewModel)s).Title[0]);

        private static object GAlbumTitle(object a)
            => ToGroupHeader(((AlbumViewModel)a).Title[0]);

        private static object GVideoTitle(object v)
            => ToGroupHeader(((VideoViewModel)v).Title[0]);

        private static char ToGroupHeader(char c)
        {
            if (char.IsLetter(c))
                return char.ToUpper(c);
            return '#';
        }
    }
}
