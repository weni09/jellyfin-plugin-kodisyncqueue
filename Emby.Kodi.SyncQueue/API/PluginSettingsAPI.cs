﻿using Emby.Kodi.SyncQueue.Entities;
using MediaBrowser.Model.Serialization;
using System;
using MediaBrowser.Model.Services;
using Microsoft.Extensions.Logging;

namespace Emby.Kodi.SyncQueue.API
{
    public class PluginSettingsAPI : IService
    {
        private readonly ILogger _logger;
        private readonly IJsonSerializer _jsonSerializer;

        public PluginSettingsAPI(ILogger logger, IJsonSerializer jsonSerializer)
        {
            _logger = logger;
            _jsonSerializer = jsonSerializer;
        }

        public PluginSettings Get(GetPluginSettings request)
        {
            _logger.LogInformation("Emby.Kodi.SyncQueue: Plugin Settings Requested...");
            var settings = new PluginSettings();
            _logger.LogDebug("Emby.Kodi.SyncQueue: Class Variable Created!");
            int retDays = 0;
            DateTime dtNow = DateTime.UtcNow;
            
            _logger.LogDebug("Emby.Kodi.SyncQueue: Creating Settings Object Variables!");

            if (!(Int32.TryParse(Plugin.Instance.Configuration.RetDays, out retDays)))
            {
                retDays = 0;
            }

            settings.RetentionDays = retDays;
            settings.IsEnabled = Plugin.Instance.Configuration.IsEnabled;
            settings.TrackMovies = Plugin.Instance.Configuration.tkMovies;
            settings.TrackTVShows = Plugin.Instance.Configuration.tkTVShows;
            settings.TrackBoxSets = Plugin.Instance.Configuration.tkBoxSets;
            settings.TrackMusic = Plugin.Instance.Configuration.tkMusic;
            settings.TrackMusicVideos = Plugin.Instance.Configuration.tkMusicVideos;
            
            _logger.LogDebug("Emby.Kodi.SyncQueue: Sending Settings Object Back.");

            return settings;
        }
    }
}
