﻿using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using KNBNDesktopUI.Library.Api;
using KNBNDesktopUI.Library.Models;

namespace KNBNDesktopUI.ViewModels
{
    public class GroupViewModel : Screen
    {
        private readonly StatusInfoViewModel _status;
        private readonly IWindowManager _window;
        private readonly IUserEndpoint _userEndpoint;
        private readonly IGroupEndpoint _groupEndpoint;


        BindingList<GroupModel> _groups;

        public GroupViewModel(StatusInfoViewModel status, IWindowManager window, IUserEndpoint userEndpoint, IGroupEndpoint groupEndpoint)
        {
            _status = status;
            _window = window;
            _userEndpoint = userEndpoint;
            _groupEndpoint = groupEndpoint;
        }

        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);

            try
            {
                await LoadGroups();
            }
            catch (Exception ex)
            {
                dynamic settings = new ExpandoObject();
                settings.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                settings.ResizeMode = ResizeMode.NoResize;
                settings.Title = "System Error";

                switch (ex.Message)
                {
                    case "Unauthorized":
                        _status.UpdateMessage("Unauthorized Acces", "You shall not passed!");
                        await _window.ShowDialogAsync(_status, null, settings);
                        break;

                    case "Internal Server Error":
                        _status.UpdateMessage("Internal Server Error", "You shall not passed!");
                        await _window.ShowDialogAsync(_status, null, settings);
                        break;

                    default:
                        break;
                }
                
                if (ex.Message == "Unauthorized")
                {
                    _status.UpdateMessage("Unauthorized Acces", "You shall not passed!");
                    await _window.ShowDialogAsync(_status, null, settings);

                }
            }
        }
        // Load all groups
        private async Task LoadGroups()
        {
            var groupList = await _groupEndpoint.GetAll();
            Groups = new BindingList<GroupModel>(groupList);
        }


        private string SelectedGroupName;

        private GroupModel _selectedGroup;
        public GroupModel SelectedGroup
        {
            get { return _selectedGroup; }
            set
            {
                _selectedGroup = value;
                SelectedGroupName = value.Name;

            }
        }



        public BindingList<GroupModel> Groups
        {
            get 
            { 
                return _groups; 
            }
            set
            {
                _groups = value;
                NotifyOfPropertyChange(() => Groups);
            }
        }


        /* SQL CALL ON LOAD*/
    }
}