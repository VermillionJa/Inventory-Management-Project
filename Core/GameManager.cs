﻿using Inventory_Management_Project.Scenes;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_Project.Core
{
    public class GameManager
    {
        private readonly SceneManager _sceneManager;
        private readonly DisplayManager _displayManager;
        private readonly IServiceProvider _serviceProvider;

        public GameManager(SceneManager sceneManager, DisplayManager displayManager, IServiceProvider serviceProvider)
        {
            _sceneManager = sceneManager;
            _displayManager = displayManager;
            _serviceProvider = serviceProvider;

            _sceneManager.OnExitGameRequest += OnExitGameRequested;
            InitializeScenes();
        }

        public void Start()
        {
            _sceneManager.ChangeScene<IntroScene>();
        }

        private void InitializeScenes()
        {
            _sceneManager.AddScene(_serviceProvider.GetRequiredService<IntroScene>());
            _sceneManager.AddScene(_serviceProvider.GetRequiredService<MainMenuScene>());
        }

        private void OnExitGameRequested()
        {
            Environment.Exit(0);
        }
    }
}
